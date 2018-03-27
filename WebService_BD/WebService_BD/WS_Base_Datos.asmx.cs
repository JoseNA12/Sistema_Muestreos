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

        private string conexionInfo = 
            "Data Source =JOSENA\\SQLEXPRESS;" + // Nombre de usuario de SQL Server
            "Initial Catalog=SistemaMuestreos;" + // Nombre de la base de datos
            //"User id=;" +
            //"Password=;";
            "Integrated Security=True;"; //Sin contraseña en la bd

        private DataSet CrearPeticion(string pInstruccion)
        {
            //Ingresar a la BD
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conexionInfo;

            // Peticion que queremos hacer
            SqlDataAdapter da = new SqlDataAdapter(pInstruccion, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet VerificarCredenciales(string pA) // Funcion que devuelve un valor/respuesta proveniente de la BD
        {
            string pNombreUsuario = "'Pepito'"; string pContrasenia = "12345";
            return CrearPeticion("SELECT u.Nombre, u.Contraseña, u.IdTipoUsuario FROM USUARIO u " +
                "WHERE u.Nombre = " + pNombreUsuario + " and u.Contraseña = " + pContrasenia);
        }
    }
}
