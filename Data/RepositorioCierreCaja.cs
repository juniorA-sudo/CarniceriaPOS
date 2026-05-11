using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CarniceriaPOS.Models;

namespace CarniceriaPOS.Data
{
    public class RepositorioCierreCaja
    {
        private ConexionBD bd = new ConexionBD();

        public bool AgregarCierre(CierreCaja cierre)
        {
            string sql = @"INSERT INTO CierresCaja
                (IdUsuario, FechaApertura, FechaClosing, MontoApertura, MontoEsperado, MontoReal, Diferencia, Estado)
                VALUES (@IdUsuario, @FechaApertura, @FechaClosing, @MontoApertura, @MontoEsperado, @MontoReal, @Diferencia, @Estado)";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdUsuario", cierre.IdUsuario),
                new SqlParameter("@FechaApertura", cierre.FechaApertura),
                new SqlParameter("@FechaClosing", cierre.FechaClosing),
                new SqlParameter("@MontoApertura", cierre.MontoApertura),
                new SqlParameter("@MontoEsperado", cierre.MontoEsperado),
                new SqlParameter("@MontoReal", cierre.MontoReal),
                new SqlParameter("@Diferencia", cierre.Diferencia),
                new SqlParameter("@Estado", cierre.Estado)
            };

            return bd.EjecutarComando(sql, parametros) > 0;
        }

        public List<CierreCaja> ObtenerTodos()
        {
            string sql = @"SELECT
                c.IdCierre, c.IdUsuario, c.FechaApertura, c.FechaClosing,
                c.MontoApertura, c.MontoEsperado, c.MontoReal, c.Diferencia,
                c.Estado, u.NombreUsuario
                FROM CierresCaja c
                LEFT JOIN Usuarios u ON c.IdUsuario = u.IdUsuario
                ORDER BY c.FechaClosing DESC";

            DataTable dt = bd.ObtenerDatos(sql);
            List<CierreCaja> cierres = new List<CierreCaja>();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    cierres.Add(MapearCierre(row));
                }
            }

            return cierres;
        }

        public List<CierreCaja> ObtenerCierresPorFecha(DateTime fecha)
        {
            string sql = @"SELECT
                c.IdCierre, c.IdUsuario, c.FechaApertura, c.FechaClosing,
                c.MontoApertura, c.MontoEsperado, c.MontoReal, c.Diferencia,
                c.Estado, u.NombreUsuario
                FROM CierresCaja c
                LEFT JOIN Usuarios u ON c.IdUsuario = u.IdUsuario
                WHERE CAST(c.FechaClosing AS DATE) = @Fecha
                ORDER BY c.FechaClosing DESC";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Fecha", fecha.Date)
            };

            DataTable dt = bd.ObtenerDatos(sql, parametros);
            List<CierreCaja> cierres = new List<CierreCaja>();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    cierres.Add(MapearCierre(row));
                }
            }

            return cierres;
        }

        public CierreCaja ObtenerPorId(int idCierre)
        {
            string sql = @"SELECT
                c.IdCierre, c.IdUsuario, c.FechaApertura, c.FechaClosing,
                c.MontoApertura, c.MontoEsperado, c.MontoReal, c.Diferencia,
                c.Estado, u.NombreUsuario
                FROM CierresCaja c
                LEFT JOIN Usuarios u ON c.IdUsuario = u.IdUsuario
                WHERE c.IdCierre = @IdCierre";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdCierre", idCierre)
            };

            DataTable dt = bd.ObtenerDatos(sql, parametros);

            if (dt != null && dt.Rows.Count > 0)
            {
                return MapearCierre(dt.Rows[0]);
            }

            return null;
        }

        public bool ActualizarCierre(CierreCaja cierre)
        {
            string sql = @"UPDATE CierresCaja SET
                IdUsuario = @IdUsuario,
                FechaApertura = @FechaApertura,
                FechaClosing = @FechaClosing,
                MontoApertura = @MontoApertura,
                MontoEsperado = @MontoEsperado,
                MontoReal = @MontoReal,
                Diferencia = @Diferencia,
                Estado = @Estado
                WHERE IdCierre = @IdCierre";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdCierre", cierre.IdCierre),
                new SqlParameter("@IdUsuario", cierre.IdUsuario),
                new SqlParameter("@FechaApertura", cierre.FechaApertura),
                new SqlParameter("@FechaClosing", cierre.FechaClosing),
                new SqlParameter("@MontoApertura", cierre.MontoApertura),
                new SqlParameter("@MontoEsperado", cierre.MontoEsperado),
                new SqlParameter("@MontoReal", cierre.MontoReal),
                new SqlParameter("@Diferencia", cierre.Diferencia),
                new SqlParameter("@Estado", cierre.Estado)
            };

            return bd.EjecutarComando(sql, parametros) > 0;
        }

        public bool EliminarCierre(int idCierre)
        {
            string sql = "DELETE FROM CierresCaja WHERE IdCierre = @IdCierre";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdCierre", idCierre)
            };

            return bd.EjecutarComando(sql, parametros) > 0;
        }

        private CierreCaja MapearCierre(DataRow row)
        {
            return new CierreCaja
            {
                IdCierre = (int)row["IdCierre"],
                IdUsuario = (int)row["IdUsuario"],
                FechaApertura = (DateTime)row["FechaApertura"],
                FechaClosing = row["FechaClosing"] != DBNull.Value ? (DateTime)row["FechaClosing"] : DateTime.MinValue,
                MontoApertura = (decimal)row["MontoApertura"],
                MontoEsperado = (decimal)row["MontoEsperado"],
                MontoReal = (decimal)row["MontoReal"],
                Diferencia = (decimal)row["Diferencia"],
                Estado = row["Estado"].ToString(),
                NombreUsuario = row["NombreUsuario"] != DBNull.Value ? row["NombreUsuario"].ToString() : ""
            };
        }
    }
}
