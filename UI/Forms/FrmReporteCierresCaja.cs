using System;
using System.Data;
using System.Windows.Forms;
using CarniceriaPOS.Data;

namespace CarniceriaPOS.UI.Forms
{
    public partial class FrmReporteCierresCaja : FrmReporteBase
    {
        private readonly RepositorioVenta _repVenta;

        public FrmReporteCierresCaja()
        {
            InitializeComponent();
            _repVenta = new RepositorioVenta();
        }

        protected override void FrmReporteBase_Load(object sender, EventArgs e)
        {
            lblTituloReporte.Text = "REPORTE DE CIERRE DE CAJA";
            GenerarReporte();
        }

        private void GenerarReporte()
        {
            try
            {
                var ventas     = _repVenta.ObtenerVentasPorFecha(DateTime.Today);
                decimal totalDia = 0;
                decimal efectivo = 0, tarjeta = 0, otro = 0;

                foreach (var v in ventas)
                {
                    totalDia += v.Total;
                    switch ((v.MetodoPago ?? "").ToUpper())
                    {
                        case "EFECTIVO": efectivo += v.Total; break;
                        case "TARJETA":  tarjeta  += v.Total; break;
                        default:         otro     += v.Total; break;
                    }
                }

                var dt = new DataTable();
                dt.Columns.Add("Hora", typeof(string));
                dt.Columns.Add("NA Venta", typeof(string));
                dt.Columns.Add("Cliente", typeof(string));
                dt.Columns.Add("Subtotal", typeof(string));
                dt.Columns.Add("Impuesto", typeof(string));
                dt.Columns.Add("Total", typeof(string));
                dt.Columns.Add("Metodo", typeof(string));

                foreach (var v in ventas)
                    dt.Rows.Add(
                        v.FechaVenta.ToString("hh:mm tt"),
                        v.NumeroFactura,
                        v.NombreCliente ?? "General",
                        $"${v.Subtotal:N2}",
                        $"${v.TotalITBIS:N2}",
                        $"${v.Total:N2}",
                        v.MetodoPago ?? "a""
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
