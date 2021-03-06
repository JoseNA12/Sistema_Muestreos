﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Muestreos
{
    public partial class Actividades : System.Web.UI.Page
    {
        public ListItem itemSeleccionado = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    ListBox_Actividades.Items.Clear();
                    ServicioRef_WebService_BD.WS_Base_DatosSoapClient asd = new ServicioRef_WebService_BD.WS_Base_DatosSoapClient();
                    DataSet ds = new DataSet();
                    ds = asd.ObtenerActividades();
                    DataTable tablaActividades = ds.Tables[0];
                    ListBox_Actividades.DataMember = ds.Tables[0].Columns[0].ColumnName;
                    ListBox_Actividades.DataValueField = ds.Tables[0].Columns[0].ColumnName;
                    ListBox_Actividades.DataSource = ds.Tables[0];
                    ListBox_Actividades.DataBind();
                }
                catch
                {
                    MessageBox("Error al cargar los datos.");
                }
            }
        }

        private void MessageBox(string msg)
        {
            Page.Controls.Add(new LiteralControl(
             "<script language='javascript'> window.alert('" + msg.Replace("'", "\\'") + "')</script>"));
        }

        protected void Button_Eliminar_Click(object sender, EventArgs e)
        {
            //var text = (listBox1.SelectedItem as DataRowView)["columnName"].ToString();
            // string actividadAEliminar = String.Join(", ",ListBox_Actividades.Items.Cast<ListItem>().Where(i=>i.Selected).Select(i => i.Value).ToString());

            if (itemSeleccionado == null)
            {
                MessageBox("Seleccione una actividad para poder eliminarla.");
            }
            else
            {
                ServicioRef_WebService_BD.WS_Base_DatosSoapClient WS = new ServicioRef_WebService_BD.WS_Base_DatosSoapClient();
                DataSet ds = WS.EliminarActividad(itemSeleccionado.Value.ToString());

                if (!ds.Tables[0].Rows[0].Equals("error"))
                {
                    MessageBox_2("Se ha eliminado la actividad correctamente.", "Actividades.aspx");
                }
                else
                {
                    MessageBox("Error al eliminar");
                }
            }
        }

        protected void ListBox_Actividades_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListItem item in ListBox_Actividades.Items)
            {
                if (item.Selected == true)
                {
                    itemSeleccionado = new ListItem();
                    itemSeleccionado.Text = item.Text;
                    itemSeleccionado.Value = item.Value;
                }
            }

        }

        protected void Button_Salir_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainAdministrador.aspx");
        }

        protected void Button_CrearActividad_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearActividad.aspx");
        }

        protected void Button_Modificar_Click(object sender, EventArgs e)
        {
            if (itemSeleccionado != null)
            {
                Response.Redirect("ModificarActividad.aspx?parametro=" + itemSeleccionado.Text);
            }
            else
            {
                MessageBox("Seleccione una actividad para poder modificarla.");
            }
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