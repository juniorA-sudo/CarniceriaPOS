using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CarniceriaPOS.Models;

namespace CarniceriaPOS.Data
{
    public class RepositorioUsuario
    {
        private ConexionBD bd = new ConexionBD();

        public bool AgregarUsuario(Usuario usuario)
        {
            string sql = @"INSERT INTO Usuarios (IdEmpleado, NombreUsuario, Email, PasswordHash, IdRol, Activo)
                          VALUES (@IdEmpleado, @NombreUsuario, @Email, @PasswordHash, @IdRol, @Activo)";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdEmpleado", usuario.IdEmpleado),
                new SqlParameter("@NombreUsuario", usuario.NombreUsuario),
                new SqlParameter("@Email", usuario.Email),
                new SqlParameter("@PasswordHash", usuario.PasswordHash),
                new SqlParameter("@IdRol", usuario.IdRol),
                new SqlParameter("@Activo", usuario.Activo)
            };

            return bd.EjecutarComando(sql, parametros) > 0;
        }

        public Usuario ObtenerUsuarioPorEmail(string email)
        {
            string sql = @"SELECT u.*, r.Nombre as NombreRol, e.Nombre as NombreEmpleado
                          FROM Usuarios u
                          LEFT JOIN Roles r ON u.IdRol = r.IdRol
                          LEFT JOIN Empleados e ON u.IdEmpleado = e.IdEmpleado
                          WHERE u.Email = @Email";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Email", email)
            };

            DataTable dt = bd.ObtenerDatos(sql, parametros);
            if (dt.Rows.Count > 0)
            {
                return MapearUsuario(dt.Rows[0]);
            }
            return null;
        }

        public List<Usuario> ObtenerTodos()
        {
            string sql = @"SELECT u.*, r.Nombre as NombreRol, e.Nombre as NombreEmpleado
                          FROM Usuarios u
                          LEFT JOIN Roles r ON u.IdRol = r.IdRol
                          LEFT JOIN Empleados e ON u.IdEmpleado = e.IdEmpleado
                          WHERE u.Activo = 1";

            DataTable dt = bd.ObtenerDatos(sql);
            List<Usuario> usuarios = new List<Usuario>();

            foreach (DataRow row in dt.Rows)
            {
                usuarios.Add(MapearUsuario(row));
            }
            return usuarios;
        }

        public bool ActualizarUsuario(Usuario usuario)
        {
            string sql = @"UPDATE Usuarios SET IdEmpleado = @IdEmpleado, NombreUsuario = @NombreUsuario,
                          Email = @Email, PasswordHash = @PasswordHash, IdRol = @IdRol
                          WHERE IdUsuario = @IdUsuario";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdUsuario", usuario.IdUsuario),
                new SqlParameter("@IdEmpleado", usuario.IdEmpleado),
                new SqlParameter("@NombreUsuario", usuario.NombreUsuario),
                new SqlParameter("@Email", usuario.Email),
                new SqlParameter("@PasswordHash", usuario.PasswordHash),
                new SqlParameter("@IdRol", usuario.IdRol)
            };

            return bd.EjecutarComando(sql, parametros) > 0;
        }

        public bool EliminarUsuario(int idUsuario)
        {
            string sql = "UPDATE Usuarios SET Activo = 0 WHERE IdUsuario = @IdUsuario";
            SqlParameter[] parametros = new SqlParameter[] { new SqlParameter("@IdUsuario", idUsuario) };
            return bd.EjecutarComando(sql, parametros) > 0;
        }

        private Usuario MapearUsuario(DataRow row)
        {
            return new Usuario
            {
                IdUsuario = (int)row["IdUsuario"],
                IdEmpleado = (int)row["IdEmpleado"],
                NombreUsuario = row["NombreUsuario"].ToString(),
                Email = row["Email"].ToString(),
                PasswordHash = row["PasswordHash"].ToString(),
                IdRol = (int)row["IdRol"],
                Activo = (bool)row["Activo"],
                FechaCreacion = (DateTime)row["FechaCreacion"],
                NombreRol = row["NombreRol"] != DBNull.Value ? row["NombreRol"].ToString() : "",
                NombreEmpleado = row["NombreEmpleado"] != DBNull.Value ? row["NombreEmpleado"].ToString() : ""
            };
        }
    }
}
