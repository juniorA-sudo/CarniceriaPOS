using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CarniceriaPOS.Models;

namespace CarniceriaPOS.Data
{
    public class RepositorioRol
    {
        private ConexionBD bd = new ConexionBD();

        public List<Rol> ObtenerTodos()
        {
            try
            {
                string sql = "SELECT * FROM Roles";
                DataTable dt = bd.ObtenerDatos(sql);
                List<Rol> roles = new List<Rol>();

                foreach (DataRow row in dt.Rows)
                {
                    roles.Add(new Rol
                    {
                        IdRol = (int)row["IdRol"],
                        Nombre = row["Nombre"].ToString(),
                        Descripcion = row["Descripcion"].ToString()
                    });
                }
                return roles;
            }
            catch
            {
                
                return ObtenerRolesDemo();
            }
        }

        private List<Rol> ObtenerRolesDemo()
        {
            return new List<Rol>
            {
                new Rol { IdRol = 1, Nombre = "Administrador", Descripcion = "Administrador del sistema" },
                new Rol { IdRol = 2, Nombre = "Gerente", Descripcion = "Gerente de operaciones" },
                new Rol { IdRol = 3, Nombre = "Vendedor", Descripcion = "Personal de ventas" },
                new Rol { IdRol = 4, Nombre = "Cajero", Descripcion = "Encargado de caja" },
                new Rol { IdRol = 5, Nombre = "Bodeguero", Descripcion = "Encargado de bodega" }
            };
        }

        public Rol ObtenerRolPorId(int idRol)
        {
            try
            {
                string sql = "SELECT * FROM Roles WHERE IdRol = @IdRol";
                SqlParameter[] parametros = new SqlParameter[] { new SqlParameter("@IdRol", idRol) };

                DataTable dt = bd.ObtenerDatos(sql, parametros);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    return new Rol
                    {
                        IdRol = (int)row["IdRol"],
                        Nombre = row["Nombre"].ToString(),
                        Descripcion = row["Descripcion"].ToString()
                    };
                }
                return null;
            }
            catch
            {
                
                var rolesDemo = ObtenerRolesDemo();
                return rolesDemo.Find(r => r.IdRol == idRol);
            }
        }
    }
}
