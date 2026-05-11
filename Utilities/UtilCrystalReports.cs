using System;
using System.Windows.Forms;
using System.Data;

namespace CarniceriaPOS.Utilities
{
    
    
    
    public static class UtilCrystalReports
    {
        
        
        
        public static void MostrarReporte(DataTable datos, string titulo, string descripcion = "", string firmante = "")
        {
            try
            {
                
                Form frmPreview = new Form
                {
                    Text = titulo,
                    Width = 1000,
                    Height = 700,
                    StartPosition = FormStartPosition.CenterScreen
                };

                
                Panel pnlMain = new Panel { Dock = DockStyle.Fill };
                frmPreview.Controls.Add(pnlMain);

                
                Panel pnlHeader = new Panel
                {
                    Dock = DockStyle.Top,
                    Height = 120,
                    BackColor = System.Drawing.Color.FromArgb(30, 58, 95),
                    Padding = new System.Windows.Forms.Padding(15)
                };
                pnlMain.Controls.Add(pnlHeader);

                
                Label lblTitulo = new Label
                {
                    Text = titulo,
                    Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Bold),
                    ForeColor = System.Drawing.Color.White,
                    AutoSize = false,
                    Height = 35,
                    Dock = DockStyle.Top
                };
                pnlHeader.Controls.Add(lblTitulo);

                
                Label lblFecha = new Label
                {
                    Text = $"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm:ss} | {descripcion}",
                    Font = new System.Drawing.Font("Segoe UI", 9),
                    ForeColor = System.Drawing.Color.LightGray,
                    AutoSize = false,
                    Dock = DockStyle.Top
                };
                pnlHeader.Controls.Add(lblFecha);

                
                Panel pnlDatos = new Panel
                {
                    Dock = DockStyle.Fill,
                    Padding = new System.Windows.Forms.Padding(10)
                };
                pnlMain.Controls.Add(pnlDatos);

                
                DataGridView dgv = new DataGridView
                {
                    DataSource = datos,
                    Dock = DockStyle.Fill,
                    ReadOnly = true,
                    AllowUserToAddRows = false,
                    AllowUserToDeleteRows = false,
                    EnableHeadersVisualStyles = false,
                    BorderStyle = System.Windows.Forms.BorderStyle.None,
                    ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                    {
                        BackColor = System.Drawing.Color.FromArgb(30, 58, 95),
                        ForeColor = System.Drawing.Color.White,
                        Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold),
                        Alignment = DataGridViewContentAlignment.MiddleCenter,
                        Padding = new System.Windows.Forms.Padding(5)
                    },
                    ColumnHeadersHeight = 35,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        BackColor = System.Drawing.Color.White,
                        ForeColor = System.Drawing.Color.FromArgb(51, 51, 51),
                        Font = new System.Drawing.Font("Segoe UI", 9),
                        Padding = new System.Windows.Forms.Padding(5)
                    },
                    AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
                    {
                        BackColor = System.Drawing.Color.FromArgb(240, 248, 255)
                    },
                    GridColor = System.Drawing.Color.FromArgb(200, 220, 235),
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                    RowTemplate = { Height = 28 }
                };

                pnlDatos.Controls.Add(dgv);

                
                Panel pnlBotones = new Panel
                {
                    Dock = DockStyle.Bottom,
                    Height = 50,
                    BackColor = System.Drawing.Color.FromArgb(245, 247, 250),
                    Padding = new System.Windows.Forms.Padding(10)
                };
                frmPreview.Controls.Add(pnlBotones);

                
                Button btnImprimir = new Button
                {
                    Text = "️ Imprimir",
                    Width = 120,
                    Height = 35,
                    Location = new System.Drawing.Point(10, 7),
                    BackColor = System.Drawing.Color.FromArgb(30, 58, 95),
                    ForeColor = System.Drawing.Color.White,
                    Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat,
                    Cursor = System.Windows.Forms.Cursors.Hand
                };

                btnImprimir.Click += (s, e) =>
                {
                    try
                    {
                        PrintDialog printDialog = new PrintDialog();
                        if (printDialog.ShowDialog() == DialogResult.OK)
                        {
                            System.Drawing.Printing.PrintDocument printDoc = new System.Drawing.Printing.PrintDocument();
                            printDoc.PrinterSettings = printDialog.PrinterSettings;
                            printDoc.Print();
                            MessageBox.Show("Enviado a imprimir", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al imprimir: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                pnlBotones.Controls.Add(btnImprimir);

                
                Button btnExportar = new Button
                {
                    Text = " Exportar PDF",
                    Width = 120,
                    Height = 35,
                    Location = new System.Drawing.Point(140, 7),
                    BackColor = System.Drawing.Color.FromArgb(0, 150, 136),
                    ForeColor = System.Drawing.Color.White,
                    Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat,
                    Cursor = System.Windows.Forms.Cursors.Hand
                };

                btnExportar.Click += (s, e) =>
                {
                    try
                    {
                        SaveFileDialog saveDialog = new SaveFileDialog
                        {
                            FileName = $"Reporte_{titulo}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf",
                            Filter = "Archivos PDF (*.pdf)|*.pdf",
                            Title = "Guardar reporte como PDF"
                        };

                        if (saveDialog.ShowDialog() == DialogResult.OK)
                        {
                            ExportarDataGridViewAPDF(dgv, titulo, descripcion, firmante, saveDialog.FileName);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al exportar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                pnlBotones.Controls.Add(btnExportar);

                
                Button btnCerrar = new Button
                {
                    Text = " Cerrar",
                    Width = 100,
                    Height = 35,
                    Location = new System.Drawing.Point(270, 7),
                    BackColor = System.Drawing.Color.FromArgb(192, 192, 192),
                    ForeColor = System.Drawing.Color.Black,
                    Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat,
                    Cursor = System.Windows.Forms.Cursors.Hand
                };

                btnCerrar.Click += (s, e) => frmPreview.Close();
                pnlBotones.Controls.Add(btnCerrar);

                frmPreview.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al mostrar reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        
        
        private static void ExportarDataGridViewAPDF(DataGridView dgv, string titulo, string descripcion, string firmante, string rutaPDF)
        {
            try
            {
                
                UtilExportPDF.ExportarDataGridViewAPDF(dgv, titulo, descripcion, firmante);
                MessageBox.Show($"Reporte exportado a:\n{rutaPDF}", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
