<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IniciarSesion.aspx.cs" Inherits="Sistema_Muestreos.IniciarSesion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #form1 {
            height: 395px;
        }
    </style>
</head>
<body style="height: 414px; width: 697px">
    <form id="form1" runat="server">
        <p>
            Iniciar Sesion</p>
        <p>
            Nombre de usuario:
        </p>
        <p>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p>
            Contraseña:</p>
        <p>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Ingresar" />
        </p>
    </form>
</body>
</html>
