using System;
using System.Windows.Forms;
using CarniceriaPOS.Models;
using CarniceriaPOS.Utilities;

namespace CarniceriaPOS.UI.Forms
{
    public partial class FrmEditarLineItem : Form
    {
        private DetalleVenta detalleOriginal;
        private Producto producto;
        public DetalleVenta DetalleModificado { get; private set; }

        public FrmEditarLineItem(DetalleVenta detalle, Producto prod)
        {
            InitializeComponent();
            this.detalleOriginal = detalle;
            this.producto = prod;
        }

        private void FrmEditarLineItem_Load(object sender, EventArgs e)
        {
            this.Text = "Editar Linea de Venta";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new System.Drawing.Size(450, 350);

            ConstruirFormulario();
        }

        private void ConstruirFormulario()
        {
            
            var pnlMain = new Panel { Dock = DockStyle.Fill, Padding = new Padding(15) };

            
            var lblProducto = new Label
            {
                Text = "Producto:",
                Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold),
                Location = new System.Drawing.Point(15, 20),
                AutoSize = true
            };

            var txtProducto = new TextBox
            {
                Text = producto?.Nombre ?? "",
                Location = new System.Drawing.Point(15, 40),
                Width = 400,
                ReadOnly = true,
                BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            };

            
            var lblCantidad = new Label
            {
                Text = producto?.EsPesable == true ? "Peso (kg):" : "Cantidad (unidades):",
                Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold),
                Location = new System.Drawing.Point(15, 80),
                AutoSize = true
            };

            var numCantidad = new NumericUpDown
            {
                Location = new System.Drawing.Point(15, 100),
                Width = 150,
                DecimalPlaces = producto?.EsPesable == true ? 3 : 0,
                Minimum = 0,
                Value = producto?.EsPesable == true ? (decimal)detalleOriginal.Peso : detalleOriginal.Cantidad
            };

            
            var lblStockDisponible = new Label
            {
                Text = $"Stock disponible: {(producto?.EsPesable == true ? $"{producto.StockActualKg:F2} {producto.UnidadMedida}" : $"{producto?.StockActual} unidades")}",
                Font = new System.Drawing.Font("Segoe UI", 8),
                ForeColor = System.Drawing.Color.FromArgb(100, 100, 100),
                Location = new System.Drawing.Point(15, 125),
                AutoSize = true
            };

            
            var lblPrecio = new Label
            {
                Text = "Precio unitario:",
                Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold),
                Location = new System.Drawing.Point(15, 150),
                AutoSize = true
            };

            var txtPrecio = new TextBox
            {
                Text = $"${detalleOriginal.PrecioUnitario:N2}",
                Location = new System.Drawing.Point(15, 170),
                Width = 150,
                ReadOnly = true,
                BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
            };

            
            var lblSubtotal = new Label
            {
                Text = "Subtotal:",
                Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold),
                Location = new System.Drawing.Point(15, 210),
                AutoSize = true
            };

            var lblSubtotalVal = new Label
            {
                Text = $"${detalleOriginal.Subtotal:N2}",
                Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(74, 158, 255),
                Location = new System.Drawing.Point(15, 230),
                AutoSize = true
            };

            
            numCantidad.ValueChanged += (s, e) =>
            {
                decimal nuevaCantidad = numCantidad.Value;
                decimal nuevoSubtotal = CalculadorPrecio.CalcularSubtotal(producto, nuevaCantidad);
                lblSubtotalVal.Text = $"${nuevoSubtotal:N2}";
            };

            
            var pnlBotones = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 60,
                BackColor = System.Drawing.Color.FromArgb(245, 245, 245)
            };

            var btnGuardar = new Button
            {
                Text = " Guardar",
                BackColor = System.Drawing.Color.FromArgb(76, 175, 80),
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold),
                Width = 120,
                Height = 35,
                Location = new System.Drawing.Point(15, 12),
                Cursor = Cursors.Hand
            };
            btnGuardar.Click += (s, e) => GuardarCambios(numCantidad.Value);

            var btnCancelar = new Button
            {
                Text = " Cancelar",
                BackColor = System.Drawing.Color.FromArgb(220, 220, 220),
                ForeColor = System.Drawing.Color.FromArgb(26, 31, 46),
                Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold),
                Width = 120,
                Height = 35,
                Location = new System.Drawing.Point(145, 12),
                Cursor = Cursors.Hand
            };
            btnCancelar.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            pnlBotones.Controls.Add(btnGuardar);
            pnlBotones.Controls.Add(btnCancelar);

            
            pnlMain.Controls.Add(lblProducto);
            pnlMain.Controls.Add(txtProducto);
            pnlMain.Controls.Add(lblCantidad);
            pnlMain.Controls.Add(numCantidad);
            pnlMain.Controls.Add(lblStockDisponible);
            pnlMain.Controls.Add(lblPrecio);
            pnlMain.Controls.Add(txtPrecio);
            pnlMain.Controls.Add(lblSubtotal);
            pnlMain.Controls.Add(lblSubtotalVal);

            this.Controls.Add(pnlMain);
            this.Controls.Add(pnlBotones);
        }

        private void GuardarCambios(decimal nuevaCantidad)
        {
            if (producto == null)
            {
                MessageBox.Show("Error: Producto no valido");
                return;
            }

            
            if (!ValidadorStock.ValidarStock(producto, nuevaCantidad))
            {
                string mensajeError = ValidadorStock.ObtenerMensajeError(producto, nuevaCantidad);
                MessageBox.Show($"Stock insuficiente:\n\n{mensajeError}", "Error de Stock",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            DetalleModificado = new DetalleVenta
            {
                IdDetalle = detalleOriginal.IdDetalle,
                IdVenta = detalleOriginal.IdVenta,
                IdProducto = detalleOriginal.IdProducto,
                Cantidad = nuevaCantidad,
                Peso = 0,
                TipoCantidad = producto.AbreviacionUnidad ?? "Unidad",
                PrecioUnitario = detalleOriginal.PrecioUnitario,
                Descuento = detalleOriginal.Descuento,
                Subtotal = CalculadorPrecio.CalcularSubtotal(producto, nuevaCantidad),
                NombreProducto = detalleOriginal.NombreProducto
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }
    }
}
