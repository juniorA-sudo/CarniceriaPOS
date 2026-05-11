using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CarniceriaPOS.Utilities;
using Guna.UI2.WinForms;

namespace CarniceriaPOS.UI.Forms
{
    [DesignerCategory("")]
    public partial class FrmReporteBase : Form
    {
        private DataGridView _dgvDatosReal;
        private Panel _pnlFirmaFooter;

        public FrmReporteBase()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            this.Load += new EventHandler(FrmReporteBase_Load);

            ConfigurarHeaderDocumento();
            ConfigurarDataGridEstilizado();
            ConfigurarFooterFirmas();
        }

        protected virtual void FrmReporteBase_Load(object sender, EventArgs e)
        {
        }

        private void ConfigurarHeaderDocumento()
        {
            Guna2Panel pnlBannerAzul = new Guna2Panel
            {
                Dock = DockStyle.Top,
                Height = 140,
                FillColor = Color.FromArgb(52, 152, 219),
                Padding = new Padding(30, 20, 30, 20)
            };

            Label lblInfoEmpresa = new Label
            {
                Text = "CARNICERIA POS\n\ninfo@carniceria.com\n(829) 123-4567\nCalle Principal #123, Santo Domingo",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(30, 25),
                BackColor = Color.Transparent
            };

            Label lblInfoEmision = new Label
            {
                Text = $"Emitido por: {SesionActual.UsuarioActual?.NombreUsuario ?? "Admin"}\nRNC: 00000-00\nFecha: {DateTime.Now:dd/MM/yyyy}",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.TopRight,
                AutoSize = false,
                Size = new Size(300, 80),
                Location = new Point(750, 25),
                BackColor = Color.Transparent
            };

            pnlBannerAzul.Controls.Add(lblInfoEmpresa);
            pnlBannerAzul.Controls.Add(lblInfoEmision);

            pnlDocumento.Controls.Add(pnlBannerAzul);
            pnlBannerAzul.SendToBack();
            lblTituloReporte.BringToFront();
        }

        private void ConfigurarDataGridEstilizado()
        {
            pnlDatos.Padding = new Padding(20, 30, 20, 10);

            _dgvDatosReal = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                AllowUserToAddRows = false,
                AllowUserToOrderColumns = false,
                ReadOnly = true,
                EnableHeadersVisualStyles = false,
                RowTemplate = { Height = 35 },
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                GridColor = Color.FromArgb(231, 239, 246),
                RowHeadersVisible = false
            };

            _dgvDatosReal.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            _dgvDatosReal.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            _dgvDatosReal.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            _dgvDatosReal.ColumnHeadersHeight = 40;

            _dgvDatosReal.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            _dgvDatosReal.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            _dgvDatosReal.DefaultCellStyle.SelectionForeColor = Color.White;

            pnlDatos.Controls.Add(_dgvDatosReal);
            pnlDatos.BringToFront();
        }

        private void ConfigurarFooterFirmas()
        {
            _pnlFirmaFooter = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 120,
                BackColor = Color.White
            };

            Label line1 = new Label { Text = "__________________________", Location = new Point(150, 50), AutoSize = true };
            Label sub1 = new Label { Text = "Firma Emisor", Location = new Point(190, 75), AutoSize = true, Font = new Font("Segoe UI", 8, FontStyle.Bold) };

            Label line2 = new Label { Text = "__________________________", Location = new Point(700, 50), AutoSize = true };
            Label sub2 = new Label { Text = "Firma Receptor", Location = new Point(740, 75), AutoSize = true, Font = new Font("Segoe UI", 8, FontStyle.Bold) };

            _pnlFirmaFooter.Controls.AddRange(new Control[] { line1, sub1, line2, sub2 });
            pnlDocumento.Controls.Add(_pnlFirmaFooter);
            _pnlFirmaFooter.BringToFront();
        }

        protected DataGridView DgvDatos => _dgvDatosReal;

        // El metodo BtnCerrar_Click se mantiene por si los hijos necesitan 
        // llamarlo manualmente, pero ya no esta vinculado al boton de la base.
        protected virtual void BtnCerrar_Click(object sender, EventArgs e) => this.Close();
    }
}