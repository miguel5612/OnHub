using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text.RegularExpressions;
using System.IO;


using System.Data.SqlClient;
using System.Globalization;
using Newtonsoft.Json;


namespace onHub.App_Code
{
    //onmotica is an Miguel Califa creation :) 2018 C

    public class onmotica
    {

        public static string getBrokerAddress()
        {
            //return "68.183.31.237"; 157.230.174.83
            return "157.230.174.83"; 
        }
        public static string getAppFolder()
        {
            string folderPath = "";
            SqlDataReader dr = fetchReader("SELECT TOP(1) AppFolderPath FROM ServerInfo ORDER BY ServerInfoID DESC");
            while (dr.Read())
            {
                if (dr.HasRows)
                {
                    folderPath = dr["AppFolderPath"].ToString();
                }                
            }
            return folderPath;
        }

        public static void login(System.Web.SessionState.HttpSessionState Session, HttpResponse Response, string username, string password)
        {
            string pSQL = "SELECT * FROM [onUser] WHERE userName = '" + username + "' AND password = '" + password + "'";
            SqlDataReader dr = onmotica.fetchReader(pSQL);
            while (dr.Read())
            {
                Session["UsrID"] = dr["id"].ToString();
                Session["UsrName"] = dr["userName"].ToString();
                Session["userTypId"] = dr["userTypID"].ToString();
                Response.Redirect("/dashboard");
            }
        }
        public static void updateAppFolder(string Path)
        {
            executeSQL("UPDATE ServerInfo SET AppFolderPath = '"+ Path + "' WHERE ServerInfoID = 1");
        }
        public static void isLogged(System.Web.SessionState.HttpSessionState Session, HttpResponse Response, String location)
        {
            if (Session["UsrID"] != null & Session["UsrName"] != null)
            {
                if (Convert.ToInt32(Session["UsrID"]) > 0 & Session["UsrName"].ToString() != "" & (location == "default" || location == "login"))
                {
                    Response.Redirect("/dashboard");
                }
            }
            else if(location!="login" & location!="default")
            {
                Session.RemoveAll();
                Response.Redirect("/login");
            }
        }
        public static Double string2Double(string numero)
        {
            if (numero != "")
            {
                return Convert.ToDouble(numero.Replace(".", ","));
            }
            else
            {
                return 0;
            }
        }
        public static double NZDBNum(string pIn)
        {
            if(pIn == null)
            {
                return 0;
            }
            else
            {
                return string2Double(pIn);
            }

        }

        public static void saveIntoDB(string msg, string topic)
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";

            var pSQL = "INSERT INTO [measurements] ([inTopic], [registerDate], [status], [field1], [field2], [field3], [field4], [field5], [field6], [field7], [field8], [field9], [field10], [field11], [field12], [field13], [field14], [field15]) VALUES ('@inTopic', @registerAt, '@status', @field1, @field2, @field3, @field4, @field5, @field6, @field7, @field8, @field9, @field10, @field11, @field12, @field13, @field14, @field15, @field16)";

