<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/SzabGlowny.master" AutoEventWireup="true" CodeFile="BudzetDetails.aspx.cs" Inherits="Views_BudzetDetails_BudzetDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="Panel1" runat="server" Visible="<%# !this.CanView %>">
        <div style="display: block; margin-top: 30px; font-size: 16px; color: red; font-weight: bold;">Nie możesz przeglądać zawartości tej strony!</div>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Visible="<%# this.CanView %>">
        <div id="content">
            <div class="pageHeader">Budżet "<asp:Label runat="server" ID="lblBudgetName" />"</div>
            <asp:LinkButton ID="LinkButton1" runat="server" Text="Dodaj nową pozycję" PostBackUrl='<%# "~/Views/BudzetDetails/NowaPozycjaBudzetu.aspx?id=" + this.GetQueryStringValue(GETValueIdentifiers.ID) %>' />
            <div style="display: block; margin-top: 30px; font-size: 16px; color: darkred; font-weight: bold;">
                <asp:Label ID="Label1" runat="server" Text="Brak dodanych pozycji budżetu" Visible="<%# !this.RepeaterVisible %>" />
            </div>


            <asp:Repeater runat="server" ID="rptrBudgetDetails" Visible="<%# this.RepeaterVisible %>">
                <HeaderTemplate>
                    <table class="table">
                        <tr class="tableHeader">
                            <td class="tekstHeader">Nazwa</td>
                            <td class="tekstHeader">Cena</td>
                            <td class="tekstHeader">Ilość</td>
                            <td class="tekstHeader">Wartość</td>
                            <td class="tekstHeader">Data zakupu</td>
                            <td class="tekstHeader">Kategoria wydatków</td>
                            <td>
                                <img src="../../Images/shop-small.png" title="Najedź na ikonę sklepu, by dowiedzieć się, gdzie dokonano zakupu" /></td>
                            <td>
                                <img src="../../Images/info-small.png" title="Najedź na ikonę informacji, by odczytać zapisane dodatkowe informacje" /></td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tableItem">
                        <td class="tekst"><%# Eval("ProductName") %></td>
                        <td class="liczba"><%# Eval("Price") %> zł</td>
                        <td class="liczba"><%# Eval("Quantity") %></td>
                        <td class="liczba"><%# Eval("Wartosc") %> zł</td>
                        <td class="tekst"><%# Eval("PurchaseDateString") %></td>
                        <td class="tekst"><%# Eval("ExpenseCatName") %></td>
                        <td>
                            <img src="../../Images/shop-small.png" title="<%# Eval("ShopFriendlyName") %>" /></td>
                        <td>
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/info-small.png" title='<%# Eval("AddInfo") %>' Visible='<%# !string.IsNullOrEmpty(Eval("AddInfo") as string) %>' /></td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr class="altTableItem">
                        <td class="tekst"><%# Eval("ProductName") %></td>
                        <td class="liczba"><%# Eval("Price") %> zł</td>
                        <td class="liczba"><%# Eval("Quantity") %></td>
                        <td class="liczba"><%# Eval("Wartosc") %> zł</td>
                        <td class="tekst"><%# Eval("PurchaseDateString") %></td>
                        <td class="tekst"><%# Eval("ExpenseCatName") %></td>
                        <td>
                            <img src="../../Images/shop-small.png" title="<%# Eval("ShopFriendlyName") %>" /></td>
                        <td>
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/info-small.png" title='<%# Eval("AddInfo") %>' Visible='<%# !string.IsNullOrEmpty(Eval("AddInfo") as string) %>' /></td>
                    </tr>
                </AlternatingItemTemplate>
                <FooterTemplate>
                    <tr class="tablePodsumowanie">
                        <td class="liczba">Podsumowanie:</td>
                        <td class="liczba"><%= this.SumaCeny.ToString() %> zł</td>
                        <td class="liczba"><%= this.SumaIlosci.ToString() %></td>
                        <td class="liczba"><%= this.SumaWartosci.ToString() %> zł</td>
                        <td colspan="4"></td>
                    </tr>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </asp:Panel>
</asp:Content>

