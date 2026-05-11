using System;
using System.Linq;
using System.Windows.Forms;
using CarniceriaPOS.Data;
using CarniceriaPOS.Business;
using CarniceriaPOS.Models;
using CarniceriaPOS.Utilities;

namespace CarniceriaPOS.UI.Forms
{
    public partial class FrmCompras : Form
    {
        private RepositorioCompra repCompra;
        private RepositorioProducto repProducto;
        private RepositorioProveedor repProveedor;

        public FrmCompras()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inicializar FrmCompras: " + ex.Message);
                throw;
            }
        }

        private RepositorioCompra ObtenerRepCompra()
        {
            if (repCompra == null)
                repCompra = new RepositorioCompra();
            return repCompra;
        }

        private RepositorioProducto ObtenerRepProducto()
        {
            if (repProducto == null)
                repProducto = new RepositorioProducto();
            return repProducto;
        }

        private RepositorioProveedor ObtenerRepProveedor()
        {
            if (repProveedor == null)
                repProveedor = new RepositorioProveedor();
            return repProveedor;
        }

        private void FrmCompras_Load(object sender, EventArgs e)
        {
            
            if (!SesionActual.TieneAcceso("Compras"))
            {
                MessageBox.Show("No tiene permiso para acceder a la gestion de compras.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LogAuditoria.RegistrarAccesoDenegado("Compras", SesionActual.UsuarioActual?.IdUsuario ?? 0);
                this.Close();
                return;
            }

            this.Text = "Gestion de Compras";
            dtpFechaCompra.Value = DateTime.Now;

            
            Validador.ConfigurarMaxLengthFormulario(this.Controls);

            
            dtpFechaCompra.ValueChanged += (s, evt) => CargarComprasPorFecha(dtpFechaCompra.Value.Date);

            CargarProveedores();
            CargarProductos();
            CargarEstadisticas();
            CargarComprasPorFecha(DateTime.Now);

            
            cmbProducto.SelectedIndexChanged += CmbProducto_SelectedIndexChanged;

            
            ReposicionarBotonesGuardar();
        }

        private void CargarProveedores()
        {
            try
            {
                cmbProveedor.DataSource = ObtenerRepProveedor().ObtenerTodos();
                cmbProveedor.DisplayMember = "Nombre";
                cmbProveedor.ValueMember = "IdProveedor";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar proveedores: " + ex.Message);
            }
        }

        private void CargarProductos()
        {
            try
            {
                cmbProducto.DataSource = ObtenerRepProducto().ObtenerTodos();
                cmbProducto.DisplayMember = "Nombre";
                cmbProducto.ValueMember = "IdProducto";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }

        private void CargarEstadisticas()
        {
            try
            {
                
                DateTime inicioMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime finMes = DateTime.Now.Date.AddDays(1);
                var comprasMes = ObtenerRepCompra().ObtenerComprasPorPeriodo(inicioMes, finMes);

                
                lblComprasVal.Text = comprasMes.Count.ToString();

                
                decimal montoTotal = 0;
                foreach (var compra in comprasMes)
                {
                    montoTotal += compra.Total;
                }
                lblMontoVal.Text = "$" + montoTotal.ToString("N2");

                
                int comprasPendientes = comprasMes.FindAll(c => c.Estado != "Completada").Count;
                lblPendientesVal.Text = comprasPendientes.ToString();

                
                var proveedores = ObtenerRepProveedor().ObtenerTodos();
                int proveedoresActivos = proveedores.FindAll(p => p.Activo).Count;
                lblProveedoresVal.Text = proveedoresActivos.ToString();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al cargar estadisticas: " + ex.Message);
            }
        }

        private void CargarComprasPorFecha(DateTime fecha)
        {
            try
            {
                var compras = ObtenerRepCompra().ObtenerComprasPorPeriodo(fecha, fecha);

                if (compras == null || compras.Count == 0)
                {
                    dgvCompras.DataSource = null;
                    System.Diagnostics.Debug.WriteLine($"No hay compras registradas para {fecha:dd/MM/yyyy}");
                }
                else
                {
                    dgvCompras.DataSource = compras;
                    System.Diagnostics.Debug.WriteLine($"Se cargaron {compras.Count} compras para {fecha:dd/MM/yyyy}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar compras: " + ex.Message);
                System.Diagnostics.Debug.WriteLine("Error en CargarComprasPorFecha: " + ex.ToString());
            }
        }

        private void ReposicionarBotonesGuardar()
        {
            try
            {
                
                var btnGuardarCompra = this.Controls.Find("btnGuardarCompra", true).FirstOrDefault() as Button;
                var dgvCompras = this.Controls.Find("dgvCompras", true).FirstOrDefault() as DataGridView;

                if (btnGuardarCompra != null && dgvCompras != null)
                {
                    
                    btnGuardarCompra.Left = dgvCompras.Right + 10;
                    btnGuardarCompra.Top = dgvCompras.Top;
                    btnGuardarCompra.Visible = true;
                    btnGuardarCompra.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error en ReposicionarBotonesGuardar: " + ex.Message);
            }
        }

        private void CmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbProducto.SelectedItem is Producto producto && producto != null)
                {
                    
                    
                    var lblPrecioUnitario = this.Controls.Find("lblPrecioUnitario", true).FirstOrDefault() as Label;
                    if (lblPrecioUnitario != null)
                    {
                        lblPrecioUnitario.Text = $"${producto.PrecioCompra:N2}";
                    }

                    
                    var txtPrecioUnitario = this.Controls.Find("txtPrecioUnitario", true).FirstOrDefault() as TextBox;
                    if (txtPrecioUnitario != null)
                    {
                        txtPrecioUnitario.Text = producto.PrecioCompra.ToString("N2");
                    }

                    System.Diagnostics.Debug.WriteLine($"Producto seleccionado: {producto.Nombre}, Precio: ${producto.PrecioCompra:N2}");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al cargar precio del producto: " + ex.Message);
            }
        }

        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            if (!ValidarDetalle())
            {
                return;
            }

            try
            {
                var producto = (Producto)cmbProducto.SelectedItem;
                int cantidad = int.Parse(txtCantidad.Text);
                decimal precio = producto.PrecioCompra;

                dgvDetalles.Rows.Add(
                    producto.IdProducto,
                    producto.Nombre,
                    cantidad,
                    precio,
                    cantidad * precio
                );

                ActualizarTotal();
                txtCantidad.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar detalle: " + ex.Message);
            }
        }

        private void btnGuardarCompra_Click(object sender, EventArgs e)
        {
            if (dgvDetalles.Rows.Count == 0)
            {
                MessageBox.Show("Agregue al menos un detalle de compra");
                return;
            }

            if (ValidarCompra())
            {
                try
                {
                    
                    string subtotalStr = lblSubtotalVal.Text.Replace("$", "").Trim();
                    string impuestoStr = lblImpuestoVal.Text.Replace("$", "").Trim();
                    string totalStr = lblTotalVal.Text.Replace("$", "").Trim();

                    var compra = new Compra
                    {
                        NumeroFacturaProv = "COM" + DateTime.Now.Ticks.ToString().Substring(0, 10),
                        IdProveedor = (int)cmbProveedor.SelectedValue,
                        IdUsuario = SesionActual.UsuarioActual.IdUsuario,
                        FechaCompra = DateTime.Now,
                        Total = decimal.Parse(totalStr),
                        Estado = "Completada"
                    };

                    if (ObtenerRepCompra().AgregarCompra(compra))
                    {
                        MessageBox.Show("Compra guardada correctamente");
                        LimpiarFormulario();

                        
                        System.Threading.Thread.Sleep(100); 
                        dgvCompras.DataSource = null; 
                        CargarComprasPorFecha(DateTime.Now);
                        CargarEstadisticas();  
                    }
                    else
                    {
                        MessageBox.Show("Error: No se pudo guardar la compra en la base de datos");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar compra: " + ex.Message);
                }
            }
        }

        private void ActualizarTotal()
        {
            decimal subtotal = 0;
            foreach (DataGridViewRow row in dgvDetalles.Rows)
            {
                if (row.Cells[4].Value != null)
                {
                    subtotal += decimal.Parse(row.Cells[4].Value.ToString());
                }
            }

            decimal impuesto = subtotal * 0.12m;
            decimal total = subtotal + impuesto;

            lblSubtotalVal.Text = "$" + subtotal.ToString("N2");
            lblImpuestoVal.Text = "$" + impuesto.ToString("N2");
            lblTotalVal.Text = "$" + total.ToString("N2");
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            cmbProveedor.SelectedIndex = 0;
            dgvDetalles.Rows.Clear();
            txtCantidad.Clear();
            lblSubtotalVal.Text = "$0.00";
            lblImpuestoVal.Text = "$0.00";
            lblTotalVal.Text = "$0.00";
        }

        private bool ValidarDetalle()
        {
            
            if (!Validador.ValidarCampoObligatorio(txtCantidad.Text))
            {
                MessageBox.Show("Ingrese una cantidad para el producto");
                txtCantidad.Focus();
                return false;
            }

            
            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser un numero positivo mayor a 0");
                txtCantidad.Focus();
                return false;
            }

            
            if (cmbProveedor.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un proveedor");
                cmbProveedor.Focus();
                return false;
            }

            
            if (cmbProducto.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un producto");
                cmbProducto.Focus();
                return false;
            }

            return true;
        }

        private bool ValidarCompra()
        {
            
            if (dgvDetalles.Rows.Count == 0)
            {
                MessageBox.Show("Agregue al menos un detalle a la compra");
                return false;
            }

            
            if (cmbProveedor.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un proveedor");
                cmbProveedor.Focus();
                return false;
            }

            
            if (!Validador.ValidarRangoFechas(dtpFechaCompra.Value.Date, DateTime.Now.Date.AddDays(1)))
            {
                MessageBox.Show("La fecha de compra no puede ser futura");
                dtpFechaCompra.Focus();
                return false;
            }

            return true;
        }
    }
}
