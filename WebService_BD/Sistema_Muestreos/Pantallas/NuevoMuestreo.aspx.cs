using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Muestreos
{
    public partial class WebForm1 : System.Web.UI.Page // NuevoMuestreo
    {

        int rangoInicial = 0;
        int rangoFinal = 0;
        int tiempoExtra = 0;
        bool tiempoAleatorio = false; 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Params["TiempoAleatorio"] != null)
                {
                    // Rango de tiempo aleatorio
                    if (Request.Params["TiempoAleatorio"].ToString().Equals("True"))
                    {
                        if (!Request.Params["TiempoExtra"].ToString().Equals("")) // No es vacio
                        {
                            tiempoExtra = Int32.Parse(Request.Params["TiempoExtra"].ToString());
                        }
                        tiempoAleatorio = true;
                    }
                    else
                    {
                        // Rango de tiempo NO aleatorio
                        rangoInicial = Int32.Parse(Request.Params["RangoInicial"].ToString());
                        rangoFinal = Int32.Parse(Request.Params["RangoFinal"].ToString());

                        if (!Request.Params["TiempoExtra"].ToString().Equals("")) // No es vacio
                        {
                            tiempoExtra = Int32.Parse(Request.Params["TiempoExtra"].ToString());
                        }
                        
                        tiempoAleatorio = false;
                    }
                }

            }
        }
        protected void Button_CrearMuestreo_Click(object sender, EventArgs e)
        {
            if (!TextBox_NombreNuevoMuestreo.Text.Equals("") && !TextBox_DescripcionNuevoMuestreo.Text.Equals(""))
            {
                MessageBox(rangoInicial.ToString() + " - " + rangoFinal.ToString() + " - " + 
                    tiempoExtra.ToString() + " - " + tiempoAleatorio.ToString() + " - " + 
                    TextBox_NombreNuevoMuestreo.Text + " - " + TextBox_DescripcionNuevoMuestreo.Text);
            }
        }

        protected void Button_CancelarNuevoMuestreo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Muestreo.aspx");
        }

        private void MessageBox(string msg)
        {
            Page.Controls.Add(new LiteralControl(
             "<script language='javascript'> window.alert('" + msg.Replace("'", "\\'") + "')</script>"));
        }
    }
}