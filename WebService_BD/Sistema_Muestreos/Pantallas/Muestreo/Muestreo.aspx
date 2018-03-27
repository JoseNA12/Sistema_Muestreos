<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Muestreo.aspx.cs" Inherits="Sistema_Muestreos.NuevoMuestreo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 572px; height: 273px">
            <asp:Panel ID="Panel1" runat="server" BackColor="#0099FF" Font-Size="XX-Large" Height="268px" Width="575px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Muestreo<br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server" Font-Size="Medium" Text="Lapso de tiempo dentre cada muestreo preliminar"></asp:Label>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="ListaLapsoTiempo" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    <asp:ListItem>5 minutos</asp:ListItem>
                    <asp:ListItem>10 minutos</asp:ListItem>
                    <asp:ListItem>15 minutos</asp:ListItem>
                    <asp:ListItem>20 minutos</asp:ListItem>
                    <asp:ListItem>30 minutos</asp:ListItem>
                    <asp:ListItem>40 minutos</asp:ListItem>
                    <asp:ListItem>50 minutos</asp:ListItem>
                    <asp:ListItem Value="60 minutos"></asp:ListItem>
                    <asp:ListItem>Aleatorio</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BtnNuevoMuestreo" runat="server" OnClick="Button1_Click" Text="Nuevo Muestreo" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BtnFinalizarMuestreo" runat="server" Text="Finalizar Muestreo" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BtnAtras" runat="server" Text="Atrás" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
