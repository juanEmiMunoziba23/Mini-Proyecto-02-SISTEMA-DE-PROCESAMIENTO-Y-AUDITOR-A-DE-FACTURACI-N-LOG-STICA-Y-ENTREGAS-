using MiniProye02.Models;

namespace MiniProye02.Services;

/// <summary>Almacena y ordena los paquetes procesados en un arreglo dinámico.</summary>
public class ArregloService
{
    private Paquete[] _arregloBase = new Paquete[5];
    private int _cantidad;

    /// <summary>Agrega un paquete y duplica la capacidad cuando sea necesario.</summary>
    /// <param name="p">Paquete que se agregará.</param>
    public void Agregar(Paquete p)
    {
        if (_cantidad == _arregloBase.Length)
        {
            var nuevoArreglo = new Paquete[_arregloBase.Length * 2];
            for (int i = 0; i < _cantidad; i++)
                nuevoArreglo[i] = _arregloBase[i];
            _arregloBase = nuevoArreglo;
        }
        _arregloBase[_cantidad++] = p;
    }

    /// <summary>Devuelve una copia con únicamente los elementos ocupados.</summary>
    /// <returns>Paquetes actualmente almacenados.</returns>
    public Paquete[] ObtenerArreglo()
    {
        var ocupados = new Paquete[_cantidad];
        Array.Copy(_arregloBase, ocupados, _cantidad);
        return ocupados;
    }

    /// <summary>Ordena los paquetes de mayor a menor total mediante selección.</summary>
    public void OrdenarDescendentePorTotal()
    {
        for (int i = 0; i < _cantidad - 1; i++)
        {
            int indiceMayor = i;
            for (int j = i + 1; j < _cantidad; j++)
                if (_arregloBase[j].Total > _arregloBase[indiceMayor].Total)
                    indiceMayor = j;

            if (indiceMayor != i)
                (_arregloBase[i], _arregloBase[indiceMayor]) = (_arregloBase[indiceMayor], _arregloBase[i]);
        }
    }

    /// <summary>Reinicia el arreglo a su capacidad inicial.</summary>
    public void Limpiar()
    {
        _arregloBase = new Paquete[5];
        _cantidad = 0;
    }
}
