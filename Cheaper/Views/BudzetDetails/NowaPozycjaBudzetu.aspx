<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/SzabGlowny.master" AutoEventWireup="true" CodeFile="NowaPozycjaBudzetu.aspx.cs" Inherits="Views_BudzetDetails_NowaPozycjaBudzetu" %>

<%@ Register Namespace="Cheaper.Controls" TagPrefix="ctl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel runat="server" Visible="<%# !this.CanView %>"><div style="display: block; margin-top: 30px; font-size: 16px; color: red; font-weight: bold;">Nie możesz przeglądać zawartości tej strony!</div></asp:Panel>
    <asp:Panel runat="server" Visible="<%# this.CanView %>">
    <div id="content">
        <asp:Panel runat="server" Visible="<%# !this.HasKategorieWydatkow %>">
            <div style="display: block; margin-top: 30px; font-size: 16px; color: darkred; font-weight: bold;">
                Brak dodanych kategorii wydatków, dodaj nową. 
            </div><asp:LinkButton style="display:block; margin-top: 15px;" runat="server" PostBackUrl="~/Views/KategorieWydatkow/KategorieWydatkow.aspx" Text="Przejdź do kategorii wydatków" />
        </asp:Panel>
        <asp:Panel runat="server" Visible="<%# this.HasKategorieWydatkow %>">
        <div class="pageHeader">Nowa pozycja budżetu "<asp:Label runat="server" ID="lblBudgetName" />"</div>
        <table class="table">
            <tr>
                <td class="tableHeader">Produkt
                    <asp:ImageButton style="float:right;" ID="ImageButton1" runat="server" ImageUrl="~/Images/add-button-small.png" OnClientClick='$("#pupNowyProdukt").dialog("open"); return false;' Visible="<%# !this.StatisticsEnabled %>" />
                </td>
                <td class="tableItem">
                    <asp:TextBox runat="server" ClientIDMode="Static" ID="tbProducts" /><ctl:HiddenFieldValidatable runat="server" ID="tbProductsId" ClientIDMode="Static" />
                    <asp:RequiredFieldValidator ID="rfvProducts" runat="server" ControlToValidate="tbProductsId" Display="Dynamic" ToolTip="Musisz wybrać produkt za pomocą podpowiedzi"><div class="validationErr">Podaj wartość</div></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="tableHeader">Kategoria<br />
                    wydatku</td>
                <td class="tableItem">
                    <asp:DropDownList runat="server" ID="ddlKategorieWyd" />
                </td>
            </tr>
            <tr>
                <td class="tableHeader">Sklep
                    <asp:ImageButton style="float:right;" runat="server" ImageUrl="~/Images/add-button-small.png" OnClientClick='$("#pupNowySklep").dialog("open"); return false;' />
                </td>
                <td class="tableItem">
                    <asp:TextBox runat="server" ClientIDMode="Static" ID="tbShops" /><ctl:HiddenFieldValidatable runat="server" ID="tbShopId" ClientIDMode="Static" />
                    <%--<asp:RequiredFieldValidator runat="server" ID="rfvShops" Display="Dynamic" ControlToValidate="tbShopId" ToolTip="Musisz wybrać sklep za pomocą podpowiedzi"><div class="validationErr">Podaj wartość</div></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td class="tableHeader">Cena</td>

                <td class="tableItem">
                    <asp:TextBox runat="server" ID="tbPrice" ClientIDMode="Static" />
                    <asp:RangeValidator runat="server" ID="rvPrice" MinimumValue="0" MaximumValue="100000000" Display="Dynamic" Type="Double" ControlToValidate="tbPrice"><div class="validationErr">Niepoprawna wartość</div></asp:RangeValidator>
                    <asp:RequiredFieldValidator runat="server" ID="rfvPrice" ControlToValidate="tbPrice" Display="Dynamic"><div class="validationErr">Podaj cenę</div></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="tableHeader">Data zakupu</td>
                <td class="tableItem">
                    <asp:TextBox runat="server" ClientIDMode="Static" ID="tbPurchaseDate" />
                    <asp:RequiredFieldValidator runat="server" ID="rfvPurchaseDate" ControlToValidate="tbPurchaseDate" Display="Dynamic"><div class="validationErr">Wybierz datę</div></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator runat="server" ID="revPurchaseDate" ValidationExpression="\d{4}-\d{2}-\d{2}" ControlToValidate="tbPurchaseDate" Display="Dynamic"><div class="validationErr">Niepoprawna data</div></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="tableHeader">Ilość</td>
                <td class="tableItem">
                    <asp:TextBox runat="server" ID="tbQuantity" />
                    <asp:RangeValidator runat="server" ID="rvQuantity" MinimumValue="0" MaximumValue="10000" Display="Dynamic" Type="Double" ControlToValidate="tbQuantity"><div class="validationErr">Niepoprawna wartość</div></asp:RangeValidator>
                    <asp:RequiredFieldValidator runat="server" ID="rfvQuantity" ControlToValidate="tbQuantity" Display="Dynamic"><div class="validationErr">Podaj ilość</div></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="tableHeader">Dodatkowe informacje</td>
                <td class="tableItem">
                    <asp:TextBox runat="server" ID="tbAddInfo" /></td>
            </tr>
            <tr>
                <td colspan="2" class="tableHeader">
                    <asp:Button Style="width: 100%" runat="server" Text="Zapisz pozycję" ID="btnSavePozycja" OnClick="btnSavePozycja_Click" />
                </td>
            </tr>
        </table>
            </asp:Panel>
    </div></asp:Panel>
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

