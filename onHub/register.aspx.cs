using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using airQ.App_Code;
using System.Data.SqlClient;
using System.Drawing;

namespace airQ
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("/login");
        }

        protected void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            bool bandera = true;
            var usuario = txtUserName.Text;
            var password = txtPassword.Text;
            if (usuario!= null & password != null)
            {
                if (usuario!= "" & password != "")
                {
                    string pSQL = "SELECT * FROM onUser WHERE userName = '" + txtUserName.Text + "'";
                    SqlDataReader dr = onmotica.fetchReader(pSQL);
                    while (dr.Read())
                    {
                        if (dr.HasRows || (dr.IsDBNull(0)))
                        {
                            if (dr["userName"] != null)
                            {
                                if (dr["userName"].ToString() != "")
                                {
                                    lblError.Text = "Usuario ya registrado, prueba con otro nombre de usuario";
                                    lblError.ForeColor = Color.Red;
                                    bandera = false;
                                }
                            }
                        }
                        else
                        {
                            lblError.Visible = false;
                        }
                    }
                    if(bandera)
                    {
                        pSQL = "INSERT INTO [onUser]  ([userName], [password], [userTypid], [creationDate]) VALUES ('@UserName','@Pass','@userTypid','@RegisterDate')";
                        pSQL = pSQL.Replace("@UserName", usuario);
                        pSQL = pSQL.Replace("@Pass", password);
                        pSQL = pSQL.Replace("@RegisterDate", onmotica.convertD2IDateTime(DateTime.Now));
                        pSQL = pSQL.Replace("@userTypid", "1");
                        onmotica.executeSQL(pSQL);
                        onmotica.login(Session, Response, usuario, password);
                    }
                }

            }

        }
    }    
}