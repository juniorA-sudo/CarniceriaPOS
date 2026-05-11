using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CarniceriaPOS.Models;
using System.Windows.Forms;

namespace CarniceriaPOS.Data
{
    public class RepositorioProducto
    {
        private ConexionBD bd = new ConexionBD();

        public bool AgregarProducto(Producto producto)
        {
            try
            {
                string sql = @"INSERT INTO Productos (CodigoBarras, Nombre, Descripcion, Categoria,
                              IdUnidadMedida, PrecioCompra, PrecioVenta, StockActual, StockMinimo,
                              AplicaITBIS, Activo, FechaCreacion)
                              VALUES (@CodigoBarras, @Nombre, @Descripcion, @Categoria,
                              @IdUnidadMedida, @PrecioCompra, @PrecioVenta, @StockActual, @StockMinimo,
                              @AplicaITBIS, @Activo, @FechaCreacion)";

                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@CodigoBarras", producto.CodigoBarras ?? ""),
                    new SqlParameter("@Nombre", producto.Nombre ?? ""),
                    new SqlParameter("@Descripcion", producto.Descripcion ?? ""),
                    new SqlParameter("@Categoria", producto.Categoria ?? ""),
                    new SqlParameter("@IdUnidadMedida", producto.IdUnidadMedida),
                    new SqlParameter("@PrecioCompra", producto.PrecioCompra),
                    new SqlParameter("@PrecioVenta", producto.PrecioVenta),
                    new SqlParameter("@StockActual", producto.StockActual),
                    new SqlParameter("@StockMinimo", producto.StockMinimo),
                    new SqlParameter("@AplicaITBIS", producto.AplicaITBIS),
                    new SqlParameter("@Activo", producto.Activo),
                    new SqlParameter("@FechaCreacion", DateTime.Now)
                };

