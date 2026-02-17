<%@ Page Title="Manage Actions" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageActions.aspx.cs" Inherits="Mohammed11254WebApp.demo.ManageActions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>إجراءات على الموظف</h2>

    <!-- البحث -->
    <div class="card p-3 mb-3">
        <div class="row g-2">
            <div class="col-md-3">
                <label>EmployeeId</label>
                <asp:TextBox ID="txtSearchId" runat="server" CssClass="form-control" />
            </div>
            <div class="col-md-3 align-self-end">
                <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" Text="بحث" OnClick="btnSearch_Click" />
            </div>
            <div class="col-md-6">
                <asp:Label ID="lblEmpInfo" runat="server" CssClass="d-block mt-4 fw-bold"></asp:Label>
            </div>
        </div>
        <asp:Label ID="lblSearchMsg" runat="server" CssClass="text-danger mt-2 d-block"></asp:Label>
    </div>

    <!-- تسجيل الحضور -->
    <div class="card p-3 mb-3" runat="server" id="secAttendance" visible="false">
        <h5>تسجيل حضور</h5>
        <div class="row g-2">
            <div class="col-md-3">
                <label>التاريخ</label>
                <asp:TextBox ID="txtAttDate" runat="server" CssClass="form-control" TextMode="Date" />
            </div>
            <div class="col-md-3">
                <label>الحالة</label>
                <asp:DropDownList ID="ddlAttStatus" runat="server" CssClass="form-select">
                    <asp:ListItem Text="حاضر" Value="1" />
                    <asp:ListItem Text="غائب" Value="0" />
                </asp:DropDownList>
            </div>
            <div class="col-md-3 align-self-end">
                <asp:Button ID="btnSaveAttendance" runat="server" CssClass="btn btn-success" Text="حفظ الحضور" OnClick="btnSaveAttendance_Click" />
            </div>
        </div>
        <asp:Label ID="lblAttMsg" runat="server" CssClass="d-block mt-2"></asp:Label>
    </div>

    <!-- النقاط -->
    <div class="card p-3 mb-3" runat="server" id="secPoints" visible="false">
        <h5>إضافة نقاط</h5>
        <div class="row g-2">
            <div class="col-md-3">
                <label>عدد النقاط</label>
                <asp:TextBox ID="txtPoints" runat="server" CssClass="form-control" />
            </div>
            <div class="col-md-6">
                <label>السبب</label>
                <asp:TextBox ID="txtReason" runat="server" CssClass="form-control" />
            </div>
            <div class="col-md-3 align-self-end">
                <asp:Button ID="btnSavePoints" runat="server" CssClass="btn btn-success" Text="حفظ النقاط" OnClick="btnSavePoints_Click" />
            </div>
        </div>
        <asp:Label ID="lblPointsMsg" runat="server" CssClass="d-block mt-2"></asp:Label>
    </div>

    <!-- المهارات -->
    <div class="card p-3 mb-3" runat="server" id="secSkills" visible="false">
        <h5>إضافة مهارة</h5>
        <div class="row g-2">
            <div class="col-md-6">
                <label>اسم المهارة</label>
                <asp:TextBox ID="txtSkillName" runat="server" CssClass="form-control" placeholder="أدخل اسم المهارة" />
            </div>
            <div class="col-md-3 align-self-end">
                <asp:Button ID="btnAddSkill" runat="server" CssClass="btn btn-success" Text="إضافة المهارة" OnClick="btnAddSkill_Click" />
            </div>
        </div>
        <asp:Label ID="lblSkillsMsg" runat="server" CssClass="d-block mt-2"></asp:Label>
    </div>

    
    <div class="card p-3 mb-3" runat="server" id="secEval" visible="false">
        <h5>إضافة تقييم</h5>
        <div class="row g-2">
            <div class="col-md-3">
                <label>الفترة</label>
                <asp:TextBox ID="txtPeriod" runat="server" CssClass="form-control" />
            </div>
            <div class="col-md-3">
                <label>إجمالي النقاط</label>
                <asp:TextBox ID="txtTotalPoint" runat="server" CssClass="form-control" />
            </div>
            <div class="col-md-3">
                <label>تاريخ التقييم</label>
                <asp:TextBox ID="txtEvalDate" runat="server" CssClass="form-control" TextMode="Date" />
            </div>
            <div class="col-md-3 align-self-end">
                <asp:Button ID="btnSaveEval" runat="server" CssClass="btn btn-success" Text="حفظ التقييم" OnClick="btnSaveEval_Click" />
            </div>
        </div>
        <asp:Label ID="lblEvalMsg" runat="server" CssClass="d-block mt-2"></asp:Label>
    </div>

</asp:Content>
