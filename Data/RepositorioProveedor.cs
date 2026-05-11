using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CarniceriaPOS.Models;
using System.Windows.Forms;

namespace CarniceriaPOS.Data
{
    public class RepositorioProveedor
    {
        private ConexionBD bd = new ConexionBD();

        public bool AgregarProveedor(Proveedor proveedor)
        {
            try
            {
                string sql = @"INSERT INTO Proveedores (Nombre, Telefono, Email, Direccion, RNC, Activo)
                          VALUES (@Nombre, @Telefono, @Email, @Direccion, @RNC, @Activo)";

                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Nombre", proveedor.Nombre ?? ""),
                    new SqlParameter("@Telefono", proveedor.Telefono ?? ""),
                    new SqlParameter("@Email", proveedor.Email ?? ""),
                    new SqlParameter("@Direccion", proveedor.Direccion ?? ""),
                    new SqlParameter("@RNC", proveedor.RNC ?? ""),
                    new SqlParameter("@Activo", true)
                };

                return bd.EjecutarComando(sql, parametros) > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar proveedor: " + ex.Message);
                return false;
            }
        }

        public List<Proveedor> ObtenerTodos()
        {
            List<Proveedor> proveedores = new List<Proveedor>();
            try
            {
                string sql = "SELECT * FROM Proveedores WHERE Activo = 1 ORDER BY Nombre";
                DataTable dt = bd.ObtenerDatos(sql);

                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        proveedores.Add(MapearProveedor(row));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar proveedores: " + ex.Message);
            }
            return proveedores;
        }

        public Proveedor ObtenerProveedorPorId(int idProveedor)
        {
            try
            {
                string sql = "SELECT * FROM Proveedores WHERE IdProveedor = @IdProveedor";
                SqlParameter[] parametros = new SqlParameter[] { new SqlParameter("@IdProveedor", idProveedor) };

                DataTable dt = bd.ObtenerDatos(sql, parametros);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return MapearProveedor(dt.Rows[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener proveedor: " + ex.Message);
            }
            return null;
        }

        public bool ActualizarProveedor(Proveedor proveedor)
        {
            try
            {
                string sql = @"UPDATE Proveedores SET Nombre = @Nombre, Telefono = @Telefono,
                          Email = @Email, Direccion = @Direccion, RNC = @RNC
                          WHERE IdProveedor = @IdProveedor";

                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@IdProveedor", proveedor.IdProveedor),
                    new SqlParameter("@Nombre", proveedor.Nombre ?? ""),
                    new SqlParameter("@Telefono", proveedor.Telefono ?? ""),
                    new SqlParameter("@Email", proveedor.Email ?? ""),
                    new SqlParameter("@Direccion", proveedor.Direccion ?? ""),
                    new SqlParameter("@RNC", proveedor.RNC ?? "")
                };

                return bd.EjecutarComando(sql, parametros) > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar proveedor: " + ex.Message);
                return false;
            }
        }

        public bool EliminarProveedor(int idProveedor)
        {
            try
            {
                string sql = "UPDATE Proveedores SET Activo = 0 WHERE IdProveedor = @IdProveedor";
                SqlParameter[] parametros = new SqlParameter[] { new SqlParameter("@IdProveedor", idProveedor) };
                return bd.EjecutarComando(sql, parametros) > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar proveedor: " + ex.Message);
                return false;
            }
        }

        private Proveedor MapearProveedor(DataRow row)
        {
            // Función para obtener datos de forma segura (Previene el error de Cast)
            object SafeGet(string columnName, object defaultValue)
            {
                if (row.Table.Columns.Contains(columnName) && row[columnName] != DBNull.Value)
                    return row[columnName];
                return defaultValue;
            }

            return new Proveedor
            {
                IdProveedor = Convert.ToInt32(SafeGet("IdProveedor", 0)),
                Nombre = SafeGet("Nombre", "").ToString(),
                Telefono = SafeGet("Telefono", "").ToString(),
                Email = SafeGet("Email", "").ToString(),
                Direccion = SafeGet("Direccion", "").ToString(),
                RNC = SafeGet("RNC", "").ToString(),
                // Convert.ToBoolean es más robusto que el casting directo (bool)
                Activo = Convert.ToBoolean(SafeGet("Activo", false)),
                // SafeGet con fecha por defecto por si el campo es nulo o no existe
                FechaCreacion = Convert.ToDateTime(SafeGet("FechaCreacion", DateTime.Now))
            };
        }
    }
}