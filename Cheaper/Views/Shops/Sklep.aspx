<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/SzabGlowny.master" AutoEventWireup="true" CodeFile="Sklep.aspx.cs" Inherits="Views_Shops_Sklep" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">
        <div class="pageHeader">Sklepy</div>
        <div style="text-align: center; float: none;">
            <asp:LinkButton ID="btnNowyBudzet" OnClientClick='$("#pupNowySklep").dialog("open"); return false;' runat="server">Dodaj nowy sklep</asp:LinkButton>
        </div>
        <div style="display: block; margin-top: 30px; font-size: 16px; color: darkred; font-weight: bold;">
            <asp:Label ID="Label1" runat="server" Text="Brak dodanych sklepów" Visible="<%# !this.RepeaterVisible %>" />
        </div>
        <asp:Repeater runat="server" ID="rptrShops" Visible="<%# this.RepeaterVisible %>">
            <HeaderTemplate>
                <table class="table">
                    <tbody id="tabShops">
                        <tr class="tableHeader">
                            <td class="tekstHeader">Nazwa sklepu</td>
                            <td class="tekstHeader">Ulica</td>
                            <td class="tekstHeader">Miasto</td>
                            <td class="tekstHeader">Kod pocztowy</td>
                        </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="tableItem">
                    <td class="tekst"><%# Eval("FriendlyName") %></td>
                    <td class="tekst"><%# Eval("Street") %></td>
                    <td class="tekst"><%# Eval("City") %></td>
                    <td class="tekst"><%# Eval("PostCode") %></td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="altTableItem">
                    <td class="tekst"><%# Eval("FriendlyName") %></td>
                    <td class="tekst"><%# Eval("Street") %></td>
                    <td class="tekst"><%# Eval("City") %></td>
                    <td class="tekst"><%# Eval("PostCode") %></td>
                </tr>
            </AlternatingItemTemplate>
            <FooterTemplate>
                </tbody>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <div id="pupNowySklep" title="Nowy sklep">
        <table>
            <tr>
                <td>Nazwa sklepu</td>
                <td>
                    <asp:TextBox ClientIDMode="Static" ID="tbShopFriendlyName" runat="server" /></td>
            </tr>
            <tr>
                <td>Ulica</td>
                <td>
                    <asp:TextBox ClientIDMode="Static" ID="tbShopUlica" runat="server" /></td>
            </tr>
            <tr>
                <td>Miasto</td>
                <td>
                    <asp:TextBox ClientIDMode="Static" ID="tbShopMiasto" runat="server" /></td>
            </tr>
            <tr>
                <td>Kod pocztowy</td>
                <td>
                    <asp:TextBox ClientIDMode="Static" ID="tbShopKodPocztowy" runat="server" /><img id="postCodeNotValid" src="../../Images/not-ok-mark-small.png" title="Niepoprawny kod pocztowy" />
                    <input type="checkbox" hidden="hidden" id="addRow" checked="checked" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

