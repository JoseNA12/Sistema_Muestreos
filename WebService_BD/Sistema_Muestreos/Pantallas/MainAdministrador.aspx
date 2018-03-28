<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainAdministrador.aspx.cs" Inherits="Sistema_Muestreos.MainAdministrador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>

<body style="margin: 65px auto auto auto; height: 512px; width: 452px; background-image: url('Img/Background_2.jpg'); position:center; ">
    <form id="form1" runat="server">
        <div style="height: 516px; width: 455px;">
            <br />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <asp:Panel ID="Panel2" runat="server" HorizontalAlign="Center">
                <asp:Label ID="Label1" runat="server" Font-Names="Microsoft Sans Serif" Font-Size="XX-Large" Text="Sistema de Muestreos" ForeColor="White" Font-Bold="True"></asp:Label>
            </asp:Panel>
            <br />
            <asp:Panel ID="Panel1" runat="server" Height="384px" style="margin-top: 0px" Width="451px" HorizontalAlign="Center">
                <asp:Button ID="Button_AgregarUsuario" runat="server" Text="Agregar usuario" Width="178px" Font-Names="Microsoft Sans Serif" Height="38px" OnClick="Button_AgregarUsuario_Click"/>
                <br />
                <br />
                <asp:Button ID="Button_Muestreo" runat="server" Font-Names="Microsoft Sans Serif" Height="38px" Text="Muestreo" Width="178px" OnClick="Button_Muestreo_Click" />
                <br />
                <br />
                <asp:Button ID="Button_CrearRevision" runat="server" Font-Names="Microsoft Sans Serif" Height="38px" Text="Crear revisión" Width="178px" OnClick="Button_CrearRevision_Click" />
                <br />
                <br />
                <asp:Button ID="Button_Actividades" runat="server" Font-Names="Microsoft Sans Serif" Height="38px" Text="Actividades" Width="178px" OnClick="Button_Actividades_Click" />
                <br />
                <br />
                <asp:Button ID="Button_Colaboradores" runat="server" Font-Names="Microsoft Sans Serif" Height="38px" Text="Colaboradores" Width="178px" OnClick="Button_Colaboradores_Click" />
                <br />
                <br />
                <br />
                <asp:Panel ID="Panel3" runat="server" HorizontalAlign="Right">
                    <asp:Button ID="Button_Salir" runat="server" BackColor="#06627B" BorderStyle="None" Font-Names="Microsoft Sans Serif" Font-Size="Large" Font-Strikeout="False" ForeColor="White" Height="38px" Text="Salir" Width="76px" OnClick="Button_Salir_Click" />
                </asp:Panel>
            </asp:Panel>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </div>
    </form>
</body>
</html>
