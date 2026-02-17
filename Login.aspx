<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Mohammed11254WebApp.demo.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>تسجيل الدخول</h2>
    <div class="card p-3" style="max-width:480px">
        <div class="mb-2">
            <label>اسم المستخدم</label>
            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" />
        </div>
        <div class="mb-2">
            <label>كلمة المرور</label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" />
        </div>
        <asp:Button ID="btnLogin" runat="server" Text="دخول" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
        <asp:Label ID="lblMessage" runat="server" CssClass="text-danger d-block mt-2"></asp:Label>
    </div>
</asp:Content>
