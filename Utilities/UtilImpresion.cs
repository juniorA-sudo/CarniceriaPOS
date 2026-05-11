using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace CarniceriaPOS.Utilities
{
    public class UtilImpresion
    {
        private DataGridView dgv;
        private string titulo;
        private string descripcion;
        private string usuario;
        private int currentPage = 0;
        private int rowsPerPage = 18;

        private Color colorAzulOscuro = Color.FromArgb(30, 58, 95);
        private Color colorAzulClaro = Color.FromArgb(240, 248, 255);
        private Color colorGris = Color.FromArgb(100, 100, 100);

        public UtilImpresion(DataGridView dataGridView, string tituloReporte, string desc = "", string user = "")
        {
            dgv = dataGridView;
            titulo = tituloReporte;
            descripcion = desc;
            usuario = !string.IsNullOrEmpty(user) ? user : SesionActual.UsuarioActual?.NombreUsuario ?? "Sistema";
        }

        public void Imprimir()
        {
            try
            {
                PrintDocument printDoc = new PrintDocument();
                printDoc.DefaultPageSettings.Landscape = true;
                printDoc.DefaultPageSettings.Margins = new Margins(15, 15, 15, 15);
                printDoc.PrintPage += ImprimirPagina;

                PrintPreviewDialog previewDialog = new PrintPreviewDialog
                {
                    Document = printDoc,
                    Width = 1000,
                    Height = 800
                };

                previewDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al imprimir: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImprimirPagina(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            float y = 12;
            float margenIzquierdo = 15;
            float margenDerecho = 15;
            float ancho = e.PageBounds.Width - margenIzquierdo - margenDerecho;

            Font fuenteEmpresa = new Font("Arial", 12, FontStyle.Bold);
            Font fuenteSeccion = new Font("Arial", 7, FontStyle.Italic);
            Font fuenteTitulo = new Font("Arial", 11, FontStyle.Bold);
            Font fuenteSubtitulo = new Font("Arial", 7.5f);
            Font fuenteDatos = new Font("Arial", 7f);
            Font fuenteEncabezado = new Font("Arial", 7.5f, FontStyle.Bold);
            Font fuentePie = new Font("Arial", 7f);

            Brush pincelNegro = Brushes.Black;
            Brush pincelGris = new SolidBrush(colorGris);
            Brush pincelAzul = new SolidBrush(colorAzulOscuro);
            Pen lineaPrincipal = new Pen(colorAzulOscuro, 1.5f);
            Pen lineaGris = new Pen(Color.LightGray, 0.5f);

            
            g.DrawLine(lineaPrincipal, margenIzquierdo, y, margenIzquierdo + ancho, y);
            y += 4;

            
            g.DrawString("CARNICERIA POS", fuenteEmpresa, pincelAzul, margenIzquierdo, y);
            y += 14;

            
            g.DrawString("Sistema de Gestion de Carniceria", fuenteSeccion, pincelGris, margenIzquierdo, y);
            y += 6;

            
            g.DrawLine(lineaPrincipal, margenIzquierdo, y, margenIzquierdo + ancho, y);
            y += 8;

            
            g.DrawString(titulo, fuenteTitulo, pincelNegro, margenIzquierdo, y);
            y += 13;

            
            string infoCompleta = $"Generado: {DateTime.Now:dd/MM/yyyy HH:mm:ss}  |  Usuario: {usuario}";
            g.DrawString(infoCompleta, fuenteSubtitulo, pincelGris, margenIzquierdo, y);
            y += 8;

            
            if (!string.IsNullOrEmpty(descripcion))
            {
                string descCorta = descripcion.Length > 120 ? descripcion.Substring(0, 117) + "..." : descripcion;
                g.DrawString(descCorta, fuenteSubtitulo, pincelGris, margenIzquierdo, y);
                y += 8;
            }

            y += 3;

            
            float alturaEncabezado = 18;
            float alturaFila = 14;
            float anchoCol = ancho / dgv.Columns.Count;

            
            float xCol = margenIzquierdo;
            g.FillRectangle(new SolidBrush(colorAzulOscuro), margenIzquierdo, y, ancho, alturaEncabezado);

            
            g.DrawLine(lineaPrincipal, margenIzquierdo, y, margenIzquierdo + ancho, y);

            for (int col = 0; col < dgv.Columns.Count; col++)
            {
                StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center,
                    Trimming = StringTrimming.EllipsisWord
                };
                g.DrawString(dgv.Columns[col].HeaderText, fuenteEncabezado, Brushes.White,
                    new RectangleF(xCol + 1, y + 2, anchoCol - 2, alturaEncabezado - 4), sf);

                g.DrawLine(new Pen(Color.White, 0.5f), xCol + anchoCol, y, xCol + anchoCol, y + alturaEncabezado);
                xCol += anchoCol;
            }
            y += alturaEncabezado;

            
            int filaActual = currentPage * rowsPerPage;
            bool esFilaAlterna = false;

            while (filaActual < dgv.Rows.Count && y < e.PageBounds.Height - 40)
            {
                DataGridViewRow fila = dgv.Rows[filaActual];

                if (!fila.IsNewRow)
                {
                    
                    if (esFilaAlterna)
                    {
                        g.FillRectangle(new SolidBrush(colorAzulClaro),
                            margenIzquierdo, y, ancho, alturaFila);
                    }

                    xCol = margenIzquierdo;
                    for (int col = 0; col < dgv.Columns.Count; col++)
                    {
                        object valor = fila.Cells[col].Value;
                        string texto = valor != null ? valor.ToString().Trim() : "";

                        StringFormat sf = new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center,
                            Trimming = StringTrimming.EllipsisWord
                        };
                        g.DrawString(texto, fuenteDatos, pincelNegro,
                            new RectangleF(xCol + 1, y + 1, anchoCol - 2, alturaFila - 2), sf);

                        g.DrawLine(lineaGris, xCol, y, xCol, y + alturaFila);
                        xCol += anchoCol;
                    }

                    
                    g.DrawLine(lineaGris, margenIzquierdo + ancho, y, margenIzquierdo + ancho, y + alturaFila);
                    
                    g.DrawLine(lineaGris, margenIzquierdo, y + alturaFila, margenIzquierdo + ancho, y + alturaFila);

                    y += alturaFila;
                    esFilaAlterna = !esFilaAlterna;
                }

                filaActual++;
            }

            
            y = e.PageBounds.Height - 25;

            g.DrawLine(lineaPrincipal, margenIzquierdo, y, margenIzquierdo + ancho, y);
            y += 4;

            string infoPie = "CarniceriaPOS © - Sistema de Gestion";
            g.DrawString(infoPie, fuentePie, pincelGris, margenIzquierdo, y);

            string numPagina = $"Pagina {currentPage + 1}";
            SizeF tamano = g.MeasureString(numPagina, fuentePie);
            g.DrawString(numPagina, fuentePie, pincelGris,
                margenIzquierdo + ancho - tamano.Width, y);

            e.HasMorePages = (filaActual < dgv.Rows.Count);
            if (e.HasMorePages)
            {
                currentPage++;
            }

            fuenteEmpresa.Dispose();
            fuenteSeccion.Dispose();
            fuenteTitulo.Dispose();
            fuenteSubtitulo.Dispose();
            fuenteDatos.Dispose();
            fuenteEncabezado.Dispose();
            fuentePie.Dispose();
            lineaPrincipal.Dispose();
            lineaGris.Dispose();
        }
    }
}
