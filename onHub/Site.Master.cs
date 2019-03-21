using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace airQ
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usrID"] == null)
            {
                Button1.Text = "Registrarse"; 
            }
            else
            {
                Button1.Text = "Cerrar sesion";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(Session["usrID"]  == null)
            {
                Response.Redirect("/login");
            }
            else
            {
                Response.Redirect("/logout");
            }
        }
    }
}