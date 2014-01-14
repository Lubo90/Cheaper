<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/SzabGlowny.master" AutoEventWireup="true" CodeFile="BudzetDetails.aspx.cs" Inherits="Views_BudzetDetails_BudzetDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <span>Budżet "<asp:Label runat="server" ID="lblBudgetName" />"</span><br />
                <asp:LinkButton runat="server" Text="Dodaj nową pozycję" PostBackUrl='<%# "~/Views/BudzetDetails/NowaPozycjaBudzetu.aspx?id=" + this.GetQueryStringValue(GETValueIdentifiers.ID) %>' />
        <asp:Repeater runat="server" ID="rptrBudgetDetails">
            <HeaderTemplate>
                <table class="table">
                    <tr class="tableHeader">
                        <td>Nazwa</td>
                        <td>Cena</td>
                        <td>Ilość</td>
                        <td>Wartość</td>
                        <td>Data zakupu</td>
                        <td>Kategoria wydatków</td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="tableItem">
                    <td><%# Eval("ProductName") %></td>
                    <td><%# Eval("Price") %></td>
                    <td><%# Eval("Quantity") %></td>
                    <td><%# Eval("Wartosc") %></td>
                    <td><%# Eval("PurchaseDateString") %></td>
                    <td><%# Eval("ExpenseCatName") %></td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="altTableItem">
                    <td><%# Eval("ProductName") %></td>
                    <td><%# Eval("Price") %></td>
                    <td><%# Eval("Quantity") %></td>
                    <td><%# Eval("Wartosc") %></td>
                    <td><%# Eval("PurchaseDateString") %></td>
                    <td><%# Eval("ExpenseCatName") %></td>
                </tr>
            </AlternatingItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

