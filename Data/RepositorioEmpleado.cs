using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CarniceriaPOS.Models;
using System.Windows.Forms;

namespace CarniceriaPOS.Data
{
    public class RepositorioEmpleado
    {
        private ConexionBD bd = new ConexionBD();

        public List<Empleado> ObtenerTodos()
        {
            List<Empleado> empleados = new List<Empleado>();
            try
            {
                // Usamos la clase ConexionBD para obtener el DataTable, igual que en Clientes/Proveedores
                string sql = @"SELECT e.*, d.Nombre as NombreDepartamento
                               FROM Empleados e
                               LEFT JOIN Departamentos d ON e.IdDepartamento = d.IdDepartamento
                               ORDER BY e.Nombre";

                DataTable dt = bd.ObtenerDatos(sql);

                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        empleados.Add(MapearEmpleado(row));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar empleados: " + ex.Message);
            }
            return empleados;
        }

        public bool AgregarEmpleado(Empleado empleado)
        {
            try
            {
                string sql = @"INSERT INTO Empleados (Nombre, Cedula, Telefono, IdDepartamento, Puesto, Salario, Activo, FechaCreacion) 
                               VALUES (@Nombre, @Cedula, @Telefono, @IdDepartamento, @Puesto, @Salario, @Activo, @FechaCreacion)";

                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@Nombre", empleado.Nombre ?? ""),
                    new SqlParameter("@Cedula", empleado.Cedula ?? ""),
                    new SqlParameter("@Telefono", empleado.Telefono ?? ""),
                    new SqlParameter("@IdDepartamento", (object)empleado.IdDepartamento ?? DBNull.Value),
                    new SqlParameter("@Puesto", empleado.Puesto ?? ""),
                    new SqlParameter("@Salario", empleado.Salario),
                    new SqlParameter("@Activo", empleado.Activo),
                    new SqlParameter("@FechaCreacion", DateTime.Now)
                };

                return bd.EjecutarComando(sql, parametros) > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar empleado: " + ex.Message);
                return false;
            }
        }

        public bool ActualizarEmpleado(Empleado empleado)
        {
            try
            {
                string sql = @"UPDATE Empleados SET Nombre = @Nombre, Cedula = @Cedula, Telefono = @Telefono, 
                               IdDepartamento = @IdDepartamento, Puesto = @Puesto, Salario = @Salario, Activo = @Activo
                               WHERE IdEmpleado = @IdEmpleado";

                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@IdEmpleado", empleado.IdEmpleado),
                    new SqlParameter("@Nombre", empleado.Nombre ?? ""),
                    new SqlParameter("@Cedula", empleado.Cedula ?? ""),
                    new SqlParameter("@Telefono", empleado.Telefono ?? ""),
                    new SqlParameter("@IdDepartamento", (object)empleado.IdDepartamento ?? DBNull.Value),
                    new SqlParameter("@Puesto", empleado.Puesto ?? ""),
                    new SqlParameter("@Salario", empleado.Salario),
                    new SqlParameter("@Activo", empleado.Activo)
                };

                return bd.EjecutarComando(sql, parametros) > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar empleado: " + ex.Message);
                return false;
            }
        }

        public bool EliminarEmpleado(int idEmpleado)
        {
            try
            {
                // Generalmente es mejor desactivar en lugar de borrar físicamente
                string sql = "UPDATE Empleados SET Activo = 0 WHERE IdEmpleado = @IdEmpleado";
                SqlParameter[] parametros = new SqlParameter[] { new SqlParameter("@IdEmpleado", idEmpleado) };
                return bd.EjecutarComando(sql, parametros) > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar empleado: " + ex.Message);
                return false;
            }
        }

        private Empleado MapearEmpleado(DataRow row)
        {
            // Función de ayuda para evitar el error de "Specified cast is not valid"
            object SafeGet(string columnName, object defaultValue)
            {
                if (row.Table.Columns.Contains(columnName) && row[columnName] != DBNull.Value)
                    return row[columnName];
                return defaultValue;
            }

            return new Empleado
            {
                IdEmpleado = Convert.ToInt32(SafeGet("IdEmpleado", 0)),
                Nombre = SafeGet("Nombre", "").ToString(),
                Cedula = SafeGet("Cedula", "").ToString(),
                Telefono = SafeGet("Telefono", "").ToString(),
                IdDepartamento = row["IdDepartamento"] != DBNull.Value ? (int?)Convert.ToInt32(row["IdDepartamento"]) : null,
                Puesto = SafeGet("Puesto", "").ToString(),
                Salario = Convert.ToDecimal(SafeGet("Salario", 0m)),
                Activo = Convert.ToBoolean(SafeGet("Activo", false)),
                FechaCreacion = Convert.ToDateTime(SafeGet("FechaCreacion", DateTime.Now)),
                NombreDepartamento = SafeGet("NombreDepartamento", "N/A").ToString()
            };
        }
    }
}