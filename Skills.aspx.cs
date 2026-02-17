using System;
using System.Collections.Generic;
using System.Data;

namespace Mohammed11254WebApp.demo
{
    public partial class Skills : System.Web.UI.Page
    {
        CRUD crud = new CRUD();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
                Response.Redirect("Login.aspx");

            if (Session["Role"] == null || Session["Role"].ToString() != "Admin")
            {
                Response.Redirect("Home.aspx");
                return;
            }

            if (!IsPostBack)
                BindGrid();
        }

        private void BindGrid()
        {
            DataTable dt = crud.getDT("SELECT * FROM Skills");
            grdSkills.DataSource = dt;
            grdSkills.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int id = 0;
            int.TryParse(lblId.Text, out id);
            string skillName = txtSkillName.Text.Trim();

            if (id == 0)
            {
                string ins = "INSERT INTO Skills (skillName) VALUES (@name)";
                var p = new Dictionary<string, object>
                {
                    { "@name", skillName }
                };
                crud.ExecuteNonQuery(ins, p);
            }
            else
            {
                string upd = "UPDATE Skills SET skillName=@name WHERE skillId=@id";
                var p = new Dictionary<string, object>
                {
                    { "@name", skillName },
                    { "@id", id }
                };
                crud.ExecuteNonQuery(upd, p);
            }

            ClearForm();
            BindGrid();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            lblId.Text = "0";
            txtSkillName.Text = "";
        }

        protected void grdSkills_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "EditRow")
            {
                DataTable dt = crud.getDTPassSqlDic("SELECT * FROM Skills WHERE skillId = @id", new Dictionary<string, object> { { "@id", id } });
                if (dt.Rows.Count > 0)
                {
                    var r = dt.Rows[0];
                    lblId.Text = r["skillId"].ToString();
                    txtSkillName.Text = r["skillName"].ToString();
                }
            }
            else if (e.CommandName == "DeleteRow")
            {
                crud.ExecuteNonQuery("DELETE FROM Skills WHERE skillId = @id", new Dictionary<string, object> { { "@id", id } });
                BindGrid();
            }
        }
    }
}
