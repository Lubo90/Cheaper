<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NowyBudzet.ascx.cs" Inherits="Views_Budzet_NowyBudzet" %>

<span>Nowy budżet</span>
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
        <td colspan="2"><asp:Button ID="btnSaveBudzet" Text="Dodaj budżet" runat="server" OnClick="btnSaveBudzet_Click" /></td>
    </tr>
</table>
