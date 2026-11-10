using System.Globalization;
using MiniProye02.Models;
using MiniProye02.Services;

namespace MiniProye02;

/// <summary>Interfaz para procesar, auditar y exportar lotes de facturación.</summary>
public partial class Form1 : Form
{
    private readonly ConfiguracionService _configuracionService = new();
    private readonly PaqueteParserService _paqueteParserService = new();
    private readonly ArregloService _arregloService = new();
    private readonly CsvService _csvService = new();
    private readonly IdiomaService _idiomaService = new();
    private Dictionary<string, string> _traducciones = new();
    private CalculoService? _calculoService;
    private DatabaseService? _databaseService;

    /// <summary>Inicializa la interfaz; el diseñador crea todos los controles.</summary>
    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        try
        {
            string rutaConfiguracion = Path.Combine(AppContext.BaseDirectory, "Resources", "appsettings.json");
            Configuracion configuracion = _configuracionService.CargarConfiguracion(rutaConfiguracion);
            _calculoService = new CalculoService(configuracion);
            _databaseService = new DatabaseService(configuracion.CadenaConexion);
            _databaseService.Inicializar();
            CargarIdiomaSeleccionado();
            btnProcesar.Enabled = true;
        }
        catch (Exception ex)
        {
            btnProcesar.Enabled = false;
            MessageBox.Show($"{Texto("MsgErrorConfig", "No fue posible cargar la configuración o inicializar la base de datos.")}\n{ex.Message}",
                Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void cmbIdioma_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_traducciones.Count > 0)
            CargarIdiomaSeleccionado();
    }

