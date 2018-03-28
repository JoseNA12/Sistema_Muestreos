using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Muestreos
{
    public partial class Actividades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ServicioRef_WebService_BD.WS_Base_DatosSoapClient asd = new ServicioRef_WebService_BD.WS_Base_DatosSoapClient();
                DataSet ds = new DataSet();
                ds = asd.ObtenerActividades();
                DataTable tablaActividades = ds.Tables[0];
                foreach (DataRow row in tablaActividades.Rows)
                {
                    ListBox_Actividades.Items.Add(row["Nombre"].ToString());
                }
            }
            catch
            {
                MessageBox("Error");
            }
        }

        private void MessageBox(string msg)
        {
            Page.Controls.Add(new LiteralControl(
             "<script language='javascript'> window.alert('" + msg.Replace("'", "\\'") + "')</script>"));
        }

        protected void Button_Eliminar_Click(object sender, EventArgs e)
        {
            ListBox_Actividades.Dispose();
        }

        protected void Button_Salir_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainAdministrador.aspx");
        }

        protected void Button_CrearActividad_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearActividad.aspx");
        }
    }
}