using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Linq;
using System.Text;

namespace airQ.App_Code
{
    public class BLLOnmotica
    {
        private Int32 usrId;
        public BLLOnmotica(int pUsrId)
        {
            usrId = pUsrId;
        }

        /*
        public List<onUser> getUserData()
        {
            using ( DB = new BeDipsSBWEntities())
            {
                string strSQL = "SET ARITHABORT ON; SELECT portNewsChannelKopf.PNCKid, portNewsChannelKopf.HauptTitel, portNewsChannelKopf.BildPfadKlein, portNewsChannelKopf.BildPfadGross, portNewsChannelKopf.DownloadDok, STUFF((SELECT '<br />' + Text FROM portNewsChannelDetail WHERE PNCKid = portNewsChannelKopf.PNCKid AND ErscheinungsStatus = 0 ORDER BY portNewsChannelDetail.Reihenfolge FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 6, '') AS DetailText, (SELECT CAST(COUNT(*) AS Bit) FROM portNewsChannelDetail WHERE (PNCKid=portNewsChannelKopf.PNCKid)) AS Weiterlesen FROM portNewsChannelKopf WHERE DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) BETWEEN erscheintVon AND erscheintBis ORDER BY erscheintVon DESC";
                return DB.Database.SqlQuery<PortalNews>(strSQL).ToList();
            }
        }
        */


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
 