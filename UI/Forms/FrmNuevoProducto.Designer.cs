namespace CarniceriaPOS.UI.Forms
{
    partial class FrmNuevoProducto
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.lblUnidad = new System.Windows.Forms.Label();
            this.cmbUnidadMedida = new System.Windows.Forms.ComboBox();
            this.lblPrecioC = new System.Windows.Forms.Label();
            this.txtPrecioCompra = new System.Windows.Forms.TextBox();
            this.lblPrecioV = new System.Windows.Forms.Label();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.lblStockAct = new System.Windows.Forms.Label();
            this.txtStockActual = new System.Windows.Forms.TextBox();
            this.lblStockMin = new System.Windows.Forms.Label();
            this.txtStockMinimo = new System.Windows.Forms.TextBox();
            this.chkItbis = new System.Windows.Forms.CheckBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 680);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "FrmNuevoProducto";
            this.Text = "Nuevo Producto";

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(40, 30);
            this.lblTitulo.Text = "Nuevo Producto";

            this.lblCodigo.Text = "Codigo de Barras";
            this.lblCodigo.Location = new System.Drawing.Point(40, 90);
            this.lblCodigo.Size = new System.Drawing.Size(150, 20);

            this.txtCodigo.Location = new System.Drawing.Point(40, 115);
            this.txtCodigo.Size = new System.Drawing.Size(520, 25);

            this.lblNombre.Text = "Nombre del Producto";
            this.lblNombre.Location = new System.Drawing.Point(40, 155);
            this.lblNombre.Size = new System.Drawing.Size(150, 20);

            this.txtNombre.Location = new System.Drawing.Point(40, 180);
            this.txtNombre.Size = new System.Drawing.Size(520, 25);

            this.lblDesc.Text = "Descripcion";
            this.lblDesc.Location = new System.Drawing.Point(40, 220);
            this.lblDesc.Size = new System.Drawing.Size(150, 20);

            this.txtDescripcion.Location = new System.Drawing.Point(40, 245);
            this.txtDescripcion.Size = new System.Drawing.Size(520, 25);

            this.lblCategoria.Text = "Categoria";
            this.lblCategoria.Location = new System.Drawing.Point(40, 285);
            this.lblCategoria.Size = new System.Drawing.Size(100, 20);

            this.cmbCategoria.Location = new System.Drawing.Point(40, 310);
            this.cmbCategoria.Size = new System.Drawing.Size(250, 25);
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblUnidad.Text = "Unidad Medida";
            this.lblUnidad.Location = new System.Drawing.Point(310, 285);
            this.lblUnidad.Size = new System.Drawing.Size(100, 20);

            this.cmbUnidadMedida.Location = new System.Drawing.Point(310, 310);
            this.cmbUnidadMedida.Size = new System.Drawing.Size(250, 25);
            this.cmbUnidadMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblPrecioC.Text = "Precio Compra";
            this.lblPrecioC.Location = new System.Drawing.Point(40, 350);
            this.lblPrecioC.Size = new System.Drawing.Size(100, 20);

            this.txtPrecioCompra.Location = new System.Drawing.Point(40, 375);
            this.txtPrecioCompra.Size = new System.Drawing.Size(250, 25);

            this.lblPrecioV.Text = "Precio Venta";
            this.lblPrecioV.Location = new System.Drawing.Point(310, 350);
            this.lblPrecioV.Size = new System.Drawing.Size(100, 20);

            this.txtPrecioVenta.Location = new System.Drawing.Point(310, 375);
            this.txtPrecioVenta.Size = new System.Drawing.Size(250, 25);

            this.lblStockAct.Text = "Stock Actual";
            this.lblStockAct.Location = new System.Drawing.Point(40, 415);
            this.lblStockAct.Size = new System.Drawing.Size(100, 20);

            this.txtStockActual.Location = new System.Drawing.Point(40, 440);
            this.txtStockActual.Size = new System.Drawing.Size(250, 25);

            this.lblStockMin.Text = "Stock Minimo";
            this.lblStockMin.Location = new System.Drawing.Point(310, 415);
            this.lblStockMin.Size = new System.Drawing.Size(100, 20);

            this.txtStockMinimo.Location = new System.Drawing.Point(310, 440);
            this.txtStockMinimo.Size = new System.Drawing.Size(250, 25);

            this.chkItbis.Text = "Aplica ITBIS";
            this.chkItbis.Location = new System.Drawing.Point(40, 480);
            this.chkItbis.Size = new System.Drawing.Size(150, 25);

            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(40, 560);
            this.btnGuardar.Size = new System.Drawing.Size(250, 45);
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(310, 560);
            this.btnCancelar.Size = new System.Drawing.Size(250, 45);
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.lblUnidad);
            this.Controls.Add(this.cmbUnidadMedida);
            this.Controls.Add(this.lblPrecioC);
            this.Controls.Add(this.txtPrecioCompra);
            this.Controls.Add(this.lblPrecioV);
            this.Controls.Add(this.txtPrecioVenta);
            this.Controls.Add(this.lblStockAct);
            this.Controls.Add(this.txtStockActual);
            this.Controls.Add(this.lblStockMin);
            this.Controls.Add(this.txtStockMinimo);
            this.Controls.Add(this.chkItbis);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label lblUnidad;
        private System.Windows.Forms.ComboBox cmbUnidadMedida;
        private System.Windows.Forms.Label lblPrecioC;
        private System.Windows.Forms.TextBox txtPrecioCompra;
        private System.Windows.Forms.Label lblPrecioV;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.Label lblStockAct;
        private System.Windows.Forms.TextBox txtStockActual;
        private System.Windows.Forms.Label lblStockMin;
        private System.Windows.Forms.TextBox txtStockMinimo;
        private System.Windows.Forms.CheckBox chkItbis;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}