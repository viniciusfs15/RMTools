namespace RMTools
{
  partial class FormSelecionarDiretorioPadrao
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
      this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
      this.txtDiretorio = new System.Windows.Forms.TextBox();
      this.btnSelecionar = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.btnSalvar = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // txtDiretorio
      // 
      this.txtDiretorio.Location = new System.Drawing.Point(10, 29);
      this.txtDiretorio.Name = "txtDiretorio";
      this.txtDiretorio.Size = new System.Drawing.Size(193, 20);
      this.txtDiretorio.TabIndex = 0;
      // 
      // btnSelecionar
      // 
      this.btnSelecionar.Location = new System.Drawing.Point(209, 27);
      this.btnSelecionar.Name = "btnSelecionar";
      this.btnSelecionar.Size = new System.Drawing.Size(75, 23);
      this.btnSelecionar.TabIndex = 1;
      this.btnSelecionar.Text = "Selecionar";
      this.btnSelecionar.UseVisualStyleBackColor = true;
      this.btnSelecionar.Click += new System.EventHandler(this.btnSelecionar_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(7, 13);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(125, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Selecione o diretório raiz:";
      // 
      // btnSalvar
      // 
      this.btnSalvar.Location = new System.Drawing.Point(209, 66);
      this.btnSalvar.Name = "btnSalvar";
      this.btnSalvar.Size = new System.Drawing.Size(75, 23);
      this.btnSalvar.TabIndex = 3;
      this.btnSalvar.Text = "Salvar";
      this.btnSalvar.UseVisualStyleBackColor = true;
      this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
      // 
      // FormSelecionarDiretorioPadrao
      // 
      this.AcceptButton = this.btnSalvar;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(295, 104);
      this.Controls.Add(this.btnSalvar);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btnSelecionar);
      this.Controls.Add(this.txtDiretorio);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "FormSelecionarDiretorioPadrao";
      this.Text = "Diretorio raiz";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    private System.Windows.Forms.TextBox txtDiretorio;
    private System.Windows.Forms.Button btnSelecionar;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnSalvar;
  }
}