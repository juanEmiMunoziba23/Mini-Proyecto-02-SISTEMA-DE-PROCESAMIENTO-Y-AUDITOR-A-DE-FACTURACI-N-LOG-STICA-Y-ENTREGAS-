# Contribuidores del Proyecto

## LogisticaFacturacion - Sistema de Procesamiento y Auditoría de Facturación

Repositorio oficial: https://github.com/juanEmiMunoziba23/Mini-Projecto-02-SISTEMA-DE-PROCESAMIENTO-Y-AUDITOR-A-DE-FACTURACI-N-LOG-STICA-Y-ENTREGAS-.git

## Equipo de desarrollo

| Integrante | Rol |
|------------|-----|
| Ian Paulo Acevedo Aldana | Backend + QA |
| Juan Emiliano Muñoz Ibarra | Frontend + Documentación + DevOps |

## Desglose de aportaciones

### Ian Paulo Acevedo Aldana — Backend + QA

**Partes del proyecto que generó:**

**Módulo Backend (Lógica de negocio)**

- **Modelos de dominio (`Models/`)**:
  - `Paquete` (encapsulamiento estricto mediante campos privados y propiedades públicas para `Codigo`, `Cliente`, `Zona`, `Peso`, `ValorDeclarado` y propiedades calculadas `SubtotalPeso`, `RecargoZona`, `PenalizacionPeso`, `Seguro`, `Impuesto`, `Total`).
  - `Configuracion` (parámetros de tarifas y conexión).
- **Validaciones y parseo (`PaqueteParserService.cs`)**:
  - Algoritmo de sanitización y parseo tolerante a fallos (Reto 1).
  - Uso de `Split(';')`, `Trim()`, `ToUpperInvariant()` y `decimal.TryParse` con `InvariantCulture`.
  - Validación de 5 campos por línea, zonas A/B/C, peso y valor declarado positivos.
  - Acumulación de errores en lista paralela sin detener el lote.
- **Motor de cálculo financiero (`CalculoService.cs`)**:
  - Cálculo escalonado de tarifas (Reto 3).
  - Subtotal por peso, recargo por zona mediante `switch` (5%, 10%, 18%).
  - Penalización por exceso de peso (>20 kg) al 25% del precio base.
  - Seguro del 2% si el valor declarado supera $1,000.
  - IVA sobre la base imponible y total final.
- **Arreglo dinámico y ordenamiento (`ArregloService.cs`)**:
  - Implementación manual del redimensionamiento (Reto 2).
  - Al superar la capacidad, se crea un nuevo arreglo con el doble de tamaño y se copia elemento por elemento.
  - Ordenamiento descendente por `Total` mediante algoritmo de selección.
- **Persistencia de datos (`DatabaseService.cs`)**:
  - Creación de la tabla `Paquetes` en SQLite con `CREATE TABLE IF NOT EXISTS` e inserción parametrizada (prevención de SQL injection).
- **Exportación a CSV (`CsvService.cs`)**:
  - Generación de archivo delimitado por comas con `StreamWriter` y `UTF8Encoding(true)` (BOM para compatibilidad con Excel), con escape de campos que contienen comas o comillas.
- **Carga de configuración (`ConfiguracionService.cs`)**:
  - Lectura y deserialización de `appsettings.json` con `System.Text.Json`.
- **Internacionalización (`IdiomaService.cs`)**:
  - Carga de diccionarios de traducción desde `es.json` y `en.json` con fallback seguro.

**Módulo de QA (Aseguramiento de calidad)**

- Diseño y ejecución de casos de prueba funcionales: lote válido, lote con líneas inválidas, lote vacío, más de 5 paquetes (redimensionamiento), cambio de idioma, exportación CSV, ausencia de `appsettings.json` y clic en fila del grid.
- Verificación de casos borde: peso ≤ 0, valor declarado ≤ 0, zona inválida, campos vacíos, líneas con distinto número de campos y caracteres no numéricos.
- Validación del ordenamiento descendente y de la integridad de los datos persistidos en SQLite.

**Archivos principales que generó:**

