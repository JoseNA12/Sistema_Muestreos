using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient; //Para la conexión con la base datos
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebService_BD
{
    /// <summary>
    /// Descripción breve de WS_Base_Datos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WS_Base_Datos : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public DataSet GetData()
        {
            //Ingresar a la BD
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source =JoseNA;" +
                "Initial Catalog=SistemaMuestreos;" +
                //"User id=SQLEXPRESS;" +
                //"Password=3;";
                "Integrated Security=True;"; //Sin contraseña en la bd
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM USUARIO", conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}
