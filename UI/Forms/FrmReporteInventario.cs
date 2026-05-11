using System;
using System.Data;
using System.Windows.Forms;
using CarniceriaPOS.Data;

namespace CarniceriaPOS.UI.Forms
{
    public partial class FrmReporteInventario : FrmReporteBase
    {
        private readonly RepositorioProducto _repProducto;

        public FrmReporteInventario()
        {
            InitializeComponent();
            _repProducto = new RepositorioProducto();
        }

        protected override void FrmReporteBase_Load(object sender, EventArgs e)
        {
            lblTituloReporte.Text = "REPORTE DE INVENTARIO ACTUAL";
            GenerarReporte();
        }

        private void GenerarReporte()
        {
            try
            {
                var productos = _repProducto.ObtenerTodos();

                var dt = new DataTable();
                dt.Columns.Add("Producto", typeof(string));
                dt.Columns.Add("CategorÃ­a", typeof(string));
                dt.Columns.Add("Stock Actual", typeof(int));
                dt.Columns.Add("Stock MÃ­nimo", typeof(int));
                dt.Columns.Add("P. Compra", typeof(string));
                dt.Columns.Add("P. Venta", typeof(string));
                dt.Columns.Add("Valor Total", typeof(string));
                dt.Columns.Add("Estado", typeof(string));

                foreach (var p in productos)
                    dt.Rows.Add(
                        p.Nombre,
                        p.Categoria ?? "Sin categorÃ­a",
                        p.StockActual,
                        p.StockMinimo,
                        $"${p.PrecioCompra:N2}",
                        $"${p.PrecioVenta:N2}",
                        $"${p.StockActual * p.PrecioCompra:N2}",
                        p.StockActual <= p.StockMinimo ? "BAJO" : "OK"
                    );

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
