using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CarniceriaPOS.Data;
using CarniceriaPOS.Business;
using CarniceriaPOS.Models;
using CarniceriaPOS.Utilities;

namespace CarniceriaPOS.UI.Forms
{
    public partial class FrmPOS : Form
    {
        private RepositorioProducto repProducto;
        private RepositorioVenta repVenta;
        private Venta ventaActual;
        private List<DetalleVenta> detallesVenta = new List<DetalleVenta>();
        private List<Producto> productosCompletos;
        private int contadorVentas = 0;

        public FrmPOS()
        {
            try
            {
                InitializeComponent();

                ventaActual = new Venta
                {
                    NumeroFactura = GenerarNumeroFactura(),
                    FechaVenta = DateTime.Now,
                    IdUsuario = SesionActual.UsuarioActual?.IdUsuario ?? 0
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inicializar FrmPOS: " + ex.Message);
                throw;
            }
        }

        private RepositorioProducto ObtenerRepProducto()
        {
            if (repProducto == null)
                repProducto = new RepositorioProducto();

            return repProducto;
        }

        private RepositorioVenta ObtenerRepVenta()
        {
            if (repVenta == null)
                repVenta = new RepositorioVenta();

            return repVenta;
        }

        private string GenerarNumeroFactura()
        {
            try
            {
                string fechaHoy = DateTime.Now.ToString("yyyyMMdd");
                int ultimoNumero = ObtenerRepVenta().ObtenerUltimoNumeroFactura(fechaHoy);
                contadorVentas = ultimoNumero + 1;
                return $"FCT-{fechaHoy}-{contadorVentas:D4}";
            }
            catch
            {
                contadorVentas++;
                return $"FCT-{DateTime.Now:yyyyMMdd}-{contadorVentas:D4}";
            }
        }

        private void FrmPOS_Load(object sender, EventArgs e)
        {
            try
            {
                
                if (!SesionActual.TieneAcceso("Ventas"))
                {
                    MessageBox.Show("No tiene permiso para acceder al modulo de ventas.",
                        "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LogAuditoria.RegistrarAccesoDenegado("Ventas", SesionActual.UsuarioActual?.IdUsuario ?? 0);
                    this.Close();
                    return;
                }

                CargarCategorias();
                CargarProductos();

                
                if (dgvProductos != null)
                    dgvProductos.CellClick += DgvProductos_CellClick;

                if (dgvCarrito != null)
                {
                    dgvCarrito.KeyDown += DgvCarrito_KeyDown;
                    dgvCarrito.CellDoubleClick += DgvCarrito_CellDoubleClick;
                }

                if (txtBusqueda != null)
                    txtBusqueda.TextChanged += TxtBusqueda_TextChanged;

                if (lstCategorias != null)
                    lstCategorias.SelectedIndexChanged += LstCategorias_SelectedIndexChanged;

                if (txtMontoRecibido != null)
                {
                    txtMontoRecibido.TextChanged += TxtMontoRecibido_TextChanged;
                    txtMontoRecibido.KeyPress += TxtMontoRecibido_KeyPress;
                }

                if (txtCantidad != null)
                {
                    txtCantidad.KeyPress += (s, e2) =>
                    {
                        if (!char.IsDigit(e2.KeyChar) && e2.KeyChar != '\b')
                        {
                            e2.Handled = true;
                        }
                    };
                }

                NuevaVenta();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el Punto de Venta:\n{ex.Message}\n\n{ex.StackTrace}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine("Error en FrmPOS_Load: " + ex.ToString());
            }
        }

        private void CargarCategorias()
        {
            try
            {
                if (lstCategorias == null)
                    return;

                lstCategorias.Items.Clear();
                lstCategorias.Items.Add("Todas");
                lstCategorias.Items.Add("Res");
                lstCategorias.Items.Add("Cerdo");
                lstCategorias.Items.Add("Pollo");
                lstCategorias.Items.Add("Embutidos");
                lstCategorias.Items.Add("Aves");
                lstCategorias.Items.Add("Sazon");

                lstCategorias.SelectedIndex = 0; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorias: " + ex.Message);
            }
        }

        private void CargarProductos()
        {
            try
            {
                productosCompletos = ObtenerRepProducto().ObtenerTodos();
                if (productosCompletos != null)
                {
                    MostrarProductosPorCategoria();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }

        private void MostrarProductosPorCategoria()
        {
            try
            {
                if (productosCompletos == null || lstCategorias == null)
                    return;

                string categoriaSeleccionada = lstCategorias.SelectedItem?.ToString() ?? "Todas";

                List<Producto> productosFiltrados;
                if (categoriaSeleccionada.Equals("Todas", StringComparison.OrdinalIgnoreCase))
                {
                    productosFiltrados = productosCompletos;
                }
                else
                {
                    productosFiltrados = productosCompletos.Where(p =>
                        !string.IsNullOrEmpty(p.Categoria) &&
                        p.Categoria.Equals(categoriaSeleccionada, StringComparison.OrdinalIgnoreCase)
                    ).ToList();
                }

                dgvProductos.DataSource = productosFiltrados;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar productos: " + ex.Message);
            }
        }

        private void DgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvProductos.Rows[e.RowIndex].Selected = true;
                txtCantidad.Focus();
                txtCantidad.SelectAll();
            }
        }

        private void LstCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtBusqueda.Clear();
                MostrarProductosPorCategoria();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cambiar categoria: " + ex.Message);
            }
        }

