using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CarniceriaPOS.Models;

namespace CarniceriaPOS.Data
{
    public class RepositorioDepartamento
    {
        private ConexionBD conexion;

        public RepositorioDepartamento()
        {
            conexion = new ConexionBD();
        }

        public List<Departamento> ObtenerTodos()
        {
            List<Departamento> departamentos = new List<Departamento>();
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    string query = "SELECT IdDepartamento, Nombre, Descripcion, Activo FROM Departamentos WHERE Activo = 1 ORDER BY Nombre";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        departamentos.Add(new Departamento
                        {
                            IdDepartamento = (int)reader["IdDepartamento"],
                            Nombre = reader["Nombre"].ToString(),
                            Descripcion = reader["Descripcion"] != DBNull.Value ? reader["Descripcion"].ToString() : "",
                            Activo = (bool)reader["Activo"]
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al obtener departamentos: " + ex.Message);
            }
            return departamentos;
        }

        public Departamento ObtenerPorId(int idDepartamento)
        {
            Departamento departamento = null;
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    string query = "SELECT IdDepartamento, Nombre, Descripcion, Activo FROM Departamentos WHERE IdDepartamento = @IdDepartamento";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IdDepartamento", idDepartamento);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        departamento = new Departamento
                        {
                            IdDepartamento = (int)reader["IdDepartamento"],
                            Nombre = reader["Nombre"].ToString(),
                            Descripcion = reader["Descripcion"] != DBNull.Value ? reader["Descripcion"].ToString() : "",
                            Activo = (bool)reader["Activo"]
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al obtener departamento: " + ex.Message);
            }
            return departamento;
        }

        public bool AgregarDepartamento(Departamento departamento)
        {
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    string query = "INSERT INTO Departamentos (Nombre, Descripcion, Activo) " +
                                   "VALUES (@Nombre, @Descripcion, @Activo)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nombre", departamento.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", departamento.Descripcion ?? "");
                    cmd.Parameters.AddWithValue("@Activo", departamento.Activo);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al agregar departamento: " + ex.Message);
                return false;
            }
        }

        public bool ActualizarDepartamento(Departamento departamento)
        {
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    string query = "UPDATE Departamentos SET Nombre = @Nombre, Descripcion = @Descripcion, Activo = @Activo " +
                                   "WHERE IdDepartamento = @IdDepartamento";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nombre", departamento.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", departamento.Descripcion ?? "");
                    cmd.Parameters.AddWithValue("@Activo", departamento.Activo);
                    cmd.Parameters.AddWithValue("@IdDepartamento", departamento.IdDepartamento);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al actualizar departamento: " + ex.Message);
                return false;
            }
        }

        public bool EliminarDepartamento(int idDepartamento)
        {
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    string query = "UPDATE Departamentos SET Activo = 0 WHERE IdDepartamento = @IdDepartamento";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IdDepartamento", idDepartamento);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al eliminar departamento: " + ex.Message);
                return false;
            }
        }
    }
}
