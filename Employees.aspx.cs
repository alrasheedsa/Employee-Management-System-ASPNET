using System;
using System.Collections.Generic;
using System.Data;

namespace Mohammed11254WebApp.demo
{
    public partial class Employees : System.Web.UI.Page
    {
        CRUD crud = new CRUD();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null) Response.Redirect("Login.aspx");
            if (!IsPostBack) BindGrid();
        }

        private void BindGrid()
        {
            DataTable dt = crud.getDT("SELECT * FROM employee");
            grdEmployees.DataSource = dt;
            grdEmployees.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int id = 0;
            int.TryParse(lblId.Text, out id);
            string fName = txtFName.Text.Trim();
            string lName = txtLName.Text.Trim();
            string job = txtJob.Text.Trim();
            DateTime hire = DateTime.TryParse(txtHireDate.Text.Trim(), out hire) ? DateTime.Parse(txtHireDate.Text.Trim()) : DateTime.MinValue;
            string email = txtEmail.Text.Trim();
            bool active = chkActive.Checked;

            if (id == 0)
            {
                string ins = "INSERT INTO employee (fName, lName, jopTitle, hireDate, email, isActive) VALUES (@f,@l,@j,@h,@e,@a)";
                var p = new Dictionary<string, object>
                {
                    { "@f", fName }, { "@l", lName }, { "@j", job },
                    { "@h", hire == DateTime.MinValue ? (object)DBNull.Value : hire },
                    { "@e", email }, { "@a", active }
                };
                crud.ExecuteNonQuery(ins, p);
            }
            else
            {
                string upd = "UPDATE employee SET fName=@f, lName=@l, jopTitle=@j, hireDate=@h, email=@e, isActive=@a WHERE employeeId=@id";
                var p = new Dictionary<string, object>
                {
                    { "@f", fName }, { "@l", lName }, { "@j", job },
                    { "@h", hire == DateTime.MinValue ? (object)DBNull.Value : hire },
                    { "@e", email }, { "@a", active },
                    { "@id", id }
                };
                crud.ExecuteNonQuery(upd, p);
            }

            ClearForm();
            BindGrid();
        }

        protected void btnClear_Click(object sender, EventArgs e) { ClearForm(); }

        private void ClearForm()
        {
            lblId.Text = "0";
            txtFName.Text = txtLName.Text = txtJob.Text = txtHireDate.Text = txtEmail.Text = "";
            chkActive.Checked = false;
        }

        protected void grdEmployees_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "EditRow")
            {
                DataTable dt = crud.getDTPassSqlDic("SELECT * FROM employee WHERE employeeId = @id", new Dictionary<string, object> { { "@id", id } });
                if (dt.Rows.Count > 0)
                {
                    var r = dt.Rows[0];
                    lblId.Text = r["employeeId"].ToString();
                    txtFName.Text = r["fName"].ToString();
                    txtLName.Text = r["lName"].ToString();
                    txtJob.Text = r["jopTitle"].ToString();
                    txtHireDate.Text = r["hireDate"] == DBNull.Value ? "" : Convert.ToDateTime(r["hireDate"]).ToString("yyyy-MM-dd");
                    txtEmail.Text = r["email"].ToString();
                    chkActive.Checked = (r["isActive"] != DBNull.Value) && Convert.ToBoolean(r["isActive"]);
                }
            }
            else if (e.CommandName == "DeleteRow")
            {
                var p = new Dictionary<string, object> { { "@id", id } };

                
                crud.ExecuteNonQuery("DELETE FROM Attendance WHERE employeeId=@id", p);
                crud.ExecuteNonQuery("DELETE FROM Points WHERE employeeId=@id", p);
                crud.ExecuteNonQuery("DELETE FROM Evaluation WHERE employeeId=@id", p);
                crud.ExecuteNonQuery("DELETE FROM EmployeeSkills WHERE employeeId=@id", p);
                crud.ExecuteNonQuery("DELETE FROM Questionnaire WHERE employeeId=@id", p);
                crud.ExecuteNonQuery("DELETE FROM UsersAdmins WHERE employeeId=@id", p);

               
                crud.ExecuteNonQuery("DELETE FROM employee WHERE employeeId=@id", p);

                
            }
        }
    }
}
