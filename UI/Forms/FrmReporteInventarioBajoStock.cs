using System;
using System.Data;
using System.Windows.Forms;
using CarniceriaPOS.Data;

namespace CarniceriaPOS.UI.Forms
{
    public partial class FrmReporteInventarioBajoStock : FrmReporteBase
    {
        private readonly RepositorioProducto _repProducto;

        public FrmReporteInventarioBajoStock()
        {
            InitializeComponent();
            _repProducto = new RepositorioProducto();
        }

        protected override void FrmReporteBase_Load(object sender, EventArgs e)
        {
            lblTituloReporte.Text = "REPORTE DE PRODUCTOS CON STOCK BAJO";
            GenerarReporte();
        }

        private void GenerarReporte()
        {
            try
            {
                var productos = _repProducto.ObtenerProductosBajoStock();

                var dt = new DataTable();
                dt.Columns.Add("Producto", typeof(string));
                dt.Columns.Add("Categoria", typeof(string));
                dt.Columns.Add("Stock Actual", typeof(int));
                dt.Columns.Add("Stock Minimo", typeof(int));
                dt.Columns.Add("Faltante", typeof(int));
                dt.Columns.Add("P. Compra", typeof(string));
                dt.Columns.Add("Costo Repo.", typeof(string));
                dt.Columns.Add("Prioridad", typeof(string));

                foreach (var p in productos)
                {
                    decimal faltante = p.StockMinimo - p.StockActual;
                    string prioridad = p.StockActual == 0 ? "SIN STOCK"
                        : p.StockActual < p.StockMinimo / 2 ? "URGENTE"
                        : "BAJO";

                    dt.Rows.Add(
                        p.Nombre,
                        p.Categoria ?? "a”",
                        p.StockActual,
                        p.StockMinimo,
                        faltante,
                        $"${p.PrecioCompra:N2}",
                        $"${faltante * p.PrecioCompra:N2}",
                        prioridad
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
