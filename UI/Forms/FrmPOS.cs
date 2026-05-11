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
        private RepositorioCliente repCliente;
        private Venta ventaActual;
        private Cliente clienteActual;
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
                    IdEmpleado = SesionActual.UsuarioActual?.IdUsuario ?? 0
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

        private RepositorioCliente ObtenerRepCliente()
        {
            if (repCliente == null)
                repCliente = new RepositorioCliente();

            return repCliente;
        }

        private string GenerarNumeroFactura()
        {
            try
            {
                string fechaHoy = DateTime.Now.ToString("yyyyMMdd");
                string prefijoFactura = $"FCT-{fechaHoy}-";

                // Esta función debe ir a la base de datos y traer el MAX de hoy
                int ultimoNumero = ObtenerRepVenta().ObtenerUltimoNumeroFactura(prefijoFactura);

                // Si el último fue 1, el nuevo será 2.
                int siguienteNumero = ultimoNumero + 1;

                return $"{prefijoFactura}{siguienteNumero:D4}";
            }
            catch
            {
                // En caso de error crítico, usa Ticks para que el número sea irrepetible
                return $"FCT-{DateTime.Now:yyyyMMddHHmmss}-{DateTime.Now.Ticks}";
            }
        }

        private void FrmPOS_Load(object sender, EventArgs e)
        {
            try
            {
                if (!SesionActual.TieneAcceso("Ventas"))
                {
                    MessageBox.Show(
                        "No tiene permiso para acceder al modulo de ventas.",
                        "Acceso Denegado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    LogAuditoria.RegistrarAccesoDenegado(
                        "Ventas",
                        SesionActual.UsuarioActual?.IdUsuario ?? 0);

                    this.Close();
                    return;
                }

                CargarCategorias();
                CargarProductos();
                ConfigurarColumnasDgvProductos();

                // =========================
                // EVENTOS DGV PRODUCTOS
                // =========================
                if (dgvProductos != null)
                {
                    dgvProductos.CellClick += DgvProductos_CellClick;

                    // EVITA ERROR DE IMAGEN
                    dgvProductos.DataError += (s, ev) =>
                    {
                        ev.ThrowException = false;
                    };
                }

                // =========================
                // EVENTOS DGV CARRITO
                // =========================
                if (dgvCarrito != null)
                {
                    dgvCarrito.KeyDown += DgvCarrito_KeyDown;
                    dgvCarrito.CellDoubleClick += DgvCarrito_CellDoubleClick;
                    dgvCarrito.CellContentClick += DgvCarrito_CellContentClick;

                    // NUEVO EVENTO
                    dgvCarrito.CellClick += DgvCarrito_CellClick;

                    // EVITA ERROR:
                    // "Invalid cast from string to Image"
                    dgvCarrito.DataError += (s, ev) =>
                    {
                        ev.ThrowException = false;
                    };

                    // CONFIGURACION SEGURA PARA IMAGENES
                    if (dgvCarrito.Columns["colImagen"] is DataGridViewImageColumn imgCol)
                    {
                        imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    }
                }

                // =========================
                // BUSQUEDA
                // =========================
                if (txtBusqueda != null)
                {
                    txtBusqueda.TextChanged += TxtBusqueda_TextChanged;
                }

                // =========================
                // CATEGORIAS
                // =========================
                if (lstCategorias != null)
                {
                    lstCategorias.SelectedIndexChanged += LstCategorias_SelectedIndexChanged;
                }

                // =========================
                // MONTO RECIBIDO
                // =========================
                if (txtMontoRecibido != null)
                {
                    txtMontoRecibido.TextChanged += TxtMontoRecibido_TextChanged;
                    txtMontoRecibido.KeyPress += TxtMontoRecibido_KeyPress;
                }

                // =========================
                // CANTIDAD
                // =========================
                if (txtCantidad != null)
                {
                    txtCantidad.KeyPress += (s, e2) =>
                    {
                        if (!char.IsDigit(e2.KeyChar) &&
                            e2.KeyChar != '\b')
                        {
                            e2.Handled = true;
                        }
                    };
                }

                // =========================
                // BOTON SELECCIONAR CLIENTE
                // =========================
                AgregarBotonSeleccionarCliente();

                // =========================
                // INICIAR NUEVA VENTA
                // =========================
                NuevaVenta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar el Punto de Venta:\n{ex.Message}\n\n{ex.StackTrace}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
                    productosFiltrados = productosCompletos
                        .Where(p => !string.IsNullOrEmpty(p.Categoria) &&
                                    p.Categoria.Equals(categoriaSeleccionada, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                }

                dgvProductos.DataSource = null;
                dgvProductos.DataSource = productosFiltrados;

                if (dgvProductos.Columns.Contains("UnidadMedida"))
                {
                    dgvProductos.Columns["UnidadMedida"].DataPropertyName = "UnidadMedida";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar productos: " + ex.Message);
            }
        }

        private void ConfigurarColumnasDgvProductos()
        {
            dgvProductos.AutoGenerateColumns = false;

            if (dgvProductos.Columns.Contains("UnidadMedida"))
            {
                dgvProductos.Columns["UnidadMedida"].DataPropertyName = "UnidadMedida";
                dgvProductos.Columns["UnidadMedida"].ValueType = typeof(string);
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

                string categoriaSeleccionada =
                    lstCategorias?.SelectedItem?.ToString() ?? "Todas";

                var filtrados = productosCompletos.Where(p =>
                {
                    bool coincideNombre =
                        p.Nombre.ToLower().Contains(filtro);

                    bool coincideCategoria =
                        categoriaSeleccionada.Equals(
                            "Todas",
                            StringComparison.OrdinalIgnoreCase)
                        ||
                        (
                            !string.IsNullOrEmpty(p.Categoria)
                            &&
                            p.Categoria.Equals(
                                categoriaSeleccionada,
                                StringComparison.OrdinalIgnoreCase)
                        );

                    return coincideNombre && coincideCategoria;
                }).ToList();

                dgvProductos.DataSource = filtrados;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en busqueda: " + ex.Message);
            }
        }
        private void DgvCarrito_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                if (dgvCarrito.Columns[e.ColumnIndex].Name == "colEliminar")
                {
                    if (MessageBox.Show(
                        "¿Eliminar producto del carrito?",
                        "Confirmar",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        dgvCarrito.Rows.RemoveAt(e.RowIndex);

                        if (e.RowIndex < detallesVenta.Count)
                            detallesVenta.RemoveAt(e.RowIndex);

                        ActualizarTotal();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar producto: " + ex.Message);
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

                if (!decimal.TryParse(txtCantidad.Text, out decimal cantidad)
                    || cantidad <= 0)
                {
                    MessageBox.Show("Ingrese cantidad valida");
                    return;
                }

                var row = dgvProductos.SelectedRows[0];

                int idProducto =
                    Convert.ToInt32(row.Cells["IdProducto"].Value);

                string nombre =
                    row.Cells["Nombre"].Value.ToString();

                decimal precioVenta =
                    Convert.ToDecimal(row.Cells["PrecioVenta"].Value);

                decimal stock =
                    Convert.ToDecimal(row.Cells["StockActual"].Value);

                string unidadMedida = "";
                try
                {
                    if (dgvProductos.Columns.Contains("UnidadMedida") &&
                        row.Cells["UnidadMedida"].Value != null)
                    {
                        unidadMedida = row.Cells["UnidadMedida"].Value.ToString();
                    }
                }
                catch
                {
                    unidadMedida = "";
                }

                if (cantidad > stock)
                {
                    MessageBox.Show($"Stock insuficiente. Disponible: {stock} {unidadMedida}");
                    return;
                }

                int filaExistente = -1;
                for (int i = 0; i < dgvCarrito.Rows.Count; i++)
                {
                    if (dgvCarrito.Rows[i].Cells[0].Value != null &&
                        Convert.ToInt32(dgvCarrito.Rows[i].Cells[0].Value) == idProducto)
                    {
                        filaExistente = i;
                        break;
                    }
                }

                if (filaExistente >= 0)
                {
                    decimal cantidadActual = Convert.ToDecimal(dgvCarrito.Rows[filaExistente].Cells[3].Value);
                    decimal nuevaCantidad = cantidadActual + cantidad;

                    if (nuevaCantidad > stock)
                    {
                        MessageBox.Show($"Stock insuficiente. Disponible: {stock} {unidadMedida}\nYa tiene: {cantidadActual} en el carrito");
                        return;
                    }

                    decimal nuevoSubtotal = precioVenta * nuevaCantidad;

                    dgvCarrito.Rows[filaExistente].Cells[3].Value = nuevaCantidad;
                    dgvCarrito.Rows[filaExistente].Cells[5].Value = "$" + nuevoSubtotal.ToString("N2");

                    var detalleExistente = detallesVenta.FirstOrDefault(d => d.IdProducto == idProducto);
                    if (detalleExistente != null)
                    {
                        detalleExistente.Cantidad = (int)nuevaCantidad;
                        detalleExistente.Subtotal = nuevoSubtotal;
                    }
                }
                else
                {
                    decimal subtotal = precioVenta * cantidad;

                    dgvCarrito.Rows.Add(
                        idProducto,
                        nombre,
                        "X",
                        cantidad,
                        "$" + precioVenta.ToString("N2"),
                        "$" + subtotal.ToString("N2"),
                        unidadMedida
                    );

                    var detalle = new DetalleVenta
                    {
                        IdProducto = idProducto,
                        Cantidad = (int)cantidad,
                        PrecioUnitario = precioVenta,
                        Subtotal = subtotal,
                        NombreProducto = nombre
                    };

                    detallesVenta.Add(detalle);
                }

                txtCantidad.Text = "1";

                ActualizarTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void DgvCarrito_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                if (dgvCarrito.Columns[e.ColumnIndex].Name == "colEliminar")
                {
                    DialogResult resultado = MessageBox.Show(
                        "¿Eliminar este producto del carrito?",
                        "Confirmar",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        dgvCarrito.Rows.RemoveAt(e.RowIndex);

                        if (e.RowIndex < detallesVenta.Count)
                            detallesVenta.RemoveAt(e.RowIndex);

                        ActualizarTotal();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al eliminar producto: " + ex.Message);
            }
        }

        private void DgvCarrito_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete &&
                dgvCarrito.SelectedRows.Count > 0)
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
            if (e.RowIndex < 0) return;

            var detalle = detallesVenta[e.RowIndex];
            var producto = ObtenerRepProducto().ObtenerTodos()?.FirstOrDefault(p => p.IdProducto == detalle.IdProducto);

            if (producto == null) return;

            Form frm = new Form
            {
                Text = string.Empty,
                Width = 450,
                Height = 320, // Altura ajustada para que no sobre espacio ni se corte
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.None,
                BackColor = Color.White
            };

            Panel pnlHeader = new Panel { Dock = DockStyle.Top, Height = 55, BackColor = Color.FromArgb(28, 35, 64) };
            Label lblTitulo = new Label
            {
                Text = "AJUSTAR CANTIDAD",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            pnlHeader.Controls.Add(lblTitulo);

            // Borde externo para el formulario
            frm.Paint += (s, pe) => {
                pe.Graphics.DrawRectangle(new Pen(Color.FromArgb(28, 35, 64), 2), 0, 0, frm.Width - 1, frm.Height - 1);
            };

            Label LblInfo = new Label
            {
                Text = producto.Nombre.ToUpper(),
                Top = 75,
                Left = 20,
                Width = 410,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(40, 40, 40),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label LblPrecio = new Label
            {
                Text = $"Precio Unitario: ${producto.PrecioVenta:N2}",
                Top = 105,
                Left = 20,
                Width = 410,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.MiddleCenter
            };

            NumericUpDown numCantidad = new NumericUpDown
            {
                Value = detalle.Cantidad,
                Left = 145,
                Top = 145,
                Width = 160,
                Height = 40,
                Minimum = 1,
                Maximum = (decimal)producto.StockActual + detalle.Cantidad,
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                TextAlign = HorizontalAlignment.Center,
                BorderStyle = BorderStyle.FixedSingle
            };

            Button btnOK = new Button
            {
                Text = "GUARDAR",
                DialogResult = DialogResult.OK,
                Width = 180,
                Height = 45,
                Left = 35,
                Top = 230,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnOK.FlatAppearance.BorderSize = 0;

            Button btnCancel = new Button
            {
                Text = "CANCELAR",
                DialogResult = DialogResult.Cancel,
                Width = 180,
                Height = 45,
                Left = 235,
                Top = 230,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnCancel.FlatAppearance.BorderSize = 0;

            frm.Controls.AddRange(new Control[] { pnlHeader, LblInfo, LblPrecio, numCantidad, btnOK, btnCancel });

            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                int nuevaCantidad = (int)numCantidad.Value;
                detalle.Cantidad = nuevaCantidad;
                detalle.Subtotal = producto.PrecioVenta * nuevaCantidad;

                dgvCarrito.Rows[e.RowIndex].Cells[3].Value = nuevaCantidad;
                dgvCarrito.Rows[e.RowIndex].Cells[5].Value = "$" + detalle.Subtotal.ToString("N2");

                ActualizarTotal();
            }

            frm.Dispose();
        }

        private void ActualizarTotal()
        {
            try
            {
                decimal subtotal =
                    detallesVenta.Sum(d => d.Subtotal);

                decimal itbis = subtotal * 0.18m;

                decimal total = subtotal + itbis;

                ventaActual.Subtotal = subtotal;
                ventaActual.TotalITBIS = itbis;
                ventaActual.Total = total;

                lblSubtotalVal.Text = "$" + subtotal.ToString("N2");
                lblImpuestoVal.Text = "$" + itbis.ToString("N2");
                lblTotalVal.Text = "$" + total.ToString("N2");

                txtMontoRecibido.Text = "";

                lblCambioVal.Text = "$0.00";
                lblCambioVal.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al actualizar totales: " + ex.Message);
            }
        }

        private string ObtenerMetodoPagoSeleccionado()
        {
            if (rdoEfectivo.Checked)
                return "Efectivo";

            if (rdoTarjeta.Checked)
                return "Tarjeta";

            if (rdoDebito.Checked)
                return "Debito";

            return "Efectivo";
        }

        private void TxtMontoRecibido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)
                && e.KeyChar != '.'
                && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void TxtMontoRecibido_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(
                txtMontoRecibido.Text,
                out decimal montoRecibido))
            {
                decimal cambio =
                    montoRecibido - ventaActual.Total;

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
                    lblCambioVal.BackColor =
                        Color.FromArgb(144, 238, 144);
                }

                lblCambioVal.Text =
                    "$" + cambio.ToString("N2");
            }
        }

        private bool ValidarVenta()
        {
            if (detallesVenta.Count == 0)
            {
                MessageBox.Show(
                    "El carrito esta vacio. Agregue productos antes de completar la venta");

                return false;
            }

            if (ventaActual.Total <= 0)
            {
                MessageBox.Show(
                    "El total debe ser mayor a $0.00");

                return false;
            }

            return true;
        }

        private void FinalizarVenta(object sender, EventArgs e)
        {
            try
            {
                // 1. Validar si hay productos
                if (!ValidarVenta())
                    return;

                // 2. Validar Cliente (Sin bucles que frisen la app)
                if (ventaActual.IdCliente == null || ventaActual.IdCliente <= 0)
                {
                    MessageBox.Show(
                        "Debe seleccionar un cliente antes de finalizar la venta.",
                        "Cliente Requerido",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    SeleccionarCliente();

                    // Si después de abrirlo sigue vacío, abortamos el proceso para que el usuario pueda elegir
                    if (ventaActual.IdCliente == null || ventaActual.IdCliente <= 0)
                    {
                        return;
                    }
                }

                // 3. Obtener Método de Pago
                string metodoPago = ObtenerMetodoPagoSeleccionado();

                // 4. Validar efectivo si corresponde
                if (metodoPago.Equals("Efectivo", StringComparison.OrdinalIgnoreCase))
                {
                    if (!decimal.TryParse(txtMontoRecibido.Text, out decimal montoRecibido))
                    {
                        MessageBox.Show("Ingrese un monto recibido válido.");
                        txtMontoRecibido.Focus();
                        return;
                    }

                    if (montoRecibido < ventaActual.Total)
                    {
                        MessageBox.Show("Monto insuficiente para cubrir el total.");
                        return;
                    }

                    ventaActual.MontoRecibido = montoRecibido;
                    ventaActual.Cambio = montoRecibido - ventaActual.Total;
                }
                else
                {
                    // Para tarjeta o débito, el monto recibido es igual al total
                    ventaActual.MontoRecibido = ventaActual.Total;
                    ventaActual.Cambio = 0;
                }

                // 5. Preparar datos finales
                ventaActual.Detalles = detallesVenta;
                ventaActual.MetodoPago = metodoPago;
                ventaActual.Estado = "Completada";

                // 6. Guardar en Base de Datos
                if (ObtenerRepVenta().AgregarVenta(ventaActual))
                {
                    MessageBox.Show("¡Venta registrada exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Imprimir si es necesario
                    ImprimirTicket(null, null);

                    // Limpiar para la siguiente venta
                    NuevaVenta();
                }
                else
                {
                    MessageBox.Show("Error al guardar la venta en la base de datos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error crítico al finalizar venta: " + ex.Message);
            }
        }

        private void ImprimirTicket(object sender, EventArgs e)
        {
            try
            {
                if (ventaActual == null ||
                    detallesVenta.Count == 0)
                {
                    MessageBox.Show(
                        "No hay venta para imprimir");

                    return;
                }

                MessageBox.Show(
                    "Ticket impreso correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al imprimir: " + ex.Message);
            }
        }

        private void CancelarVenta(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "¿Desea cancelar esta venta?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
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
                    IdEmpleado =
                        SesionActual.UsuarioActual?.IdUsuario ?? 0,
                    IdCliente = 0,
                    MetodoPago = "Efectivo",
                    Estado = "Pendiente",
                    Subtotal = 0,
                    TotalITBIS = 0,
                    Total = 0
                };

                clienteActual = null;

                detallesVenta.Clear();

                dgvCarrito.Rows.Clear();

                lblSubtotalVal.Text = "$0.00";
                lblImpuestoVal.Text = "$0.00";
                lblTotalVal.Text = "$0.00";

                txtMontoRecibido.Clear();

                lblCambioVal.Text = "$0.00";
                lblCambioVal.BackColor = Color.Transparent;

                rdoEfectivo.Checked = true;

                dgvProductos.ClearSelection();

                txtBusqueda.Clear();

                if (lstCategorias.Items.Count > 0)
                    lstCategorias.SelectedIndex = 0;
                else
                    MostrarProductosPorCategoria();

                txtCantidad.Text = "1";

                ActualizarTituloCliente();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al inicializar nueva venta: " + ex.Message);
            }
        }

        private void AgregarBotonSeleccionarCliente()
        {
            try
            {
                if (pnlSearch.Controls.Find("btnSeleccionarCliente", false).Length == 0)
                {
                    Button btnSeleccionarCliente = new Button
                    {
                        Name = "btnSeleccionarCliente",
                        Text = "👤 Seleccionar Cliente",
                        BackColor = Color.FromArgb(33, 150, 243),
                        ForeColor = Color.White,
                        Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                        FlatStyle = FlatStyle.Flat,
                        Height = txtBusqueda.Height + 2, // Ajustado a la altura del buscador
                        Width = 150,
                        Cursor = Cursors.Hand,
                        Anchor = AnchorStyles.Top | AnchorStyles.Right
                    };

                    btnSeleccionarCliente.FlatAppearance.BorderSize = 0;
                    btnSeleccionarCliente.Click += (s, e) => SeleccionarCliente();

                    // Ajustamos el ancho del buscador para que no choquen
                    txtBusqueda.Width = pnlSearch.Width - btnSeleccionarCliente.Width - 25;

                    // Posicionamos el botón justo al lado del buscador
                    btnSeleccionarCliente.Left = txtBusqueda.Right + 5;
                    btnSeleccionarCliente.Top = txtBusqueda.Top - 1;

                    // Agregamos el botón directamente al panel de búsqueda para que sea fijo
                    pnlSearch.Controls.Add(btnSeleccionarCliente);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ubicar el botón de cliente: " + ex.Message);
            }
        }

        private void SeleccionarCliente()
        {
            try
            {
                using (FrmBuscadorClienteCedula frm = new FrmBuscadorClienteCedula())
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        clienteActual = frm.ClienteSeleccionado;

                        if (clienteActual != null && clienteActual.IdCliente > 0)
                        {
                            ventaActual.IdCliente = clienteActual.IdCliente;
                            ActualizarTituloCliente();
                        }
                        else
                        {
                            ventaActual.IdCliente = 0;
                            ActualizarTituloCliente();
                        }
                    }
                    else
                    {
                        ventaActual.IdCliente = 0;
                        clienteActual = null;
                        ActualizarTituloCliente();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar cliente: " + ex.Message);
            }
        }

        private void ActualizarTituloCliente()
        {
            try
            {
                if (clienteActual != null && clienteActual.IdCliente > 0)
                {
                    this.Text = $"Punto de Venta - Cliente: {clienteActual.Nombre}";
                }
                else
                {
                    this.Text = "Punto de Venta - Cliente: Genérico";
                }
            }
            catch
            {
                this.Text = "Punto de Venta";
            }
        }
    }
}