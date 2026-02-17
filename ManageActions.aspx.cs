using System;
using System.Collections.Generic;
using System.Data;

namespace Mohammed11254WebApp.demo
{
    public partial class ManageActions : System.Web.UI.Page
    {
        CRUD crud = new CRUD();
        int CurrentEmployeeId
        {
            get
            {
                int id = 0;
                int.TryParse(ViewState["EmpId"]?.ToString(), out id);
                return id;
            }
            set { ViewState["EmpId"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null) { Response.Redirect("Login.aspx"); return; }

            if (!IsPostBack)
            {
                HideAllSections();
            }
        }

        void HideAllSections()
        {
            secAttendance.Visible = false;
            secPoints.Visible = false;
            secSkills.Visible = false;
            secEval.Visible = false;

            lblAttMsg.Text = lblPointsMsg.Text = lblSkillsMsg.Text = lblEvalMsg.Text = "";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            HideAllSections();
            lblSearchMsg.Text = "";
            lblEmpInfo.Text = "";
            CurrentEmployeeId = 0;

            int empId;
            if (!int.TryParse(txtSearchId.Text.Trim(), out empId))
            {
                lblSearchMsg.Text = "أدخل رقم موظف صحيح.";
                return;
            }

            var dt = crud.getDTPassSqlDic("SELECT TOP 1 employeeId, fName, lName FROM employee WHERE employeeId=@id",
                new Dictionary<string, object> { { "@id", empId } });

            if (dt.Rows.Count == 0)
            {
                lblSearchMsg.Text = "الموظف غير موجود.";
                return;
            }

            CurrentEmployeeId = empId;
            lblEmpInfo.Text = $"الموظف: {dt.Rows[0]["fName"]} {dt.Rows[0]["lName"]} (ID: {empId})";

            string role = Session["Role"]?.ToString() ?? "";
            secAttendance.Visible = true;
            secPoints.Visible = true;
            secSkills.Visible = true;
            secEval.Visible = true;

            if (role == "Employee")
            {
                int myId = 0; int.TryParse(Session["employeeId"]?.ToString(), out myId);
                bool sameUser = (myId == empId);
                if (!sameUser)
                {
                    lblSearchMsg.Text = "لا تملك صلاحية التعديل على موظف آخر.";
                    HideAllSections();
                }
            }
        }

        protected void btnSaveAttendance_Click(object sender, EventArgs e)
        {
            if (CurrentEmployeeId == 0) { lblAttMsg.Text = "ابحث عن الموظف أولاً."; return; }
            DateTime d;
            if (!DateTime.TryParse(txtAttDate.Text.Trim(), out d))
            {
                lblAttMsg.Text = "أدخل تاريخ صحيح.";
                return;
            }
            int status = ddlAttStatus.SelectedValue == "1" ? 1 : 0;

            var sql = @"INSERT INTO Attendance (employeeId, attendanceDate, status) VALUES (@e, @d, @s)";
            var p = new Dictionary<string, object> {
                {"@e", CurrentEmployeeId},
                {"@d", d},
                {"@s", status}
            };
            int n = crud.InsertUpdateDelete(sql, p);
            lblAttMsg.CssClass = n > 0 ? "text-success" : "text-danger";
            lblAttMsg.Text = n > 0 ? "تم حفظ الحضور." : "لم يتم الحفظ.";
        }

        protected void btnSavePoints_Click(object sender, EventArgs e)
        {
            if (CurrentEmployeeId == 0) { lblPointsMsg.Text = "ابحث عن الموظف أولاً."; return; }
            int pts;
            if (!int.TryParse(txtPoints.Text.Trim(), out pts))
            {
                lblPointsMsg.Text = "أدخل رقم نقاط صحيح.";
                return;
            }

            string reason = txtReason.Text.Trim();
            string addedBy = Session["username"]?.ToString() ?? "system";

            var sql = @"INSERT INTO Points (employeeId, points, addedBy, dateAdded, Reason)
                        VALUES (@e, @p, @a, GETDATE(), @r)";
            var p = new Dictionary<string, object> {
                {"@e", CurrentEmployeeId},
                {"@p", pts},
                {"@a", addedBy},
                {"@r", reason}
            };
            int n = crud.InsertUpdateDelete(sql, p);
            lblPointsMsg.CssClass = n > 0 ? "text-success" : "text-danger";
            lblPointsMsg.Text = n > 0 ? "تم حفظ النقاط." : "لم يتم الحفظ.";
        }

        protected void btnAddSkill_Click(object sender, EventArgs e)
        {
            if (CurrentEmployeeId == 0) { lblSkillsMsg.Text = "ابحث عن الموظف أولاً."; return; }

            string skillName = txtSkillName.Text.Trim();
            if (string.IsNullOrEmpty(skillName))
            {
                lblSkillsMsg.Text = "أدخل اسم المهارة.";
                return;
            }

            var dt = crud.getDTPassSqlDic(
                "SELECT skillId FROM Skills WHERE name=@n",
                new Dictionary<string, object> { { "@n", skillName } });

            int skillId;
            if (dt.Rows.Count == 0)
            {
                string insSkill = "INSERT INTO Skills (name) OUTPUT INSERTED.skillId VALUES (@n)";
                skillId = Convert.ToInt32(crud.ExecuteScalar(insSkill, new Dictionary<string, object> { { "@n", skillName } }));
            }
            else
            {
                skillId = Convert.ToInt32(dt.Rows[0]["skillId"]);
            }

            var chk = crud.getDTPassSqlDic(
                "SELECT 1 FROM EmployeeSkills WHERE employeeId=@e AND skillId=@s",
                new Dictionary<string, object> { { "@e", CurrentEmployeeId }, { "@s", skillId } });

            if (chk.Rows.Count > 0)
            {
                lblSkillsMsg.Text = "المهارة مسجلة مسبقاً لهذا الموظف.";
                return;
            }

            var sql = @"INSERT INTO EmployeeSkills (employeeId, skillId) VALUES (@e, @s)";
            var p = new Dictionary<string, object> { { "@e", CurrentEmployeeId }, { "@s", skillId } };
            int n = crud.InsertUpdateDelete(sql, p);

            lblSkillsMsg.CssClass = n > 0 ? "text-success" : "text-danger";
            lblSkillsMsg.Text = n > 0 ? "تم إضافة المهارة." : "لم يتم الإضافة.";
        }

        protected void btnSaveEval_Click(object sender, EventArgs e)
        {
            if (CurrentEmployeeId == 0) { lblEvalMsg.Text = "ابحث عن الموظف أولاً."; return; }
            int total;
            if (!int.TryParse(txtTotalPoint.Text.Trim(), out total))
            {
                lblEvalMsg.Text = "أدخل رقم صحيح لإجمالي النقاط.";
                return;
            }
            DateTime ed;
            if (!DateTime.TryParse(txtEvalDate.Text.Trim(), out ed))
            {
                lblEvalMsg.Text = "أدخل تاريخ تقييم صحيح.";
                return;
            }
            string period = txtPeriod.Text.Trim();

            var sql = @"INSERT INTO Evaluation (employeeId, period, totalPoint, evaluationDate)
                        VALUES (@e, @per, @tot, @ed)";
            var p = new Dictionary<string, object> {
                {"@e", CurrentEmployeeId},
                {"@per", period},
                {"@tot", total},
                {"@ed", ed}
            };
            int n = crud.InsertUpdateDelete(sql, p);
            lblEvalMsg.CssClass = n > 0 ? "text-success" : "text-danger";
            lblEvalMsg.Text = n > 0 ? "تم حفظ التقييم." : "لم يتم الحفظ.";
        }
    }
}
