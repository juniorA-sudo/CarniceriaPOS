using System;
using System.Drawing;
using System.Windows.Forms;
using CarniceriaPOS.Business;
using CarniceriaPOS.Utilities;

namespace CarniceriaPOS.UI.Forms
{
    public partial class FrmPrincipal : Form
    {
        private Form _formularioActivo;

        public FrmPrincipal()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            ConfigurarVentanaPrincipal();
            AplicarEstilos();
            ActualizarMenuPorRol();
            AbrirFormularioEnContenido(new FrmPOS(), "Punto de venta");
        }

        private void ConfigurarVentanaPrincipal()
        {
            ClientSize = new Size(1440, 900);
            MinimumSize = new Size(1280, 820);
            WindowState = FormWindowState.Normal;
        }

        private void AplicarEstilos()
        {
            string nombreUsuario = SesionActual.UsuarioActual != null
                ? SesionActual.UsuarioActual.NombreUsuario
                : "Invitado";
            string nombreRol = SesionActual.RolActual != null
                ? SesionActual.RolActual.Nombre
                : "Acceso local";

            lblUser.Text = "Usuario: " + nombreUsuario;
            lblRole.Text = "Rol: " + nombreRol;
            Text = "Sistema Carnicera’aAa - " + nombreUsuario;

            BackColor = Color.FromArgb(15, 20, 25);
            pnlContent.BackColor = Color.FromArgb(15, 20, 25);
            pnlContentHost.BackColor = Color.White;
        }

        private void AbrirFormularioEnContenido(Form formulario, string titulo)
        {
            try
            {
                if (formulario == null)
                {
                    return;
                }

                pnlContent.SuspendLayout();

                
                if (_formularioActivo != null)
                {
                    try
                    {
                        if (!_formularioActivo.IsDisposed)
                        {
                            _formularioActivo.Close();
                            _formularioActivo.Dispose();
                        }
                    }
                    catch { }
                }

                _formularioActivo = formulario;
                lblTitle.Text = titulo;

                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                formulario.StartPosition = FormStartPosition.Manual;

                pnlContentHost.Controls.Clear();
                pnlContentHost.Controls.Add(formulario);
                formulario.BringToFront();
                formulario.Show();

                pnlContent.ResumeLayout(true);
            }
            catch (Exception ex)
            {
                
                pnlContent.ResumeLayout(true);
                MessageBox.Show($"No se puede abrir el ma’aAdulo: {titulo}\n\n{ex.Message}",
                    "Acceso Denegado o Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ActualizarMenuPorRol()
        {
            try
            {
                if (SesionActual.UsuarioActual == null || SesionActual.RolActual == null)
                {
                    HabilitarTodosBotones();
                    return;
                }

                int idRol = SesionActual.UsuarioActual.IdRol;

                btnProductos.Enabled = idRol == 1 || idRol == 2 || idRol == 5;
                btnClientes.Enabled = idRol == 1 || idRol == 2 || idRol == 3;
                btnProveedores.Enabled = idRol == 1 || idRol == 2 || idRol == 5;
                btnVentas.Enabled = idRol == 1 || idRol == 2 || idRol == 3 || idRol == 4;
                btnCompras.Enabled = idRol == 1 || idRol == 2 || idRol == 5;
                btnReportes.Enabled = idRol == 1 || idRol == 2;
                btnUsuarios.Enabled = idRol == 1 || idRol == 2;
                btnEmpleados.Enabled = idRol == 1 || idRol == 2;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error en ActualizarMenuPorRol: " + ex.Message);
                HabilitarTodosBotones();
            }
        }

        private void HabilitarTodosBotones()
        {
            btnProductos.Enabled = true;
            btnClientes.Enabled = true;
            btnProveedores.Enabled = true;
            btnVentas.Enabled = true;
            btnCompras.Enabled = true;
            btnReportes.Enabled = true;
            btnUsuarios.Enabled = true;
            btnEmpleados.Enabled = true;
        }

        
        
        
        private void ValidarYAbrirFormulario(Control boton, string modulo, Form formulario, string titulo)
        {
            try
            {
                
                if (!boton.Enabled)
                {
                    MessageBox.Show("No tiene permiso para acceder a este ma’aAdulo.", "Acceso Denegado");
                    return;
                }

                
                if (!SesionActual.TieneAcceso(modulo))
                {
                    MessageBox.Show($"No tiene permiso para acceder a {titulo}.", "Acceso Denegado");
                    LogAuditoria.RegistrarAccesoDenegado(modulo, SesionActual.UsuarioActual?.IdUsuario ?? 0);
                    return;
                }

                
                AbrirFormularioEnContenido(formulario, titulo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir {titulo}: {ex.Message}", "Error");
            }
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            ValidarYAbrirFormulario(btnProductos, "Productos", new FrmProductos(), "Productos");
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            ValidarYAbrirFormulario(btnClientes, "Clientes", new FrmClientes(), "Clientes");
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            ValidarYAbrirFormulario(btnProveedores, "Proveedores", new FrmProveedores(), "Proveedores");
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            ValidarYAbrirFormulario(btnVentas, "Ventas", new FrmPOS(), "Punto de venta");
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            ValidarYAbrirFormulario(btnCompras, "Compras", new FrmCompras(), "Compras");
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            ValidarYAbrirFormulario(btnReportes, "Reportes", new FrmReportes(), "Reportes");
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            ValidarYAbrirFormulario(btnUsuarios, "Usuarios", new FrmUsuarios(), "Usuarios");
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            ValidarYAbrirFormulario(btnEmpleados, "Empleados", new FrmEmpleados(), "Empleados");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro de que deseas salir del sistema?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SesionActual.CerrarSesion();
                Close();
            }
        }
    }
}
