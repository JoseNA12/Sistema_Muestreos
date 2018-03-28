using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Muestreos
{
    public partial class CrearUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_CrearUsuario_Click(object sender, EventArgs e)
        {
            if (!TextBox_Nombre.Text.Equals("") && !TextBox_Apellidos.Text.Equals("") && !TextBox_CorreoElectronico.Text.Equals("") && !TextBox_NombreUsuario.Text.Equals(""))
            {
                ServicioRef_WebService_BD.WS_Base_DatosSoapClient WS = new ServicioRef_WebService_BD.WS_Base_DatosSoapClient();

                int tipoUsuario = Convert.ToInt32(DropDownList_TipoUsuario.SelectedValue);

                DataSet ds = WS.RegistrarNuevoUsuario(TextBox_Nombre.Text, TextBox_Apellidos.Text, TextBox_CorreoElectronico.Text, TextBox_NombreUsuario.Text, tipoUsuario);

                DataTable firsttable = ds.Tables[0];
                DataRow row = firsttable.Rows[0];


                if (!row[0].ToString().Equals("error"))
                {
                    
                    MessageBox("Se ha registrado con éxito el usuario!. Por favor, verifique la bandeja del correo electronico " + TextBox_CorreoElectronico.Text + " para obtener la contraseña asociada a la cuenta.");
                }
                else
                {
                    MessageBox("Error, el usuario o correo electrónico ya se ha registrado en el sistema. Por favor, ingrese nuevamente los datos.");
                }
            }
            else
            {
                MessageBox("Por favor, rellene todos los campos.");
            }
        }

        private void MessageBox(string msg)
        {
            Page.Controls.Add(new LiteralControl(
             "<script language='javascript'> window.alert('" + msg.Replace("'", "\\'") + "')</script>"));
        }
    }
}