    private void CargarIdiomaSeleccionado()
    {
        try
        {
            string archivo = cmbIdioma.SelectedIndex == 1 ? "en.json" : "es.json";
            string rutaIdioma = Path.Combine(AppContext.BaseDirectory, "Resources", archivo);
            _traducciones = _idiomaService.CargarIdioma(rutaIdioma);
            AplicarTraducciones();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"No fue posible cargar el idioma seleccionado.\n{ex.Message}", Text,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void AplicarTraducciones()
    {
        Text = Texto("Titulo", "LogisticaFacturacion");
        lblTitulo.Text = Texto("Titulo", "LogisticaFacturacion");
        lblLblLote.Text = Texto("LblLote", "Lote de paquetes");
        lblDetalleTitulo.Text = Texto("LblDetalle", "Detalle del paquete");
        lblErroresTitulo.Text = Texto("LblErrores", "Errores");
        lblIdioma.Text = Texto("LblIdioma", "Idioma");
        btnProcesar.Text = Texto("BtnProcesar", "Procesar");
        btnExportar.Text = Texto("BtnExportar", "Exportar CSV");
        btnLimpiar.Text = Texto("BtnLimpiar", "Limpiar");
        dgvPaquetes.Columns[nameof(Paquete.Codigo)].HeaderText = Texto("ColCodigo", "Código");
        dgvPaquetes.Columns[nameof(Paquete.Cliente)].HeaderText = Texto("ColCliente", "Cliente");
        dgvPaquetes.Columns[nameof(Paquete.Zona)].HeaderText = Texto("ColZona", "Zona");
        dgvPaquetes.Columns[nameof(Paquete.Peso)].HeaderText = Texto("ColPeso", "Peso (kg)");
        dgvPaquetes.Columns[nameof(Paquete.Total)].HeaderText = Texto("ColTotal", "Total");
    }

    private void btnProcesar_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtLote.Text))
        {
            MessageBox.Show(Texto("MsgLoteVacio", "Ingrese al menos una línea para procesar."), Text,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (_calculoService is null || _databaseService is null)
        {
            MessageBox.Show(Texto("MsgErrorConfig", "No fue posible cargar la configuración."), Text,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        try
        {
            ResultadoParseo resultado = _paqueteParserService.ParsearLote(txtLote.Text);
            var errores = new List<string>(resultado.Errores);
            foreach (Paquete paquete in resultado.PaquetesValidos)
            {
                _calculoService.CalcularPaquete(paquete);
                _arregloService.Agregar(paquete);
                try
                {
                    _databaseService.GuardarPaquete(paquete);
                }
                catch (Exception ex)
                {
                    errores.Add($"{paquete.Codigo}: no se pudo guardar en la base de datos. {ex.Message}");
                }
            }

            _arregloService.OrdenarDescendentePorTotal();
            ActualizarGrid();
            lstErrores.BeginUpdate();
            lstErrores.Items.Clear();
            lstErrores.Items.AddRange(errores.Cast<object>().ToArray());
            lstErrores.EndUpdate();
            MessageBox.Show(string.Format(CultureInfo.CurrentCulture,
                    Texto("MsgProcesado", "Se procesaron {0} paquetes válidos."), resultado.PaquetesValidos.Count),
                Text, MessageBoxButtons.OK, errores.Count > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ocurrió un error al procesar el lote.\n{ex.Message}", Text,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ActualizarGrid()
    {
        dgvPaquetes.DataSource = null;
        dgvPaquetes.DataSource = _arregloService.ObtenerArreglo();
        lblDetalleContenido.Text = string.Empty;
    }

    private void btnExportar_Click(object sender, EventArgs e)
    {
        Paquete[] paquetes = _arregloService.ObtenerArreglo();
        if (paquetes.Length == 0)
        {
            MessageBox.Show(Texto("MsgSinPaquetes", "No hay paquetes para exportar."), Text,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var dialogo = new SaveFileDialog
        {
            Filter = "Archivo CSV (*.csv)|*.csv",
            DefaultExt = "csv",
            AddExtension = true,
            FileName = "Facturacion.csv"
        };
        if (dialogo.ShowDialog(this) != DialogResult.OK)
            return;

        try
        {
            _csvService.Exportar(dialogo.FileName, paquetes);
            MessageBox.Show(Texto("MsgExportado", "El archivo CSV se exportó correctamente."), Text,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"No fue posible exportar el archivo CSV.\n{ex.Message}", Text,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnLimpiar_Click(object sender, EventArgs e)
    {
        txtLote.Clear();
        lstErrores.Items.Clear();
        lblDetalleContenido.Text = string.Empty;
        _arregloService.Limpiar();
        ActualizarGrid();
    }

    private void dgvPaquetes_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || dgvPaquetes.Rows[e.RowIndex].DataBoundItem is not Paquete paquete)
            return;

        lblDetalleContenido.Text =
            $"{Texto("ColCodigo", "Código")}: {paquete.Codigo}\n" +
            $"{Texto("ColCliente", "Cliente")}: {paquete.Cliente}\n" +
            $"{Texto("ColZona", "Zona")}: {paquete.Zona}\n" +
            $"{Texto("ColPeso", "Peso (kg)")}: {paquete.Peso.ToString("N2", CultureInfo.CurrentCulture)}\n" +
            $"Valor declarado: {paquete.ValorDeclarado.ToString("C2", CultureInfo.CurrentCulture)}\n" +
            $"Subtotal por peso: {paquete.SubtotalPeso.ToString("C2", CultureInfo.CurrentCulture)}\n" +
            $"Recargo de zona: {paquete.RecargoZona.ToString("C2", CultureInfo.CurrentCulture)}\n" +
            $"Penalización por peso: {paquete.PenalizacionPeso.ToString("C2", CultureInfo.CurrentCulture)}\n" +
            $"Seguro: {paquete.Seguro.ToString("C2", CultureInfo.CurrentCulture)}\n" +
            $"Impuesto: {paquete.Impuesto.ToString("C2", CultureInfo.CurrentCulture)}\n" +
            $"Total: {paquete.Total.ToString("C2", CultureInfo.CurrentCulture)}";
    }

    private string Texto(string clave, string alternativa) =>
        _traducciones.TryGetValue(clave, out string? traduccion) ? traduccion : alternativa;
}
