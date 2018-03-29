using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Muestreos
{
    public partial class MuestreoPeliminar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button_Crear_Click(object sender, EventArgs e)
        {

            if (!TextBox_Humedad.Text.Equals(""))
            {
                if (!TextBox_Temperatura.Text.Equals(""))
                {
                    ServicioRef_WebService_BD.WS_Base_DatosSoapClient WS = new ServicioRef_WebService_BD.WS_Base_DatosSoapClient();
                    DataSet ds_2 = WS.BuscarUltimoMuestreoPreliminar();
                    DataSet ds = WS.ModificarMuestreoPreliminar(ds_2.Tables[0].Rows[0][0].ToString(), TextBox_Temperatura.Text, TextBox_Humedad.Text);

                    Response.Redirect("MuestreoPreliminar2.aspx");
                }
                else
                {
                    MessageBox("Por favor, ingrese la temperatura.");
                }
            }
            else
            {
                MessageBox("Por favor, ingrese la humedad.");
            }
        }

        private void MessageBox(string msg)
        {
            Page.Controls.Add(new LiteralControl(
             "<script language='javascript'> window.alert('" + msg.Replace("'", "\\'") + "')</script>"));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainAdministrador.aspx");
        }
    }
}