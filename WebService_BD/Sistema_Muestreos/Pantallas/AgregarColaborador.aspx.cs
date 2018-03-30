using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Muestreos
{
    public partial class AgregarColaborador : System.Web.UI.Page
    {
        DataTable tablaPuestosActuales;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DropDownList_Puesto.Items.Clear();
                // Agregar puestos de trabajo al Drop List
                ServicioRef_WebService_BD.WS_Base_DatosSoapClient WS = new ServicioRef_WebService_BD.WS_Base_DatosSoapClient();
                DataSet ds = WS.BuscarPuestos();
                DataTable tablaPuestos = ds.Tables[0];
                tablaPuestosActuales = tablaPuestos;

                foreach (DataRow row in tablaPuestos.Rows)
                {
                    DropDownList_Puesto.Items.Add(row["Nombre"].ToString());
                }
            }
            catch
            {
                MessageBox("Error");
            }
        }

        protected void Button_Agregar_Click(object sender, EventArgs e)
        {
            if (!TextBox_Identificador.Text.Equals(""))
            {
                if (!TextBox_Salario.Text.Equals(""))
                {
                    ServicioRef_WebService_BD.WS_Base_DatosSoapClient WS = new ServicioRef_WebService_BD.WS_Base_DatosSoapClient();

                    int IdPuesto = ObtenerIdPuesto(DropDownList_Puesto.Text);

                    if (IdPuesto != -1)
                    {
                        DataSet ds = WS.InsertarColaborador(TextBox_Identificador.Text, TextBox_Salario.Text, IdPuesto);

                        DataTable tablaColaborador = ds.Tables[0];
                        DataRow row = tablaColaborador.Rows[0];

                        if (row[0].ToString().Equals("exito"))
                        {
                            MessageBox("Colaborador agregado satisfactoriamente");
                        }
                        else
                        {
                            MessageBox("Error, el colaborador ya existe!");
                        }
                    }
                    else
                    {
                        MessageBox("Error en la busqueda del puesto!"); // inesperado
                    }
                }
                else
                {
                    MessageBox("Por favor, ingrese el salario del colaborador");
                }
            }
            else
            {
                MessageBox("Por favor, ingrese el identificador del colaborador");
            }
        }

        protected void Button_Salir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Colaboradores.aspx");
        }

        private int ObtenerIdPuesto(string pNombrePuesto)
        {
            foreach (DataRow row in tablaPuestosActuales.Rows)
            {
                if (pNombrePuesto.Equals(row["Nombre"].ToString()))
                {
                    return Convert.ToInt32(row["IdPuesto"].ToString());
                }
            }
            return -1; // Error
        }

        private void MessageBox(string msg)
        {
            Page.Controls.Add(new LiteralControl(
             "<script language='javascript'> window.alert('" + msg.Replace("'", "\\'") + "')</script>"));
        }
    }
}