using System;
using System.Windows.Forms;
using CarniceriaPOS.Data;
using CarniceriaPOS.Business;
using CarniceriaPOS.Utilities;

namespace CarniceriaPOS.UI.Forms
{
    public partial class FrmLogin : Form
    {
        private RepositorioUsuario repUsuario = new RepositorioUsuario();
        private RepositorioRol repRol = new RepositorioRol();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.Text = "Login - Sistema Carniceria";
            AplicarEstilos();
            txtEmail.Focus();
        }

        private void AplicarEstilos()
        {
            
            AplicarEstiloTextBox(txtEmail);
            AplicarEstiloTextBox(txtPassword);

            
            CargarLogo();
        }

        private void AplicarEstiloTextBox(TextBox textBox)
        {
            textBox.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox.Font = new System.Drawing.Font("Segoe UI", 11F);
            textBox.Margin = new System.Windows.Forms.Padding(5);
        }

        private void CargarLogo()
        {
            try
            {
                string[] extensiones = { ".png", ".jpg", ".jpeg", ".bmp", ".gif" };
                string rutaEjecucion = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

                
                string[] rutasBusqueda = new string[]
                {
                    System.IO.Path.Combine(rutaEjecucion, "logo"),                    
                    System.IO.Path.Combine(System.IO.Directory.GetParent(System.IO.Directory.GetParent(rutaEjecucion).FullName).FullName, "logo"),  
                    System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CarniceriaPOS", "logo")  
                };

                foreach (var rutaBase in rutasBusqueda)
                {
                    foreach (var ext in extensiones)
                    {
                        string rutaLogo = rutaBase + ext;
                        if (System.IO.File.Exists(rutaLogo))
                        {
                            
                            using (var img = System.Drawing.Image.FromFile(rutaLogo))
                            {
                                pictureBoxLogo.Image = new System.Drawing.Bitmap(img);
                            }
                            System.Diagnostics.Debug.WriteLine($"Logo cargado exitosamente desde: {rutaLogo}");
                            return;
                        }
                    }
                }

                System.Diagnostics.Debug.WriteLine($"No se encontro logo en las ubicaciones esperadas");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al cargar logo: {ex.Message}\n{ex.StackTrace}");
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                AutenticarUsuario();
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Ingrese el email");
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Ingrese la contrasena");
                txtPassword.Focus();
                return false;
            }

            return true;
        }

        private void AutenticarUsuario()
        {
            try
            {
                var usuario = repUsuario.ObtenerUsuarioPorEmail(txtEmail.Text);

                if (usuario == null)
                {
                    MessageBox.Show("Usuario no encontrado");
                    LogAuditoria.RegistrarLogin(txtEmail.Text, false);
                    return;
                }

                if (usuario.PasswordHash != txtPassword.Text)
                {
                    MessageBox.Show("Contrasena incorrecta");
                    txtPassword.Clear();
                    txtPassword.Focus();
                    LogAuditoria.RegistrarLogin(usuario.NombreUsuario, false);
                    return;
                }

                if (!usuario.Activo)
                {
                    MessageBox.Show("Este usuario esta inactivo");
                    LogAuditoria.RegistrarLogin(usuario.NombreUsuario, false);
                    return;
                }

                var rol = repRol.ObtenerRolPorId(usuario.IdRol);
                SesionActual.IniciarSesion(usuario, rol);

                
                LogAuditoria.RegistrarLogin(usuario.NombreUsuario, true);

                FrmPrincipal frmPrincipal = new FrmPrincipal();
                this.Hide();
                frmPrincipal.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                LogAuditoria.RegistrarLogin(txtEmail.Text, false);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                txtPassword.Focus();
                e.Handled = true;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnEntrar_Click(null, null);
                e.Handled = true;
            }
        }
    }
}
