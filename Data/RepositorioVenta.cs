using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CarniceriaPOS.Models;

namespace CarniceriaPOS.Data
{
    public class RepositorioVenta
    {
        private ConexionBD bd = new ConexionBD();

        public bool AgregarVenta(Venta venta)
        {
            // CORRECCIÓN: Se usa @IdEmpleado para ser consistente con el objeto y la tabla
            string sql = @"INSERT INTO Ventas (NumeroFactura, IdCliente, IdEmpleado, FechaVenta,
                          Subtotal, TotalITBIS, Total, MetodoPago, Estado,
                          MontoRecibido, Cambio)
                          VALUES (@NumeroFactura, @IdCliente, @IdEmpleado, @FechaVenta,
                          @Subtotal, @TotalITBIS, @Total, @MetodoPago, @Estado,
                          @MontoRecibido, @Cambio)";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@NumeroFactura", venta.NumeroFactura),
                new SqlParameter("@IdCliente", venta.IdCliente ?? (object)DBNull.Value),
                new SqlParameter("@IdEmpleado", venta.IdEmpleado),
                new SqlParameter("@FechaVenta", venta.FechaVenta),
                new SqlParameter("@Subtotal", venta.Subtotal),
                new SqlParameter("@TotalITBIS", venta.TotalITBIS),
                new SqlParameter("@Total", venta.Total),
                new SqlParameter("@MetodoPago", venta.MetodoPago),
                new SqlParameter("@Estado", venta.Estado),
                new SqlParameter("@MontoRecibido", venta.MontoRecibido),
                new SqlParameter("@Cambio", venta.Cambio)
            };

            return bd.EjecutarComando(sql, parametros) > 0;
        }

        public int ObtenerUltimoNumeroFactura(string prefijoFecha)
        {
            // CORRECCIÓN: Cambié SUBSTRING(12,4) por una lógica más flexible que busca el número después del último guion
            // Esto evita errores si el prefijo cambia de longitud.
            string sql = @"SELECT ISNULL(MAX(CAST(REVERSE(LEFT(REVERSE(NumeroFactura), CHARINDEX('-', REVERSE(NumeroFactura)) - 1)) AS INT)), 0)
                           FROM Ventas
                           WHERE NumeroFactura LIKE @Prefijo + '%'";

            SqlParameter[] parametros = new SqlParameter[]
            {
                // Asegúrate que el prefijo coincida con lo que generas (ej: "VT-20231027-")
                new SqlParameter("@Prefijo", prefijoFecha)
            };

            object resultado = bd.ObtenerEscalar(sql, parametros);
            return resultado != null && resultado != DBNull.Value ? Convert.ToInt32(resultado) : 0;
        }

        // CORRECCIÓN: En todas las consultas SELECT, cambié IdUsuario por IdEmpleado 
        // para que coincida con tu INSERT.
        public List<Venta> ObtenerVentasPorFecha(DateTime fecha)
        {
            string sql = @"SELECT v.*, c.Nombre as NombreCliente, u.NombreUsuario
                          FROM Ventas v
                          LEFT JOIN Clientes c ON v.IdCliente = c.IdCliente
                          LEFT JOIN Usuarios u ON v.IdEmpleado = u.IdUsuario
                          WHERE CAST(v.FechaVenta as DATE) = @Fecha
                          ORDER BY v.FechaVenta DESC";

            SqlParameter[] parametros = { new SqlParameter("@Fecha", fecha.Date) };
            DataTable dt = bd.ObtenerDatos(sql, parametros);
            List<Venta> ventas = new List<Venta>();

            foreach (DataRow row in dt.Rows) ventas.Add(MapearVenta(row));
            return ventas;
        }

        public List<Venta> ObtenerVentasPorPeriodoYUsuario(DateTime fechaInicio, DateTime fechaFin, int? idUsuario = null)
        {
            string sql = @"SELECT v.*, c.Nombre as NombreCliente, u.NombreUsuario
                          FROM Ventas v
                          LEFT JOIN Clientes c ON v.IdCliente = c.IdCliente
                          LEFT JOIN Usuarios u ON v.IdEmpleado = u.IdUsuario
                          WHERE CAST(v.FechaVenta as DATE) >= @FechaInicio AND CAST(v.FechaVenta as DATE) <= @FechaFin";

            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@FechaInicio", fechaInicio.Date),
                new SqlParameter("@FechaFin", fechaFin.Date)
            };

            if (idUsuario.HasValue)
            {
                sql += " AND v.IdEmpleado = @IdUsuario"; // Corregido a IdEmpleado
                parametros.Add(new SqlParameter("@IdUsuario", idUsuario.Value));
            }

            sql += " ORDER BY v.FechaVenta DESC";
            DataTable dt = bd.ObtenerDatos(sql, parametros.ToArray());
            List<Venta> ventas = new List<Venta>();
            foreach (DataRow row in dt.Rows) ventas.Add(MapearVenta(row));
            return ventas;
        }

        private Venta MapearVenta(DataRow row)
        {
            return new Venta
            {
                IdVenta = (int)row["IdVenta"],
                NumeroFactura = row["NumeroFactura"].ToString(),
                IdCliente = row["IdCliente"] != DBNull.Value ? (int?)row["IdCliente"] : null,
                IdEmpleado = (int)row["IdEmpleado"], // Consistente con la tabla
                FechaVenta = (DateTime)row["FechaVenta"],
                Subtotal = (decimal)row["Subtotal"],
                TotalITBIS = (decimal)row["TotalITBIS"],
                Total = (decimal)row["Total"],
                MetodoPago = row["MetodoPago"].ToString(),
                Estado = row["Estado"].ToString(),
                NombreCliente = row["NombreCliente"] != DBNull.Value ? row["NombreCliente"].ToString() : "Cliente General",
                NombreUsuario = row["NombreUsuario"] != DBNull.Value ? row["NombreUsuario"].ToString() : "N/A",
                MontoRecibido = row["MontoRecibido"] != DBNull.Value ? (decimal)row["MontoRecibido"] : 0,
                Cambio = row["Cambio"] != DBNull.Value ? (decimal)row["Cambio"] : 0
            };
        }

        // Otros métodos (AgregarDetalleVenta, etc.) se mantienen igual si las tablas DetalleVentas están correctas.
    }
}