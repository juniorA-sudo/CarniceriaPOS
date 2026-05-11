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
            string sql = @"INSERT INTO Ventas (NumeroFactura, IdCliente, IdUsuario, FechaVenta,
                          Subtotal, TotalITBIS, Total, MetodoPago, Estado,
                          MontoRecibido, Cambio)
                          VALUES (@NumeroFactura, @IdCliente, @IdUsuario, @FechaVenta,
                          @Subtotal, @TotalITBIS, @Total, @MetodoPago, @Estado,
                          @MontoRecibido, @Cambio)";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@NumeroFactura", venta.NumeroFactura),
                new SqlParameter("@IdCliente", venta.IdCliente ?? (object)DBNull.Value),
                new SqlParameter("@IdUsuario", venta.IdUsuario),
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

        public int ObtenerIdVentaUltima()
        {
            string sql = "SELECT IDENT_CURRENT('Ventas')";
            object resultado = bd.ObtenerEscalar(sql);
            if (resultado != null && resultado != DBNull.Value)
            {
                return int.Parse(resultado.ToString());
            }
            return 0;
        }

        public int ObtenerUltimoNumeroFactura(string prefijoFecha)
        {
            string sql = @"SELECT ISNULL(MAX(CAST(SUBSTRING(NumeroFactura, 12, 4) AS INT)), 0)
                           FROM Ventas
                           WHERE NumeroFactura LIKE @Prefijo + '%'";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Prefijo", $"VT-{prefijoFecha}")
            };

            object resultado = bd.ObtenerEscalar(sql, parametros);
            return resultado != null && resultado != DBNull.Value ? Convert.ToInt32(resultado) : 0;
        }

        public bool AgregarDetalleVenta(DetalleVenta detalle)
        {
            string sql = @"INSERT INTO DetalleVentas (IdVenta, IdProducto, Cantidad,
                          PrecioUnitario, Descuento, Subtotal, Peso, TipoCantidad)
                          VALUES (@IdVenta, @IdProducto, @Cantidad,
                          @PrecioUnitario, @Descuento, @Subtotal, @Peso, @TipoCantidad)";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdVenta", detalle.IdVenta),
                new SqlParameter("@IdProducto", detalle.IdProducto),
                new SqlParameter("@Cantidad", detalle.Cantidad),
                new SqlParameter("@PrecioUnitario", detalle.PrecioUnitario),
                new SqlParameter("@Descuento", detalle.Descuento),
                new SqlParameter("@Subtotal", detalle.Subtotal),
                new SqlParameter("@Peso", detalle.Peso),
                new SqlParameter("@TipoCantidad", detalle.TipoCantidad ?? "Unidad")
            };

            return bd.EjecutarComando(sql, parametros) > 0;
        }

        public List<Venta> ObtenerVentasPorFecha(DateTime fecha)
        {
            string sql = @"SELECT v.*, c.Nombre as NombreCliente, u.NombreUsuario
                          FROM Ventas v
                          LEFT JOIN Clientes c ON v.IdCliente = c.IdCliente
                          LEFT JOIN Usuarios u ON v.IdUsuario = u.IdUsuario
                          WHERE CAST(v.FechaVenta as DATE) = @Fecha
                          ORDER BY v.FechaVenta DESC";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Fecha", fecha.Date)
            };

            DataTable dt = bd.ObtenerDatos(sql, parametros);
            List<Venta> ventas = new List<Venta>();

            foreach (DataRow row in dt.Rows)
            {
                ventas.Add(MapearVenta(row));
            }
            return ventas;
        }

        public List<Venta> ObtenerVentasPorPeriodo(DateTime fechaInicio, DateTime fechaFin)
        {
            string sql = @"SELECT v.*, c.Nombre as NombreCliente, u.NombreUsuario
                          FROM Ventas v
                          LEFT JOIN Clientes c ON v.IdCliente = c.IdCliente
                          LEFT JOIN Usuarios u ON v.IdUsuario = u.IdUsuario
                          WHERE v.FechaVenta >= @FechaInicio AND v.FechaVenta <= @FechaFin
                          ORDER BY v.FechaVenta DESC";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@FechaInicio", fechaInicio),
                new SqlParameter("@FechaFin", fechaFin.AddDays(1))
            };

            DataTable dt = bd.ObtenerDatos(sql, parametros);
            List<Venta> ventas = new List<Venta>();

            foreach (DataRow row in dt.Rows)
            {
                ventas.Add(MapearVenta(row));
            }
            return ventas;
        }

        public List<Venta> ObtenerVentasPorPeriodoYUsuario(DateTime fechaInicio, DateTime fechaFin, int? idUsuario = null)
        {
            string sql = @"SELECT v.*, c.Nombre as NombreCliente, u.NombreUsuario
                          FROM Ventas v
                          LEFT JOIN Clientes c ON v.IdCliente = c.IdCliente
                          LEFT JOIN Usuarios u ON v.IdUsuario = u.IdUsuario
                          WHERE CAST(v.FechaVenta as DATE) >= @FechaInicio AND CAST(v.FechaVenta as DATE) <= @FechaFin";

            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@FechaInicio", fechaInicio.Date),
                new SqlParameter("@FechaFin", fechaFin.Date)
            };

            if (idUsuario.HasValue)
            {
                sql += " AND v.IdUsuario = @IdUsuario";
                parametros.Add(new SqlParameter("@IdUsuario", idUsuario.Value));
            }

            sql += " ORDER BY v.FechaVenta DESC";

            DataTable dt = bd.ObtenerDatos(sql, parametros.ToArray());
            List<Venta> ventas = new List<Venta>();

            foreach (DataRow row in dt.Rows)
            {
                ventas.Add(MapearVenta(row));
            }
            return ventas;
        }

        public decimal ObtenerTotalVentasPorFecha(DateTime fecha)
        {
            string sql = @"SELECT ISNULL(SUM(Total), 0) FROM Ventas
                          WHERE CAST(FechaVenta as DATE) = @Fecha";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Fecha", fecha.Date)
            };

            object resultado = bd.ObtenerEscalar(sql, parametros);
            if (resultado != null && resultado != DBNull.Value)
            {
                return decimal.Parse(resultado.ToString());
            }
            return 0;
        }

        public List<Venta> ObtenerTodos()
        {
            string sql = @"SELECT v.*, c.Nombre as NombreCliente, u.NombreUsuario
                          FROM Ventas v
                          LEFT JOIN Clientes c ON v.IdCliente = c.IdCliente
                          LEFT JOIN Usuarios u ON v.IdUsuario = u.IdUsuario
                          ORDER BY v.FechaVenta DESC";

            DataTable dt = bd.ObtenerDatos(sql);
            List<Venta> ventas = new List<Venta>();

            foreach (DataRow row in dt.Rows)
            {
                ventas.Add(MapearVenta(row));
            }
            return ventas;
        }

        public int ContarTotalVentas()
        {
            string sql = "SELECT COUNT(*) as Total FROM Ventas";
            object resultado = bd.ObtenerEscalar(sql);
            if (resultado != null && resultado != DBNull.Value)
            {
                return int.Parse(resultado.ToString());
            }
            return 0;
        }

        public DataTable ObtenerRangoFechasVentas()
        {
            string sql = @"SELECT
                            MIN(CAST(FechaVenta as DATE)) as FechaMinima,
                            MAX(CAST(FechaVenta as DATE)) as FechaMaxima,
                            COUNT(*) as TotalRegistros
                          FROM Ventas";

            return bd.ObtenerDatos(sql);
        }

        public bool ActualizarDetalleVenta(DetalleVenta detalle)
        {
            string sql = @"UPDATE DetalleVentas
                          SET Cantidad = @Cantidad, PrecioUnitario = @PrecioUnitario,
                              Descuento = @Descuento, Subtotal = @Subtotal,
                              Peso = @Peso, TipoCantidad = @TipoCantidad
                          WHERE IdDetalle = @IdDetalle";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdDetalle", detalle.IdDetalle),
                new SqlParameter("@Cantidad", detalle.Cantidad),
                new SqlParameter("@PrecioUnitario", detalle.PrecioUnitario),
                new SqlParameter("@Descuento", detalle.Descuento),
                new SqlParameter("@Subtotal", detalle.Subtotal),
                new SqlParameter("@Peso", detalle.Peso),
                new SqlParameter("@TipoCantidad", detalle.TipoCantidad ?? "Unidad")
            };

            return bd.EjecutarComando(sql, parametros) > 0;
        }

        public bool EliminarDetalleVenta(int idDetalle)
        {
            string sql = "DELETE FROM DetalleVentas WHERE IdDetalle = @IdDetalle";
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdDetalle", idDetalle)
            };
            return bd.EjecutarComando(sql, parametros) > 0;
        }

        public List<Venta> ObtenerVentasDelDia(DateTime fecha)
        {
            return ObtenerVentasPorFecha(fecha);
        }

        private Venta MapearVenta(DataRow row)
        {
            var venta = new Venta
            {
                IdVenta = (int)row["IdVenta"],
                NumeroFactura = row["NumeroFactura"].ToString(),
                IdCliente = row["IdCliente"] != DBNull.Value ? (int?)row["IdCliente"] : null,
                IdUsuario = (int)row["IdUsuario"],
                FechaVenta = (DateTime)row["FechaVenta"],
                Subtotal = (decimal)row["Subtotal"],
                TotalITBIS = (decimal)row["TotalITBIS"],
                Total = (decimal)row["Total"],
                MetodoPago = row["MetodoPago"].ToString(),
                Estado = row["Estado"].ToString(),
                NombreCliente = row["NombreCliente"] != DBNull.Value ? row["NombreCliente"].ToString() : "Cliente General",
                NombreUsuario = row["NombreUsuario"] != DBNull.Value ? row["NombreUsuario"].ToString() : "",
                MontoRecibido = row["MontoRecibido"] != DBNull.Value ? (decimal)row["MontoRecibido"] : 0,
                Cambio = row["Cambio"] != DBNull.Value ? (decimal)row["Cambio"] : 0
            };
            return venta;
        }
    }
}
