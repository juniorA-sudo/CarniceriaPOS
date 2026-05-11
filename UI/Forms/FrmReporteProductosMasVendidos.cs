using System;
using System.Windows.Forms;

namespace CarniceriaPOS.UI.Forms
{
    public partial class FrmReporteProductosMasVendidos : FrmReporteBase
    {
        public FrmReporteProductosMasVendidos() : base()
        {
            this.lblTituloModulo.Text = "Reporte de Productos Mas Vendidos";
            this.lblSubtituloHeader.Text = "Analisis de productos con mayor demanda";
            this.lblTituloReporte.Text = "PRODUCTOS MAS VENDIDOS";
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
                DgvDatos.Columns.Add("Producto", "Producto");
                DgvDatos.Columns.Add("Cantidad", "Cantidad");
                DgvDatos.Columns.Add("Ingresos", "Ingresos");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar reporte: " + ex.Message);
            }
        }
    }
}
