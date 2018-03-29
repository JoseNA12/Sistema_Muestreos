using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
                string contraseñaTemporal = generarContraseniaTemporal();
                DataSet ds = WS.RegistrarNuevoUsuario(TextBox_Nombre.Text, TextBox_Apellidos.Text, TextBox_CorreoElectronico.Text, TextBox_NombreUsuario.Text, contraseñaTemporal, tipoUsuario);

                DataTable firsttable = ds.Tables[0];
                DataRow row = firsttable.Rows[0];


                if (!row[0].ToString().Equals("error"))
                {
                    string correoResultado = EnviarCorreo(TextBox_CorreoElectronico.Text, contraseñaTemporal);
                    if (correoResultado.Equals("exito"))
                    {
                        MessageBox("Se ha registrado con éxito el usuario!. Por favor, verifique la bandeja del correo electronico " + TextBox_CorreoElectronico.Text + " para obtener la contraseña asociada a la cuenta.");

                    }
                    else
                    {
                        MessageBox("Error al enviar el correo electrónico.");

                    }
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

        private string EnviarCorreo(string correo, string contraseña)
        {
            MailMessage email = new MailMessage();
            email.To.Add(new MailAddress(correo));
            email.From = new MailAddress("sistemamuestreo@gmail.com");
            email.Subject = "Registro en el Sistema de Muestreos ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
            email.Body = "Recuerde cambiar la contraseña después de ingresar. La contraseña generada es: " + contraseña;
            email.IsBodyHtml = false;
            email.Priority = MailPriority.Normal;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("sistemamuestreo@gmail.com", "proyectotec123");

            string output = null;

            try
            {
                smtp.Send(email);
                email.Dispose();
                output = "exito";
            }
            catch (Exception ex)
            {
                output = "error";
            }
            Console.WriteLine(output);
            return output;
        }


        private string generarContraseniaTemporal()
        {
            Random rnd = new Random();
            int numero;
            string contraseñaGenerada = "";
            while (contraseñaGenerada.Length < 5)
            {
                numero = rnd.Next(0, 9);
                contraseñaGenerada += numero.ToString();
            }
            return contraseñaGenerada;
        }
    }
}