using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CarniceriaPOS.Models;
using System.Windows.Forms;

namespace CarniceriaPOS.Data
{
    public class RepositorioCliente
    {
        private ConexionBD bd = new ConexionBD();

        public bool AgregarCliente(Cliente cliente)
        {
            try
            {
                string sql = @"INSERT INTO Clientes (Nombre, Cedula, Telefono, Email, Direccion, RNC, Activo, FechaCreacion)
                          VALUES (@Nombre, @Cedula, @Telefono, @Email, @Direccion, @RNC, @Activo, @FechaCreacion)";

                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Nombre", cliente.Nombre ?? ""),
                    new SqlParameter("@Cedula", cliente.Cedula ?? ""),
                    new SqlParameter("@Telefono", cliente.Telefono ?? ""),
                    new SqlParameter("@Email", cliente.Email ?? ""),
                    new SqlParameter("@Direccion", cliente.Direccion ?? ""),
                    new SqlParameter("@RNC", cliente.RNC ?? ""),
                    new SqlParameter("@Activo", cliente.Activo),
                    new SqlParameter("@FechaCreacion", DateTime.Now)
                };

                return bd.EjecutarComando(sql, parametros) > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar cliente: " + ex.Message);
                return false;
            }
        }

        public List<Cliente> ObtenerTodos()
        {
            List<Cliente> clientes = new List<Cliente>();
            try
            {
                string sql = "SELECT * FROM Clientes WHERE Activo = 1 ORDER BY Nombre";
                DataTable dt = bd.ObtenerDatos(sql);

                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        clientes.Add(MapearCliente(row));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
            return clientes;
        }

        public Cliente ObtenerClientePorId(int idCliente)
        {
            try
            {
                string sql = "SELECT * FROM Clientes WHERE IdCliente = @IdCliente";
                SqlParameter[] parametros = new SqlParameter[] { new SqlParameter("@IdCliente", idCliente) };

                DataTable dt = bd.ObtenerDatos(sql, parametros);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return MapearCliente(dt.Rows[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener cliente: " + ex.Message);
            }
            return null;
        }

        public Cliente ObtenerClientePorCedula(string cedula)
        {
            try
            {
                string sql = "SELECT * FROM Clientes WHERE Cedula = @Cedula AND Activo = 1";
                SqlParameter[] parametros = new SqlParameter[] { new SqlParameter("@Cedula", cedula) };

                DataTable dt = bd.ObtenerDatos(sql, parametros);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return MapearCliente(dt.Rows[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar por cedula: " + ex.Message);
            }
            return null;
        }

        public bool ActualizarCliente(Cliente cliente)
        {
            try
            {
                string sql = @"UPDATE Clientes SET Nombre = @Nombre, Cedula = @Cedula, Telefono = @Telefono,
                          Email = @Email, Direccion = @Direccion, RNC = @RNC
                          WHERE IdCliente = @IdCliente";

                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@IdCliente", cliente.IdCliente),
                    new SqlParameter("@Nombre", cliente.Nombre ?? ""),
                    new SqlParameter("@Cedula", cliente.Cedula ?? ""),
                    new SqlParameter("@Telefono", cliente.Telefono ?? ""),
                    new SqlParameter("@Email", cliente.Email ?? ""),
                    new SqlParameter("@Direccion", cliente.Direccion ?? ""),
                    new SqlParameter("@RNC", cliente.RNC ?? "")
                };

                return bd.EjecutarComando(sql, parametros) > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar cliente: " + ex.Message);
                return false;
            }
        }

        public bool EliminarCliente(int idCliente)
        {
            try
            {
                string sql = "UPDATE Clientes SET Activo = 0 WHERE IdCliente = @IdProducto"; // Nota: Asegúrate que el parámetro sea @IdCliente en el SP si lo cambiaste
                SqlParameter[] parametros = new SqlParameter[] { new SqlParameter("@IdProducto", idCliente) };
                return bd.EjecutarComando(sql, parametros) > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar cliente: " + ex.Message);
                return false;
            }
        }

        private Cliente MapearCliente(DataRow row)
        {
            // Método preventivo para obtener datos sin errores de conversión (Casting)
            object SafeGet(string columnName, object defaultValue)
            {
                if (row.Table.Columns.Contains(columnName) && row[columnName] != DBNull.Value)
                    return row[columnName];
                return defaultValue;
            }

            return new Cliente
            {
                IdCliente = Convert.ToInt32(SafeGet("IdCliente", 0)),
                Nombre = SafeGet("Nombre", "").ToString(),
                Cedula = SafeGet("Cedula", "").ToString(),
                Telefono = SafeGet("Telefono", "").ToString(),
                Email = SafeGet("Email", "").ToString(),
                Direccion = SafeGet("Direccion", "").ToString(),
                RNC = SafeGet("RNC", "").ToString(),
                Activo = Convert.ToBoolean(SafeGet("Activo", false)),
                FechaCreacion = Convert.ToDateTime(SafeGet("FechaCreacion", DateTime.Now))
            };
        }
    }
}