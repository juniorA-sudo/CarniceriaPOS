using System;
using System.Windows.Forms;
using CarniceriaPOS.Models;
using CarniceriaPOS.Data;

namespace CarniceriaPOS.UI.Forms
{
    public partial class FrmEditarProducto : Form
    {
        private RepositorioProducto _repo;
        private Producto _producto;

        public FrmEditarProducto(Producto producto)
        {
            InitializeComponent();
            _repo = new RepositorioProducto();
            _producto = producto;
        }

        private void FrmEditarProducto_Load(object sender, EventArgs e)
        {
            CargarCombos();
            MapearProductoAForm();
        }

        private void CargarCombos()
        {
            cmbCategoria.Items.AddRange(new string[] { "Cortes de Res", "Cortes de Cerdo", "Embutidos", "Pollo", "Sazon" });
            cmbUnidadMedida.Items.AddRange(new string[] { "Kg", "Lb", "Unidad" });
        }

        private void MapearProductoAForm()
        {
            txtCodigo.Text = _producto.CodigoBarras;
            txtNombre.Text = _producto.Nombre;
            txtDescripcion.Text = _producto.Descripcion;
            cmbCategoria.Text = _producto.Categoria;
            txtPrecioCompra.Text = _producto.PrecioCompra.ToString();
            txtPrecioVenta.Text = _producto.PrecioVenta.ToString();
            txtStockActual.Text = _producto.StockActual.ToString();
            txtStockMinimo.Text = _producto.StockMinimo.ToString();
            chkItbis.Checked = _producto.AplicaITBIS;
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
                _producto.CodigoBarras = txtCodigo.Text;
                _producto.Nombre = txtNombre.Text;
                _producto.Descripcion = txtDescripcion.Text;
                _producto.Categoria = cmbCategoria.Text;
                _producto.PrecioCompra = decimal.Parse(txtPrecioCompra.Text);
                _producto.PrecioVenta = decimal.Parse(txtPrecioVenta.Text);
                _producto.StockActual = decimal.Parse(txtStockActual.Text);
                _producto.StockMinimo = decimal.Parse(txtStockMinimo.Text);
                _producto.AplicaITBIS = chkItbis.Checked;

                if (_repo.ActualizarProducto(_producto))
                {
                    MessageBox.Show("Producto actualizado correctamente");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
