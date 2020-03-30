namespace TestConnectionClient
{
  partial class FormClient
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClient));
      this.txbPort = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.btnIniciar = new System.Windows.Forms.Button();
      this.txbIntervalo = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.txbIP = new System.Windows.Forms.TextBox();
      this.pnlCampos = new System.Windows.Forms.Panel();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.txbLog = new System.Windows.Forms.TextBox();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.picGif = new System.Windows.Forms.PictureBox();
      this.pnlCampos.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.picGif)).BeginInit();
      this.SuspendLayout();
      // 
      // txbPort
      // 
      resources.ApplyResources(this.txbPort, "txbPort");
      this.txbPort.Name = "txbPort";
      // 
      // label1
      // 
      resources.ApplyResources(this.label1, "label1");
      this.label1.Name = "label1";
      // 
      // label2
      // 
      resources.ApplyResources(this.label2, "label2");
      this.label2.Name = "label2";
      // 
      // btnIniciar
      // 
      resources.ApplyResources(this.btnIniciar, "btnIniciar");
      this.btnIniciar.Name = "btnIniciar";
      this.btnIniciar.UseVisualStyleBackColor = true;
      this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
      // 
      // txbIntervalo
      // 
      resources.ApplyResources(this.txbIntervalo, "txbIntervalo");
      this.txbIntervalo.Name = "txbIntervalo";
      this.txbIntervalo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
      // 
      // label3
      // 
      resources.ApplyResources(this.label3, "label3");
      this.label3.Name = "label3";
      // 
      // txbIP
      // 
      resources.ApplyResources(this.txbIP, "txbIP");
      this.txbIP.Name = "txbIP";
      // 
      // pnlCampos
      // 
      this.pnlCampos.Controls.Add(this.label3);
      this.pnlCampos.Controls.Add(this.txbIP);
      this.pnlCampos.Controls.Add(this.txbPort);
      this.pnlCampos.Controls.Add(this.label1);
      this.pnlCampos.Controls.Add(this.txbIntervalo);
      this.pnlCampos.Controls.Add(this.label2);
      resources.ApplyResources(this.pnlCampos, "pnlCampos");
      this.pnlCampos.Name = "pnlCampos";
      // 
      // toolTip1
      // 
      this.toolTip1.AutomaticDelay = 300;
      // 
      // txbLog
      // 
      resources.ApplyResources(this.txbLog, "txbLog");
      this.txbLog.Name = "txbLog";
      // 
      // timer1
      // 
      this.timer1.Interval = 1000;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // picGif
      // 
      resources.ApplyResources(this.picGif, "picGif");
      this.picGif.Name = "picGif";
      this.picGif.TabStop = false;
      // 
      // FormClient
      // 
      this.AcceptButton = this.btnIniciar;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.picGif);
      this.Controls.Add(this.txbLog);
      this.Controls.Add(this.pnlCampos);
      this.Controls.Add(this.btnIniciar);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "FormClient";
      this.pnlCampos.ResumeLayout(false);
      this.pnlCampos.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.picGif)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txbPort;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btnIniciar;
    private System.Windows.Forms.TextBox txbIntervalo;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txbIP;
    private System.Windows.Forms.Panel pnlCampos;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.TextBox txbLog;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.PictureBox picGif;
  }
}

