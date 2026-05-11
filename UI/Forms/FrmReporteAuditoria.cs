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
                // Consulta ajustada a la tabla 'AuditoriaAcceso' y sus columnas reales
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

            // Columna Fecha y Hora
            DgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FechaHora",
                HeaderText = "Fecha/Hora",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" }
            });

            // Columna Usuario
            DgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreUsuario",
                HeaderText = "Usuario",
                Width = 120
            });

            // Columna Modulo
            DgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Modulo",
                HeaderText = "Modulo",
                Width = 110
            });

            // Columna Accion
            DgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Accion",
                HeaderText = "Accion",
                Width = 100
            });

            // Columna Resultado (Nuevo campo de tu tabla)
            DgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Resultado",
                HeaderText = "Resultado",
                Width = 100
            });

            // Columna Detalles (En plural segun tu imagen)
            DgvDatos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Detalles",
                HeaderText = "Detalles de la Actividad",
                FillWeight = 200
            });
        }
    }
}