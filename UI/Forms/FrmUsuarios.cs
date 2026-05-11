using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using CarniceriaPOS.Data;
using CarniceriaPOS.Business;
using CarniceriaPOS.Models;
using CarniceriaPOS.Utilities;
using CarniceriaPOS.UI.Forms;

namespace CarniceriaPOS.UI.Forms
{
    public partial class FrmUsuarios : FormBase
    {
        private RepositorioUsuario repUsuario;
        private RepositorioRol repRol;
        private bool esNuevo = true;

        public FrmUsuarios()
        {
            try
            {
                InitializeComponent();
                repUsuario = new RepositorioUsuario();
                repRol = new RepositorioRol();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inicializar FrmUsuarios: " + ex.Message);
                throw;
            }
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
                if (!SesionActual.TieneAcceso("Usuarios"))
                {
                    MessageBox.Show("No tiene permiso para acceder a la gestion de usuarios.",
                        "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LogAuditoria.RegistrarAccesoDenegado("Usuarios", SesionActual.UsuarioActual?.IdUsuario ?? 0);
                    this.Close();
                    return;
                }

                ConfigurarValidacionesFormulario();
                CargarRoles();
                CargarUsuarios();
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
            FormateadorTextBox.ConfigurarTextBox(txtNombre, FormateadorTextBox.TipoValidacion.SoloLetras, 100);
            FormateadorTextBox.ConfigurarTextBox(txtEmail, FormateadorTextBox.TipoValidacion.Gmail);
            if (txtContrasena != null)
                txtContrasena.MaxLength = 50;
        }

        private void CargarRoles()
        {
            try
            {
                var roles = repRol.ObtenerTodos();
                cmbRol.DataSource = roles;
                cmbRol.DisplayMember = "Nombre";
                cmbRol.ValueMember = "IdRol";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar roles: " + ex.Message);
            }
        }

        private void CargarUsuarios()
        {
            try
            {
                var usuarios = repUsuario.ObtenerTodos();

                if (dgvUsuarios.Columns.Count == 0)
                {
                    dgvUsuarios.Columns.Add("IdUsuario", "ID");
                    dgvUsuarios.Columns.Add("NombreEmpleado", "Empleado");
                    dgvUsuarios.Columns.Add("NombreUsuario", "Usuario");
                    dgvUsuarios.Columns.Add("Email", "Email");
                    dgvUsuarios.Columns.Add("NombreRol", "Rol");
                    dgvUsuarios.Columns.Add("Activo", "Activo");

                    dgvUsuarios.Columns["IdUsuario"].DataPropertyName = "IdUsuario";
                    dgvUsuarios.Columns["NombreEmpleado"].DataPropertyName = "NombreEmpleado";
                    dgvUsuarios.Columns["NombreUsuario"].DataPropertyName = "NombreUsuario";
                    dgvUsuarios.Columns["Email"].DataPropertyName = "Email";
                    dgvUsuarios.Columns["NombreRol"].DataPropertyName = "NombreRol";
                    dgvUsuarios.Columns["Activo"].DataPropertyName = "Activo";

                    dgvUsuarios.Columns["IdUsuario"].Width = 40;
                    dgvUsuarios.Columns["NombreEmpleado"].Width = 150;
                    dgvUsuarios.Columns["NombreUsuario"].Width = 120;
                    dgvUsuarios.Columns["Email"].Width = 150;
                    dgvUsuarios.Columns["NombreRol"].Width = 80;
                    dgvUsuarios.Columns["Activo"].Width = 60;
                }

                dgvUsuarios.DataSource = usuarios;
                lblTotal.Text = $"Total Usuarios: {usuarios.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message);
            }
        }

        private bool ValidarCampos()
        {
            if (!Validador.ValidarCampoObligatorio(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre completo");
                txtNombre.Focus();
                return false;
            }

            if (!Validador.ValidarSoloLetras(txtNombre.Text))
            {
                MessageBox.Show("El nombre solo puede contener letras y espacios");
                txtNombre.Focus();
                return false;
            }

            if (!Validador.ValidarCampoObligatorio(txtEmail.Text))
            {
                MessageBox.Show("Ingrese el correo electronico");
                txtEmail.Focus();
                return false;
            }

            if (!Validador.ValidarEmail(txtEmail.Text))
            {
                MessageBox.Show("El correo electronico no es valido");
                txtEmail.Focus();
                return false;
            }

            if (!Validador.ValidarCampoObligatorio(txtPassword.Text))
            {
                MessageBox.Show("Ingrese la contrasena");
                txtPassword.Focus();
                return false;
            }

            if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("La contrasena debe tener al menos 6 caracteres");
                txtPassword.Focus();
                return false;
            }

            if (cmbRol.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un rol");
                cmbRol.Focus();
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
                return;

            try
            {
                if (esNuevo)
                {
                    var usuario = new Usuario
                    {
                        NombreUsuario = txtNombre.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        PasswordHash = txtPassword.Text,
                        IdRol = (int)cmbRol.SelectedValue,
                        IdEmpleado = 0, 
                        Activo = chkActivo.Checked,
                        FechaCreacion = DateTime.Now
                    };

                    if (repUsuario.AgregarUsuario(usuario))
                    {
                        MessageBox.Show("Usuario agregado correctamente");
                        LimpiarCampos();
                        CargarUsuarios();
                        HabilitarDeshabilitarBotones(false);
                        esNuevo = false;
                    }
                }
                else
                {
                    if (dgvUsuarios.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Seleccione un usuario para actualizar");
                        return;
                    }

                    int idUsuario = (int)dgvUsuarios.SelectedRows[0].Cells["IdUsuario"].Value;

                    var usuario = new Usuario
                    {
                        IdUsuario = idUsuario,
                        NombreUsuario = txtNombre.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        PasswordHash = txtPassword.Text,
                        IdRol = (int)cmbRol.SelectedValue,
                        IdEmpleado = 0, 
                        Activo = chkActivo.Checked
                    };

                    if (repUsuario.ActualizarUsuario(usuario))
                    {
                        MessageBox.Show("Usuario actualizado correctamente");
                        LimpiarCampos();
                        CargarUsuarios();
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
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un usuario para eliminar");
                return;
            }

            if (MessageBox.Show("?Desea eliminar este usuario?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int idUsuario = (int)dgvUsuarios.SelectedRows[0].Cells["IdUsuario"].Value;
                    if (repUsuario.EliminarUsuario(idUsuario))
                    {
                        MessageBox.Show("Usuario eliminado correctamente");
                        LimpiarCampos();
                        CargarUsuarios();
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
            dgvUsuarios.ClearSelection();
            HabilitarDeshabilitarBotones(false);
            esNuevo = false;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            cmbRol.SelectedIndex = 0;
            chkActivo.Checked = true;
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                var row = dgvUsuarios.SelectedRows[0];
                txtID.Text = row.Cells["IdUsuario"].Value?.ToString() ?? "";
                txtNombre.Text = row.Cells["NombreEmpleado"].Value?.ToString() ?? "";
                txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
                txtPassword.Clear();

                esNuevo = false;
                HabilitarDeshabilitarBotones(true);
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            FiltrarUsuarios();
        }

        private void FiltrarUsuarios()
        {
            try
            {
                string filtro = txtBusqueda.Text.ToLower().Trim();
                var usuarios = repUsuario.ObtenerTodos();

                if (string.IsNullOrEmpty(filtro))
                {
                    dgvUsuarios.DataSource = usuarios;
                }
                else
                {
                    var usuariosFiltrados = usuarios.FindAll(u =>
                        u.NombreEmpleado.ToLower().Contains(filtro) ||
                        u.NombreUsuario.ToLower().Contains(filtro) ||
                        u.Email.ToLower().Contains(filtro)
                    );

                    dgvUsuarios.DataSource = usuariosFiltrados;
                }

                lblTotal.Text = $"Total Usuarios: {dgvUsuarios.Rows.Count}";
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
