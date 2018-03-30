using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Muestreos
{
    public partial class MainAdministrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IniciarSesion.usuarioActual[2].ToString().Equals("2"))
            {
                Button_Actividades.Visible = false;
                Button_AgregarUsuario.Visible = false;
                Button_Colaboradores.Visible = false;
                Button_Muestreo.Visible = false;
            }

            try
            {
                ServicioRef_WebService_BD.WS_Base_DatosSoapClient WS = new ServicioRef_WebService_BD.WS_Base_DatosSoapClient();

                DataSet ds = WS.BuscarUltimoMuestreo();

                if (Int32.Parse(ds.Tables[0].Rows[0][5].ToString()) == 1)
                {
                    Button_CrearRevision.Enabled = false;
                }
                else
                {
                    Button_CrearRevision.Enabled = true;
                }
            }
            catch
            {
                Button_CrearRevision.Enabled = false; // no hay muestreos
            }
        }

        private void MessageBox(string msg)
        {
            Page.Controls.Add(new LiteralControl(
             "<script language='javascript'> window.alert('" + msg.Replace("'", "\\'") + "')</script>"));
        }

        protected void Button_AgregarUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearUsuario.aspx");
        }

        protected void Button_Muestreo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Muestreo.aspx");
        }

        protected void Button_CrearRevision_Click(object sender, EventArgs e)
        {
            ServicioRef_WebService_BD.WS_Base_DatosSoapClient WS = new ServicioRef_WebService_BD.WS_Base_DatosSoapClient();
            DataSet ds_2 = WS.BuscarUltimoMuestreoPreliminar();
            DateTime fechaMP = Convert.ToDateTime(ds_2.Tables[0].Rows[0][2].ToString());  // 7:30
            DateTime FechActual = DateTime.Now; // 7:15

            if (fechaMP <= FechActual)   // 7:15 menor 7:30
            {
                Response.Redirect("MuestreoPreliminar.aspx");
            }
            else
            {
                MessageBox("El muestreo preliminar se habilitará a las " + fechaMP);
            }

            //Response.Redirect("MuestreoPreliminar.aspx");
        }

        protected void Button_Actividades_Click(object sender, EventArgs e)
        {
            Response.Redirect("Actividades.aspx");
        }

        protected void Button_Colaboradores_Click(object sender, EventArgs e)
        {
            Response.Redirect("Colaboradores.aspx");
        }

        protected void Button_Salir_Click(object sender, EventArgs e)
        {
            Response.Redirect("IniciarSesion.aspx");
        }

        protected void Button_CambiarContrasenia_Click(object sender, EventArgs e)
        {
            Response.Redirect("CambiarContraseña.aspx");
        }
    }
}