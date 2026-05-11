using System;
using System.Data;
using System.Data.SqlClient;

namespace CarniceriaPOS.Data
{
    public class ConexionBD
    {
        private string cadenaConexion = @"Server=.\SQLEXPRESS;Database=CarniceriaPOS;Integrated Security=true;Connection Timeout=10;MultipleActiveResultSets=true;Encrypt=true;TrustServerCertificate=true;";

        public SqlConnection Conectar()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            try
            {
                conexion.Open();
                return conexion;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al conectar a la base de datos: " + ex.Message);
            }
        }

        public void Desconectar(SqlConnection conexion)
        {
            if (conexion != null && conexion.State == ConnectionState.Open)
            {
                conexion.Close();
                conexion.Dispose();
            }
        }

        public int EjecutarComando(string sql, SqlParameter[] parametros = null)
        {
            SqlConnection conexion = Conectar();
            try
            {
                SqlCommand comando = new SqlCommand(sql, conexion);
                if (parametros != null)
                {
                    comando.Parameters.AddRange(parametros);
                }
                return comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al ejecutar comando: " + ex.Message);
            }
            finally
            {
                Desconectar(conexion);
            }
        }

        public DataTable ObtenerDatos(string sql, SqlParameter[] parametros = null)
        {
            SqlConnection conexion = Conectar();
            try
            {
                SqlCommand comando = new SqlCommand(sql, conexion);
                if (parametros != null)
                {
                    comando.Parameters.AddRange(parametros);
                }
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);
                return dt;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al obtener datos: " + ex.Message);
            }
            finally
            {
                Desconectar(conexion);
            }
        }

        public object ObtenerEscalar(string sql, SqlParameter[] parametros = null)
        {
            SqlConnection conexion = Conectar();
            try
            {
                SqlCommand comando = new SqlCommand(sql, conexion);
                if (parametros != null)
                {
                    comando.Parameters.AddRange(parametros);
                }
                return comando.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al ejecutar escalar: " + ex.Message);
            }
            finally
            {
                Desconectar(conexion);
            }
        }
    }
}
