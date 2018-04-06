using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Sistema_Muestreos.Pantallas
{
    public partial class CambiarContraseña : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button_CambiarContraseña_Click(object sender, EventArgs e)
        {
            if (!TextBox_Contrasenia_1.Text.Equals("") && !TextBox_Contrasenia_2.Text.Equals("") && CheckBox_EstasSeguro.Checked)
            {
                if (TextBox_Contrasenia_1.Text.Equals(TextBox_Contrasenia_2.Text))
                {
                    ServicioRef_WebService_BD.WS_Base_DatosSoapClient WS = new ServicioRef_WebService_BD.WS_Base_DatosSoapClient();

                    DataSet ds = WS.ActualizarContrasenia(IniciarSesion.usuarioActual[0].ToString(), TextBox_Contrasenia_1.Text);
                    DataTable tablaResultado = ds.Tables[0];
                    DataRow row = tablaResultado.Rows[0];

                    if (row[0].ToString().Equals("exito"))
                    {
                        MessageBox_2("Contraseña cambiada satisfactoriamente", "MainAdministrador.aspx");
                    }
                    else
                    {
                        MessageBox("Error");
                    }
                }
                else
                {
                    MessageBox("Las contraseñas ingresadas no coinciden, intente nuevamente.");
                }
            }
            else
            {
                MessageBox("Por favor, rellene los campos y marque la casilla de confirmación.");
            }
        }

        private void MessageBox(string msg)
        {
            Page.Controls.Add(new LiteralControl(
             "<script language='javascript'> window.alert('" + msg.Replace("'", "\\'") + "')</script>"));
        }

        protected void Button_Atras_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainAdministrador.aspx");
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