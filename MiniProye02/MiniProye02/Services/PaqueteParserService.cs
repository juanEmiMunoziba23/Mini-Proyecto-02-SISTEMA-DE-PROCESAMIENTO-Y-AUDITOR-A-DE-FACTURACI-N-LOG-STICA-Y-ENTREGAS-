using System.Globalization;
using MiniProye02.Models;

namespace MiniProye02.Services;

/// <summary>Contiene los paquetes válidos y los errores encontrados en un lote.</summary>
public class ResultadoParseo
{
    /// <summary>Paquetes que superaron las validaciones.</summary>
    public List<Paquete> PaquetesValidos { get; } = new();
    /// <summary>Errores asociados a las líneas rechazadas.</summary>
    public List<string> Errores { get; } = new();
}

/// <summary>Valida y convierte las líneas de un lote de facturación.</summary>
public class PaqueteParserService
{
    /// <summary>Parsea cada línea de forma independiente y acumula sus errores.</summary>
    /// <param name="textoLote">Texto con registros separados por saltos de línea.</param>
    /// <returns>Resultado con paquetes válidos y errores por línea.</returns>
    public ResultadoParseo ParsearLote(string textoLote)
    {
        var resultado = new ResultadoParseo();
        string[] lineas = textoLote.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.None);

        for (int i = 0; i < lineas.Length; i++)
        {
            string linea = lineas[i].Trim();
            if (linea.Length == 0)
                continue;

            try
            {
                string[] campos = linea.Split(';');
                if (campos.Length != 5)
                    throw new FormatException("Se esperaban exactamente 5 campos separados por ';'.");

                string codigo = campos[0].Trim().ToUpperInvariant();
                string cliente = campos[1].Trim();
                string zona = campos[2].Trim().ToUpperInvariant();
                if (codigo.Length == 0)
                    throw new FormatException("El código no puede estar vacío.");
                if (cliente.Length == 0)
                    throw new FormatException("El cliente no puede estar vacío.");
                if (zona is not ("ZONA A" or "ZONA B" or "ZONA C"))
                    throw new FormatException($"La zona '{campos[2].Trim()}' no es válida.");
                if (!decimal.TryParse(campos[3].Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out decimal peso) || peso <= 0)
                    throw new FormatException("El peso debe ser un número positivo.");
                if (!decimal.TryParse(campos[4].Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out decimal valorDeclarado) || valorDeclarado <= 0)
                    throw new FormatException("El valor declarado debe ser un número positivo.");

                resultado.PaquetesValidos.Add(new Paquete
                {
                    Codigo = codigo,
                    Cliente = cliente,
                    Zona = zona,
                    Peso = peso,
                    ValorDeclarado = valorDeclarado
                });
            }
            catch (Exception ex) when (ex is FormatException or ArgumentException or OverflowException)
            {
                resultado.Errores.Add($"Línea {i + 1}: {ex.Message}");
            }
        }

        return resultado;
    }
}
