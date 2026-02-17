<%@ Page Title="الموظفون" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="Mohammed11254WebApp.demo.Employees" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>إدارة الموظفين</h3>

    <asp:Panel ID="pnlForm" runat="server">
        <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>

        <asp:Label ID="lblFName" runat="server" Text="الاسم الأول"></asp:Label><br />
        <asp:TextBox ID="txtFName" runat="server"></asp:TextBox><br />

        <asp:Label ID="lblLName" runat="server" Text="الاسم الأخير"></asp:Label><br />
        <asp:TextBox ID="txtLName" runat="server"></asp:TextBox><br />

        <asp:Label ID="lblJob" runat="server" Text="المسمى الوظيفي"></asp:Label><br />
        <asp:TextBox ID="txtJob" runat="server"></asp:TextBox><br />

        <asp:Label ID="lblHireDate" runat="server" Text="تاريخ التوظيف"></asp:Label><br />
        <asp:TextBox ID="txtHireDate" runat="server"></asp:TextBox><br />

        <asp:Label ID="lblEmail" runat="server" Text="البريد الإلكتروني"></asp:Label><br />
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />

        <asp:CheckBox ID="chkActive" runat="server" Text="مفعل" /><br />

        <asp:Button ID="btnSave" runat="server" Text="حفظ" OnClick="btnSave_Click" />
        <asp:Button ID="btnClear" runat="server" Text="مسح" OnClick="btnClear_Click" />
    </asp:Panel>

    <hr />

    <asp:GridView ID="grdEmployees" runat="server" AutoGenerateColumns="false" OnRowCommand="grdEmployees_RowCommand">
        <Columns>
            <asp:BoundField DataField="employeeId" HeaderText="ID" />
            <asp:BoundField DataField="fName" HeaderText="First Name" />
            <asp:BoundField DataField="lName" HeaderText="Last Name" />
            <asp:BoundField DataField="jopTitle" HeaderText="Job Title" />
            <asp:BoundField DataField="hireDate" HeaderText="Hire Date" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:BoundField DataField="email" HeaderText="Email" />
            <asp:CheckBoxField DataField="isActive" HeaderText="Active" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditRow" CommandArgument='<%# Eval("employeeId") %>' Text="تعديل"></asp:LinkButton>
                    &nbsp;
                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteRow" CommandArgument='<%# Eval("employeeId") %>' Text="حذف" OnClientClick="return confirm('هل تريد الحذف؟');"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
