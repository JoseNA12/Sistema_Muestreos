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
            if (!TextBox_LapsePersonalizado.Text.Equals(""))
            {
                try
                {
                    int minutos = Int32.Parse(TextBox_LapsePersonalizado.Text);

                    DateTime horaActual = DateTime.Now;
                    DateTime horaMasLapso = horaActual.AddMinutes(minutos);

                    //DateTime.Now.ToLongTimeString() + TextBox_LapsePersonalizado.Text;

                }
                catch
                {
                    MessageBox("Formato inválido del lapso de tiempo.");
                }
                
            }
            else
            {
                if (CheckBox1_LapsoAleatorio.Checked)
                {

                }
                else
                {
                    MessageBox("Indique el lapso de tiempo que se desea manejar.");
                }
            }
            
            //Response.Redirect("NuevoMuestreo.aspx");
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