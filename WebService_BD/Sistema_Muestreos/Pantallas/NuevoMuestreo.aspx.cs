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
        Random ran = new Random();
        protected void Page_Load(object sender, EventArgs e)
        {
           // MessageBox(Request.Params["RangoInicial"].ToString());
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
                    rangoInicial = ran.Next(2,30);
                    rangoFinal = ran.Next(35,60);
                    

                }
                else
                {
                    // Rango de tiempo NO aleatorio
                    rangoInicial = Int32.Parse(Request.Params["RangoInicial"]);
                    rangoFinal = Int32.Parse(Request.Params["RangoFinal"]);
                    //MessageBox(Request.Params["RangoInicial"]);
                    if (!Request.Params["TiempoExtra"].ToString().Equals("")) // No es vacio
                    {
                        tiempoExtra = Int32.Parse(Request.Params["TiempoExtra"].ToString());
                    }
                    tiempoAleatorio = false;
                    /*rangoInicial = Int32.Parse(Request.Params["RangoInicial"].ToString());
                    rangoFinal = Int32.Parse(Request.Params["RangoFinal"].ToString());
                    tiempoExtra = Int32.Parse(Request.Params["TiempoExtra"].ToString());*/
                }
            }    
        }

        protected void Button_CrearMuestreo_Click(object sender, EventArgs e)
        {
            if (!TextBox_NombreNuevoMuestreo.Text.Equals("") && !TextBox_DescripcionNuevoMuestreo.Text.Equals(""))
            {
                ServicioRef_WebService_BD.WS_Base_DatosSoapClient WS = new ServicioRef_WebService_BD.WS_Base_DatosSoapClient();
                DataSet ds = WS.ModificarMuestreo(Int32.Parse(WS.BuscarUltimoMuestreo().Tables[0].Rows[0][0].ToString()), TextBox_NombreNuevoMuestreo.Text,
                    DateTime.Now.ToString("yyyy-MM-dd") + " " + DateTime.Now.ToLongTimeString(), // DateTime.Now.ToString(),
                    rangoInicial, rangoFinal,"", 2, TextBox_DescripcionNuevoMuestreo.Text, IniciarSesion.usuarioActual[0].ToString(),
                    1); 

                //CREAR MUESTREO PRELIMINAR VACIO
                WS.CrearMuestreoPreliminar(WS.BuscarUltimoMuestreo().Tables[0].Rows[0][0].ToString(), "", "", "");

                string horaRandomFinal = ""; //DateTime.Now.ToString("yyyy-MM-dd") + " ";

                Random rdn = new Random();
                int miValor = rdn.Next(rangoInicial, rangoFinal + tiempoExtra + 1);
                DateTime horaRandom = DateTime.Now.AddMinutes(miValor);

                DataSet dsHL = WS.BuscarHorasNoLaborables();

                foreach (DataRow row in dsHL.Tables[0].Rows)
                {
                    DateTime horaInicio = Convert.ToDateTime(row[2].ToString());
                    DateTime horaFinal = Convert.ToDateTime(row[3].ToString());

                    if (horaRandom >= horaInicio && horaRandom <= horaFinal)
                    {
                        //ESTA DENTRO DE LAS HORAS DE DESCANSO
                        horaRandom = horaFinal.AddMinutes(miValor + 5);
                    }

                }

                horaRandomFinal = horaRandom.ToString("yyyy-MM-dd H:mm:ss");//horaRandom.ToLongTimeString(); //()

                WS.ModificarMuestreoPreliminarHoras(WS.BuscarUltimoMuestreoPreliminar().Tables[0].Rows[0][0].ToString(), horaRandomFinal);

                MessageBox_2("El muestreo se ha creado correctamente!. El primer muestreo preliminar se habilitará a las: " + horaRandomFinal,
                    "MainAdministrador.aspx");       
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

        private void MessageBox_2(string pMensaje, string pURL)
        {
            string message = pMensaje;
            string url = pURL;
            string script = "window.onload = function(){ alert('";
            script += message += "');window.location = '" + url + "'; }";

            ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
        }
    }
}