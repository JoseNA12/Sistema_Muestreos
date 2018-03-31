using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Muestreos.Pantallas
{
    public partial class Puestos : System.Web.UI.Page
    {
        public ListItem itemSeleccionado = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    ListBox_Puestos.Items.Clear();

                    CargarPuestos();
                }
                catch
                {
                    MessageBox("Error al cargar los datos.");
                }
            }
        }

        protected void Button_Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                ServicioRef_WebService_BD.WS_Base_DatosSoapClient WS = new ServicioRef_WebService_BD.WS_Base_DatosSoapClient();
                DataSet ds = WS.CrearPuesto(TextBox_Puesto.Text);

                if (!ds.Tables[0].Rows[0].ToString().Equals("error"))
                {
                    MessageBox("Se ha creado el Puesto correctamente");
                    CargarPuestos();
                }
                else
                {
                    MessageBox("Error al crear el Puesto.");
                }

            }
            catch
            {
                MessageBox("Error inesperado.");
            }
        }

        protected void Button_Eliminar_Click(object sender, EventArgs e)
        {
            if (itemSeleccionado == null)
            {
                MessageBox("Seleccione un puesto para poder eliminarlo.");
            }
            else
            {
                
                ServicioRef_WebService_BD.WS_Base_DatosSoapClient WS = new ServicioRef_WebService_BD.WS_Base_DatosSoapClient();
                DataSet ds = WS.verificarPuesto(itemSeleccionado.Value.ToString());

                if (!ds.Tables[0].Rows[0][0].ToString().Equals("puesto en uso"))
                {
                   
                    ds = WS.EliminarPuesto(itemSeleccionado.Value.ToString());
                    if (!ds.Tables[0].Rows[0][0].Equals("error"))
                    {
                        MessageBox("Se ha eliminado el puesto correctamente.");
                        CargarPuestos();

                    }
                    else
                    {
                        MessageBox("Error al eliminar");
                    }
                }
                else
                {
                    MessageBox("El puesto seleccionado está en uso por los colaboradores.");
                }
                
                
            }
        }

        protected void Button_Atras_Click(object sender, EventArgs e)
        {
            Response.Redirect("Colaboradores.aspx");
        }

        private void MessageBox(string msg)
        {
            Page.Controls.Add(new LiteralControl(
             "<script language='javascript'> window.alert('" + msg.Replace("'", "\\'") + "')</script>"));
        }

        private void CargarPuestos()
        {
            ServicioRef_WebService_BD.WS_Base_DatosSoapClient asd = new ServicioRef_WebService_BD.WS_Base_DatosSoapClient();
            DataSet ds = asd.ObtenerPuesto();

            DataTable tablaPuestos = ds.Tables[0];
            ListBox_Puestos.DataMember = ds.Tables[0].Columns[1].ColumnName;
            ListBox_Puestos.DataValueField = ds.Tables[0].Columns[1].ColumnName;
            ListBox_Puestos.DataSource = ds.Tables[0];
            ListBox_Puestos.DataBind();
        }

        protected void ListBox_Puestos_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListItem item in ListBox_Puestos.Items)
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