            try
            {
                dynamic jsonMesssage = JsonConvert.DeserializeObject(msg);

                pSQL = pSQL.Replace("@inTopic", topic);
                pSQL = pSQL.Replace("@registerAt", "CONVERT(datetime, '" + convertD2IDateTime(DateNow()) + "')");

                bool status = jsonMesssage.status == null ? 0 : jsonMesssage.status;
                pSQL = pSQL.Replace("@status", status.ToString());

                pSQL = pSQL.Replace("@field1", jsonMesssage.D1);
                pSQL = pSQL.Replace("@field2", jsonMesssage.D2);
                pSQL = pSQL.Replace("@field3", jsonMesssage.D3);
                pSQL = pSQL.Replace("@field4", jsonMesssage.D4);
                pSQL = pSQL.Replace("@field5", jsonMesssage.D5);
                pSQL = pSQL.Replace("@field6", jsonMesssage.D6);
                pSQL = pSQL.Replace("@field7", jsonMesssage.D7);
                pSQL = pSQL.Replace("@field8", jsonMesssage.D8);
                pSQL = pSQL.Replace("@field9", jsonMesssage.D9);
                pSQL = pSQL.Replace("@field10", jsonMesssage.D10);
                pSQL = pSQL.Replace("@field11", jsonMesssage.D11);
                pSQL = pSQL.Replace("@field12", jsonMesssage.D12);
                pSQL = pSQL.Replace("@field13", jsonMesssage.D13);
                pSQL = pSQL.Replace("@field14", jsonMesssage.D14);
                pSQL = pSQL.Replace("@field15", jsonMesssage.D15);

                executeSQLonHub(pSQL);
                
            }
            catch (Exception ex)
            {
                //("Error insertando el registro -- ", err);
                saveInLogMQTT(ex, msg);
            }
            finally
            {
            }
        }
        public static void saveInLogMQTT(Exception ex)
        {
            try
            {
                string pathFolder = @getAppFolder();
                string pathLog = @"Logs";
                string strFileName = "mosquitto.txt"; 

                string path = string.Format("{0}\\{1}\\{2}", pathFolder, pathLog, strFileName);
                FileStream objFilestream = new FileStream(path, FileMode.Append, FileAccess.Write);
            using (StreamWriter sw = new StreamWriter((Stream)objFilestream))
            {
                sw.WriteLine("=============Error Logging ===========");
                sw.WriteLine("===========Start============= " + DateTime.Now);
                sw.WriteLine("Error Message: " + ex.Message);
                sw.WriteLine("Stack Trace: " + ex.StackTrace);
                sw.WriteLine("Path App: " + path);
                sw.WriteLine("===========End============= " + DateTime.Now);

            }
            }
            catch (Exception Err)
            {

            }
        }
        public static void saveInLogMQTT(Exception ex, String jsonMsg)
        {
            try
            {
                string pathFolder = @getAppFolder();
                string pathLog = @"Logs";
                string strFileName = "mosquitto.txt";

                string path = string.Format("{0}\\{1}\\{2}", pathFolder, pathLog, strFileName);
                FileStream objFilestream = new FileStream(path, FileMode.Append, FileAccess.Write);
                using (StreamWriter sw = new StreamWriter((Stream)objFilestream))
                {
                    sw.WriteLine("=============Error Logging ===========");
                    sw.WriteLine("===========Start============= " + DateTime.Now);
                    sw.WriteLine("Error Message: " + ex.Message);
                    sw.WriteLine("Stack Trace: " + ex.StackTrace);
                    sw.WriteLine("Json Msg: " + jsonMsg);
                    sw.WriteLine("Path App: " + path);
                    sw.WriteLine("===========End============= " + DateTime.Now);

                }
            }
            catch (Exception Err)
            {

            }
        }
        public static void executeSQL(string query)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["onHubConnectionString"].ConnectionString);
            myConn.Open();
            cmd.CommandText = query;
            cmd.Connection = myConn;
            cmd.ExecuteNonQuery();
            myConn.Close();
        }
        public static void executeSQLMonitor3D(string query)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["onHubConnectionString"].ConnectionString);
            myConn.Open();
            cmd.CommandText = query;
            cmd.Connection = myConn;
            cmd.ExecuteNonQuery();
            myConn.Close();
        }
        public static void executeSQLonHub(string query)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["onHubConnectionString"].ConnectionString);
            myConn.Open();
            cmd.CommandText = query;
            cmd.Connection = myConn;
            cmd.ExecuteNonQuery();
            myConn.Close();
        }
        public static SqlDataReader fetchReader(string query)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["onHubConnectionString"].ConnectionString);
            myConn.Open();
            SqlCommand myCmd = new SqlCommand(query, myConn);
            SqlDataReader dr = myCmd.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }

        public static DataSet fetchData(string query)
        {
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["onHubConnectionString"].ConnectionString);
            SqlDataAdapter myAdapter = new SqlDataAdapter(query, myConn);
            DataSet myData = new DataSet();
            myAdapter.Fill(myData);
            return myData;
        }

        public static object fetchScalar(string query)
        {
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["onHubConnectionString"].ConnectionString);
            SqlCommand myCmd = new SqlCommand(query, myConn);
            myConn.Open();
            object scalar = myCmd.ExecuteScalar();
            myConn.Close();
            return scalar;
        }

        public static object fetchScalar(string query, int timeToWait)
        {
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["onHubConnectionString"].ConnectionString);
            SqlCommand myCmd = new SqlCommand(query, myConn);
            myConn.Open();
            myCmd.CommandTimeout = timeToWait;
            object scalar = myCmd.ExecuteScalar();
            myConn.Close();
            return scalar;
        }

        public static SqlDataReader fetchReader(SqlCommand myCmd)
        {
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["onHubConnectionString"].ConnectionString);
            myCmd.Connection = myConn;
            myConn.Open();
            return myCmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public static DataSet fetchData(SqlCommand myCmd)
        {
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["onHubConnectionString"].ConnectionString);
            myCmd.Connection = myConn;
            SqlDataAdapter myAdapter = new SqlDataAdapter(myCmd);
            DataSet myData = new DataSet();
            myAdapter.Fill(myData);
            return myData;
        }

        public static object fetchScalar(SqlCommand myCmd)
        {
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["onHubConnectionString"].ConnectionString);
            myCmd.Connection = myConn;
            myConn.Open();
            myCmd.CommandTimeout = 32400; //32400 sec = 9 hours
            object scalar = myCmd.ExecuteScalar();
            myConn.Close();
            return scalar;
        }
        public static DateTime DateNow()
        {
            DateTime utcTime = DateTime.UtcNow;
            TimeZoneInfo myZone = TimeZoneInfo.CreateCustomTimeZone("COLOMBIA", new TimeSpan(-5, 0, 0), "Colombia", "Colombia");
            DateTime custDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, myZone);
            return custDateTime;
        }
        public static string convertD2SQLDate(DateTime dt)
        {
            return dt.ToString("yyyy/MM/ddThh:mm:ss", CultureInfo.InvariantCulture);
        }
        public static string convertD2IDate(DateTime datum)
        {
            return DateTime.Parse(datum.ToString()).ToString("yyyyMMdd");
        }

        public static string convertD2IDateTime(DateTime datum)
        {
            return DateTime.Parse(datum.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string convertD2PGDate(string datum)
        {
            return DateTime.Parse(datum).ToString("dd.MM.yyyy");
        }

        public static string convertD2PGDateTime(string datum)
        {
            return DateTime.Parse(datum).ToString("dd.MM.yyyy HH:mm:ss");
        }

        public static string convertG2IDate(string datum)
        {
            return DateTime.Parse(datum).ToString("yyyyMMdd");
        }

    }
}