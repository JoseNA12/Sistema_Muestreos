using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Muestreos
{
    public partial class IniciarSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServicioRef_WebService_BD.WS_Base_DatosSoapClient WS = new ServicioRef_WebService_BD.WS_Base_DatosSoapClient();
            DataSet ds = WS.GetData(); // Llamamos al metodo GetData() que lo tiene el web service

            TextBox_NombreUsuario.Text = ds.Tables[0].TableName; // Obtener el nombre de la tabla como prueba
        }
    }
}