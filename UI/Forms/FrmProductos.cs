using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;
using CarniceriaPOS.Data;
using CarniceriaPOS.Business;
using CarniceriaPOS.Models;
using CarniceriaPOS.Utilities;

namespace CarniceriaPOS.UI.Forms
{
    public partial class FrmProductos : Form
    {
        private RepositorioProducto repProducto;
        private List<Producto> productosActuales;

        public FrmProductos()
        {
            try
            {
                InitializeComponent();
                repProducto = new RepositorioProducto();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inicializar FrmProductos: " + ex.Message);
                throw;
            }
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            try
            {
                if (!SesionActual.TieneAcceso("Productos"))
                {
                    MessageBox.Show("No tiene permiso para acceder a la gestion de productos.",
                        "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LogAuditoria.RegistrarAccesoDenegado("Productos", SesionActual.UsuarioActual?.IdUsuario ?? 0);
                    this.Close();
                    return;
                }

                CargarCategorias();
                CargarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar formulario: " + ex.Message);
            }
        }

        private void CargarCategorias()
        {
            cmbCategorias.Items.Clear();
            cmbCategorias.Items.Add("Todas");
            cmbCategorias.Items.Add("Cortes de Res");
            cmbCategorias.Items.Add("Cortes de Cerdo");
            cmbCategorias.Items.Add("Embutidos");
            cmbCategorias.Items.Add("Pollo");
            cmbCategorias.Items.Add("Sazon");
            cmbCategorias.SelectedIndex = 0;
        }

        private void CargarProductos()
        {
            try
            {
                productosActuales = repProducto.ObtenerTodos();
                if (productosActuales == null)
                {
                    productosActuales = new List<Producto>();
                }
                FiltrarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
                productosActuales = new List<Producto>();
            }
        }

        private void FiltrarProductos()
        {
            try
            {
                if (productosActuales == null) return;

                string busqueda = txtBusqueda.Text.Trim().ToLower();
                if (busqueda == "buscar por nombre o codigo...") busqueda = "";

                string categoria = cmbCategorias.SelectedItem?.ToString() ?? "Todas";

                var filtrados = productosActuales.Where(p =>
                    (categoria == "Todas" || (p.Categoria != null && p.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase))) &&
                    (string.IsNullOrEmpty(busqueda) ||
                     (p.Nombre != null && p.Nombre.ToLower().Contains(busqueda)) ||
                     (p.CodigoBarras != null && p.CodigoBarras.ToLower().Contains(busqueda)))
                ).ToList();

                GenerarTarjetas(filtrados);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error en filtrado: " + ex.Message);
            }
        }

        private void GenerarTarjetas(List<Producto> lista)
        {
            try
            {
                flpProductos.Controls.Clear();

                if (lista == null || lista.Count == 0)
                {
                    Label lblVacio = new Label
                    {
                        Text = "No hay productos para mostrar",
                        Font = new Font("Segoe UI", 14F, FontStyle.Italic),
                        ForeColor = Color.Gray,
                        AutoSize = true,
                        Padding = new Padding(20)
                    };
                    flpProductos.Controls.Add(lblVacio);
                    return;
                }

                foreach (var producto in lista)
                {
                    Panel tarjeta = CrearTarjetaProducto(producto);
                    flpProductos.Controls.Add(tarjeta);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar tarjetas: " + ex.Message);
            }
        }

        private Panel CrearTarjetaProducto(Producto producto)
        {
            Panel tarjeta = new Panel
            {
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(220, 280),
                Margin = new Padding(10)
            };

            Label lblIcono = new Label
            {
                Text = "BOX",
                Font = new Font("Segoe UI", 24F, FontStyle.Bold),
                AutoSize = false,
                Height = 80,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                ForeColor = Color.LightGray
            };
            tarjeta.Controls.Add(lblIcono);

            Label lblNombre = new Label
            {
                Text = producto.Nombre,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.Black,
                AutoSize = false,
                Height = 45,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                Padding = new Padding(5)
            };
            tarjeta.Controls.Add(lblNombre);

            Label lblCategoria = new Label
            {
                Text = producto.Categoria,
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.Gray,
                AutoSize = false,
                Height = 20,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter
            };
            tarjeta.Controls.Add(lblCategoria);

            Label lblPrecio = new Label
            {
                Text = $"RD$ {producto.PrecioVenta:N2}",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(45, 52, 54),
                AutoSize = false,
                Height = 30,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter
            };
            tarjeta.Controls.Add(lblPrecio);

            Label lblStock = new Label
            {
                Text = $"Stock: {producto.StockActual}",
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                ForeColor = ObtenerColorStock(producto.StockActual, producto.StockMinimo),
                AutoSize = false,
                Height = 20,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter
            };
            tarjeta.Controls.Add(lblStock);

            Panel pnlBotones = new Panel
            {
                BackColor = Color.FromArgb(242, 245, 248),
                Height = 50,
                Dock = DockStyle.Bottom,
                Padding = new Padding(5)
            };

            Button btnEditar = new Button
            {
                Text = "Editar",
                BackColor = Color.FromArgb(76, 175, 80),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                Size = new Size(95, 35),
                Location = new Point(10, 8)
            };
            btnEditar.Click += (s, e) => EditarProducto(producto);

            Button btnEliminar = new Button
            {
                Text = "Eliminar",
                BackColor = Color.FromArgb(255, 107, 107),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                Size = new Size(95, 35),
                Location = new Point(110, 8)
            };
            btnEliminar.Click += (s, e) => EliminarProducto(producto);

            pnlBotones.Controls.Add(btnEditar);
            pnlBotones.Controls.Add(btnEliminar);
            tarjeta.Controls.Add(pnlBotones);

            return tarjeta;
        }

        private Color ObtenerColorStock(decimal stockActual, decimal stockMinimo)
        {
            if (stockActual < stockMinimo) return Color.Red;
            if (stockActual <= stockMinimo * 1.5m) return Color.Orange;
            return Color.Green;
        }

        private void EditarProducto(Producto producto)
        {
            using (FrmEditarProducto frm = new FrmEditarProducto(producto))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarProductos();
                }
            }
        }

        private void EliminarProducto(Producto producto)
        {
            if (MessageBox.Show("Desea eliminar " + producto.Nombre + "?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    if (repProducto.EliminarProducto(producto.IdProducto))
                    {
                        MessageBox.Show("Producto eliminado");
                        CargarProductos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            FiltrarProductos();
        }

        private void cmbCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarProductos();
        }

        private void btnAgregarNuevo_Click(object sender, EventArgs e)
        {
            using (FrmNuevoProducto frm = new FrmNuevoProducto())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarProductos();
                }
            }
        }
    }
}
