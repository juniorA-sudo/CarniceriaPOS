using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace CarniceriaPOS.Utilities
{
    public static class FormateadorTextBox
    {
        public enum TipoValidacion
        {
            SoloNumeros,
            SoloLetras,
            Alfanumerico,
            Cedula,
            Telefono,
            RNC,
            Moneda,
            Gmail,
            Ninguna
        }

        public static void ConfigurarTextBox(TextBox textBox, TipoValidacion tipo, int? longitudMaxima = null)
        {
            if (textBox == null) return;

            if (longitudMaxima == null)
            {
                switch (tipo)
                {
                    case TipoValidacion.SoloNumeros: longitudMaxima = 20; break;
                    case TipoValidacion.SoloLetras: longitudMaxima = 100; break;
                    case TipoValidacion.Alfanumerico: longitudMaxima = 100; break;
                    case TipoValidacion.Cedula: longitudMaxima = 13; break;
                    case TipoValidacion.Telefono: longitudMaxima = 20; break;
                    case TipoValidacion.RNC: longitudMaxima = 9; break;
                    case TipoValidacion.Moneda: longitudMaxima = 15; break;
                    case TipoValidacion.Gmail: longitudMaxima = 30; break;
                    default: longitudMaxima = 255; break;
                }
            }

            textBox.MaxLength = longitudMaxima.Value;
            textBox.Tag = tipo;

            textBox.KeyPress += (s, e) => TextBox_KeyPress(s, e, tipo);
            textBox.TextChanged += (s, e) => TextBox_TextChanged(s, e, tipo);
        }

        private static void TextBox_KeyPress(object sender, KeyPressEventArgs e, TipoValidacion tipo)
        {
            TextBox textBox = sender as TextBox;
            if (textBox == null) return;

            if (char.IsControl(e.KeyChar) || e.KeyChar == (char)22)
            {
                return;
            }

            switch (tipo)
            {
                case TipoValidacion.SoloNumeros:
                case TipoValidacion.Cedula:
                case TipoValidacion.Telefono:
                case TipoValidacion.RNC:
                case TipoValidacion.Moneda:
                    e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != '.';
                    break;

                case TipoValidacion.SoloLetras:
                    e.Handled = !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar);
                    break;

                case TipoValidacion.Alfanumerico:
                    e.Handled = !char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar);
                    break;

                case TipoValidacion.Gmail:
                    e.Handled = !(char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == '-' || e.KeyChar == '_');
                    break;
            }
        }

        private static void TextBox_TextChanged(object sender, EventArgs e, TipoValidacion tipo)
        {
            TextBox textBox = sender as TextBox;
            if (textBox == null) return;

            string textoOriginal = textBox.Text;
            int posicionCursor = textBox.SelectionStart;
            string textoFormateado = textoOriginal;

            switch (tipo)
            {
                case TipoValidacion.Cedula:
                    textoFormateado = FormatearCedula(textoOriginal);
                    break;

                case TipoValidacion.Telefono:
                    textoFormateado = FormatearTelefono(textoOriginal);
                    break;

                case TipoValidacion.RNC:
                    textoFormateado = FormatearRNC(textoOriginal);
                    break;

                case TipoValidacion.Moneda:
                    textoFormateado = FormatearMoneda(textoOriginal);
                    break;

                case TipoValidacion.SoloNumeros:
                    textoFormateado = Regex.Replace(textoOriginal, @"[^0-9]", "");
                    break;

                case TipoValidacion.SoloLetras:
                    textoFormateado = Regex.Replace(textoOriginal, @"[^a-zA-Z\s]", "");
                    break;

                case TipoValidacion.Gmail:
                    textoFormateado = FormatearGmail(textoOriginal);
                    break;
            }

            if (textoFormateado != textoOriginal)
            {
                textBox.Text = textoFormateado;

                if (posicionCursor <= textoFormateado.Length)
                    textBox.SelectionStart = posicionCursor;
                else
                    textBox.SelectionStart = textoFormateado.Length;
            }
        }

        private static string FormatearCedula(string texto)
        {
            string numeros = Regex.Replace(texto, @"[^0-9]", "");

            if (numeros.Length > 13)
                numeros = numeros.Substring(0, 13);

            if (numeros.Length <= 3)
                return numeros;
            else if (numeros.Length <= 10)
                return numeros.Substring(0, 3) + "-" + numeros.Substring(3);
            else
                return numeros.Substring(0, 3) + "-" + numeros.Substring(3, 7) + "-" + numeros.Substring(10);
        }

        private static string FormatearTelefono(string texto)
        {
            string numeros = Regex.Replace(texto, @"[^0-9]", "");

            if (numeros.Length > 10)
                numeros = numeros.Substring(0, 10);

            if (numeros.Length == 0)
                return "";
            else if (numeros.Length <= 3)
                return numeros;
            else if (numeros.Length <= 6)
                return numeros.Substring(0, 3) + "-" + numeros.Substring(3);
            else
                return numeros.Substring(0, 3) + "-" + numeros.Substring(3, 3) + "-" + numeros.Substring(6);
        }

        private static string FormatearRNC(string texto)
        {
            string numeros = Regex.Replace(texto, @"[^0-9]", "");

            if (numeros.Length > 9)
                numeros = numeros.Substring(0, 9);

            if (numeros.Length <= 3)
                return numeros;
            else
                return numeros.Substring(0, 3) + "-" + numeros.Substring(3);
        }

        private static string FormatearMoneda(string texto)
        {
            string numeros = Regex.Replace(texto, @"[^0-9.]", "");

            int indexPunto = numeros.IndexOf('.');
            if (indexPunto != -1)
            {
                numeros = numeros.Substring(0, indexPunto + 1) +
                          numeros.Substring(indexPunto + 1).Replace(".", "");
            }

            return numeros;
        }

        private static string FormatearGmail(string texto)
        {
            string usuario = texto.ToLower().Trim();

            if (usuario.EndsWith("@gmail.com"))
                return usuario;

            if (usuario.Contains("@"))
                usuario = usuario.Split('@')[0];

            usuario = Regex.Replace(usuario, @"[^a-z0-9._-]", "");

            if (!string.IsNullOrEmpty(usuario))
                return usuario + "@gmail.com";

            return usuario;
        }

        public static bool ValidarTextBox(TextBox textBox)
        {
            if (textBox == null || string.IsNullOrWhiteSpace(textBox.Text))
                return false;

            if (!(textBox.Tag is TipoValidacion tipo))
                return true;

            switch (tipo)
            {
                case TipoValidacion.Cedula:
                    return ValidarCedula(textBox.Text);
                case TipoValidacion.Telefono:
                    return ValidarTelefono(textBox.Text);
                case TipoValidacion.RNC:
                    return ValidarRNC(textBox.Text);
                case TipoValidacion.Moneda:
                    return ValidarMoneda(textBox.Text);
                case TipoValidacion.Gmail:
                    return ValidarGmail(textBox.Text);
                default:
                    return true;
            }
        }

        private static bool ValidarCedula(string cedula)
        {
            string numeros = Regex.Replace(cedula, @"[^0-9]", "");
            return numeros.Length == 13 && Regex.IsMatch(numeros, @"^\d{13}$");
        }

        private static bool ValidarTelefono(string telefono)
        {
            string numeros = Regex.Replace(telefono, @"[^0-9]", "");
            return numeros.Length == 10 && Regex.IsMatch(numeros, @"^\d{10}$");
        }

        private static bool ValidarRNC(string rnc)
        {
            string numeros = Regex.Replace(rnc, @"[^0-9]", "");
            return numeros.Length == 9 && Regex.IsMatch(numeros, @"^\d{9}$");
        }

        private static bool ValidarMoneda(string monto)
        {
            return decimal.TryParse(monto, out decimal valor) && valor >= 0;
        }

        private static bool ValidarGmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            if (!email.EndsWith("@gmail.com"))
                return false;

            string usuario = email.Replace("@gmail.com", "").ToLower();

            return Regex.IsMatch(usuario, @"^[a-z0-9._-]{1,30}$");
        }

        public static string ObtenerValorLimpio(TextBox textBox)
        {
            if (textBox == null)
                return "";

            return Regex.Replace(textBox.Text, @"[^0-9.]", "");
        }

        public static void LimpiarTextBoxes(Control contenedor)
        {
            if (contenedor == null)
                return;

            foreach (Control control in contenedor.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Clear();
                }
                else if (control.HasChildren)
                {
                    LimpiarTextBoxes(control);
                }
            }
        }

        public static void LimpiarTextBoxesEspecificos(params TextBox[] textBoxes)
        {
            foreach (TextBox txt in textBoxes)
            {
                if (txt != null)
                    txt.Clear();
            }
        }
    }
}
