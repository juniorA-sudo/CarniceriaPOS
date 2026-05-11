using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using CarniceriaPOS.Business;
using CarniceriaPOS.Utilities;
using System.IO;

namespace CarniceriaPOS.UI.Forms
{
    public partial class FrmReportes : Form
    {
        private Form _reporteActivo;
        private string _tabActual = "GENERALES";

        private class ReporteItem
        {
            public string Titulo { get; set; }
            public string Descripcion { get; set; }
            public string Categoria { get; set; }
            public string Tipo { get; set; } // GENERALES o ESPECÍFICOS
            public Color ColorTema { get; set; }
            public string RutaImagen { get; set; }
            public Func<Form> Fabrica { get; set; }
        }

        public FrmReportes()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {
            if (!SesionActual.TieneAcceso("Reportes"))
            {
                MessageBox.Show("No tiene permiso para acceder a los reportes del sistema.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            flpReportes.WrapContents = true;
            flpReportes.AutoScroll = true;

            lineSelected.Width = btnGenerales.Width;
            lineSelected.Left = btnGenerales.Left;

            CargarContenidoTab();
        }

        private void Tab_Click(object sender, EventArgs e)
        {
            Guna2Button btn = (Guna2Button)sender;
            lineSelected.Width = btn.Width;
            lineSelected.Left = btn.Left;

            _tabActual = btn.Text.ToUpper();
            CargarContenidoTab();
        }

        private void CargarContenidoTab()
        {
            flpReportes.Controls.Clear();

            var todosLosReportes = new List<ReporteItem>
            {
                // --- REPORTES GENERALES ---
                new ReporteItem {
                    Titulo = "Reporte de Productos",
                    Descripcion = "Listado maestro de la tabla productos.",
                    Categoria = "INVENTARIO",
                    Tipo = "GENERALES",
                    ColorTema = Color.FromArgb(230, 126, 34),
                    RutaImagen = @"C:\Users\grego\source\repos\CarniceriaPOS\CarniceriaPOS\Assets\Images\productos.jpg",
                    Fabrica = () => new FrmReporteProductos()
                },
                new ReporteItem {
                    Titulo = "Reporte de Clientes",
                    Descripcion = "Base de datos completa de la tabla clientes.",
                    Categoria = "CLIENTES",
                    Tipo = "GENERALES",
                    ColorTema = Color.FromArgb(155, 89, 182),
                    RutaImagen = @"C:\Users\grego\source\repos\CarniceriaPOS\CarniceriaPOS\Assets\Images\clientes.jpg",
                    Fabrica = () => new FrmReporteClientes()
                },
                new ReporteItem {
                    Titulo = "Reporte de Empleados",
                    Descripcion = "Listado del personal registrado en la tabla empleados.",
                    Categoria = "FINANZAS",
                    Tipo = "GENERALES",
                    ColorTema = Color.FromArgb(52, 73, 94),
                    RutaImagen = @"C:\Users\grego\source\repos\CarniceriaPOS\CarniceriaPOS\Assets\Images\empleados.jpg",
                    Fabrica = () => new FrmReporteEmpleados()
                },
                new ReporteItem {
                    Titulo = "Reporte de Proveedores",
                    Descripcion = "Listado completo de proveedores registrados.",
                    Categoria = "COMPRAS",
                    Tipo = "GENERALES",
                    ColorTema = Color.FromArgb(44, 62, 80),
                    RutaImagen = @"C:\Users\grego\source\repos\CarniceriaPOS\CarniceriaPOS\Assets\Images\proveedores.jpeg",
                    Fabrica = () => new FrmReporteProveedores()
                },
                new ReporteItem {
                    Titulo = "Auditoría de Sistema",
                    Descripcion = "Historial de acciones, inicios de sesión y movimientos de usuarios.",
                    Categoria = "SEGURIDAD",
                    Tipo = "GENERALES",
                    ColorTema = Color.FromArgb(192, 57, 43),
                    RutaImagen = @"C:\Users\grego\source\repos\CarniceriaPOS\CarniceriaPOS\Assets\Images\auditoria.jpg",
                    Fabrica = () => new FrmReporteAuditoria()
                },

                // --- REPORTES ESPECÍFICOS ---
                new ReporteItem {
                    Titulo = "Ventas Diarias",
                    Descripcion = "Consulta el detalle de ingresos y facturación del día de hoy.",
                    Categoria = "VENTAS",
                    Tipo = "ESPECÍFICOS",
                    ColorTema = Color.FromArgb(46, 204, 113),
                    RutaImagen = @"C:\Users\grego\source\repos\CarniceriaPOS\CarniceriaPOS\Assets\Images\ventasdiarias.jpg",
                    Fabrica = () => new FrmReporteVentasDiarias(DateTime.Today, DateTime.Today)
                }
            };

            var filtrados = todosLosReportes.Where(r => r.Tipo.Equals(_tabActual, StringComparison.OrdinalIgnoreCase)).ToList();

            foreach (var repo in filtrados)
            {
                CrearTarjetaReporte(repo);
            }
        }

        private void CrearTarjetaReporte(ReporteItem item)
        {
            Guna2Panel card = new Guna2Panel
            {
                Size = new Size(320, 390),
                FillColor = Color.White,
                BorderRadius = 15,
                Margin = new Padding(15),
            };
            card.ShadowDecoration.Enabled = true;
            card.ShadowDecoration.Depth = 8;
            card.ShadowDecoration.Color = Color.Silver;

            Guna2Panel pnlImagen = new Guna2Panel
            {
                Size = new Size(320, 160),
                Dock = DockStyle.Top,
                FillColor = Color.FromArgb(245, 246, 250),
                BorderRadius = 15
            };

            if (!string.IsNullOrEmpty(item.RutaImagen) && File.Exists(item.RutaImagen))
            {
                PictureBox pb = new PictureBox
                {
                    Image = Image.FromFile(item.RutaImagen),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Dock = DockStyle.Fill
                };
                pnlImagen.Controls.Add(pb);
            }
            else
            {
                Label lblPlaceholder = new Label
                {
                    Text = "📊",
                    Font = new Font("Segoe UI", 40F),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    ForeColor = Color.Gainsboro
                };
                pnlImagen.Controls.Add(lblPlaceholder);
            }

            Label lblCat = new Label
            {
                Text = item.Categoria,
                ForeColor = item.ColorTema,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                Location = new Point(20, 175),
                AutoSize = true
            };

            Label lblTit = new Label
            {
                Text = item.Titulo,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(45, 52, 54),
                Location = new Point(18, 195),
                Size = new Size(280, 30)
            };

            Label lblDesc = new Label
            {
                Text = item.Descripcion,
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = Color.FromArgb(108, 117, 125),
                Location = new Point(20, 230),
                Size = new Size(280, 50)
            };

            Guna2Button btn = new Guna2Button
            {
                Text = "VER REPORTE",
                FillColor = item.ColorTema,
                BorderRadius = 8,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.White,
                Size = new Size(160, 42),
                Location = new Point(20, 330),
                Cursor = Cursors.Hand
            };

            btn.Click += (s, e) => {
                Form frm = item.Fabrica();
                if (frm != null) AbrirReporteEnContenido(frm, item.Titulo);
            };

            card.Controls.Add(btn);
            card.Controls.Add(lblDesc);
            card.Controls.Add(lblTit);
            card.Controls.Add(lblCat);
            card.Controls.Add(pnlImagen);

            flpReportes.Controls.Add(card);
        }

        private void AbrirReporteEnContenido(Form reporte, string titulo)
        {
            if (reporte == null) return;
            if (_reporteActivo != null) { _reporteActivo.Close(); _reporteActivo.Dispose(); }

            _reporteActivo = reporte;
            lblTitulo.Text = titulo;
            btnVolver.Visible = true;
            pnlSelector.Visible = false;
            pnlNav.Visible = false;

            reporte.TopLevel = false;
            reporte.FormBorderStyle = FormBorderStyle.None;
            reporte.Dock = DockStyle.Fill;

            pnlReportHost.Controls.Clear();
            pnlReportHost.Controls.Add(reporte);
            pnlReportHost.Visible = true;
            reporte.Show();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            if (_reporteActivo != null) { _reporteActivo.Close(); _reporteActivo.Dispose(); _reporteActivo = null; }
            lblTitulo.Text = "Panel de Reportes";
            btnVolver.Visible = false;
            pnlReportHost.Visible = false;
            pnlSelector.Visible = true;
            pnlNav.Visible = true;
        }
    }
}