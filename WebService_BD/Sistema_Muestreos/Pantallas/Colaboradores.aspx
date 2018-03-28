<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Colaboradores.aspx.cs" Inherits="Sistema_Muestreos.Colaboradores" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="margin: auto; height: 455px; width: 695px; background-image: url('Img/Background_2.jpg'); position:center; ">
    <form id="form1" runat="server">
        <div style="height: 456px; width: 692px;">
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Colaboradores" Font-Names="Microsoft Sans Serif" Font-Size="X-Large" ForeColor="White"></asp:Label>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;<asp:ListBox ID="ListBox_Colaboradores" runat="server" Height="269px" Width="588px" AppendDataBoundItems="True" OnSelectedIndexChanged="ListBox_Colaboradores_SelectedIndexChanged"></asp:ListBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button_Agregar" runat="server" Text="Agregar" Height="38px" OnClick="Button_Agregar_Click" Width="86px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button_Eliminar" runat="server" Text="Eliminar" Height="38px" Width="82px" OnClick="Button_Eliminar_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button_Salir" runat="server" Text="Salir" Width="87px" Height="38px" OnClick="Button_Salir_Click" />
        </div>
    </form>
</body>
</html>

