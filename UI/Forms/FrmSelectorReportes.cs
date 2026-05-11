using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarniceriaPOS.UI.Forms
{
    public partial class FrmSelectorReportes : Form
    {
        public FrmSelectorReportes()
        {
        }

        private void FrmSelectorReportes_Load(object sender, EventArgs e)
        {
            this.Text = " Selector de Reportes - Sistema Carniceria";
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            CrearInterfaz();
        }

        private void CrearInterfaz()
        {
            Panel pnlMain = new Panel()
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(20)
            };

            Label lblTitulo = new Label()
            {
                Text = " SELECCIONA UN REPORTE PARA GENERAR",
                Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(230, 30, 120),
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 30)
            };
            pnlMain.Controls.Add(lblTitulo);

            
            var reportes = new (string titulo, string descripcion, string icono, Action accion)[]
            {
                ("Ventas Diarias", "Reporte detallado de ventas del dia actual", "", () =>
                {
                    AskForDateRange((inicio, fin) => {
                        var frm = new FrmReporteVentasDiarias(inicio, fin);
                        frm.Show();
                    });
                }),

                ("Inventario Actual", "Estado completo del inventario de productos", "", () =>
                {
                    var frm = new FrmReporteInventario();
                    frm.Show();
                }),

                ("Compras por Periodo", "Historial de compras realizadas", "", () =>
                {
                    AskForDateRange((inicio, fin) => {
                        var frm = new FrmReporteCompras(inicio, fin);
                        frm.Show();
                    });
                }),

                ("Clientes Registrados", "Listado completo de clientes", "", () =>
                {
                    var frm = new FrmReporteClientes();
                    frm.Show();
                }),

                ("Cierres de Caja", "Control y conciliacion de cierres diarios", "", () =>
                {
                    var frm = new FrmReporteCierresCaja();
                    frm.Show();
                }),

                ("Productos Mas Vendidos", "Analisis de productos con mayor demanda", "", () =>
                {
                    var frm = new FrmReporteProductosMasVendidos();
                    frm.Show();
                }),

                ("Inventario Bajo Stock", "Productos que requieren reorden urgente", "", () =>
                {
                    var frm = new FrmReporteInventarioBajoStock();
                    frm.Show();
                }),

                ("Ventas por Periodo", "Analisis de ventas en un rango de fechas", "", () =>
                {
                    AskForDateRange((inicio, fin) => {
                        //var frm = new FrmReporteVentasPeriodo(inicio, fin);
                        //frm.Show();
                    });
                }),

                ("Ventas por Vendedor", "Desempeno de cada vendedor", "", () =>
                {
                    //var frm = new FrmReporteVentasVendedor();
                    //frm.Show();
                }),

                ("Ingresos vs Egresos", "Analisis financiero completo del periodo", "", () =>
                {
                    var frm = new FrmReporteIngresosEgresos();
                    frm.Show();
                })
            };

            
            int contador = 0;
            foreach (var reporte in reportes)
            {
                Button btn = new Button()
                {
                    Width = pnlMain.Width - 40,
                    Height = 80,
                    Margin = new Padding(0, 0, 0, 15),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = System.Drawing.Color.White,
                    ForeColor = System.Drawing.Color.FromArgb(50, 50, 50),
                    Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Padding = new Padding(20, 10, 10, 10),
                    Text = $"{reporte.icono}  {reporte.titulo}\n{reporte.descripcion}",
                    Cursor = System.Windows.Forms.Cursors.Hand
                };

                btn.Click += (s, e) => reporte.accion();
                btn.MouseEnter += (s, e) => btn.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
                btn.MouseLeave += (s, e) => btn.BackColor = System.Drawing.Color.White;

                pnlMain.Controls.Add(btn);
                contador++;
            }

            this.Controls.Add(pnlMain);
        }

        private void AskForDateRange(Action<DateTime, DateTime> callback)
        {
            Form frmDate = new Form()
            {
                Text = "Seleccionar Periodo",
                Width = 400,
                Height = 200,
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label lblInicio = new Label() { Text = "Fecha Inicio:", Location = new System.Drawing.Point(20, 20), Width = 80 };
            DateTimePicker dtpInicio = new DateTimePicker() { Location = new System.Drawing.Point(100, 20), Width = 250, Value = DateTime.Now.AddMonths(-1) };

            Label lblFin = new Label() { Text = "Fecha Fin:", Location = new System.Drawing.Point(20, 60), Width = 80 };
            DateTimePicker dtpFin = new DateTimePicker() { Location = new System.Drawing.Point(100, 60), Width = 250, Value = DateTime.Now };

            Button btnAceptar = new Button() { Text = "Aceptar", Location = new System.Drawing.Point(200, 120), Width = 80, DialogResult = DialogResult.OK };
            Button btnCancelar = new Button() { Text = "Cancelar", Location = new System.Drawing.Point(290, 120), Width = 80, DialogResult = DialogResult.Cancel };

            btnAceptar.Click += (s, e) => {
                callback(dtpInicio.Value, dtpFin.Value);
                frmDate.Close();
            };

            frmDate.Controls.Add(lblInicio);
            frmDate.Controls.Add(dtpInicio);
            frmDate.Controls.Add(lblFin);
            frmDate.Controls.Add(dtpFin);
            frmDate.Controls.Add(btnAceptar);
            frmDate.Controls.Add(btnCancelar);

            frmDate.ShowDialog(this);
        }
    }
}
