namespace CarniceriaPOS.UI.Forms
{
    partial class FrmReportes
    {
        private System.ComponentModel.IContainer components = null;
        private Guna.UI2.WinForms.Guna2Panel pnlMain;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private Guna.UI2.WinForms.Guna2Button btnVolver;
        private Guna.UI2.WinForms.Guna2Panel pnlSelector;
        private System.Windows.Forms.FlowLayoutPanel flpReportes;
        private Guna.UI2.WinForms.Guna2Panel pnlReportHost;
        private Guna.UI2.WinForms.Guna2Panel pnlNav;
        private Guna.UI2.WinForms.Guna2Button btnGenerales;
        private Guna.UI2.WinForms.Guna2Button btnEspecificos;
        private Guna.UI2.WinForms.Guna2Separator lineSelected;

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
            this.pnlMain = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlReportHost = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlSelector = new Guna.UI2.WinForms.Guna2Panel();
            this.flpReportes = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlNav = new Guna.UI2.WinForms.Guna2Panel();
            this.lineSelected = new Guna.UI2.WinForms.Guna2Separator();
            this.btnEspecificos = new Guna.UI2.WinForms.Guna2Button();
            this.btnGenerales = new Guna.UI2.WinForms.Guna2Button();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.btnVolver = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlSelector.SuspendLayout();
            this.pnlNav.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();

            // pnlMain
            this.pnlMain.Controls.Add(this.pnlReportHost);
            this.pnlMain.Controls.Add(this.pnlSelector);
            this.pnlMain.Controls.Add(this.pnlNav);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.FillColor = System.Drawing.Color.FromArgb(242, 245, 250);
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1144, 794);
            this.pnlMain.TabIndex = 0;

            // pnlReportHost
            this.pnlReportHost.BackColor = System.Drawing.Color.Transparent;
            this.pnlReportHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlReportHost.Location = new System.Drawing.Point(0, 114);
            this.pnlReportHost.Name = "pnlReportHost";
            this.pnlReportHost.Size = new System.Drawing.Size(1144, 680);
            this.pnlReportHost.TabIndex = 2;
            this.pnlReportHost.Visible = false;

            // pnlSelector - El contenedor de las tarjetas
            this.pnlSelector.BackColor = System.Drawing.Color.Transparent;
            this.pnlSelector.Controls.Add(this.flpReportes);
            this.pnlSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSelector.Location = new System.Drawing.Point(0, 114);
            this.pnlSelector.Name = "pnlSelector";
            this.pnlSelector.Padding = new System.Windows.Forms.Padding(10);
            this.pnlSelector.Size = new System.Drawing.Size(1144, 680);
            this.pnlSelector.TabIndex = 1;

            // flpReportes - Configuracion CRITICA para 3x2
            this.flpReportes.AutoScroll = true;
            this.flpReportes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpReportes.Location = new System.Drawing.Point(10, 10);
            this.flpReportes.Name = "flpReportes";
            this.flpReportes.Padding = new System.Windows.Forms.Padding(15, 5, 0, 0); // Padding para centrar el bloque
            this.flpReportes.Size = new System.Drawing.Size(1124, 660);
            this.flpReportes.TabIndex = 0;
            this.flpReportes.WrapContents = true; // Permite que las tarjetas bajen a la siguiente linea

            // pnlNav
            this.pnlNav.BackColor = System.Drawing.Color.Transparent;
            this.pnlNav.Controls.Add(this.lineSelected);
            this.pnlNav.Controls.Add(this.btnEspecificos);
            this.pnlNav.Controls.Add(this.btnGenerales);
            this.pnlNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNav.FillColor = System.Drawing.Color.White;
            this.pnlNav.Location = new System.Drawing.Point(0, 64);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(1144, 50);
            this.pnlNav.TabIndex = 3;

            // lineSelected (Animacion visual de pestana)
            this.lineSelected.FillColor = System.Drawing.Color.FromArgb(30, 58, 95);
            this.lineSelected.FillThickness = 3;
            this.lineSelected.Location = new System.Drawing.Point(20, 45);
            this.lineSelected.Name = "lineSelected";
            this.lineSelected.Size = new System.Drawing.Size(150, 5);
            this.lineSelected.TabIndex = 2;

            // btnGenerales
            this.btnGenerales.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnGenerales.Checked = true;
            this.btnGenerales.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnGenerales.CheckedState.ForeColor = System.Drawing.Color.FromArgb(30, 58, 95);
            this.btnGenerales.FillColor = System.Drawing.Color.White;
            this.btnGenerales.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGenerales.ForeColor = System.Drawing.Color.FromArgb(30, 58, 95);
            this.btnGenerales.Location = new System.Drawing.Point(20, 0);
            this.btnGenerales.Name = "btnGenerales";
            this.btnGenerales.Size = new System.Drawing.Size(150, 45);
            this.btnGenerales.Text = "GENERALES";
            this.btnGenerales.Click += new System.EventHandler(this.Tab_Click);

            // btnEspecificos
            this.btnEspecificos.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnEspecificos.FillColor = System.Drawing.Color.White;
            this.btnEspecificos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEspecificos.ForeColor = System.Drawing.Color.Gray;
            this.btnEspecificos.Location = new System.Drawing.Point(170, 0);
            this.btnEspecificos.Name = "btnEspecificos";
            this.btnEspecificos.Size = new System.Drawing.Size(150, 45);
            this.btnEspecificos.Text = "ESPECIFICOS";
            this.btnEspecificos.Click += new System.EventHandler(this.Tab_Click);

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.Controls.Add(this.btnVolver);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.FillColor = System.Drawing.Color.White;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1144, 64);
            this.pnlHeader.TabIndex = 0;

            // btnVolver
            this.btnVolver.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnVolver.BorderRadius = 8;
            this.btnVolver.FillColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnVolver.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.Location = new System.Drawing.Point(1000, 14);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(130, 35);
            this.btnVolver.Text = "Volver al Menu";
            this.btnVolver.Visible = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(30, 58, 95);
            this.lblTitulo.Location = new System.Drawing.Point(20, 17);
            this.lblTitulo.Text = "Panel de Reportes";

            // FrmReportes
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 794);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmReportes";
            this.Load += new System.EventHandler(this.FrmReportes_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlSelector.ResumeLayout(false);
            this.pnlNav.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}