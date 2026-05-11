using System;
using System.Data;
using System.Windows.Forms;
using CarniceriaPOS.Data;

namespace CarniceriaPOS.UI.Forms
{
    public partial class FrmReporteCompras : FrmReporteBase
    {
        private readonly RepositorioCompra _repCompra;
        private readonly DateTime _inicio, _fin;

        public FrmReporteCompras(DateTime inicio, DateTime fin)
        {
            InitializeComponent();
            _inicio = inicio;
            _fin    = fin;
            _repCompra = new RepositorioCompra();
        }

        protected override void FrmReporteBase_Load(object sender, EventArgs e)
        {
            lblTituloReporte.Text = $"REPORTE DE COMPRAS a" {_inicio:dd/MM/yyyy} al {_fin:dd/MM/yyyy}";
            GenerarReporte();
        }

        private void GenerarReporte()
        {
            try
            {
                var compras = _repCompra.ObtenerComprasPorPeriodo(_inicio, _fin);

                var dt = new DataTable();
                dt.Columns.Add("NA Factura", typeof(string));
                dt.Columns.Add("Proveedor", typeof(string));
                dt.Columns.Add("Fecha", typeof(string));
                dt.Columns.Add("Total", typeof(string));
                dt.Columns.Add("Estado", typeof(string));

                foreach (var c in compras)
                    dt.Rows.Add(
                        c.NumeroFacturaProv,
                        c.NombreProveedor ?? "a"",
                        c.FechaCompra.ToString("dd/MM/yyyy"),
                        $"${c.Total:N2}",
                        c.Estado ?? "Completada"
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
