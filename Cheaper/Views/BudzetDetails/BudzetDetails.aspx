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
                            <td class="tekst">
                                <img src="../../Images/shop-small.png" title="Najedź na ikonę sklepu, by dowiedzieć się, gdzie dokonano zakupu" /></td>
                            <td class="tekst">
                                <img src="../../Images/info-small.png" title="Najedź na ikonę informacji, by odczytać zapisane dodatkowe informacje" /></td>
                            <% if (this.StatisticsEnabled)
                               { %>
                            <td class="tekstHeader">Różnica<br />
                                ceny</td>
                            <% } %>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tableItem">
                        <td class="tekst"><%# Eval("ProductName") %></td>
                        <td class="liczba"><%# Eval("Price", "{0:0.## zł}") %></td>
                        <td class="liczba"><%# Eval("Quantity", "{0:0.##}") %></td>
                        <td class="liczba"><%# Eval("Wartosc", "{0:0.## zł}") %></td>
                        <td class="tekst"><%# Eval("PurchaseDateString") %></td>
                        <td class="tekst"><%# Eval("ExpenseCatName") %></td>
                        <td class="tekst">
                            <asp:Image ID="imgShop" runat="server" ImageUrl="~/Images/shop-small.png" title='<%# Eval("ShopFriendlyName") %>' Visible='<%# !string.IsNullOrEmpty(Eval("ShopFriendlyName") as string) %>' /></td>
                        <td class="tekst">
                            <asp:Image ID="imgInfo" runat="server" ImageUrl="~/Images/info-small.png" title='<%# Eval("AddInfo") %>' Visible='<%# !string.IsNullOrEmpty(Eval("AddInfo") as string) %>' /></td>
                        <% if (this.StatisticsEnabled)
                           { %>
                        <td class="liczba" style="<%# Converters.GetColorBasedOnDecimal(Eval("RoznicaCeny")) %>"
                            title="Średnia cena: <%# Eval("SredniaCena", "{0:0.## zł}") %>"><%# Eval("RoznicaCeny", "{0:0.## zł}") %></td>
                        <% } %>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr class="altTableItem">
                        <td class="tekst"><%# Eval("ProductName") %></td>
                        <td class="liczba"><%# Eval("Price", "{0:0.## zł}") %></td>
                        <td class="liczba"><%# Eval("Quantity", "{0:0.##}") %></td>
                        <td class="liczba"><%# Eval("Wartosc", "{0:0.## zł}") %></td>
                        <td class="tekst"><%# Eval("PurchaseDateString") %></td>
                        <td class="tekst"><%# Eval("ExpenseCatName") %></td>
                        <td class="tekst">
                            <asp:Image ID="imgShopAlt" runat="server" ImageUrl="~/Images/shop-small.png" title='<%# Eval("ShopFriendlyName") %>' Visible='<%# !string.IsNullOrEmpty(Eval("ShopFriendlyName") as string) %>' /></td>
                        <td class="tekst">
                            <asp:Image ID="imgInfoAlt" runat="server" ImageUrl="~/Images/info-small.png" title='<%# Eval("AddInfo") %>' Visible='<%# !string.IsNullOrEmpty(Eval("AddInfo") as string) %>' /></td>
                        <% if (this.StatisticsEnabled)
                           { %>
                        <td class="liczba" style="<%# Converters.GetColorBasedOnDecimal(Eval("RoznicaCeny")) %>"
                            title="Średnia cena: <%# Eval("SredniaCena", "{0:0.## zł}") %>"><%# Eval("RoznicaCeny", "{0:0.## zł}") %></td>
                        <% } %>
                    </tr>
                </AlternatingItemTemplate>
                <FooterTemplate>
                    <tr class="tablePodsumowanie">
                        <td class="liczba">Podsumowanie:</td>
                        <td class="liczba"><%= this.SumaCeny.ToString("0.##") %> zł</td>
                        <td class="liczba"><%= this.SumaIlosci.ToString("0.##") %></td>
                        <td class="liczba"><%= this.SumaWartosci.ToString("0.##") %> zł</td>
                        <td colspan="4" class="liczba"><%# (this.SumaRoznic < 0 ? "Przepłacono" : "Zaoszczędzono") + " w sumie:" %></td>
                        <% if (this.StatisticsEnabled)
                           { %>
                        <td class="liczba" style="<%# Converters.GetColorBasedOnDecimal(this.SumaRoznic) %>"><%= (this.SumaRoznic < 0 ? this.SumaRoznic * -1 : this.SumaRoznic).ToString("0.## zł") %></td>
                        <% } %>
                    </tr>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </asp:Panel>
</asp:Content>

