namespace RMTools
{
  partial class FormPrincipal
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
      this.label1 = new System.Windows.Forms.Label();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.lbVersaoaLabel = new System.Windows.Forms.Label();
      this.lbVersao = new System.Windows.Forms.Label();
      this.bgWorkerAplicar = new System.ComponentModel.BackgroundWorker();
      this.lblMessage = new System.Windows.Forms.Label();
      this.lstAmbientes = new System.Windows.Forms.ListView();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.btnRefreshAmbientes = new System.Windows.Forms.Button();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.btnAbrirRmNet = new System.Windows.Forms.Button();
      this.grpConfig = new System.Windows.Forms.GroupBox();
      this.txbFileServerPath = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.txbDefaultDb = new System.Windows.Forms.TextBox();
      this.chbSmartClient = new System.Windows.Forms.CheckBox();
      this.grpSmartClient = new System.Windows.Forms.GroupBox();
      this.chbUpdateClient = new System.Windows.Forms.CheckBox();
      this.chbUpdateServer = new System.Windows.Forms.CheckBox();
      this.label3 = new System.Windows.Forms.Label();
      this.txbServidor = new System.Windows.Forms.TextBox();
      this.progressBarAplicar = new System.Windows.Forms.ProgressBar();
      this.chbTraceFileRmExe = new System.Windows.Forms.CheckBox();
      this.btnAplicar = new System.Windows.Forms.Button();
      this.label14 = new System.Windows.Forms.Label();
      this.chbNCamadas = new System.Windows.Forms.CheckBox();
      this.txbLocalizationLanguage = new System.Windows.Forms.TextBox();
      this.lstConfig = new System.Windows.Forms.ListBox();
      this.label13 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.txbPort = new System.Windows.Forms.TextBox();
      this.chbEnableCompression = new System.Windows.Forms.CheckBox();
      this.label12 = new System.Windows.Forms.Label();
      this.chbEnableDynamicLocalization = new System.Windows.Forms.CheckBox();
      this.txbLibPath = new System.Windows.Forms.TextBox();
      this.chbTraceFileHost = new System.Windows.Forms.CheckBox();
      this.label11 = new System.Windows.Forms.Label();
      this.chbTraceLS = new System.Windows.Forms.CheckBox();
      this.txbHost = new System.Windows.Forms.TextBox();
      this.txbActionsPath = new System.Windows.Forms.TextBox();
      this.label10 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.txbHttpPort = new System.Windows.Forms.TextBox();
      this.txbApiPort = new System.Windows.Forms.TextBox();
      this.label9 = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.pnlButtons = new System.Windows.Forms.Panel();
      this.btnAliasManager = new System.Windows.Forms.Button();
      this.btnEncerraAmbiente = new System.Windows.Forms.Button();
      this.btnApagarBroker = new System.Windows.Forms.Button();
      this.btnHostApp = new System.Windows.Forms.Button();
      this.btnRmexe = new System.Windows.Forms.Button();
      this.btnServiceManager = new System.Windows.Forms.Button();
      this.groupBox2.SuspendLayout();
      this.grpConfig.SuspendLayout();
      this.grpSmartClient.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.pnlButtons.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(9, 42);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(56, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Ambientes";
      // 
      // timer1
      // 
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // lbVersaoaLabel
      // 
      this.lbVersaoaLabel.AutoSize = true;
      this.lbVersaoaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
      this.lbVersaoaLabel.Location = new System.Drawing.Point(9, 9);
      this.lbVersaoaLabel.Name = "lbVersaoaLabel";
      this.lbVersaoaLabel.Size = new System.Drawing.Size(50, 13);
      this.lbVersaoaLabel.TabIndex = 33;
      this.lbVersaoaLabel.Text = "Versão:";
      // 
      // lbVersao
      // 
      this.lbVersao.AutoSize = true;
      this.lbVersao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
      this.lbVersao.Location = new System.Drawing.Point(65, 9);
      this.lbVersao.Name = "lbVersao";
      this.lbVersao.Size = new System.Drawing.Size(56, 13);
      this.lbVersao.TabIndex = 34;
      this.lbVersao.Text = "lbVersao";
      // 
      // bgWorkerAplicar
      // 
      this.bgWorkerAplicar.WorkerSupportsCancellation = true;
      this.bgWorkerAplicar.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
      this.bgWorkerAplicar.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
      // 
      // lblMessage
      // 
      this.lblMessage.AutoSize = true;
      this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblMessage.ForeColor = System.Drawing.SystemColors.Highlight;
      this.lblMessage.Location = new System.Drawing.Point(179, 4);
      this.lblMessage.Name = "lblMessage";
      this.lblMessage.Size = new System.Drawing.Size(99, 20);
      this.lblMessage.TabIndex = 34;
      this.lblMessage.Text = "lblMessage";
      this.lblMessage.Visible = false;
      // 
      // lstAmbientes
      // 
      this.lstAmbientes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.lstAmbientes.BackColor = System.Drawing.SystemColors.ButtonFace;
      this.lstAmbientes.BackgroundImageTiled = true;
      this.lstAmbientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.lstAmbientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lstAmbientes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
      this.lstAmbientes.HideSelection = false;
      this.lstAmbientes.Location = new System.Drawing.Point(3, 13);
      this.lstAmbientes.Name = "lstAmbientes";
      this.lstAmbientes.Size = new System.Drawing.Size(250, 443);
      this.lstAmbientes.TabIndex = 36;
      this.lstAmbientes.TileSize = new System.Drawing.Size(220, 30);
      this.lstAmbientes.UseCompatibleStateImageBehavior = false;
      this.lstAmbientes.View = System.Windows.Forms.View.Tile;
      this.lstAmbientes.DoubleClick += new System.EventHandler(this.lstAmbientes_DoubleClick);
      // 
      // groupBox2
      // 
      this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.groupBox2.Controls.Add(this.lstAmbientes);
      this.groupBox2.Location = new System.Drawing.Point(12, 60);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(259, 462);
      this.groupBox2.TabIndex = 37;
      this.groupBox2.TabStop = false;
      // 
      // btnRefreshAmbientes
      // 
      this.btnRefreshAmbientes.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.btnRefreshAmbientes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.btnRefreshAmbientes.FlatAppearance.BorderSize = 0;
      this.btnRefreshAmbientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnRefreshAmbientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnRefreshAmbientes.Location = new System.Drawing.Point(183, 35);
      this.btnRefreshAmbientes.Name = "btnRefreshAmbientes";
      this.btnRefreshAmbientes.Size = new System.Drawing.Size(56, 26);
      this.btnRefreshAmbientes.TabIndex = 37;
      this.btnRefreshAmbientes.Text = "Atualizar";
      this.btnRefreshAmbientes.UseVisualStyleBackColor = false;
      this.btnRefreshAmbientes.Click += new System.EventHandler(this.btnRefreshAmbientes_Click);
      // 
      // btnAbrirRmNet
      // 
      this.btnAbrirRmNet.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.btnAbrirRmNet.BackgroundImage = global::RMTools.Properties.Resources.Icone_Pasta;
      this.btnAbrirRmNet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btnAbrirRmNet.FlatAppearance.BorderSize = 0;
      this.btnAbrirRmNet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnAbrirRmNet.Location = new System.Drawing.Point(245, 35);
      this.btnAbrirRmNet.Name = "btnAbrirRmNet";
      this.btnAbrirRmNet.Size = new System.Drawing.Size(26, 26);
      this.btnAbrirRmNet.TabIndex = 6;
      this.btnAbrirRmNet.UseVisualStyleBackColor = false;
      this.btnAbrirRmNet.Click += new System.EventHandler(this.btnAbrirRmNet_Click);
      // 
      // grpConfig
      // 
      this.grpConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.grpConfig.Controls.Add(this.txbFileServerPath);
      this.grpConfig.Controls.Add(this.label6);
      this.grpConfig.Controls.Add(this.label5);
      this.grpConfig.Controls.Add(this.txbDefaultDb);
      this.grpConfig.Controls.Add(this.chbSmartClient);
      this.grpConfig.Controls.Add(this.grpSmartClient);
      this.grpConfig.Controls.Add(this.progressBarAplicar);
      this.grpConfig.Controls.Add(this.chbTraceFileRmExe);
      this.grpConfig.Controls.Add(this.btnAplicar);
      this.grpConfig.Controls.Add(this.label14);
      this.grpConfig.Controls.Add(this.chbNCamadas);
      this.grpConfig.Controls.Add(this.txbLocalizationLanguage);
      this.grpConfig.Controls.Add(this.lstConfig);
      this.grpConfig.Controls.Add(this.label13);
      this.grpConfig.Controls.Add(this.label2);
      this.grpConfig.Controls.Add(this.txbPort);
      this.grpConfig.Controls.Add(this.chbEnableCompression);
      this.grpConfig.Controls.Add(this.label12);
      this.grpConfig.Controls.Add(this.chbEnableDynamicLocalization);
      this.grpConfig.Controls.Add(this.txbLibPath);
      this.grpConfig.Controls.Add(this.chbTraceFileHost);
      this.grpConfig.Controls.Add(this.label11);
      this.grpConfig.Controls.Add(this.chbTraceLS);
      this.grpConfig.Controls.Add(this.txbHost);
      this.grpConfig.Controls.Add(this.txbActionsPath);
      this.grpConfig.Controls.Add(this.label10);
      this.grpConfig.Controls.Add(this.label4);
      this.grpConfig.Controls.Add(this.txbHttpPort);
      this.grpConfig.Controls.Add(this.txbApiPort);
      this.grpConfig.Controls.Add(this.label9);
      this.grpConfig.Location = new System.Drawing.Point(277, 119);
      this.grpConfig.Name = "grpConfig";
      this.grpConfig.Size = new System.Drawing.Size(727, 403);
      this.grpConfig.TabIndex = 38;
      this.grpConfig.TabStop = false;
      // 
      // txbFileServerPath
      // 
      this.txbFileServerPath.Location = new System.Drawing.Point(11, 298);
      this.txbFileServerPath.Name = "txbFileServerPath";
      this.txbFileServerPath.Size = new System.Drawing.Size(397, 20);
      this.txbFileServerPath.TabIndex = 39;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(8, 282);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(76, 13);
      this.label6.TabIndex = 38;
      this.label6.Text = "FileServerPath";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(8, 161);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(56, 13);
      this.label5.TabIndex = 37;
      this.label5.Text = "DefaultDB";
      // 
      // txbDefaultDb
      // 
      this.txbDefaultDb.Location = new System.Drawing.Point(11, 177);
      this.txbDefaultDb.Name = "txbDefaultDb";
      this.txbDefaultDb.Size = new System.Drawing.Size(156, 20);
      this.txbDefaultDb.TabIndex = 14;
      // 
      // chbSmartClient
      // 
      this.chbSmartClient.AutoSize = true;
      this.chbSmartClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.chbSmartClient.Location = new System.Drawing.Point(11, 65);
      this.chbSmartClient.Name = "chbSmartClient";
      this.chbSmartClient.Size = new System.Drawing.Size(117, 17);
      this.chbSmartClient.TabIndex = 7;
      this.chbSmartClient.Text = "Habilitar SmartClient";
      this.chbSmartClient.UseVisualStyleBackColor = true;
      // 
      // grpSmartClient
      // 
      this.grpSmartClient.Controls.Add(this.chbUpdateClient);
      this.grpSmartClient.Controls.Add(this.chbUpdateServer);
      this.grpSmartClient.Controls.Add(this.label3);
      this.grpSmartClient.Controls.Add(this.txbServidor);
      this.grpSmartClient.Enabled = false;
      this.grpSmartClient.Location = new System.Drawing.Point(11, 79);
      this.grpSmartClient.Name = "grpSmartClient";
      this.grpSmartClient.Size = new System.Drawing.Size(403, 38);
      this.grpSmartClient.TabIndex = 35;
      this.grpSmartClient.TabStop = false;
      // 
      // chbUpdateClient
      // 
      this.chbUpdateClient.AutoSize = true;
      this.chbUpdateClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.chbUpdateClient.Location = new System.Drawing.Point(112, 12);
      this.chbUpdateClient.Name = "chbUpdateClient";
      this.chbUpdateClient.Size = new System.Drawing.Size(90, 17);
      this.chbUpdateClient.TabIndex = 9;
      this.chbUpdateClient.Text = "Habilitar Client";
      this.chbUpdateClient.UseVisualStyleBackColor = true;
      // 
      // chbUpdateServer
      // 
      this.chbUpdateServer.AutoSize = true;
      this.chbUpdateServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.chbUpdateServer.Location = new System.Drawing.Point(9, 12);
      this.chbUpdateServer.Name = "chbUpdateServer";
      this.chbUpdateServer.Size = new System.Drawing.Size(95, 17);
      this.chbUpdateServer.TabIndex = 8;
      this.chbUpdateServer.Text = "Habilitar Server";
      this.chbUpdateServer.UseVisualStyleBackColor = true;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(208, 14);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(51, 13);
      this.label3.TabIndex = 38;
      this.label3.Text = "Host:Port";
      // 
      // txbServidor
      // 
      this.txbServidor.Location = new System.Drawing.Point(265, 11);
      this.txbServidor.Name = "txbServidor";
      this.txbServidor.Size = new System.Drawing.Size(132, 20);
      this.txbServidor.TabIndex = 37;
      // 
      // progressBarAplicar
      // 
      this.progressBarAplicar.Location = new System.Drawing.Point(11, 348);
      this.progressBarAplicar.Name = "progressBarAplicar";
      this.progressBarAplicar.Size = new System.Drawing.Size(205, 23);
      this.progressBarAplicar.TabIndex = 33;
      this.progressBarAplicar.Visible = false;
      // 
      // chbTraceFileRmExe
      // 
      this.chbTraceFileRmExe.AutoSize = true;
      this.chbTraceFileRmExe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.chbTraceFileRmExe.Location = new System.Drawing.Point(136, 42);
      this.chbTraceFileRmExe.Name = "chbTraceFileRmExe";
      this.chbTraceFileRmExe.Size = new System.Drawing.Size(113, 17);
      this.chbTraceFileRmExe.TabIndex = 5;
      this.chbTraceFileRmExe.Text = "TraceFile (RM.exe)";
      this.chbTraceFileRmExe.UseVisualStyleBackColor = true;
      // 
      // btnAplicar
      // 
      this.btnAplicar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.btnAplicar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.btnAplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnAplicar.Location = new System.Drawing.Point(222, 348);
      this.btnAplicar.Name = "btnAplicar";
      this.btnAplicar.Size = new System.Drawing.Size(90, 23);
      this.btnAplicar.TabIndex = 18;
      this.btnAplicar.Text = "Aplicar";
      this.btnAplicar.UseVisualStyleBackColor = false;
      // 
      // label14
      // 
      this.label14.AutoSize = true;
      this.label14.Location = new System.Drawing.Point(173, 161);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(111, 13);
      this.label14.TabIndex = 28;
      this.label14.Text = "LocalizationLanguage\r\n";
      // 
      // chbNCamadas
      // 
      this.chbNCamadas.AutoSize = true;
      this.chbNCamadas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.chbNCamadas.Location = new System.Drawing.Point(11, 19);
      this.chbNCamadas.Name = "chbNCamadas";
      this.chbNCamadas.Size = new System.Drawing.Size(78, 17);
      this.chbNCamadas.TabIndex = 1;
      this.chbNCamadas.Text = "N Camadas";
      this.chbNCamadas.UseVisualStyleBackColor = true;
      // 
      // txbLocalizationLanguage
      // 
      this.txbLocalizationLanguage.Location = new System.Drawing.Point(176, 177);
      this.txbLocalizationLanguage.Name = "txbLocalizationLanguage";
      this.txbLocalizationLanguage.Size = new System.Drawing.Size(108, 20);
      this.txbLocalizationLanguage.TabIndex = 15;
      // 
      // lstConfig
      // 
      this.lstConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lstConfig.Enabled = false;
      this.lstConfig.FormattingEnabled = true;
      this.lstConfig.Location = new System.Drawing.Point(433, 42);
      this.lstConfig.Name = "lstConfig";
      this.lstConfig.Size = new System.Drawing.Size(288, 329);
      this.lstConfig.TabIndex = 7;
      // 
      // label13
      // 
      this.label13.AutoSize = true;
      this.label13.Location = new System.Drawing.Point(229, 122);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(26, 13);
      this.label13.TabIndex = 26;
      this.label13.Text = "Port";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(431, 17);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(84, 13);
      this.label2.TabIndex = 8;
      this.label2.Text = "Arquivos Config:";
      // 
      // txbPort
      // 
      this.txbPort.Location = new System.Drawing.Point(232, 138);
      this.txbPort.Name = "txbPort";
      this.txbPort.Size = new System.Drawing.Size(52, 20);
      this.txbPort.TabIndex = 11;
      // 
      // chbEnableCompression
      // 
      this.chbEnableCompression.AutoSize = true;
      this.chbEnableCompression.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.chbEnableCompression.Location = new System.Drawing.Point(298, 17);
      this.chbEnableCompression.Name = "chbEnableCompression";
      this.chbEnableCompression.Size = new System.Drawing.Size(116, 17);
      this.chbEnableCompression.TabIndex = 3;
      this.chbEnableCompression.Text = "EnableCompression";
      this.chbEnableCompression.UseVisualStyleBackColor = true;
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Location = new System.Drawing.Point(8, 200);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(43, 13);
      this.label12.TabIndex = 24;
      this.label12.Text = "LibPath";
      // 
      // chbEnableDynamicLocalization
      // 
      this.chbEnableDynamicLocalization.AutoSize = true;
      this.chbEnableDynamicLocalization.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.chbEnableDynamicLocalization.Location = new System.Drawing.Point(136, 17);
      this.chbEnableDynamicLocalization.Name = "chbEnableDynamicLocalization";
      this.chbEnableDynamicLocalization.Size = new System.Drawing.Size(153, 17);
      this.chbEnableDynamicLocalization.TabIndex = 2;
      this.chbEnableDynamicLocalization.Text = "EnableDynamicLocalization";
      this.chbEnableDynamicLocalization.UseVisualStyleBackColor = true;
      // 
      // txbLibPath
      // 
      this.txbLibPath.Location = new System.Drawing.Point(11, 216);
      this.txbLibPath.Name = "txbLibPath";
      this.txbLibPath.Size = new System.Drawing.Size(397, 20);
      this.txbLibPath.TabIndex = 16;
      // 
      // chbTraceFileHost
      // 
      this.chbTraceFileHost.AutoSize = true;
      this.chbTraceFileHost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.chbTraceFileHost.Location = new System.Drawing.Point(11, 42);
      this.chbTraceFileHost.Name = "chbTraceFileHost";
      this.chbTraceFileHost.Size = new System.Drawing.Size(98, 17);
      this.chbTraceFileHost.TabIndex = 4;
      this.chbTraceFileHost.Text = "TraceFile (Host)";
      this.chbTraceFileHost.UseVisualStyleBackColor = true;
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(8, 122);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(29, 13);
      this.label11.TabIndex = 22;
      this.label11.Text = "Host";
      // 
      // chbTraceLS
      // 
      this.chbTraceLS.AutoSize = true;
      this.chbTraceLS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.chbTraceLS.Location = new System.Drawing.Point(298, 42);
      this.chbTraceLS.Name = "chbTraceLS";
      this.chbTraceLS.Size = new System.Drawing.Size(64, 17);
      this.chbTraceLS.TabIndex = 6;
      this.chbTraceLS.Text = "TraceLS";
      this.chbTraceLS.UseVisualStyleBackColor = true;
      // 
      // txbHost
      // 
      this.txbHost.Location = new System.Drawing.Point(11, 138);
      this.txbHost.Name = "txbHost";
      this.txbHost.Size = new System.Drawing.Size(210, 20);
      this.txbHost.TabIndex = 10;
      // 
      // txbActionsPath
      // 
      this.txbActionsPath.Location = new System.Drawing.Point(11, 255);
      this.txbActionsPath.Name = "txbActionsPath";
      this.txbActionsPath.Size = new System.Drawing.Size(397, 20);
      this.txbActionsPath.TabIndex = 17;
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(291, 122);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(46, 13);
      this.label10.TabIndex = 20;
      this.label10.Text = "HttpPort";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(8, 239);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(64, 13);
      this.label4.TabIndex = 16;
      this.label4.Text = "ActionsPath";
      // 
      // txbHttpPort
      // 
      this.txbHttpPort.Location = new System.Drawing.Point(294, 138);
      this.txbHttpPort.Name = "txbHttpPort";
      this.txbHttpPort.Size = new System.Drawing.Size(52, 20);
      this.txbHttpPort.TabIndex = 12;
      // 
      // txbApiPort
      // 
      this.txbApiPort.Location = new System.Drawing.Point(356, 138);
      this.txbApiPort.Name = "txbApiPort";
      this.txbApiPort.Size = new System.Drawing.Size(52, 20);
      this.txbApiPort.TabIndex = 13;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(353, 122);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(41, 13);
      this.label9.TabIndex = 18;
      this.label9.Text = "ApiPort";
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.pnlButtons);
      this.groupBox1.Location = new System.Drawing.Point(277, 60);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(727, 53);
      this.groupBox1.TabIndex = 39;
      this.groupBox1.TabStop = false;
      // 
      // pnlButtons
      // 
      this.pnlButtons.Controls.Add(this.btnAliasManager);
      this.pnlButtons.Controls.Add(this.btnEncerraAmbiente);
      this.pnlButtons.Controls.Add(this.btnApagarBroker);
      this.pnlButtons.Controls.Add(this.btnHostApp);
      this.pnlButtons.Controls.Add(this.btnRmexe);
      this.pnlButtons.Controls.Add(this.btnServiceManager);
      this.pnlButtons.Location = new System.Drawing.Point(6, 13);
      this.pnlButtons.Name = "pnlButtons";
      this.pnlButtons.Size = new System.Drawing.Size(710, 34);
      this.pnlButtons.TabIndex = 32;
      // 
      // btnAliasManager
      // 
      this.btnAliasManager.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.btnAliasManager.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btnAliasManager.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.btnAliasManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnAliasManager.Location = new System.Drawing.Point(330, 5);
      this.btnAliasManager.Name = "btnAliasManager";
      this.btnAliasManager.Size = new System.Drawing.Size(103, 26);
      this.btnAliasManager.TabIndex = 3;
      this.btnAliasManager.Text = "Alias Manager";
      this.btnAliasManager.UseVisualStyleBackColor = false;
      // 
      // btnEncerraAmbiente
      // 
      this.btnEncerraAmbiente.BackColor = System.Drawing.Color.Red;
      this.btnEncerraAmbiente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btnEncerraAmbiente.FlatAppearance.BorderColor = System.Drawing.Color.Red;
      this.btnEncerraAmbiente.FlatAppearance.BorderSize = 0;
      this.btnEncerraAmbiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnEncerraAmbiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnEncerraAmbiente.ForeColor = System.Drawing.SystemColors.ControlLightLight;
      this.btnEncerraAmbiente.Location = new System.Drawing.Point(548, 5);
      this.btnEncerraAmbiente.Name = "btnEncerraAmbiente";
      this.btnEncerraAmbiente.Size = new System.Drawing.Size(120, 26);
      this.btnEncerraAmbiente.TabIndex = 5;
      this.btnEncerraAmbiente.Text = "Encerrar Ambiente";
      this.btnEncerraAmbiente.UseVisualStyleBackColor = false;
      this.btnEncerraAmbiente.Visible = false;
      // 
      // btnApagarBroker
      // 
      this.btnApagarBroker.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.btnApagarBroker.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btnApagarBroker.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.btnApagarBroker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnApagarBroker.Location = new System.Drawing.Point(439, 5);
      this.btnApagarBroker.Name = "btnApagarBroker";
      this.btnApagarBroker.Size = new System.Drawing.Size(103, 26);
      this.btnApagarBroker.TabIndex = 4;
      this.btnApagarBroker.Text = "Apagar _Broker";
      this.btnApagarBroker.UseVisualStyleBackColor = false;
      // 
      // btnHostApp
      // 
      this.btnHostApp.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.btnHostApp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btnHostApp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.btnHostApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnHostApp.Location = new System.Drawing.Point(112, 5);
      this.btnHostApp.Name = "btnHostApp";
      this.btnHostApp.Size = new System.Drawing.Size(103, 26);
      this.btnHostApp.TabIndex = 1;
      this.btnHostApp.Text = "Host App";
      this.btnHostApp.UseVisualStyleBackColor = false;
      // 
      // btnRmexe
      // 
      this.btnRmexe.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.btnRmexe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btnRmexe.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.btnRmexe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnRmexe.Location = new System.Drawing.Point(3, 5);
      this.btnRmexe.Name = "btnRmexe";
      this.btnRmexe.Size = new System.Drawing.Size(103, 26);
      this.btnRmexe.TabIndex = 0;
      this.btnRmexe.Text = "RM.exe";
      this.btnRmexe.UseVisualStyleBackColor = false;
      // 
      // btnServiceManager
      // 
      this.btnServiceManager.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.btnServiceManager.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btnServiceManager.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.btnServiceManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnServiceManager.Location = new System.Drawing.Point(221, 5);
      this.btnServiceManager.Name = "btnServiceManager";
      this.btnServiceManager.Size = new System.Drawing.Size(103, 26);
      this.btnServiceManager.TabIndex = 2;
      this.btnServiceManager.Text = "Service Manager";
      this.btnServiceManager.UseVisualStyleBackColor = false;
      // 
      // FormPrincipal
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1035, 534);
      this.Controls.Add(this.grpConfig);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.btnAbrirRmNet);
      this.Controls.Add(this.btnRefreshAmbientes);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.lblMessage);
      this.Controls.Add(this.lbVersao);
      this.Controls.Add(this.lbVersaoaLabel);
      this.Controls.Add(this.label1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MinimumSize = new System.Drawing.Size(1051, 573);
      this.Name = "FormPrincipal";
      this.Text = "RM Tools";
      this.Load += new System.EventHandler(this.FormPrincipal_Load);
      this.groupBox2.ResumeLayout(false);
      this.grpConfig.ResumeLayout(false);
      this.grpConfig.PerformLayout();
      this.grpSmartClient.ResumeLayout(false);
      this.grpSmartClient.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.pnlButtons.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.Label lbVersaoaLabel;
    private System.Windows.Forms.Label lbVersao;
    private System.ComponentModel.BackgroundWorker bgWorkerAplicar;
    private System.Windows.Forms.Label lblMessage;
    private System.Windows.Forms.ListView lstAmbientes;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.Button btnRefreshAmbientes;
    private System.Windows.Forms.Button btnAbrirRmNet;
    private System.Windows.Forms.GroupBox grpConfig;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txbDefaultDb;
    private System.Windows.Forms.CheckBox chbSmartClient;
    private System.Windows.Forms.GroupBox grpSmartClient;
    private System.Windows.Forms.CheckBox chbUpdateClient;
    private System.Windows.Forms.CheckBox chbUpdateServer;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txbServidor;
    private System.Windows.Forms.ProgressBar progressBarAplicar;
    private System.Windows.Forms.CheckBox chbTraceFileRmExe;
    private System.Windows.Forms.Button btnAplicar;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.CheckBox chbNCamadas;
    private System.Windows.Forms.TextBox txbLocalizationLanguage;
    private System.Windows.Forms.ListBox lstConfig;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txbPort;
    private System.Windows.Forms.CheckBox chbEnableCompression;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.CheckBox chbEnableDynamicLocalization;
    private System.Windows.Forms.TextBox txbLibPath;
    private System.Windows.Forms.CheckBox chbTraceFileHost;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.CheckBox chbTraceLS;
    private System.Windows.Forms.TextBox txbHost;
    private System.Windows.Forms.TextBox txbActionsPath;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txbHttpPort;
    private System.Windows.Forms.TextBox txbApiPort;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Panel pnlButtons;
    private System.Windows.Forms.Button btnAliasManager;
    private System.Windows.Forms.Button btnEncerraAmbiente;
    private System.Windows.Forms.Button btnApagarBroker;
    private System.Windows.Forms.Button btnHostApp;
    private System.Windows.Forms.Button btnRmexe;
    private System.Windows.Forms.Button btnServiceManager;
    private System.Windows.Forms.TextBox txbFileServerPath;
    private System.Windows.Forms.Label label6;
  }
}

