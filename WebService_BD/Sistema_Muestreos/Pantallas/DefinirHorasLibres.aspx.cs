using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Muestreos.Pantallas
{
    public partial class DefinirHorasLibres : System.Web.UI.Page
    {
        public ListItem itemSeleccionado = null;
        string[] valores;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    ActualizarLista();
                }
                catch
                {
                    MessageBox("No sirve lista");
                }
            }
        }

        private void MessageBox(string msg)
        {
            Page.Controls.Add(new LiteralControl(
             "<script language='javascript'> window.alert('" + msg.Replace("'", "\\'") + "')</script>"));
        }

        private void ActualizarLista()
        {
            ListBox_HorasLibresDefinidas.Items.Clear();
            ServicioRef_WebService_BD.WS_Base_DatosSoapClient asd = new ServicioRef_WebService_BD.WS_Base_DatosSoapClient();
            DataSet ds = new DataSet();
            ds = asd.BuscarHorasNoLaborables();
            DataTable tablaHorasNoLaborales = ds.Tables[0];
            foreach (DataRow row in tablaHorasNoLaborales.Rows)
            {
                ListItem item = new ListItem();
                item.Value = row["HoraInicio"].ToString() + " -> " + row["HoraFinal"].ToString();
                item.Text = row["HoraInicio"].ToString() + " -> " + row["HoraFinal"].ToString();
                ListBox_HorasLibresDefinidas.Items.Add(item);
            }
        }

        protected void Button_Atras_Click(object sender, EventArgs e)
        {
            Response.Redirect("Muestreo.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e) // Borrar
        {
            if (itemSeleccionado == null)
            {
                MessageBox("Seleccione una hora para poder eliminarla.");
            }
            else
            {
                ServicioRef_WebService_BD.WS_Base_DatosSoapClient WS = new ServicioRef_WebService_BD.WS_Base_DatosSoapClient();
                valores = itemSeleccionado.Value.Split(new[] { " -> " }, StringSplitOptions.None);
                DataSet ds = WS.BuscarIdHoraNoLaboral(valores[0], valores[1]);
                DataSet ds_2 = WS.BorrarHorasNoLaborables(Int32.Parse(ds.Tables[0].Rows[0][0].ToString()));
                ActualizarLista();

                MessageBox("Se ha borrado la hora correctamente!.");
            }
        }

        protected void ListBox_HorasLibresDefinidas_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListItem item in ListBox_HorasLibresDefinidas.Items)
            {
                if (item.Selected == true)
                {
                    itemSeleccionado = new ListItem();
                    itemSeleccionado.Text = item.Text;
                    itemSeleccionado.Value = item.Value;
                }
            }
        }

        protected void Button_AgregarHoraLibre_Click(object sender, EventArgs e)
        {
            if ((TextBox_HoraInicial.Text == "" || TextBox_HoraFinal.Text == ""))
            {
                MessageBox("Complete las casillas de Hora Inicial y Hora Final para poder agregar la hora");
            }
            else
            {
                ServicioRef_WebService_BD.WS_Base_DatosSoapClient asd = new ServicioRef_WebService_BD.WS_Base_DatosSoapClient();
                DataSet ds = new DataSet();
                ds = asd.BuscarUltimoMuestreo();
                DataSet ds_2 = new DataSet();
                ds_2 = asd.AniadirHoraNoLaboral(Int32.Parse(ds.Tables[0].Rows[0][0].ToString()), TextBox_HoraInicial.Text, TextBox_HoraFinal.Text);
                ActualizarLista();

                MessageBox("Se ha añadido la hora correctamente!.");
            }
        }
    }
}