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
        public ListItem itemSeleccionado = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    ListBox_Actividades.Items.Clear();
                    ServicioRef_WebService_BD.WS_Base_DatosSoapClient asd = new ServicioRef_WebService_BD.WS_Base_DatosSoapClient();
                    DataSet ds = new DataSet();
                    ds = asd.ObtenerActividades();
                    DataTable tablaActividades = ds.Tables[0];
                    ListBox_Actividades.DataMember = ds.Tables[0].Columns[0].ColumnName;
                    ListBox_Actividades.DataValueField = ds.Tables[0].Columns[0].ColumnName;
                    ListBox_Actividades.DataSource = ds.Tables[0];
                    ListBox_Actividades.DataBind();
                }
                catch
                {
                    MessageBox("Error");
                }
            }
        }

        private void MessageBox(string msg)
        {
            Page.Controls.Add(new LiteralControl(
             "<script language='javascript'> window.alert('" + msg.Replace("'", "\\'") + "')</script>"));
        }

        protected void Button_Eliminar_Click(object sender, EventArgs e)
        {
            //var text = (listBox1.SelectedItem as DataRowView)["columnName"].ToString();
            // string actividadAEliminar = String.Join(", ",ListBox_Actividades.Items.Cast<ListItem>().Where(i=>i.Selected).Select(i => i.Value).ToString());
            int aux = 0;

            if (itemSeleccionado == null)
            {
                MessageBox("Seleccione una actividad para poder eliminarla.");
            }
            else
            {
                ServicioRef_WebService_BD.WS_Base_DatosSoapClient WS = new ServicioRef_WebService_BD.WS_Base_DatosSoapClient();
                DataSet ds = WS.EliminarActividad(itemSeleccionado.Value.ToString());

                if (!ds.Tables[0].Rows[0].Equals("error"))
                {
                    MessageBox("Se ha eliminado la actividad correctamente.");
                    Response.Redirect(Request.Url.AbsoluteUri); // Refrescar la pagina actual
                }
            }
        }

        protected void ListBox_Actividades_SelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (ListItem item in ListBox_Actividades.Items)
            {
                if (item.Selected == true)
                {
                    itemSeleccionado = new ListItem();
                    itemSeleccionado.Text = item.Text;
                    itemSeleccionado.Value = item.Value;
                }
            }

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