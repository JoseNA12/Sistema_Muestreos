<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambiarContraseña.aspx.cs" Inherits="Sistema_Muestreos.Pantallas.CambiarContraseña" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="margin: auto; height: 409px; width: 392px; background-image: url('Img/Background_2.jpg'); position:center;">
    <form id="form1" runat="server">
        <div style="height: 454px; width: 401px">
            <br />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Cambiar contraseña" Font-Names="Microsoft Sans Serif" Font-Size="X-Large" ForeColor="White"></asp:Label>
            <br />
            <br />
            <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center">
                <br />
                <asp:Label ID="Label1" runat="server" Text="Ingrese la contraseña:" Font-Names="Microsoft Sans Serif" Font-Size="Medium"></asp:Label>
                <br />
                <br />
                <asp:TextBox ID="TextBox_Contrasenia_1" runat="server" TextMode="Password" Width="176px"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label3" runat="server" Font-Names="Microsoft Sans Serif" Text="Ingrese nuevamente la contraseña:"></asp:Label>
                <br />
                <br />
                <asp:TextBox ID="TextBox_Contrasenia_2" runat="server" TextMode="Password" Width="171px"></asp:TextBox>
                <br />
                <br />
                <br />
                <asp:CheckBox ID="CheckBox_EstasSeguro" runat="server" Font-Names="Microsoft Sans Serif" Font-Size="Medium" Text="¿Estás seguro?" />
                <br />
                <br />
                &nbsp;&nbsp;
                <asp:Button ID="Button_CambiarContraseña" runat="server" Height="38px" OnClick="Button_CambiarContraseña_Click" Text="Cambiar" Width="80px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button_Atras" runat="server" Font-Names="Microsoft Sans Serif" Height="38px" OnClick="Button_Atras_Click" Text="Atras" Width="70px" />
            </asp:Panel>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
        </div>
    </form>
</body>
</html>
