namespace CarniceriaPOS.UI.Forms
{
    partial class FrmCaja
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlSalesTable = new System.Windows.Forms.Panel();
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.lblSalesTitle = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.lblStatusPerc = new System.Windows.Forms.Label();
            this.lblStatusPercLabel = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblStatusStateLabel = new System.Windows.Forms.Label();
            this.lblStatusMonto = new System.Windows.Forms.Label();
            this.lblStatusMontoLabel = new System.Windows.Forms.Label();
            this.pnlCashier = new System.Windows.Forms.Panel();
            this.lblDiferencia = new System.Windows.Forms.Label();
            this.lblDiferenciaLabel = new System.Windows.Forms.Label();
            this.lblMontoReal = new System.Windows.Forms.Label();
            this.txtMontoReal = new System.Windows.Forms.TextBox();
            this.lblMontoRealLabel = new System.Windows.Forms.Label();
            this.lblMontoEsperado = new System.Windows.Forms.Label();
            this.lblMontoEsperadoLabel = new System.Windows.Forms.Label();
            this.lblCashierTitle = new System.Windows.Forms.Label();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.pnlSumItem4 = new System.Windows.Forms.Panel();
            this.lblSum4Value = new System.Windows.Forms.Label();
            this.lblSum4Label = new System.Windows.Forms.Label();
            this.pnlSumItem3 = new System.Windows.Forms.Panel();
            this.lblSum3Value = new System.Windows.Forms.Label();
            this.lblSum3Label = new System.Windows.Forms.Label();
            this.pnlSumItem2 = new System.Windows.Forms.Panel();
            this.lblSum2Value = new System.Windows.Forms.Label();
            this.lblSum2Label = new System.Windows.Forms.Label();
            this.pnlSumItem1 = new System.Windows.Forms.Panel();
            this.lblSum1Value = new System.Windows.Forms.Label();
            this.lblSum1Label = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderDesc = new System.Windows.Forms.Label();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.lblTotalVentas = new System.Windows.Forms.Label();
            this.lblCantidadVentas = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlSalesTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.pnlCashier.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            this.pnlSumItem4.SuspendLayout();
            this.pnlSumItem3.SuspendLayout();
            this.pnlSumItem2.SuspendLayout();
            this.pnlSumItem1.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();

            this.pnlMain.AutoScroll = true;
            this.pnlMain.Controls.Add(this.pnlContent);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(15);
            this.pnlMain.Size = new System.Drawing.Size(1024, 700);
            this.pnlMain.TabIndex = 0;

            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.pnlContent.Controls.Add(this.pnlSalesTable);
            this.pnlContent.Controls.Add(this.pnlButtons);
            this.pnlContent.Controls.Add(this.pnlStatus);
            this.pnlContent.Controls.Add(this.pnlCashier);
            this.pnlContent.Controls.Add(this.pnlSummary);
            this.pnlContent.Controls.Add(this.pnlHeader);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(15, 15);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(994, 670);
            this.pnlContent.TabIndex = 0;

            this.pnlSalesTable.BackColor = System.Drawing.Color.White;
            this.pnlSalesTable.Controls.Add(this.dgvVentas);
            this.pnlSalesTable.Controls.Add(this.lblSalesTitle);
            this.pnlSalesTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSalesTable.Location = new System.Drawing.Point(0, 510);
            this.pnlSalesTable.Name = "pnlSalesTable";
            this.pnlSalesTable.Padding = new System.Windows.Forms.Padding(15);
            this.pnlSalesTable.Size = new System.Drawing.Size(994, 160);
            this.pnlSalesTable.TabIndex = 0;

            this.dgvVentas.AllowUserToAddRows = false;
            this.dgvVentas.AllowUserToDeleteRows = false;
            this.dgvVentas.BackgroundColor = System.Drawing.Color.White;
            this.dgvVentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVentas.Location = new System.Drawing.Point(15, 36);
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.ReadOnly = true;
            this.dgvVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVentas.Size = new System.Drawing.Size(964, 109);
            this.dgvVentas.TabIndex = 0;