                return bd.EjecutarComando(sql, parametros) > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error preventivo al insertar: " + ex.Message);
                return false;
            }
        }

        public List<Producto> ObtenerTodos()
        {
            List<Producto> productos = new List<Producto>();
            try
            {
                string sql = @"SELECT p.*, 
                               u.Nombre as NombreUnidadMedida, 
                               u.Abreviatura as AbreviaturaUnidad
                          FROM Productos p
                          LEFT JOIN UnidadesMedida u ON p.IdUnidadMedida = u.IdUnidadMedida
                          WHERE p.Activo = 1
                          ORDER BY p.Nombre";

                DataTable dt = bd.ObtenerDatos(sql);
                if (dt == null) return productos;

                foreach (DataRow row in dt.Rows)
                {
                    productos.Add(MapearProducto(row));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error preventivo al cargar lista completa: " + ex.Message);
            }
            return productos;
        }

        public List<Producto> ObtenerProductosBajoStock()
        {
            List<Producto> productos = new List<Producto>();
            try
            {
                string sql = @"SELECT p.*, 
                               u.Nombre as NombreUnidadMedida, 
                               u.Abreviatura as AbreviaturaUnidad
                          FROM Productos p
                          LEFT JOIN UnidadesMedida u ON p.IdUnidadMedida = u.IdUnidadMedida
                          WHERE p.Activo = 1 AND p.StockActual <= p.StockMinimo
                          ORDER BY p.StockActual";

                DataTable dt = bd.ObtenerDatos(sql);
                if (dt == null) return productos;

                foreach (DataRow row in dt.Rows)
                {
                    productos.Add(MapearProducto(row));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error preventivo al cargar bajo stock: " + ex.Message);
            }
            return productos;
        }

        public Producto ObtenerProductoPorId(int idProducto)
        {
            try
            {
                string sql = @"SELECT p.*, u.Nombre as NombreUnidadMedida, u.Abreviatura as AbreviaturaUnidad
                              FROM Productos p
                              LEFT JOIN UnidadesMedida u ON p.IdUnidadMedida = u.IdUnidadMedida
                              WHERE p.IdProducto = @IdProducto";

                SqlParameter[] parametros = new SqlParameter[] { new SqlParameter("@IdProducto", idProducto) };
                DataTable dt = bd.ObtenerDatos(sql, parametros);

                if (dt != null && dt.Rows.Count > 0)
                {
                    return MapearProducto(dt.Rows[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error preventivo al obtener por ID: " + ex.Message);
            }
            return null;
        }

        public bool ActualizarProducto(Producto producto)
        {
            try
            {
                string sql = @"UPDATE Productos SET CodigoBarras = @CodigoBarras, Nombre = @Nombre,
                              Descripcion = @Descripcion, Categoria = @Categoria,
                              IdUnidadMedida = @IdUnidadMedida, PrecioCompra = @PrecioCompra,
                              PrecioVenta = @PrecioVenta, StockActual = @StockActual,
                              StockMinimo = @StockMinimo, AplicaITBIS = @AplicaITBIS
                              WHERE IdProducto = @IdProducto";

                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@IdProducto", producto.IdProducto),
                    new SqlParameter("@CodigoBarras", producto.CodigoBarras ?? ""),
                    new SqlParameter("@Nombre", producto.Nombre),
                    new SqlParameter("@Descripcion", producto.Descripcion ?? ""),
                    new SqlParameter("@Categoria", producto.Categoria ?? ""),
                    new SqlParameter("@IdUnidadMedida", producto.IdUnidadMedida),
                    new SqlParameter("@PrecioCompra", producto.PrecioCompra),
                    new SqlParameter("@PrecioVenta", producto.PrecioVenta),
                    new SqlParameter("@StockActual", producto.StockActual),
                    new SqlParameter("@StockMinimo", producto.StockMinimo),
                    new SqlParameter("@AplicaITBIS", producto.AplicaITBIS)
                };

                return bd.EjecutarComando(sql, parametros) > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error preventivo al actualizar: " + ex.Message);
                return false;
            }
        }

        public bool ActualizarStock(int idProducto, int cantidad)
        {
            try
            {
                string sql = "UPDATE Productos SET StockActual = StockActual + @Cantidad WHERE IdProducto = @IdProducto";
                SqlParameter[] parametros = new SqlParameter[] {
                    new SqlParameter("@IdProducto", idProducto),
                    new SqlParameter("@Cantidad", cantidad)
                };
                return bd.EjecutarComando(sql, parametros) > 0;
            }
            catch { return false; }
        }

        public bool EliminarProducto(int idProducto)
        {
            try
            {
                string sql = "UPDATE Productos SET Activo = 0 WHERE IdProducto = @IdProducto";
                SqlParameter[] parametros = new SqlParameter[] { new SqlParameter("@IdProducto", idProducto) };
                return bd.EjecutarComando(sql, parametros) > 0;
            }
            catch { return false; }
        }

        private Producto MapearProducto(DataRow row)
        {
            object SafeGet(string columnName, object defaultValue)
            {
                if (row.Table.Columns.Contains(columnName) && row[columnName] != DBNull.Value)
                    return row[columnName];

                if (columnName == "Descripcion" && row.Table.Columns.Contains("Descripcion"))
                    return row["Descripcion"];

                return defaultValue;
            }

            return new Producto
            {
                IdProducto = Convert.ToInt32(SafeGet("IdProducto", 0)),
                CodigoBarras = SafeGet("CodigoBarras", "").ToString(),
                Nombre = SafeGet("Nombre", "Sin Nombre").ToString(),
                Descripcion = SafeGet("Descripcion", "").ToString(),
                Categoria = SafeGet("Categoria", "").ToString(),
                IdUnidadMedida = Convert.ToInt32(SafeGet("IdUnidadMedida", 0)),
                PrecioCompra = Convert.ToDecimal(SafeGet("PrecioCompra", 0m)),
                PrecioVenta = Convert.ToDecimal(SafeGet("PrecioVenta", 0m)),
                StockActual = Convert.ToDecimal(SafeGet("StockActual", 0m)),
                StockMinimo = Convert.ToDecimal(SafeGet("StockMinimo", 0m)),
                AplicaITBIS = Convert.ToBoolean(SafeGet("AplicaITBIS", false)),
                Activo = Convert.ToBoolean(SafeGet("Activo", true)),
                FechaCreacion = Convert.ToDateTime(SafeGet("FechaCreacion", DateTime.Now)),
                NombreUnidadMedida = SafeGet("NombreUnidadMedida", "N/A").ToString(),
                AbreviacionUnidad = SafeGet("AbreviaturaUnidad", "").ToString()
            };
        }
    }
}
