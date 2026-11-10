using System.Text.Json;
using MiniProye02.Models;

namespace MiniProye02.Services;

/// <summary>Carga la configuración de facturación desde JSON.</summary>
public class ConfiguracionService
{
    /// <summary>Lee y deserializa la configuración indicada.</summary>
    /// <param name="ruta">Ruta al archivo appsettings.json.</param>
    /// <returns>Configuración deserializada.</returns>
    /// <exception cref="FileNotFoundException">El archivo no existe.</exception>
    public Configuracion CargarConfiguracion(string ruta)
    {
        if (!File.Exists(ruta))
            throw new FileNotFoundException("No se encontró el archivo de configuración.", ruta);

        string json = File.ReadAllText(ruta);
        return JsonSerializer.Deserialize<Configuracion>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        }) ?? throw new InvalidDataException("El archivo de configuración está vacío o no es válido.");
    }
}
