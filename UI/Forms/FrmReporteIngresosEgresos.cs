using System;
using System.Windows.Forms;

namespace CarniceriaPOS.UI.Forms
{
    public partial class FrmReporteIngresosEgresos : FrmReporteBase
    {
        public FrmReporteIngresosEgresos() : base()
        {
            this.lblTituloModulo.Text = "Reporte de Ingresos vs Egresos";
            this.lblSubtituloHeader.Text = "Analisis financiero completo del periodo";
            this.lblTituloReporte.Text = "INGRESOS VS EGRESOS";
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
                DgvDatos.Columns.Add("Concepto", "Concepto");
                DgvDatos.Columns.Add("Ingresos", "Ingresos");
                DgvDatos.Columns.Add("Egresos", "Egresos");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar reporte: " + ex.Message);
            }
        }
    }
}
