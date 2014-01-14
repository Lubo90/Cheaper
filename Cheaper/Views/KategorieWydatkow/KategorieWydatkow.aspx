<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/SzabGlowny.master" AutoEventWireup="true" CodeFile="KategorieWydatkow.aspx.cs" Inherits="Views_KategorieWydatkow_KategorieWydatkow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="overflow: hidden; margin: 0 auto 0 auto;">
        <div style="font-size: 20px; font-weight: bold; font-family: Arial; float: none; text-align: center">Kategorie wydatków</div>
        <div style="text-align: center; float: none;">
            <asp:LinkButton ID="btnNowyBudzet" OnClientClick='$("#pupNowaKatWyd").dialog("open"); return false;' runat="server">Dodaj nową kategorię</asp:LinkButton>
        </div>
        <div id="content">
        <asp:Repeater runat="server" ID="rptrKatWyd">
            <HeaderTemplate>
                <table class="table">
                    <tr class="tableHeader">
                        <td>Nazwa</td>
                        <td>Miesięczna kwota</td>
                        <td>Pozostało do wydania</td>
                        <td></td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="tableItem">
                    <td><%# Eval("Name") %></td>
                    <td><%# Eval("Amount") %> zł</td>
                    <td><%# Eval("Balance") %> zł</td>
                    <td>
                        <asp:LinkButton ID="LinkButton1" runat="server" Text="Zmień kwotę" OnClientClick='<%# "openKatWydPopUp(" + Eval("Id") + "); return false;" %>' /></td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="altTableItem">
                    <td><%# Eval("Name") %></td>
                    <td><%# Eval("Amount") %> zł</td>
                    <td><%# Eval("Balance") %> zł</td>
                    <td>
                        <asp:LinkButton ID="LinkButton2" runat="server" Text="Zmień kwotę" OnClientClick='<%# "openKatWydPopUp(" + Eval("Id") + "); return false;" %>' /></td>
                </tr>
            </AlternatingItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
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
                <td><asp:TextBox ClientIDMode="Static" ID="tbNazwaKatWyd" runat="server" /></td>
            </tr>
            <tr>
                <td>Kwota</td>
                <td><asp:TextBox ClientIDMode="Static" ID="tbKwotaKatWyd" runat="server" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

