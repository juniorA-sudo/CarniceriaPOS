namespace CarniceriaPOS.UI.Forms
{
    partial class FrmCompras
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlStats = new System.Windows.Forms.Panel();
            this.lblComprasLbl = new System.Windows.Forms.Label();
            this.lblComprasVal = new System.Windows.Forms.Label();
            this.lblMontoLbl = new System.Windows.Forms.Label();
            this.lblMontoVal = new System.Windows.Forms.Label();
            this.lblPendientesLbl = new System.Windows.Forms.Label();
            this.lblPendientesVal = new System.Windows.Forms.Label();
            this.lblProveedoresLbl = new System.Windows.Forms.Label();
            this.lblProveedoresVal = new System.Windows.Forms.Label();
            this.pnlFormulario = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.lblNumeroFactura = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblPrecioUnitario = new System.Windows.Forms.Label();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.dtpFechaCompra = new System.Windows.Forms.DateTimePicker();
            this.txtNumeroFactura = new System.Windows.Forms.TextBox();
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtPrecioUnitario = new System.Windows.Forms.TextBox();
            this.btnAgregarDetalle = new System.Windows.Forms.Button();
            this.btnLimpiarForm = new System.Windows.Forms.Button();
            this.pnlDetalles = new System.Windows.Forms.Panel();
            this.lblDetallesTitle = new System.Windows.Forms.Label();
            this.dgvDetalles = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlResumen = new System.Windows.Forms.Panel();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblSubtotalVal = new System.Windows.Forms.Label();
            this.lblImpuesto = new System.Windows.Forms.Label();
            this.lblImpuestoVal = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotalVal = new System.Windows.Forms.Label();
            this.btnGuardarCompra = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.pnlHistorial = new System.Windows.Forms.Panel();
            this.lblHistorialTitle = new System.Windows.Forms.Label();
            this.dgvCompras = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlStats.SuspendLayout();
            this.pnlFormulario.SuspendLayout();
            this.pnlDetalles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            this.pnlResumen.SuspendLayout();
            this.pnlHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).BeginInit();
            this.SuspendLayout();
            
            
            
            this.pnlStats.BackColor = System.Drawing.Color.White;
            this.pnlStats.Controls.Add(this.lblComprasLbl);
            this.pnlStats.Controls.Add(this.lblComprasVal);
            this.pnlStats.Controls.Add(this.lblMontoLbl);
            this.pnlStats.Controls.Add(this.lblMontoVal);
            this.pnlStats.Controls.Add(this.lblPendientesLbl);
            this.pnlStats.Controls.Add(this.lblPendientesVal);
            this.pnlStats.Controls.Add(this.lblProveedoresLbl);
            this.pnlStats.Controls.Add(this.lblProveedoresVal);
            this.pnlStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStats.Location = new System.Drawing.Point(0, 0);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Padding = new System.Windows.Forms.Padding(15);
            this.pnlStats.Size = new System.Drawing.Size(800, 90);
            this.pnlStats.TabIndex = 3;
            
            
            
            this.lblComprasLbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblComprasLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblComprasLbl.Location = new System.Drawing.Point(15, 12);
            this.lblComprasLbl.Name = "lblComprasLbl";
            this.lblComprasLbl.Size = new System.Drawing.Size(140, 20);
            this.lblComprasLbl.TabIndex = 0;
            this.lblComprasLbl.Text = "Compras Este Mes";
            
            
            
            this.lblComprasVal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblComprasVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.lblComprasVal.Location = new System.Drawing.Point(15, 35);
            this.lblComprasVal.Name = "lblComprasVal";
            this.lblComprasVal.Size = new System.Drawing.Size(140, 40);
            this.lblComprasVal.TabIndex = 1;
            this.lblComprasVal.Text = "18";
            
            
            
            this.lblMontoLbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMontoLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblMontoLbl.Location = new System.Drawing.Point(180, 12);
            this.lblMontoLbl.Name = "lblMontoLbl";
            this.lblMontoLbl.Size = new System.Drawing.Size(140, 20);
            this.lblMontoLbl.TabIndex = 2;
            this.lblMontoLbl.Text = "Monto Total";
            
            
            
            this.lblMontoVal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblMontoVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.lblMontoVal.Location = new System.Drawing.Point(180, 35);
            this.lblMontoVal.Name = "lblMontoVal";
            this.lblMontoVal.Size = new System.Drawing.Size(140, 40);
            this.lblMontoVal.TabIndex = 3;
            this.lblMontoVal.Text = "$12,450";
            
            
            
            this.lblPendientesLbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPendientesLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblPendientesLbl.Location = new System.Drawing.Point(345, 12);
            this.lblPendientesLbl.Name = "lblPendientesLbl";
            this.lblPendientesLbl.Size = new System.Drawing.Size(140, 20);
            this.lblPendientesLbl.TabIndex = 4;
            this.lblPendientesLbl.Text = "Compras Pendientes";
            
            
            
            this.lblPendientesVal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblPendientesVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.lblPendientesVal.Location = new System.Drawing.Point(345, 35);
            this.lblPendientesVal.Name = "lblPendientesVal";
            this.lblPendientesVal.Size = new System.Drawing.Size(140, 40);
            this.lblPendientesVal.TabIndex = 5;
            this.lblPendientesVal.Text = "3";
            
            
            
            this.lblProveedoresLbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProveedoresLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblProveedoresLbl.Location = new System.Drawing.Point(510, 12);
            this.lblProveedoresLbl.Name = "lblProveedoresLbl";
            this.lblProveedoresLbl.Size = new System.Drawing.Size(140, 20);
            this.lblProveedoresLbl.TabIndex = 6;
            this.lblProveedoresLbl.Text = "Proveedores Activos";
            
            
            
            this.lblProveedoresVal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblProveedoresVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.lblProveedoresVal.Location = new System.Drawing.Point(510, 35);
            this.lblProveedoresVal.Name = "lblProveedoresVal";
            this.lblProveedoresVal.Size = new System.Drawing.Size(140, 40);
            this.lblProveedoresVal.TabIndex = 7;
            this.lblProveedoresVal.Text = "7";
            
            
            
            this.pnlFormulario.BackColor = System.Drawing.Color.White;
            this.pnlFormulario.Controls.Add(this.lblFormTitle);
            this.pnlFormulario.Controls.Add(this.lblNumeroFactura);
            this.pnlFormulario.Controls.Add(this.lblCantidad);
            this.pnlFormulario.Controls.Add(this.lblPrecioUnitario);
            this.pnlFormulario.Controls.Add(this.cmbProveedor);
            this.pnlFormulario.Controls.Add(this.dtpFechaCompra);
            this.pnlFormulario.Controls.Add(this.txtNumeroFactura);
            this.pnlFormulario.Controls.Add(this.cmbProducto);
            this.pnlFormulario.Controls.Add(this.txtCantidad);
            this.pnlFormulario.Controls.Add(this.txtPrecioUnitario);
            this.pnlFormulario.Controls.Add(this.btnAgregarDetalle);
            this.pnlFormulario.Controls.Add(this.btnLimpiarForm);
            this.pnlFormulario.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFormulario.Location = new System.Drawing.Point(0, 90);
            this.pnlFormulario.Name = "pnlFormulario";
            this.pnlFormulario.Padding = new System.Windows.Forms.Padding(15);
            this.pnlFormulario.Size = new System.Drawing.Size(800, 200);
            this.pnlFormulario.TabIndex = 2;
            
            
            
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.Location = new System.Drawing.Point(15, 12);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(300, 30);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "Nueva Compra";
            
            
            
            this.lblNumeroFactura.AutoSize = true;
            this.lblNumeroFactura.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNumeroFactura.ForeColor = System.Drawing.Color.Gray;
            this.lblNumeroFactura.Location = new System.Drawing.Point(395, 34);
            this.lblNumeroFactura.Name = "lblNumeroFactura";
            this.lblNumeroFactura.Size = new System.Drawing.Size(63, 15);
            this.lblNumeroFactura.TabIndex = 10;
            this.lblNumeroFactura.Text = "N Factura";
            
            
            
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCantidad.ForeColor = System.Drawing.Color.Gray;
            this.lblCantidad.Location = new System.Drawing.Point(205, 84);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(55, 15);
            this.lblCantidad.TabIndex = 11;
            this.lblCantidad.Text = "Cantidad";
            
            
            
            this.lblPrecioUnitario.AutoSize = true;
            this.lblPrecioUnitario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPrecioUnitario.ForeColor = System.Drawing.Color.Gray;
            this.lblPrecioUnitario.Location = new System.Drawing.Point(395, 84);
            this.lblPrecioUnitario.Name = "lblPrecioUnitario";
            this.lblPrecioUnitario.Size = new System.Drawing.Size(85, 15);
            this.lblPrecioUnitario.TabIndex = 12;
            this.lblPrecioUnitario.Text = "Precio Unitario";
            
            
            
            this.cmbProveedor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbProveedor.Location = new System.Drawing.Point(15, 55);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(180, 25);
            this.cmbProveedor.TabIndex = 1;
            
            
            
            this.dtpFechaCompra.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFechaCompra.Location = new System.Drawing.Point(205, 55);
            this.dtpFechaCompra.Name = "dtpFechaCompra";
            this.dtpFechaCompra.Size = new System.Drawing.Size(180, 25);
            this.dtpFechaCompra.TabIndex = 2;
            
            
            
            this.txtNumeroFactura.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNumeroFactura.Location = new System.Drawing.Point(391, 50);
            this.txtNumeroFactura.Name = "txtNumeroFactura";
            this.txtNumeroFactura.Size = new System.Drawing.Size(180, 25);
            this.txtNumeroFactura.TabIndex = 3;
            
            
            
            this.cmbProducto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbProducto.Location = new System.Drawing.Point(15, 105);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(180, 25);
            this.cmbProducto.TabIndex = 4;
            
            
            
            this.txtCantidad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCantidad.Location = new System.Drawing.Point(205, 105);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(180, 25);
            this.txtCantidad.TabIndex = 5;
            
            
            
            this.txtPrecioUnitario.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPrecioUnitario.Location = new System.Drawing.Point(395, 105);
            this.txtPrecioUnitario.Name = "txtPrecioUnitario";
            this.txtPrecioUnitario.Size = new System.Drawing.Size(180, 25);
            this.txtPrecioUnitario.TabIndex = 6;
            
            
            
            this.btnAgregarDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.btnAgregarDetalle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAgregarDetalle.ForeColor = System.Drawing.Color.White;
            this.btnAgregarDetalle.Location = new System.Drawing.Point(15, 155);
            this.btnAgregarDetalle.Name = "btnAgregarDetalle";
            this.btnAgregarDetalle.Size = new System.Drawing.Size(180, 35);
            this.btnAgregarDetalle.TabIndex = 7;
            this.btnAgregarDetalle.Text = " Agregar";
            this.btnAgregarDetalle.UseVisualStyleBackColor = false;
            this.btnAgregarDetalle.Click += new System.EventHandler(this.btnAgregarDetalle_Click);
            
            
            
            this.btnLimpiarForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(247)))));
            this.btnLimpiarForm.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnLimpiarForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnLimpiarForm.Location = new System.Drawing.Point(205, 155);
            this.btnLimpiarForm.Name = "btnLimpiarForm";
            this.btnLimpiarForm.Size = new System.Drawing.Size(180, 35);
            this.btnLimpiarForm.TabIndex = 8;
            this.btnLimpiarForm.Text = " Limpiar";
            this.btnLimpiarForm.UseVisualStyleBackColor = false;
            
            
            
            this.pnlDetalles.BackColor = System.Drawing.Color.White;
            this.pnlDetalles.Controls.Add(this.lblDetallesTitle);
            this.pnlDetalles.Controls.Add(this.dgvDetalles);
            this.pnlDetalles.Controls.Add(this.pnlResumen);
            this.pnlDetalles.Controls.Add(this.btnGuardarCompra);
            this.pnlDetalles.Controls.Add(this.btnLimpiar);
            this.pnlDetalles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetalles.Location = new System.Drawing.Point(0, 290);
            this.pnlDetalles.Name = "pnlDetalles";
            this.pnlDetalles.Padding = new System.Windows.Forms.Padding(15);
            this.pnlDetalles.Size = new System.Drawing.Size(800, 310);
            this.pnlDetalles.TabIndex = 1;
            
            
            
            this.lblDetallesTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDetallesTitle.Location = new System.Drawing.Point(15, 12);
            this.lblDetallesTitle.Name = "lblDetallesTitle";
            this.lblDetallesTitle.Size = new System.Drawing.Size(300, 30);
            this.lblDetallesTitle.TabIndex = 0;
            this.lblDetallesTitle.Text = " Detalles de la Compra";
            
            
            
            this.dgvDetalles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10});
            this.dgvDetalles.Location = new System.Drawing.Point(15, 50);
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.ReadOnly = true;
            this.dgvDetalles.Size = new System.Drawing.Size(600, 200);
            this.dgvDetalles.TabIndex = 1;
            
            
            
            this.dataGridViewTextBoxColumn6.HeaderText = "ID";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            
            
            
            this.dataGridViewTextBoxColumn7.HeaderText = "Producto";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            
            
            
            this.dataGridViewTextBoxColumn8.HeaderText = "Cantidad";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            
            
            
            this.dataGridViewTextBoxColumn9.HeaderText = "Precio Unitario";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            
            
            
            this.dataGridViewTextBoxColumn10.HeaderText = "Subtotal";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            
            
            
            this.pnlResumen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlResumen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlResumen.Controls.Add(this.lblSubtotal);
            this.pnlResumen.Controls.Add(this.lblSubtotalVal);
            this.pnlResumen.Controls.Add(this.lblImpuesto);
            this.pnlResumen.Controls.Add(this.lblImpuestoVal);
            this.pnlResumen.Controls.Add(this.lblTotal);
            this.pnlResumen.Controls.Add(this.lblTotalVal);
            this.pnlResumen.Location = new System.Drawing.Point(15, 260);
            this.pnlResumen.Name = "pnlResumen";
            this.pnlResumen.Size = new System.Drawing.Size(600, 120);
            this.pnlResumen.TabIndex = 2;
            
            
            
            this.lblSubtotal.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSubtotal.Location = new System.Drawing.Point(20, 15);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(100, 20);
            this.lblSubtotal.TabIndex = 0;
            this.lblSubtotal.Text = "Subtotal:";
            
            
            
            this.lblSubtotalVal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSubtotalVal.Location = new System.Drawing.Point(500, 15);
            this.lblSubtotalVal.Name = "lblSubtotalVal";
            this.lblSubtotalVal.Size = new System.Drawing.Size(80, 20);
            this.lblSubtotalVal.TabIndex = 1;
            this.lblSubtotalVal.Text = "$0.00";
            this.lblSubtotalVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            
            
            
            this.lblImpuesto.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblImpuesto.Location = new System.Drawing.Point(20, 45);
            this.lblImpuesto.Name = "lblImpuesto";
            this.lblImpuesto.Size = new System.Drawing.Size(100, 20);
            this.lblImpuesto.TabIndex = 2;
            this.lblImpuesto.Text = "Impuesto (12%):";
            
            
            
            this.lblImpuestoVal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblImpuestoVal.Location = new System.Drawing.Point(500, 45);
            this.lblImpuestoVal.Name = "lblImpuestoVal";
            this.lblImpuestoVal.Size = new System.Drawing.Size(80, 20);
            this.lblImpuestoVal.TabIndex = 3;
            this.lblImpuestoVal.Text = "$0.00";
            this.lblImpuestoVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            
            
            
            this.lblTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.White;
            this.lblTotal.Location = new System.Drawing.Point(20, 75);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblTotal.Size = new System.Drawing.Size(300, 30);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "TOTAL A PAGAR:";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            
            
            
            this.lblTotalVal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.lblTotalVal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalVal.ForeColor = System.Drawing.Color.White;
            this.lblTotalVal.Location = new System.Drawing.Point(500, 75);
            this.lblTotalVal.Name = "lblTotalVal";
            this.lblTotalVal.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblTotalVal.Size = new System.Drawing.Size(80, 30);
            this.lblTotalVal.TabIndex = 5;
            this.lblTotalVal.Text = "$0.00";
            this.lblTotalVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            
            
            
            this.btnGuardarCompra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnGuardarCompra.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardarCompra.ForeColor = System.Drawing.Color.White;
            this.btnGuardarCompra.Location = new System.Drawing.Point(15, 390);
            this.btnGuardarCompra.Name = "btnGuardarCompra";
            this.btnGuardarCompra.Size = new System.Drawing.Size(180, 35);
            this.btnGuardarCompra.TabIndex = 3;
            this.btnGuardarCompra.Text = " Guardar Compra";
            this.btnGuardarCompra.UseVisualStyleBackColor = false;
            this.btnGuardarCompra.Click += new System.EventHandler(this.btnGuardarCompra_Click);
            
            
            
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(247)))));
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnLimpiar.Location = new System.Drawing.Point(205, 390);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(180, 35);
            this.btnLimpiar.TabIndex = 4;
            this.btnLimpiar.Text = " Limpiar Todo";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            
            
            
            this.pnlHistorial.BackColor = System.Drawing.Color.White;
            this.pnlHistorial.Controls.Add(this.lblHistorialTitle);
            this.pnlHistorial.Controls.Add(this.dgvCompras);
            this.pnlHistorial.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlHistorial.Location = new System.Drawing.Point(0, 300);
            this.pnlHistorial.Name = "pnlHistorial";
            this.pnlHistorial.Padding = new System.Windows.Forms.Padding(15);
            this.pnlHistorial.Size = new System.Drawing.Size(800, 300);
            this.pnlHistorial.TabIndex = 0;
            
            
            
            this.lblHistorialTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblHistorialTitle.Location = new System.Drawing.Point(15, 12);
            this.lblHistorialTitle.Name = "lblHistorialTitle";
            this.lblHistorialTitle.Size = new System.Drawing.Size(300, 30);
            this.lblHistorialTitle.TabIndex = 0;
            this.lblHistorialTitle.Text = "Historial de Compras";
            
            
            
            this.dgvCompras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCompras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dgvCompras.Location = new System.Drawing.Point(15, 50);
            this.dgvCompras.Name = "dgvCompras";
            this.dgvCompras.ReadOnly = true;
            this.dgvCompras.Size = new System.Drawing.Size(600, 230);
            this.dgvCompras.TabIndex = 1;
            
            
            
            this.dataGridViewTextBoxColumn1.HeaderText = "Fecha";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            
            
            
            this.dataGridViewTextBoxColumn2.HeaderText = "Proveedor";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            
            
            
            this.dataGridViewTextBoxColumn3.HeaderText = "Numero";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            
            
            
            this.dataGridViewTextBoxColumn4.HeaderText = "Monto Total";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            
            
            
            this.dataGridViewTextBoxColumn5.HeaderText = "Estado";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            
            
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.pnlHistorial);
            this.Controls.Add(this.pnlDetalles);
            this.Controls.Add(this.pnlFormulario);
            this.Controls.Add(this.pnlStats);
            this.Name = "FrmCompras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion de Compras";
            this.Load += new System.EventHandler(this.FrmCompras_Load);
            this.pnlStats.ResumeLayout(false);
            this.pnlFormulario.ResumeLayout(false);
            this.pnlFormulario.PerformLayout();
            this.pnlDetalles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            this.pnlResumen.ResumeLayout(false);
            this.pnlHistorial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Label lblComprasVal;
        private System.Windows.Forms.Label lblComprasLbl;
        private System.Windows.Forms.Label lblMontoVal;
        private System.Windows.Forms.Label lblMontoLbl;
        private System.Windows.Forms.Label lblPendientesVal;
        private System.Windows.Forms.Label lblPendientesLbl;
        private System.Windows.Forms.Label lblProveedoresVal;
        private System.Windows.Forms.Label lblProveedoresLbl;

        private System.Windows.Forms.Panel pnlFormulario;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Label lblNumeroFactura;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblPrecioUnitario;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.DateTimePicker dtpFechaCompra;
        private System.Windows.Forms.TextBox txtNumeroFactura;
        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtPrecioUnitario;
        private System.Windows.Forms.Button btnAgregarDetalle;
        private System.Windows.Forms.Button btnLimpiarForm;

        private System.Windows.Forms.Panel pnlDetalles;
        private System.Windows.Forms.Label lblDetallesTitle;
        private System.Windows.Forms.DataGridView dgvDetalles;
        private System.Windows.Forms.Panel pnlResumen;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblSubtotalVal;
        private System.Windows.Forms.Label lblImpuesto;
        private System.Windows.Forms.Label lblImpuestoVal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotalVal;
        private System.Windows.Forms.Button btnGuardarCompra;
        private System.Windows.Forms.Button btnLimpiar;

        private System.Windows.Forms.Panel pnlHistorial;
        private System.Windows.Forms.Label lblHistorialTitle;
        private System.Windows.Forms.DataGridView dgvCompras;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    }
}
