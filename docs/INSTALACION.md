# Guía de Instalación — LogisticaFacturacion
**Sistema de Procesamiento y Auditoría de Facturación (MiniProye02)**

**Repositorio oficial:** https://github.com/juanEmiMunoziba23/Mini-Projecto-02-SISTEMA-DE-PROCESAMIENTO-Y-AUDITOR-A-DE-FACTURACI-N-LOG-STICA-Y-ENTREGAS-.git

---

## Índice
1. [Requisitos del sistema](#1-requisitos-del-sistema)
2. [Instalación portátil](#2-instalación-portátil)
3. [Instalación desde código fuente](#3-instalación-desde-código-fuente)
4. [Descarga directa como ZIP](#4-descarga-directa-como-zip)
5. [Generar tu propio ejecutable](#5-generar-tu-propio-ejecutable)
6. [Solución de problemas](#6-solución-de-problemas)
7. [Soporte](#7-soporte)

---

## 1. Requisitos del sistema

### Hardware mínimo
| Recurso | Mínimo |
|---------|--------|
| Procesador | 1.8 GHz o superior |
| Memoria RAM | 2 GB |
| Espacio en disco | 100 MB |
| Pantalla | 1024 × 768 |

### Software
| Recurso | Requerimiento |
|---------|---------------|
| Sistema operativo | Windows 10 o superior (64 bits) |
| .NET Runtime | No requerido (versión self-contained) |
| Conexión a internet | No requerida para ejecutar |
| Permisos | Usuario estándar (no requiere admin) |

La aplicación funciona **100 % offline** una vez instalada.

---

## 2. Instalación portátil
**Método recomendado — No requiere instalación.**

### Paso 1 — Obtener el ejecutable
Descarga el archivo `LogisticaFacturacion.exe` desde:
- El repositorio: https://github.com/juanEmiMunoziba23/Mini-Projecto-02-SISTEMA-DE-PROCESAMIENTO-Y-AUDITOR-A-DE-FACTURACI-N-LOG-STICA-Y-ENTREGAS-.git
- O el paquete de instalación entregado por el equipo.

### Paso 2 — Extraer
1. Crea una carpeta donde quieras tener la aplicación (por ejemplo, `C:\LogisticaFacturacion\`).
2. Copia el `.exe` y la carpeta `Resources/` (que contiene `appsettings.json`, `es.json` y `en.json`) dentro de esa carpeta.

### Paso 3 — Ejecutar
1. Haz doble clic sobre `LogisticaFacturacion.exe`.
2. Si Windows muestra la advertencia *"Windows protegió tu PC"*:
   - Clic en **Más información**.
   - Clic en **Ejecutar de todas formas**.

### Paso 4 — Verificar
Se debe abrir la ventana principal con el título: *"Sistema de Procesamiento y Auditoría de Facturación"*.
Al iniciar, la aplicación creará automáticamente el archivo `Logistica.db` (base de datos SQLite) en la misma carpeta.

### Crear acceso directo (opcional)
1. Clic derecho sobre `LogisticaFacturacion.exe`.
2. **Enviar a → Escritorio (crear acceso directo)**.

---

## 3. Instalación desde código fuente
Para desarrolladores que quieran modificar el proyecto.

### Paso 1 — Instalar herramientas necesarias
| Herramienta | Enlace de descarga |
|-------------|--------------------|
| Visual Studio 2022 Community | https://visualstudio.microsoft.com/es/vs/community/ |
| .NET 10.0 SDK | https://dotnet.microsoft.com/download |
| Git | https://git-scm.com/download/win |

> Durante la instalación de Visual Studio, marca la carga de trabajo **"Desarrollo de escritorio de .NET"**.

### Paso 2 — Verificar instalaciones
Abre PowerShell y ejecuta:
```bash
git --version
dotnet --version

Paso 3 — Clonar el repositorio
git clone https://github.com/juanEmiMunoziba23/Mini-Projecto-02-SISTEMA-DE-PROCESAMIENTO-Y-AUDITOR-A-DE-FACTURACI-N-LOG-STICA-Y-ENTREGAS-.git
cd Mini-Projecto-02-SISTEMA-DE-PROCESAMIENTO-Y-AUDITOR-A-DE-FACTURACI-N-LOG-STICA-Y-ENTREGAS-

Paso 4 — Restaurar dependencias
dotnet restore

Paso 5 — Compilar y ejecutar
Opción A — Visual Studio:

Doble clic sobre MiniProye02.slnx.

Presiona F5 o Compilar → Compilar solución (Ctrl + Shift + B).

Opción B — Línea de comandos:
dotnet build -c Release
dotnet run

4. Descarga directa como ZIP
Si no tienes Git instalado, puedes descargar el proyecto como ZIP.

Paso 1 — Descargar
🔗 https://github.com/juanEmiMunoziba23/Mini-Projecto-02-SISTEMA-DE-PROCESAMIENTO-Y-AUDITOR-A-DE-FACTURACI-N-LOG-STICA-Y-ENTREGAS-/archive/refs/heads/main.zip

Paso 2 — Descomprimir
Clic derecho sobre el archivo descargado.

Extraer todo...

Elige una carpeta de destino.

Paso 3 — Abrir con Visual Studio
Entra a la carpeta extraída.

Doble clic en MiniProye02.slnx.

Visual Studio abrirá el proyecto automáticamente.

Paso 4 — Compilar
Presiona F5 para compilar y ejecutar.

5. Generar tu propio ejecutable
Si quieres crear tu propio LogisticaFacturacion.exe autónomo (sin necesidad de tener .NET instalado):
Comando único
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true

Resultado
El ejecutable se genera en:
bin\Release\net10.0-windows\win-x64\publish\LogisticaFacturacion.exe

Características del ejecutable
Característica	Valor
Tamaño aproximado	70 MB
Requiere .NET instalado	No
Requiere dependencias	No (excepto la carpeta Resources/)
Funciona en	Windows 10/11 (64 bits)
Importante: Asegúrate de copiar la carpeta Resources/ (con appsettings.json, es.json y en.json) junto al .exe, de lo contrario la aplicación mostrará un error de configuración al iniciar.

6. Solución de problemas
6.1 Al ejecutar la aplicación
Problema	Causa	Solución
Windows bloquea el .exe	SmartScreen	"Más información → Ejecutar de todas formas"
No abre el programa	.exe dañado	Descarga una copia nueva
"No fue posible cargar la configuración"	Falta la carpeta Resources/ o el archivo appsettings.json	Copia la carpeta Resources/ junto al .exe
"Unable to load DLL 'SQLite.Interop.dll'"	Falta la librería nativa de SQLite	Copia runtimes\win-x64\native\SQLite.Interop.dll a la raíz del ejecutable
La ventana se ve cortada	Resolución baja	Ajustar a 125 % o superior en Windows
6.2 Al compilar desde código fuente
Problema	Causa	Solución
dotnet: command not found	Falta el SDK	Instalar .NET 10.0 SDK
git: command not found	Falta Git	Instalar Git
Error MSB... al compilar	Dependencias faltantes	Ejecutar dotnet restore
El diseñador visual falla	Bug del diseñador de WinForms	Ignorar — el código funciona igual
C# 12/13 no soportado	SDK antiguo	Actualizar a .NET 10.0 o superior
6.3 Al publicar el ejecutable
Problema	Solución
El .exe pesa mucho	Es normal (self-contained ≈ 70 MB)
No funciona en 32 bits	Compilar con -r win-x86
Faltan archivos DLL	No usar -p:PublishSingleFile=true, o asegurarse de copiar SQLite.Interop.dll
La base de datos se crea en otra ruta	Usar ruta absoluta en CadenaConexion (ver Documentación Técnica)
7. Soporte
Documentación relacionada
Manual de Usuario

Documentación Técnica

Repositorio oficial
https://github.com/juanEmiMunoziba23/Mini-Projecto-02-SISTEMA-DE-PROCESAMIENTO-Y-AUDITOR-A-DE-FACTURACI-N-LOG-STICA-Y-ENTREGAS-.git