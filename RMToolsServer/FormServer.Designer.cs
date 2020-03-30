namespace TestConnectionServer
{
  partial class FormServer
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormServer));
      this.btnIniciar = new System.Windows.Forms.Button();
      this.txbPort = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.txbLog = new System.Windows.Forms.TextBox();
      this.picBox = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
      this.SuspendLayout();
      // 
      // btnIniciar
      // 
      resources.ApplyResources(this.btnIniciar, "btnIniciar");
      this.btnIniciar.Name = "btnIniciar";
      this.btnIniciar.UseVisualStyleBackColor = true;
      this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
      // 
      // txbPort
      // 
      resources.ApplyResources(this.txbPort, "txbPort");
      this.txbPort.Name = "txbPort";
      this.txbPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbPort_KeyPress);
      // 
      // label1
      // 
      resources.ApplyResources(this.label1, "label1");
      this.label1.Name = "label1";
      // 
      // txbLog
      // 
      resources.ApplyResources(this.txbLog, "txbLog");
      this.txbLog.Name = "txbLog";
      // 
      // picBox
      // 
      resources.ApplyResources(this.picBox, "picBox");
      this.picBox.Name = "picBox";
      this.picBox.TabStop = false;
      // 
      // FormServer
      // 
      this.AcceptButton = this.btnIniciar;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.txbLog);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txbPort);
      this.Controls.Add(this.btnIniciar);
      this.Controls.Add(this.picBox);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "FormServer";
      ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnIniciar;
    private System.Windows.Forms.TextBox txbPort;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txbLog;
    private System.Windows.Forms.PictureBox picBox;
  }
}

