using System;
using System.Windows.Forms;

namespace CarniceriaPOS.UI.Forms
{
    public partial class FrmReporteCierresCaja : FrmReporteBase
    {
        public FrmReporteCierresCaja() : base()
        {
            this.lblTituloModulo.Text = "Reporte de Cierres de Caja";
            this.lblSubtituloHeader.Text = "Control y conciliacion de cierres diarios";
            this.lblTituloReporte.Text = "CIERRES DE CAJA";
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
                DgvDatos.Columns.Add("Monto", "Monto");
                DgvDatos.Columns.Add("Estado", "Estado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar reporte: " + ex.Message);
            }
        }
    }
}
