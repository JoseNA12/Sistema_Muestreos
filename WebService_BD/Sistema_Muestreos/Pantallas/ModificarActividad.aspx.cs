using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Muestreos
{
    public partial class ModificarActividad : System.Web.UI.Page
    {
        public string ActividadAModificar;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Params["parametro"] != null)
                {
                    ActividadAModificar = Request.Params["parametro"].ToString();
                    TextBox_NombreActividad.Text = ActividadAModificar;
                }
                try
                {
                    ServicioRef_WebService_BD.WS_Base_DatosSoapClient asd = new ServicioRef_WebService_BD.WS_Base_DatosSoapClient();
                    DataSet ds = new DataSet();
                    ds = asd.ObtenerActividad(ActividadAModificar);
                    DataRow row = ds.Tables[0].Rows[0];
                    TextBox_Descripcion.Text = row["Observacion"].ToString();

                    foreach (ListItem item in DropDownList_TipoActividad.Items)
                    {
                        if (row["IdTipoActividad"].ToString().Equals(item.Value))
                        {
                            DropDownList_TipoActividad.SelectedValue = item.Value;
                            break;
                        }
                    }

                }
                catch
                {
                    MessageBox("Error");
                }
            }

        }

        protected void Button_Modificar_Click(object sender, EventArgs e)
        {
            ServicioRef_WebService_BD.WS_Base_DatosSoapClient asd = new ServicioRef_WebService_BD.WS_Base_DatosSoapClient();
            DataSet ds = new DataSet();
            string nombre = TextBox_NombreActividad.Text;
            string descripcion = TextBox_Descripcion.Text;
            ds = asd.ModificarActividad(Request.Params["parametro"], nombre, descripcion, Int32.Parse(DropDownList_TipoActividad.SelectedItem.Value));

            if (ds.Tables[0].Rows[0][0].ToString().Equals("exito"))
            {
                MessageBox("Se ha modificado la actividad correctamente!");
            }
            else
            {
                MessageBox("Error al modificar la actividad");
            }
        }

        protected void Button_Salir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Actividades.aspx");
        }

        private void MessageBox(string msg)
        {
            Page.Controls.Add(new LiteralControl(
             "<script language='javascript'> window.alert('" + msg.Replace("'", "\\'") + "')</script>"));
        }
    }
}