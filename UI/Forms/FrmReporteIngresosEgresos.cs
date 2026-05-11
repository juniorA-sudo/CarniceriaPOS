using System;
using System.Data;
using System.Windows.Forms;
using CarniceriaPOS.Data;

namespace CarniceriaPOS.UI.Forms
{
    public partial class FrmReporteIngresosEgresos : FrmReporteBase
    {
        private readonly RepositorioVenta  _repVenta;
        private readonly RepositorioCompra _repCompra;

        public FrmReporteIngresosEgresos()
        {
            InitializeComponent();
            _repVenta  = new RepositorioVenta();
            _repCompra = new RepositorioCompra();
        }

        protected override void FrmReporteBase_Load(object sender, EventArgs e)
        {
            lblTituloReporte.Text = "REPORTE DE INGRESOS VS EGRESOS (P&L)";
            GenerarReporte();
        }

        private void GenerarReporte()
        {
            try
            {
                var ventas  = _repVenta.ObtenerTodos();
                var compras = _repCompra.ObtenerTodos();

                decimal ingresos = 0, impVentas = 0;
                decimal egresos  = 0, impCompras = 0;

                foreach (var v in ventas)  { ingresos  += v.Total; impVentas  += v.TotalITBIS; }
                foreach (var c in compras) { egresos   += c.Total; impCompras += c.Total; }

                decimal ganancia = ingresos - egresos;
                decimal margen   = ingresos > 0 ? ganancia * 100m / ingresos : 0;

                var dt = new DataTable();
                dt.Columns.Add("Concepto", typeof(string));
                dt.Columns.Add("Cantidad", typeof(int));
                dt.Columns.Add("Monto (sin IVA)", typeof(string));
                dt.Columns.Add("IVA", typeof(string));
                dt.Columns.Add("Total", typeof(string));
                dt.Columns.Add("% sobre ingresos", typeof(string));

                decimal subIngresos = ingresos - impVentas;
                decimal subEgresos  = egresos  - impCompras;

                dt.Rows.Add("Ingresos por Ventas",    ventas.Count,  $"${subIngresos:N2}",  $"${impVentas:N2}",  $"${ingresos:N2}",  "100.0%");
                dt.Rows.Add("Egresos por Compras",    compras.Count, $"${subEgresos:N2}",   $"${impCompras:N2}", $"${egresos:N2}",   $"{(margen == 0 ? 0 : (egresos * 100m / ingresos)):N1}%");
                dt.Rows.Add("Ganancia Bruta (neta)",  ventas.Count - compras.Count, "a"", "a"", $"${ganancia:N2}", $"{margen:N1}%");

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
