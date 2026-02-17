using System;
using System.Collections.Generic;
using System.Data;

namespace Mohammed11254WebApp.demo
{
    public partial class Login : System.Web.UI.Page
    {
        CRUD crud = new CRUD();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) lblMessage.Text = "";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            var sql = @"SELECT TOP 1 userID, username, PasswordHash, role, employeeId
                        FROM UsersAdmins
                        WHERE username=@u AND PasswordHash=@p";
            var para = new Dictionary<string, object>
            {
                {"@u", txtUsername.Text.Trim()},
                {"@p", txtPassword.Text.Trim()}
            };
            DataTable dt = crud.getDTPassSqlDic(sql, para);
            if (dt.Rows.Count == 1)
            {
                var r = dt.Rows[0];
                Session["username"] = r["username"].ToString();
                Session["Role"] = r["role"].ToString();     
                Session["employeeId"] = r["employeeId"] == DBNull.Value ? null : r["employeeId"].ToString();
                Response.Redirect("Home.aspx");
            }
            else
            {
                lblMessage.Text = "بيانات الدخول غير صحيحة.";
            }
        }
    }
}
