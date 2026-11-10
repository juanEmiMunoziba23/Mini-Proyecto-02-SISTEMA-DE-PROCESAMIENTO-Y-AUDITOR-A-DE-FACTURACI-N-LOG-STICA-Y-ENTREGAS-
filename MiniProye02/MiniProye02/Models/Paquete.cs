namespace MiniProye02.Models;

/// <summary>Representa un envío procesado para facturación.</summary>
public class Paquete
{
    private string _codigo = string.Empty;
    private string _cliente = string.Empty;
    private string _zona = string.Empty;
    private decimal _peso;
    private decimal _valorDeclarado;

    /// <summary>Obtiene o establece el código del paquete.</summary>
    public string Codigo { get => _codigo; set => _codigo = value; }
    /// <summary>Obtiene o establece el nombre del cliente.</summary>
    public string Cliente { get => _cliente; set => _cliente = value; }
    /// <summary>Obtiene o establece la zona de destino.</summary>
    public string Zona { get => _zona; set => _zona = value; }
    /// <summary>Obtiene o establece el peso del paquete en kilogramos.</summary>
    public decimal Peso { get => _peso; set => _peso = value; }
    /// <summary>Obtiene o establece el valor declarado del envío.</summary>
    public decimal ValorDeclarado { get => _valorDeclarado; set => _valorDeclarado = value; }
    /// <summary>Importe calculado por peso.</summary>
    public decimal SubtotalPeso { get; set; }
    /// <summary>Recargo aplicado según la zona.</summary>
    public decimal RecargoZona { get; set; }
    /// <summary>Penalización por peso superior al límite.</summary>
    public decimal PenalizacionPeso { get; set; }
    /// <summary>Importe del seguro.</summary>
    public decimal Seguro { get; set; }
    /// <summary>Impuesto aplicado a la base imponible.</summary>
    public decimal Impuesto { get; set; }
    /// <summary>Total facturado.</summary>
    public decimal Total { get; set; }
}
