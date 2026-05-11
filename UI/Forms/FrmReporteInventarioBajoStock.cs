using System;
using System.Windows.Forms;

namespace CarniceriaPOS.UI.Forms
{
    public partial class FrmReporteInventarioBajoStock : FrmReporteBase
    {
        public FrmReporteInventarioBajoStock() : base()
        {
            this.lblTituloModulo.Text = "Reporte de Inventario Bajo Stock";
            this.lblSubtituloHeader.Text = "Productos que requieren reorden urgente";
            this.lblTituloReporte.Text = "INVENTARIO BAJO STOCK";
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
                DgvDatos.Columns.Add("StockActual", "Stock Actual");
                DgvDatos.Columns.Add("StockMinimo", "Stock Minimo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar reporte: " + ex.Message);
            }
        }
    }
}
