<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
    <div class="page-content">
        <div class="page-form">
            <p>Usuario:
            <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
            </p>
            <p>Contraseña:
            <asp:TextBox ID="txtContraseña" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="btnLog" runat="server" Text="Aceptar" onclick="btnLog_Click" />
            </p>
        </div>
    </div>
    </form>
    </body>
</html>
