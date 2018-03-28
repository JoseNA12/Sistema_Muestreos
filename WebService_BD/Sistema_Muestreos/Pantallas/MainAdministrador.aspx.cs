using System;
using System.Collections.Generic;
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

        }

        protected void Button_CrearRevision_Click(object sender, EventArgs e)
        {
            //Response.Redirect(".aspx");
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
    }
}