<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/SzabGlowny.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel runat="server" Style="text-align: center;">
        <div id="content">

            <div style="font-size:16px; font-weight:bold; margin-top: 30px; color:#753d6a;">Strona Cheaper pozwoli Ci kontrolować Twój budżet.</div>
            <asp:Repeater ID="rptrUsers" runat="server" Visible="false">
                <HeaderTemplate>Lista użytkowników
                    <table class="table">
                        <tr class="tableHeader">
                            <td style="border:1px solid #d2ee5e">Nazwa użytkownika</td>
                            <td style="border:1px solid #d2ee5e">Hasło</td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tableItem">
                        <td style="border:1px solid #d2ee5e; text-align: center;"><%# Eval("UserName") %></td>
                        <td style="border:1px solid #d2ee5e; text-align: center;"><%# Eval("Passwd") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </asp:Panel>
</asp:Content>

