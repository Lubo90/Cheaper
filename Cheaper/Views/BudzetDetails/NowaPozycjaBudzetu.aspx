<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/SzabGlowny.master" AutoEventWireup="true" CodeFile="NowaPozycjaBudzetu.aspx.cs" Inherits="Views_BudzetDetails_NowaPozycjaBudzetu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<div style="float: left; margin: 0 auto;">--%>
    <div style="font-size: 20px; font-weight: bold; font-family: Arial; float: none; text-align: center">Nowa pozycja budżetu</div>
    <div id="content">
        <table class="table">
            <tr>
                <td class="tableHeader" style="width: 100px;">
                    <asp:Label runat="server" Text="Produkt" />
                </td>
                <td class="tableItem">
                    <asp:TextBox runat="server" ClientIDMode="Static" ID="tbProducts" /><asp:Button Width="100" runat="server" OnClientClick='$("#pupNowyProdukt").dialog("open"); return false;' Text="Nowy produkt" />
                </td>
            </tr>
            <tr>
                <td class="tableHeader">Kategoria<br />
                    wydatku</td>
                <td class="tableItem">
                    <asp:DropDownList runat="server" ID="ddlKategorieWyd" /><%--<asp:Button runat="server" Width="100" OnClientClick='$("#pupNowaKatWyd").dialog("open"); return false;' Text="Nowa kat. wyd." />--%>
                </td>
            </tr>
            <tr>
                <td class="tableHeader">Sklep</td>
                <td class="tableItem">
                    <asp:TextBox runat="server" ClientIDMode="Static" ID="tbShops" /><asp:HiddenField ID="tbShopId" runat="server" ClientIDMode="Static" />
                    <asp:Button Width="100" runat="server" OnClientClick='$("#pupNowySklep").dialog("open"); return false;' Text="Nowy sklep" /></td>
            </tr>
            <tr>
                <td class="tableHeader">Cena</td>
                <td class="tableItem">
                    <asp:TextBox runat="server" ID="tbPrice" /></td>
            </tr>
            <tr>
                <td class="tableHeader">Data zakupu</td>
                <td class="tableItem">
                    <asp:TextBox runat="server" ClientIDMode="Static" ID="tbPurchaseDate" /></td>
            </tr>
            <tr>
                <td class="tableHeader">Ilość</td>
                <td class="tableItem">
                    <asp:TextBox runat="server" ID="tbQuantity" /></td>
            </tr>
            <tr>
                <td class="tableHeader">Dodatkowe informacje</td>
                <td class="tableItem">
                    <asp:TextBox runat="server" ID="tbAddInfo" /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button runat="server" Text="Zapisz pozycję" ID="btnSavePozycja" OnClick="btnSavePozycja_Click"/>
                </td>
            </tr>
        </table>
    </div>
    <div id="pupNowyProdukt" title="Nowy produkt">
        <table>
            <tr>
                <td>Nazwa</td>
                <td>
                    <asp:TextBox ClientIDMode="Static" ID="tbNazwaProduktu" runat="server" /></td>
            </tr>
            <tr>
                <td>Kategoria</td>
                <td>
                    <asp:DropDownList ID="ddlKategorie" ClientIDMode="Static" runat="server"></asp:DropDownList>
                </td>
            </tr>
        </table>
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
                    <asp:TextBox ClientIDMode="Static" ID="tbShopKodPocztowy" runat="server" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

