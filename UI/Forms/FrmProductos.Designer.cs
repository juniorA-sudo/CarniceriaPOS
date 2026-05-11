namespace CarniceriaPOS.UI.Forms
{
    partial class FrmProductos
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
            this.pnlProductos = new System.Windows.Forms.Panel();
            this.flpProductos = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cmbCategorias = new System.Windows.Forms.ComboBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.btnAgregarNuevo = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlProductos.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();

            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(242, 245, 248);
            this.pnlMain.Controls.Add(this.pnlProductos);
            this.pnlMain.Controls.Add(this.pnlTop);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(20);
            this.pnlMain.Size = new System.Drawing.Size(1144, 794);
            this.pnlMain.TabIndex = 0;

            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblCategoria);
            this.pnlTop.Controls.Add(this.cmbCategorias);
            this.pnlTop.Controls.Add(this.lblTitulo);
            this.pnlTop.Controls.Add(this.txtBusqueda);
            this.pnlTop.Controls.Add(this.btnAgregarNuevo);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(20, 20);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1104, 100);
            this.pnlTop.TabIndex = 0;

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(45, 52, 54);
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(258, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Catalogo de Productos";

            this.txtBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBusqueda.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtBusqueda.ForeColor = System.Drawing.Color.Gray;
            this.txtBusqueda.Location = new System.Drawing.Point(25, 58);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(350, 27);
            this.txtBusqueda.TabIndex = 1;
            this.txtBusqueda.Text = "Buscar por nombre o codigo...";
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);

            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblCategoria.Location = new System.Drawing.Point(400, 62);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(71, 19);
            this.lblCategoria.TabIndex = 4;
            this.lblCategoria.Text = "Categoria:";

            this.cmbCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategorias.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbCategorias.FormattingEnabled = true;
            this.cmbCategorias.Location = new System.Drawing.Point(475, 57);
            this.cmbCategorias.Name = "cmbCategorias";
            this.cmbCategorias.Size = new System.Drawing.Size(220, 28);
            this.cmbCategorias.TabIndex = 2;
            this.cmbCategorias.SelectedIndexChanged += new System.EventHandler(this.cmbCategorias_SelectedIndexChanged);

            this.btnAgregarNuevo.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnAgregarNuevo.FlatAppearance.BorderSize = 0;
            this.btnAgregarNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarNuevo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAgregarNuevo.ForeColor = System.Drawing.Color.White;
            this.btnAgregarNuevo.Location = new System.Drawing.Point(880, 50);
            this.btnAgregarNuevo.Name = "btnAgregarNuevo";
            this.btnAgregarNuevo.Size = new System.Drawing.Size(200, 40);
            this.btnAgregarNuevo.TabIndex = 3;
            this.btnAgregarNuevo.Text = "+ NUEVO PRODUCTO";
            this.btnAgregarNuevo.UseVisualStyleBackColor = false;
            this.btnAgregarNuevo.Click += new System.EventHandler(this.btnAgregarNuevo_Click);

            this.pnlProductos.BackColor = System.Drawing.Color.Transparent;
            this.pnlProductos.Controls.Add(this.flpProductos);
            this.pnlProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProductos.Location = new System.Drawing.Point(20, 120);
            this.pnlProductos.Name = "pnlProductos";
            this.pnlProductos.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.pnlProductos.Size = new System.Drawing.Size(1104, 654);
            this.pnlProductos.TabIndex = 1;

            this.flpProductos.AutoScroll = true;
            this.flpProductos.BackColor = System.Drawing.Color.White;
            this.flpProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpProductos.Location = new System.Drawing.Point(0, 15);
            this.flpProductos.Name = "flpProductos";
            this.flpProductos.Padding = new System.Windows.Forms.Padding(10);
            this.flpProductos.Size = new System.Drawing.Size(1104, 639);
            this.flpProductos.TabIndex = 0;

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 794);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion de Inventario";
            this.Load += new System.EventHandler(this.FrmProductos_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlProductos.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Button btnAgregarNuevo;
        private System.Windows.Forms.Panel pnlProductos;
        private System.Windows.Forms.FlowLayoutPanel flpProductos;
        private System.Windows.Forms.ComboBox cmbCategorias;
        private System.Windows.Forms.Label lblCategoria;
    }
}
