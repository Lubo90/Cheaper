<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListaBudzetow.ascx.cs" Inherits="Views_Budzet_ListaBudzetow" %>

<div style="margin: 0 auto; float: left;text-align:center; margin:0 auto; display:block;">
<asp:Repeater runat="server" ID="rptrBudgets">
    <HeaderTemplate>
        <table>
            <tr>
                <td>Nazwa budżetu</td>
                <td>Data utworzenia</td>
                <td>Przychody</td>
                <td>Wydatki</td>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td><%# Eval("BudgetName") %></td>
            <td><%# Eval("CreationDate") %></td>
            <td><%# Eval("Income") %></td>
            <td><%# Eval("Expenses") %></td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
    </div>
