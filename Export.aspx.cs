using System;
using System.Data;
using System.IO;
using ClosedXML.Excel;

namespace Mohammed11254WebApp.demo
{
    public partial class Export : System.Web.UI.Page
    {
        CRUD crud = new CRUD();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null) { Response.Redirect("Login.aspx"); return; }
            if (!IsPostBack) ddlExport.SelectedIndex = 0;
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            lblExport.Text = "";
            DataTable dt = null;
            string sel = ddlExport.SelectedValue;

            if (sel == "Employees")
                dt = crud.getDT("SELECT employeeId, fName, lName, jopTitle, hireDate, email, isActive FROM employee ORDER BY employeeId");
            else if (sel == "Points")
                dt = crud.getDT("SELECT * FROM vw_EmployeePoints ORDER BY dateAdded DESC");
            else if (sel == "Attendance")
                dt = crud.getDT("SELECT employeeId, attendanceDate, status FROM Attendance ORDER BY attendanceDate DESC");
            else if (sel == "FullReport")
                dt = crud.getDT("SELECT * FROM vw_FullEmployeeReport");
            else
            {
                lblExport.Text = "اختر تقريراً.";
                return;
            }

            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add(sel);
                ws.Cell(1, 1).InsertTable(dt, true);

                using (var ms = new MemoryStream())
                {
                    wb.SaveAs(ms);
                    ms.Position = 0;

                    Response.Clear();
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", $"attachment; filename={sel}_{DateTime.Now:yyyyMMddHHmm}.xlsx");
                    Response.BinaryWrite(ms.ToArray());
                    Response.End();
                }
            }
        }
    }
}
