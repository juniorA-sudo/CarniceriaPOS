using System;
using System.Windows.Forms;
using CarniceriaPOS.Models;

namespace CarniceriaPOS.UI.Forms
{
    public partial class FrmConfirmarVenta : Form
    {
        private Venta ventaActual;
        private Cliente clienteSeleccionado;
        private MetodoPago metodoSeleccionado;

        public FrmConfirmarVenta(Venta venta, Cliente cliente, MetodoPago metodo)
        {
            InitializeComponent();
            this.ventaActual = venta;
            this.clienteSeleccionado = cliente;
            this.metodoSeleccionado = metodo;
        }

        private void FrmConfirmarVenta_Load(object sender, EventArgs e)
        {
            this.Text = "Confirmar Venta";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new System.Drawing.Size(450, 350);

            CargarDatosVenta();
        }

        private void CargarDatosVenta()
        {
            if (ventaActual == null) return;

            var pnlInfo = new Panel
            {
                Dock = DockStyle.Top,
                Height = 200,
                BackColor = System.Drawing.Color.FromArgb(240, 240, 240),
                Padding = new Padding(15)
            };

            var lblNumVenta = new Label
            {
                Text = $"Naomero de Venta: {ventaActual.NumeroVenta}",
                Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold),
                Dock = DockStyle.Top,
                AutoSize = true,
                Margin = new Padding(0, 5, 0, 5)
            };

            var lblCliente = new Label
            {
                Text = $"Cliente: {(clienteSeleccionado?.Nombre ?? "No seleccionado")}",
                Font = new System.Drawing.Font("Segoe UI", 9),
                Dock = DockStyle.Top,
                AutoSize = true,
                Margin = new Padding(0, 5, 0, 5)
            };

            var lblMetodo = new Label
            {
                Text = $"Metodo: {(metodoSeleccionado?.Nombre ?? "Efectivo")}",
                Font = new System.Drawing.Font("Segoe UI", 9),
                Dock = DockStyle.Top,
                AutoSize = true,
                Margin = new Padding(0, 5, 0, 5)
            };

            var lblSeparador = new Label
            {
                Text = "a"a"a"a"a"a"a"a"a"a"a"a"a"a"a"a"a"a"a"a"a"a"a"a"a",
                Dock = DockStyle.Top,
                AutoSize = true,
                Margin = new Padding(0, 10, 0, 5)
            };

            var lblSubtotal = new Label
            {
                Text = $"Subtotal: ${ventaActual.Subtotal:N2}",
                Font = new System.Drawing.Font("Segoe UI", 9),
                Dock = DockStyle.Top,
                AutoSize = true,
                Margin = new Padding(0, 5, 0, 5)
            };

            var lblImpuesto = new Label
            {
                Text = $"Impuesto (12%): ${ventaActual.Impuesto:N2}",
                Font = new System.Drawing.Font("Segoe UI", 9),
                Dock = DockStyle.Top,
                AutoSize = true,
                Margin = new Padding(0, 5, 0, 5)
            };

            var lblTotal = new Label
            {
                Text = $"TOTAL: ${ventaActual.Total:N2}",
                Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(74, 158, 255),
                Dock = DockStyle.Top,
                AutoSize = true,
                Margin = new Padding(0, 10, 0, 5)
            };

            pnlInfo.Controls.Add(lblTotal);
            pnlInfo.Controls.Add(lblImpuesto);
            pnlInfo.Controls.Add(lblSubtotal);
            pnlInfo.Controls.Add(lblSeparador);
            pnlInfo.Controls.Add(lblMetodo);
            pnlInfo.Controls.Add(lblCliente);
            pnlInfo.Controls.Add(lblNumVenta);

            this.Controls.Add(pnlInfo);

            var pnlBotones = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 60,
                BackColor = System.Drawing.Color.White,
                Padding = new Padding(15)
            };

            var btnConfirmar = new Button
            {
                Text = " Confirmar",
                BackColor = System.Drawing.Color.FromArgb(76, 175, 80),
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold),
                Width = 150,
                Height = 35,
                Cursor = Cursors.Hand,
                Dock = DockStyle.Right,
                Margin = new Padding(0, 0, 10, 0)
            };
            btnConfirmar.Click += (s, e) => { this.DialogResult = DialogResult.OK; this.Close(); };

            var btnCancelar = new Button
            {
                Text = " Cancelar",
                BackColor = System.Drawing.Color.FromArgb(220, 220, 220),
                ForeColor = System.Drawing.Color.FromArgb(26, 31, 46),
                Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold),
                Width = 150,
                Height = 35,
                Cursor = Cursors.Hand,
                Dock = DockStyle.Right,
                Margin = new Padding(0, 0, 10, 0)
            };
            btnCancelar.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            pnlBotones.Controls.Add(btnConfirmar);
            pnlBotones.Controls.Add(btnCancelar);

            this.Controls.Add(pnlBotones);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }
    }
}
