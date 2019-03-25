using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data;
using System.Data.SqlClient;
using onHub.App_Code;
using System.Drawing;

namespace airQ
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            onmotica.isLogged(Session, Response,"login");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("/register");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var usr = txtUser.Text;
            var password = txtPassword.Text;
            onmotica.login(Session, Response, usr, password);
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}