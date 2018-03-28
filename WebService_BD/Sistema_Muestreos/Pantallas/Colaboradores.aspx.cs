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
        public ListItem itemSeleccionado = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    ListBox_Colaboradores.Items.Clear();

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

        protected void Button_Eliminar_Click(object sender, EventArgs e)
        {
            //var text = (listBox1.SelectedItem as DataRowView)["columnName"].ToString();
            // string actividadAEliminar = String.Join(", ",ListBox_Actividades.Items.Cast<ListItem>().Where(i=>i.Selected).Select(i => i.Value).ToString());
            int aux = 0;

            if (itemSeleccionado == null)
            {
                MessageBox("Seleccione un colaborador para poder eliminarlo.");
            }
            else
            {
                ServicioRef_WebService_BD.WS_Base_DatosSoapClient WS = new ServicioRef_WebService_BD.WS_Base_DatosSoapClient();
                DataSet ds = WS.EliminarColaborador(itemSeleccionado.Value.ToString());

                if (!ds.Tables[0].Rows[0].Equals("error"))
                {
                    MessageBox("Se ha eliminado al colaborador correctamente.");
                    Response.Redirect(Request.Url.AbsoluteUri); // Refrescar la pagina actual
                }
                else
                {
                    MessageBox("Error al eliminar");
                }
            }
        }

        protected void Button_Salir_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainAdministrador.aspx");
        }

        protected void ListBox_Colaboradores_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListItem item in ListBox_Colaboradores.Items)
            {
                if (item.Selected == true)
                {
                    itemSeleccionado = new ListItem();
                    itemSeleccionado.Text = item.Text;
                    itemSeleccionado.Value = item.Value;
                }
            }
        }

    }
}