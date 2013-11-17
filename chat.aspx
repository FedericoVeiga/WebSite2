<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="chat.aspx.cs" Inherits="chat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ListView ID="lvMensajes" runat="server">
        <ItemTemplate>
            <div><%# Eval("Texto") %></div>
        </ItemTemplate>
    </asp:ListView>
    <asp:TextBox ID="txtMensaje" Width="300px" runat="server"></asp:TextBox>
    <asp:Button ID="btnEnviar" runat="server" Text="Enviar" onclick="btnEnviar_Click" />
</asp:Content>
