namespace MiniProye02;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;
    private Panel panelEncabezado;
    private Label lblTitulo;
    private Label lblIdioma;
    private ComboBox cmbIdioma;
    private Label lblLblLote;
    private TextBox txtLote;
    private FlowLayoutPanel panelBotones;
    private Button btnProcesar;
    private Button btnExportar;
    private Button btnLimpiar;
    private Panel panelDetalle;
    private Label lblDetalleTitulo;
    private Label lblDetalleContenido;
    private DataGridView dgvPaquetes;
    private Label lblErroresTitulo;
    private ListBox lstErrores;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        panelEncabezado = new Panel();
        lblTitulo = new Label();
        lblIdioma = new Label();
        cmbIdioma = new ComboBox();
        lblLblLote = new Label();
        txtLote = new TextBox();
        panelBotones = new FlowLayoutPanel();
        btnProcesar = new Button();
        btnExportar = new Button();
        btnLimpiar = new Button();
        panelDetalle = new Panel();
        lblDetalleTitulo = new Label();
        lblDetalleContenido = new Label();
        dgvPaquetes = new DataGridView();
        lblErroresTitulo = new Label();
        lstErrores = new ListBox();
        ((System.ComponentModel.ISupportInitialize)dgvPaquetes).BeginInit();
        panelEncabezado.SuspendLayout();
        panelBotones.SuspendLayout();
        panelDetalle.SuspendLayout();
        SuspendLayout();
        //
        // panelEncabezado
        //
        panelEncabezado.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        panelEncabezado.BackColor = Color.FromArgb(30, 58, 95);
        panelEncabezado.Controls.Add(lblTitulo);
        panelEncabezado.Controls.Add(lblIdioma);
        panelEncabezado.Controls.Add(cmbIdioma);
        panelEncabezado.Location = new Point(0, 0);
        panelEncabezado.Name = "panelEncabezado";
        panelEncabezado.Size = new Size(1100, 60);
        panelEncabezado.TabIndex = 0;
        //
        // lblTitulo
        //
        lblTitulo.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        lblTitulo.AutoEllipsis = true;
        lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblTitulo.ForeColor = Color.White;
        lblTitulo.Location = new Point(15, 12);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(690, 36);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "Sistema de Procesamiento y Auditoría de Facturación";
        lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
        //
        // lblIdioma
        //
        lblIdioma.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblIdioma.ForeColor = Color.White;
        lblIdioma.Location = new Point(815, 19);
        lblIdioma.Name = "lblIdioma";
        lblIdioma.Size = new Size(70, 23);
        lblIdioma.TabIndex = 1;
        lblIdioma.Text = "Idioma";
        lblIdioma.TextAlign = ContentAlignment.MiddleRight;
        //
        // cmbIdioma
        //
        cmbIdioma.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        cmbIdioma.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbIdioma.FormattingEnabled = true;
        cmbIdioma.Items.AddRange(new object[] { "Español", "English" });
        cmbIdioma.Location = new Point(895, 17);
        cmbIdioma.Name = "cmbIdioma";
        cmbIdioma.Size = new Size(120, 23);
        cmbIdioma.TabIndex = 2;
        cmbIdioma.SelectedIndex = 0;
        cmbIdioma.SelectedIndexChanged += cmbIdioma_SelectedIndexChanged;
        //
        // lblLblLote
        //
        lblLblLote.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblLblLote.Location = new Point(15, 75);
        lblLblLote.Name = "lblLblLote";
        lblLblLote.Size = new Size(570, 22);
        lblLblLote.TabIndex = 1;
        lblLblLote.Text = "Lote de paquetes";
        lblLblLote.TextAlign = ContentAlignment.MiddleLeft;
        //
        // txtLote
        //
        txtLote.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        txtLote.BorderStyle = BorderStyle.FixedSingle;
        txtLote.Location = new Point(15, 100);
        txtLote.Multiline = true;
        txtLote.Name = "txtLote";
        txtLote.ScrollBars = ScrollBars.Vertical;
        txtLote.Size = new Size(570, 150);
        txtLote.TabIndex = 2;
        //
        // panelBotones
        //
        panelBotones.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        panelBotones.Controls.Add(btnProcesar);
        panelBotones.Controls.Add(btnExportar);
        panelBotones.Controls.Add(btnLimpiar);
        panelBotones.Location = new Point(15, 260);
        panelBotones.Name = "panelBotones";
        panelBotones.Size = new Size(570, 42);
        panelBotones.TabIndex = 3;
        panelBotones.WrapContents = false;
        //
        // btnProcesar
        //
        btnProcesar.BackColor = Color.FromArgb(30, 58, 95);
        btnProcesar.FlatStyle = FlatStyle.Flat;
        btnProcesar.ForeColor = Color.White;
        btnProcesar.Margin = new Padding(0, 2, 10, 2);
        btnProcesar.Name = "btnProcesar";
        btnProcesar.Size = new Size(130, 35);
        btnProcesar.TabIndex = 0;
        btnProcesar.Text = "Procesar";
        btnProcesar.UseVisualStyleBackColor = false;
        btnProcesar.Click += btnProcesar_Click;
        //
        // btnExportar
        //
        btnExportar.BackColor = Color.FromArgb(105, 117, 132);
        btnExportar.FlatStyle = FlatStyle.Flat;
        btnExportar.ForeColor = Color.White;
        btnExportar.Margin = new Padding(0, 2, 10, 2);
        btnExportar.Name = "btnExportar";
        btnExportar.Size = new Size(130, 35);
        btnExportar.TabIndex = 1;
        btnExportar.Text = "Exportar CSV";
        btnExportar.UseVisualStyleBackColor = false;
        btnExportar.Click += btnExportar_Click;
        //
        // btnLimpiar
        //
        btnLimpiar.BackColor = Color.FromArgb(105, 117, 132);
        btnLimpiar.FlatStyle = FlatStyle.Flat;
        btnLimpiar.ForeColor = Color.White;
        btnLimpiar.Margin = new Padding(0, 2, 10, 2);
        btnLimpiar.Name = "btnLimpiar";
        btnLimpiar.Size = new Size(130, 35);
        btnLimpiar.TabIndex = 2;
        btnLimpiar.Text = "Limpiar";
        btnLimpiar.UseVisualStyleBackColor = false;
        btnLimpiar.Click += btnLimpiar_Click;
        //
        // panelDetalle
        //
        panelDetalle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        panelDetalle.BackColor = Color.FromArgb(245, 245, 245);
        panelDetalle.BorderStyle = BorderStyle.FixedSingle;
        panelDetalle.Controls.Add(lblDetalleTitulo);
        panelDetalle.Controls.Add(lblDetalleContenido);
        panelDetalle.Location = new Point(605, 75);
        panelDetalle.Name = "panelDetalle";
        panelDetalle.Size = new Size(480, 227);
        panelDetalle.TabIndex = 4;
        //
        // lblDetalleTitulo
        //
        lblDetalleTitulo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        lblDetalleTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblDetalleTitulo.Location = new Point(12, 10);
        lblDetalleTitulo.Name = "lblDetalleTitulo";
        lblDetalleTitulo.Size = new Size(450, 22);
        lblDetalleTitulo.TabIndex = 0;
        lblDetalleTitulo.Text = "Detalle del paquete";
        //
        // lblDetalleContenido
        //
        lblDetalleContenido.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        lblDetalleContenido.AutoSize = false;
        lblDetalleContenido.Location = new Point(12, 38);
        lblDetalleContenido.Name = "lblDetalleContenido";
        lblDetalleContenido.Size = new Size(450, 175);
        lblDetalleContenido.TabIndex = 1;
        //
        // dgvPaquetes
        //
        dgvPaquetes.AllowUserToAddRows = false;
        dgvPaquetes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvPaquetes.BackgroundColor = Color.White;
        dgvPaquetes.BorderStyle = BorderStyle.FixedSingle;
        dgvPaquetes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 58, 95);
        dgvPaquetes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgvPaquetes.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 58, 95);
        dgvPaquetes.EnableHeadersVisualStyles = false;
        dgvPaquetes.Columns.AddRange(new DataGridViewColumn[]
        {
            new DataGridViewTextBoxColumn { Name = nameof(MiniProye02.Models.Paquete.Codigo), DataPropertyName = nameof(MiniProye02.Models.Paquete.Codigo), HeaderText = "Código", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
            new DataGridViewTextBoxColumn { Name = nameof(MiniProye02.Models.Paquete.Cliente), DataPropertyName = nameof(MiniProye02.Models.Paquete.Cliente), HeaderText = "Cliente", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
            new DataGridViewTextBoxColumn { Name = nameof(MiniProye02.Models.Paquete.Zona), DataPropertyName = nameof(MiniProye02.Models.Paquete.Zona), HeaderText = "Zona", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
            new DataGridViewTextBoxColumn { Name = nameof(MiniProye02.Models.Paquete.Peso), DataPropertyName = nameof(MiniProye02.Models.Paquete.Peso), HeaderText = "Peso (kg)", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill },
            new DataGridViewTextBoxColumn { Name = nameof(MiniProye02.Models.Paquete.Total), DataPropertyName = nameof(MiniProye02.Models.Paquete.Total), HeaderText = "Total", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill }
        });
        dgvPaquetes.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 249, 249);
        dgvPaquetes.ReadOnly = true;
        dgvPaquetes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvPaquetes.MultiSelect = false;
        dgvPaquetes.Location = new Point(15, 320);
        dgvPaquetes.Name = "dgvPaquetes";
        dgvPaquetes.RowHeadersVisible = false;
        dgvPaquetes.Size = new Size(1070, 220);
        dgvPaquetes.TabIndex = 5;
        dgvPaquetes.CellClick += dgvPaquetes_CellClick;
        //
        // lblErroresTitulo
        //
        lblErroresTitulo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        lblErroresTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblErroresTitulo.Location = new Point(15, 550);
        lblErroresTitulo.Name = "lblErroresTitulo";
        lblErroresTitulo.Size = new Size(1070, 22);
        lblErroresTitulo.TabIndex = 6;
        lblErroresTitulo.Text = "Errores";
        //
        // lstErrores
        //
        lstErrores.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        lstErrores.BackColor = Color.FromArgb(255, 249, 230);
        lstErrores.BorderStyle = BorderStyle.FixedSingle;
        lstErrores.FormattingEnabled = true;
        lstErrores.HorizontalScrollbar = true;
        lstErrores.ItemHeight = 15;
        lstErrores.Location = new Point(15, 575);
        lstErrores.Name = "lstErrores";
        lstErrores.Size = new Size(1070, 92);
        lstErrores.TabIndex = 7;
        //
        // Form1
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(1100, 700);
        Controls.Add(lstErrores);
        Controls.Add(lblErroresTitulo);
        Controls.Add(dgvPaquetes);
        Controls.Add(panelDetalle);
        Controls.Add(panelBotones);
        Controls.Add(txtLote);
        Controls.Add(lblLblLote);
        Controls.Add(panelEncabezado);
        Font = new Font("Segoe UI", 9F, FontStyle.Regular);
        MinimumSize = new Size(900, 650);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "LogisticaFacturacion";
        Load += Form1_Load;
        panelEncabezado.ResumeLayout(false);
        panelBotones.ResumeLayout(false);
        panelDetalle.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvPaquetes).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
}
