using System;

namespace Mohammed11254WebApp.demo
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null) { Response.Redirect("Login.aspx"); return; }

            if (!IsPostBack)
            {
                lblUser.Text = Session["username"].ToString();
                lblRole.Text = Session["Role"] == null ? "" : Session["Role"].ToString();
             
            }
        }
    }
}
