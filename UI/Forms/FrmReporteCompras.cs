using System;
using System.Windows.Forms;

namespace CarniceriaPOS.UI.Forms
{
    public partial class FrmReporteCompras : FrmReporteBase
    {
        private DateTime _desde, _hasta;

        public FrmReporteCompras(DateTime desde, DateTime hasta) : base()
        {
            _desde = desde;
            _hasta = hasta;
            this.lblTituloModulo.Text = "Reporte de Compras";
            this.lblSubtituloHeader.Text = $"Compras desde {_desde:dd/MM/yyyy} hasta {_hasta:dd/MM/yyyy}";
            this.lblTituloReporte.Text = "HISTORIAL DE COMPRAS";
        }

        protected override void FrmReporteBase_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                DgvDatos.Columns.Clear();
                DgvDatos.Columns.Add("Fecha", "Fecha");
                DgvDatos.Columns.Add("Proveedor", "Proveedor");
                DgvDatos.Columns.Add("Monto", "Monto");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar reporte: " + ex.Message);
            }
        }
    }
}
