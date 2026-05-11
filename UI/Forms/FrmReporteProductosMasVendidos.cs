using System;
using System.Data;
using System.Windows.Forms;
using CarniceriaPOS.Data;

namespace CarniceriaPOS.UI.Forms
{
    public partial class FrmReporteProductosMasVendidos : FrmReporteBase
    {
        private readonly RepositorioProducto _repProducto;

        public FrmReporteProductosMasVendidos()
        {
            InitializeComponent();
            _repProducto = new RepositorioProducto();
        }

        protected override void FrmReporteBase_Load(object sender, EventArgs e)
        {
            lblTituloReporte.Text = "REPORTE DE PRODUCTOS a€” CATÃLOGO Y PRECIOS";
            GenerarReporte();
        }

        private void GenerarReporte()
        {
            try
            {
                var productos = _repProducto.ObtenerTodos();

                var dt = new DataTable();
                dt.Columns.Add("#", typeof(int));
                dt.Columns.Add("Producto", typeof(string));
                dt.Columns.Add("CategorÃ­a", typeof(string));
                dt.Columns.Add("Stock", typeof(int));
                dt.Columns.Add("P. Costo", typeof(string));
                dt.Columns.Add("P. Venta", typeof(string));
                dt.Columns.Add("Margen", typeof(string));
                dt.Columns.Add("Valor Stock", typeof(string));

                int rank = 1;
                foreach (var p in productos)
                {
                    decimal margen = p.PrecioCompra > 0
                        ? (p.PrecioVenta - p.PrecioCompra) * 100m / p.PrecioCompra
                        : 0;
                    dt.Rows.Add(
                        rank++,
                        p.Nombre,
                        p.Categoria ?? "a€”",
                        p.StockActual,
                        $"${p.PrecioCompra:N2}",
                        $"${p.PrecioVenta:N2}",
                        $"{margen:N0}%",
                        $"${p.StockActual * p.PrecioVenta:N2}"
                    );
                }

                DgvDatos.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar reporte: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
