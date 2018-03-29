using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Muestreos
{
    public partial class WebForm1 : System.Web.UI.Page // NuevoMuestreo
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_CrearMuestreo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Muestreo.aspx");
        }

        protected void Button_CancelarNuevoMuestreo_Click(object sender, EventArgs e)
        {

        }
    }
}