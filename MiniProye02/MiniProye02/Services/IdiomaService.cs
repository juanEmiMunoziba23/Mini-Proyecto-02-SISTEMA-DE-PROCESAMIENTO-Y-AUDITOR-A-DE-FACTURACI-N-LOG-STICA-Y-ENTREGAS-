using System.Text.Json;

namespace MiniProye02.Services;

/// <summary>Carga diccionarios de traducción desde archivos JSON.</summary>
public class IdiomaService
{
    /// <summary>Lee las traducciones del archivo JSON indicado.</summary>
    /// <param name="ruta">Ruta al archivo de traducciones.</param>
    /// <returns>Diccionario con las claves y textos traducidos.</returns>
    public Dictionary<string, string> CargarIdioma(string ruta)
    {
        if (!File.Exists(ruta))
            throw new FileNotFoundException("No se encontró el archivo de idioma.", ruta);

        string json = File.ReadAllText(ruta);
        return JsonSerializer.Deserialize<Dictionary<string, string>>(json)
            ?? throw new InvalidDataException("El archivo de idioma está vacío o no es válido.");
    }
}
