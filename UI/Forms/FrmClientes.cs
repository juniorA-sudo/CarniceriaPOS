using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using CarniceriaPOS.Data;
using CarniceriaPOS.Business;
using CarniceriaPOS.Models;
using CarniceriaPOS.Utilities;

namespace CarniceriaPOS.UI.Forms
{
    public partial class FrmClientes : Form
    {
        private RepositorioCliente repCliente;
        private bool esNuevo = true;

        public FrmClientes()
        {
            try
            {
                InitializeComponent();
                repCliente = new RepositorioCliente();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inicializar FrmClientes: " + ex.Message);
                throw;
            }
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            try
            {
                if (!SesionActual.TieneAcceso("Clientes"))
                {
                    MessageBox.Show("No tiene permiso para acceder a la gestion de clientes.",
                        "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LogAuditoria.RegistrarAccesoDenegado("Clientes", SesionActual.UsuarioActual?.IdUsuario ?? 0);
                    this.Close();
                    return;
                }

                ConfigurarValidacionesFormulario();
                CargarClientes();
                ActualizarPie();
                HabilitarDeshabilitarBotones(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el formulario: " + ex.Message);
            }
        }

        
        
        
        private void ConfigurarValidacionesFormulario()
        {
            FormateadorTextBox.ConfigurarTextBox(txtCedula, FormateadorTextBox.TipoValidacion.Cedula);
            FormateadorTextBox.ConfigurarTextBox(txtNombre, FormateadorTextBox.TipoValidacion.SoloLetras, 100);
            FormateadorTextBox.ConfigurarTextBox(txtTelefono, FormateadorTextBox.TipoValidacion.Telefono);
            FormateadorTextBox.ConfigurarTextBox(txtRNC, FormateadorTextBox.TipoValidacion.RNC);
            FormateadorTextBox.ConfigurarTextBox(txtLimiteCredito, FormateadorTextBox.TipoValidacion.Moneda, 15);
        }

        
        
        
        private void CargarClientes()
        {
            try
            {
                var clientes = repCliente.ObtenerTodos();

                if (dgvClientes.Columns.Count == 0)
                {
                    dgvClientes.Columns.Add("IdCliente", "ID");
                    dgvClientes.Columns.Add("Nombre", "Nombre");
                    dgvClientes.Columns.Add("Cedula", "Cedula");
                    dgvClientes.Columns.Add("RNC", "RNC");
                    dgvClientes.Columns.Add("Telefono", "Telefono");
                    dgvClientes.Columns.Add("LimiteCredito", "Limite Credito");

                    dgvClientes.Columns["IdCliente"].DataPropertyName = "IdCliente";
                    dgvClientes.Columns["Nombre"].DataPropertyName = "Nombre";
                    dgvClientes.Columns["Cedula"].DataPropertyName = "Cedula";
                    dgvClientes.Columns["RNC"].DataPropertyName = "RNC";
                    dgvClientes.Columns["Telefono"].DataPropertyName = "Telefono";
                    dgvClientes.Columns["LimiteCredito"].DataPropertyName = "LimiteCredito";

                    dgvClientes.Columns["IdCliente"].Width = 40;
                    dgvClientes.Columns["Nombre"].Width = 150;
                    dgvClientes.Columns["Cedula"].Width = 110;
                    dgvClientes.Columns["RNC"].Width = 100;
                    dgvClientes.Columns["Telefono"].Width = 100;
                    dgvClientes.Columns["LimiteCredito"].Width = 120;
                }

                dgvClientes.DataSource = clientes;
                lblTotal.Text = $"Total Clientes: {clientes.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }

        
        
        
        private bool ValidarCampos()
        {
            if (!Validador.ValidarCampoObligatorio(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre del cliente");
                txtNombre.Focus();
                return false;
            }

            if (!Validador.ValidarSoloLetras(txtNombre.Text))
            {
                MessageBox.Show("El nombre solo puede contener letras y espacios");
                txtNombre.Focus();
                return false;
            }

            if (!Validador.ValidarCampoObligatorio(txtCedula.Text))
            {
                MessageBox.Show("Ingrese la cedula del cliente");
                txtCedula.Focus();
                return false;
            }

            if (txtCedula.Text.Length < 11)
            {
                MessageBox.Show("La cedula debe tener 11 digitos");
                txtCedula.Focus();
                return false;
            }

            if (!string.IsNullOrEmpty(txtTelefono.Text))
            {
                if (!Validador.ValidarTelefono(txtTelefono.Text))
                {
                    MessageBox.Show("El telefono no es valido");
                    txtTelefono.Focus();
                    return false;
                }
            }

            if (!string.IsNullOrEmpty(txtRNC.Text))
            {
                if (!Validador.ValidarSoloNumeros(txtRNC.Text))
                {
                    MessageBox.Show("El RNC solo puede contener numeros");
                    txtRNC.Focus();
                    return false;
                }
            }

            if (!string.IsNullOrEmpty(txtLimiteCredito.Text))
            {
                if (!decimal.TryParse(txtLimiteCredito.Text, out decimal credito) || credito < 0)
                {
                    MessageBox.Show("El limite de credito debe ser un valor positivo");
                    txtLimiteCredito.Focus();
                    return false;
                }
            }

            return true;
        }

        
        
        
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            LimpiarCampos();
            HabilitarDeshabilitarBotones(true);
            txtNombre.Focus();
        }

        
        
        
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                if (esNuevo)
                {
                    var cliente = new Cliente
                    {
                        Nombre = txtNombre.Text.Trim(),
                        Cedula = txtCedula.Text.Trim(),
                        Telefono = txtTelefono.Text.Trim(),
                        RNC = txtRNC.Text.Trim(),
                        Direccion = txtDireccion.Text.Trim(),
                        Activo = chkActivo.Checked,
                        FechaCreacion = DateTime.Now
                    };

                    if (repCliente.AgregarCliente(cliente))
                    {
                        MessageBox.Show("Cliente agregado correctamente");
                        LimpiarCampos();
                        CargarClientes();
                        HabilitarDeshabilitarBotones(false);
                        esNuevo = false;
                    }
                }
                else
                {
                    if (dgvClientes.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Seleccione un cliente para actualizar");
                        return;
                    }

                    int idCliente = (int)dgvClientes.SelectedRows[0].Cells["IdCliente"].Value;

                    var cliente = new Cliente
                    {
                        IdCliente = idCliente,
                        Nombre = txtNombre.Text.Trim(),
                        Cedula = txtCedula.Text.Trim(),
                        Telefono = txtTelefono.Text.Trim(),
                        RNC = txtRNC.Text.Trim(),
                        Direccion = txtDireccion.Text.Trim(),
                        Activo = chkActivo.Checked
                    };

                    if (repCliente.ActualizarCliente(cliente))
                    {
                        MessageBox.Show("Cliente actualizado correctamente");
                        LimpiarCampos();
                        CargarClientes();
                        HabilitarDeshabilitarBotones(false);
                        esNuevo = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        
        
        
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un cliente para eliminar");
                return;
            }

            if (MessageBox.Show("?Desea eliminar este cliente?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int idCliente = (int)dgvClientes.SelectedRows[0].Cells["IdCliente"].Value;
                    if (repCliente.EliminarCliente(idCliente))
                    {
                        MessageBox.Show("Cliente eliminado correctamente");
                        LimpiarCampos();
                        CargarClientes();
                        HabilitarDeshabilitarBotones(false);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        
        
        
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            dgvClientes.ClearSelection();
            HabilitarDeshabilitarBotones(false);
            esNuevo = false;
        }

        
        
        
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtCedula.Clear();
            txtTelefono.Clear();
            txtRNC.Clear();
            txtDireccion.Clear();
            txtLimiteCredito.Text = "0.00";
            chkActivo.Checked = true;
        }

        
        
        
        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                var row = dgvClientes.SelectedRows[0];
                txtID.Text = row.Cells["IdCliente"].Value?.ToString() ?? "";
                txtNombre.Text = row.Cells["Nombre"].Value?.ToString() ?? "";
                txtCedula.Text = row.Cells["Cedula"].Value?.ToString() ?? "";
                txtTelefono.Text = row.Cells["Telefono"].Value?.ToString() ?? "";
                txtRNC.Text = row.Cells["RNC"].Value?.ToString() ?? "";

                esNuevo = false;
                HabilitarDeshabilitarBotones(true);
            }
        }

        
        
        
        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            FiltrarClientes();
        }

        
        
        
        private void FiltrarClientes()
        {
            try
            {
                string filtro = txtBusqueda.Text.ToLower().Trim();
                var clientes = repCliente.ObtenerTodos();

                if (string.IsNullOrEmpty(filtro))
                {
                    dgvClientes.DataSource = clientes;
                }
                else
                {
                    var clientesFiltrados = clientes.FindAll(c =>
                        c.Nombre.ToLower().Contains(filtro) ||
                        (!string.IsNullOrEmpty(c.Cedula) && c.Cedula.Contains(filtro)) ||
                        (!string.IsNullOrEmpty(c.RNC) && c.RNC.Contains(filtro))
                    );

                    dgvClientes.DataSource = clientesFiltrados;
                }

                lblTotal.Text = $"Total Clientes: {dgvClientes.Rows.Count}";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error en busqueda: " + ex.Message);
            }
        }

        
        
        
        private void HabilitarDeshabilitarBotones(bool habilitar)
        {
            btnGuardar.Enabled = habilitar;
            btnEliminar.Enabled = habilitar;
            btnNuevo.Enabled = true;
            btnLimpiar.Enabled = true;
        }

        
        
        
        private void ActualizarPie()
        {
            try
            {
                var usuario = SesionActual.UsuarioActual;
                lblUsuario.Text = usuario != null ? $"Usuario: {usuario.NombreUsuario}" : "Usuario: N/A";
                lblConexion.Text = "Conexion: OK";
            }
            catch
            {
                lblUsuario.Text = "Usuario: N/A";
                lblConexion.Text = "Conexion: ERROR";
            }
        }
    }
}
