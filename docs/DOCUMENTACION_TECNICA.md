# Documentación Técnica — LogisticaFacturacion

**Sistema de Procesamiento y Auditoría de Facturación (MiniProye02)**

**Repositorio oficial:** https://github.com/juanEmiMunoziba23/Mini-Projecto-02-SISTEMA-DE-PROCESAMIENTO-Y-AUDITOR-A-DE-FACTURACI-N-LOG-STICA-Y-ENTREGAS-.git

---

## Índice

1. [Arquitectura del sistema](#1-arquitectura-del-sistema)
2. [Estructura del proyecto](#2-estructura-del-proyecto)
3. [Clases y modelos](#3-clases-y-modelos)
4. [Diagrama de flujo](#4-diagrama-de-flujo)
5. [Requisitos para desarrolladores](#5-requisitos-para-desarrolladores)
6. [Clonar el repositorio](#6-clonar-el-repositorio)
7. [Compilar desde código fuente](#7-compilar-desde-código-fuente)
8. [Mantenimiento y extensiones](#8-mantenimiento-y-extensiones)
9. [Glosario](#9-glosario)

---

## 1. Arquitectura del sistema

El sistema sigue una arquitectura organizada en **tres capas claras**, cumpliendo con los principios de separación de responsabilidades y Programación Orientada a Objetos (POO):

```text
CAPA DE PRESENTACIÓN (Windows Forms)
Form1.cs + Form1.Designer.cs
│
│ Responsable:
│ - Interacción con el usuario
│ - Captura de lotes de texto
│ - Visualización de resultados en DataGridView
│ - Proyección de desglose en panel lateral
│
│ llamadas a métodos
▼
┌─────────────────────────────────────────────┐
│ CAPA DE LÓGICA DE NEGOCIO (Services)        │
│ CalculoService · PaqueteParserService       │
│ ArregloService · CsvService                 │
│ DatabaseService · ConfiguracionService      │
│ IdiomaService                               │
│                                             │
│ Responsable:                                │
│ - Parseo y validación de cadenas            │
│ - Cálculo financiero escalonado             │
│ - Manejo de arreglos dinámicos              │
│ - Persistencia SQLite, CSV y JSON           │
└───────────────────┬─────────────────────────┘
                    │
                    │ uso de modelos
                    ▼
┌─────────────────────────────────────────────┐
│ CAPA DE MODELOS (Models)                    │
│ Paquete · Configuracion                     │
│                                             │
│ Responsable:                                │
│ - Representación de datos                   │
│ - Estructuras de dominio                    │
└─────────────────────────────────────────────┘
Justificación del diseño
Separación estricta: la interfaz gráfica no realiza cálculos ni lee archivos directamente; delega todo a los servicios.

Encapsulamiento: Paquete expone sus datos mediante propiedades públicas respaldadas por campos privados.

Escalabilidad: el diseño permite agregar nuevos servicios (por ejemplo, un nuevo formato de exportación) sin modificar la UI.

Robustez: el parseo tolerante a fallos permite procesar lotes grandes sin que una línea defectuosa detenga todo el flujo.

LogisticaFacturacion/
│
├── LINK_GITHUB.txt               → Link del repositorio
├── README.md                     → Presentación del proyecto
├── CONTRIBUTORS.md               → Datos del equipo
│
├── MiniProye02.slnx              → Solución de Visual Studio
├── MiniProye02/
│   ├── MiniProye02.csproj        → Configuración del proyecto (.NET 10)
│   ├── Program.cs                → Punto de entrada
│   ├── Form1.cs                  → Lógica del formulario
│   ├── Form1.Designer.cs         → Controles de la interfaz
│   │
│   ├── Models/
│   │   ├── Paquete.cs            → Entidad de dominio
│   │   └── Configuracion.cs      → Parámetros de tarifas
│   │
│   ├── Services/
│   │   ├── ArregloService.cs     → Arreglo dinámico + ordenamiento
│   │   ├── CalculoService.cs     → Cálculo financiero escalonado
│   │   ├── ConfiguracionService.cs → Lectura de appsettings.json
│   │   ├── CsvService.cs         → Exportación a CSV
│   │   ├── DatabaseService.cs    → Persistencia SQLite
│   │   ├── IdiomaService.cs      → Carga de traducciones
│   │   └── PaqueteParserService.cs → Parseo y validación de lotes
│   │
│   └── Resources/
│       ├── appsettings.json      → Tarifas y cadena de conexión
│       ├── es.json               → Traducciones español
│       └── en.json               → Traducciones inglés
│
└── docs/                         → Documentación
    ├── MANUAL_USUARIO.md
    ├── DOCUMENTACION_TECNICA.md
    └── INSTALACION.md

Archivo	Tipo	Propósito
Program.cs	C#	Método Main que arranca la aplicación
Models/Paquete.cs	C#	Define la entidad Paquete con encapsulamiento estricto
Models/Configuracion.cs	C#	Parámetros de tarifas y cadena de conexión
Services/PaqueteParserService.cs	C#	Algoritmo de sanitización y parseo tolerante a fallos
Services/CalculoService.cs	C#	Motor de cálculo financiero escalonado
Services/ArregloService.cs	C#	Arreglo dinámico y ordenamiento por selección
Services/DatabaseService.cs	C#	Persistencia en SQLite
Services/CsvService.cs	C#	Exportación a CSV con UTF-8 BOM
Services/ConfiguracionService.cs	C#	Lectura de appsettings.json
Services/IdiomaService.cs	C#	Carga de diccionarios de traducción
Form1.cs	C#	Lógica del formulario (procesar, exportar, limpiar)
Form1.Designer.cs	C#	Controles e interfaz gráfica (autogenerado)
MiniProye02.csproj	XML	Configuración de compilación (.NET 10)
MiniProye02.slnx	Texto	Agrupación del proyecto en Visual Studio   

3. Clases y modelos
3.1 Clase Paquete
Representa un envío procesado con encapsulamiento estricto (campos privados + propiedades públicas).

Propiedad	Tipo	Descripción
Codigo	string	Identificador del paquete
Cliente	string	Nombre del cliente
Zona	string	Zona de destino (A/B/C)
Peso	decimal	Peso en kilogramos
ValorDeclarado	decimal	Valor declarado del envío
SubtotalPeso	decimal	Cálculo: Peso × PrecioBasePorKg
RecargoZona	decimal	Recargo según zona
PenalizacionPeso	decimal	Penalización por exceso de peso
Seguro	decimal	2% si ValorDeclarado > 1000
Impuesto	decimal	IVA sobre base imponible
Total	decimal	Total facturado

Campos privados:
private string _codigo = string.Empty;
private string _cliente = string.Empty;
private string _zona = string.Empty;
private decimal _peso;
private decimal _valorDeclarado;

3.2 Clase Configuracion
Representa los parámetros globales de facturación.

Propiedad	Tipo	Descripción
PrecioBasePorKg	decimal	Precio por kilogramo
TasaIVA	decimal	Tasa de IVA (ej. 0.16)
CostoFijoEnvio	decimal	Costo fijo por envío
CadenaConexion	string	Cadena de conexión SQLite

3.3 Clase CalculoService
Motor financiero que aplica las reglas de negocio escalonadas.
// Recargo por zona
decimal tasaZona = p.Zona switch
{
    "ZONA A" => 0.05m,
    "ZONA B" => 0.10m,
    "ZONA C" => 0.18m,
    _ => throw new ArgumentException("La zona del paquete no es válida.", nameof(p))
};

// Penalización por peso > 20 kg
p.PenalizacionPeso = p.Peso > 20m
    ? (p.Peso - 20m) * 0.25m * _configuracion.PrecioBasePorKg
    : 0m;

// Seguro si valor declarado > 1000
p.Seguro = p.ValorDeclarado > 1000m ? p.ValorDeclarado * 0.02m : 0m;

// Base imponible e impuesto
decimal baseImponible = p.SubtotalPeso + p.RecargoZona 
                      + p.PenalizacionPeso + p.Seguro 
                      + _configuracion.CostoFijoEnvio;
p.Impuesto = baseImponible * _configuracion.TasaIVA;
p.Total = baseImponible + p.Impuesto;

3.4 Clase ArregloService
Maneja un arreglo dinámico de paquetes con redimensionamiento manual y ordenamiento por selección.
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

public void OrdenarDescendentePorTotal()
{
    for (int i = 0; i < _cantidad - 1; i++)
    {
        int indiceMayor = i;
        for (int j = i + 1; j < _cantidad; j++)
            if (_arregloBase[j].Total > _arregloBase[indiceMayor].Total)
                indiceMayor = j;

        if (indiceMayor != i)
            (_arregloBase[i], _arregloBase[indiceMayor]) = 
                (_arregloBase[indiceMayor], _arregloBase[i]);
    }
}

3.5 Clase PaqueteParserService
Valida cada línea de forma independiente y acumula errores en una lista paralela.
string[] campos = linea.Split(';');
if (campos.Length != 5)
    throw new FormatException("Se esperaban exactamente 5 campos separados por ';'.");

if (zona is not ("ZONA A" or "ZONA B" or "ZONA C"))
    throw new FormatException($"La zona '{campos[2].Trim()}' no es válida.");

if (!decimal.TryParse(campos[3].Trim(), NumberStyles.Number, 
    CultureInfo.InvariantCulture, out decimal peso) || peso <= 0)
    throw new FormatException("El peso debe ser un número positivo.");

3.6 Clase DatabaseService
Crea la tabla Paquetes e inserta con parámetros (prevención de SQL injection).
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
);

3.7 Clase IdiomaService
Carga diccionarios desde JSON y aplica fallback seguro.
public Dictionary<string, string> CargarIdioma(string ruta)
{
    if (!File.Exists(ruta))
        throw new FileNotFoundException("No se encontró el archivo de idioma.", ruta);

    string json = File.ReadAllText(ruta);
    return JsonSerializer.Deserialize<Dictionary<string, string>>(json)
        ?? throw new InvalidDataException("El archivo de idioma está vacío o no es válido.");
}

4. Diagrama de flujo
4.1 Flujo principal — Procesar un lote
              INICIO
                │
                ▼
      [Ingresar o pegar lote en TextBox]
                │
                ▼
      ¿TextBox vacío? ── Sí ──▶ [Mostrar error] ──▶ FIN
                │ No
                ▼
      [Parsear línea por línea]
                │
                ▼
      ¿Línea válida? ── No ──▶ [Agregar a lista de errores]
                │ Sí
                ▼
      [Calcular tarifas con CalculoService]
                │
                ▼
      [Agregar a ArregloService]
                │
                ▼
      [Guardar en SQLite]
                │
                ▼
      [Ordenar arreglo descendente]
                │
                ▼
      [Actualizar DataGridView y ListBox de errores]
                │
                ▼
      [Mostrar mensaje con cantidad procesada]
                │
                ▼
              FIN

4.2 Flujo de inspección — Clic en fila del grid
              INICIO
                │
                ▼
      [Clic en fila del DataGridView]
                │
                ▼
      ¿Fila válida? ── No ──▶ FIN
                │ Sí
                ▼
      [Obtener objeto Paquete]
                │
                ▼
      [Construir texto de desglose]
                │
                ▼
      [Mostrar en panel lateral]
                │
                ▼
              FIN

4.3 Flujo de exportación — CSV
              INICIO
                │
                ▼
      ¿Hay paquetes? ── No ──▶ [Mostrar error] ──▶ FIN
                │ Sí
                ▼
      [Abrir SaveFileDialog]
                │
                ▼
      ¿Usuario confirma? ── No ──▶ FIN
                │ Sí
                ▼
      [Escribir encabezado y filas con StreamWriter]
                │
                ▼
      [Mostrar confirmación]
                │
                ▼
              FIN

5. Requisitos para desarrolladores
Hardware mínimo
Procesador de 1.8 GHz

4 GB de RAM

1 GB de espacio libre en disco

Software obligatorio
Herramienta	Versión mínima
Windows	10 (64 bits)
Visual Studio	2022 Community
Carga de trabajo VS	"Desarrollo de escritorio .NET"
.NET SDK	10.0 o superior
Git	2.30+

Instalación de Visual Studio
Descarga desde https://visualstudio.microsoft.com/es/vs/community/

Durante la instalación, marca:

Desarrollo de escritorio de .NET

Espera a que termine (10-20 min).

Instalación de Git
Descarga desde https://git-scm.com/download/win

Instala con las opciones por defecto.

Verifica con:
git --version

6. Clonar el repositorio
URL del repositorio
https://github.com/juanEmiMunoziba23/Mini-Projecto-02-SISTEMA-DE-PROCESAMIENTO-Y-AUDITOR-A-DE-FACTURACI-N-LOG-STICA-Y-ENTREGAS-.git

Comando para clonar
git clone https://github.com/juanEmiMunoziba23/Mini-Projecto-02-SISTEMA-DE-PROCESAMIENTO-Y-AUDITOR-A-DE-FACTURACI-N-LOG-STICA-Y-ENTREGAS-.git
cd Mini-Projecto-02-SISTEMA-DE-PROCESAMIENTO-Y-AUDITOR-A-DE-FACTURACI-N-LOG-STICA-Y-ENTREGAS-

Descarga directa como ZIP
Ve al repositorio en GitHub.

Clic en Code → Download ZIP.

Descomprime y abre MiniProye02.slnx con Visual Studio 2022.

7. Compilar desde código fuente
Opción A — Visual Studio (recomendado)
Abre MiniProye02.slnx con doble clic.

Espera a que Visual Studio restaure los paquetes NuGet.

Presiona F5 para compilar y ejecutar.

O bien: menú Compilar → Compilar solución (Ctrl + Shift + B).

8. Mantenimiento y extensiones
8.1 Modificar las tarifas de facturación
Edita el archivo Resources/appsettings.json:
{
  "PrecioBasePorKg": 25.50,
  "TasaIVA": 0.16,
  "CostoFijoEnvio": 50.00,
  "CadenaConexion": "Data Source=Logistica.db;Version=3;"
}
Los cambios se aplican al reiniciar la aplicación (no requiere recompilar).

8.2 Agregar una nueva zona
Requiere 2 cambios:

Services/CalculoService.cs: añadir el valor al switch.
decimal tasaZona = p.Zona switch
{
    "ZONA A" => 0.05m,
    "ZONA B" => 0.10m,
    "ZONA C" => 0.18m,
    "ZONA D" => 0.22m,  // ← Nueva zona
    _ => throw new ArgumentException("La zona del paquete no es válida.", nameof(p))
};
Services/PaqueteParserService.cs: actualizar la validación.
if (zona is not ("ZONA A" or "ZONA B" or "ZONA C" or "ZONA D"))
    throw new FormatException($"La zona '{campos[2].Trim()}' no es válida.");

8.3 Agregar un nuevo campo al paquete
Requiere 6 cambios:

Models/Paquete.cs: añadir la propiedad.

Services/PaqueteParserService.cs: aumentar el número de campos esperados.

Services/CalculoService.cs: incluir el campo en el cálculo si aplica.

Form1.Designer.cs: añadir la columna al DataGridView.

Services/DatabaseService.cs: añadir el campo al INSERT y a la tabla.

Services/CsvService.cs: añadir la columna al CSV.

8.4 Solución de problemas comunes
Problema	Causa probable	Solución
"No fue posible cargar la configuración"	appsettings.json ausente o mal formado	Verifica Resources/appsettings.json y su sintaxis JSON
"Unable to load DLL 'SQLite.Interop.dll'"	Interop no copiado a la salida	Copia manualmente o configura RuntimeIdentifier en el .csproj
Los paquetes no aparecen en la tabla	Todas las líneas tienen errores	Revisa el panel de errores; verifica el formato de 5 campos con ;
El idioma no cambia	Archivo de idioma ausente o clave faltante	Verifica Resources/es.json y Resources/en.json

9. Glosario
Término	Significado
Paquete	Envío individual que se procesa para facturación
Zona	Región de destino que determina el recargo (A/B/C)
Subtotal por peso	Peso × PrecioBasePorKg
Recargo de zona	Porcentaje aplicado al subtotal según la zona
Penalización por peso	Cargo extra si el paquete supera 20 kg
Seguro	2% del valor declarado si supera $1,000
Base imponible	Suma de subtotal + recargos + seguro + costo fijo
IVA	Impuesto al Valor Agregado aplicado a la base imponible
Self-contained	Ejecutable que incluye el runtime de .NET
Arreglo dinámico	Arreglo que crece manualmente al duplicar su capacidad
Parseo tolerante	Procesamiento línea por línea que no se detiene por errores
SQLite	Base de datos local embebida en el ejecutable
CSV	Comma Separated Values — formato de archivo tabular
Markdown	Lenguaje de marcado ligero para documentación