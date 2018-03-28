using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Muestreos
{
    public partial class Colaboradores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ServicioRef_WebService_BD.WS_Base_DatosSoapClient WS = new ServicioRef_WebService_BD.WS_Base_DatosSoapClient();
                DataSet ds = WS.BuscarColaboradores();
                DataTable tablaColaboradores = ds.Tables[0];
                foreach (DataRow row in tablaColaboradores.Rows)
                {
                    ListBox_Colaboradores.Items.Add(row["Nombre"].ToString());
                }
            }
            catch
            {
                MessageBox("Hubo un error cargando los colaboradores!.");
            }
        }

        private void MessageBox(string msg)
        {
            Page.Controls.Add(new LiteralControl(
             "<script language='javascript'> window.alert('" + msg.Replace("'", "\\'") + "')</script>"));
        }

    

    protected void Button_Agregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarColaborador.aspx");
        }

        protected void Button_Salir_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainAdministrador.aspx");
        }

        protected void ListBox_Colaboradores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}