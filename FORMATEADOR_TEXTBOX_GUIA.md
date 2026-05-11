# Guia de Uso - FormateadorTextBox

## Descripcion
`FormateadorTextBox` es una clase utilitaria que maneja automaticamente:
- **Formateo**: Agrega guiones automaticamente (cedula, telefono, RNC)
- **Validacion**: Solo permite caracteres validos segun el tipo
- **Restriccion de entrada**: Previene caracteres invalidos mientras escribes

## Tipos de Validacion Disponibles

### 1. SoloNumeros
Solo permite digitos (0-9)
```csharp
FormateadorTextBox.ConfigurarTextBox(txtNumeros, FormateadorTextBox.TipoValidacion.SoloNumeros);
```
- Ejemplo: `123456`

### 2. SoloLetras
Solo permite letras y espacios
```csharp
FormateadorTextBox.ConfigurarTextBox(txtNombre, FormateadorTextBox.TipoValidacion.SoloLetras, 100);
```
- Ejemplo: `Juan Perez`

### 3. Alfanumerico
Permite letras, numeros y espacios
```csharp
FormateadorTextBox.ConfigurarTextBox(txtPuesto, FormateadorTextBox.TipoValidacion.Alfanumerico, 100);
```
- Ejemplo: `Gerente General 2`

### 4. Cedula ⭐ (Formatea automaticamente)
Formato: XXX-XXXXXXX-X (13 digitos con guiones)
```csharp
FormateadorTextBox.ConfigurarTextBox(txtCedula, FormateadorTextBox.TipoValidacion.Cedula);
```
- Usuario escribe: `00123456789012`
- Se formatea a: `001-2345678-9012`
- Longitud maxima: 13 digitos

### 5. Telefono ⭐ (Formatea automaticamente)
Formato: +503-XXXX-XXXX (8 digitos con formato salvadoreno)
```csharp
FormateadorTextBox.ConfigurarTextBox(txtTelefono, FormateadorTextBox.TipoValidacion.Telefono);
```
- Usuario escribe: `12345678`
- Se formatea a: `+503-1234-5678`
- Longitud maxima: 8 digitos

### 6. RNC ⭐ (Formatea automaticamente)
Formato: XXX-XXXXXXX (9 digitos con guion)
```csharp
FormateadorTextBox.ConfigurarTextBox(txtRNC, FormateadorTextBox.TipoValidacion.RNC);
```
- Usuario escribe: `123456789`
- Se formatea a: `123-456789`
- Longitud maxima: 9 digitos

### 7. Moneda
Permite digitos y punto decimal
```csharp
FormateadorTextBox.ConfigurarTextBox(txtSalario, FormateadorTextBox.TipoValidacion.Moneda, 15);
```
- Ejemplo: `2500.50`
- Solo un punto decimal permitido

### 8. Ninguna
Sin validacion (por defecto)
```csharp
FormateadorTextBox.ConfigurarTextBox(txtLibre, FormateadorTextBox.TipoValidacion.Ninguna);
```

## Como Usar en un Formulario

### En el evento Load del formulario:
```csharp
private void MiFormulario_Load(object sender, EventArgs e)
{
    // Configurar validaciones para los TextBox
    FormateadorTextBox.ConfigurarTextBox(txtCedula, FormateadorTextBox.TipoValidacion.Cedula);
    FormateadorTextBox.ConfigurarTextBox(txtNombre, FormateadorTextBox.TipoValidacion.SoloLetras, 100);
    FormateadorTextBox.ConfigurarTextBox(txtTelefono, FormateadorTextBox.TipoValidacion.Telefono);
    FormateadorTextBox.ConfigurarTextBox(txtSalario, FormateadorTextBox.TipoValidacion.Moneda, 15);
}
```

## Funciones Utilitarias

### Validar un TextBox
```csharp
if (FormateadorTextBox.ValidarTextBox(txtCedula))
{
    MessageBox.Show("Cedula valida!");
}
```

### Obtener valor limpio (sin formato)
```csharp
string cedulaLimpia = FormateadorTextBox.ObtenerValorLimpio(txtCedula);
// Si usuario escribio: "001-2345678-9012"
// Retorna: "00123456789012"
```

## Ejemplos Reales

### Ejemplo 1: Formulario de Clientes
```csharp
private void ConfigurarValidaciones()
{
    FormateadorTextBox.ConfigurarTextBox(txtCedula, FormateadorTextBox.TipoValidacion.Cedula);
    FormateadorTextBox.ConfigurarTextBox(txtNombre, FormateadorTextBox.TipoValidacion.SoloLetras, 100);
    FormateadorTextBox.ConfigurarTextBox(txtTelefono, FormateadorTextBox.TipoValidacion.Telefono);
    FormateadorTextBox.ConfigurarTextBox(txtLimiteCredito, FormateadorTextBox.TipoValidacion.Moneda, 15);
}

private void btnGuardar_Click(object sender, EventArgs e)
{
    // Validar campos obligatorios
    if (!FormateadorTextBox.ValidarTextBox(txtCedula))
    {
        MessageBox.Show("Ingrese una cedula valida");
        return;
    }
    
    // Usar valores limpios para guardar en BD
    cliente.Cedula = FormateadorTextBox.ObtenerValorLimpio(txtCedula);
    cliente.Nombre = txtNombre.Text;
    cliente.Telefono = FormateadorTextBox.ObtenerValorLimpio(txtTelefono);
    
    // Guardar...
}
```

### Ejemplo 2: Formulario de Proveedores
```csharp
private void FrmProveedores_Load(object sender, EventArgs e)
{
    FormateadorTextBox.ConfigurarTextBox(txtRNC, FormateadorTextBox.TipoValidacion.RNC);
    FormateadorTextBox.ConfigurarTextBox(txtNombre, FormateadorTextBox.TipoValidacion.SoloLetras, 100);
    FormateadorTextBox.ConfigurarTextBox(txtTelefono, FormateadorTextBox.TipoValidacion.Telefono);
}
```

## Ventajas

✓ **Formateo Automatico**: El usuario no necesita escribir los guiones
✓ **Validacion en Tiempo Real**: Los caracteres invalidos se rechaza mientras se escriben
✓ **Consistencia**: Todos los campos se formatean igual en toda la aplicacion
✓ **Facil Mantenimiento**: Un solo lugar para cambiar las reglas
✓ **Sin Codigo Repetido**: No necesitas escribir KeyPress y TextChanged en cada formulario

## Notas Importantes

- La clase maneja automaticamente los eventos KeyPress y TextChanged
- No necesitas agregar handlers adicionales una vez configurado
- El MaxLength se establece automaticamente segun el tipo
- Puedes personalizar el MaxLength pasando un parametro opcional
- Siempre usa `ObtenerValorLimpio()` antes de guardar en base de datos
