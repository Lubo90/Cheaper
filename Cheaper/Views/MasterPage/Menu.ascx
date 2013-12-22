<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menu.ascx.cs" Inherits="Views_MasterPage_Menu"  %>
<div runat="server" style="border:1px solid #000; width:100px; height:auto; float:left; text-align: center;" ID="menuPanel">
    <span>Menu</span>
    <asp:LinkButton ID="menuStronaGlowna" PostBackUrl="~/Views/StronaGlowna/Default.aspx" Text="Strona główna" runat="server" CssClass="menuItem" />
    <asp:LinkButton ID="menuBudzety" PostBackUrl="" Text="Mój budżet" runat="server" CssClass="menuItem" />
</div>