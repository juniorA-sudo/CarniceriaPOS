using System;
using System.Windows.Forms;
using CarniceriaPOS.Data;
using CarniceriaPOS.Business;
using CarniceriaPOS.Models;
using CarniceriaPOS.Utilities;

namespace CarniceriaPOS.UI.Forms
{
    public partial class FrmProveedores : Form
    {
        private RepositorioProveedor repProveedor;
        private bool esNuevo = true;

        public FrmProveedores()
        {
            try
            {
                InitializeComponent();
                repProveedor = new RepositorioProveedor();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inicializar FrmProveedores: " + ex.Message);
                throw;
            }
        }

        private void FrmProveedores_Load(object sender, EventArgs e)
        {
            try
            {
                
                if (!SesionActual.TieneAcceso("Proveedores"))
                {
                    MessageBox.Show("No tiene permiso para acceder a la gestion de proveedores.",
                        "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LogAuditoria.RegistrarAccesoDenegado("Proveedores", SesionActual.UsuarioActual?.IdUsuario ?? 0);
                    this.Close();
                    return;
                }

                ConfigurarValidacionesFormulario();

                CargarProveedores();

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
            FormateadorTextBox.ConfigurarTextBox(txtRNC, FormateadorTextBox.TipoValidacion.RNC);
            FormateadorTextBox.ConfigurarTextBox(txtNombre, FormateadorTextBox.TipoValidacion.SoloLetras, 100);
            FormateadorTextBox.ConfigurarTextBox(txtTelefono, FormateadorTextBox.TipoValidacion.Telefono);
            txtDireccion.MaxLength = 150;
        }

        private void CargarProveedores()
        {
            try
            {
                var proveedores = repProveedor.ObtenerTodos();

                if (dgvProveedores.Columns.Count == 0)
                {
                    dgvProveedores.Columns.Add("IdProveedor", "ID");
                    dgvProveedores.Columns.Add("Nombre", "Nombre");
                    dgvProveedores.Columns.Add("RNC", "RNC");
                    dgvProveedores.Columns.Add("Telefono", "Telefono");
                    dgvProveedores.Columns.Add("Email", "Email");

                    dgvProveedores.Columns["IdProveedor"].DataPropertyName = "IdProveedor";
                    dgvProveedores.Columns["Nombre"].DataPropertyName = "Nombre";
                    dgvProveedores.Columns["RNC"].DataPropertyName = "RNC";
                    dgvProveedores.Columns["Telefono"].DataPropertyName = "Telefono";
                    dgvProveedores.Columns["Email"].DataPropertyName = "Email";

                    dgvProveedores.Columns["IdProveedor"].Width = 40;
                    dgvProveedores.Columns["Nombre"].Width = 150;
                    dgvProveedores.Columns["RNC"].Width = 100;
                    dgvProveedores.Columns["Telefono"].Width = 100;
                    dgvProveedores.Columns["Email"].Width = 115;
                }

                dgvProveedores.DataSource = proveedores;

                lblTotal.Text = $"Total Proveedores: {proveedores.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar proveedores: " + ex.Message);
                lblTotal.Text = "Total Proveedores: 0";
            }
        }

        private bool ValidarCampos()
        {
            
            if (!Validador.ValidarCampoObligatorio(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre de la empresa");
                txtNombre.Focus();
                return false;
            }

            if (!Validador.ValidarSoloLetras(txtNombre.Text))
            {
                MessageBox.Show("El nombre solo puede contener letras y espacios");
                txtNombre.Focus();
                return false;
            }

            if (txtNombre.Text.Length > 100)
            {
                MessageBox.Show("El nombre no puede exceder 100 caracteres");
                txtNombre.Focus();
                return false;
            }

            if (!Validador.ValidarCampoObligatorio(txtRNC.Text))
            {
                MessageBox.Show("Ingrese el RNC (Registro Nacional Contribuyente)");
                txtRNC.Focus();
                return false;
            }

            if (!Validador.ValidarSoloNumeros(txtRNC.Text))
            {
                MessageBox.Show("El RNC solo puede contener naomeros");
                txtRNC.Focus();
                return false;
            }

            if (txtRNC.Text.Length < 9 || txtRNC.Text.Length > 14)
            {
                MessageBox.Show("El RNC debe tener entre 9 y 14 digitos");
                txtRNC.Focus();
                return false;
            }

            if (!string.IsNullOrEmpty(txtTelefono.Text))
            {
                if (!Validador.ValidarTelefono(txtTelefono.Text))
                {
                    MessageBox.Show("El telefono no es valido. Use formato: 809-555-1234");
                    txtTelefono.Focus();
                    return false;
                }
            }

            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                if (!Validador.ValidarEmail(txtEmail.Text))
                {
                    MessageBox.Show("El email no es valido");
                    txtEmail.Focus();
                    return false;
                }
            }

            if (txtDireccion.Text.Length > 150)
            {
                MessageBox.Show("La direccion no puede exceder 150 caracteres");
                txtDireccion.Focus();
                return false;
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
            {
                return;
            }

            try
            {
                if (esNuevo)
                {
                    
                    var proveedor = new Proveedor
                    {
                        Nombre = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtNombre.Text.ToLower()),
                        Telefono = txtTelefono.Text.Trim(),
                        Email = txtEmail.Text.ToLower().Trim(),
                        Direccion = txtDireccion.Text.Trim(),
                        RNC = txtRNC.Text.Trim(),
                        Activo = chkActivo.Checked,
                        FechaCreacion = DateTime.Now
                    };

                    if (repProveedor.AgregarProveedor(proveedor))
                    {
                        MessageBox.Show("Proveedor agregado correctamente");
                        LimpiarCampos();
                        CargarProveedores();
                        HabilitarDeshabilitarBotones(false);
                        esNuevo = false;
                    }
                    else
                    {
                        MessageBox.Show("Error al agregar el proveedor");
                    }
                }
                else
                {
                    
                    if (dgvProveedores.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Seleccione un proveedor para actualizar");
                        return;
                    }

                    int idProveedor = (int)dgvProveedores.SelectedRows[0].Cells["IdProveedor"].Value;

                    var proveedor = new Proveedor
                    {
                        IdProveedor = idProveedor,
                        Nombre = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtNombre.Text.ToLower()),
                        Telefono = txtTelefono.Text.Trim(),
                        Email = txtEmail.Text.ToLower().Trim(),
                        Direccion = txtDireccion.Text.Trim(),
                        RNC = txtRNC.Text.Trim(),
                        Activo = chkActivo.Checked
                    };

                    if (repProveedor.ActualizarProveedor(proveedor))
                    {
                        MessageBox.Show("Proveedor actualizado correctamente");
                        LimpiarCampos();
                        CargarProveedores();
                        HabilitarDeshabilitarBotones(false);
                        esNuevo = false;
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el proveedor");
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
            if (dgvProveedores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un proveedor para eliminar");
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "A?Desea eliminar este proveedor?",
                "Confirmacion de Eliminacion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    int idProveedor = (int)dgvProveedores.SelectedRows[0].Cells["IdProveedor"].Value;

                    if (repProveedor.EliminarProveedor(idProveedor))
                    {
                        MessageBox.Show("Proveedor eliminado correctamente");
                        LimpiarCampos();
                        CargarProveedores();
                        HabilitarDeshabilitarBotones(false);
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el proveedor");
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
            dgvProveedores.ClearSelection();
            HabilitarDeshabilitarBotones(false);
            esNuevo = false;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtRNC.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();
            chkActivo.Checked = true;
        }

        private void dgvProveedores_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count > 0)
            {
                var row = dgvProveedores.SelectedRows[0];
                txtID.Text = row.Cells["IdProveedor"].Value?.ToString() ?? "";
                txtNombre.Text = row.Cells["Nombre"].Value?.ToString() ?? "";
                txtRNC.Text = row.Cells["RNC"].Value?.ToString() ?? "";
                txtTelefono.Text = row.Cells["Telefono"].Value?.ToString() ?? "";
                txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";

                esNuevo = false;
                HabilitarDeshabilitarBotones(true);
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            FiltrarProveedores();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltrarProveedores();
        }

        private void FiltrarProveedores()
        {
            try
            {
                string filtro = txtBusqueda.Text.ToLower().Trim();
                var proveedores = repProveedor.ObtenerTodos();

                if (string.IsNullOrEmpty(filtro))
                {
                    dgvProveedores.DataSource = proveedores;
                }
                else
                {
                    var proveedoresFiltrados = proveedores.FindAll(p =>
                        p.Nombre.ToLower().Contains(filtro) ||
                        (!string.IsNullOrEmpty(p.RNC) && p.RNC.Contains(filtro))
                    );

                    dgvProveedores.DataSource = proveedoresFiltrados;
                }

                lblTotal.Text = $"Total Proveedores: {dgvProveedores.Rows.Count}";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error en baosqueda: " + ex.Message);
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
