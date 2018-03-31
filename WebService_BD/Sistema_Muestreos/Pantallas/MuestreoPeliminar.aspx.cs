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

        protected void Button_CrearMP_Click(object sender, EventArgs e)
        {
            if (!TextBox_Humedad.Text.Equals(""))
            {
                if (!TextBox_Temperatura.Text.Equals(""))
                {
                    ServicioRef_WebService_BD.WS_Base_DatosSoapClient WS = new ServicioRef_WebService_BD.WS_Base_DatosSoapClient();

                    DataSet ds = WS.CrearMuestreoPreliminar(NuevoMuestreo.muestreoActual[1].ToString(), DateTime.Now.ToString("yyyy-MM-dd") + " " + DateTime.Now.ToLongTimeString(),TextBox_Temperatura.Text, TextBox_Humedad.Text);

                    DataTable firsttable = ds.Tables[0];
                    DataRow row = firsttable.Rows[0];

                    if (row[0].ToString().Equals("exito"))
                    {                    
                        Response.Redirect("MuestreoPreliminar2.aspx");                  
                    }
                    else
                    {
                        MessageBox("Los datos ingresados no son válidos");
                    }
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
    }
}