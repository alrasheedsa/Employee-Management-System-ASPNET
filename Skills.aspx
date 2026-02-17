<%@ Page Title="المهارات" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Skills.aspx.cs" Inherits="Mohammed11254WebApp.demo.Skills" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>إدارة المهارات</h3>
    <asp:Panel ID="pnlForm" runat="server">
        <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>

        <asp:Label ID="lblSkillName" runat="server" Text="اسم المهارة"></asp:Label><br />
        <asp:TextBox ID="txtSkillName" runat="server"></asp:TextBox><br />

        <asp:Button ID="btnSave" runat="server" Text="حفظ" OnClick="btnSave_Click" />
        <asp:Button ID="btnClear" runat="server" Text="مسح" OnClick="btnClear_Click" />
    </asp:Panel>

    <hr />

    <asp:GridView ID="grdSkills" runat="server" AutoGenerateColumns="false" OnRowCommand="grdSkills_RowCommand">
        <Columns>
            <asp:BoundField DataField="skillId" HeaderText="ID" />
            <asp:BoundField DataField="skillName" HeaderText="اسم المهارة" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditRow" CommandArgument='<%# Eval("skillId") %>' Text="تعديل"></asp:LinkButton>
                    &nbsp;
                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteRow" CommandArgument='<%# Eval("skillId") %>' Text="حذف" OnClientClick="return confirm('هل تريد الحذف؟');"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
