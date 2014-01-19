<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/SzabGlowny.master" AutoEventWireup="true" CodeFile="Budzet.aspx.cs" Inherits="Views_Budzet_Budzet" %>

<%@ Register Src="~/Views/Budzet/ListaBudzetow.ascx" TagPrefix="uc1" TagName="ListaBudzetow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">
        <div class="pageHeader">Budżety</div>
        <div style="text-align: center; float: none;">
            <asp:LinkButton ID="btnNowyBudzet" OnClientClick='$("#pupNowyBudzet").dialog("open"); return false;' runat="server">Dodaj nowy budżet</asp:LinkButton>
        </div>
        <uc1:ListaBudzetow runat="server" ID="ListaBudzetow" />
    </div>
    <div id="pupNowyBudzet" title="Nowy budżet">
        <table>
            <tr>
                <td>Nazwa budżetu</td>
                <td>
                    <asp:TextBox ID="tbNazwaBudzetu" ClientIDMode="Static" runat="server" BorderStyle="None"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

