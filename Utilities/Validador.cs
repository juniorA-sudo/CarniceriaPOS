using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CarniceriaPOS.Utilities
{
    public class Validador
    {

        public static void ConfigurarMaxLengthFormulario(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is TextBox txt)
                {
                    string nombreControl = control.Name.ToLower();

                    if (nombreControl.Contains("busqueda")) txt.MaxLength = 50;

                    else if (nombreControl.Contains("nombre")) txt.MaxLength = 50;

                    else if (nombreControl.Contains("descripcion")) txt.MaxLength = 150;

                    else if (nombreControl.Contains("precio")) txt.MaxLength = 15;

                    else if (nombreControl.Contains("stock") || nombreControl.Contains("cantidad")) txt.MaxLength = 10;

                    else if (nombreControl.Contains("email")) txt.MaxLength = 80;

                    else if (nombreControl.Contains("telefono")) txt.MaxLength = 20;

                    else if (nombreControl.Contains("nit") || nombreControl.Contains("rnc") || nombreControl.Contains("dni")) txt.MaxLength = 20;

                    else if (nombreControl.Contains("direccion")) txt.MaxLength = 100;

                    else if (nombreControl.Contains("password") || nombreControl.Contains("contrasena")) txt.MaxLength = 40;

                    else if (nombreControl.Contains("credito") || nombreControl.Contains("monto")) txt.MaxLength = 15;

                    else if (nombreControl.Contains("observacion") || nombreControl.Contains("nota") || nombreControl.Contains("comentario")) txt.MaxLength = 300;
                }

                if (control.HasChildren)
                {
                    ConfigurarMaxLengthFormulario(control.Controls);
                }
            }
        }

        public static bool ValidarSoloLetras(string texto)
        {
            if (string.IsNullOrEmpty(texto)) return true;
            return Regex.IsMatch(texto, @"^[a-zaeiounA-ZAEIOUN\s\-\'\.]+$");
        }

        public static bool ValidarSoloNumeros(string texto)
        {
            if (string.IsNullOrEmpty(texto)) return true;
            return Regex.IsMatch(texto, @"^\d+$");
        }

        public static bool ValidarSoloNumerosDecimales(string texto)
        {
            if (string.IsNullOrEmpty(texto)) return true;
            return Regex.IsMatch(texto, @"^[\d\.]+$");
        }

        public static string LimpiarALetras(string texto)
        {
            if (string.IsNullOrEmpty(texto)) return "";
            return Regex.Replace(texto, @"[^a-zaeiounA-ZAEIOUN\s\-\'\.]+", "");
        }

        public static string LimpiarANumeros(string texto)
        {
            if (string.IsNullOrEmpty(texto)) return "";
            return Regex.Replace(texto, @"[^\d]", "");
        }

        public static string LimpiarANumerosDecimales(string texto)
        {
            if (string.IsNullOrEmpty(texto)) return "";
            return Regex.Replace(texto, @"[^\d\.]", "");
        }

        public static bool ValidarEmailGmailObligatorio(string email)
        {
            if (string.IsNullOrEmpty(email)) return false; 

            if (!email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool ValidarEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool ValidarTelefonoRepublicaDominicana(string telefono)
        {
            if (string.IsNullOrEmpty(telefono)) return true;

            string telefonoLimpio = Regex.Replace(telefono, @"[\s\-\(\)]", "");

            if (telefonoLimpio.Length != 10) return false;

            return Regex.IsMatch(telefonoLimpio, @"^(809|829|849)\d{7}$");
        }

        public static bool ValidarTelefono(string telefono)
        {
            if (string.IsNullOrEmpty(telefono)) return true;
            return Regex.IsMatch(telefono, @"^\d{7,20}$");
        }

        public static bool ValidarNIT(string nit)
        {
            if (string.IsNullOrEmpty(nit)) return true;
            return Regex.IsMatch(nit, @"^\d{6,20}$");
        }

        public static bool ValidarCampoObligatorio(string valor)
        {
            return !string.IsNullOrWhiteSpace(valor);
        }

        public static bool ValidarPrecioPositivo(decimal precio)
        {
            return precio > 0;
        }

        public static bool ValidarStockValido(int stock)
        {
            return stock >= 0;
        }

        public static bool ValidarPasswordSegura(string password)
        {
            if (string.IsNullOrEmpty(password)) return false;
            return password.Length >= 8;
        }

        public static bool ValidarRangoFechas(DateTime inicio, DateTime fin)
        {
            return inicio <= fin;
        }

        public static string FormatearTelefonoRD(string telefono)
        {
            if (string.IsNullOrEmpty(telefono)) return "";

            string limpio = System.Text.RegularExpressions.Regex.Replace(telefono, @"[\s\-\(\)]", "");

            if (limpio.Length > 10)
            {
                limpio = limpio.Substring(0, 10);
            }

            limpio = System.Text.RegularExpressions.Regex.Replace(limpio, @"[^\d]", "");

            if (limpio.Length == 10)
            {
                return $"{limpio.Substring(0, 3)}-{limpio.Substring(3, 3)}-{limpio.Substring(6)}";
            }
            
            else if (limpio.Length > 0)
            {
                if (limpio.Length <= 3)
                    return limpio;
                else if (limpio.Length <= 6)
                    return $"{limpio.Substring(0, 3)}-{limpio.Substring(3)}";
                else
                    return $"{limpio.Substring(0, 3)}-{limpio.Substring(3, 3)}-{limpio.Substring(6)}";
            }

            return limpio;
        }

        public static string FormatearRNC(string rnc)
        {
            if (string.IsNullOrEmpty(rnc)) return "";

            string limpio = System.Text.RegularExpressions.Regex.Replace(rnc, @"[\s\-]", "");

            if (limpio.Length > 11)
            {
                limpio = limpio.Substring(0, 11);
            }

            limpio = System.Text.RegularExpressions.Regex.Replace(limpio, @"[^\d]", "");

            if (limpio.Length == 11)
            {
                return $"{limpio.Substring(0, 3)}-{limpio.Substring(3, 6)}-{limpio.Substring(9)}";
            }
            
            else if (limpio.Length == 9)
            {
                return $"{limpio.Substring(0, 3)}-{limpio.Substring(3)}";
            }
            
            else if (limpio.Length > 0)
            {
                if (limpio.Length <= 3)
                    return limpio;
                else if (limpio.Length <= 9)
                    return $"{limpio.Substring(0, 3)}-{limpio.Substring(3)}";
                else
                    return $"{limpio.Substring(0, 3)}-{limpio.Substring(3, 6)}-{limpio.Substring(9)}";
            }

            return limpio;
        }

        public static void ConfigurarFormateoTelefono(TextBox txtTelefono)
        {
            if (txtTelefono == null) return;

            txtTelefono.TextChanged += (s, e) =>
            {
                int cursorPos = txtTelefono.SelectionStart;
                string original = txtTelefono.Text;
                string formateado = FormatearTelefonoRD(original);

                if (original != formateado)
                {
                    txtTelefono.Text = formateado;
                    
                    txtTelefono.SelectionStart = Math.Min(cursorPos + 1, formateado.Length);
                }
            };
        }

        public static void ConfigurarFormateoRNC(TextBox txtRNC)
        {
            if (txtRNC == null) return;

            txtRNC.TextChanged += (s, e) =>
            {
                int cursorPos = txtRNC.SelectionStart;
                string original = txtRNC.Text;
                string formateado = FormatearRNC(original);

                if (original != formateado)
                {
                    txtRNC.Text = formateado;

                    txtRNC.SelectionStart = Math.Min(cursorPos + 1, formateado.Length);
                }
            };
        }

        public static string FormatearCedula(string cedula)
        {
            if (string.IsNullOrEmpty(cedula)) return "";

            string limpio = System.Text.RegularExpressions.Regex.Replace(cedula, @"[\s\-]", "");

            if (limpio.Length > 11)
            {
                limpio = limpio.Substring(0, 11);
            }

            limpio = System.Text.RegularExpressions.Regex.Replace(limpio, @"[^\d]", "");

            if (limpio.Length == 11)
            {
                return $"{limpio.Substring(0, 3)}-{limpio.Substring(3, 7)}-{limpio.Substring(10)}";
            }
            else if (limpio.Length > 0)
            {
                if (limpio.Length <= 3)
                    return limpio;
                else if (limpio.Length <= 10)
                    return $"{limpio.Substring(0, 3)}-{limpio.Substring(3)}";
                else
                    return $"{limpio.Substring(0, 3)}-{limpio.Substring(3, 7)}-{limpio.Substring(10)}";
            }

            return limpio;
        }

        public static void ConfigurarFormatearCedula(TextBox txtCedula)
        {
            if (txtCedula == null) return;

            txtCedula.TextChanged += (s, e) =>
            {
                int cursorPos = txtCedula.SelectionStart;
                string original = txtCedula.Text;
                string formateado = FormatearCedula(original);

                if (original != formateado)
                {
                    txtCedula.Text = formateado;

                    txtCedula.SelectionStart = Math.Min(cursorPos + 1, formateado.Length);
                }
            };
        }
    }
}
