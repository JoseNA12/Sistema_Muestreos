<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Puestos.aspx.cs" Inherits="Sistema_Muestreos.Pantallas.Puestos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="margin: auto; height: 497px; width: 695px; background-image: url('Img/Background_2.jpg'); position:center;">
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Font-Names="Microsoft Sans Serif" Font-Size="X-Large" ForeColor="White" Text="Puestos"></asp:Label>
            <br />
            <br />
            <asp:Panel ID="Panel1" runat="server" Height="391px" HorizontalAlign="Center">
                <br />
                <br />
                <asp:TextBox ID="TextBox_Puesto" runat="server" Font-Names="Microsoft Sans Serif" Font-Size="Medium" Height="28px"></asp:TextBox>
                &nbsp;&nbsp;<asp:Button ID="Button_Agregar" runat="server" Font-Names="Microsoft Sans Serif" Height="38px" OnClick="Button_Agregar_Click" Text="Agregar" Width="87px" />
                <br />
                <br />
                <asp:ListBox ID="ListBox_Puestos" runat="server" Font-Names="Microsoft Sans Serif" Height="176px" OnSelectedIndexChanged="ListBox_Puestos_SelectedIndexChanged" Width="185px"></asp:ListBox>
                <br />
                <br />
                <br />
                <br />
                &nbsp;<asp:Button ID="Button_Eliminar" runat="server" Font-Names="Microsoft Sans Serif" Height="38px" OnClick="Button_Eliminar_Click" Text="Eliminar" Width="95px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button_Atras" runat="server" Font-Names="Microsoft Sans Serif" Height="38px" OnClick="Button_Atras_Click" Text="Atras" Width="66px" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
