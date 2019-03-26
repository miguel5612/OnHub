using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using onHub.App_Code;
using System.Data.SqlClient;
using Newtonsoft.Json;
using onHub.App_Code;

namespace airQ
{
	public partial class dashboard : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (Request.QueryString["device"] != null)
            {
                if (int.Parse(Request.QueryString["device"].ToString()) > 0)
                {
                    Session["deviceID"] = Request.QueryString["device"].ToString();
                }
            }
            if (!Page.IsPostBack)
            {
                Session["unSubscribeTopics"] = "";

                #region getThingFirstTime
                String pSQL = "SELECT * FROM thing WHERE state>=1 AND idUsr =" + Session["UsrID"].ToString();
                using (SqlDataReader dr = onmotica.fetchReader(pSQL)) { 
                    bool firstFlag = true;
                    while (dr.Read())
                    {
                        if (dr.HasRows)
                        {
                            if (firstFlag & Request.QueryString["device"] == null)
                            {
                                Session["deviceID"] = dr["id"].ToString();
                                Session["deviceName"] = dr["deviceName"].ToString();
                                Session["inTopic"] = dr["inTopic"].ToString();
                                Session["outTopic"] = dr["outTopic"].ToString();
                                firstFlag = false;
                            }
                            else if (firstFlag & dr["deviceID"].ToString() == Request.QueryString["device"])
                            {
                                Session["deviceID"] = dr["id"].ToString();
                                Session["deviceName"] = dr["deviceName"].ToString();
                                Session["inTopic"] = dr["inTopic"].ToString();
                                Session["outTopic"] = dr["outTopic"].ToString();
                                firstFlag = false;
                            }
                            else
                            {
                                Session["unSubscribeTopics"] = Session["unSubscribeTopics"].ToString() + dr["inTopic"].ToString();
                            }
                            //AddMenuItem(dr["deviceName"].ToString(), dr["deviceID"].ToString());
                        }
                    }
                }
                #endregion
            }            
        }

        private void AddMenuItem(string text, string btnID)
		{
            Session["deviceName" + btnID] = text;

            HtmlGenericControl li = new HtmlGenericControl("li");
			//menu.Controls.Add(li);

            HyperLink openDeviceLink = new HyperLink();
			openDeviceLink.CssClass = btnID;
            openDeviceLink.NavigateUrl = "~/dashboard?device=" + btnID;
            openDeviceLink.Text = text;
			openDeviceLink.Width = 200;
            if (btnID == Session["deviceID"].ToString())
            {
                openDeviceLink.Style.Add("background-color", "darkred");
                openDeviceLink.Style.Add("color", "white");                
            }
			
			li.Controls.Add(openDeviceLink);         
		}
}
}