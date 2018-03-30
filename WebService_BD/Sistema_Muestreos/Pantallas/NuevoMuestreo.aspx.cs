using System;
using System.Collections.Generic;
using System.Data;
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

            if (Request.Params["TiempoAleatorio"] != null)
            {
                //MessageBox("entro");

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

        protected void Button_CrearMuestreo_Click(object sender, EventArgs e)
        {
            if (!TextBox_NombreNuevoMuestreo.Text.Equals("") && !TextBox_DescripcionNuevoMuestreo.Text.Equals(""))
            {
                ServicioRef_WebService_BD.WS_Base_DatosSoapClient WS = new ServicioRef_WebService_BD.WS_Base_DatosSoapClient();

                DataSet ds = WS.CrearMuestreo(DateTime.Now.ToString("yyyy-MM-dd") + " " + DateTime.Now.ToLongTimeString(),
                    rangoInicial, rangoFinal, TextBox_DescripcionNuevoMuestreo.Text, IniciarSesion.usuarioActual[0].ToString(),
                    TextBox_NombreNuevoMuestreo.Text);

                //CREAR MUESTREO PRELIMINAR VACIO
                WS.CrearMuestreoPreliminar(WS.BuscarUltimoMuestreo().Tables[0].Rows[0][0].ToString(), "", "", "");


                /*string horaRandomFinal = DateTime.Now.ToString("yyyy-MM-dd") + " ";
                while (true)
                {
                    Random rdn = new Random();
                    int miValor = rdn.Next(rangoInicial, rangoFinal + tiempoExtra + 1);
                    DateTime horaRandom = DateTime.Now.AddMinutes(miValor);
                    bool sinbanderas = false;
                    DataSet dsHL = WS.BuscarHorasNoLaborables();

                    foreach (DataRow row in dsHL.Tables[0].Rows)
                    {

                        DateTime horaInicio = Convert.ToDateTime(row[1].ToString());
                        DateTime horaFinal = Convert.ToDateTime(row[2].ToString());
                        if (horaRandom >= horaInicio && horaRandom <= horaFinal)
                        {
                            //ESTA DENTRO DE LAS HORAS DE DESCANSO
                            sinbanderas = true;
                            break;
                        }

                    }
                    if (sinbanderas == false)
                    {
                        horaRandomFinal = horaRandom.ToString("yyyy-MM-dd") + " " + horaRandom.ToLongTimeString();
                        break;
                    }
                }
                MessageBox(horaRandomFinal);
                WS.ModificarMuestreoPreliminarHoras(WS.BuscarUltimoMuestreo().Tables[0].Rows[0][0].ToString(), horaRandomFinal);*/
                //MessageBox("El muestreo se ha creado correctamente!. El primer muestreo preliminar se habilitará a las: " + horaRandomFinal);
                Response.Redirect("DefinirHorasLibres.aspx");
            }
            /*if (!TextBox_NombreNuevoMuestreo.Text.Equals("") && !TextBox_DescripcionNuevoMuestreo.Text.Equals(""))
            {
                ServicioRef_WebService_BD.WS_Base_DatosSoapClient WS = new ServicioRef_WebService_BD.WS_Base_DatosSoapClient();

                DataSet ds = WS.CrearMuestreo(DateTime.Now.ToString("yyyy-MM-dd") + " " + DateTime.Now.ToLongTimeString(),
                    rangoInicial, rangoFinal, TextBox_DescripcionNuevoMuestreo.Text, IniciarSesion.usuarioActual[0].ToString(),
                    TextBox_NombreNuevoMuestreo.Text);

                Random rdn = new Random();
                int miValor = rdn.Next(rangoInicial, rangoFinal + tiempoExtra + 1);

                MessageBox(DateTime.Now.AddMinutes(miValor).ToLongTimeString());

                WS.CrearMuestreoPreliminar(WS.BuscarUltimoMuestreo().Tables[0].Rows[0][0].ToString(),
                    (DateTime.Now.ToString("yyyy-MM-dd") + " " + DateTime.Now.AddMinutes(miValor).ToLongTimeString()), 
                    "", "");

                MessageBox("El muestreo se ha creado correctamente!. El primer muestreo preliminar se habilitará a las: " + DateTime.Now.ToString("yyyy-MM-dd") + " " + DateTime.Now.AddMinutes(miValor).ToLongTimeString());
                Response.Redirect("MainAdministrador.aspx");
            }*/
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