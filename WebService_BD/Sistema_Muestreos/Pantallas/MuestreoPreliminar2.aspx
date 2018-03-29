<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MuestreoPreliminar2.aspx.cs" Inherits="Sistema_Muestreos.MuestreoPreliminar2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="margin: auto; background-image: url('Img/Background_2.jpg'); width: 586px; position:center; height: 519px;">
    <form id="form1" runat="server">
        <div style="height: 523px; width: 589px">
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Muestreo Preliminar" Font-Names="Microsoft Sans Serif" Font-Size="X-Large" ForeColor="White"></asp:Label>
            <br />
            <br />
            <asp:Panel ID="Panel1" runat="server" Height="420px" HorizontalAlign="Center" Width="582px">
                <asp:Label ID="Label2" runat="server" Text="Colaboradores" Font-Names="Microsoft Sans Serif"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label3" runat="server" Font-Names="Microsoft Sans Serif" Text="Actividades"></asp:Label>
                <br />
                <asp:DropDownList ID="DropDownList_Colaboradores" runat="server" Height="21px" Width="200px">
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="DropDownList_Actividades" runat="server" Height="21px" Width="200px">
                </asp:DropDownList>
                <br />
                <br />
                <asp:Label ID="Label4" runat="server" Font-Names="Microsoft Sans Serif" Text="Descripcion"></asp:Label>
                <br />
                <asp:TextBox ID="TextBox_Descripcion" runat="server" Width="289px" Height="48px" TextMode="MultiLine"></asp:TextBox>
                <br />
                <br />
                <asp:ListBox ID="ListBox_Registro" runat="server" Height="202px" Width="557px">
                </asp:ListBox>
                <br />
                <br />
                <asp:Button ID="Button_RegistrarActividad" runat="server" Height="38px" OnClick="Button_RegistrarActividad_Click" Text="Registrar revisión" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button_Finalizar" runat="server" Height="38px" OnClick="Button_Finalizar_Click" Text="Finalizar" Width="111px" />
            </asp:Panel>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
