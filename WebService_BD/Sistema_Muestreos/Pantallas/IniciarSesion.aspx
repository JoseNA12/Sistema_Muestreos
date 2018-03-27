<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IniciarSesion.aspx.cs" Inherits="Sistema_Muestreos.IniciarSesion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Iniciar Sesión</title>
    <style type="text/css">
        #form1 {
            height: 406px;
            width: 562px;
            margin-bottom: 0px;
        }
    </style>
</head>
<body style="height: 409px; width: 592px; margin-bottom: 0px;">
    <form id="form1" runat="server" autocomplete="on">
        <asp:Panel ID="Panel1" runat="server" BackColor="#3399FF" Height="410px" Width="517px" HorizontalAlign="Center">
            <asp:Panel ID="Panel2" runat="server" BackColor="White" Height="410px" HorizontalAlign="Center" style="margin-left: 128px; margin-right: 1px; margin-top: 0px; margin-bottom: 1px" Width="268px">
                <br />
                <br />
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Microsoft Sans Serif" Font-Size="Large" Text="Iniciar Sesión"></asp:Label>
                <br />
                <br />
                <br />
                <br />
                &nbsp;<asp:Label ID="Label2" runat="server" Font-Names="Microsoft Sans Serif" Font-Size="Medium" Text="Nombre de usuario:"></asp:Label>
                <br />
                <br />
                <asp:TextBox ID="TextBox_NombreUsuario" runat="server" Font-Names="Calibri" Font-Size="Medium" style="margin-left: 0px"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label3" runat="server" Font-Names="Microsoft Sans Serif" Font-Size="Medium" Text="Contraseña:"></asp:Label>
                <br />
                <br />
                <asp:TextBox ID="TextBox_Contrasenia" runat="server" Font-Names="Calibri" Font-Size="Medium" TextMode="Password"></asp:TextBox>
                <br />
                <br />
                <br />
                <asp:Button ID="button_Ingresar" runat="server" BackColor="#0099FF" Font-Names="Calibri" Font-Size="Medium" ForeColor="White" Text="Ingresar" Width="163px" OnClick="button_Ingresar_Click" />
                <br />
                <br />
            </asp:Panel>
        </asp:Panel>
    </form>
</body>
</html>
