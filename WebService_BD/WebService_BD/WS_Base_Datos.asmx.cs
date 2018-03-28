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

        /*private DataSet CrearPeticion(string pInstruccion)
        {
            //Ingresar a la BD
            SqlConnection conn = new SqlConnection(conexionInfo);
            conn.Open();
            //conn.ConnectionString = conexionInfo;
            ///SqlCommand com = new SqlCommand("Prueba()", conn);
            // Peticion que queremos hacer
            SqlDataAdapter da = new SqlDataAdapter("crud_UsuarioSelect", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }*/

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

        [WebMethod]
        public DataSet VerificarCredenciales(string pNombreUsuario, string pContrasenia) // Funcion que devuelve un valor/respuesta proveniente de la BD
        {
            //Ingresar a la BD
            SqlConnection conn = new SqlConnection(conexionInfo);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter("crud_UsuarioSelect", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.AddWithValue("@Usuario", pNombreUsuario);
            da.SelectCommand.Parameters.AddWithValue("@Contraseña", pContrasenia);

            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet RegistrarNuevoUsuario(string pNombre, string pApellidos, string pCorreoElectronico, string pNombreUsuario, int pIdTipoUsuario)
        {
            SqlConnection conn = new SqlConnection(conexionInfo);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter("crud_UsuarioInsert", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.AddWithValue("@Nombre", pNombre);
            da.SelectCommand.Parameters.AddWithValue("@Apellido", pApellidos);
            da.SelectCommand.Parameters.AddWithValue("@Correo", pCorreoElectronico);
            da.SelectCommand.Parameters.AddWithValue("@Usuario", pNombreUsuario);
            da.SelectCommand.Parameters.AddWithValue("@IdTipoUsuario", pIdTipoUsuario);
            da.SelectCommand.Parameters.AddWithValue("@Estado", 1);

            string pContrasenia = generarContraseniaTemporal();
            da.SelectCommand.Parameters.AddWithValue("@Contraseña", pContrasenia);

            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet ObtenerActividades()
        {
            SqlConnection conn = new SqlConnection(conexionInfo);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter("crud_ActividadSelect", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet CrearActividad(string pNombreActividad, int pTipoActividad, string pDescripcion)
        {
            SqlConnection conn = new SqlConnection(conexionInfo);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter("crud_ActividadInsert", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.AddWithValue("@Nombre", pNombreActividad);
            da.SelectCommand.Parameters.AddWithValue("@Observacion", pDescripcion);
            da.SelectCommand.Parameters.AddWithValue("@IdTipoActividad", pTipoActividad);
            da.SelectCommand.Parameters.AddWithValue("@Estado", 1);

            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet EliminarActividad(string pNombreActividad)
        {
            SqlConnection conn = new SqlConnection(conexionInfo);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter("crud_ActividadDelete", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Nombre", pNombreActividad);

            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet InsertarColaborador(string identificador, string salario, int puesto)
        {
            //Ingresar a la BD
            SqlConnection conn = new SqlConnection(conexionInfo);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter("crud_ColaboradorInsert", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.AddWithValue("@Nombre", identificador);
            da.SelectCommand.Parameters.AddWithValue("@IdPuesto", puesto);
            da.SelectCommand.Parameters.AddWithValue("@Salario", salario);
            da.SelectCommand.Parameters.AddWithValue("@Estado", 1);

            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet EliminarColaborador(string colaborador)
        {
            SqlConnection conn = new SqlConnection(conexionInfo);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter("crud_ColaboradorDelete", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Nombre", colaborador);

            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet BuscarPuestos()
        {
            SqlConnection conn = new SqlConnection(conexionInfo);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter("crud_PuestoSelect", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet BuscarColaboradores()
        {
            SqlConnection conn = new SqlConnection(conexionInfo);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter("crud_ColaboradorSelect", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}
