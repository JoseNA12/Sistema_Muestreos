using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Muestreos
{
    public partial class NuevoMuestreo : System.Web.UI.Page
    {

        public static DataRow muestreoActual;
        public static List<DateTime> horasMuestreo = new List<DateTime>();

        protected void Page_Load(object sender, EventArgs e)
        {
            VerificarMuestreoTerminado();

            if (Button_NuevoMuestreo.Enabled)
            {
                Button_FinalizarMuestreo.Enabled = false;
            }
        }


        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button_FinalizarMuestreo_Click(object sender, EventArgs e)
        {
            ServicioRef_WebService_BD.WS_Base_DatosSoapClient WS = new ServicioRef_WebService_BD.WS_Base_DatosSoapClient();
            DataSet ds = WS.FinalizarMuestreo(WS.BuscarUltimoMuestreo().Tables[0].Rows[0][0].ToString(),
                DateTime.Now.ToString("yyyy-MM-dd") + " " + DateTime.Now.ToLongTimeString());

            MessageBox("El muestreo ha sido finalizado!.");
            VerificarMuestreoTerminado();

            WS.EliminarMuestreoPreliminar(WS.BuscarUltimoMuestreoPreliminar().Tables[0].Rows[0][0].ToString());

            Response.Redirect(Request.Url.AbsoluteUri); // Refrescar la pagina actual
        }

        protected void Button_NuevoMuestreo_Click(object sender, EventArgs e)
        {
            int temp;
            
            if (CheckBox1_LapsoAleatorio.Checked)
            {
                if (!TextBox_LapsoExtra.Text.Equals("") && int.TryParse(TextBox_LapsoExtra.Text, out temp) || TextBox_LapsoExtra.Text.Equals(""))
                    Response.Redirect("NuevoMuestreo.aspx?" +
                                "TiempoExtra=" + TextBox_LapsoExtra.Text + "&" +
                                "TiempoAleatorio=True");
                else
                {
                    MessageBox("Formato inválido del lapso de tiempo.");
                }
            }
            else
            {
                if (!TextBox_RangoInicial.Text.Equals("") && !TextBox_RangoFinal.Text.Equals("") &&
                    int.TryParse(TextBox_RangoInicial.Text, out temp) && int.TryParse(TextBox_RangoFinal.Text, out temp))
                {
                    string tiempoExtra = TextBox_LapsoExtra.Text;

                    if ((!TextBox_LapsoExtra.Text.Equals("") && int.TryParse(TextBox_LapsoExtra.Text, out temp))
                        || TextBox_LapsoExtra.Text.Equals(""))
                    {
                        Response.Redirect("NuevoMuestreo.aspx?" +
                                "RangoInicial=" + TextBox_RangoInicial.Text + "&" +
                                "RangoFinal=" + TextBox_RangoFinal.Text + "&" +
                                "TiempoExtra=" + TextBox_LapsoExtra.Text + "&" +
                                "TiempoAleatorio=False");
                    }
                    else
                    {
                        MessageBox("Formato inválido en los rangos de tiempo.");
                    }
                }
                else
                {
                    MessageBox("Indique el lapso de tiempo que se desea manejar o verifique que los rangos ingresados sean numeros enteros.");
                }
            }
        }

        protected void Button_Atras_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainAdministrador.aspx");
        }

        protected void Button_ActualizarLapso_Click(object sender, EventArgs e)
        {

        }

        private void VerificarMuestreoTerminado()
        {
            ServicioRef_WebService_BD.WS_Base_DatosSoapClient WS = new ServicioRef_WebService_BD.WS_Base_DatosSoapClient();
            DataSet ds = WS.BuscarUltimoMuestreo();// = WS.CrearMuestreoPreliminar(NuevoMuestreo.muestreoActual[1].ToString(), DateTime.Now.ToString("yyyy-MM-dd") + " " + DateTime.Now.ToLongTimeString(), TextBox_Temperatura.Text, TextBox_Humedad.Text);

            try
            {
                if (ds.Tables[0].Rows[0][5].Equals(2)) // Muestreo en proceso
                {
                    Button_NuevoMuestreo.Enabled = false;
                }
                else
                {
                    Button_NuevoMuestreo.Enabled = true;
                }
            }
            catch
            {
                // no existen muestreos
            }
            
        }

        private void MessageBox(string msg)
        {
            Page.Controls.Add(new LiteralControl(
             "<script language='javascript'> window.alert('" + msg.Replace("'", "\\'") + "')</script>"));
        }

        protected void Button_HorasLibres_Click(object sender, EventArgs e)
        {
            Response.Redirect("DefinirHorasLibres.aspx");
        }
    }
}