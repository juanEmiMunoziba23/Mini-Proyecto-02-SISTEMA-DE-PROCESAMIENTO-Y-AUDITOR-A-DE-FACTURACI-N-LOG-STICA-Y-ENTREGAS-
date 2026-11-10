# LogisticaFacturacion - Sistema de Procesamiento y Auditoría de Facturación (MiniProye02)
🔗 Repositorio oficial:(https://github.com/juanEmiMunoziba23/Mini-Proyecto-02-SISTEMA-DE-PROCESAMIENTO-Y-AUDITOR-A-DE-FACTURACI-N-LOG-STICA-Y-ENTREGAS-.git)

Sistema de escritorio en C# con Windows Forms para procesar, auditar y exportar lotes de facturación de fletes y envíos express, con tarifas parametrizadas, cálculo escalonado de impuestos y soporte multi-idioma.

## Características

- **Procesamiento por lotes**: recibe lotes de paquetes en formato delimitado por `;` desde un `TextBox` multilínea.
- **Parseo tolerante a fallos**: cada línea se valida de forma independiente; las inválidas se reportan en un panel de errores sin detener el resto del lote.
- **Cálculo escalonado de tarifas**: subtotal por peso, recargo por zona (A/B/C), penalización por exceso de peso (>20 kg), seguro (>$1,000) e IVA configurable.
- **Arreglo dinámico**: redimensionamiento manual (`Paquete[]`) al duplicar capacidad y ordenamiento descendente por total (método de selección).
- **Interfaz multi-idioma dinámica**: cambio Español ↔ English en tiempo real para botones, etiquetas, columnas y mensajes.
- **Auditoría visual**: `DataGridView` con los paquetes validados; al hacer clic en una fila, el desglose financiero completo se proyecta en un panel lateral.
- **Persistencia en SQLite**: historial de paquetes procesados en base de datos local.
- **Exportación a CSV**: mediante `SaveFileDialog`, con codificación UTF-8 con BOM (compatible con Excel).
- **Configuración externa**: tarifas y cadena de conexión cargadas desde `appsettings.json`.

## Tecnologías

C# · .NET 10 · Windows Forms · System.Data.SQLite.Core · System.Text.Json · Git

## Equipo

| Nombre | Rol |
|--------|-----|
| Ian Paulo Acevedo Aldana | Backend + QA |
| Juan Emiliano Muñoz Ibarra | Frontend + Documentación + DevOps |

Detalle completo en `CONTRIBUTORS.md`.

## Documentación

## Instalación

Clonar el proyecto:

```bash
git clone https://github.com/juanEmiMunoziba23/Mini-Proyecto-02-SISTEMA-DE-PROCESAMIENTO-Y-AUDITOR-A-DE-FACTURACI-N-LOG-STICA-Y-ENTREGAS-.git
cd <tu-repo>
dotnet restore
dotnet run
dotnet restore
dotnet run
