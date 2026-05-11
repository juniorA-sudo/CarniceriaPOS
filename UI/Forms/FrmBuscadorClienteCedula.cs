using System;
using System.Windows.Forms;
using CarniceriaPOS.Data;
using CarniceriaPOS.Models;

namespace CarniceriaPOS.UI.Forms
{
    public partial class FrmBuscadorClienteCedula : Form
    {
        private RepositorioCliente repCliente;
        public Cliente ClienteSeleccionado { get; set; }

        public FrmBuscadorClienteCedula()
        {
            InitializeComponent();
            repCliente = new RepositorioCliente();
        }

        private void FrmBuscadorClienteCedula_Load(object sender, EventArgs e)
        {
            txtCedula.Focus();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCedula.Text))
            {
                MessageBox.Show("Ingrese una cedula");
                return;
            }

            BuscarCliente();
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true;
                BuscarCliente();
            }
        }

        private void BuscarCliente()
        {
            try
            {
                Cliente cliente = repCliente.ObtenerClientePorCedula(txtCedula.Text);

                if (cliente != null)
                {
                    
                    ClienteSeleccionado = cliente;
                    MessageBox.Show($"Cliente encontrado: {cliente.Nombre}", "a‰xito");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    
                    if (MessageBox.Show(
                        "Cliente no encontrado.\nA?Desea crear un cliente nuevo con esta cedula?",
                        "Cliente no existe",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        CrearClienteNuevo();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void CrearClienteNuevo()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre del cliente");
                txtNombre.Focus();
                return;
            }

            try
            {
                Cliente nuevoCliente = new Cliente
                {
                    Nombre = txtNombre.Text,
                    Cedula = txtCedula.Text,
                    Telefono = "",
                    Email = "",
                    Direccion = "",
                    NIT = "",
                    Activo = true
                };

                if (repCliente.AgregarCliente(nuevoCliente))
                {
                    
                    ClienteSeleccionado = repCliente.ObtenerClientePorCedula(txtCedula.Text);
                    MessageBox.Show($"Cliente creado: {nuevoCliente.Nombre}\n\nPuede agregar mas datos despues", "a‰xito");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear cliente: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
