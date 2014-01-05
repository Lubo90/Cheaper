<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/SzabGlowny.master" AutoEventWireup="true" CodeFile="Budzet.aspx.cs" Inherits="Views_Budzet_Budzet" %>

<%@ Register Src="~/Views/Budzet/ListaBudzetow.ascx" TagPrefix="uc1" TagName="ListaBudzetow" %>
<%@ Register Src="~/Views/Budzet/NowyBudzet.ascx" TagPrefix="uc1" TagName="NowyBudzet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="overflow: hidden; margin: 0 auto 0 auto;">
        <div style="font-size: 20px; font-weight: bold; font-family: Arial; float: none; text-align: center">Budżety</div>
        <div style="text-align: center; float: none;">
            <asp:LinkButton ID="btnNowyBudzet" runat="server" OnClick="btnNowyBudzet_Click">Dodaj nowy budżet</asp:LinkButton>
        </div>
        <div id="content">
            <asp:MultiView ID="mvBudzet" runat="server" ActiveViewIndex="0">
                <asp:View runat="server">
                    <uc1:ListaBudzetow runat="server" ID="ListaBudzetow" />
                </asp:View>
                <asp:View runat="server">
                    <div>
                    <table border="1">
                        <tr>
                            <td>Nazwa budżetu</td>
                            <td>
                                <asp:TextBox runat="server" ID="tbBudgetName"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Data utworzenia</td>
                            <td>
                                <asp:Label ID="lblBudgetCreationDate" runat="server" /></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btnSaveBudzet" Text="Dodaj budżet" runat="server" OnClick="btnSaveBudzet_Click" /></td>
                        </tr>
                    </table>
                        </div>
                </asp:View>
            </asp:MultiView>
        </div>
    </div>
</asp:Content>

