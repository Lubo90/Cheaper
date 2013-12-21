<%@ Page Title="" Language="C#" MasterPageFile="~/SzabGlowny.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label runat="server">To jest Label zawarty w podstronie Default.aspx</asp:Label>
    <asp:Repeater ID="Repeater1" runat="server"></asp:Repeater>
    <asp:EntityDataSource ID="EntityDataSource1" runat="server"></asp:EntityDataSource>
</asp:Content>

