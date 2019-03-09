using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Linq;
using System.Text;
using onmoticaData;

namespace airQ.App_Code
{
    public class BLLOnmotica
    {
        private Int32 usrId;
        public BLLOnmotica(int pUsrId)
        {
            usrId = pUsrId;
        }

        
        public List<onUser> getUserData()
        {
            using (onHubEntities DB = new onHubEntities())
            {
                string strSQL = "SELECT * FROM onUser WHERE id = " + usrId.ToString();
                return DB.Database.SqlQuery<onUser>(strSQL).ToList();
            }
        }
        public List<personalData> getpersonalData()
        {
            using (onHubEntities DB = new onHubEntities())
            {
                string strSQL = "SELECT * FROM personalData WHERE id = " + usrId.ToString();
                return DB.Database.SqlQuery<personalData>(strSQL).ToList();
            }
        }
        public List<report> getReport(string inTopic, string name, int thingId, DateTime startDate)
        {
            using (onHubEntities DB = new onHubEntities())
            {
                string strSQL = "INSERT INTO report (name, thingId, usrId, startDate, field1Max, field2Max, field3Max, field4Max, field5Max, field6Max, field7Max, field8Max, field9Max, " + "field10Max, field11Max, field12Max, field13Max, field14Max, field15Max,field1Min, field2Min, field3Min, field4Min, field5Min, field6Min, field7Min, field8Min, field9Min, " +   "field10Min, field11Min, field12Min, field13Min, field14Min, field15Min, field1AVG, field2AVG, field3AVG, field4AVG, field5AVG, field6AVG, field7AVG, field8AVG, field9AVG" +  ", field10AVG, field11AVG, field12AVG, field13AVG, field14AVG, field15AVG)  SELECT " + name + " AS name, " + thingId.ToString() + " AS thingId, " + usrId.ToString() + " AS usrId, " + thingId.ToString() + "  As thingId, MAX(field1) as field1Max,MAX(field2) as field2Max,MAX(field3) as field3Max,MAX(field4) as field4Max,MAX(field5) as field5Max,MAX(field6) as field6Max,MAX(field7) as field7Max,MAX(field8) as field8Max,MAX(field9) as field9Max,MAX(field10) as field10Max,MAX(field11) as field11Max,MAX(field12) as field12Max, MAX(field13) as field13Max, MAX(field14) as field14Max, MAX(field15) as field15Max, MIN(field1) as field1Min,MIN(field2) as field2MIN,Min(field3) as field3Min,MIN(field4) as field4Min,MIN(field5) as field5Min,MIN(field6) as field6Min,MIN(field7) as field7Min,MIN(field8) as field8Min,MIN(field9) as field9Min,MIN(field10) as field10Min,MIN(field11) as field11Min,MIN(field12) as field12Min, MIN(field13) as field13Min, MIN(field14) as field14Min, MIN(field15) as field15Min, AVG(field1) as field1AVG,AVG(field2) as field2AVG,AVG(field3) as field3AVG,AVG(field4) as field4AVG,AVG(field5) as field5AVG,AVG(field6) as field6AVG,AVG(field7) as field7AVG,AVG(field8) as field8AVG,AVG(field9) as field9AVG,AVG(field10) as field10AVG,AVG(field11) as field11AVG,AVG(field12) as field12AVG, AVG(field13) as field13AVG, AVG(field14) as field14AVG, AVG(field15) as field15AVG FROM measurements WHERE inTopic = " + inTopic;
                DB.Database.ExecuteSqlCommand(strSQL);

                strSQL = "SELECT * FROM report WHERE inTopic = " + inTopic.ToString() + " ORDER BY startDate DESC";
                return DB.Database.SqlQuery<report>(strSQL).ToList();
            }
        }
        public List<onEmail> getonEmail()
        {
            using (onHubEntities DB = new onHubEntities())
            {
                string strSQL = "SELECT * FROM onEmail WHERE usrId = " + usrId.ToString();
                return DB.Database.SqlQuery<onEmail>(strSQL).ToList();
            }
        }



    }

