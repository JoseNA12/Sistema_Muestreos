<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IniciarSesion.aspx.cs" Inherits="Sistema_Muestreos.IniciarSesion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Iniciar Sesión</title>
    <style type="text/css">
        #form1 {
            height: 559px;
            width: 525px;
            margin-bottom: 0px;
        }
    </style>
</head>
<body style="margin: auto; height: 584px; width: 515px; background-image: url('Img/Background_2.jpg'); position:center; ">
    <form id="form1" runat="server" autocomplete="on">
        <div style=" margin-left: auto; margin-right:auto;">
            <asp:Panel ID="Panel1" runat="server" Height="584px" Width="518px" HorizontalAlign="Center" style="margin-top: 55px">
                <asp:Panel ID="Panel2" runat="server" BackColor="White" Height="545px" HorizontalAlign="Center" style="margin-left: 128px; margin-right: 1px; margin-top: 0px; margin-bottom: 1px" Width="268px">
                    <br />
                    <asp:Image ID="Image1" runat="server" Height="130px" ImageUrl="~/Pantallas/Img/login.png" Width="130px" />
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
                    <asp:Button ID="button_Ingresar" runat="server" BackColor="#06627B" Font-Names="Calibri" Font-Size="Large" ForeColor="White" Text="Ingresar" Width="163px" OnClick="button_Ingresar_Click" Height="39px" />
                    <br />
                    <br />
                </asp:Panel>
            </asp:Panel>
         </div>
    </form>
</body>
</html>
