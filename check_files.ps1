$files = @(
    "Utilities\FormateadorTextBox.cs",
    "UI\Forms\FormBase.cs",
    "UI\Forms\FrmBuscadorClienteCedula.cs",
    "UI\Forms\FrmBuscadorClienteCedula.Designer.cs"
)

foreach ($file in $files) {
    $fullPath = Join-Path $PSScriptRoot $file
    if (Test-Path $fullPath) {
        Write-Host "✓ $file" -ForegroundColor Green
    } else {
        Write-Host "✗ $file NOT FOUND" -ForegroundColor Red
    }
}
