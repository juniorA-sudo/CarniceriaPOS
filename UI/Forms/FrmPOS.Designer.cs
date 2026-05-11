namespace CarniceriaPOS.UI.Forms
{
    partial class FrmPOS
    {
        private System.ComponentModel.IContainer components = null;

        public System.Windows.Forms.DataGridView dgvCarrito;
        public System.Windows.Forms.ComboBox cmbCliente;
        public System.Windows.Forms.ComboBox cmbMetodoPago;
        public System.Windows.Forms.TextBox txtBusqueda;
        public System.Windows.Forms.TextBox txtMontoRecibido;
        public System.Windows.Forms.Label lblSubtotalVal;
        public System.Windows.Forms.Label lblImpuestoVal;
        public System.Windows.Forms.Label lblDescuentoVal;
        public System.Windows.Forms.Label lblTotalVal;
        public System.Windows.Forms.Label lblPagaConVal;
        public System.Windows.Forms.Label lblCambioVal;
        public System.Windows.Forms.DataGridView dgvProductos;
        public System.Windows.Forms.TextBox txtCantidad;
        public System.Windows.Forms.ListBox lstCategorias;

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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.pnlCarritoSection = new System.Windows.Forms.Panel();
            this.dgvCarrito = new System.Windows.Forms.DataGridView();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImagen = new System.Windows.Forms.DataGridViewImageColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCarritoTitle = new System.Windows.Forms.Label();
            this.pnlAddProduct = new System.Windows.Forms.Panel();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.pnlProductosGrid = new System.Windows.Forms.Panel();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnCancelarVenta = new System.Windows.Forms.Button();
            this.btnImprimirTicket = new System.Windows.Forms.Button();
            this.btnFinalizarVenta = new System.Windows.Forms.Button();
            this.pnlPaymentDetails = new System.Windows.Forms.Panel();
            this.pnlCambio = new System.Windows.Forms.Panel();
            this.lblCambioVal = new System.Windows.Forms.Label();
            this.lblCambio = new System.Windows.Forms.Label();
            this.pnlPagaCon = new System.Windows.Forms.Panel();
            this.txtMontoRecibido = new System.Windows.Forms.TextBox();
            this.lblPagaCon = new System.Windows.Forms.Label();
            this.pnlMetodoPago = new System.Windows.Forms.Panel();
            this.rdoDebito = new System.Windows.Forms.RadioButton();
            this.rdoTarjeta = new System.Windows.Forms.RadioButton();
            this.rdoEfectivo = new System.Windows.Forms.RadioButton();
            this.lblMetodoPago = new System.Windows.Forms.Label();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.lblTotalVal = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pnlDescuento = new System.Windows.Forms.Panel();
            this.lblDescuentoVal = new System.Windows.Forms.Label();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.pnlImpuesto = new System.Windows.Forms.Panel();
            this.lblImpuestoVal = new System.Windows.Forms.Label();
            this.lblImpuesto = new System.Windows.Forms.Label();
            this.pnlSubtotal = new System.Windows.Forms.Panel();
            this.lblSubtotalVal = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblDetallesPagoTitle = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lstCategorias = new System.Windows.Forms.ListBox();
            this.lblCategoriasTitle = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlCarritoSection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).BeginInit();
            this.pnlAddProduct.SuspendLayout();
            this.pnlProductosGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.pnlSearch.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.pnlPaymentDetails.SuspendLayout();
            this.pnlCambio.SuspendLayout();
            this.pnlPagaCon.SuspendLayout();
            this.pnlMetodoPago.SuspendLayout();
            this.pnlTotal.SuspendLayout();
            this.pnlDescuento.SuspendLayout();
            this.pnlImpuesto.SuspendLayout();
            this.pnlSubtotal.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.SuspendLayout();

            this.pnlMain.Controls.Add(this.pnlCenter);
            this.pnlMain.Controls.Add(this.pnlRight);
            this.pnlMain.Controls.Add(this.pnlLeft);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(981, 688);
            this.pnlMain.TabIndex = 0;

            this.pnlCenter.BackColor = System.Drawing.Color.White;
            this.pnlCenter.Controls.Add(this.pnlCarritoSection);
            this.pnlCenter.Controls.Add(this.pnlAddProduct);
            this.pnlCenter.Controls.Add(this.pnlProductosGrid);
            this.pnlCenter.Controls.Add(this.pnlSearch);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(137, 0);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(569, 688);
            this.pnlCenter.TabIndex = 1;

            this.pnlCarritoSection.BackColor = System.Drawing.Color.White;
            this.pnlCarritoSection.Controls.Add(this.dgvCarrito);
            this.pnlCarritoSection.Controls.Add(this.lblCarritoTitle);
            this.pnlCarritoSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCarritoSection.Location = new System.Drawing.Point(0, 269);
            this.pnlCarritoSection.Name = "pnlCarritoSection";
            this.pnlCarritoSection.Padding = new System.Windows.Forms.Padding(4);
            this.pnlCarritoSection.Size = new System.Drawing.Size(569, 419);
            this.pnlCarritoSection.TabIndex = 3;

            this.dgvCarrito.AllowUserToAddRows = false;
            this.dgvCarrito.BackgroundColor = System.Drawing.Color.White;
            this.dgvCarrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarrito.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCode,
            this.colProducto,
            this.colImagen,
            this.colCantidad,
            this.colPrecioUnitario,
            this.colTotal});
            this.dgvCarrito.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCarrito.Location = new System.Drawing.Point(4, 4);
            this.dgvCarrito.Name = "dgvCarrito";
            this.dgvCarrito.ReadOnly = true;
            this.dgvCarrito.RowTemplate.Height = 25;
            this.dgvCarrito.Size = new System.Drawing.Size(561, 411);
            this.dgvCarrito.TabIndex = 1;

            this.colCode.HeaderText = "Codigo";
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            this.colCode.Width = 60;

            this.colProducto.HeaderText = "Producto";
            this.colProducto.Name = "colProducto";
            this.colProducto.ReadOnly = true;
            this.colProducto.Width = 180;

            this.colImagen.HeaderText = "Img";
            this.colImagen.Name = "colImagen";
            this.colImagen.ReadOnly = true;
            this.colImagen.Width = 40;

            this.colCantidad.HeaderText = "Cant";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.ReadOnly = true;
            this.colCantidad.Width = 60;

            this.colPrecioUnitario.HeaderText = "Precio";
            this.colPrecioUnitario.Name = "colPrecioUnitario";
            this.colPrecioUnitario.ReadOnly = true;
            this.colPrecioUnitario.Width = 80;

            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            this.colTotal.Width = 80;

            this.lblCarritoTitle.AutoSize = true;
            this.lblCarritoTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCarritoTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.lblCarritoTitle.Location = new System.Drawing.Point(4, 4);
            this.lblCarritoTitle.Name = "lblCarritoTitle";
            this.lblCarritoTitle.Size = new System.Drawing.Size(56, 19);
            this.lblCarritoTitle.TabIndex = 0;
            this.lblCarritoTitle.Text = "Carrito";

            this.pnlAddProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.pnlAddProduct.Controls.Add(this.btnAgregarProducto);
            this.pnlAddProduct.Controls.Add(this.txtCantidad);
            this.pnlAddProduct.Controls.Add(this.lblCantidad);
            this.pnlAddProduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAddProduct.Location = new System.Drawing.Point(0, 234);
            this.pnlAddProduct.Name = "pnlAddProduct";
            this.pnlAddProduct.Padding = new System.Windows.Forms.Padding(4);
            this.pnlAddProduct.Size = new System.Drawing.Size(569, 35);
            this.pnlAddProduct.TabIndex = 2;

            this.btnAgregarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(149)))), ((int)(((byte)(237)))));
            this.btnAgregarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarProducto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregarProducto.ForeColor = System.Drawing.Color.White;
            this.btnAgregarProducto.Location = new System.Drawing.Point(129, 5);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(103, 24);
            this.btnAgregarProducto.TabIndex = 2;
            this.btnAgregarProducto.Text = "Agregar";
            this.btnAgregarProducto.UseVisualStyleBackColor = false;
            this.btnAgregarProducto.Click += new System.EventHandler(this.AgregarProductoAlCarrito);

            this.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantidad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCantidad.Location = new System.Drawing.Point(56, 7);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(69, 23);
            this.txtCantidad.TabIndex = 1;

            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCantidad.Location = new System.Drawing.Point(4, 9);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(58, 15);
            this.lblCantidad.TabIndex = 0;
            this.lblCantidad.Text = "Cantidad:";

            this.pnlProductosGrid.Controls.Add(this.dgvProductos);
            this.pnlProductosGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProductosGrid.Location = new System.Drawing.Point(0, 43);
            this.pnlProductosGrid.Name = "pnlProductosGrid";
            this.pnlProductosGrid.Padding = new System.Windows.Forms.Padding(4);
            this.pnlProductosGrid.Size = new System.Drawing.Size(569, 191);
            this.pnlProductosGrid.TabIndex = 1;

            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.BackgroundColor = System.Drawing.Color.White;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductos.Location = new System.Drawing.Point(4, 4);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowTemplate.Height = 25;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(561, 183);
            this.dgvProductos.TabIndex = 0;

            this.pnlSearch.BackColor = System.Drawing.Color.White;
            this.pnlSearch.Controls.Add(this.txtBusqueda);
            this.pnlSearch.Controls.Add(this.lblBuscar);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Padding = new System.Windows.Forms.Padding(4);
            this.pnlSearch.Size = new System.Drawing.Size(569, 43);
            this.pnlSearch.TabIndex = 0;

            this.txtBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBusqueda.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBusqueda.Location = new System.Drawing.Point(4, 19);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(557, 23);
            this.txtBusqueda.TabIndex = 1;

            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBuscar.Location = new System.Drawing.Point(4, 4);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(96, 15);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Codigo/Nombre";

            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.pnlRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRight.Controls.Add(this.pnlButtons);
            this.pnlRight.Controls.Add(this.pnlPaymentDetails);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(706, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(275, 688);
            this.pnlRight.TabIndex = 2;

            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.pnlButtons.Controls.Add(this.btnCancelarVenta);
            this.pnlButtons.Controls.Add(this.btnImprimirTicket);
            this.pnlButtons.Controls.Add(this.btnFinalizarVenta);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 599);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(9);
            this.pnlButtons.Size = new System.Drawing.Size(273, 87);
            this.pnlButtons.TabIndex = 1;

            this.btnCancelarVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(20)))), ((int)(((byte)(60)))));
            this.btnCancelarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarVenta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarVenta.ForeColor = System.Drawing.Color.White;
            this.btnCancelarVenta.Location = new System.Drawing.Point(9, 57);
            this.btnCancelarVenta.Name = "btnCancelarVenta";
            this.btnCancelarVenta.Size = new System.Drawing.Size(255, 22);
            this.btnCancelarVenta.TabIndex = 2;
            this.btnCancelarVenta.Text = " CANCELAR VENTA";
            this.btnCancelarVenta.UseVisualStyleBackColor = false;
            this.btnCancelarVenta.Click += new System.EventHandler(this.CancelarVenta);

            this.btnImprimirTicket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.btnImprimirTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimirTicket.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimirTicket.ForeColor = System.Drawing.Color.White;
            this.btnImprimirTicket.Location = new System.Drawing.Point(9, 33);
            this.btnImprimirTicket.Name = "btnImprimirTicket";
            this.btnImprimirTicket.Size = new System.Drawing.Size(255, 22);
            this.btnImprimirTicket.TabIndex = 1;
            this.btnImprimirTicket.Text = " IMPRIMIR TICKET";
            this.btnImprimirTicket.UseVisualStyleBackColor = false;
            this.btnImprimirTicket.Click += new System.EventHandler(this.ImprimirTicket);

            this.btnFinalizarVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnFinalizarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizarVenta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizarVenta.ForeColor = System.Drawing.Color.White;
            this.btnFinalizarVenta.Location = new System.Drawing.Point(9, 9);
            this.btnFinalizarVenta.Name = "btnFinalizarVenta";
            this.btnFinalizarVenta.Size = new System.Drawing.Size(255, 22);
            this.btnFinalizarVenta.TabIndex = 0;
            this.btnFinalizarVenta.Text = " FINALIZAR VENTA";
            this.btnFinalizarVenta.UseVisualStyleBackColor = false;
            this.btnFinalizarVenta.Click += new System.EventHandler(this.FinalizarVenta);

            this.pnlPaymentDetails.AutoScroll = true;
            this.pnlPaymentDetails.Controls.Add(this.pnlCambio);
            this.pnlPaymentDetails.Controls.Add(this.pnlPagaCon);
            this.pnlPaymentDetails.Controls.Add(this.pnlMetodoPago);
            this.pnlPaymentDetails.Controls.Add(this.pnlTotal);
            this.pnlPaymentDetails.Controls.Add(this.pnlDescuento);
            this.pnlPaymentDetails.Controls.Add(this.pnlImpuesto);
            this.pnlPaymentDetails.Controls.Add(this.pnlSubtotal);
            this.pnlPaymentDetails.Controls.Add(this.lblDetallesPagoTitle);
            this.pnlPaymentDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPaymentDetails.Location = new System.Drawing.Point(0, 0);
            this.pnlPaymentDetails.Name = "pnlPaymentDetails";
            this.pnlPaymentDetails.Padding = new System.Windows.Forms.Padding(9);
            this.pnlPaymentDetails.Size = new System.Drawing.Size(273, 686);
            this.pnlPaymentDetails.TabIndex = 0;

            this.pnlCambio.Controls.Add(this.lblCambioVal);
            this.pnlCambio.Controls.Add(this.lblCambio);
            this.pnlCambio.Location = new System.Drawing.Point(9, 260);
            this.pnlCambio.Name = "pnlCambio";
            this.pnlCambio.Size = new System.Drawing.Size(253, 26);
            this.pnlCambio.TabIndex = 7;

            this.lblCambioVal.AutoSize = true;
            this.lblCambioVal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCambioVal.Location = new System.Drawing.Point(197, 4);
            this.lblCambioVal.Name = "lblCambioVal";
            this.lblCambioVal.Size = new System.Drawing.Size(52, 15);
            this.lblCambioVal.TabIndex = 1;
            this.lblCambioVal.Text = "0.00 RD$";

            this.lblCambio.AutoSize = true;
            this.lblCambio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCambio.Location = new System.Drawing.Point(0, 4);
            this.lblCambio.Name = "lblCambio";
            this.lblCambio.Size = new System.Drawing.Size(52, 15);
            this.lblCambio.TabIndex = 0;
            this.lblCambio.Text = "Cambio:";

            this.pnlPagaCon.Controls.Add(this.txtMontoRecibido);
            this.pnlPagaCon.Controls.Add(this.lblPagaCon);
            this.pnlPagaCon.Location = new System.Drawing.Point(9, 225);
            this.pnlPagaCon.Name = "pnlPagaCon";
            this.pnlPagaCon.Size = new System.Drawing.Size(253, 35);
            this.pnlPagaCon.TabIndex = 6;

            this.txtMontoRecibido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMontoRecibido.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMontoRecibido.Location = new System.Drawing.Point(67, 7);
            this.txtMontoRecibido.Name = "txtMontoRecibido";
            this.txtMontoRecibido.Size = new System.Drawing.Size(178, 23);
            this.txtMontoRecibido.TabIndex = 1;

            this.lblPagaCon.AutoSize = true;
            this.lblPagaCon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPagaCon.Location = new System.Drawing.Point(0, 9);
            this.lblPagaCon.Name = "lblPagaCon";
            this.lblPagaCon.Size = new System.Drawing.Size(61, 15);
            this.lblPagaCon.TabIndex = 0;
            this.lblPagaCon.Text = "Paga Con:";

            this.pnlMetodoPago.Controls.Add(this.rdoDebito);
            this.pnlMetodoPago.Controls.Add(this.rdoTarjeta);
            this.pnlMetodoPago.Controls.Add(this.rdoEfectivo);
            this.pnlMetodoPago.Controls.Add(this.lblMetodoPago);
            this.pnlMetodoPago.Location = new System.Drawing.Point(9, 156);
            this.pnlMetodoPago.Name = "pnlMetodoPago";
            this.pnlMetodoPago.Size = new System.Drawing.Size(253, 69);
            this.pnlMetodoPago.TabIndex = 5;

            this.rdoDebito.AutoSize = true;
            this.rdoDebito.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rdoDebito.Location = new System.Drawing.Point(190, 22);
            this.rdoDebito.Name = "rdoDebito";
            this.rdoDebito.Size = new System.Drawing.Size(60, 19);
            this.rdoDebito.TabIndex = 3;
            this.rdoDebito.Text = "Debito";

            this.rdoTarjeta.AutoSize = true;
            this.rdoTarjeta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rdoTarjeta.Location = new System.Drawing.Point(69, 22);
            this.rdoTarjeta.Name = "rdoTarjeta";
            this.rdoTarjeta.Size = new System.Drawing.Size(118, 19);
            this.rdoTarjeta.TabIndex = 2;
            this.rdoTarjeta.Text = "Tarjeta de Credito";

            this.rdoEfectivo.AutoSize = true;
            this.rdoEfectivo.Checked = true;
            this.rdoEfectivo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rdoEfectivo.Location = new System.Drawing.Point(4, 22);
            this.rdoEfectivo.Name = "rdoEfectivo";
            this.rdoEfectivo.Size = new System.Drawing.Size(67, 19);
            this.rdoEfectivo.TabIndex = 1;
            this.rdoEfectivo.TabStop = true;
            this.rdoEfectivo.Text = "Efectivo";

            this.lblMetodoPago.AutoSize = true;
            this.lblMetodoPago.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMetodoPago.Location = new System.Drawing.Point(0, 4);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(98, 15);
            this.lblMetodoPago.TabIndex = 0;
            this.lblMetodoPago.Text = "Metodo de Pago";

            this.pnlTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.pnlTotal.Controls.Add(this.lblTotalVal);
            this.pnlTotal.Controls.Add(this.lblTotal);
            this.pnlTotal.Location = new System.Drawing.Point(9, 108);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.Size = new System.Drawing.Size(253, 39);
            this.pnlTotal.TabIndex = 4;

            this.lblTotalVal.AutoSize = true;
            this.lblTotalVal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalVal.ForeColor = System.Drawing.Color.White;
            this.lblTotalVal.Location = new System.Drawing.Point(180, 10);
            this.lblTotalVal.Name = "lblTotalVal";
            this.lblTotalVal.Size = new System.Drawing.Size(76, 21);
            this.lblTotalVal.TabIndex = 1;
            this.lblTotalVal.Text = "0.00 RD$";

            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.White;
            this.lblTotal.Location = new System.Drawing.Point(4, 10);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(56, 21);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "TOTAL";

            this.pnlDescuento.Controls.Add(this.lblDescuentoVal);
            this.pnlDescuento.Controls.Add(this.lblDescuento);
            this.pnlDescuento.Location = new System.Drawing.Point(9, 82);
            this.pnlDescuento.Name = "pnlDescuento";
            this.pnlDescuento.Size = new System.Drawing.Size(253, 26);
            this.pnlDescuento.TabIndex = 3;

            this.lblDescuentoVal.AutoSize = true;
            this.lblDescuentoVal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDescuentoVal.Location = new System.Drawing.Point(197, 4);
            this.lblDescuentoVal.Name = "lblDescuentoVal";
            this.lblDescuentoVal.Size = new System.Drawing.Size(52, 15);
            this.lblDescuentoVal.TabIndex = 1;
            this.lblDescuentoVal.Text = "0.00 RD$";

            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDescuento.Location = new System.Drawing.Point(0, 4);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(63, 15);
            this.lblDescuento.TabIndex = 0;
            this.lblDescuento.Text = "Descuento";

            this.pnlImpuesto.Controls.Add(this.lblImpuestoVal);
            this.pnlImpuesto.Controls.Add(this.lblImpuesto);
            this.pnlImpuesto.Location = new System.Drawing.Point(9, 56);
            this.pnlImpuesto.Name = "pnlImpuesto";
            this.pnlImpuesto.Size = new System.Drawing.Size(253, 26);
            this.pnlImpuesto.TabIndex = 2;

            this.lblImpuestoVal.AutoSize = true;
            this.lblImpuestoVal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblImpuestoVal.Location = new System.Drawing.Point(197, 4);
            this.lblImpuestoVal.Name = "lblImpuestoVal";
            this.lblImpuestoVal.Size = new System.Drawing.Size(52, 15);
            this.lblImpuestoVal.TabIndex = 1;
            this.lblImpuestoVal.Text = "0.00 RD$";

            this.lblImpuesto.AutoSize = true;
            this.lblImpuesto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblImpuesto.Location = new System.Drawing.Point(0, 4);
            this.lblImpuesto.Name = "lblImpuesto";
            this.lblImpuesto.Size = new System.Drawing.Size(90, 15);
            this.lblImpuesto.TabIndex = 0;
            this.lblImpuesto.Text = "Impuesto (18%)";

            this.pnlSubtotal.Controls.Add(this.lblSubtotalVal);
            this.pnlSubtotal.Controls.Add(this.lblSubtotal);
            this.pnlSubtotal.Location = new System.Drawing.Point(9, 30);
            this.pnlSubtotal.Name = "pnlSubtotal";
            this.pnlSubtotal.Size = new System.Drawing.Size(253, 26);
            this.pnlSubtotal.TabIndex = 1;

            this.lblSubtotalVal.AutoSize = true;
            this.lblSubtotalVal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtotalVal.Location = new System.Drawing.Point(197, 4);
            this.lblSubtotalVal.Name = "lblSubtotalVal";
            this.lblSubtotalVal.Size = new System.Drawing.Size(52, 15);
            this.lblSubtotalVal.TabIndex = 1;
            this.lblSubtotalVal.Text = "0.00 RD$";

            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtotal.Location = new System.Drawing.Point(0, 4);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(51, 15);
            this.lblSubtotal.TabIndex = 0;
            this.lblSubtotal.Text = "Subtotal";

            this.lblDetallesPagoTitle.AutoSize = true;
            this.lblDetallesPagoTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDetallesPagoTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.lblDetallesPagoTitle.Location = new System.Drawing.Point(9, 9);
            this.lblDetallesPagoTitle.Name = "lblDetallesPagoTitle";
            this.lblDetallesPagoTitle.Size = new System.Drawing.Size(65, 20);
            this.lblDetallesPagoTitle.TabIndex = 0;
            this.lblDetallesPagoTitle.Text = "Detalles";

            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.pnlLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLeft.Controls.Add(this.lstCategorias);
            this.pnlLeft.Controls.Add(this.lblCategoriasTitle);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(137, 688);
            this.pnlLeft.TabIndex = 0;

            this.lstCategorias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstCategorias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCategorias.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstCategorias.FormattingEnabled = true;
            this.lstCategorias.ItemHeight = 15;
            this.lstCategorias.Items.AddRange(new object[] {
            "Busca",
            "Res",
            "Cerdo",
            "Pollo",
            "Embutidos",
            "Aves",
            "Sazon"});
            this.lstCategorias.Location = new System.Drawing.Point(0, 0);
            this.lstCategorias.Name = "lstCategorias";
            this.lstCategorias.Size = new System.Drawing.Size(135, 686);
            this.lstCategorias.TabIndex = 1;

            this.lblCategoriasTitle.AutoSize = true;
            this.lblCategoriasTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCategoriasTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.lblCategoriasTitle.Location = new System.Drawing.Point(4, 9);
            this.lblCategoriasTitle.Name = "lblCategoriasTitle";
            this.lblCategoriasTitle.Size = new System.Drawing.Size(81, 19);
            this.lblCategoriasTitle.TabIndex = 0;
            this.lblCategoriasTitle.Text = "Categorias";

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 688);
            this.Controls.Add(this.pnlMain);
            this.DoubleBuffered = true;
            this.Name = "FrmPOS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Punto de Venta";
            this.Load += new System.EventHandler(this.FrmPOS_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlCarritoSection.ResumeLayout(false);
            this.pnlCarritoSection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).EndInit();
            this.pnlAddProduct.ResumeLayout(false);
            this.pnlAddProduct.PerformLayout();
            this.pnlProductosGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.pnlPaymentDetails.ResumeLayout(false);
            this.pnlPaymentDetails.PerformLayout();
            this.pnlCambio.ResumeLayout(false);
            this.pnlCambio.PerformLayout();
            this.pnlPagaCon.ResumeLayout(false);
            this.pnlPagaCon.PerformLayout();
            this.pnlMetodoPago.ResumeLayout(false);
            this.pnlMetodoPago.PerformLayout();
            this.pnlTotal.ResumeLayout(false);
            this.pnlTotal.PerformLayout();
            this.pnlDescuento.ResumeLayout(false);
            this.pnlDescuento.PerformLayout();
            this.pnlImpuesto.ResumeLayout(false);
            this.pnlImpuesto.PerformLayout();
            this.pnlSubtotal.ResumeLayout(false);
            this.pnlSubtotal.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlCenter;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Panel pnlProductosGrid;
        private System.Windows.Forms.Panel pnlAddProduct;
        private System.Windows.Forms.Panel pnlCarritoSection;
        private System.Windows.Forms.Panel pnlPaymentDetails;
        private System.Windows.Forms.Panel pnlMetodoPago;
        private System.Windows.Forms.Panel pnlPagaCon;
        private System.Windows.Forms.Panel pnlCambio;
        private System.Windows.Forms.Panel pnlSubtotal;
        private System.Windows.Forms.Panel pnlImpuesto;
        private System.Windows.Forms.Panel pnlDescuento;
        private System.Windows.Forms.Panel pnlTotal;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Label lblCategoriasTitle;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Label lblCarritoTitle;
        private System.Windows.Forms.Label lblDetallesPagoTitle;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblImpuesto;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblMetodoPago;
        private System.Windows.Forms.Label lblPagaCon;
        private System.Windows.Forms.Label lblCambio;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.Button btnFinalizarVenta;
        private System.Windows.Forms.Button btnImprimirTicket;
        private System.Windows.Forms.Button btnCancelarVenta;
        private System.Windows.Forms.RadioButton rdoEfectivo;
        private System.Windows.Forms.RadioButton rdoTarjeta;
        private System.Windows.Forms.RadioButton rdoDebito;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewImageColumn colImagen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
    }
}
