using System;
using System.Windows.Forms;
using CarniceriaPOS.Models;
using CarniceriaPOS.Data;
using CarniceriaPOS.Utilities;

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
            ConfigurarTextBox();
            CargarCombos();
        }

        private void ConfigurarTextBox()
        {
            if (txtNombre != null)
                FormateadorTextBox.ConfigurarTextBox(txtNombre, FormateadorTextBox.TipoValidacion.SoloLetras);

            if (txtCodigo != null)
                FormateadorTextBox.ConfigurarTextBox(txtCodigo, FormateadorTextBox.TipoValidacion.Alfanumerico);

            if (txtDescripcion != null)
                FormateadorTextBox.ConfigurarTextBox(txtDescripcion, FormateadorTextBox.TipoValidacion.Alfanumerico);

            if (txtPrecioCompra != null)
                FormateadorTextBox.ConfigurarTextBox(txtPrecioCompra, FormateadorTextBox.TipoValidacion.Moneda);

            if (txtPrecioVenta != null)
                FormateadorTextBox.ConfigurarTextBox(txtPrecioVenta, FormateadorTextBox.TipoValidacion.Moneda);

            if (txtStockActual != null)
                FormateadorTextBox.ConfigurarTextBox(txtStockActual, FormateadorTextBox.TipoValidacion.SoloNumeros);

            if (txtStockMinimo != null)
                FormateadorTextBox.ConfigurarTextBox(txtStockMinimo, FormateadorTextBox.TipoValidacion.SoloNumeros);
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
