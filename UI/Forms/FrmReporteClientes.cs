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
    public partial class FrmReporteClientes : FrmReporteBase
    {
        private RepositorioCliente _repo;
        private List<Cliente> _listaClientes;

        public FrmReporteClientes() : base()
        {
            _repo = new RepositorioCliente();

            // Configuracion de textos en el encabezado
            this.lblTituloModulo.Text = "Reporte de Clientes";
            this.lblSubtituloHeader.Text = "Base de datos completa, contactos y fidelizacion de clientes registrados.";
            this.lblTituloReporte.Text = "LISTADO MAESTRO DE CLIENTES";
        }

        protected override void FrmReporteBase_Load(object sender, EventArgs e)
        {
            CargarDatosClientes();
        }

        private void CargarDatosClientes()
        {
            try
            {
                _listaClientes = _repo.ObtenerTodos();

                if (_listaClientes != null)
                {
                    ConfigurarColumnasGrid();
                    LlenarGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar reporte de clientes: " + ex.Message);
            }
        }

        private void ConfigurarColumnasGrid()
        {
            DgvDatos.Columns.Clear();
            DgvDatos.AutoGenerateColumns = false;

            // Definicion de columnas segun el estandar del reporte
            DgvDatos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = "Cliente", FillWeight = 150 });
            DgvDatos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Cedula", HeaderText = "Cedula/RNC", Width = 120 });
            DgvDatos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Telefono", HeaderText = "Telefono", Width = 120 });
            DgvDatos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Correo Electronico", FillWeight = 130 });
            DgvDatos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Direccion", HeaderText = "Direccion", FillWeight = 150 });
            DgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FechaCreacion",
                HeaderText = "F. Registro",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });
        }

        private void LlenarGrid()
        {
            DgvDatos.DataSource = _listaClientes;
        }

  

        private Guna2Panel CrearTarjetaInfo(string titulo, string valor, Color colorAcento)
        {
            Guna2Panel card = new Guna2Panel
            {
                Width = 220,
                Height = 70,
                BorderRadius = 10,
                FillColor = Color.FromArgb(248, 249, 250),
                Margin = new Padding(10),
                BorderColor = Color.Gainsboro,
                BorderThickness = 1
            };

            Label lblT = new Label { Text = titulo, Font = new Font("Segoe UI", 8, FontStyle.Bold), ForeColor = Color.Gray, Location = new Point(15, 12), AutoSize = true, BackColor = Color.Transparent };
            Label lblV = new Label { Text = valor, Font = new Font("Segoe UI", 13, FontStyle.Bold), ForeColor = colorAcento, Location = new Point(15, 30), AutoSize = true, BackColor = Color.Transparent };

            card.Controls.Add(lblT);
            card.Controls.Add(lblV);
            return card;
        }
    }
}