using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace CarniceriaPOS.Utilities
{
    /// <summary>
    /// Clase para manejar formateo y validacion de TextBox
    /// </summary>
    public static class FormateadorTextBox
    {
        // Tipos de validacion
        public enum TipoValidacion
        {
            SoloNumeros,
            SoloLetras,
            Alfanumerico,
            Cedula,           // 13 numeros con formato XXX-XXXXXXX-X
            Telefono,         // Formato +1-XXX-XXX-XXXX dominicano
            RNC,              // 9 numeros con formato XXX-XXXXXXX
            Moneda,           // Numeros con decimales
            Gmail,            // Usuario@gmail.com (usuario solo escribe la parte antes del @)
            Ninguna
        }

        /// <summary>
        /// Configura un TextBox con validacion automatica
        /// </summary>
        public static void ConfigurarTextBox(TextBox textBox, TipoValidacion tipo, int? longitudMaxima = null)
        {
            if (textBox == null) return;

            // Establecer longitud maxima por defecto segun el tipo
            if (longitudMaxima == null)
            {
                longitudMaxima = tipo switch
                {
                    TipoValidacion.SoloNumeros => 20,
                    TipoValidacion.SoloLetras => 100,
                    TipoValidacion.Alfanumerico => 100,
                    TipoValidacion.Cedula => 13,
                    TipoValidacion.Telefono => 15,
                    TipoValidacion.RNC => 9,
                    TipoValidacion.Moneda => 15,
                    TipoValidacion.Gmail => 30,
                    _ => 255
                };
            }

            textBox.MaxLength = longitudMaxima.Value;

            // Limpiar eventos previos
            textBox.KeyPress -= TextBox_KeyPress;
            textBox.TextChanged -= TextBox_TextChanged;

            // Agregar eventos
            textBox.KeyPress += (s, e) => TextBox_KeyPress(s, e, tipo);
            textBox.TextChanged += (s, e) => TextBox_TextChanged(s, e, tipo);

            // Guardar el tipo de validacion como tag
            textBox.Tag = tipo;
        }

        /// <summary>
        /// Valida los caracteres mientras se escriben
        /// </summary>
        private static void TextBox_KeyPress(object sender, KeyPressEventArgs e, TipoValidacion tipo)
        {
            TextBox textBox = sender as TextBox;
            if (textBox == null) return;

            // Permitir teclas especiales (Backspace, Delete, Tab, etc.)
            if (char.IsControl(e.KeyChar) || e.KeyChar == (char)22) // Ctrl+V
            {
                return;
            }

            // Validar segun el tipo
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
                    // Permitir letras, numeros, puntos, guiones y guiones bajos
                    e.Handled = !(char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == '-' || e.KeyChar == '_');
                    break;
            }
        }

        /// <summary>
        /// Formatea automaticamente el texto segun el tipo
        /// </summary>
        private static void TextBox_TextChanged(object sender, EventArgs e, TipoValidacion tipo)
        {
            TextBox textBox = sender as TextBox;
            if (textBox == null) return;

            string textoOriginal = textBox.Text;
            int posicionCursor = textBox.SelectionStart;
            string textoFormateado = textoOriginal;

            // Aplicar formateo segun el tipo
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

            // Si cambio, actualizar el textbox
            if (textoFormateado != textoOriginal)
            {
                textBox.Text = textoFormateado;
                // Restaurar posicion del cursor
                if (posicionCursor <= textoFormateado.Length)
                    textBox.SelectionStart = posicionCursor;
                else
                    textBox.SelectionStart = textoFormateado.Length;
            }
        }

        /// <summary>
        /// Formatea cedula como XXX-XXXXXXX-X
        /// </summary>
        private static string FormatearCedula(string texto)
        {
            // Remover caracteres no numericos
            string numeros = Regex.Replace(texto, @"[^0-9]", "");

            // Limitar a 13 digitos
            if (numeros.Length > 13)
                numeros = numeros.Substring(0, 13);

            // Aplicar formato
            if (numeros.Length <= 3)
                return numeros;
            else if (numeros.Length <= 10)
                return numeros.Substring(0, 3) + "-" + numeros.Substring(3);
            else
                return numeros.Substring(0, 3) + "-" + numeros.Substring(3, 7) + "-" + numeros.Substring(10);
        }

        /// <summary>
        /// Formatea telefono dominicano como +1-XXX-XXX-XXXX
        /// </summary>
        private static string FormatearTelefono(string texto)
        {
            // Remover caracteres no numericos
            string numeros = Regex.Replace(texto, @"[^0-9]", "");

            // Limitar a 10 digitos (formato dominicano)
            if (numeros.Length > 10)
                numeros = numeros.Substring(0, 10);

            // Aplicar formato +1-XXX-XXX-XXXX
            if (numeros.Length <= 3)
                return "+1-" + numeros;
            else if (numeros.Length <= 6)
                return "+1-" + numeros.Substring(0, 3) + "-" + numeros.Substring(3);
            else
                return "+1-" + numeros.Substring(0, 3) + "-" + numeros.Substring(3, 3) + "-" + numeros.Substring(6);
        }

        /// <summary>
        /// Formatea RNC como XXX-XXXXXXX
        /// </summary>
        private static string FormatearRNC(string texto)
        {
            // Remover caracteres no numericos
            string numeros = Regex.Replace(texto, @"[^0-9]", "");

            // Limitar a 9 digitos
            if (numeros.Length > 9)
                numeros = numeros.Substring(0, 9);

            // Aplicar formato
            if (numeros.Length <= 3)
                return numeros;
            else
                return numeros.Substring(0, 3) + "-" + numeros.Substring(3);
        }

        /// <summary>
        /// Formatea moneda permitiendo decimales
        /// </summary>
        private static string FormatearMoneda(string texto)
        {
            // Permitir numeros y punto decimal
            string numeros = Regex.Replace(texto, @"[^0-9.]", "");

            // No permitir multiples puntos
            int indexPunto = numeros.IndexOf('.');
            if (indexPunto != -1)
            {
                numeros = numeros.Substring(0, indexPunto + 1) +
                          numeros.Substring(indexPunto + 1).Replace(".", "");
            }

            return numeros;
        }

        /// <summary>
        /// Formatea Gmail agregando automaticamente @gmail.com
        /// </summary>
        private static string FormatearGmail(string texto)
        {
            // Remover espacios y convertir a minusculas
            string usuario = texto.ToLower().Trim();

            // Si ya contiene @gmail.com, devolverlo tal cual
            if (usuario.EndsWith("@gmail.com"))
                return usuario;

            // Si contiene @, removerlo
            if (usuario.Contains("@"))
                usuario = usuario.Split('@')[0];

            // Limitar a caracteres validos para gmail (letras, numeros, punto, guion, guion bajo)
            usuario = Regex.Replace(usuario, @"[^a-z0-9._-]", "");

            // Agregar @gmail.com
            if (!string.IsNullOrEmpty(usuario))
                return usuario + "@gmail.com";

            return usuario;
        }

        /// <summary>
        /// Valida un textbox y retorna si es valido
        /// </summary>
        public static bool ValidarTextBox(TextBox textBox)
        {
            if (textBox == null || string.IsNullOrWhiteSpace(textBox.Text))
                return false;

            if (!(textBox.Tag is TipoValidacion tipo))
                return true;

            return tipo switch
            {
                TipoValidacion.Cedula => ValidarCedula(textBox.Text),
                TipoValidacion.Telefono => ValidarTelefono(textBox.Text),
                TipoValidacion.RNC => ValidarRNC(textBox.Text),
                TipoValidacion.Moneda => ValidarMoneda(textBox.Text),
                TipoValidacion.Gmail => ValidarGmail(textBox.Text),
                _ => true
            };
        }

        private static bool ValidarCedula(string cedula)
        {
            // Remover guiones
            string numeros = Regex.Replace(cedula, @"[^0-9]", "");
            return numeros.Length == 13 && Regex.IsMatch(numeros, @"^\d{13}$");
        }

        private static bool ValidarTelefono(string telefono)
        {
            // Remover caracteres especiales
            string numeros = Regex.Replace(telefono, @"[^0-9]", "");
            return numeros.Length == 10 && Regex.IsMatch(numeros, @"^\d{10}$");
        }

        private static bool ValidarRNC(string rnc)
        {
            // Remover guiones
            string numeros = Regex.Replace(rnc, @"[^0-9]", "");
            return numeros.Length == 9 && Regex.IsMatch(numeros, @"^\d{9}$");
        }

        private static bool ValidarMoneda(string monto)
        {
            return decimal.TryParse(monto, out decimal valor) && valor >= 0;
        }

        private static bool ValidarGmail(string email)
        {
            // Validar que sea un email de gmail valido
            if (string.IsNullOrWhiteSpace(email))
                return false;

            // Debe terminar con @gmail.com
            if (!email.EndsWith("@gmail.com"))
                return false;

            // La parte del usuario (antes del @) debe tener al menos 1 caracter
            string usuario = email.Replace("@gmail.com", "").ToLower();

            // Validar formato valido de usuario gmail (letras, numeros, puntos, guiones, guiones bajos)
            return Regex.IsMatch(usuario, @"^[a-z0-9._-]{1,30}$");
        }

        /// <summary>
        /// Obtiene el valor limpio (sin formato) del textbox
        /// </summary>
        public static string ObtenerValorLimpio(TextBox textBox)
        {
            if (textBox == null)
                return "";

            return Regex.Replace(textBox.Text, @"[^0-9.]", "");
        }
    }
}
