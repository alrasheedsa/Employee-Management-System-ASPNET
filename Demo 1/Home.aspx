<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Mohammed11254WebApp.demo.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>لوحة التحكم</h2>
    <div class="alert alert-info">
        مرحباً <strong><asp:Label ID="lblUser" runat="server"></asp:Label></strong> (الدور: <asp:Label ID="lblRole" runat="server"></asp:Label>)
    </div>

    <div class="row g-3">
        <div class="col-md-4">
            <div class="card p-3">
                <h5>إدارة الموظفين</h5>
                <p>إدارة بيانات الموظفين.</p>
                <asp:HyperLink ID="lnkEmployees" runat="server" NavigateUrl="Employees.aspx" CssClass="btn btn-outline-primary">الانتقال</asp:HyperLink>
            </div>
        </div>

        <div class="col-md-4">
            <div class="card p-3">
                <h5>تسجيل حضور / نقاط / مهارات / تقييم</h5>
                <p>بحث بالرقم الوظيفي ثم تنفيذ الإجراء.</p>
                <asp:HyperLink ID="lnkManage" runat="server" NavigateUrl="ManageActions.aspx" CssClass="btn btn-outline-primary">الانتقال</asp:HyperLink>
            </div>
        </div>

        <div class="col-md-4">
            <div class="card p-3">
                <h5>تصدير التقارير</h5>
                <p>تصدير Excel: الموظفين، النقاط، الحضور، التقرير الكامل.</p>
                <asp:HyperLink ID="lnkExport" runat="server" NavigateUrl="Export.aspx" CssClass="btn btn-outline-primary">الانتقال</asp:HyperLink>
            </div>
        </div>

        
    </div>
</asp:Content>
