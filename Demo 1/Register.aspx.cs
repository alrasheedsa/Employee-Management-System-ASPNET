using System;
using System.Collections.Generic;

namespace Mohammed11254WebApp.demo
{
    public partial class Register : System.Web.UI.Page
    {
        CRUD crud = new CRUD();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["username"] == null) { Response.Redirect("Login.aspx"); return; }
            if (Session["Role"] == null || Session["Role"].ToString() != "Admin") { Response.Redirect("Home.aspx"); return; }
            if (!IsPostBack) lblMsg.Text = "";
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            int empId = 0;
            int.TryParse(txtEmpId.Text.Trim(), out empId);

            var sql = @"INSERT INTO UsersAdmins (username, PasswordHash, role, employeeId)
                        VALUES (@u, @p, @r, @e)";
            var para = new Dictionary<string, object>
            {
                {"@u", txtUser.Text.Trim()},
                {"@p", txtPass.Text.Trim()},
                {"@r", ddlRole.SelectedValue},
                {"@e", empId == 0 ? (object)DBNull.Value : empId}
            };
            int n = crud.InsertUpdateDelete(sql, para);
            lblMsg.CssClass = "text-success";
            lblMsg.Text = (n > 0) ? "تم إنشاء المستخدم بنجاح." : "لم يتم إنشاء المستخدم.";
        }
    }
}