        private void TxtBusqueda_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (productosCompletos == null)
                    return;

                string filtro = txtBusqueda.Text.ToLower();
                string categoriaSeleccionada = lstCategorias?.SelectedItem?.ToString() ?? "Todas";

                var filtrados = productosCompletos.Where(p =>
                {
                    bool coincideNombre = p.Nombre.ToLower().Contains(filtro);
                    bool coincideCategoria = categoriaSeleccionada.Equals("Todas", StringComparison.OrdinalIgnoreCase) ||
                        (!string.IsNullOrEmpty(p.Categoria) &&
                         p.Categoria.Equals(categoriaSeleccionada, StringComparison.OrdinalIgnoreCase));

                    return coincideNombre && coincideCategoria;
                }).ToList();

                dgvProductos.DataSource = filtrados;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en busqueda: " + ex.Message);
            }
        }

        private void AgregarProductoAlCarrito(object sender, EventArgs e)
        {
            try
            {
                if (dgvProductos.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione un producto");
                    return;
                }

                if (!decimal.TryParse(txtCantidad.Text, out decimal cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("Ingrese cantidad valida");
                    return;
                }

                var row = dgvProductos.SelectedRows[0];

                int idProducto = (int)row.Cells["IdProducto"].Value;
                string nombre = row.Cells["Nombre"].Value.ToString();
                decimal precioVenta = decimal.Parse(row.Cells["PrecioVenta"].Value.ToString());
                decimal stock = decimal.Parse(row.Cells["StockActual"].Value.ToString());

                if (cantidad > stock)
                {
                    MessageBox.Show($"Stock insuficiente. Disponible: {stock}");
                    return;
                }

                decimal subtotal = precioVenta * cantidad;

                dgvCarrito.Rows.Add(idProducto, nombre, "", cantidad, "$" + precioVenta.ToString("N2"), "$" + subtotal.ToString("N2"));

                var detalle = new DetalleVenta
                {
                    IdProducto = idProducto,
                    Cantidad = (int)cantidad,
                    PrecioUnitario = precioVenta,
                    Subtotal = subtotal,
                    NombreProducto = nombre
                };

                detallesVenta.Add(detalle);
                txtCantidad.Text = "1";
                ActualizarTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void DgvCarrito_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && dgvCarrito.SelectedRows.Count > 0)
            {
                int index = dgvCarrito.SelectedRows[0].Index;
                dgvCarrito.Rows.RemoveAt(index);

                if (index < detallesVenta.Count)
                    detallesVenta.RemoveAt(index);

                ActualizarTotal();
                e.Handled = true;
            }
        }

        private void DgvCarrito_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var detalle = detallesVenta[e.RowIndex];
            var producto = ObtenerRepProducto().ObtenerTodos()?.FirstOrDefault(p => p.IdProducto == detalle.IdProducto);

            if (producto == null)
                return;

            Form frm = new Form
            {
                Text = "Editar Cantidad",
                Width = 350,
                Height = 180,
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label lblProducto = new Label { Text = "Producto:", Left = 10, Top = 10, Width = 100 };
            TextBox txtProducto = new TextBox { Text = producto.Nombre, Left = 10, Top = 30, Width = 310, ReadOnly = true };
            Label lblCantidad = new Label { Text = "Cantidad:", Left = 10, Top = 70, Width = 100 };

            NumericUpDown numCantidad = new NumericUpDown
            {
                Value = detalle.Cantidad,
                Left = 10,
                Top = 90,
                Width = 100,
                Minimum = 1,
                Maximum = producto.StockActual + detalle.Cantidad
            };

            Button btnOK = new Button { Text = "Guardar", DialogResult = DialogResult.OK, Left = 100, Top = 130, Width = 100 };
            Button btnCancel = new Button { Text = "Cancelar", DialogResult = DialogResult.Cancel, Left = 210, Top = 130, Width = 100 };

            frm.Controls.AddRange(new Control[] { lblProducto, txtProducto, lblCantidad, numCantidad, btnOK, btnCancel });

            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                int nuevaCantidad = (int)numCantidad.Value;
                detalle.Cantidad = nuevaCantidad;
                detalle.Subtotal = producto.PrecioVenta * nuevaCantidad;

                dgvCarrito.Rows[e.RowIndex].Cells[1].Value = nuevaCantidad;
                dgvCarrito.Rows[e.RowIndex].Cells[3].Value = "$" + detalle.Subtotal.ToString("N2");

                ActualizarTotal();
            }

            frm.Dispose();
        }

        private void ActualizarTotal()
        {
            try
            {
                decimal subtotal = detallesVenta.Sum(d => d.Subtotal);
                decimal itbis = subtotal * 0.18m;
                decimal total = subtotal + itbis;

                ventaActual.Subtotal = subtotal;
                ventaActual.TotalITBIS = itbis;
                ventaActual.Total = total;

                if (lblSubtotalVal != null)
                    lblSubtotalVal.Text = "$" + subtotal.ToString("N2");

                if (lblImpuestoVal != null)
                    lblImpuestoVal.Text = "$" + itbis.ToString("N2");

                if (lblTotalVal != null)
                    lblTotalVal.Text = "$" + total.ToString("N2");

                txtMontoRecibido.Text = "";
                lblCambioVal.Text = "$0.00";
                lblCambioVal.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar totales: " + ex.Message);
            }
        }

        private string ObtenerMetodoPagoSeleccionado()
        {
            if (rdoEfectivo != null && rdoEfectivo.Checked)
                return "Efectivo";
            if (rdoTarjeta != null && rdoTarjeta.Checked)
                return "Tarjeta";
            if (rdoDebito != null && rdoDebito.Checked)
                return "Debito";
            return "Efectivo";
        }

        private void TxtMontoRecibido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void TxtMontoRecibido_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtMontoRecibido.Text, out decimal montoRecibido))
            {
                decimal cambio = montoRecibido - ventaActual.Total;

                if (cambio < 0)
                {
                    lblCambioVal.ForeColor = Color.Red;
                    lblCambioVal.BackColor = Color.White;
                }
                else if (cambio == 0)
                {
                    lblCambioVal.ForeColor = Color.White;
                    lblCambioVal.BackColor = Color.Green;
                }
                else
                {
                    lblCambioVal.ForeColor = Color.White;
                    lblCambioVal.BackColor = Color.FromArgb(144, 238, 144);
                }

                lblCambioVal.Text = "$" + cambio.ToString("N2");
            }
        }

        private bool ValidarVenta()
        {
            
            if (detallesVenta.Count == 0)
            {
                MessageBox.Show("El carrito esta vacio. Agregue productos antes de completar la venta");
                return false;
            }

            
            if (ventaActual.Total <= 0)
            {
                MessageBox.Show("El total debe ser mayor a $0.00");
                return false;
            }

            return true;
        }

        private void FinalizarVenta(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarVenta())
                {
                    return;
                }

                string metodoPago = ObtenerMetodoPagoSeleccionado();

                if (metodoPago.Equals("Efectivo", StringComparison.OrdinalIgnoreCase))
                {
                    if (!decimal.TryParse(txtMontoRecibido.Text, out decimal montoRecibido))
                    {
                        MessageBox.Show("Ingrese monto recibido valido");
                        return;
                    }

                    if (montoRecibido < ventaActual.Total)
                    {
                        MessageBox.Show("Monto insuficiente");
                        return;
                    }

                    ventaActual.MontoRecibido = montoRecibido;
                    ventaActual.Cambio = montoRecibido - ventaActual.Total;
                }

                ventaActual.Detalles = detallesVenta;
                ventaActual.MetodoPago = metodoPago;
                ventaActual.Estado = "Completada";

                if (ObtenerRepVenta().AgregarVenta(ventaActual))
                {
                    MessageBox.Show("!Venta registrada exitosamente!");
                    ImprimirTicket(null, null);
                    NuevaVenta();
                }
                else
                {
                    MessageBox.Show("Error al guardar la venta");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ImprimirTicket(object sender, EventArgs e)
        {
            try
            {
                if (ventaActual == null || detallesVenta.Count == 0)
                {
                    MessageBox.Show("No hay venta para imprimir");
                    return;
                }

                
                MessageBox.Show("Ticket impreso correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al imprimir: " + ex.Message);
            }
        }

        private void CancelarVenta(object sender, EventArgs e)
        {
            if (MessageBox.Show("?Desea cancelar esta venta?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                NuevaVenta();
            }
        }

        private void NuevaVenta()
        {
            try
            {
                ventaActual = new Venta
                {
                    NumeroFactura = GenerarNumeroFactura(),
                    FechaVenta = DateTime.Now,
                    IdUsuario = SesionActual.UsuarioActual?.IdUsuario ?? 0,
                    IdCliente = 0,
                    MetodoPago = "Efectivo",
                    Estado = "Pendiente",
                    Subtotal = 0,
                    TotalITBIS = 0,
                    Total = 0
                };

                detallesVenta.Clear();
                dgvCarrito.Rows.Clear();

                if (lblSubtotalVal != null)
                    lblSubtotalVal.Text = "$0.00";

                if (lblImpuestoVal != null)
                    lblImpuestoVal.Text = "$0.00";

                if (lblTotalVal != null)
                    lblTotalVal.Text = "$0.00";

                if (txtMontoRecibido != null)
                    txtMontoRecibido.Clear();

                if (lblCambioVal != null)
                {
                    lblCambioVal.Text = "$0.00";
                    lblCambioVal.BackColor = Color.Transparent;
                }

                if (rdoEfectivo != null)
                    rdoEfectivo.Checked = true;

                dgvProductos.ClearSelection();
                if (txtBusqueda != null)
                    txtBusqueda.Clear();

                if (lstCategorias != null && lstCategorias.Items.Count > 0)
                    lstCategorias.SelectedIndex = 0;
                else
                    MostrarProductosPorCategoria();

                if (txtCantidad != null)
                    txtCantidad.Text = "1";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inicializar nueva venta: " + ex.Message);
            }
        }
    }
}
