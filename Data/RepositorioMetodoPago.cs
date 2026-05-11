using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CarniceriaPOS.Models;

namespace CarniceriaPOS.Data
{
    public class RepositorioMetodoPago
    {
        private ConexionBD bd = new ConexionBD();

        public List<MetodoPago> ObtenerTodos()
        {
            string sql = @"SELECT * FROM MetodosPago
                          WHERE Activo = 1
                          ORDER BY IdMetodoPago ASC";

            DataTable dt = bd.ObtenerDatos(sql);
            List<MetodoPago> metodos = new List<MetodoPago>();

            foreach (DataRow row in dt.Rows)
            {
                metodos.Add(MapearMetodoPago(row));
            }
            return metodos;
        }

        public MetodoPago ObtenerPorId(int idMetodoPago)
        {
            string sql = @"SELECT * FROM MetodosPago
                          WHERE IdMetodoPago = @IdMetodoPago";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdMetodoPago", idMetodoPago)
            };

            DataTable dt = bd.ObtenerDatos(sql, parametros);
            if (dt.Rows.Count > 0)
            {
                return MapearMetodoPago(dt.Rows[0]);
            }
            return null;
        }

        public bool AgregarMetodoPago(MetodoPago metodo)
        {
            string sql = @"INSERT INTO MetodosPago (Nombre, Descripcion, RequiereCliente, Activo)
                          VALUES (@Nombre, @Descripcion, @RequiereCliente, @Activo)";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Nombre", metodo.Nombre),
                new SqlParameter("@Descripcion", metodo.Descripcion ?? ""),
                new SqlParameter("@RequiereCliente", metodo.RequiereCliente),
                new SqlParameter("@Activo", metodo.Activo)
            };

            return bd.EjecutarComando(sql, parametros) > 0;
        }

        public bool ActualizarMetodoPago(MetodoPago metodo)
        {
            string sql = @"UPDATE MetodosPago
                          SET Nombre = @Nombre, Descripcion = @Descripcion,
                              RequiereCliente = @RequiereCliente, Activo = @Activo
                          WHERE IdMetodoPago = @IdMetodoPago";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdMetodoPago", metodo.IdMetodoPago),
                new SqlParameter("@Nombre", metodo.Nombre),
                new SqlParameter("@Descripcion", metodo.Descripcion ?? ""),
                new SqlParameter("@RequiereCliente", metodo.RequiereCliente),
                new SqlParameter("@Activo", metodo.Activo)
            };

            return bd.EjecutarComando(sql, parametros) > 0;
        }

        private MetodoPago MapearMetodoPago(DataRow row)
        {
            return new MetodoPago
            {
                IdMetodoPago = (int)row["IdMetodoPago"],
                Nombre = row["Nombre"].ToString(),
                Descripcion = row["Descripcion"] != DBNull.Value ? row["Descripcion"].ToString() : "",
                RequiereCliente = (bool)row["RequiereCliente"],
                Activo = (bool)row["Activo"],
                FechaCreacion = (DateTime)row["FechaCreacion"]
            };
        }
    }
}
