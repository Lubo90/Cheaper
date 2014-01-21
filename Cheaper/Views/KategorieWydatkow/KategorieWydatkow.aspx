<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/SzabGlowny.master" AutoEventWireup="true" CodeFile="KategorieWydatkow.aspx.cs" Inherits="Views_KategorieWydatkow_KategorieWydatkow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">
        <div class="pageHeader">Kategorie wydatków</div>
        <div style="text-align: center; float: none;">
            <asp:LinkButton ID="btnNowyBudzet" OnClientClick='$("#pupNowaKatWyd").dialog("open"); return false;' runat="server">Dodaj nową kategorię</asp:LinkButton>
        </div>
        <div style="display: block; margin-top: 30px; font-size: 16px; color: darkred; font-weight: bold;">
            <asp:Label ID="Label1" runat="server" Text="Brak dodanych kategorii wydatków" Visible="<%# !this.RepeaterVisible %>" />
        </div>
        <asp:Repeater runat="server" ID="rptrKatWyd" Visible="<%# this.RepeaterVisible %>">
            <HeaderTemplate>
                <table class="table">
                    <tbody id="tabWydatki">
                        <tr class="tableHeader">
                            <td class="tekstHeader">Nazwa</td>
                            <td class="tekstHeader">Miesięczna kwota</td>
                            <td class="tekstHeader">Pozostało do wydania</td>
                            <td class="tekstHeader">Edycja</td>
                        </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="tableItem">
                    <td class="tekst"><%# Eval("Name") %></td>
                    <td class="liczba"><%# Eval("Amount", "{0:0.## zł}") %></td>
                    <td class="liczba" style="<%# Converters.GetColorBasedOnDecimal(Eval("Balance")) %>"><%# Eval("Balance", "{0:0.## zł}") %></td>
                    <td class="tekst">
                        <asp:LinkButton ID="LinkButton1" runat="server" Text="Zmień kwotę" OnClientClick='<%# "openKatWydPopUp(" + Eval("Id") + "); return false;" %>' /></td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="altTableItem">
                    <td class="tekst"><%# Eval("Name") %></td>
                    <td class="liczba"><%# Eval("Amount", "{0:0.## zł}") %></td>
                    <td class="liczba" style="<%# Converters.GetColorBasedOnDecimal(Eval("Balance")) %>"><%# Eval("Balance", "{0:0.## zł}") %></td>
                    <td class="tekst">
                        <asp:LinkButton ID="LinkButton2" runat="server" Text="Zmień kwotę" OnClientClick='<%# "openKatWydPopUp(" + Eval("Id") + "); return false;" %>' /></td>
                </tr>
            </AlternatingItemTemplate>
            <FooterTemplate>
                    </tbody>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <div id="pupKwotaKatWyd" title="Zmiana kwoty">
        <table>
            <tr>
                <td>Kwota</td>
                <td>
                    <asp:TextBox ClientIDMode="Static" ID="tbKwota" runat="server" /><input type="hidden" id="valExpenseCatId" /></td>
            </tr>
        </table>
    </div>
    <div id="pupNowaKatWyd" title="Nowa kategoria wydatków">
        <table>
            <tr>
                <td>Nazwa</td>
                <td>
                    <asp:TextBox ClientIDMode="Static" ID="tbNazwaKatWyd" runat="server" /></td>
            </tr>
            <tr>
                <td>Kwota</td>
                <td>
                    <asp:TextBox ClientIDMode="Static" ID="tbKwotaKatWyd" runat="server" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

