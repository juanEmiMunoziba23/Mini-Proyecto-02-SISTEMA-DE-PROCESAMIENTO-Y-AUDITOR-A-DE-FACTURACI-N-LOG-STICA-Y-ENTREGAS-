using MiniProye02.Models;

namespace MiniProye02.Services;

/// <summary>Calcula los cargos de facturación de cada paquete.</summary>
public class CalculoService
{
    private readonly Configuracion _configuracion;

    /// <summary>Crea el servicio con la configuración de tarifas.</summary>
    /// <param name="configuracion">Configuración vigente.</param>
    public CalculoService(Configuracion configuracion) => _configuracion = configuracion;

    /// <summary>Calcula subtotal, recargos, impuesto y total del paquete.</summary>
    /// <param name="p">Paquete a calcular.</param>
    public void CalcularPaquete(Paquete p)
    {
        p.SubtotalPeso = p.Peso * _configuracion.PrecioBasePorKg;
        decimal tasaZona = p.Zona switch
        {
            "ZONA A" => 0.05m,
            "ZONA B" => 0.10m,
            "ZONA C" => 0.18m,
            _ => throw new ArgumentException("La zona del paquete no es válida.", nameof(p))
        };
        p.RecargoZona = p.SubtotalPeso * tasaZona;
        p.PenalizacionPeso = p.Peso > 20m
            ? (p.Peso - 20m) * 0.25m * _configuracion.PrecioBasePorKg
            : 0m;
        p.Seguro = p.ValorDeclarado > 1000m ? p.ValorDeclarado * 0.02m : 0m;
        decimal baseImponible = p.SubtotalPeso + p.RecargoZona + p.PenalizacionPeso + p.Seguro + _configuracion.CostoFijoEnvio;
        p.Impuesto = baseImponible * _configuracion.TasaIVA;
        p.Total = baseImponible + p.Impuesto;
    }
}
