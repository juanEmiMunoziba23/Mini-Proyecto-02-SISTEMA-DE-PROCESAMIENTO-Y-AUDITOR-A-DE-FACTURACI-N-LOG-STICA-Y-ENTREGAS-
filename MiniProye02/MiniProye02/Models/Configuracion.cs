namespace MiniProye02.Models;

/// <summary>Contiene los parámetros de facturación y conexión a datos.</summary>
public class Configuracion
{
    /// <summary>Precio cobrado por kilogramo.</summary>
    public decimal PrecioBasePorKg { get; set; }
    /// <summary>Tasa de IVA en formato decimal.</summary>
    public decimal TasaIVA { get; set; }
    /// <summary>Costo fijo por envío.</summary>
    public decimal CostoFijoEnvio { get; set; }
    /// <summary>Cadena de conexión a la base de datos.</summary>
    public string CadenaConexion { get; set; } = string.Empty;
}
