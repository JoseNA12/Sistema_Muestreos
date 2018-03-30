<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Muestreo.aspx.cs" Inherits="Sistema_Muestreos.NuevoMuestreo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="margin: auto; background-image: url('Img/Background_2.jpg'); width: 611px; position:center; height: 461px;">
    <form id="form1" runat="server">
        <div style="width: 609px; height: 453px">
            <br />
            <br />
                <asp:Label ID="Label2" runat="server" Font-Names="Microsoft Sans Serif" Font-Size="X-Large" ForeColor="White" Text="Muestreo"></asp:Label>
                <br />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server" Font-Size="Medium" Text="Rangos de tiempo" Font-Names="Microsoft Sans Serif"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label5" runat="server" Font-Names="Microsoft Sans Serif" Font-Size="Medium" Text="Tiempo extra" ToolTip="Tiempo que tarda el usuario en trasladarse al lugar del muestreo"></asp:Label>
                &nbsp;<asp:Panel ID="Panel2" runat="server" Height="319px" HorizontalAlign="Center">
                <br />
                <asp:TextBox ID="TextBox_RangoInicial" runat="server" Width="50px" Font-Names="Microsoft Sans Serif" Font-Size="Medium" Height="25px" MaxLength="4" ToolTip="Minutos entre cada muestreo preliminar" ></asp:TextBox>
                &nbsp;
                <asp:Label ID="Label7" runat="server" Font-Size="XX-Large" Text="~"></asp:Label>
                &nbsp;
                <asp:TextBox ID="TextBox_RangoFinal" runat="server" Width="50px" Font-Names="Microsoft Sans Serif" Font-Size="Medium" Height="25px" MaxLength="4" ToolTip="Minutos entre cada muestreo preliminar"></asp:TextBox>
                &nbsp;
                <asp:Label ID="Label4" runat="server" Font-Names="Microsoft Sans Serif" Font-Size="Small" Text="Minutos"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox_LapsoExtra" runat="server" Font-Names="Microsoft Sans Serif" Font-Size="Medium" Height="25px" MaxLength="4" ToolTip="Tiempo que se añade al lapso de tiempo" Width="50px"></asp:TextBox>
                <asp:Label ID="Label6" runat="server" Font-Names="Microsoft Sans Serif" Font-Size="Small" Text="Minutos"></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <br />
                <br />
                <asp:CheckBox ID="CheckBox1_LapsoAleatorio" runat="server" Font-Names="Microsoft Sans Serif" Font-Size="Medium" Text="Lapso aleatorio ?" ToolTip="El tiempo extra se considera" />
                <br />
                <br />
                <br />
                <asp:Button ID="Button_ActualizarLapso" runat="server" Height="38px" OnClick="Button_ActualizarLapso_Click" Text="Actualizar lapso" Font-Names="Microsoft Sans Serif" Visible="False" />
                &nbsp;&nbsp;
                <asp:Button ID="Button_HorasLibres" runat="server" Height="38px" OnClick="Button_HorasLibres_Click" Text="Horas libres" Width="97px" Enabled="False" Visible="False" />
                <br />
                <br />
                <br />
                <br />
                <asp:Button ID="Button_NuevoMuestreo" runat="server" Font-Names="Microsoft Sans Serif" Height="38px" OnClick="Button_NuevoMuestreo_Click" Text="Nuevo Muestreo" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button_FinalizarMuestreo" runat="server" Font-Names="Microsoft Sans Serif" Height="38px" OnClick="Button_FinalizarMuestreo_Click" Text="Finalizar Muestreo" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button_Atras" runat="server" Font-Names="Microsoft Sans Serif" Height="38px" OnClick="Button_Atras_Click" Text="Atrás" Width="68px" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
