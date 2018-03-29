using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Muestreos.Pantallas
{
    public partial class DefinirHorasLibres : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button_Atras_Click(object sender, EventArgs e)
        {
            Response.Redirect("Muestreo.aspx");
        }
    }
}