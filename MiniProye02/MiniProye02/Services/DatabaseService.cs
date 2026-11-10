using System.Data.SQLite;
using MiniProye02.Models;

namespace MiniProye02.Services;

/// <summary>Persiste los paquetes facturados en una base de datos SQLite.</summary>
public class DatabaseService
{
    private readonly string _cadenaConexion;

    /// <summary>Crea el servicio con la cadena de conexión SQLite.</summary>
    /// <param name="cadenaConexion">Cadena de conexión a la base de datos.</param>
    public DatabaseService(string cadenaConexion) => _cadenaConexion = cadenaConexion;

    /// <summary>Crea la tabla de paquetes si aún no existe.</summary>
    public void Inicializar()
    {
        using var conexion = new SQLiteConnection(_cadenaConexion);
        conexion.Open();
        using var comando = new SQLiteCommand(@"
            CREATE TABLE IF NOT EXISTS Paquetes (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Codigo TEXT NOT NULL,
                Cliente TEXT NOT NULL,
                Zona TEXT NOT NULL,
                Peso REAL NOT NULL,
                ValorDeclarado REAL NOT NULL,
                SubtotalPeso REAL NOT NULL,
                RecargoZona REAL NOT NULL,
                PenalizacionPeso REAL NOT NULL,
                Seguro REAL NOT NULL,
                Impuesto REAL NOT NULL,
                Total REAL NOT NULL
            );", conexion);
        comando.ExecuteNonQuery();
    }

    /// <summary>Guarda un paquete con una instrucción SQL parametrizada.</summary>
    /// <param name="p">Paquete calculado que se guardará.</param>
    public void GuardarPaquete(Paquete p)
    {
        using var conexion = new SQLiteConnection(_cadenaConexion);
        conexion.Open();
        using var comando = new SQLiteCommand(@"
            INSERT INTO Paquetes
                (Codigo, Cliente, Zona, Peso, ValorDeclarado, SubtotalPeso, RecargoZona, PenalizacionPeso, Seguro, Impuesto, Total)
            VALUES
                (@Codigo, @Cliente, @Zona, @Peso, @ValorDeclarado, @SubtotalPeso, @RecargoZona, @PenalizacionPeso, @Seguro, @Impuesto, @Total);", conexion);
        comando.Parameters.AddWithValue("@Codigo", p.Codigo);
        comando.Parameters.AddWithValue("@Cliente", p.Cliente);
        comando.Parameters.AddWithValue("@Zona", p.Zona);
        comando.Parameters.AddWithValue("@Peso", p.Peso);
        comando.Parameters.AddWithValue("@ValorDeclarado", p.ValorDeclarado);
        comando.Parameters.AddWithValue("@SubtotalPeso", p.SubtotalPeso);
        comando.Parameters.AddWithValue("@RecargoZona", p.RecargoZona);
        comando.Parameters.AddWithValue("@PenalizacionPeso", p.PenalizacionPeso);
        comando.Parameters.AddWithValue("@Seguro", p.Seguro);
        comando.Parameters.AddWithValue("@Impuesto", p.Impuesto);
        comando.Parameters.AddWithValue("@Total", p.Total);
        comando.ExecuteNonQuery();
    }
}
