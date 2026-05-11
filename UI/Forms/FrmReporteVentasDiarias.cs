using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CarniceriaPOS.Data;

namespace CarniceriaPOS.UI.Forms
{
    public partial class FrmReporteVentasDiarias : FrmReporteBase
    {
        // Asumiendo que tienes un RepositorioVenta o similar
        private DateTime _desde, _hasta;

        public FrmReporteVentasDiarias(DateTime desde, DateTime hasta) : base()
        {
            _desde = desde;
            _hasta = hasta;
            this.lblTituloModulo.Text = "Reporte de Ventas";
            this.lblSubtituloHeader.Text = $"Ventas realizadas desde {_desde:dd/MM/yyyy} hasta {_hasta:dd/MM/yyyy}";
            this.lblTituloReporte.Text = "MOVIMIENTO DE VENTAS DIARIAS";
        }

        protected override void FrmReporteBase_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            // Aqui llamarias a tu procedimiento de ventas
            // Por ahora configuramos las columnas para que el grid no este vacio visualmente
            DgvDatos.Columns.Clear();
            DgvDatos.Columns.Add("Fecha", "Fecha");
            DgvDatos.Columns.Add("Factura", "No. Factura");
            DgvDatos.Columns.Add("Cliente", "Cliente");
            DgvDatos.Columns.Add("SubTotal", "Sub-Total");
            DgvDatos.Columns.Add("ITBIS", "ITBIS");
            DgvDatos.Columns.Add("Total", "Total");

            DgvDatos.Columns["Total"].DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            DgvDatos.Columns["Total"].DefaultCellStyle.Format = "C2";
        }
    }
}