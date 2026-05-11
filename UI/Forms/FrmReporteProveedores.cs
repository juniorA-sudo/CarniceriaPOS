using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CarniceriaPOS.Data;
using CarniceriaPOS.Models;

namespace CarniceriaPOS.UI.Forms
{
    public partial class FrmReporteProveedores : FrmReporteBase
    {
        private RepositorioProveedor _repo;

        public FrmReporteProveedores() : base()
        {
            _repo = new RepositorioProveedor();
            this.lblTituloModulo.Text = "Reporte de Proveedores";
            this.lblSubtituloHeader.Text = "Base de datos y contacto de proveedores registrados.";
            this.lblTituloReporte.Text = "LISTADO MAESTRO DE PROVEEDORES";
        }

        protected override void FrmReporteBase_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                var lista = _repo.ObtenerTodos();
                DgvDatos.Columns.Clear();
                DgvDatos.AutoGenerateColumns = false;

                DgvDatos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = "Proveedor", FillWeight = 150 });
                DgvDatos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "RNC", HeaderText = "RNC", Width = 120 });
                DgvDatos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Telefono", HeaderText = "Telefono", Width = 120 });
                DgvDatos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Correo", FillWeight = 130 });
                DgvDatos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Direccion", HeaderText = "Direccion", FillWeight = 150 });

                DgvDatos.DataSource = lista;
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }
    }
}