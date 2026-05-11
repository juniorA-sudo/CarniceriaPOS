using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CarniceriaPOS.Models;

namespace CarniceriaPOS.Data
{
    public class RepositorioCompra
    {
        private ConexionBD bd = new ConexionBD();

        public bool AgregarCompra(Compra compra)
        {
            string sql = @"INSERT INTO Compras (NumeroFacturaProv, IdProveedor, IdUsuario, FechaCompra, Total, Estado)
                          VALUES (@NumeroFacturaProv, @IdProveedor, @IdUsuario, @FechaCompra, @Total, @Estado)";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@NumeroFacturaProv", compra.NumeroFacturaProv),
                new SqlParameter("@IdProveedor", compra.IdProveedor),
                new SqlParameter("@IdUsuario", compra.IdUsuario),
                new SqlParameter("@FechaCompra", compra.FechaCompra),
                new SqlParameter("@Total", compra.Total),
                new SqlParameter("@Estado", compra.Estado)
            };

            return bd.EjecutarComando(sql, parametros) > 0;
        }

        public bool AgregarDetalleCompra(DetalleCompra detalle)
        {
            string sql = @"INSERT INTO DetalleCompras (IdCompra, IdProducto, Cantidad,
                          PrecioUnitario, Subtotal)
                          VALUES (@IdCompra, @IdProducto, @Cantidad,
                          @PrecioUnitario, @Subtotal)";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdCompra", detalle.IdCompra),
                new SqlParameter("@IdProducto", detalle.IdProducto),
                new SqlParameter("@Cantidad", detalle.Cantidad),
                new SqlParameter("@PrecioUnitario", detalle.PrecioUnitario),
                new SqlParameter("@Subtotal", detalle.Subtotal)
            };

            return bd.EjecutarComando(sql, parametros) > 0;
        }

        public List<Compra> ObtenerComprasPorPeriodo(DateTime fechaInicio, DateTime fechaFin)
        {
            string sql = @"SELECT c.*, p.Nombre as NombreProveedor, u.NombreUsuario
                          FROM Compras c
                          LEFT JOIN Proveedores p ON c.IdProveedor = p.IdProveedor
                          LEFT JOIN Usuarios u ON c.IdUsuario = u.IdUsuario
                          WHERE c.FechaCompra >= @FechaInicio AND c.FechaCompra <= @FechaFin
                          ORDER BY c.FechaCompra DESC";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@FechaInicio", fechaInicio),
                new SqlParameter("@FechaFin", fechaFin.AddDays(1))
            };

            DataTable dt = bd.ObtenerDatos(sql, parametros);
            List<Compra> compras = new List<Compra>();

            foreach (DataRow row in dt.Rows)
            {
                compras.Add(MapearCompra(row));
            }
            return compras;
        }

        public List<Compra> ObtenerTodos()
        {
            string sql = @"SELECT c.*, p.Nombre as NombreProveedor, u.NombreUsuario
                          FROM Compras c
                          LEFT JOIN Proveedores p ON c.IdProveedor = p.IdProveedor
                          LEFT JOIN Usuarios u ON c.IdUsuario = u.IdUsuario
                          ORDER BY c.FechaCompra DESC";

            DataTable dt = bd.ObtenerDatos(sql);
            List<Compra> compras = new List<Compra>();

            foreach (DataRow row in dt.Rows)
            {
                compras.Add(MapearCompra(row));
            }
            return compras;
        }

        private Compra MapearCompra(DataRow row)
        {
            return new Compra
            {
                IdCompra = (int)row["IdCompra"],
                NumeroFacturaProv = row["NumeroFacturaProv"].ToString(),
                IdProveedor = (int)row["IdProveedor"],
                IdUsuario = (int)row["IdUsuario"],
                FechaCompra = (DateTime)row["FechaCompra"],
                Total = (decimal)row["Total"],
                Estado = row["Estado"].ToString(),
                NombreProveedor = row["NombreProveedor"] != DBNull.Value ? row["NombreProveedor"].ToString() : "",
                NombreUsuario = row["NombreUsuario"] != DBNull.Value ? row["NombreUsuario"].ToString() : ""
            };
        }
    }
}
