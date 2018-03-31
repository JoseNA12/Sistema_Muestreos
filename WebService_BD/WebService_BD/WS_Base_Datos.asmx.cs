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
        private static string conexionInfo =
            "Data Source =JOSENA\\SQLEXPRESS;" + // Nombre de usuario de SQL Server
            "Initial Catalog=SistemaMuestreos;" + // Nombre de la base de datos
                                                  //"User id=;" +
                                                  //"Password=;";
            "Integrated Security=True;"; //Sin contraseña en la bd

        private SqlConnection conn;

        [WebMethod]
        public DataSet VerificarCredenciales(string pNombreUsuario, string pContrasenia) // Funcion que devuelve un valor/respuesta proveniente de la BD
        {
            //Ingresar a la BD
            conn =  new SqlConnection(conexionInfo);
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
        public DataSet RegistrarNuevoUsuario(string pNombre, string pApellidos, string pCorreoElectronico, string pNombreUsuario, string pContrasenia, int pIdTipoUsuario)
        {
            SqlConnection conn = new SqlConnection(conexionInfo);
            // conn.Open();

            SqlDataAdapter da = new SqlDataAdapter("crud_UsuarioInsert", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.AddWithValue("@Nombre", pNombre);
            da.SelectCommand.Parameters.AddWithValue("@Apellido", pApellidos);
            da.SelectCommand.Parameters.AddWithValue("@Correo", pCorreoElectronico);
            da.SelectCommand.Parameters.AddWithValue("@Usuario", pNombreUsuario);
            da.SelectCommand.Parameters.AddWithValue("@IdTipoUsuario", pIdTipoUsuario);
            da.SelectCommand.Parameters.AddWithValue("@Estado", 1);
            da.SelectCommand.Parameters.AddWithValue("@Contraseña", pContrasenia);

            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet ObtenerActividades()
        {
            SqlConnection conn = new SqlConnection(conexionInfo);
            // conn.Open();

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
            // conn.Open();

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
        public DataSet ModificarActividad(string pNombreOriginal, string pNombre, string pDescripcion, int pTipo)
        {
            SqlConnection conn = new SqlConnection(conexionInfo);
            // conn.Open();

            SqlDataAdapter da = new SqlDataAdapter("crud_ActividadUpdate", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@NombreOriginal", pNombreOriginal);
            da.SelectCommand.Parameters.AddWithValue("@Nombre", pNombre);
            da.SelectCommand.Parameters.AddWithValue("@Observacion", pDescripcion);
            da.SelectCommand.Parameters.AddWithValue("@IdTipoActividad", pTipo);
            da.SelectCommand.Parameters.AddWithValue("@Estado", 1);


            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet EliminarActividad(string pNombreActividad)
        {
            SqlConnection conn = new SqlConnection(conexionInfo);
            // conn.Open();

            SqlDataAdapter da = new SqlDataAdapter("crud_ActividadDelete", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Nombre", pNombreActividad);

            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet ObtenerActividad(string pNombreActividad)
        {
            SqlConnection conn = new SqlConnection(conexionInfo);
            // conn.Open();

            SqlDataAdapter da = new SqlDataAdapter("SeleccionarActividad", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@pNombre", pNombreActividad);

            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet InsertarColaborador(string identificador, string salario, int puesto)
        {
            //Ingresar a la BD
            SqlConnection conn = new SqlConnection(conexionInfo);
            // conn.Open();

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
            // conn.Open();

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
            // conn.Open();

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
            // conn.Open();

            SqlDataAdapter da = new SqlDataAdapter("crud_ColaboradorSelect", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    
        [WebMethod]
        public DataSet ObtenerMuestreoPreliminarId()
        {
            SqlConnection conn = new SqlConnection(conexionInfo);
            // conn.Open();

            SqlDataAdapter da = new SqlDataAdapter("DevolverMuestreoPreliminarId", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet RegistrarRevisionColaborador(int pIdMP, string IdColaborador, int pIdAtividad, string pUsuarioRegistrador, string pDescripcion)
        {
            SqlConnection conn = new SqlConnection(conexionInfo);
            // conn.Open();

            SqlDataAdapter da = new SqlDataAdapter("crud_MuestreoPreliminarObservacionInsert", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@IdMP", pIdMP);
            da.SelectCommand.Parameters.AddWithValue("@IdColaborador", IdColaborador);
            da.SelectCommand.Parameters.AddWithValue("@IdActividad", pIdAtividad);
            da.SelectCommand.Parameters.AddWithValue("@UsuarioRegistrador", pUsuarioRegistrador);
            da.SelectCommand.Parameters.AddWithValue("@Descripcion", pDescripcion);

            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet ActualizarContrasenia(string usuario, string contraseña)
        {
            SqlConnection conn = new SqlConnection(conexionInfo);
            // conn.Open();

            SqlDataAdapter da = new SqlDataAdapter("crud_UsuarioUpdate", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@UsuarioIdentificador", usuario);
            da.SelectCommand.Parameters.AddWithValue("@Usuario", null);
            da.SelectCommand.Parameters.AddWithValue("@Contraseña", contraseña);
            da.SelectCommand.Parameters.AddWithValue("@IdTipoUsuario", null);
            da.SelectCommand.Parameters.AddWithValue("@Nombre", null);
            da.SelectCommand.Parameters.AddWithValue("@Apellido", null);
            da.SelectCommand.Parameters.AddWithValue("@Estado", null);
            da.SelectCommand.Parameters.AddWithValue("@Correo", null);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


        [WebMethod]
        public DataSet CrearMuestreoPreliminar(string idMuestreo, string fechahora, string temperatura, string humedad)
        {
            SqlConnection conn = new SqlConnection(conexionInfo);
            // conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("crud_MuestreoPreliminarInsert", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@IdMuestreo", idMuestreo);
            da.SelectCommand.Parameters.AddWithValue("@FechaHora", fechahora);
            da.SelectCommand.Parameters.AddWithValue("@Humedad", humedad);
            da.SelectCommand.Parameters.AddWithValue("@Temperatura", temperatura);

            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet InsertarHorasNoLaborables(string idmuestreo, string horaDescanso)
        {
            SqlConnection conn = new SqlConnection(conexionInfo);
            // conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("crud_MuestreoHoraDescansoInsert", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@IdMuestreo", idmuestreo);
            da.SelectCommand.Parameters.AddWithValue("@HoraDescanso", horaDescanso);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet BuscarHorasNoLaborables()
        {
            SqlConnection conn = new SqlConnection(conexionInfo);
            // conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("crud_MuestreoHoraDescansoSelect", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet BorrarHorasNoLaborables(int idHora)
        {
            SqlConnection conn = new SqlConnection(conexionInfo);
            // conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("crud_MuestreoHoraDescansoDelete", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@IdMH", idHora);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet CrearMuestreo(string fechaHoraInicio, int lapsoRandomInicio, int lapsoRandomFinal, string descripcion, string adm, string nombre)
        {
            SqlConnection conn = new SqlConnection(conexionInfo);
            // conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("crud_MuestreoInsert", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@FechaHoraInicio", fechaHoraInicio); // datetime
            da.SelectCommand.Parameters.AddWithValue("@LapsoRandomInicio", lapsoRandomInicio); // int
            da.SelectCommand.Parameters.AddWithValue("@LapsoRandomFinal", lapsoRandomFinal); // int
            //da.SelectCommand.Parameters.AddWithValue("@FechaHoraFinalizacion", null); // datetime
            da.SelectCommand.Parameters.AddWithValue("@EstadoMuestreo", 2); //// int
            da.SelectCommand.Parameters.AddWithValue("@Descripcion", descripcion); // nvarchar
            da.SelectCommand.Parameters.AddWithValue("@Administrador", adm); // nvarchar
            da.SelectCommand.Parameters.AddWithValue("@Estado", 1); // bit
            da.SelectCommand.Parameters.AddWithValue("@Nombre", nombre); // nvarchar
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet FinalizarMuestreo(string idMuestreo, string fechaHoraFinal)
        {
            SqlConnection conn = new SqlConnection(conexionInfo);
            // conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("crud_MuestreoUpdate", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@IdMuestreo", idMuestreo);
            da.SelectCommand.Parameters.AddWithValue("@FechaHoraFinalizacion", fechaHoraFinal);
            da.SelectCommand.Parameters.AddWithValue("@EstadoMuestreo", 1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


        [WebMethod]
        public DataSet EliminarMuestreo(string idMuestreo)
        {
            SqlConnection conn = new SqlConnection(conexionInfo);
            // conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("crud_MuestreoDelete", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@IdMuestreo", idMuestreo);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet BuscarUltimoMuestreo()
        {
            SqlConnection conn = new SqlConnection(conexionInfo);
            // conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("crud_MuestreoSelect", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        //retornaIdHoraNoLaboral
        [WebMethod]
        public DataSet BuscarIdHoraNoLaboral(string horaInicio, string horaFinal)
        {
            SqlConnection conn = new SqlConnection(conexionInfo);
            // conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("retornaIdHoraNoLaboral", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@horaInicio", horaInicio);
            da.SelectCommand.Parameters.AddWithValue("@horaFinal", horaFinal);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet AniadirHoraNoLaboral(int IdMuestreo, string horaInicio, string horaFinal)
        {
            SqlConnection conn = new SqlConnection(conexionInfo);
            // conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("crud_MuestreoHoraDescansoInsert", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@IdMuestreo", IdMuestreo);
            da.SelectCommand.Parameters.AddWithValue("@HoraInicio", horaInicio);
            da.SelectCommand.Parameters.AddWithValue("@HoraFinal", horaFinal);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet ModificarMuestreoPreliminar(string IDMP, string temperatura, string humedad)
        {
            SqlConnection conn = new SqlConnection(conexionInfo);
            // conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("crud_MuestreoPreliminarUpdate", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@IdMP", IDMP);
            //    da.SelectCommand.Parameters.AddWithValue("@IdMuestreo", );
            //    da.SelectCommand.Parameters.AddWithValue("@FechaHora", fechahora);
            da.SelectCommand.Parameters.AddWithValue("@Humedad", humedad);
            da.SelectCommand.Parameters.AddWithValue("@Temperatura", temperatura);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet EliminarMuestreoPreliminar(string idMuestreo)
        {
            SqlConnection conn = new SqlConnection(conexionInfo);
            // conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("crud_MuestreoPreliminarDelete", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@IdMP", idMuestreo);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


        [WebMethod]
        public DataSet BuscarUltimoMuestreoPreliminar()
        {
            SqlConnection conn = new SqlConnection(conexionInfo);
            // conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("crud_MuestreoPreliminarSelect", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet ModificarMuestreoPreliminarHoras(string IDMP, string fechahora)
        {
            SqlConnection conn = new SqlConnection(conexionInfo);
            // conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("crud_MuestreoPreliminarUpdate", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@IdMP", IDMP);
            //da.SelectCommand.Parameters.AddWithValue("@IdMuestreo", );
            da.SelectCommand.Parameters.AddWithValue("@FechaHora", fechahora);
            //da.SelectCommand.Parameters.AddWithValue("@Humedad", humedad);
            //da.SelectCommand.Parameters.AddWithValue("@Temperatura", temperatura);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        [WebMethod]
        /*@IdMuestreo int,
		@Nombre [nvarchar](50) = null,
		@FechaHoraInicio [datetime] = null,
		@LapsoRandomInicio [int] = null,
		@LapsoRandomFinal [int] = null,
		@FechaHoraFinalizacion [datetime] = null,
		@EstadoMuestreo [int] = null,
		@Descripcion [nvarchar](200) = null,
		@Administrador [nvarchar](50) = null,
		@Estado [bit] = null*/
        public DataSet ModificarMuestreo(int IdMuestreo, string Nombre, string fechaHora,int randomInicio, int randomFinal,string FechaHoraFinalizacion,int EstadoMuestro,
            string Descripcion,string Administrador,int Estado)
        {
            SqlConnection conn = new SqlConnection(conexionInfo);
            // conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("crud_MuestreoUpdate", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@IdMuestreo", IdMuestreo);
            da.SelectCommand.Parameters.AddWithValue("@Nombre", Nombre);
            da.SelectCommand.Parameters.AddWithValue("@FechaHoraInicio", fechaHora);
            da.SelectCommand.Parameters.AddWithValue("@LapsoRandomInicio", randomInicio);
            da.SelectCommand.Parameters.AddWithValue("@LapsoRandomFinal", randomFinal);
            da.SelectCommand.Parameters.AddWithValue("@FechaHoraFinalizacion", FechaHoraFinalizacion);
            da.SelectCommand.Parameters.AddWithValue("@EstadoMuestreo", EstadoMuestro);
            da.SelectCommand.Parameters.AddWithValue("@Descripcion", Descripcion);
            da.SelectCommand.Parameters.AddWithValue("@Administrador", Administrador);
            da.SelectCommand.Parameters.AddWithValue("@Estado", Estado);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


        [WebMethod]
        public DataSet CrearPuesto(string nombre)
        {
            SqlConnection conn = new SqlConnection(conexionInfo);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter("crud_PuestoInsert", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.AddWithValue("@Nombre", nombre);
            da.SelectCommand.Parameters.AddWithValue("@Estado", 1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet ModificarPuesto(string nombreOriginal, string nombreNuevo)
        {

            SqlConnection conn = new SqlConnection(conexionInfo);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("crud_PuestoUpdate", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@NombreOriginal", nombreOriginal);
            da.SelectCommand.Parameters.AddWithValue("@Nombre", nombreNuevo);
            da.SelectCommand.Parameters.AddWithValue("@Estado", 1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet EliminarPuesto(string nombre)
        {
            SqlConnection conn = new SqlConnection(conexionInfo);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter("crud_PuestoDelete", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.AddWithValue("@Nombre", nombre);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet ObtenerPuesto()
        {
            SqlConnection conn = new SqlConnection(conexionInfo);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("crud_PuestoSelect", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}
