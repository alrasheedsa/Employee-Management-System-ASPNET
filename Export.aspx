<%@ Page Title="Export" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Export.aspx.cs" Inherits="Mohammed11254WebApp.demo.Export" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>تصدير التقارير إلى Excel</h2>
    <div class="card p-3" style="max-width:520px">
        <div class="mb-2">
            <label>اختر نوع التصدير</label>
            <asp:DropDownList ID="ddlExport" runat="server" CssClass="form-select">
                <asp:ListItem Text="Employees" Value="Employees" />
                <asp:ListItem Text="Points" Value="Points" />
                <asp:ListItem Text="Attendance" Value="Attendance" />
                <asp:ListItem Text="FullReport" Value="FullReport" />
            </asp:DropDownList>
        </div>
        <asp:Button ID="btnExport" runat="server" Text="تصدير" CssClass="btn btn-primary" OnClick="btnExport_Click" />
        <asp:Label ID="lblExport" runat="server" CssClass="d-block mt-2"></asp:Label>
    </div>
</asp:Content>
