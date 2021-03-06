﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Muestreos
{
    public partial class CrearActividad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void MessageBox(string msg)
        {
            Page.Controls.Add(new LiteralControl(
             "<script language='javascript'> window.alert('" + msg + "')</script>"));
        }

        protected void Button_Crear_Click(object sender, EventArgs e)
        {
            if (!TextBox_NombreActividad.Text.Equals(""))
            {
                try
                {
                    ServicioRef_WebService_BD.WS_Base_DatosSoapClient WS = new ServicioRef_WebService_BD.WS_Base_DatosSoapClient();
                    DataSet ds = WS.CrearActividad(TextBox_NombreActividad.Text, Int32.Parse(DropDownList_TipoActividad.SelectedItem.Value), TextBox_DescripcionActividad.Text);

                    if (!ds.Tables[0].Rows[0].ToString().Equals("error"))
                    {
                        MessageBox_2("Se ha creado la Actividad correctamente", "Actividades.aspx");
                    }
                    else
                    {
                        MessageBox("Error al crear la actividad");
                    }

                }
                catch
                {
                    MessageBox("Error");
                }
            }
            else
            {
                MessageBox("Ingrese un nombre para la actividad.");
            }
        }

        protected void Button_Salir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Actividades.aspx");
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