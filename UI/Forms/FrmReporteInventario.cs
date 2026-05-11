using System;
using System.Windows.Forms;

namespace CarniceriaPOS.UI.Forms
{
    public partial class FrmReporteInventario : FrmReporteBase
    {
        public FrmReporteInventario() : base()
        {
            this.lblTituloModulo.Text = "Reporte de Inventario";
            this.lblSubtituloHeader.Text = "Estado completo del inventario de productos";
            this.lblTituloReporte.Text = "INVENTARIO ACTUAL";
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
                DgvDatos.Columns.Add("Stock", "Stock");
                DgvDatos.Columns.Add("Valor", "Valor Total");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar reporte: " + ex.Message);
            }
        }
    }
}