            this.lblSalesTitle.AutoSize = true;
            this.lblSalesTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSalesTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSalesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(46)))));
            this.lblSalesTitle.Location = new System.Drawing.Point(15, 15);
            this.lblSalesTitle.Name = "lblSalesTitle";
            this.lblSalesTitle.Size = new System.Drawing.Size(185, 21);
            this.lblSalesTitle.TabIndex = 1;
            this.lblSalesTitle.Text = " Resumen de Ventas";

            this.pnlButtons.BackColor = System.Drawing.Color.White;
            this.pnlButtons.Controls.Add(this.btnImprimir);
            this.pnlButtons.Controls.Add(this.btnGuardar);
            this.pnlButtons.Controls.Add(this.btnCalcular);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButtons.Location = new System.Drawing.Point(0, 460);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(0, 0, 0, 15);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(15);
            this.pnlButtons.Size = new System.Drawing.Size(994, 50);
            this.pnlButtons.TabIndex = 1;

            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Location = new System.Drawing.Point(325, 10);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(120, 35);
            this.btnImprimir.TabIndex = 0;
            this.btnImprimir.Text = " Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = false;

            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(175, 10);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(140, 35);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = " Guardar Cierre";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardarCierre_Click);

            this.btnCalcular.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.btnCalcular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalcular.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCalcular.ForeColor = System.Drawing.Color.White;
            this.btnCalcular.Location = new System.Drawing.Point(15, 10);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(150, 35);
            this.btnCalcular.TabIndex = 2;
            this.btnCalcular.Text = " Calcular Diferencia";
            this.btnCalcular.UseVisualStyleBackColor = false;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcularDiferencia_Click);

            this.pnlStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlStatus.Controls.Add(this.lblStatusPerc);
            this.pnlStatus.Controls.Add(this.lblStatusPercLabel);
            this.pnlStatus.Controls.Add(this.lblEstado);
            this.pnlStatus.Controls.Add(this.lblStatusStateLabel);
            this.pnlStatus.Controls.Add(this.lblStatusMonto);
            this.pnlStatus.Controls.Add(this.lblStatusMontoLabel);
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStatus.Location = new System.Drawing.Point(0, 360);
            this.pnlStatus.Margin = new System.Windows.Forms.Padding(0, 0, 0, 15);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Padding = new System.Windows.Forms.Padding(15);
            this.pnlStatus.Size = new System.Drawing.Size(994, 100);
            this.pnlStatus.TabIndex = 2;

            this.lblStatusPerc.AutoSize = true;
            this.lblStatusPerc.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblStatusPerc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(46)))));
            this.lblStatusPerc.Location = new System.Drawing.Point(545, 35);
            this.lblStatusPerc.Name = "lblStatusPerc";
            this.lblStatusPerc.Size = new System.Drawing.Size(77, 30);
            this.lblStatusPerc.TabIndex = 0;
            this.lblStatusPerc.Text = "0.00%";

            this.lblStatusPercLabel.AutoSize = true;
            this.lblStatusPercLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatusPercLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lblStatusPercLabel.Location = new System.Drawing.Point(545, 15);
            this.lblStatusPercLabel.Name = "lblStatusPercLabel";
            this.lblStatusPercLabel.Size = new System.Drawing.Size(63, 15);
            this.lblStatusPercLabel.TabIndex = 1;
            this.lblStatusPercLabel.Text = "Porcentaje";

            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblEstado.ForeColor = System.Drawing.Color.Black;
            this.lblEstado.Location = new System.Drawing.Point(280, 35);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(79, 20);
            this.lblEstado.TabIndex = 2;
            this.lblEstado.Text = "Pendiente";

            this.lblStatusStateLabel.AutoSize = true;
            this.lblStatusStateLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatusStateLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lblStatusStateLabel.Location = new System.Drawing.Point(280, 15);
            this.lblStatusStateLabel.Name = "lblStatusStateLabel";
            this.lblStatusStateLabel.Size = new System.Drawing.Size(42, 15);
            this.lblStatusStateLabel.TabIndex = 3;
            this.lblStatusStateLabel.Text = "Estado";

            this.lblStatusMonto.AutoSize = true;
            this.lblStatusMonto.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblStatusMonto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(46)))));
            this.lblStatusMonto.Location = new System.Drawing.Point(15, 35);
            this.lblStatusMonto.Name = "lblStatusMonto";
            this.lblStatusMonto.Size = new System.Drawing.Size(71, 30);
            this.lblStatusMonto.TabIndex = 4;
            this.lblStatusMonto.Text = "$0.00";

            this.lblStatusMontoLabel.AutoSize = true;
            this.lblStatusMontoLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatusMontoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lblStatusMontoLabel.Location = new System.Drawing.Point(15, 15);
            this.lblStatusMontoLabel.Name = "lblStatusMontoLabel";
            this.lblStatusMontoLabel.Size = new System.Drawing.Size(48, 15);
            this.lblStatusMontoLabel.TabIndex = 5;
            this.lblStatusMontoLabel.Text = "Balance";

            this.pnlCashier.BackColor = System.Drawing.Color.White;
            this.pnlCashier.Controls.Add(this.lblDiferencia);
            this.pnlCashier.Controls.Add(this.lblDiferenciaLabel);
            this.pnlCashier.Controls.Add(this.lblMontoReal);
            this.pnlCashier.Controls.Add(this.txtMontoReal);
            this.pnlCashier.Controls.Add(this.lblMontoRealLabel);
            this.pnlCashier.Controls.Add(this.lblMontoEsperado);
            this.pnlCashier.Controls.Add(this.lblMontoEsperadoLabel);
            this.pnlCashier.Controls.Add(this.lblCashierTitle);
            this.pnlCashier.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCashier.Location = new System.Drawing.Point(0, 180);
            this.pnlCashier.Margin = new System.Windows.Forms.Padding(0, 0, 0, 15);
            this.pnlCashier.Name = "pnlCashier";
            this.pnlCashier.Padding = new System.Windows.Forms.Padding(15);
            this.pnlCashier.Size = new System.Drawing.Size(994, 180);
            this.pnlCashier.TabIndex = 3;

            this.lblDiferencia.AutoSize = true;
            this.lblDiferencia.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDiferencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(46)))));
            this.lblDiferencia.Location = new System.Drawing.Point(545, 70);
            this.lblDiferencia.Name = "lblDiferencia";
            this.lblDiferencia.Size = new System.Drawing.Size(45, 19);
            this.lblDiferencia.TabIndex = 0;
            this.lblDiferencia.Text = "$0.00";

            this.lblDiferenciaLabel.AutoSize = true;
            this.lblDiferenciaLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDiferenciaLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(46)))));
            this.lblDiferenciaLabel.Location = new System.Drawing.Point(545, 50);
            this.lblDiferenciaLabel.Name = "lblDiferenciaLabel";
            this.lblDiferenciaLabel.Size = new System.Drawing.Size(63, 15);
            this.lblDiferenciaLabel.TabIndex = 1;
            this.lblDiferenciaLabel.Text = "Diferencia:";

            this.lblMontoReal.AutoSize = true;
            this.lblMontoReal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMontoReal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(46)))));
            this.lblMontoReal.Location = new System.Drawing.Point(280, 100);
            this.lblMontoReal.Name = "lblMontoReal";
            this.lblMontoReal.Size = new System.Drawing.Size(45, 19);
            this.lblMontoReal.TabIndex = 2;
            this.lblMontoReal.Text = "$0.00";

            this.txtMontoReal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMontoReal.Location = new System.Drawing.Point(280, 70);
            this.txtMontoReal.Name = "txtMontoReal";
            this.txtMontoReal.Size = new System.Drawing.Size(150, 25);
            this.txtMontoReal.TabIndex = 3;
            this.txtMontoReal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            this.lblMontoRealLabel.AutoSize = true;
            this.lblMontoRealLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMontoRealLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(46)))));
            this.lblMontoRealLabel.Location = new System.Drawing.Point(280, 50);
            this.lblMontoRealLabel.Name = "lblMontoRealLabel";
            this.lblMontoRealLabel.Size = new System.Drawing.Size(113, 15);
            this.lblMontoRealLabel.TabIndex = 4;
            this.lblMontoRealLabel.Text = "Monto Real en Caja:";

            this.lblMontoEsperado.AutoSize = true;
            this.lblMontoEsperado.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMontoEsperado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(46)))));
            this.lblMontoEsperado.Location = new System.Drawing.Point(15, 70);
            this.lblMontoEsperado.Name = "lblMontoEsperado";
            this.lblMontoEsperado.Size = new System.Drawing.Size(45, 19);
            this.lblMontoEsperado.TabIndex = 5;
            this.lblMontoEsperado.Text = "$0.00";

            this.lblMontoEsperadoLabel.AutoSize = true;
            this.lblMontoEsperadoLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMontoEsperadoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(46)))));
            this.lblMontoEsperadoLabel.Location = new System.Drawing.Point(15, 50);
            this.lblMontoEsperadoLabel.Name = "lblMontoEsperadoLabel";
            this.lblMontoEsperadoLabel.Size = new System.Drawing.Size(149, 15);
            this.lblMontoEsperadoLabel.TabIndex = 6;
            this.lblMontoEsperadoLabel.Text = "Monto Esperado (Sistema):";

            this.lblCashierTitle.AutoSize = true;
            this.lblCashierTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCashierTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(46)))));
            this.lblCashierTitle.Location = new System.Drawing.Point(15, 15);
            this.lblCashierTitle.Name = "lblCashierTitle";
            this.lblCashierTitle.Size = new System.Drawing.Size(115, 21);
            this.lblCashierTitle.TabIndex = 7;
            this.lblCashierTitle.Text = "Cierre de Caja";

            this.pnlSummary.BackColor = System.Drawing.Color.Transparent;
            this.pnlSummary.Controls.Add(this.pnlSumItem4);
            this.pnlSummary.Controls.Add(this.pnlSumItem3);
            this.pnlSummary.Controls.Add(this.pnlSumItem2);
            this.pnlSummary.Controls.Add(this.pnlSumItem1);
            this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSummary.Location = new System.Drawing.Point(0, 80);
            this.pnlSummary.Margin = new System.Windows.Forms.Padding(0, 0, 0, 15);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(994, 100);
            this.pnlSummary.TabIndex = 4;

            this.pnlSumItem4.BackColor = System.Drawing.Color.White;
            this.pnlSumItem4.Controls.Add(this.lblSum4Value);
            this.pnlSumItem4.Controls.Add(this.lblSum4Label);
            this.pnlSumItem4.Location = new System.Drawing.Point(645, 0);
            this.pnlSumItem4.Name = "pnlSumItem4";
            this.pnlSumItem4.Padding = new System.Windows.Forms.Padding(12);
            this.pnlSumItem4.Size = new System.Drawing.Size(200, 90);
            this.pnlSumItem4.TabIndex = 0;

            this.lblSum4Value.AutoSize = true;
            this.lblSum4Value.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblSum4Value.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(46)))));
            this.lblSum4Value.Location = new System.Drawing.Point(12, 35);
            this.lblSum4Value.Name = "lblSum4Value";
            this.lblSum4Value.Size = new System.Drawing.Size(77, 32);
            this.lblSum4Value.TabIndex = 0;
            this.lblSum4Value.Text = "$0.00";

            this.lblSum4Label.AutoSize = true;
            this.lblSum4Label.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblSum4Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.lblSum4Label.Location = new System.Drawing.Point(12, 12);
            this.lblSum4Label.Name = "lblSum4Label";
            this.lblSum4Label.Size = new System.Drawing.Size(71, 13);
            this.lblSum4Label.TabIndex = 1;
            this.lblSum4Label.Text = "Mayor Venta";

            this.pnlSumItem3.BackColor = System.Drawing.Color.White;
            this.pnlSumItem3.Controls.Add(this.lblSum3Value);
            this.pnlSumItem3.Controls.Add(this.lblSum3Label);
            this.pnlSumItem3.Location = new System.Drawing.Point(430, 0);
            this.pnlSumItem3.Name = "pnlSumItem3";
            this.pnlSumItem3.Padding = new System.Windows.Forms.Padding(12);
            this.pnlSumItem3.Size = new System.Drawing.Size(200, 90);
            this.pnlSumItem3.TabIndex = 1;

            this.lblSum3Value.AutoSize = true;
            this.lblSum3Value.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblSum3Value.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(46)))));
            this.lblSum3Value.Location = new System.Drawing.Point(12, 35);
            this.lblSum3Value.Name = "lblSum3Value";
            this.lblSum3Value.Size = new System.Drawing.Size(77, 32);
            this.lblSum3Value.TabIndex = 0;
            this.lblSum3Value.Text = "$0.00";

            this.lblSum3Label.AutoSize = true;
            this.lblSum3Label.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblSum3Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.lblSum3Label.Location = new System.Drawing.Point(12, 12);
            this.lblSum3Label.Name = "lblSum3Label";
            this.lblSum3Label.Size = new System.Drawing.Size(88, 13);
            this.lblSum3Label.TabIndex = 1;
            this.lblSum3Label.Text = "Venta Promedio";

            this.pnlSumItem2.BackColor = System.Drawing.Color.White;
            this.pnlSumItem2.Controls.Add(this.lblSum2Value);
            this.pnlSumItem2.Controls.Add(this.lblSum2Label);
            this.pnlSumItem2.Location = new System.Drawing.Point(215, 0);
            this.pnlSumItem2.Name = "pnlSumItem2";
            this.pnlSumItem2.Padding = new System.Windows.Forms.Padding(12);
            this.pnlSumItem2.Size = new System.Drawing.Size(200, 90);
            this.pnlSumItem2.TabIndex = 2;

            this.lblSum2Value.AutoSize = true;
            this.lblSum2Value.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblSum2Value.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(46)))));
            this.lblSum2Value.Location = new System.Drawing.Point(12, 35);
            this.lblSum2Value.Name = "lblSum2Value";
            this.lblSum2Value.Size = new System.Drawing.Size(28, 32);
            this.lblSum2Value.TabIndex = 0;
            this.lblSum2Value.Text = "0";

            this.lblSum2Label.AutoSize = true;
            this.lblSum2Label.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblSum2Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.lblSum2Label.Location = new System.Drawing.Point(12, 12);
            this.lblSum2Label.Name = "lblSum2Label";
            this.lblSum2Label.Size = new System.Drawing.Size(143, 13);
            this.lblSum2Label.TabIndex = 1;
            this.lblSum2Label.Text = "Cantidad de Transacciones";

            this.pnlSumItem1.BackColor = System.Drawing.Color.White;
            this.pnlSumItem1.Controls.Add(this.lblSum1Value);
            this.pnlSumItem1.Controls.Add(this.lblSum1Label);
            this.pnlSumItem1.Location = new System.Drawing.Point(0, 0);
            this.pnlSumItem1.Name = "pnlSumItem1";
            this.pnlSumItem1.Padding = new System.Windows.Forms.Padding(12);
            this.pnlSumItem1.Size = new System.Drawing.Size(200, 90);
            this.pnlSumItem1.TabIndex = 3;

            this.lblSum1Value.AutoSize = true;
            this.lblSum1Value.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblSum1Value.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.lblSum1Value.Location = new System.Drawing.Point(12, 35);
            this.lblSum1Value.Name = "lblSum1Value";
            this.lblSum1Value.Size = new System.Drawing.Size(77, 32);
            this.lblSum1Value.TabIndex = 0;
            this.lblSum1Value.Text = "$0.00";

            this.lblSum1Label.AutoSize = true;
            this.lblSum1Label.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblSum1Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.lblSum1Label.Location = new System.Drawing.Point(12, 12);
            this.lblSum1Label.Name = "lblSum1Label";
            this.lblSum1Label.Size = new System.Drawing.Size(84, 13);
            this.lblSum1Label.TabIndex = 1;
            this.lblSum1Label.Text = "Total de Ventas";

            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblHeaderDesc);
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(0, 0, 0, 15);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(15);
            this.pnlHeader.Size = new System.Drawing.Size(994, 80);
            this.pnlHeader.TabIndex = 5;

            this.lblHeaderDesc.AutoSize = true;
            this.lblHeaderDesc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblHeaderDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblHeaderDesc.Location = new System.Drawing.Point(15, 45);
            this.lblHeaderDesc.Name = "lblHeaderDesc";
            this.lblHeaderDesc.Size = new System.Drawing.Size(307, 19);
            this.lblHeaderDesc.TabIndex = 0;
            this.lblHeaderDesc.Text = "Reconciliacion de ventas del dia y balance de caja";

            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(46)))));
            this.lblHeaderTitle.Location = new System.Drawing.Point(15, 15);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(157, 30);
            this.lblHeaderTitle.TabIndex = 1;
            this.lblHeaderTitle.Text = "Cierre de Caja";

            this.lblTotalVentas.Location = new System.Drawing.Point(0, 0);
            this.lblTotalVentas.Name = "lblTotalVentas";
            this.lblTotalVentas.Size = new System.Drawing.Size(100, 23);
            this.lblTotalVentas.TabIndex = 0;

            this.lblCantidadVentas.Location = new System.Drawing.Point(0, 0);
            this.lblCantidadVentas.Name = "lblCantidadVentas";
            this.lblCantidadVentas.Size = new System.Drawing.Size(100, 23);
            this.lblCantidadVentas.TabIndex = 0;

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 700);
            this.Controls.Add(this.pnlMain);
            this.Name = "FrmCaja";
            this.Text = "Cierre de Caja";
            this.Load += new System.EventHandler(this.FrmCaja_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlSalesTable.ResumeLayout(false);
            this.pnlSalesTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.pnlCashier.ResumeLayout(false);
            this.pnlCashier.PerformLayout();
            this.pnlSummary.ResumeLayout(false);
            this.pnlSumItem4.ResumeLayout(false);
            this.pnlSumItem4.PerformLayout();
            this.pnlSumItem3.ResumeLayout(false);
            this.pnlSumItem3.PerformLayout();
            this.pnlSumItem2.ResumeLayout(false);
            this.pnlSumItem2.PerformLayout();
            this.pnlSumItem1.ResumeLayout(false);
            this.pnlSumItem1.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderDesc;
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Panel pnlSumItem1;
        private System.Windows.Forms.Label lblSum1Label;
        private System.Windows.Forms.Label lblSum1Value;
        private System.Windows.Forms.Panel pnlSumItem2;
        private System.Windows.Forms.Label lblSum2Label;
        private System.Windows.Forms.Label lblSum2Value;
        private System.Windows.Forms.Panel pnlSumItem3;
        private System.Windows.Forms.Label lblSum3Label;
        private System.Windows.Forms.Label lblSum3Value;
        private System.Windows.Forms.Panel pnlSumItem4;
        private System.Windows.Forms.Label lblSum4Label;
        private System.Windows.Forms.Label lblSum4Value;
        private System.Windows.Forms.Panel pnlCashier;
        private System.Windows.Forms.Label lblCashierTitle;
        private System.Windows.Forms.Label lblMontoEsperadoLabel;
        private System.Windows.Forms.Label lblMontoEsperado;
        private System.Windows.Forms.Label lblMontoRealLabel;
        private System.Windows.Forms.TextBox txtMontoReal;
        private System.Windows.Forms.Label lblMontoReal;
        private System.Windows.Forms.Label lblDiferenciaLabel;
        private System.Windows.Forms.Label lblDiferencia;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Label lblStatusMontoLabel;
        private System.Windows.Forms.Label lblStatusMonto;
        private System.Windows.Forms.Label lblStatusStateLabel;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblStatusPercLabel;
        private System.Windows.Forms.Label lblStatusPerc;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Panel pnlSalesTable;
        private System.Windows.Forms.Label lblSalesTitle;
        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.Label lblTotalVentas;
        private System.Windows.Forms.Label lblCantidadVentas;
    }
}
