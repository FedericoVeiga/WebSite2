<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="salaDeEspera.aspx.cs" Inherits="salaDeEspera" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <h1>Bienvenido a la sala de chat</h1>
    <asp:GridView ID="gvSala" runat="server" OnRowCommand="gvSala_RowCommand">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate> 
                    <asp:LinkButton ID="lnkEntrar" CommandName="Entrar"  runat="server">Ingresar</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
         <Columns>
            <asp:TemplateField>
                <ItemTemplate> 
                    <asp:LinkButton ID="lnkborrar" CommandName="Eliminar"  runat="server">Eliminar</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

