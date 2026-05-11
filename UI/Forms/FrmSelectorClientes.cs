using System;
using System.Windows.Forms;
using CarniceriaPOS.Data;
using CarniceriaPOS.Models;

namespace CarniceriaPOS.UI.Forms
{
    public partial class FrmSelectorClientes : Form
    {
        private RepositorioCliente repCliente;
        public Cliente ClienteSeleccionado { get; set; }

        public FrmSelectorClientes()
        {
            InitializeComponent();
            repCliente = new RepositorioCliente();
        }

        private void FrmSelectorClientes_Load(object sender, EventArgs e)
        {
            this.Text = "Seleccionar Cliente";
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            ConfigurarDataGridView();
            CargarClientes();
        }

        private void ConfigurarDataGridView()
        {
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.ReadOnly = true;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.MultiSelect = false;

            dgvClientes.Columns.Clear();
            dgvClientes.Columns.Add("IdCliente", "ID");
            dgvClientes.Columns.Add("Nombre", "Nombre");
            dgvClientes.Columns.Add("Telefono", "Telefono");
            dgvClientes.Columns.Add("Email", "Email");
            dgvClientes.Columns.Add("RNC", "RNC");

            dgvClientes.Columns["IdCliente"].Width = 50;
            dgvClientes.Columns["Nombre"].Width = 150;
            dgvClientes.Columns["Telefono"].Width = 120;
            dgvClientes.Columns["Email"].Width = 150;
            dgvClientes.Columns["RNC"].Width = 100;
        }

        private void CargarClientes()
        {
            try
            {
                dgvClientes.Rows.Clear();
                var clientes = repCliente.ObtenerTodos();

                if (clientes != null && clientes.Count > 0)
                {
                    foreach (var cliente in clientes)
                    {
                        dgvClientes.Rows.Add(
                            cliente.IdCliente,
                            cliente.Nombre,
                            cliente.Telefono ?? "",
                            cliente.Email ?? "",
                            cliente.RNC ?? ""
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string filtro = txtBusqueda.Text.ToLower();
                dgvClientes.Rows.Clear();

                var clientes = repCliente.ObtenerTodos();

                if (clientes != null)
                {
                    foreach (var cliente in clientes)
                    {
                        if (cliente.Nombre.ToLower().Contains(filtro) ||
                            (cliente.Telefono != null && cliente.Telefono.Contains(filtro)) ||
                            (cliente.Email != null && cliente.Email.ToLower().Contains(filtro)) ||
                            (cliente.RNC != null && cliente.RNC.Contains(filtro)))
                        {
                            dgvClientes.Rows.Add(
                                cliente.IdCliente,
                                cliente.Nombre,
                                cliente.Telefono ?? "",
                                cliente.Email ?? "",
                                cliente.RNC ?? ""
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en baosqueda: " + ex.Message);
            }
        }

        private void dgvClientes_DoubleClick(object sender, EventArgs e)
        {
            SeleccionarCliente();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            SeleccionarCliente();
        }

        private void SeleccionarCliente()
        {
            if (dgvClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor selecciona un cliente", "Advertencia");
                return;
            }

            try
            {
                var row = dgvClientes.SelectedRows[0];
                int idCliente = (int)row.Cells["IdCliente"].Value;

                ClienteSeleccionado = repCliente.ObtenerClientePorId(idCliente);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnClienteGeneral_Click(object sender, EventArgs e)
        {
            ClienteSeleccionado = new Cliente
            {
                IdCliente = 0,
                Nombre = "Cliente General",
                Activo = true
            };
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
