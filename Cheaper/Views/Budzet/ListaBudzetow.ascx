<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListaBudzetow.ascx.cs" Inherits="Views_Budzet_ListaBudzetow" %>

            <div style="display: block; margin-top: 30px; font-size: 16px; color: darkred; font-weight: bold;">
                <asp:Label ID="Label1" runat="server" Text="Brak utworzonych budżetów" Visible="<%# !this.RepeaterVisible %>" />
            </div>

<asp:Repeater runat="server" ID="rptrBudgets" Visible="<%# this.RepeaterVisible %>">
    <HeaderTemplate>
        <table class="table">
            <tr class="tableHeader">
                <td class="tekstHeader">Nazwa budżetu</td>
                <td class="tekstHeader">Utworzono</td>
                <td class="tekstHeader">Wydatki w tym msc</td>
                <td class="tekstHeader">Wydatki w tym roku</td>
                <td class="tekstHeader">Ilość poz. budżetu</td>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr class="tableItem">
            <td class="tekst"><asp:LinkButton runat="server" PostBackUrl='<%# "~/Views/BudzetDetails/BudzetDetails.aspx?id=" + Eval("BudgetID") %>'><%# Eval("BudgetName") %></asp:LinkButton></td>
            <td class="tekst"><%# Eval("CreationDate") %></td>
            <td class="liczba"><%# Eval("LastMonthExpenses") %></td>
            <td class="liczba"><%# Eval("LastYearExpenses") %></td>
            <td class="liczba"><%# Eval("PositionsCount") %></td>
        </tr>
    </ItemTemplate>
    <AlternatingItemTemplate>
        <tr class="altTableItem">
            <td class="tekst"><asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl='<%# "~/Views/BudzetDetails/BudzetDetails.aspx?id=" + Eval("BudgetID") %>'><%# Eval("BudgetName") %></asp:LinkButton></td>
            <td class="tekst"><%# Eval("CreationDate") %></td>
            <td class="liczba"><%# Eval("LastMonthExpenses") %></td>
            <td class="liczba"><%# Eval("LastYearExpenses") %></td>
            <td class="liczba"><%# Eval("PositionsCount") %></td>
        </tr>
    </AlternatingItemTemplate>
    <FooterTemplate>
        <tr class="tablePodsumowanie">
            <td class="liczba">Podsumowanie:</td>
            <td></td>
            <td class="liczba"><%= this.SumaWydatkowMsc.ToString() %> zł</td>
            <td class="liczba"><%= this.SumaWydatkowRok.ToString() %> zł</td>
            <td class="liczba"><%= this.SumaPozycji.ToString() %></td>
        </tr>
        </table>
    </FooterTemplate>
</asp:Repeater>