    public class report
    {
        public int id { get; set; }
        public string name { get; set; }
        public int thingId { get; set; }
        public int usrId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate  { get; set; }
        public string field1Max { get; set; }
        public string field2Max { get; set; }
        public string field3Max { get; set; }
        public string field4Max { get; set; }
        public string field5Max { get; set; }
        public string field6Max { get; set; }
        public string field7Max { get; set; }
        public string field8Max { get; set; }
        public string field9Max { get; set; }
        public string field10Max { get; set; }
        public string field11Max { get; set; }
        public string field12Max { get; set; }
        public string field13Max { get; set; }
        public string field14Max { get; set; }
        public string field15Max { get; set; }
        public string field1Min { get; set; }
        public string field2Min { get; set; }
        public string field3Min { get; set; }
        public string field4Min { get; set; }
        public string field5Min { get; set; }
        public string field6Min { get; set; }
        public string field7Min { get; set; }
        public string field8Min { get; set; }
        public string field9Min { get; set; }
        public string field10Min { get; set; }
        public string field11Min { get; set; }
        public string field12Min { get; set; }
        public string field13Min { get; set; }
        public string field14Min { get; set; }
        public string field15Min { get; set; }
        public string field1AVG { get; set; }
        public string field2AVG { get; set; }
        public string field3AVG { get; set; }
        public string field4AVG { get; set; }
        public string field5AVG { get; set; }
        public string field6AVG { get; set; }
        public string field7AVG { get; set; }
        public string field8AVG { get; set; }
        public string field9AVG { get; set; }
        public string field10AVG { get; set; }
        public string field11AVG { get; set; }
        public string field12AVG { get; set; }
        public string field13AVG { get; set; }
        public string field14AVG { get; set; }
        public string field15AVG { get; set; }
    }
    public class personalData
    {
        public int id { get; set; }
        public int usrId { get; set; }
        public string profilePhoto { get; set; }
        public string cellphone { get; set; }
        public DateTime birthday { get; set; }
        public string facebookURL { get; set; }
        public string twitterURL { get; set; }
        public string linkedinURL { get; set; }
    }

    public class onUser
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string userTypId { get; set; }
        public DateTime creationDate { get; set; }
    }
    public class onEmail
    {
        public int id { get; set; }
        public int usrId { get; set; }
        public string usrEmail { get; set; }
        public bool status { get; set; }
    }
    public class userTyp
    {
        public int id { get; set; }
        public string plan { get; set; }
        public string description { get; set; }
        public int price { get; set; }
    }
    public class thing
    {
        public int id { get; set; }
        public int idUsr { get; set; }
        public string inTopic { get; set; }
        public string outTopic { get; set; }
        public int thingTyp { get; set; }
        public bool state { get; set; }
        public DateTime creationDate { get; set; }
    }
    public class state
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime createAt { get; set; }
    }
    public class thingTyp
    {
        public int id { get; set; }
        public string name { get; set; }
        public int maxTimeOnline { get; set; }
        public string field1 { get; set; }
        public string field2 { get; set; }
        public string field3 { get; set; }
        public string field4 { get; set; }
        public string field5 { get; set; }
        public string field6 { get; set; }
        public string field7 { get; set; }
        public string field8 { get; set; }
        public string field9 { get; set; }
        public string field10 { get; set; }
        public string field11 { get; set; }
        public string field12 { get; set; }
        public string field13 { get; set; }
        public string field14 { get; set; }
        public string field15 { get; set; }

        public string field1Max { get; set; }
        public string field2Max { get; set; }
        public string field3Max { get; set; }
        public string field4Max { get; set; }
        public string field5Max { get; set; }
        public string field6Max { get; set; }
        public string field7Max { get; set; }
        public string field8Max { get; set; }
        public string field9Max { get; set; }
        public string field10Max { get; set; }
        public string field11Max { get; set; }
        public string field12Max { get; set; }
        public string field13Max { get; set; }
        public string field14Max { get; set; }
        public string field15Max { get; set; }
    }

    public class measurements
    {
        public long id { get; set; }
        public string inTopic { get; set; }
        public DateTime registerDate { get; set; }
        public string field1 { get; set; }
        public string field2 { get; set; }
        public string field3 { get; set; }
        public string field4 { get; set; }
        public string field5 { get; set; }
        public string field6 { get; set; }
        public string field7 { get; set; }
        public string field8 { get; set; }
        public string field9 { get; set; }
        public string field10 { get; set; }
        public string field11 { get; set; }
        public string field12 { get; set; }
        public string field13 { get; set; }
        public string field14 { get; set; }
        public string field15 { get; set; }
        public bool status { get; set; }
    }
}
 