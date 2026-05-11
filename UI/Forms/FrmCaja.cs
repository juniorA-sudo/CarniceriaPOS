using System;
using System.Windows.Forms;
using CarniceriaPOS.Data;
using CarniceriaPOS.Business;
using CarniceriaPOS.Models;
using CarniceriaPOS.Utilities;

namespace CarniceriaPOS.UI.Forms
{
    public partial class FrmCaja : Form
    {
        private RepositorioVenta repVenta;
        private RepositorioCierreCaja repCierre;

        public FrmCaja()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inicializar FrmCaja: " + ex.Message);
                throw;
            }
        }

        private RepositorioVenta ObtenerRepVenta()
        {
            if (repVenta == null)
                repVenta = new RepositorioVenta();
            return repVenta;
        }

        private RepositorioCierreCaja ObtenerRepCierre()
        {
            if (repCierre == null)
                repCierre = new RepositorioCierreCaja();
            return repCierre;
        }

        private void FrmCaja_Load(object sender, EventArgs e)
        {
            
            if (!SesionActual.TieneAcceso("Caja"))
            {
                MessageBox.Show("No tiene permiso para acceder al cierre de caja.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LogAuditoria.RegistrarAccesoDenegado("Caja", SesionActual.UsuarioActual?.IdUsuario ?? 0);
                this.Close();
                return;
            }

            this.Text = "Cierre de Caja";

            Validador.ConfigurarMaxLengthFormulario(this.Controls);

            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                DateTime hoy = DateTime.Now.Date;
                var ventas = ObtenerRepVenta().ObtenerVentasPorFecha(hoy);
                dgvVentas.DataSource = ventas;

                decimal totalVentas = ObtenerRepVenta().ObtenerTotalVentasPorFecha(hoy);
                lblTotalVentas.Text = totalVentas.ToString("N2");
                lblCantidadVentas.Text = ventas.Count.ToString();

                decimal montoEsperado = totalVentas;
                lblMontoEsperado.Text = montoEsperado.ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnCalcularDiferencia_Click(object sender, EventArgs e)
        {
            if (!ValidarMontoReal())
            {
                return;
            }

            try
            {
                decimal montoReal = decimal.Parse(txtMontoReal.Text);
                decimal montoEsperado = decimal.Parse(lblMontoEsperado.Text);
                decimal diferencia = montoReal - montoEsperado;

                lblMontoReal.Text = montoReal.ToString("N2");
                lblDiferencia.Text = diferencia.ToString("N2");

                if (diferencia == 0)
                {
                    lblEstado.Text = " Caja Balanceada";
                    lblEstado.ForeColor = System.Drawing.Color.Green;
                }
                else if (diferencia > 0)
                {
                    lblEstado.Text = "Sobrante: " + diferencia.ToString("N2");
                    lblEstado.ForeColor = System.Drawing.Color.Blue;
                }
                else
                {
                    lblEstado.Text = "Faltante: " + Math.Abs(diferencia).ToString("N2");
                    lblEstado.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ingrese un valor valido: " + ex.Message);
            }
        }

        private void btnGuardarCierre_Click(object sender, EventArgs e)
        {
            if (!ValidarMontoReal())
            {
                return;
            }

            try
            {
                
                if (lblDiferencia.Text == "0.00" && !string.IsNullOrEmpty(lblMontoReal.Text))
                {
                    
                    btnCalcularDiferencia_Click(null, null);
                }

                decimal montoReal = decimal.Parse(txtMontoReal.Text);
                decimal montoEsperado = decimal.Parse(lblMontoEsperado.Text);
                decimal diferencia = montoReal - montoEsperado;

                var cierre = new CierreCaja
                {
                    IdUsuario = SesionActual.UsuarioActual.IdUsuario,
                    FechaApertura = DateTime.Now.Date,
                    FechaClosing = DateTime.Now,
                    MontoApertura = 0, 
                    MontoEsperado = montoEsperado,
                    MontoReal = montoReal,
                    Diferencia = diferencia,
                    Estado = diferencia == 0 ? "Balanceada" : (diferencia > 0 ? "Sobrante" : "Faltante")
                };

                if (ObtenerRepCierre().AgregarCierre(cierre))
                {
                    MessageBox.Show(" Cierre de caja guardado correctamente\n" +
                        $"Monto esperado: ${montoEsperado:N2}\n" +
                        $"Monto real: ${montoReal:N2}\n" +
                        $"Diferencia: ${diferencia:N2}",
                        "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtMontoReal.Clear();
                    lblMontoReal.Text = "0.00";
                    lblDiferencia.Text = "0.00";
                    lblEstado.Text = "Pendiente";
                    lblEstado.ForeColor = System.Drawing.Color.Black;
                    CargarDatos();
                }
                else
                {
                    MessageBox.Show("Error al guardar el cierre de caja. Intente nuevamente.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarMontoReal()
        {
            
            if (!Validador.ValidarCampoObligatorio(txtMontoReal.Text))
            {
                MessageBox.Show("Ingrese el monto real de la caja");
                txtMontoReal.Focus();
                return false;
            }

            if (!decimal.TryParse(txtMontoReal.Text, out decimal montoReal))
            {
                MessageBox.Show("El monto debe ser un valor decimal valido");
                txtMontoReal.Focus();
                return false;
            }

            if (montoReal < 0)
            {
                MessageBox.Show("El monto no puede ser negativo");
                txtMontoReal.Focus();
                return false;
            }

            return true;
        }
    }
}
