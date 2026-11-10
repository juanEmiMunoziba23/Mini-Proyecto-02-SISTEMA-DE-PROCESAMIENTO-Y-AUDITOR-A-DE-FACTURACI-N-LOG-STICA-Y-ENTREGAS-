using System.Globalization;
using System.Text;
using MiniProye02.Models;

namespace MiniProye02.Services;

/// <summary>Exporta paquetes facturados a un archivo CSV.</summary>
public class CsvService
{
    /// <summary>Escribe el encabezado y el detalle de cada paquete.</summary>
    /// <param name="ruta">Ruta del archivo CSV que se creará.</param>
    /// <param name="paquetes">Paquetes a exportar.</param>
    public void Exportar(string ruta, Paquete[] paquetes)
    {
        using var escritor = new StreamWriter(ruta, false, new UTF8Encoding(true));
        escritor.WriteLine("Codigo,Cliente,Zona,Peso,ValorDeclarado,SubtotalPeso,RecargoZona,PenalizacionPeso,Seguro,Impuesto,Total");
        foreach (Paquete p in paquetes)
        {
            string[] valores =
            {
                p.Codigo, p.Cliente, p.Zona,
                p.Peso.ToString(CultureInfo.InvariantCulture),
                p.ValorDeclarado.ToString(CultureInfo.InvariantCulture),
                p.SubtotalPeso.ToString(CultureInfo.InvariantCulture),
                p.RecargoZona.ToString(CultureInfo.InvariantCulture),
                p.PenalizacionPeso.ToString(CultureInfo.InvariantCulture),
                p.Seguro.ToString(CultureInfo.InvariantCulture),
                p.Impuesto.ToString(CultureInfo.InvariantCulture),
                p.Total.ToString(CultureInfo.InvariantCulture)
            };
            escritor.WriteLine(string.Join(",", valores.Select(Escapar)));
        }
    }

    private static string Escapar(string valor) =>
        valor.IndexOfAny(new[] { ',', '"', '\r', '\n' }) >= 0
            ? $"\"{valor.Replace("\"", "\"\"")}\""
            : valor;
}
