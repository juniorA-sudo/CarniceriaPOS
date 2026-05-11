using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CarniceriaPOS.Data;
using CarniceriaPOS.Models;

namespace CarniceriaPOS.UI.Forms
{
    public partial class FrmReporteAuditoria : FrmReporteBase
    {
        private ConexionBD bd = new ConexionBD();

        public FrmReporteAuditoria() : base()
        {
            this.lblTituloModulo.Text = "Seguridad y Auditoria";
            this.lblSubtituloHeader.Text = "Registro detallado de actividades para control interno del sistema.";
            this.lblTituloReporte.Text = "HISTORIAL DE ACTIVIDADES DEL USUARIO";
        }

        protected override void FrmReporteBase_Load(object sender, EventArgs e)
        {
            CargarDatosAuditoria();
        }

        private void CargarDatosAuditoria()
        {
            try
            {

                string sql = @"SELECT TOP 200 
                                a.FechaHora, 
                                u.NombreUsuario, 
                                a.Modulo, 
                                a.Accion, 
                                a.Resultado,
                                a.Detalles 
                               FROM AuditoriaAcceso a 
                               INNER JOIN Usuarios u ON a.IdUsuario = u.IdUsuario 
                               ORDER BY a.FechaHora DESC";

                DataTable dt = bd.ObtenerDatos(sql);

                if (dt != null)
                {
                    ConfigurarColumnasGrid();
                    DgvDatos.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar auditoria: " + ex.Message, "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnasGrid()
        {
            DgvDatos.Columns.Clear();
            DgvDatos.AutoGenerateColumns = false;

            DgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FechaHora",
                HeaderText = "Fecha/Hora",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" }
            });

            DgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreUsuario",
                HeaderText = "Usuario",
                Width = 120
            });

            DgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Modulo",
                HeaderText = "Modulo",
                Width = 110
            });

            DgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Accion",
                HeaderText = "Accion",
                Width = 100
            });

            DgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Resultado",
                HeaderText = "Resultado",
                Width = 100
            });

            DgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Detalles",
                HeaderText = "Detalles de la Actividad",
                FillWeight = 200
            });
        }
    }
}
