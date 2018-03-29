<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NuevoMuestreo.aspx.cs" Inherits="Sistema_Muestreos.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="margin: auto; background-image: url('Img/Background_2.jpg'); width: 540px; position:center; height: 410px;">
    <form id="form1" runat="server">
        <div style="width: 534px; height: 406px">
            <asp:Panel ID="Panel1" runat="server" Height="416px" Width="535px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                &nbsp;<br />
                <asp:Label ID="Label1" runat="server" Text="Nuevo Muestreo" Font-Size="X-Large" Font-Names="Microsoft Sans Serif" ForeColor="White"></asp:Label>
                <br />
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text="Ingrese el nombre del muestreo a crear" Font-Names="Microsoft Sans Serif"></asp:Label>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox_NombreNuevoMuestreo" runat="server" Font-Names="Microsoft Sans Serif" Width="165px"></asp:TextBox>
                <br />
                &nbsp;<br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label3" runat="server" Font-Names="Microsoft Sans Serif" Text="Ingrese una descripción del muestreo a crear"></asp:Label>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox_DescripcionNuevoMuestreo" runat="server" ClientIDMode="Predictable" Height="63px" Width="436px" TextMode="MultiLine" Font-Names="Microsoft Sans Serif"></asp:TextBox>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button_CrearMuestreo" runat="server" Text="Crear" Height="38px" Width="76px" OnClick="Button_CrearMuestreo_Click" Font-Names="Microsoft Sans Serif" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                <asp:Button ID="Button_CancelarNuevoMuestreo" runat="server" Text="Atras" Height="38px" OnClick="Button_CancelarNuevoMuestreo_Click" Font-Names="Microsoft Sans Serif" Width="54px" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
