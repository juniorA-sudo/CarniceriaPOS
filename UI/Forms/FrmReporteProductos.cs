using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using CarniceriaPOS.Data;
using CarniceriaPOS.Models;

namespace CarniceriaPOS.UI.Forms
{
    public partial class FrmReporteProductos : FrmReporteBase
    {
        private RepositorioProducto _repo;
        private List<Producto> _listaProductos;

        public FrmReporteProductos() : base()
        {
            _repo = new RepositorioProducto();

            // Seteamos los títulos directamente en los controles heredados de FrmReporteBase
            this.lblTituloModulo.Text = "Reporte de Inventario";

            // Reemplazo de AgregarDescripcionReporte:
            this.lblSubtituloHeader.Text = "Resumen ejecutivo del stock actual y valoración de inventario.";

            this.lblTituloReporte.Text = "INVENTARIO GENERAL DE PRODUCTOS";
        }

        protected override void FrmReporteBase_Load(object sender, EventArgs e)
        {
            // Cargamos los datos reales de la base de datos
            CargarDatosProductos();
        }

        private void CargarDatosProductos()
        {
            try
            {
                _listaProductos = _repo.ObtenerTodos();

                if (_listaProductos != null)
                {
                    ConfigurarColumnasGrid();
                    LlenarGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos de productos: " + ex.Message);
            }
        }

        private void ConfigurarColumnasGrid()
        {
            DgvDatos.Columns.Clear();
            DgvDatos.AutoGenerateColumns = false;

            DgvDatos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = "Producto", FillWeight = 150 });
            DgvDatos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Categoria", HeaderText = "Categoría", Width = 120 });
            DgvDatos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StockActual", HeaderText = "Stock Actual", Width = 100 });
            DgvDatos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StockMinimo", HeaderText = "Stock Mínimo", Width = 100 });

            DgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PrecioCompra",
                HeaderText = "P. Compra",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" },
                Width = 100
            });

            DgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PrecioVenta",
                HeaderText = "P. Venta",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" },
                Width = 100
            });

            DgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ValorTotal",
                HeaderText = "Valor Total",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Font = new Font("Segoe UI", 9, FontStyle.Bold) },
                Width = 120
            });

            DgvDatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Estado", HeaderText = "Estado", Width = 80 });
        }

        private void LlenarGrid()
        {
            DgvDatos.Rows.Clear();
            foreach (var p in _listaProductos)
            {
                decimal valorTotal = p.StockActual * p.PrecioVenta;
                string estado = p.StockActual <= p.StockMinimo ? "BAJO" : "OK";

                int rowIndex = DgvDatos.Rows.Add(
                    p.Nombre,
                    p.Categoria,
                    p.StockActual,
                    p.StockMinimo,
                    p.PrecioCompra,
                    p.PrecioVenta,
                    valorTotal,
                    estado
                );

                if (estado == "BAJO")
                {
                    DgvDatos.Rows[rowIndex].Cells["Estado"].Style.ForeColor = Color.Red;
                    DgvDatos.Rows[rowIndex].Cells["Estado"].Style.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                }
            }
        }
    }
}