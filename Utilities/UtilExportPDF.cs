using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CarniceriaPOS.Utilities
{
    public static class UtilExportPDF
    {

        public static bool ExportarDataGridViewAPDF(DataGridView dgv, string titulo, string descripcion = "", string firmante = "")
        {
            try
            {
                
                string nombreArchivo = $"Reporte_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    FileName = nombreArchivo,
                    Filter = "Archivos PDF (*.pdf)|*.pdf|Todos los archivos (*.*)|*.*",
                    Title = "Guardar reporte como PDF",
                    DefaultExt = "pdf"
                };

                if (saveDialog.ShowDialog() != DialogResult.OK)
                    return false;

                string rutaPDF = saveDialog.FileName;

                return GenerarHTMLyAbrir(dgv, titulo, descripcion, firmante, rutaPDF);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar: {ex.Message}\n\nIntentando alternativa HTML...",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public static bool ExportarDataGridViewAPDF(DataGridView dgv, string titulo)
        {
            return ExportarDataGridViewAPDF(dgv, titulo, "", "");
        }

        private static bool GenerarHTMLyAbrir(DataGridView dgv, string titulo, string descripcion, string firmante, string rutaPDF)
        {
            try
            {
                StringBuilder html = new StringBuilder();
                html.AppendLine("<!DOCTYPE html>");
                html.AppendLine("<html lang='es'>");
                html.AppendLine("<head>");
                html.AppendLine("<meta charset='utf-8'>");
                html.AppendLine("<meta name='viewport' content='width=device-width, initial-scale=1.0'>");
                html.AppendLine("<title>" + titulo + "</title>");
                html.AppendLine("<style>");
                GenerarEstilosCSS(html);
                html.AppendLine("</style>");
                html.AppendLine("</head>");
                html.AppendLine("<body>");
                html.AppendLine("<div class='contenedor'>");

                html.AppendLine("<div class='encabezado'>");
                html.AppendLine($"  <h1>{titulo}</h1>");
                html.AppendLine($"  <div class='fecha'>Fecha y hora: {DateTime.Now:dd/MM/yyyy HH:mm:ss}</div>");
                html.AppendLine("</div>");

                if (!string.IsNullOrEmpty(descripcion))
                {
                    html.AppendLine("<div class='descripcion'>");
                    html.AppendLine($"  <p>{EscapeHtml(descripcion)}</p>");
                    html.AppendLine("</div>");
                }

                html.AppendLine("<div class='datos'>");
                html.AppendLine("<table>");
                html.AppendLine("<thead><tr>");
                foreach (DataGridViewColumn columna in dgv.Columns)
                {
                    html.AppendLine($"<th>{EscapeHtml(columna.HeaderText)}</th>");
                }
                html.AppendLine("</tr></thead>");

                html.AppendLine("<tbody>");
                bool alterno = false;
                foreach (DataGridViewRow fila in dgv.Rows)
                {
                    if (fila.IsNewRow) continue;
                    string claseAlternada = alterno ? " class='alterno'" : "";
                    html.AppendLine($"<tr{claseAlternada}>");
                    for (int i = 0; i < dgv.ColumnCount; i++)
                    {
                        object valor = fila.Cells[i].Value;
                        string texto = valor != null ? valor.ToString() : "";
                        html.AppendLine($"<td>{EscapeHtml(texto)}</td>");
                    }
                    html.AppendLine("</tr>");
                    alterno = !alterno;
                }
                html.AppendLine("</tbody>");
                html.AppendLine("</table>");
                html.AppendLine("</div>");

                html.AppendLine("<div class='firma'>");
                html.AppendLine("<div class='firma-titulo'>FIRMA:</div>");
                if (string.IsNullOrEmpty(firmante))
                {
                    html.AppendLine("<div class='firma-linea'>Autorizado por: ________________________________    Fecha: ______________</div>");
                }
                else
                {
                    html.AppendLine($"<div class='firma-linea'>Autorizado por: {EscapeHtml(firmante).PadRight(25)}  Fecha: ______________</div>");
                }
                html.AppendLine("<div class='firma-nota'>Documento interno - Uso exclusivo de la empresa</div>");
                html.AppendLine("</div>");

                html.AppendLine("<div class='botones noprint'>");
                html.AppendLine("<button onclick='window.print()'> Imprimir / Guardar como PDF</button>");
                html.AppendLine("<button onclick='window.close()'> Cerrar</button>");
                html.AppendLine("</div>");

                html.AppendLine("<div class='pie'>CarniceriaPOS - Reporte del Sistema</div>");

                html.AppendLine("</div>");
                html.AppendLine("</body>");
                html.AppendLine("</html>");

                string carpetaReportes = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                string nombreArchivo = $"Reporte_{titulo.Replace(" ", "_").Replace(":", "")}" +
                                     $"_{DateTime.Now:yyyyMMdd_HHmmss}.html";
                string rutaHTML = Path.Combine(carpetaReportes, nombreArchivo);

                try
                {
                    
                    File.WriteAllText(rutaHTML, html.ToString(), Encoding.UTF8);
                }
                catch (Exception exWrite)
                {
                    
                    try
                    {
                        carpetaReportes = Path.Combine(Path.GetTempPath(), "CarniceriaPOS");
                        if (!Directory.Exists(carpetaReportes))
                        {
                            Directory.CreateDirectory(carpetaReportes);
                        }
                        rutaHTML = Path.Combine(carpetaReportes, nombreArchivo);
                        File.WriteAllText(rutaHTML, html.ToString(), Encoding.UTF8);
                    }
                    catch
                    {
                        MessageBox.Show($"No se puede guardar el reporte.\n\nError: {exWrite.Message}\n\nIntenta ejecutar la aplicacion como administrador.",
                            "Error de Permisos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                try
                {
                    System.Diagnostics.Process.Start(rutaHTML);
                    MessageBox.Show($" Reporte guardado en el Escritorio\n\n" +
                        $"Archivo: {nombreArchivo}\n\n" +
                        $"Usa Ctrl+P en el navegador para imprimir/guardar como PDF.",
                        "Reporte Abierto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show($" El reporte se guardo en:\n{rutaHTML}\n\nAbrelo manualmente con tu navegador.",
                        "Reporte Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar reporte:\n{ex.Message}\n\nIntenta nuevamente o verifica que tengas permisos de escritura.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private static bool GenerarHTMLyAbrir(DataGridView dgv, string titulo)
        {
            return GenerarHTMLyAbrir(dgv, titulo, "", "", "");
        }

        private static void GuardarHTMLComoPDF(string rutaHTML, string rutaPDF)
        {
            try
            {

                System.Diagnostics.Process.Start($"microsoft-edge:{rutaHTML}");
            }
            catch
            {
                
                try
                {
                    System.Diagnostics.Process.Start(rutaHTML);
                }
                catch { }
            }
        }

        private static void GenerarEstilosCSS(StringBuilder html)
        {
            html.AppendLine("* { margin: 0; padding: 0; box-sizing: border-box; }");
            html.AppendLine("html, body { height: 100%; }");
            html.AppendLine("body {");
            html.AppendLine("  font-family: 'Segoe UI', Arial, sans-serif;");
            html.AppendLine("  background: white;");
            html.AppendLine("  color: #333;");
            html.AppendLine("}");

            html.AppendLine("@media print {");
            html.AppendLine("  .noprint { display: none !important; }");
            html.AppendLine("  body { margin: 0; padding: 10mm; }");
            html.AppendLine("  .contenedor { box-shadow: none; }");
            html.AppendLine("}");

            html.AppendLine(".contenedor {");
            html.AppendLine("  max-width: 1000px;");
            html.AppendLine("  margin: 0 auto;");
            html.AppendLine("  padding: 20px;");
            html.AppendLine("  background: white;");
            html.AppendLine("}");

            html.AppendLine(".encabezado {");
            html.AppendLine("  display: flex;");
            html.AppendLine("  justify-content: space-between;");
            html.AppendLine("  align-items: center;");
            html.AppendLine("  margin-bottom: 25px;");
            html.AppendLine("  border-bottom: 3px solid #1e3a5f;");
            html.AppendLine("  padding-bottom: 15px;");
            html.AppendLine("}");

            html.AppendLine("h1 {");
            html.AppendLine("  color: #1e3a5f;");
            html.AppendLine("  font-size: 28px;");
            html.AppendLine("  font-weight: bold;");
            html.AppendLine("  margin: 0;");
            html.AppendLine("}");

            html.AppendLine(".fecha {");
            html.AppendLine("  font-size: 11px;");
            html.AppendLine("  color: #666;");
            html.AppendLine("  text-align: right;");
            html.AppendLine("  white-space: nowrap;");
            html.AppendLine("}");

            html.AppendLine(".descripcion {");
            html.AppendLine("  background-color: #f5f5f5;");
            html.AppendLine("  border-left: 4px solid #1e3a5f;");
            html.AppendLine("  padding: 12px 15px;");
            html.AppendLine("  margin-bottom: 20px;");
            html.AppendLine("  border-radius: 3px;");
            html.AppendLine("}");

            html.AppendLine(".descripcion p {");
            html.AppendLine("  margin: 0;");
            html.AppendLine("  font-size: 13px;");
            html.AppendLine("  color: #555;");
            html.AppendLine("  line-height: 1.5;");
            html.AppendLine("}");

            html.AppendLine(".datos {");
            html.AppendLine("  margin: 25px 0;");
            html.AppendLine("  overflow-x: auto;");
            html.AppendLine("}");

            html.AppendLine("table {");
            html.AppendLine("  width: 100%;");
            html.AppendLine("  border-collapse: collapse;");
            html.AppendLine("  margin: 0;");
            html.AppendLine("  box-shadow: 0 2px 4px rgba(0,0,0,0.1);");
            html.AppendLine("}");

            html.AppendLine("th {");
            html.AppendLine("  background-color: #1e3a5f;");
            html.AppendLine("  color: white;");
            html.AppendLine("  padding: 14px 12px;");
            html.AppendLine("  text-align: left;");
            html.AppendLine("  font-weight: bold;");
            html.AppendLine("  font-size: 12px;");
            html.AppendLine("  border: 1px solid #1e3a5f;");
            html.AppendLine("}");

            html.AppendLine("td {");
            html.AppendLine("  padding: 10px 12px;");
            html.AppendLine("  border: 1px solid #ddd;");
            html.AppendLine("  font-size: 12px;");
            html.AppendLine("}");

            html.AppendLine("tr:not(.alterno) {");
            html.AppendLine("  background-color: white;");
            html.AppendLine("}");

            html.AppendLine("tr.alterno {");
            html.AppendLine("  background-color: #f0f8ff;");
            html.AppendLine("}");

            html.AppendLine("tr:hover {");
            html.AppendLine("  background-color: #e6f2ff;");
            html.AppendLine("}");

            html.AppendLine(".firma {");
            html.AppendLine("  margin-top: 40px;");
            html.AppendLine("  padding-top: 30px;");
            html.AppendLine("  border-top: 1px solid #ddd;");
            html.AppendLine("}");

            html.AppendLine(".firma-titulo {");
            html.AppendLine("  font-size: 13px;");
            html.AppendLine("  font-weight: bold;");
            html.AppendLine("  color: #0d47a1;");
            html.AppendLine("  margin-bottom: 14px;");
            html.AppendLine("}");

            html.AppendLine(".firma-linea {");
            html.AppendLine("  font-size: 10px;");
            html.AppendLine("  font-weight: bold;");
            html.AppendLine("  color: #1565c0;");
            html.AppendLine("  margin-bottom: 8px;");
            html.AppendLine("  font-family: monospace;");
            html.AppendLine("}");

            html.AppendLine(".firma-nota {");
            html.AppendLine("  font-size: 8px;");
            html.AppendLine("  font-style: italic;");
            html.AppendLine("  color: #999;");
            html.AppendLine("  margin-top: 8px;");
            html.AppendLine("}");

            html.AppendLine(".botones {");
            html.AppendLine("  margin: 25px 0;");
            html.AppendLine("  text-align: center;");
            html.AppendLine("}");

            html.AppendLine(".botones button {");
            html.AppendLine("  background: #1e3a5f;");
            html.AppendLine("  color: white;");
            html.AppendLine("  border: none;");
            html.AppendLine("  padding: 12px 24px;");
            html.AppendLine("  border-radius: 4px;");
            html.AppendLine("  cursor: pointer;");
            html.AppendLine("  font-size: 14px;");
            html.AppendLine("  margin: 0 8px;");
            html.AppendLine("  transition: background 0.3s;");
            html.AppendLine("}");

            html.AppendLine(".botones button:hover {");
            html.AppendLine("  background: #0d1f31;");
            html.AppendLine("}");

            html.AppendLine(".pie {");
            html.AppendLine("  text-align: center;");
            html.AppendLine("  font-size: 10px;");
            html.AppendLine("  margin-top: 30px;");
            html.AppendLine("  padding-top: 15px;");
            html.AppendLine("  border-top: 1px solid #ddd;");
            html.AppendLine("  color: #999;");
            html.AppendLine("}");
        }

        private static string EscapeHtml(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return "";

            return texto
                .Replace("&", "&amp;")
                .Replace("<", "&lt;")
                .Replace(">", "&gt;")
                .Replace("\"", "&quot;")
                .Replace("'", "&#39;");
        }
    }
}
