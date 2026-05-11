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
    public partial class FrmReporteEmpleados : FrmReporteBase
    {
        private RepositorioEmpleado _repo;

        public FrmReporteEmpleados() : base()
        {
            _repo = new RepositorioEmpleado();
            this.lblTituloModulo.Text = "Reporte de Personal";
            this.lblSubtituloHeader.Text = "Nomina y puestos del personal administrativo y operativo.";
            this.lblTituloReporte.Text = "REPORTE DETALLADO DE EMPLEADOS";
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

                DgvDatos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = "Empleado", FillWeight = 150 });
                DgvDatos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Cedula", HeaderText = "Cedula", Width = 120 });
                DgvDatos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NombreDepartamento", HeaderText = "Departamento", Width = 130 });
                DgvDatos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Puesto", HeaderText = "Puesto", Width = 130 });
                DgvDatos.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Salario",
                    HeaderText = "Salario",
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" },
                    Width = 110
                });

                DgvDatos.DataSource = lista;
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }
    }
}