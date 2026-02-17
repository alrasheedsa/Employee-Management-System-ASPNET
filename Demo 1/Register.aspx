<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Mohammed11254WebApp.demo.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>إنشاء مستخدم جديد (Admin فقط)</h2>
    <div class="card p-3" style="max-width:600px">
        <div class="row g-2">
            <div class="col-md-6">
                <label>اسم المستخدم</label>
                <asp:TextBox ID="txtUser" runat="server" CssClass="form-control" />
            </div>
            <div class="col-md-6">
                <label>كلمة المرور (ستحفظ في PasswordHash)</label>
                <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" TextMode="Password" />
            </div>
            <div class="col-md-6">
                <label>الدور</label>
                <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-select">
                    <asp:ListItem Text="Admin" Value="Admin" />
                    <asp:ListItem Text="Employee" Value="Employee" />
                </asp:DropDownList>
            </div>
            <div class="col-md-6">
                <label>EmployeeId (اختياري للموظف)</label>
                <asp:TextBox ID="txtEmpId" runat="server" CssClass="form-control" />
            </div>
        </div>
        <div class="mt-3">
            <asp:Button ID="btnCreate" runat="server" Text="إنشاء" CssClass="btn btn-success" OnClick="btnCreate_Click" />
            <asp:Label ID="lblMsg" runat="server" CssClass="d-block mt-2"></asp:Label>
        </div>
    </div>
</asp:Content>
