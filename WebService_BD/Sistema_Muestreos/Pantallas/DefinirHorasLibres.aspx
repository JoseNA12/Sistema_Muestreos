<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefinirHorasLibres.aspx.cs" Inherits="Sistema_Muestreos.Pantallas.DefinirHorasLibres" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="margin: auto; background-image: url('Img/Background_2.jpg'); width: 540px; position:center; height: 505px;">
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Font-Names="Microsoft Sans Serif" ForeColor="White" Text="Definir horas libres" Font-Size="X-Large"></asp:Label>
            <br />
            <br />
            <asp:Panel ID="Panel1" runat="server" Font-Names="Microsoft Sans Serif" Height="405px" HorizontalAlign="Center">
                <br />
                <asp:Label ID="Label6" runat="server" Text="Hora inicial"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label7" runat="server" Font-Names="Microsoft Sans Serif" Text="Hora final"></asp:Label>
                <br />
                <asp:TextBox ID="TextBox_HoraInicial" runat="server" Width="100px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox_HoraFinal" runat="server" Width="100px"></asp:TextBox>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                <br />
                <asp:Label ID="Label8" runat="server" Font-Names="Microsoft Sans Serif" Text="Horas establecidas"></asp:Label>
                <br />
                <asp:ListBox ID="ListBox_HorasLibresDefinidas" runat="server" Font-Names="Microsoft Sans Serif" Height="201px" Width="187px"></asp:ListBox>
                <br />
                <br />
                <asp:Button ID="Button_AgregarHoraLibre" runat="server" Height="38px" Text="Agregar hora" Width="95px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button_Atras" runat="server" Height="38px" Text="Atras" Width="69px" OnClick="Button_Atras_Click" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
