using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Muestreos
{
    public partial class IniciarSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ServicioRef_WebService_BD.WS_Base_DatosSoapClient WS = new ServicioRef_WebService_BD.WS_Base_DatosSoapClient();
            //DataSet ds = WS.GetData(); // Llamamos al metodo GetData() que lo tiene el web service

            //TextBox_NombreUsuario.Text = ds.Tables[0].TableName; // Obtener el nombre de la tabla como prueba
        }

        protected void button_Ingresar_Click(object sender, EventArgs e)
        {
            if (!TextBox_NombreUsuario.Text.Equals(""))
            {

                if (!TextBox_Contrasenia.Text.Equals(""))
                {
                    ServicioRef_WebService_BD.WS_Base_DatosSoapClient WS = new ServicioRef_WebService_BD.WS_Base_DatosSoapClient();

                    string[] arr1 = new string[] { TextBox_NombreUsuario.Text, TextBox_Contrasenia.Text };
                    List<string> list = new List<string>();
                    list.Add(TextBox_NombreUsuario.Text);
                    list.Add(TextBox_Contrasenia.Text);


                    string a = "a";
                    DataSet ds = WS.VerificarCredenciales();

                    MessageBox(ds.Tables[0].ToString());
                    //Response.Redirect("EmployeeHome.aspx");
                }
                else
                {
                    MessageBox("Por favor, ingrese la contraseña.");
                }
            }
            else
            {
                MessageBox("Por favor, ingrese el nombre de usuario.");
            }
        }

        private void MessageBox(string msg)
        {
            Page.Controls.Add(new LiteralControl(
             "<script language='javascript'> window.alert('" + msg.Replace("'", "\\'") + "')</script>"));
        }
    }
}