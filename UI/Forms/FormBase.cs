using System;
using System.Windows.Forms;

namespace CarniceriaPOS.UI.Forms
{
    public partial class FormBase : Form
    {
        protected virtual void ActualizarPie()
        {
            try
            {
                if (this.Controls.Count > 0)
                {
                    var label = this.Controls.Find("lblTotal", true);
                    if (label.Length > 0 && label[0] is Label lblTotal)
                    {
                        lblTotal.Text = "Total: 0";
                    }
                }
            }
            catch { }
        }

        protected virtual void HabilitarDeshabilitarBotones(bool habilitar)
        {
            try
            {
                if (this.Controls.Count > 0)
                {
                    var btnGuardar = this.Controls.Find("btnGuardar", true);
                    var btnCancelar = this.Controls.Find("btnCancelar", true);
                    var btnNuevo = this.Controls.Find("btnNuevo", true);
                    var btnEditar = this.Controls.Find("btnEditar", true);
                    var btnEliminar = this.Controls.Find("btnEliminar", true);

                    if (btnGuardar.Length > 0) btnGuardar[0].Enabled = habilitar;
                    if (btnCancelar.Length > 0) btnCancelar[0].Enabled = habilitar;
                    if (btnNuevo.Length > 0) btnNuevo[0].Enabled = !habilitar;
                    if (btnEditar.Length > 0) btnEditar[0].Enabled = !habilitar;
                    if (btnEliminar.Length > 0) btnEliminar[0].Enabled = !habilitar;
                }
            }
            catch { }
        }

        protected virtual void LimpiarCampos()
        {
            try
            {
                foreach (Control control in this.Controls)
                {
                    if (control is TextBox txt)
                        txt.Clear();
                    else if (control is ComboBox cmb)
                        cmb.SelectedIndex = -1;
                    else if (control is CheckBox chk)
                        chk.Checked = false;
                }
            }
            catch { }
        }
    }
}
