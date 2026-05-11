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
    public partial class FrmEmpleados : Form
    {
        private RepositorioEmpleado repEmpleado;
        private RepositorioDepartamento repDepartamento;
        private bool esNuevo = true;

        public FrmEmpleados()
        {
            try
            {
                InitializeComponent();
                repEmpleado = new RepositorioEmpleado();
                repDepartamento = new RepositorioDepartamento();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inicializar FrmEmpleados: " + ex.Message);
                throw;
            }
        }

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            try
            {
                if (!SesionActual.TieneAcceso("Empleados"))
                {
                    MessageBox.Show("No tiene permiso para acceder a la gestion de empleados.",
                        "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LogAuditoria.RegistrarAccesoDenegado("Empleados", SesionActual.UsuarioActual?.IdUsuario ?? 0);
                    this.Close();
                    return;
                }

                ConfigurarValidacionesFormulario();
                CargarDepartamentos();
                CargarEmpleados();
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
            
            txtCedula.KeyPress += (s, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                    e.Handled = true;
            };

            
            txtCedula.TextChanged += (s, e) =>
            {
                try
                {
                    string cleaned = txtCedula.Text.Replace("-", "");
                    if (cleaned.Length > 11)
                        cleaned = cleaned.Substring(0, 11);

                    string formatted = cleaned;
                    if (cleaned.Length >= 3)
                        formatted = cleaned.Substring(0, 3) + "-" + cleaned.Substring(3);
                    if (cleaned.Length >= 10)
                        formatted = cleaned.Substring(0, 3) + "-" + cleaned.Substring(3, 7) + "-" + cleaned.Substring(10);

                    if (formatted != txtCedula.Text && !string.IsNullOrEmpty(cleaned))
                    {
                        int cursorPos = txtCedula.SelectionStart;
                        txtCedula.Text = formatted;
                        if (cursorPos <= formatted.Length)
                            txtCedula.SelectionStart = cursorPos;
                    }
                }
                catch { }
            };

            
            txtNombre.KeyPress += (s, e) =>
            {
                if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != '\b')
                    e.Handled = true;
            };

            
            txtTelefono.KeyPress += (s, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                    e.Handled = true;
            };

            
            txtPuesto.KeyPress += (s, e) =>
            {
                if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != '\b')
                    e.Handled = true;
            };

            
            txtSalario.KeyPress += (s, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '\b')
                    e.Handled = true;
            };
        }

        
        
        
        private void CargarDepartamentos()
        {
            try
            {
                var departamentos = repDepartamento.ObtenerTodos();
                cmbDepartamento.DataSource = departamentos;
                cmbDepartamento.DisplayMember = "Nombre";
                cmbDepartamento.ValueMember = "IdDepartamento";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar departamentos: " + ex.Message);
            }
        }

        
        
        
        private void CargarEmpleados()
        {
            try
            {
                var empleados = repEmpleado.ObtenerTodos();

                if (dgvEmpleados.Columns.Count == 0)
                {
                    dgvEmpleados.Columns.Add("IdEmpleado", "ID");
                    dgvEmpleados.Columns.Add("Nombre", "Nombre");
                    dgvEmpleados.Columns.Add("Cedula", "Cedula");
                    dgvEmpleados.Columns.Add("Telefono", "Telefono");
                    dgvEmpleados.Columns.Add("Departamento", "Departamento");
                    dgvEmpleados.Columns.Add("Puesto", "Puesto");
                    dgvEmpleados.Columns.Add("Salario", "Salario");
                    dgvEmpleados.Columns.Add("Activo", "Activo");

                    dgvEmpleados.Columns["IdEmpleado"].DataPropertyName = "IdEmpleado";
                    dgvEmpleados.Columns["Nombre"].DataPropertyName = "Nombre";
                    dgvEmpleados.Columns["Cedula"].DataPropertyName = "Cedula";
                    dgvEmpleados.Columns["Telefono"].DataPropertyName = "Telefono";
                    dgvEmpleados.Columns["Departamento"].DataPropertyName = "Departamento";
                    dgvEmpleados.Columns["Puesto"].DataPropertyName = "Puesto";
                    dgvEmpleados.Columns["Salario"].DataPropertyName = "Salario";
                    dgvEmpleados.Columns["Activo"].DataPropertyName = "Activo";

                    dgvEmpleados.Columns["IdEmpleado"].Width = 40;
                    dgvEmpleados.Columns["Nombre"].Width = 120;
                    dgvEmpleados.Columns["Cedula"].Width = 110;
                    dgvEmpleados.Columns["Telefono"].Width = 100;
                    dgvEmpleados.Columns["Departamento"].Width = 100;
                    dgvEmpleados.Columns["Puesto"].Width = 100;
                    dgvEmpleados.Columns["Salario"].Width = 100;
                    dgvEmpleados.Columns["Activo"].Width = 60;
                }

                dgvEmpleados.DataSource = empleados;
                lblTotal.Text = $"Total Empleados: {empleados.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar empleados: " + ex.Message);
            }
        }

        
        
        
        private bool ValidarCampos()
        {
            if (!Validador.ValidarCampoObligatorio(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre del empleado");
                txtNombre.Focus();
                return false;
            }

            if (!Validador.ValidarSoloLetras(txtNombre.Text))
            {
                MessageBox.Show("El nombre solo puede contener letras y espacios");
                txtNombre.Focus();
                return false;
            }

            if (!Validador.ValidarCampoObligatorio(txtPuesto.Text))
            {
                MessageBox.Show("Ingrese el puesto del empleado");
                txtPuesto.Focus();
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

            if (!Validador.ValidarCampoObligatorio(txtSalario.Text))
            {
                MessageBox.Show("Ingrese el salario del empleado");
                txtSalario.Focus();
                return false;
            }

            if (!decimal.TryParse(txtSalario.Text, out decimal salario) || salario <= 0)
            {
                MessageBox.Show("El salario debe ser un valor positivo");
                txtSalario.Focus();
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
                    var empleado = new Empleado
                    {
                        Nombre = txtNombre.Text.Trim(),
                        Cedula = txtCedula.Text.Trim(),
                        Telefono = txtTelefono.Text.Trim(),
                        Puesto = txtPuesto.Text.Trim(),
                        Salario = decimal.Parse(txtSalario.Text),
                        IdDepartamento = cmbDepartamento.SelectedValue != null ? (int?)Convert.ToInt32(cmbDepartamento.SelectedValue) : null,
                        Activo = chkActivo.Checked,
                        FechaCreacion = DateTime.Now
                    };

                    if (repEmpleado.AgregarEmpleado(empleado))
                    {
                        MessageBox.Show("Empleado agregado correctamente");
                        LimpiarCampos();
                        CargarEmpleados();
                        HabilitarDeshabilitarBotones(false);
                        esNuevo = false;
                    }
                }
                else
                {
                    if (dgvEmpleados.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Seleccione un empleado para actualizar");
                        return;
                    }

                    int idEmpleado = (int)dgvEmpleados.SelectedRows[0].Cells["IdEmpleado"].Value;

                    var empleado = new Empleado
                    {
                        IdEmpleado = idEmpleado,
                        Nombre = txtNombre.Text.Trim(),
                        Cedula = txtCedula.Text.Trim(),
                        Telefono = txtTelefono.Text.Trim(),
                        Puesto = txtPuesto.Text.Trim(),
                        Salario = decimal.Parse(txtSalario.Text),
                        IdDepartamento = cmbDepartamento.SelectedValue != null ? (int?)Convert.ToInt32(cmbDepartamento.SelectedValue) : null,
                        Activo = chkActivo.Checked
                    };

                    if (repEmpleado.ActualizarEmpleado(empleado))
                    {
                        MessageBox.Show("Empleado actualizado correctamente");
                        LimpiarCampos();
                        CargarEmpleados();
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
            if (dgvEmpleados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un empleado para eliminar");
                return;
            }

            if (MessageBox.Show("¿Desea eliminar este empleado?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int idEmpleado = (int)dgvEmpleados.SelectedRows[0].Cells["IdEmpleado"].Value;
                    if (repEmpleado.EliminarEmpleado(idEmpleado))
                    {
                        MessageBox.Show("Empleado eliminado correctamente");
                        LimpiarCampos();
                        CargarEmpleados();
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
            dgvEmpleados.ClearSelection();
            HabilitarDeshabilitarBotones(false);
            esNuevo = false;
        }

        
        
        
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtCedula.Clear();
            txtTelefono.Clear();
            txtPuesto.Clear();
            txtSalario.Text = "0.00";
            cmbDepartamento.SelectedIndex = 0;
            chkActivo.Checked = true;
        }

        
        
        
        private void dgvEmpleados_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                var row = dgvEmpleados.SelectedRows[0];
                txtID.Text = row.Cells["IdEmpleado"].Value?.ToString() ?? "";
                txtNombre.Text = row.Cells["Nombre"].Value?.ToString() ?? "";
                txtCedula.Text = row.Cells["Cedula"].Value?.ToString() ?? "";
                txtTelefono.Text = row.Cells["Telefono"].Value?.ToString() ?? "";
                txtPuesto.Text = row.Cells["Puesto"].Value?.ToString() ?? "";
                txtSalario.Text = row.Cells["Salario"].Value?.ToString() ?? "0";

                esNuevo = false;
                HabilitarDeshabilitarBotones(true);
            }
        }

        
        
        
        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            FiltrarEmpleados();
        }

        
        
        
        private void FiltrarEmpleados()
        {
            try
            {
                string filtro = txtBusqueda.Text.ToLower().Trim();
                var empleados = repEmpleado.ObtenerTodos();

                if (string.IsNullOrEmpty(filtro))
                {
                    dgvEmpleados.DataSource = empleados;
                }
                else
                {
                    var empleadosFiltrados = empleados.FindAll(e =>
                        e.Nombre.ToLower().Contains(filtro) ||
                        (!string.IsNullOrEmpty(e.Cedula) && e.Cedula.Contains(filtro))
                    );

                    dgvEmpleados.DataSource = empleadosFiltrados;
                }

                lblTotal.Text = $"Total Empleados: {dgvEmpleados.Rows.Count}";
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
