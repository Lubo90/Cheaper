<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage/SzabGlowny.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel runat="server" Style="text-align: center;">
        <div style="font-size: 26px; margin: auto 0 auto 0;"><asp:Label runat="server">Witam na stronie Cheaper!</asp:Label></div>
        <div style="float: left;">Lista użytkowników<br />
            <asp:Repeater ID="rptrUsers" runat="server">
                <HeaderTemplate>
                    <table style="border:3px solid #00ff21">
                        <tr style="border:1px solid #d2ee5e">
                            <td style="border:1px solid #d2ee5e">Nazwa użytkownika</td>
                            <td style="border:1px solid #d2ee5e">Hasło</td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
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

