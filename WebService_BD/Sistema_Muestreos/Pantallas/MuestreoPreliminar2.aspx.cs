using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Muestreos
{
    public partial class MuestreoPreliminar2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    DropDownList_Actividades.Items.Clear();
                    DropDownList_Colaboradores.Items.Clear();

                    //Colaboradores

                    ServicioRef_WebService_BD.WS_Base_DatosSoapClient WS = new ServicioRef_WebService_BD.WS_Base_DatosSoapClient();
                    DataSet ds_1 = WS.BuscarColaboradores();
                    DataTable tablaColaboradores = ds_1.Tables[0];

                    foreach (DataRow row in tablaColaboradores.Rows)
                    {
                        DropDownList_Colaboradores.Items.Add(row["Nombre"].ToString());
                    }

                    //Actividades

                    DataSet ds_2 = WS.ObtenerActividades();
                    DataTable tablaActividades = ds_2.Tables[0];

                    foreach (DataRow row in tablaActividades.Rows)
                    {
                        DropDownList_Actividades.Items.Add(row["Nombre"].ToString());
                    }
                }
                catch
                {
                    MessageBox("Hubo un error cargando la información, reintente nuevamente!.");
                }
            }
        }

        protected void Button_RegistrarActividad_Click(object sender, EventArgs e)
        {
            string colaboradorSeleccionado = DropDownList_Colaboradores.SelectedValue;
            string actividadSeleccionada = DropDownList_Actividades.SelectedValue;
            string descripcion = TextBox_Descripcion.Text;

            if (!BuscarColaborador(colaboradorSeleccionado))
            {
                ListItem item = new ListItem();
                item.Value = colaboradorSeleccionado;
                item.Text = colaboradorSeleccionado + " -> " + actividadSeleccionada;
                ListBox_Registro.Items.Add(item);

                ServicioRef_WebService_BD.WS_Base_DatosSoapClient WS = new ServicioRef_WebService_BD.WS_Base_DatosSoapClient();
                DataSet ds = WS.ObtenerMuestreoPreliminarId();
                DataTable tablaMuestroPreliminarId = ds.Tables[0];

                DataSet ds_2 = WS.ObtenerActividad(actividadSeleccionada);
                DataTable tablaActividad = ds_2.Tables[0];

                DataSet ds_1 = WS.RegistrarRevisionColaborador(Int32.Parse(tablaMuestroPreliminarId.Rows[0][0].ToString()),
                    colaboradorSeleccionado, Int32.Parse(tablaActividad.Rows[0][2].ToString()), IniciarSesion.usuarioActual[0].ToString(), descripcion);

                MessageBox("Se ha registrado la revisión para " + colaboradorSeleccionado);
            }
            else
            {
                MessageBox("Ya se ha registrado el colaborador.");
            }
        }


        private bool BuscarColaborador(string pNombre)
        {
            foreach (ListItem pItem in ListBox_Registro.Items)
            {
                if (pItem.Value.Equals(pNombre))
                {
                    return true;
                }
            }
            return false;
        }

        private void MessageBox(string msg)
        {
            Page.Controls.Add(new LiteralControl(
             "<script language='javascript'> window.alert('" + msg.Replace("'", "\\'") + "')</script>"));
        }

        protected void Button_Finalizar_Click(object sender, EventArgs e)
        {

            ServicioRef_WebService_BD.WS_Base_DatosSoapClient WS = new ServicioRef_WebService_BD.WS_Base_DatosSoapClient();
            DataSet ds = WS.BuscarUltimoMuestreo();

            Random rdn = new Random();
            int miValor = rdn.Next(Int32.Parse(ds.Tables[0].Rows[0][2].ToString()), Int32.Parse(ds.Tables[0].Rows[0][3].ToString()) + 1);

            WS.CrearMuestreoPreliminar(WS.BuscarUltimoMuestreo().Tables[0].Rows[0][0].ToString(),
                (DateTime.Now.ToString("yyyy-MM-dd") + " " + DateTime.Now.AddMinutes(miValor).ToLongTimeString()),
                "", "");

            MessageBox("Se ha finalizado correctamente el muestreo preliminar!.");

            Response.Redirect("MainAdministrador.aspx");
        }
    }
}