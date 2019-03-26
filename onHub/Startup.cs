using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;


using onHub.App_Code;
using System.Data.SqlClient;
using Newtonsoft.Json;

// including the M2Mqtt Library
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Text;

[assembly: OwinStartup(typeof(airQ.Startup))]

namespace airQ
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
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
            string ReceivedMessage = Encoding.UTF8.GetString(e.Message);
            string topic = e.Topic;
            onmotica.saveIntoDB(ReceivedMessage, topic);
        }
        void client_MqttMsgPublishReceived1(object sender, MqttMsgPublishEventArgs e)
        {
            string ReceivedMessage = Encoding.UTF8.GetString(e.Message);
            string topic = e.Topic;
            onmotica.saveIntoDB(ReceivedMessage, topic);
        }
        void client_MqttMsgPublishReceived2(object sender, MqttMsgPublishEventArgs e)
        {
            string ReceivedMessage = Encoding.UTF8.GetString(e.Message);
            string topic = e.Topic;
            onmotica.saveIntoDB(ReceivedMessage, topic);
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
    }

}
