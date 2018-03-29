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

        }


        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button_FinalizarMuestreo_Click(object sender, EventArgs e)
        {

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