- `Models/Paquete.cs`
- `Models/Configuracion.cs`
- `Services/PaqueteParserService.cs`
- `Services/CalculoService.cs`
- `Services/ArregloService.cs`
- `Services/DatabaseService.cs`
- `Services/ConfiguracionService.cs`
- `Services/CsvService.cs`
- `Services/IdiomaService.cs`

---

### Juan Emiliano Muñoz Ibarra — Frontend + Documentación + DevOps

**Partes del proyecto que generó:**

**Módulo Frontend (Interfaz gráfica)**

- **Diseño del layout (`Form1.Designer.cs`)**:
  - Panel de encabezado con título y selector de idioma.
  - `TextBox` multilínea para el lote de paquetes.
  - `FlowLayoutPanel` con botones **Procesar**, **Exportar CSV** y **Limpiar**.
  - Panel lateral de detalle del paquete.
  - `DataGridView` para paquetes validados.
  - `ListBox` para errores del lote.
- **Creación de controles**: `Label`, `ComboBox` (`cmbIdioma`), `Button`, `DataGridView`, `ListBox`, `TextBox`, `Panel`.
- **Eventos**:
  - `cmbIdioma_SelectedIndexChanged` → cambio dinámico de idioma en tiempo real.
  - `btnProcesar_Click`, `btnExportar_Click`, `btnLimpiar_Click`.
  - `dgvPaquetes_CellClick` → proyección del desglose del paquete en el panel lateral.
  - `Form1_Load` → carga de configuración, inicialización de BD, carga de idioma y habilitación de botones.
- **Estilos visuales**: paleta azul (`#1E3A5F`), botones planos, tipografía `Segoe UI`, filas alternas en el grid y encabezados personalizados.
- **Ajustes de usabilidad**: propiedades `Anchor` para redimensionamiento responsivo, `MinimumSize`, `StartPosition.CenterScreen` y `AutoEllipsis` en el título.
- **Pruebas de integración UI ↔ lógica**: verificación de comunicación entre eventos y servicios, y validación de la actualización de traducciones.

**Módulo de Documentación**

- `README.md`: presentación del proyecto, características, stack, estructura, instalación y uso rápido.
- `CONTRIBUTORS.md` (este archivo).
- `docs/MANUAL_USUARIO.md`: guía paso a paso para procesar lotes, interpretar el grid, exportar CSV y cambiar idioma.
- `docs/DOCUMENTACION_TECNICA.md`: arquitectura por capas, estructura de clases, flujo de procesamiento y guía de mantenimiento.
- `docs/INSTALACION.md`: requisitos del sistema, instalación desde código fuente y solución de problemas.
- Diagramas de arquitectura y de flujo del proceso de facturación.

**Módulo DevOps**

- Configuración del repositorio GitHub: `README.md`, `CONTRIBUTORS.md`, `LINK_GITHUB.txt`.
- Generación del ejecutable autónomo (`dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true`).
- Empaquetado del entregable y pruebas de despliegue en PC limpia.
- Verificación de build limpio y de la carga correcta de los archivos `Resources/*.json`.

**Archivos principales que generó:**

- `Form1.cs` (capa de presentación y eventos)
- `Form1.Designer.cs`
- `Resources/es.json`
- `Resources/en.json`
- `Resources/appsettings.json`
- `README.md`
- `CONTRIBUTORS.md`
- `LINK_GITHUB.txt`
- `docs/MANUAL_USUARIO.md`
- `docs/DOCUMENTACION_TECNICA.md`
- `docs/INSTALACION.md`

---

## Tabla resumen de contribuciones

| Integrante | ID | Rol | Partes generadas |
|------------|----|-----|------------------|
| Ian Paulo Acevedo Aldana | 341959 | Backend + QA | Modelos, parseo, cálculo escalonado, arreglo dinámico, ordenamiento, SQLite, CSV, i18n, casos de prueba |
| Juan Emiliano Muñoz Ibarra | 549629 | Frontend + Docs + DevOps | Interfaz, eventos, estilos, traducciones, manuales, configuración de GitHub, instalador |

El código fuente completo y la documentación asociada pueden verificarse en:

**https://github.com/juanEmiMunoziba23/Mini-Projecto-02-SISTEMA-DE-PROCESAMIENTO-Y-AUDITOR-A-DE-FACTURACI-N-LOG-STICA-Y-ENTREGAS-.git**