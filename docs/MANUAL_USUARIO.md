**Sistema de Procesamiento y Auditoría de Facturación (LogisticaFacturacion)**

**Repositorio oficial:** https://github.com/juanEmiMunoziba23/Mini-Projecto-02-SISTEMA-DE-PROCESAMIENTO-Y-AUDITOR-A-DE-FACTURACI-N-LOG-STICA-Y-ENTREGAS-.git

---

## Índice

1. [Introducción](#1-introducción)
2. [Requisitos del sistema](#2-requisitos-del-sistema)
3. [Inicio de la aplicación](#3-inicio-de-la-aplicación)
4. [Interfaz principal](#4-interfaz-principal)
5. [Procesar un lote de paquetes](#5-procesar-un-lote-de-paquetes)
6. [Inspeccionar el desglose de un paquete](#6-inspeccionar-el-desglose-de-un-paquete)
7. [Exportar resultados](#7-exportar-resultados)
8. [Cambiar el idioma y limpiar pantalla](#8-cambiar-el-idioma-y-limpiar-pantalla)
9. [Preguntas frecuentes](#9-preguntas-frecuentes)

---

## 1. Introducción

El **Sistema de Procesamiento y Auditoría de Facturación (LogisticaFacturacion)** es una aplicación de escritorio desarrollada en C# con Windows Forms que permite gestionar, calcular y auditar los costos de envío de paquetes en una empresa de logística y entregas express.

El sistema recibe lotes de paquetes en formato de texto delimitado, valida su estructura, calcula los costos escalonados de flete (subtotal por peso, recargos por zona, penalizaciones, seguro e IVA) y permite exportar la auditoría a un archivo CSV. Además, cuenta con una interfaz multi-idioma dinámica (Español / Inglés) y persiste el historial de transacciones en una base de datos local SQLite.

---

## 2. Requisitos del sistema

| Recurso | Mínimo |
|---------|--------|
| Sistema operativo | Windows 10 o superior (64 bits) |
| Memoria RAM | 2 GB |
| Espacio en disco | 100 MB |
| Conexión a internet | No requerida |
| Permisos | Usuario estándar (no requiere admin) |

> La aplicación funciona **100 % offline** una vez instalada.

---

## 3. Inicio de la aplicación

### 3.1 Instalación

1. Descarga el archivo `LogisticaFacturacion.exe` desde el repositorio o recíbelo en el paquete de instalación.
2. Extrae el archivo y la carpeta `Resources/` en cualquier carpeta de tu preferencia (por ejemplo, `C:\LogisticaFacturacion\`).
3. No es necesario instalar dependencias adicionales.

### 3.2 Ejecución

1. Haz **doble clic** sobre `LogisticaFacturacion.exe`.
2. Si Windows muestra la advertencia **"Windows protegió tu PC"**:
   - Clic en **Más información**.
   - Clic en **Ejecutar de todas formas**.
3. Se abrirá la ventana principal con el título: **"Sistema de Procesamiento y Auditoría de Facturación"**.
4. Al iniciar, el sistema cargará automáticamente las tarifas y creará la base de datos `Logistica.db`.

---

## 4. Interfaz principal

La ventana principal está organizada en **cinco secciones**:

| Sección | Función |
|---------|---------|
| **Encabezado** | Título y selector de idioma |
| **Lote de paquetes** | Cuadro de texto multilínea para ingresar los registros |
| **Detalle del paquete** | Panel lateral que muestra el desglose del paquete seleccionado |
| **Tabla de paquetes** | DataGridView con los paquetes válidos procesados |
| **Errores** | ListBox con las líneas que no cumplieron el formato |

### 4.1 Encabezado y Botones

- **Selector Idioma:** cambia toda la interfaz entre Español e Inglés.
- **Procesar:** valida y calcula el lote de paquetes.
- **Exportar CSV:** genera un archivo con los datos procesados.
- **Limpiar:** borra la tabla, el lote de texto, los errores y el panel de detalle.

### 4.2 Lote de paquetes

Área donde se ingresa el texto. Cada línea debe seguir el formato `CODIGO;Cliente;Zona;Peso;ValorDeclarado`.

### 4.3 Tabla de paquetes y Detalle

La tabla muestra el Código, Cliente, Zona, Peso y Total de los paquetes exitosos. Al hacer clic en una fila, el **panel lateral** muestra el desglose completo.

### 4.4 Errores

Lista las líneas defectuosas (por ejemplo, peso negativo, zona incorrecta o campos vacíos) sin detener el procesamiento del resto del lote.

---

## 5. Procesar un lote de paquetes

### Paso 1 — Capturar el lote

En el cuadro de texto **"Lote de paquetes"**, ingresa o pega los registros. Cada línea debe tener exactamente 5 campos separados por punto y coma (`;`):

```text
CODIGO;Cliente;Zona;Peso;ValorDeclarado

Ejemplo válido:
PACK-001;Juan Perez;Zona A;12.5;150.0
PACK-002;Maria Lopez;Zona C;25.0;1200.0
PACK-003;Pedro Gomez;Zona B;8.0;900.0

Paso 2 — Ejecutar el procesamiento
Clic en el botón Procesar.

El sistema validará cada línea de forma independiente:

Las líneas válidas aparecerán en la tabla inferior.

Las líneas inválidas se listarán en el panel de errores (por ejemplo: "Línea 2: El peso debe ser un número positivo.").

Paso 3 — Confirmación
Aparecerá un mensaje de confirmación como:
Se procesaron 3 paquetes válidos.

6. Inspeccionar el desglose de un paquete
Haz clic sobre cualquier fila de la tabla de paquetes.

En el panel lateral derecho ("Detalle del paquete") se mostrará el desglose completo:
Código: PACK-002
Cliente: Maria Lopez
Zona: ZONA C
Peso (kg): 25.00
Valor declarado: $1,200.00
Subtotal por peso: $637.50
Recargo de zona: $114.75
Penalización por peso: $31.88
Seguro: $24.00
Impuesto: $137.30
Total: $995.43

Reglas de cálculo
Concepto	Regla
Subtotal por peso	Peso × PrecioBasePorKg
Recargo de zona	Zona A: 5%, Zona B: 10%, Zona C: 18%
Penalización por peso	Si Peso > 20 kg, (Peso − 20) × 25% × PrecioBasePorKg
Seguro	Si ValorDeclarado > $1,000, 2% del valor declarado
Impuesto (IVA)	(Subtotal + Recargos + Seguro + CostoFijo) × TasaIVA
Total	Base imponible + Impuesto

7. Exportar resultados
Clic en el botón Exportar CSV.

Se abrirá una ventana para elegir dónde guardar el archivo.

Escribe el nombre (por defecto: Facturacion.csv).

Clic en Guardar.

Aparecerá el mensaje: "El archivo CSV se exportó correctamente."

Formato del archivo CSV
El archivo contiene una fila por cada paquete procesado:
Codigo,Cliente,Zona,Peso,ValorDeclarado,SubtotalPeso,RecargoZona,PenalizacionPeso,Seguro,Impuesto,Total
PACK-001,Juan Perez,ZONA A,12.5,150.0,318.75,15.94,0.00,0.00,61.55,446.24
PACK-002,Maria Lopez,ZONA C,25.0,1200.0,637.50,114.75,31.88,24.00,137.30,995.43
PACK-003,Pedro Gomez,ZONA B,8.0,900.0,204.00,20.40,0.00,0.00,43.90,318.30

8. Cambiar el idioma y limpiar pantalla
8.1 Cambiar el idioma
En la esquina superior derecha, localiza el selector Idioma.

Selecciona Español o English.

Todos los textos de la interfaz (botones, etiquetas, encabezados de tabla y mensajes emergentes) se actualizarán de inmediato.

8.2 Limpiar la pantalla
Clic en el botón Limpiar.

Se borrarán el lote de texto, la tabla de paquetes, el panel de detalle y la lista de errores.

El sistema quedará listo para procesar un nuevo lote.

9. Preguntas frecuentes
¿Puedo procesar varias líneas a la vez?
Sí. El sistema procesa todo el lote y separa las líneas válidas de las inválidas.

¿Qué pasa si una línea tiene un error?
Se registra en el panel de errores y el resto del lote continúa procesándose sin detenerse.

¿Se puede procesar el mismo lote dos veces?
Sí, pero se acumularán los registros en la tabla y en la base de datos. Usa Limpiar si deseas reiniciar la pantalla.

¿Funciona sin internet?
Sí, la aplicación funciona 100 % offline.

¿Los datos se guardan al cerrar?
Sí, los paquetes procesados se guardan permanentemente en el archivo Logistica.db. El CSV es adicional para generar reportes portables.

¿Qué hago si aparece "No fue posible cargar la configuración"?
Verifica que el archivo Resources/appsettings.json exista y tenga el formato correcto en la misma carpeta que el ejecutable.

¿Puedo modificar las tarifas?
Sí, editando el archivo Resources/appsettings.json y reiniciando la aplicación.

¿Puedo modificar un paquete ya procesado?
No. Los registros de auditoría son definitivos una vez guardados. Si necesitas rehacer el cálculo, utiliza el botón Limpiar antes de volver a procesar.