namespace CarniceriaPOS.UI.Forms
{
    partial class FrmEmpleados
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
            this.pnlMainContainer = new System.Windows.Forms.Panel();
            this.pnlFormulario = new System.Windows.Forms.Panel();
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.pnlGrilla = new System.Windows.Forms.Panel();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.pnlPie = new System.Windows.Forms.Panel();
            this.grpDatos = new System.Windows.Forms.GroupBox();

            this.lblTituloForm = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblCedula = new System.Windows.Forms.Label();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblDepartamento = new System.Windows.Forms.Label();
            this.cmbDepartamento = new System.Windows.Forms.ComboBox();
            this.lblPuesto = new System.Windows.Forms.Label();
            this.txtPuesto = new System.Windows.Forms.TextBox();
            this.lblSalario = new System.Windows.Forms.Label();
            this.txtSalario = new System.Windows.Forms.TextBox();
            this.chkActivo = new System.Windows.Forms.CheckBox();

            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();

            this.lblTituloGrilla = new System.Windows.Forms.Label();
            this.lblBusqueda = new System.Windows.Forms.Label();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvEmpleados = new System.Windows.Forms.DataGridView();

            this.lblTotal = new System.Windows.Forms.Label();
            this.lblConexion = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();

            this.pnlMainContainer.SuspendLayout();
            this.pnlFormulario.SuspendLayout();
            this.pnlDatos.SuspendLayout();
            this.pnlGrilla.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.pnlPie.SuspendLayout();
            this.grpDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).BeginInit();
            this.SuspendLayout();

            this.pnlMainContainer.Controls.Add(this.pnlGrilla);
            this.pnlMainContainer.Controls.Add(this.pnlFormulario);
            this.pnlMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlMainContainer.Name = "pnlMainContainer";
            this.pnlMainContainer.Size = new System.Drawing.Size(1024, 600);
            this.pnlMainContainer.TabIndex = 0;

            this.pnlFormulario.Controls.Add(this.pnlDatos);
            this.pnlFormulario.Controls.Add(this.lblTituloForm);
            this.pnlFormulario.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFormulario.Location = new System.Drawing.Point(0, 0);
            this.pnlFormulario.Name = "pnlFormulario";
            this.pnlFormulario.Size = new System.Drawing.Size(380, 600);
            this.pnlFormulario.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlFormulario.TabIndex = 0;

            this.lblTituloForm.AutoSize = true;
            this.lblTituloForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloForm.Location = new System.Drawing.Point(15, 15);
            this.lblTituloForm.Name = "lblTituloForm";
            this.lblTituloForm.Size = new System.Drawing.Size(180, 20);
            this.lblTituloForm.TabIndex = 0;
            this.lblTituloForm.Text = "Datos del Empleado";

            this.pnlDatos.Controls.Add(this.grpDatos);
            this.pnlDatos.Controls.Add(this.pnlBotones);
            this.pnlDatos.Location = new System.Drawing.Point(0, 50);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(380, 550);
            this.pnlDatos.TabIndex = 1;
            this.pnlDatos.AutoScroll = true;

            this.grpDatos.Controls.Add(this.lblID);
            this.grpDatos.Controls.Add(this.txtID);
            this.grpDatos.Controls.Add(this.lblNombre);
            this.grpDatos.Controls.Add(this.txtNombre);
            this.grpDatos.Controls.Add(this.lblCedula);
            this.grpDatos.Controls.Add(this.txtCedula);
            this.grpDatos.Controls.Add(this.lblTelefono);
            this.grpDatos.Controls.Add(this.txtTelefono);
            this.grpDatos.Controls.Add(this.lblDepartamento);
            this.grpDatos.Controls.Add(this.cmbDepartamento);
            this.grpDatos.Controls.Add(this.lblPuesto);
            this.grpDatos.Controls.Add(this.txtPuesto);
            this.grpDatos.Controls.Add(this.lblSalario);
            this.grpDatos.Controls.Add(this.txtSalario);
            this.grpDatos.Controls.Add(this.chkActivo);
            this.grpDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.grpDatos.Location = new System.Drawing.Point(10, 10);
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Size = new System.Drawing.Size(360, 380);
            this.grpDatos.TabIndex = 0;
            this.grpDatos.TabStop = false;
            this.grpDatos.Text = "Informacion";

            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblID.Location = new System.Drawing.Point(10, 25);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(75, 13);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID Empleado:";

            this.txtID.BackColor = System.Drawing.Color.LightGray;
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtID.Location = new System.Drawing.Point(180, 23);
            this.txtID.MaxLength = 10;
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(160, 20);
            this.txtID.TabIndex = 1;
            this.txtID.Text = "AUTOGENERADO";

            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblNombre.Location = new System.Drawing.Point(10, 50);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(115, 13);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre Completo:";

            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtNombre.Location = new System.Drawing.Point(10, 65);
            this.txtNombre.MaxLength = 100;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(330, 20);
            this.txtNombre.TabIndex = 3;

            this.lblCedula.AutoSize = true;
            this.lblCedula.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblCedula.Location = new System.Drawing.Point(10, 90);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(120, 13);
            this.lblCedula.TabIndex = 4;
            this.lblCedula.Text = "Cedula (000-0000000-0):";

            this.txtCedula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCedula.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtCedula.Location = new System.Drawing.Point(10, 105);
            this.txtCedula.MaxLength = 13;
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(330, 20);
            this.txtCedula.TabIndex = 5;

            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblTelefono.Location = new System.Drawing.Point(10, 130);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(52, 13);
            this.lblTelefono.TabIndex = 6;
            this.lblTelefono.Text = "Telefono:";

            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtTelefono.Location = new System.Drawing.Point(10, 145);
            this.txtTelefono.MaxLength = 12;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(330, 20);
            this.txtTelefono.TabIndex = 7;

            this.lblDepartamento.AutoSize = true;
            this.lblDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblDepartamento.Location = new System.Drawing.Point(10, 170);
            this.lblDepartamento.Name = "lblDepartamento";
            this.lblDepartamento.Size = new System.Drawing.Size(80, 13);
            this.lblDepartamento.TabIndex = 8;
            this.lblDepartamento.Text = "Departamento:";

            this.cmbDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmbDepartamento.FormattingEnabled = true;
            this.cmbDepartamento.Location = new System.Drawing.Point(10, 185);
            this.cmbDepartamento.Name = "cmbDepartamento";
            this.cmbDepartamento.Size = new System.Drawing.Size(330, 21);
            this.cmbDepartamento.TabIndex = 9;

            this.lblPuesto.AutoSize = true;
            this.lblPuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblPuesto.Location = new System.Drawing.Point(10, 210);
            this.lblPuesto.Name = "lblPuesto";
            this.lblPuesto.Size = new System.Drawing.Size(45, 13);
            this.lblPuesto.TabIndex = 10;
            this.lblPuesto.Text = "Puesto:";

            this.txtPuesto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtPuesto.Location = new System.Drawing.Point(10, 225);
            this.txtPuesto.MaxLength = 100;
            this.txtPuesto.Name = "txtPuesto";
            this.txtPuesto.Size = new System.Drawing.Size(330, 20);
            this.txtPuesto.TabIndex = 11;

            this.lblSalario.AutoSize = true;
            this.lblSalario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblSalario.Location = new System.Drawing.Point(10, 250);
            this.lblSalario.Name = "lblSalario";
            this.lblSalario.Size = new System.Drawing.Size(75, 13);
            this.lblSalario.TabIndex = 12;
            this.lblSalario.Text = "Salario (RD$):";

            this.txtSalario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSalario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtSalario.Location = new System.Drawing.Point(10, 265);
            this.txtSalario.MaxLength = 15;
            this.txtSalario.Name = "txtSalario";
            this.txtSalario.Size = new System.Drawing.Size(100, 20);
            this.txtSalario.TabIndex = 13;
            this.txtSalario.Text = "0.00";

            this.chkActivo.AutoSize = true;
            this.chkActivo.Checked = true;
            this.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.chkActivo.Location = new System.Drawing.Point(10, 300);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(100, 17);
            this.chkActivo.TabIndex = 14;
            this.chkActivo.Text = "Empleado Activo";
            this.chkActivo.UseVisualStyleBackColor = true;

            this.pnlBotones.Controls.Add(this.btnNuevo);
            this.pnlBotones.Controls.Add(this.btnGuardar);
            this.pnlBotones.Controls.Add(this.btnEliminar);
            this.pnlBotones.Controls.Add(this.btnLimpiar);
            this.pnlBotones.Location = new System.Drawing.Point(10, 400);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(360, 50);
            this.pnlBotones.TabIndex = 1;

            this.btnNuevo.BackColor = System.Drawing.Color.LightBlue;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.Location = new System.Drawing.Point(10, 10);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 30);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "+ Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);

            this.btnGuardar.BackColor = System.Drawing.Color.LightGreen;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.Location = new System.Drawing.Point(95, 10);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 30);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = " Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnEliminar.BackColor = System.Drawing.Color.LightCoral;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.Location = new System.Drawing.Point(180, 10);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 30);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = " Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            this.btnLimpiar.BackColor = System.Drawing.Color.LightGray;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.Location = new System.Drawing.Point(265, 10);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 30);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = " Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            this.pnlGrilla.Controls.Add(this.lblTituloGrilla);
            this.pnlGrilla.Controls.Add(this.lblBusqueda);
            this.pnlGrilla.Controls.Add(this.txtBusqueda);
            this.pnlGrilla.Controls.Add(this.btnBuscar);
            this.pnlGrilla.Controls.Add(this.dgvEmpleados);
            this.pnlGrilla.Controls.Add(this.pnlPie);
            this.pnlGrilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrilla.Location = new System.Drawing.Point(380, 0);
            this.pnlGrilla.Name = "pnlGrilla";
            this.pnlGrilla.Size = new System.Drawing.Size(644, 600);
            this.pnlGrilla.TabIndex = 1;
            this.pnlGrilla.BackColor = System.Drawing.Color.LightGreen;

            this.lblTituloGrilla.AutoSize = true;
            this.lblTituloGrilla.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloGrilla.Location = new System.Drawing.Point(15, 15);
            this.lblTituloGrilla.Name = "lblTituloGrilla";
            this.lblTituloGrilla.Size = new System.Drawing.Size(130, 20);
            this.lblTituloGrilla.TabIndex = 0;
            this.lblTituloGrilla.Text = "Lista de Empleados";

            this.lblBusqueda.AutoSize = true;
            this.lblBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblBusqueda.Location = new System.Drawing.Point(15, 45);
            this.lblBusqueda.Name = "lblBusqueda";
            this.lblBusqueda.Size = new System.Drawing.Size(155, 13);
            this.lblBusqueda.TabIndex = 1;
            this.lblBusqueda.Text = "Buscar por Nombre o Cedula...";

            this.txtBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtBusqueda.Location = new System.Drawing.Point(15, 62);
            this.txtBusqueda.MaxLength = 50;
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(500, 20);
            this.txtBusqueda.TabIndex = 2;
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);

            this.btnBuscar.BackColor = System.Drawing.Color.LightGray;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnBuscar.Location = new System.Drawing.Point(520, 62);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 20);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = " Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;

            this.dgvEmpleados.AllowUserToAddRows = false;
            this.dgvEmpleados.AllowUserToDeleteRows = false;
            this.dgvEmpleados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpleados.Location = new System.Drawing.Point(15, 92);
            this.dgvEmpleados.Name = "dgvEmpleados";
            this.dgvEmpleados.ReadOnly = true;
            this.dgvEmpleados.Size = new System.Drawing.Size(605, 420);
            this.dgvEmpleados.TabIndex = 4;
            this.dgvEmpleados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmpleados.SelectionChanged += new System.EventHandler(this.dgvEmpleados_SelectionChanged);

            this.pnlPie.Controls.Add(this.lblTotal);
            this.pnlPie.Controls.Add(this.lblConexion);
            this.pnlPie.Controls.Add(this.lblUsuario);
            this.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPie.Location = new System.Drawing.Point(0, 550);
            this.pnlPie.Name = "pnlPie";
            this.pnlPie.Size = new System.Drawing.Size(644, 50);
            this.pnlPie.BackColor = System.Drawing.Color.LightGray;
            this.pnlPie.TabIndex = 5;

            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblTotal.Location = new System.Drawing.Point(15, 15);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(120, 13);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Total Empleados: 0";

            this.lblConexion.AutoSize = true;
            this.lblConexion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblConexion.Location = new System.Drawing.Point(15, 30);
            this.lblConexion.Name = "lblConexion";
            this.lblConexion.Size = new System.Drawing.Size(80, 13);
            this.lblConexion.TabIndex = 1;
            this.lblConexion.Text = "Conexion: OK";

            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblUsuario.Location = new System.Drawing.Point(450, 15);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(70, 13);
            this.lblUsuario.TabIndex = 2;
            this.lblUsuario.Text = "Usuario: N/A";

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.pnlMainContainer);
            this.Name = "FrmEmpleados";
            this.Text = "Gestion de Empleados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmEmpleados_Load);

            this.pnlMainContainer.ResumeLayout(false);
            this.pnlFormulario.ResumeLayout(false);
            this.pnlFormulario.PerformLayout();
            this.pnlDatos.ResumeLayout(false);
            this.pnlGrilla.ResumeLayout(false);
            this.pnlGrilla.PerformLayout();
            this.pnlBotones.ResumeLayout(false);
            this.pnlPie.ResumeLayout(false);
            this.pnlPie.PerformLayout();
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlMainContainer;
        private System.Windows.Forms.Panel pnlFormulario;
        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.Panel pnlGrilla;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Panel pnlPie;
        private System.Windows.Forms.GroupBox grpDatos;

        private System.Windows.Forms.Label lblTituloForm;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblCedula;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblDepartamento;
        private System.Windows.Forms.ComboBox cmbDepartamento;
        private System.Windows.Forms.Label lblPuesto;
        private System.Windows.Forms.TextBox txtPuesto;
        private System.Windows.Forms.Label lblSalario;
        private System.Windows.Forms.TextBox txtSalario;
        private System.Windows.Forms.CheckBox chkActivo;

        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;

        private System.Windows.Forms.Label lblTituloGrilla;
        private System.Windows.Forms.Label lblBusqueda;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvEmpleados;

        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblConexion;
        private System.Windows.Forms.Label lblUsuario;
    }
}
