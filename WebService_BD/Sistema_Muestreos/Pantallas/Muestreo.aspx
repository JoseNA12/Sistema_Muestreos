<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Muestreo.aspx.cs" Inherits="Sistema_Muestreos.NuevoMuestreo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="margin: auto; background-image: url('Img/Background_2.jpg'); width: 611px; position:center; height: 391px;">
    <form id="form1" runat="server">
        <div style="width: 609px; height: 368px">
            <asp:Panel ID="Panel1" runat="server" Font-Size="XX-Large" Height="383px" Width="612px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                <asp:Label ID="Label2" runat="server" Font-Names="Microsoft Sans Serif" Font-Size="X-Large" ForeColor="White" Text="Muestreo"></asp:Label>
                <br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server" Font-Size="Medium" Text="Lapso de tiempo" Font-Names="Microsoft Sans Serif"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label5" runat="server" Font-Names="Microsoft Sans Serif" Font-Size="Medium" Text="Tiempo extra"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox_LapsePersonalizado" runat="server" TextMode="Number" Width="81px"></asp:TextBox>
                &nbsp;<asp:Label ID="Label4" runat="server" Font-Names="Microsoft Sans Serif" Font-Size="Small" Text="Minutos"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:TextBox ID="TextBox_LapsoExtra" runat="server" Width="80px"></asp:TextBox>
                &nbsp;<asp:Label ID="Label6" runat="server" Font-Names="Microsoft Sans Serif" Font-Size="Small" Text="Minutos"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:CheckBox ID="CheckBox1_LapsoAleatorio" runat="server" Font-Names="Microsoft Sans Serif" Font-Size="Medium" Text="Lapso aleatorio ?" />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button_ActualizarLapso" runat="server" Font-Names="Microsoft Sans Serif" Height="38px" OnClick="Button_ActualizarLapso_Click" Text="Actualizar lapso" Visible="False" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button_HorasLibres" runat="server" Height="38px" OnClick="Button_HorasLibres_Click" Text="Horas libres" Width="97px" />
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="Button_NuevoMuestreo" runat="server" Font-Names="Microsoft Sans Serif" Height="38px" OnClick="Button_NuevoMuestreo_Click" Text="Nuevo Muestreo" />
                &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                <asp:Button ID="Button_FinalizarMuestreo" runat="server" Font-Names="Microsoft Sans Serif" Height="38px" OnClick="Button_FinalizarMuestreo_Click" Text="Finalizar Muestreo" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                <asp:Button ID="Button_Atras" runat="server" Font-Names="Microsoft Sans Serif" Height="38px" OnClick="Button_Atras_Click" Text="Atrás" Width="68px" />
                <br />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
