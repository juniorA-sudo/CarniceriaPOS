namespace CarniceriaPOS.UI.Forms
{
    partial class FrmPrincipal
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
            this.components = new System.ComponentModel.Container();
            this.pnlSidebar = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlContent = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlContentHost = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblUser = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblRole = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnProductos = new Guna.UI2.WinForms.Guna2Button();
            this.btnClientes = new Guna.UI2.WinForms.Guna2Button();
            this.btnProveedores = new Guna.UI2.WinForms.Guna2Button();
            this.btnVentas = new Guna.UI2.WinForms.Guna2Button();
            this.btnCompras = new Guna.UI2.WinForms.Guna2Button();
            this.btnReportes = new Guna.UI2.WinForms.Guna2Button();
            this.btnUsuarios = new Guna.UI2.WinForms.Guna2Button();
            this.btnEmpleados = new Guna.UI2.WinForms.Guna2Button();
            this.btnSalir = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(26, 31, 46);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(260, 900);
            this.pnlSidebar.TabIndex = 0;
            
            this.btnVentas.BorderRadius = 8;
            this.btnVentas.FillColor = System.Drawing.Color.FromArgb(30, 58, 95);
            this.btnVentas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnVentas.ForeColor = System.Drawing.Color.White;
            this.btnVentas.HoverState.FillColor = System.Drawing.Color.FromArgb(41, 74, 118);
            this.btnVentas.Location = new System.Drawing.Point(15, 20);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(230, 45);
            this.btnVentas.TabIndex = 0;
            this.btnVentas.Text = "Ventas";
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            this.pnlSidebar.Controls.Add(this.btnVentas);

            this.btnCompras.BorderRadius = 8;
            this.btnCompras.FillColor = System.Drawing.Color.Transparent;
            this.btnCompras.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCompras.ForeColor = System.Drawing.Color.White;
            this.btnCompras.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 48, 72);
            this.btnCompras.Location = new System.Drawing.Point(15, 75);
            this.btnCompras.Name = "btnCompras";
            this.btnCompras.Size = new System.Drawing.Size(230, 45);
            this.btnCompras.TabIndex = 1;
            this.btnCompras.Text = "Compras";
            this.btnCompras.Click += new System.EventHandler(this.btnCompras_Click);
            this.pnlSidebar.Controls.Add(this.btnCompras);

            this.btnProductos.BorderRadius = 8;
            this.btnProductos.FillColor = System.Drawing.Color.Transparent;
            this.btnProductos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnProductos.ForeColor = System.Drawing.Color.White;
            this.btnProductos.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 48, 72);
            this.btnProductos.Location = new System.Drawing.Point(15, 130);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(230, 45);
            this.btnProductos.TabIndex = 2;
            this.btnProductos.Text = "Productos";
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            this.pnlSidebar.Controls.Add(this.btnProductos);

            this.btnClientes.BorderRadius = 8;
            this.btnClientes.FillColor = System.Drawing.Color.Transparent;
            this.btnClientes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClientes.ForeColor = System.Drawing.Color.White;
            this.btnClientes.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 48, 72);
            this.btnClientes.Location = new System.Drawing.Point(15, 185);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(230, 45);
            this.btnClientes.TabIndex = 3;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            this.pnlSidebar.Controls.Add(this.btnClientes);

            this.btnProveedores.BorderRadius = 8;
            this.btnProveedores.FillColor = System.Drawing.Color.Transparent;
            this.btnProveedores.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnProveedores.ForeColor = System.Drawing.Color.White;
            this.btnProveedores.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 48, 72);
            this.btnProveedores.Location = new System.Drawing.Point(15, 240);
            this.btnProveedores.Name = "btnProveedores";
            this.btnProveedores.Size = new System.Drawing.Size(230, 45);
            this.btnProveedores.TabIndex = 4;
            this.btnProveedores.Text = "Proveedores";
            this.btnProveedores.Click += new System.EventHandler(this.btnProveedores_Click);
            this.pnlSidebar.Controls.Add(this.btnProveedores);

            this.btnUsuarios.BorderRadius = 8;
            this.btnUsuarios.FillColor = System.Drawing.Color.Transparent;
            this.btnUsuarios.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnUsuarios.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 48, 72);
            this.btnUsuarios.Location = new System.Drawing.Point(15, 295);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(230, 45);
            this.btnUsuarios.TabIndex = 5;
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            this.pnlSidebar.Controls.Add(this.btnUsuarios);

            this.btnEmpleados.BorderRadius = 8;
            this.btnEmpleados.FillColor = System.Drawing.Color.Transparent;
            this.btnEmpleados.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnEmpleados.ForeColor = System.Drawing.Color.White;
            this.btnEmpleados.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 48, 72);
            this.btnEmpleados.Location = new System.Drawing.Point(15, 350);
            this.btnEmpleados.Name = "btnEmpleados";
            this.btnEmpleados.Size = new System.Drawing.Size(230, 45);
            this.btnEmpleados.TabIndex = 6;
            this.btnEmpleados.Text = " Empleados";
            this.btnEmpleados.Click += new System.EventHandler(this.btnEmpleados_Click);
            this.pnlSidebar.Controls.Add(this.btnEmpleados);

            this.btnReportes.BorderRadius = 8;
            this.btnReportes.FillColor = System.Drawing.Color.Transparent;
            this.btnReportes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnReportes.ForeColor = System.Drawing.Color.White;
            this.btnReportes.HoverState.FillColor = System.Drawing.Color.FromArgb(37, 48, 72);
            this.btnReportes.Location = new System.Drawing.Point(15, 405);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(230, 45);
            this.btnReportes.TabIndex = 7;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            this.pnlSidebar.Controls.Add(this.btnReportes);

            this.btnSalir.BorderRadius = 8;
            this.btnSalir.FillColor = System.Drawing.Color.FromArgb(255, 107, 107);
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.HoverState.FillColor = System.Drawing.Color.FromArgb(232, 90, 90);
            this.btnSalir.Location = new System.Drawing.Point(15, 405);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(230, 45);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            this.pnlSidebar.Controls.Add(this.btnSalir);
            
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(30, 58, 95);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(260, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1180, 70);
            this.pnlHeader.TabIndex = 1;
            
            this.lblTitle.AutoSize = false;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(420, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Sistema Carniceria";
            this.pnlHeader.Controls.Add(this.lblTitle);
            
            this.lblUser.AutoSize = false;
            this.lblUser.BackColor = System.Drawing.Color.Transparent;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblUser.ForeColor = System.Drawing.Color.White;
            this.lblUser.Location = new System.Drawing.Point(930, 14);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(220, 20);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "Usuario: Admin";
            this.pnlHeader.Controls.Add(this.lblUser);
            
            this.lblRole.AutoSize = false;
            this.lblRole.BackColor = System.Drawing.Color.Transparent;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRole.ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.lblRole.Location = new System.Drawing.Point(930, 38);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(220, 20);
            this.lblRole.TabIndex = 2;
            this.lblRole.Text = "Rol: Administrador";
            this.pnlHeader.Controls.Add(this.lblRole);
            
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(15, 20, 25);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(260, 70);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(18);
            this.pnlContent.Size = new System.Drawing.Size(1180, 830);
            this.pnlContent.TabIndex = 2;
            this.pnlContent.Controls.Add(this.pnlContentHost);
            
            this.pnlContentHost.BackColor = System.Drawing.Color.White;
            this.pnlContentHost.BorderRadius = 14;
            this.pnlContentHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContentHost.Location = new System.Drawing.Point(18, 18);
            this.pnlContentHost.Name = "pnlContentHost";
            this.pnlContentHost.ShadowDecoration.Enabled = true;
            this.pnlContentHost.Size = new System.Drawing.Size(1144, 794);
            this.pnlContentHost.TabIndex = 0;
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(15, 20, 25);
            this.ClientSize = new System.Drawing.Size(1440, 900);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);
            this.MinimumSize = new System.Drawing.Size(1280, 820);
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema Carniceria";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.ResumeLayout(false);
        }

        private Guna.UI2.WinForms.Guna2Panel pnlSidebar;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2Panel pnlContent;
        private Guna.UI2.WinForms.Guna2Panel pnlContentHost;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblUser;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblRole;
        private Guna.UI2.WinForms.Guna2Button btnProductos;
        private Guna.UI2.WinForms.Guna2Button btnClientes;
        private Guna.UI2.WinForms.Guna2Button btnProveedores;
        private Guna.UI2.WinForms.Guna2Button btnVentas;
        private Guna.UI2.WinForms.Guna2Button btnCompras;
        private Guna.UI2.WinForms.Guna2Button btnReportes;
        private Guna.UI2.WinForms.Guna2Button btnUsuarios;
        private Guna.UI2.WinForms.Guna2Button btnEmpleados;
        private Guna.UI2.WinForms.Guna2Button btnSalir;
    }
}
