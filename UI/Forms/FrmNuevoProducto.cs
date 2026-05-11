using System;
using System.Windows.Forms;
using CarniceriaPOS.Models;
using CarniceriaPOS.Data;

namespace CarniceriaPOS.UI.Forms
{
    public partial class FrmNuevoProducto : Form
    {
        private RepositorioProducto _repo;

        public FrmNuevoProducto()
        {
            InitializeComponent();
            _repo = new RepositorioProducto();
        }

        private void FrmNuevoProducto_Load(object sender, EventArgs e)
        {
            CargarCombos();
        }

        private void CargarCombos()
        {
            cmbCategoria.Items.AddRange(new string[] { "Cortes de Res", "Cortes de Cerdo", "Embutidos", "Pollo", "Sazon" });
            cmbUnidadMedida.Items.AddRange(new string[] { "Kg", "Lb", "Unidad" });

            if (cmbCategoria.Items.Count > 0) cmbCategoria.SelectedIndex = 0;
            if (cmbUnidadMedida.Items.Count > 0) cmbUnidadMedida.SelectedIndex = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio");
                return;
            }

            try
            {
                Producto p = new Producto();
                p.CodigoBarras = txtCodigo.Text;
                p.Nombre = txtNombre.Text;
                p.Descripcion = txtDescripcion.Text;
                p.Categoria = cmbCategoria.Text;
                p.PrecioCompra = decimal.Parse(txtPrecioCompra.Text);
                p.PrecioVenta = decimal.Parse(txtPrecioVenta.Text);
                p.StockActual = decimal.Parse(txtStockActual.Text);
                p.StockMinimo = decimal.Parse(txtStockMinimo.Text);
                p.AplicaITBIS = chkItbis.Checked;
                p.Activo = true;

                if (_repo.AgregarProducto(p))
                {
                    MessageBox.Show("Producto agregado correctamente");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}