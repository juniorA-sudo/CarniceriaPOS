namespace CarniceriaPOS.UI.Forms
{
    partial class FrmReporteBase
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

        protected void InitializeComponent()
        {
            this.pnlExternalHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSubtituloHeader = new System.Windows.Forms.Label();
            this.lblTituloModulo = new System.Windows.Forms.Label();
            this.shadowContainer = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.pnlDocumento = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlDatos = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTituloReporte = new System.Windows.Forms.Label();
            this.pnlExternalHeader.SuspendLayout();
            this.shadowContainer.SuspendLayout();
            this.pnlDocumento.SuspendLayout();
            this.SuspendLayout();

            this.pnlExternalHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlExternalHeader.BorderRadius = 15;
            this.pnlExternalHeader.Controls.Add(this.lblSubtituloHeader);
            this.pnlExternalHeader.Controls.Add(this.lblTituloModulo);
            this.pnlExternalHeader.FillColor = System.Drawing.Color.White;
            this.pnlExternalHeader.Location = new System.Drawing.Point(25, 15);
            this.pnlExternalHeader.Name = "pnlExternalHeader";
            this.pnlExternalHeader.Size = new System.Drawing.Size(1095, 100);
            this.pnlExternalHeader.TabIndex = 0;

            this.lblSubtituloHeader.AutoSize = true;
            this.lblSubtituloHeader.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtituloHeader.ForeColor = System.Drawing.Color.Gray;
            this.lblSubtituloHeader.Location = new System.Drawing.Point(22, 55);
            this.lblSubtituloHeader.Name = "lblSubtituloHeader";
            this.lblSubtituloHeader.Size = new System.Drawing.Size(0, 19);
            this.lblSubtituloHeader.TabIndex = 1;

            this.lblTituloModulo.AutoSize = true;
            this.lblTituloModulo.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTituloModulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.lblTituloModulo.Location = new System.Drawing.Point(20, 15);
            this.lblTituloModulo.Name = "lblTituloModulo";
            this.lblTituloModulo.Size = new System.Drawing.Size(0, 37);
            this.lblTituloModulo.TabIndex = 0;

            this.shadowContainer.BackColor = System.Drawing.Color.Transparent;
            this.shadowContainer.Controls.Add(this.pnlDocumento);
            this.shadowContainer.FillColor = System.Drawing.Color.White;
            this.shadowContainer.Location = new System.Drawing.Point(25, 130);
            this.shadowContainer.Name = "shadowContainer";
            this.shadowContainer.Padding = new System.Windows.Forms.Padding(5);
            this.shadowContainer.ShadowColor = System.Drawing.Color.Black;
            this.shadowContainer.ShadowDepth = 50;
            this.shadowContainer.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.ForwardDiagonal;
            this.shadowContainer.Size = new System.Drawing.Size(1095, 630);
            this.shadowContainer.TabIndex = 1;

            this.pnlDocumento.Controls.Add(this.pnlDatos);
            this.pnlDocumento.Controls.Add(this.lblTituloReporte);
            this.pnlDocumento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDocumento.FillColor = System.Drawing.Color.White;
            this.pnlDocumento.Location = new System.Drawing.Point(5, 5);
            this.pnlDocumento.Name = "pnlDocumento";
            this.pnlDocumento.Size = new System.Drawing.Size(1085, 620);
            this.pnlDocumento.TabIndex = 0;

            this.pnlDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDatos.Location = new System.Drawing.Point(0, 220);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(1085, 400);
            this.pnlDatos.TabIndex = 1;

            this.lblTituloReporte.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloReporte.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTituloReporte.Location = new System.Drawing.Point(0, 160);
            this.lblTituloReporte.Name = "lblTituloReporte";
            this.lblTituloReporte.Size = new System.Drawing.Size(1085, 60);
            this.lblTituloReporte.TabIndex = 2;
            this.lblTituloReporte.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1144, 794);
            this.Controls.Add(this.shadowContainer);
            this.Controls.Add(this.pnlExternalHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmReporteBase";
            this.pnlExternalHeader.ResumeLayout(false);
            this.pnlExternalHeader.PerformLayout();
            this.shadowContainer.ResumeLayout(false);
            this.pnlDocumento.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        protected Guna.UI2.WinForms.Guna2Panel pnlExternalHeader;
        protected System.Windows.Forms.Label lblTituloModulo;
        protected System.Windows.Forms.Label lblSubtituloHeader;
        protected Guna.UI2.WinForms.Guna2ShadowPanel shadowContainer;
        protected Guna.UI2.WinForms.Guna2Panel pnlDocumento;
        protected Guna.UI2.WinForms.Guna2Panel pnlDatos;
        protected System.Windows.Forms.Label lblTituloReporte;
    }
}
