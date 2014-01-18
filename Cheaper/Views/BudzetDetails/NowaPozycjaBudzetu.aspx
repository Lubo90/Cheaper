<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/SzabGlowny.master" AutoEventWireup="true" CodeFile="NowaPozycjaBudzetu.aspx.cs" Inherits="Views_BudzetDetails_NowaPozycjaBudzetu" %>

<%@ Register Namespace="Cheaper.Controls" TagPrefix="ctl"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#tbShops").change(function () {
                $("#tbShopId").val(null);
            });

            $("#tbProducts").change(function () {
                $("#tbProductsId").val("sdfg");
            });
        });
    </script>
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
                    <asp:TextBox runat="server" ClientIDMode="Static" ID="tbProducts" /><ctl:HiddenFieldValidatable runat="server" ID="tbProductsId" ClientIDMode="Static" />
                <asp:RequiredFieldValidator ID="rfvProducts" runat="server" ControlToValidate="tbProductsId" Display="Dynamic" ToolTip="Musisz wybrać sklep za pomocą podpowiedzi"><div class="validationErr">Podaj wartość</div></asp:RequiredFieldValidator>
                </td>
                <td class="tableItem"><asp:Button ID="Button1" Width="100" runat="server" OnClientClick='$("#pupNowyProdukt").dialog("open"); return false;' Text="Nowy produkt" /></td>
            </tr>
            <tr>
                <td class="tableHeader">Kategoria<br />
                    wydatku</td>
                <td class="tableItem">
                    <asp:DropDownList runat="server" ID="ddlKategorieWyd" />
                </td>
            </tr>
            <tr>
                <td class="tableHeader">Sklep</td>
                <td class="tableItem">
                    <asp:TextBox runat="server" ClientIDMode="Static" ID="tbShops" /><ctl:HiddenFieldValidatable runat="server" ID="tbShopId" ClientIDMode="Static" />
                    <asp:RequiredFieldValidator runat="server" ID="rfvShops" Display="Dynamic" ControlToValidate="tbShopId" ToolTip="Musisz wybrać sklep za pomocą podpowiedzi"><div class="validationErr">Podaj wartość</div></asp:RequiredFieldValidator>
                    <asp:Button Width="100" runat="server" OnClientClick='$("#pupNowySklep").dialog("open"); return false;' Text="Nowy sklep" /></td>
            </tr>
            <tr>
                <td class="tableHeader">Cena</td>
                
                <td class="tableItem">
                    <asp:TextBox runat="server" ID="tbPrice" ClientIDMode="Static" />
                    <asp:RangeValidator runat="server" ID="rvPrice" MinimumValue="0" MaximumValue="100000000" Display="Dynamic" Type="Double" ControlToValidate="tbPrice"><div class="validationErr">Niepoprawna wartość</div></asp:RangeValidator>
                    <asp:RequiredFieldValidator runat="server" ID="rfvPrice" ControlToValidate="tbPrice" Display="Dynamic"><div class="validationErr">Podaj cenę</div></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="tableHeader">Data zakupu</td>
                <td class="tableItem">
                    <asp:TextBox runat="server" ClientIDMode="Static" ID="tbPurchaseDate" />
                    <asp:RegularExpressionValidator runat="server" ID="revPurchaseDate" Display="Dynamic" ControlToValidate="tbPurchaseDate" ValidationExpression="^\d{2}-\d{2}-\d{4}"><div class="validationErr">Musisz podać cenę</div></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="tableHeader">
                    Ilość</td>
                <td class="tableItem">
                    <asp:TextBox runat="server" ID="tbQuantity" />
                    <asp:RangeValidator runat="server" ID="rvQuantity" MinimumValue="1" MaximumValue="10000" Display="Dynamic" Type="Double" ControlToValidate="tbPrice"><div class="validationErr">Niepoprawna wartość</div></asp:RangeValidator>
                    <asp:RequiredFieldValidator runat="server" ID="rfvQuantity" ControlToValidate="tbPrice" Display="Dynamic"><div class="validationErr">Podaj ilość</div></asp:RequiredFieldValidator>
                </td>
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

