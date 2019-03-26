using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using onHub.App_Code;
using onmoticaData.BLL;
using System.Data.SqlClient;

// including the M2Mqtt Library
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Text;


//Libreria signalR
using airQ.Hubs;
using Microsoft.AspNet.SignalR;

//Qr Generator
using System.IO;
using System.Drawing;
using MessagingToolkit.QRCode.Codec;
using System.Drawing.Imaging;

namespace airQ
{
    public partial class dashboard1 : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            onmotica.isLogged(Session, Response,"dashboard");

        }
        void Page_LoadComplete(object sender, EventArgs e)
        {
            #region validationDeviceSeelctedOrNull
            if (Session["deviceName"] != null & Session["deviceId"] != null)
            {
                lblTittle.Text = Session["deviceName" + Session["deviceId"].ToString()].ToString();
                divMeters.Visible = true;
            }
            else
            {
                lblTittle.Text = "No tienes dispositivos registrados, haz clic en registrar nuevo dispositivo...";
                divMeters.Visible = false;
            }
            #endregion
            mqttConection();
        }

        #region mqttConection

        public void mqttConection()
        {

            String[] mqtt_server = { "test.mosquitto.org", "iot.eclipse.org", "157.230.174.83" };

            int numTopic = getCountOfTopics();
            String[] topics = new string[numTopic];

            var counter = 0;
            var pSQL = "SELECT distinct inTopic from thing";
            using (SqlDataReader dr = onmotica.fetchReader(pSQL))
            {
                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        topics[counter] = dr["inTopic"].ToString();
                        counter++;
                    }
                }
            }

            connectBroker1(topics, mqtt_server);
            connectBroker2(topics, mqtt_server);
            connectBroker3(topics, mqtt_server);

        }
        #endregion

        #region msgReceivedEvent
        // this code runs when a message was received
        void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            var inTopic = e.Topic;
            string ReceivedMessage = Encoding.UTF8.GetString(e.Message);
            var context = GlobalHost.ConnectionManager.GetHubContext<dashboardHub>();
            context.Clients.All.updateInfo(ReceivedMessage, inTopic);
        }
        void client_MqttMsgPublishReceived1(object sender, MqttMsgPublishEventArgs e)
        {
            var inTopic = e.Topic;
            string ReceivedMessage = Encoding.UTF8.GetString(e.Message);
            var context = GlobalHost.ConnectionManager.GetHubContext<dashboardHub>();
            context.Clients.All.updateInfo(ReceivedMessage, inTopic);
        }
        void client_MqttMsgPublishReceived2(object sender, MqttMsgPublishEventArgs e)
        {
            var inTopic = e.Topic;
            string ReceivedMessage = Encoding.UTF8.GetString(e.Message);
            var context = GlobalHost.ConnectionManager.GetHubContext<dashboardHub>();
            context.Clients.All.updateInfo(ReceivedMessage, inTopic);
        }
        #endregion

        #region countTopics
        public int getCountOfTopics()
        {
            var count = 0;
            var pSQL = "SELECT COUNT(distinct(inTopic)) AS total from thing";
            using (SqlDataReader dr = onmotica.fetchReader(pSQL))
            {
                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        count = (int)dr["total"];
                    }
                }
            }
            return count;
        }
        #endregion

        #region brokers

        public void connectBroker1(string[] topics, String[] mqtt_server)
        {
            String BrokerAddress = "";
            MqttClient client;
            string clientId;
            try
            {

                BrokerAddress = mqtt_server[0];
                client = new MqttClient(BrokerAddress);
                // register a callback-function (we have to implement, see below) which is called by the library when a message was received
                client.MqttMsgPublishReceived += client_MqttMsgPublishReceived1;
                // use a unique id as client id, each time we start the application
                clientId = Guid.NewGuid().ToString();
                client.Connect(clientId);
                foreach (string topic in topics)
                {
                    client.Subscribe(new string[] { topic }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
                }
            }
            catch (Exception error)
            {
                onmotica.saveInLogMQTT(error);
            }
            finally
            {

            }
        }

        public void connectBroker2(string[] topics, String[] mqtt_server)
        {
            String BrokerAddress = "";
            MqttClient client;
            string clientId;
            try
            {

                BrokerAddress = mqtt_server[1];
                client = new MqttClient(BrokerAddress);
                // register a callback-function (we have to implement, see below) which is called by the library when a message was received
                client.MqttMsgPublishReceived += client_MqttMsgPublishReceived1;
                // use a unique id as client id, each time we start the application
                clientId = Guid.NewGuid().ToString();
                client.Connect(clientId);
                foreach (string topic in topics)
                {
                    client.Subscribe(new string[] { topic }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
                }
            }
            catch (Exception error)
            {
                onmotica.saveInLogMQTT(error);
            }
            finally
            {

            }
        }


        public void connectBroker3(string[] topics, String[] mqtt_server)
        {
            String BrokerAddress = "";
            MqttClient client;
            string clientId;
            try
            {

                BrokerAddress = mqtt_server[2];
                client = new MqttClient(BrokerAddress);
                // register a callback-function (we have to implement, see below) which is called by the library when a message was received
                client.MqttMsgPublishReceived += client_MqttMsgPublishReceived1;
                // use a unique id as client id, each time we start the application
                clientId = Guid.NewGuid().ToString();
                client.Connect(clientId);
                foreach (string topic in topics)
                {
                    client.Subscribe(new string[] { topic }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
                }
            }
            catch (Exception error)
            {
                onmotica.saveInLogMQTT(error);
            }
            finally
            {

            }
        }
        #endregion

        #region WebMethods
        [System.Web.Services.WebMethod]
        public static List<onUserClass> getUserData()
        {
            int usrId = Convert.ToInt32(HttpContext.Current.Session["UsrID"]);
            BLLOnmotica vDashboard = new BLLOnmotica(usrId);
            var usrData = vDashboard.getUserData();
            return usrData;
        }
        #endregion
    }
}