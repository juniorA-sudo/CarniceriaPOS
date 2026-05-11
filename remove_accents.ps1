# Script para remover acentos de todos los archivos

$extensions = @("*.cs", "*.sql", "*.xml", "*.config", "*.resx")
$replacements = @{
    'á' = 'a'
    'é' = 'e'
    'í' = 'i'
    'ó' = 'o'
    'ú' = 'u'
    'ü' = 'u'
    'ñ' = 'n'
    'Á' = 'A'
    'É' = 'E'
    'Í' = 'I'
    'Ó' = 'O'
    'Ú' = 'U'
    'Ü' = 'U'
    'Ñ' = 'N'
}

$files = Get-ChildItem -Path "C:\Users\grego\source\repos\CarniceriaPOS\CarniceriaPOS" -Recurse -Include $extensions -Exclude @("*.Designer.cs")

foreach ($file in $files) {
    $content = Get-Content $file.FullName -Raw -Encoding UTF8
    $originalContent = $content
    
    foreach ($acento in $replacements.GetEnumerator()) {
        $content = $content -replace [regex]::Escape($acento.Key), $acento.Value
    }
    
    if ($content -ne $originalContent) {
        Set-Content -Path $file.FullName -Value $content -Encoding UTF8 -Force
        Write-Host "Procesado: $($file.Name)"
    }
}

Write-Host "Completado"
