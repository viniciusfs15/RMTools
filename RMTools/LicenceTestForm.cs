
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace TOTVS.Licence.Test
{
  // Token: 0x0200000A RID: 10
  public class LicenceTestForm : Form
  {
    // Token: 0x06000046 RID: 70 RVA: 0x000036B4 File Offset: 0x000018B4
    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
      {
        this.components.Dispose();
      }
      base.Dispose(disposing);
    }

    // Token: 0x06000047 RID: 71 RVA: 0x000036EC File Offset: 0x000018EC
    private void InitializeComponent()
    {
      this.components = new Container();
      DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
      this.label1 = new Label();
      this.tbServerIP = new TextBox();
      this.tbServerPort = new TextBox();
      this.label2 = new Label();
      this.tbLicence = new TextBox();
      this.label3 = new Label();
      this.groupBox1 = new GroupBox();
      this.splitContainer2 = new SplitContainer();
      this.cbRenewCredential = new CheckBox();
      this.label4 = new Label();
      this.tbEnCred = new TextBox();
      this.label5 = new Label();
      this.tbEnLic = new TextBox();
      this.groupBox2 = new GroupBox();
      this.dataGridView1 = new DataGridView();
      this.credentialDataGridViewImageColumn = new DataGridViewTextBoxColumn();
      this.Liberar = new DataGridViewButtonColumn();
      this.Column1 = new DataGridViewButtonColumn();
      this.bindingSource1 = new BindingSource(this.components);
      this.dsLicences1 = new DSLicences();
      this.label6 = new Label();
      this.tbRvLic = new TextBox();
      this.label7 = new Label();
      this.tbRvCred = new TextBox();
      this.splitContainer1 = new SplitContainer();
      this.timerRenew = new System.Windows.Forms.Timer(this.components);
      this.lsResult = new ListBox();
      this.btnGetTotal = new Button();
      this.btnGetIdHL = new Button();
      this.btninitKey = new Button();
      this.btnEmergKey = new Button();
      this.button1 = new Button();
      this.button2 = new Button();
      this.tbTimeOut = new TextBox();
      this.label8 = new Label();
      this.bGetCode = new Button();
      this.label9 = new Label();
      this.tParentThreadID = new TextBox();
      this.groupBox3 = new GroupBox();
      this.radioButton2 = new RadioButton();
      this.radioButton1 = new RadioButton();
      this.btnConsumeLicence = new Button();
      this.tbRenewDelay = new TextBox();
      this.ckAutomaticRenew = new CheckBox();
      this.label10 = new Label();
      this.label11 = new Label();
      this.tbThreadID = new TextBox();
      this.label12 = new Label();
      this.numericUpDown1 = new NumericUpDown();
      this.button3 = new Button();
      this.groupBox1.SuspendLayout();
      ((ISupportInitialize)this.splitContainer2).BeginInit();
      this.splitContainer2.Panel1.SuspendLayout();
      this.splitContainer2.Panel2.SuspendLayout();
      this.splitContainer2.SuspendLayout();
      this.groupBox2.SuspendLayout();
      ((ISupportInitialize)this.dataGridView1).BeginInit();
      ((ISupportInitialize)this.bindingSource1).BeginInit();
      ((ISupportInitialize)this.dsLicences1).BeginInit();
      ((ISupportInitialize)this.splitContainer1).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.groupBox3.SuspendLayout();
      ((ISupportInitialize)this.numericUpDown1).BeginInit();
      base.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Location = new Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new Size(49, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Servidor:";
      this.tbServerIP.Location = new Point(15, 25);
      this.tbServerIP.Name = "tbServerIP";
      this.tbServerIP.Size = new Size(165, 20);
      this.tbServerIP.TabIndex = 2;
      this.tbServerIP.Text = "127.0.0.1";
      this.tbServerPort.Location = new Point(15, 62);
      this.tbServerPort.Name = "tbServerPort";
      this.tbServerPort.Size = new Size(45, 20);
      this.tbServerPort.TabIndex = 4;
      this.tbServerPort.Text = "5555";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(12, 46);
      this.label2.Name = "label2";
      this.label2.Size = new Size(35, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "Porta:";
      this.tbLicence.Location = new Point(66, 62);
      this.tbLicence.Name = "tbLicence";
      this.tbLicence.Size = new Size(46, 20);
      this.tbLicence.TabIndex = 6;
      this.tbLicence.Text = "599";
      this.label3.AutoSize = true;
      this.label3.Location = new Point(63, 46);
      this.label3.Name = "label3";
      this.label3.Size = new Size(48, 13);
      this.label3.TabIndex = 5;
      this.label3.Text = "Licença:";
      this.groupBox1.Controls.Add(this.splitContainer2);
      this.groupBox1.Dock = DockStyle.Fill;
      this.groupBox1.Location = new Point(0, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(227, 488);
      this.groupBox1.TabIndex = 10;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Envio";
      this.splitContainer2.Dock = DockStyle.Fill;
      this.splitContainer2.Location = new Point(3, 16);
      this.splitContainer2.Name = "splitContainer2";
      this.splitContainer2.Orientation = Orientation.Horizontal;
      this.splitContainer2.Panel1.Controls.Add(this.cbRenewCredential);
      this.splitContainer2.Panel1.Controls.Add(this.label4);
      this.splitContainer2.Panel1.Controls.Add(this.tbEnCred);
      this.splitContainer2.Panel2.Controls.Add(this.label5);
      this.splitContainer2.Panel2.Controls.Add(this.tbEnLic);
      this.splitContainer2.Size = new Size(221, 469);
      this.splitContainer2.SplitterDistance = 271;
      this.splitContainer2.TabIndex = 0;
      this.cbRenewCredential.AutoSize = true;
      this.cbRenewCredential.Location = new Point(63, 6);
      this.cbRenewCredential.Name = "cbRenewCredential";
      this.cbRenewCredential.Size = new Size(156, 17);
      this.cbRenewCredential.TabIndex = 4;
      this.cbRenewCredential.Text = "Renovar a cada solicitação";
      this.cbRenewCredential.UseVisualStyleBackColor = true;
      this.label4.AutoSize = true;
      this.label4.Location = new Point(3, 7);
      this.label4.Name = "label4";
      this.label4.Size = new Size(54, 13);
      this.label4.TabIndex = 1;
      this.label4.Text = "Credential";
      this.tbEnCred.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
      this.tbEnCred.Location = new Point(3, 23);
      this.tbEnCred.Multiline = true;
      this.tbEnCred.Name = "tbEnCred";
      this.tbEnCred.Size = new Size(215, 245);
      this.tbEnCred.TabIndex = 0;
      this.label5.AutoSize = true;
      this.label5.Location = new Point(3, 6);
      this.label5.Name = "label5";
      this.label5.Size = new Size(113, 13);
      this.label5.TabIndex = 3;
      this.label5.Text = "Get /  Renew Licence";
      this.tbEnLic.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
      this.tbEnLic.Location = new Point(3, 22);
      this.tbEnLic.Multiline = true;
      this.tbEnLic.Name = "tbEnLic";
      this.tbEnLic.Size = new Size(215, 168);
      this.tbEnLic.TabIndex = 2;
      this.groupBox2.Controls.Add(this.dataGridView1);
      this.groupBox2.Controls.Add(this.label6);
      this.groupBox2.Controls.Add(this.tbRvLic);
      this.groupBox2.Controls.Add(this.label7);
      this.groupBox2.Controls.Add(this.tbRvCred);
      this.groupBox2.Dock = DockStyle.Fill;
      this.groupBox2.Location = new Point(0, 0);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(363, 488);
      this.groupBox2.TabIndex = 11;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Resposta";
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.AllowUserToOrderColumns = true;
      this.dataGridView1.AllowUserToResizeRows = false;
      dataGridViewCellStyle.BackColor = Color.LightBlue;
      this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle;
      this.dataGridView1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
      this.dataGridView1.AutoGenerateColumns = false;
      this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange(new DataGridViewColumn[]
      {
        this.credentialDataGridViewImageColumn,
        this.Liberar,
        this.Column1
      });
      this.dataGridView1.DataSource = this.bindingSource1;
      this.dataGridView1.Location = new Point(6, 127);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new Size(351, 358);
      this.dataGridView1.TabIndex = 12;
      this.dataGridView1.VirtualMode = true;
      this.dataGridView1.CellContentClick += this.dataGridView1_CellContentClick;
      this.dataGridView1.CellFormatting += this.dataGridView1_CellFormatting;
      this.credentialDataGridViewImageColumn.DataPropertyName = "Credential";
      this.credentialDataGridViewImageColumn.HeaderText = "Credential";
      this.credentialDataGridViewImageColumn.Name = "credentialDataGridViewImageColumn";
      this.credentialDataGridViewImageColumn.Resizable = DataGridViewTriState.True;
      this.credentialDataGridViewImageColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.credentialDataGridViewImageColumn.Width = 60;
      this.Liberar.HeaderText = "Liberação";
      this.Liberar.Name = "Liberar";
      this.Liberar.Text = "Liberar";
      this.Liberar.UseColumnTextForButtonValue = true;
      this.Liberar.Width = 60;
      this.Column1.DataPropertyName = "Credential";
      this.Column1.HeaderText = "Renovação";
      this.Column1.Name = "Column1";
      this.Column1.Resizable = DataGridViewTriState.True;
      this.Column1.Text = "Renovar";
      this.Column1.UseColumnTextForButtonValue = true;
      this.Column1.Width = 69;
      this.bindingSource1.DataMember = "Licences";
      this.bindingSource1.DataSource = this.dsLicences1;
      this.dsLicences1.DataSetName = "DSLicences";
      this.dsLicences1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      this.label6.AutoSize = true;
      this.label6.Location = new Point(7, 77);
      this.label6.Name = "label6";
      this.label6.Size = new Size(113, 13);
      this.label6.TabIndex = 11;
      this.label6.Text = "Get /  Renew Licence";
      this.tbRvLic.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
      this.tbRvLic.Location = new Point(7, 93);
      this.tbRvLic.Multiline = true;
      this.tbRvLic.Name = "tbRvLic";
      this.tbRvLic.Size = new Size(350, 28);
      this.tbRvLic.TabIndex = 10;
      this.label7.AutoSize = true;
      this.label7.Location = new Point(7, 23);
      this.label7.Name = "label7";
      this.label7.Size = new Size(54, 13);
      this.label7.TabIndex = 9;
      this.label7.Text = "Credential";
      this.tbRvCred.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
      this.tbRvCred.Location = new Point(7, 39);
      this.tbRvCred.Multiline = true;
      this.tbRvCred.Name = "tbRvCred";
      this.tbRvCred.Size = new Size(350, 30);
      this.tbRvCred.TabIndex = 8;
      this.splitContainer1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
      this.splitContainer1.Location = new Point(186, 0);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
      this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
      this.splitContainer1.Size = new Size(594, 488);
      this.splitContainer1.SplitterDistance = 227;
      this.splitContainer1.TabIndex = 13;
      this.timerRenew.Interval = 1000;
      this.timerRenew.Tick += this.timerRenew_Tick;
      this.lsResult.Dock = DockStyle.Bottom;
      this.lsResult.FormattingEnabled = true;
      this.lsResult.Location = new Point(0, 526);
      this.lsResult.Name = "lsResult";
      this.lsResult.ScrollAlwaysVisible = true;
      this.lsResult.Size = new Size(792, 199);
      this.lsResult.TabIndex = 16;
      this.lsResult.DoubleClick += this.lsResult_DoubleClick;
      this.btnGetTotal.Location = new Point(16, 320);
      this.btnGetTotal.Name = "btnGetTotal";
      this.btnGetTotal.Size = new Size(75, 23);
      this.btnGetTotal.TabIndex = 17;
      this.btnGetTotal.Text = "Get Total";
      this.btnGetTotal.UseVisualStyleBackColor = true;
      this.btnGetTotal.Click += this.btnGetTotal_Click;
      this.btnGetIdHL.Location = new Point(16, 349);
      this.btnGetIdHL.Name = "btnGetIdHL";
      this.btnGetIdHL.Size = new Size(75, 23);
      this.btnGetIdHL.TabIndex = 18;
      this.btnGetIdHL.Text = "Get Id HL";
      this.btnGetIdHL.UseVisualStyleBackColor = true;
      this.btnGetIdHL.Click += this.btnGetIdHL_Click;
      this.btninitKey.Location = new Point(16, 378);
      this.btninitKey.Name = "btninitKey";
      this.btninitKey.Size = new Size(118, 23);
      this.btninitKey.TabIndex = 19;
      this.btninitKey.Text = "Valida Chave Inicial";
      this.btninitKey.UseVisualStyleBackColor = true;
      this.btninitKey.Click += this.btninitKey_Click;
      this.btnEmergKey.Location = new Point(16, 407);
      this.btnEmergKey.Name = "btnEmergKey";
      this.btnEmergKey.Size = new Size(157, 23);
      this.btnEmergKey.TabIndex = 20;
      this.btnEmergKey.Text = "Valida Senha de Emergência";
      this.btnEmergKey.UseVisualStyleBackColor = true;
      this.btnEmergKey.Click += this.btnEmergKey_Click;
      this.button1.Location = new Point(16, 436);
      this.button1.Name = "button1";
      this.button1.Size = new Size(118, 23);
      this.button1.TabIndex = 21;
      this.button1.Text = "Get Total With Rules";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += this.button1_Click;
      this.button2.Location = new Point(16, 465);
      this.button2.Name = "button2";
      this.button2.Size = new Size(142, 23);
      this.button2.TabIndex = 22;
      this.button2.Text = "Get Available With Rules";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += this.button2_Click;
      this.tbTimeOut.Location = new Point(16, 101);
      this.tbTimeOut.Name = "tbTimeOut";
      this.tbTimeOut.Size = new Size(100, 20);
      this.tbTimeOut.TabIndex = 23;
      this.tbTimeOut.Text = "1";
      this.label8.AutoSize = true;
      this.label8.Location = new Point(13, 84);
      this.label8.Name = "label8";
      this.label8.Size = new Size(74, 13);
      this.label8.TabIndex = 24;
      this.label8.Text = "Timeout (seg.)";
      this.bGetCode.Location = new Point(101, 320);
      this.bGetCode.Name = "bGetCode";
      this.bGetCode.Size = new Size(75, 23);
      this.bGetCode.TabIndex = 25;
      this.bGetCode.Text = "Get Version";
      this.bGetCode.UseVisualStyleBackColor = true;
      this.bGetCode.Click += this.bGetCode_Click;
      this.label9.AutoSize = true;
      this.label9.Location = new Point(13, 168);
      this.label9.Name = "label9";
      this.label9.Size = new Size(89, 13);
      this.label9.TabIndex = 27;
      this.label9.Text = "Parent Thread ID";
      this.tParentThreadID.Location = new Point(16, 185);
      this.tParentThreadID.Name = "tParentThreadID";
      this.tParentThreadID.Size = new Size(100, 20);
      this.tParentThreadID.TabIndex = 26;
      this.tParentThreadID.Text = "9999";
      this.groupBox3.Controls.Add(this.radioButton2);
      this.groupBox3.Controls.Add(this.radioButton1);
      this.groupBox3.Location = new Point(15, 212);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new Size(143, 45);
      this.groupBox3.TabIndex = 28;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Funcionamento LS";
      this.radioButton2.AutoSize = true;
      this.radioButton2.Checked = true;
      this.radioButton2.Location = new Point(70, 22);
      this.radioButton2.Name = "radioButton2";
      this.radioButton2.Size = new Size(49, 17);
      this.radioButton2.TabIndex = 1;
      this.radioButton2.TabStop = true;
      this.radioButton2.Text = "2010";
      this.radioButton2.UseVisualStyleBackColor = true;
      this.radioButton2.CheckedChanged += this.radioButton2_CheckedChanged;
      this.radioButton1.AutoSize = true;
      this.radioButton1.Location = new Point(6, 22);
      this.radioButton1.Name = "radioButton1";
      this.radioButton1.Size = new Size(49, 17);
      this.radioButton1.TabIndex = 0;
      this.radioButton1.Text = "2009";
      this.radioButton1.UseVisualStyleBackColor = true;
      this.btnConsumeLicence.Location = new Point(12, 263);
      this.btnConsumeLicence.Name = "btnConsumeLicence";
      this.btnConsumeLicence.Size = new Size(67, 23);
      this.btnConsumeLicence.TabIndex = 0;
      this.btnConsumeLicence.Text = "Consumir";
      this.btnConsumeLicence.UseVisualStyleBackColor = true;
      this.btnConsumeLicence.Click += this.btnConsumeLicence_Click;
      this.tbRenewDelay.Location = new Point(122, 295);
      this.tbRenewDelay.Name = "tbRenewDelay";
      this.tbRenewDelay.ReadOnly = true;
      this.tbRenewDelay.Size = new Size(36, 20);
      this.tbRenewDelay.TabIndex = 14;
      this.ckAutomaticRenew.AutoSize = true;
      this.ckAutomaticRenew.Checked = true;
      this.ckAutomaticRenew.CheckState = CheckState.Checked;
      this.ckAutomaticRenew.Enabled = false;
      this.ckAutomaticRenew.Location = new Point(13, 298);
      this.ckAutomaticRenew.Name = "ckAutomaticRenew";
      this.ckAutomaticRenew.Size = new Size(15, 14);
      this.ckAutomaticRenew.TabIndex = 15;
      this.ckAutomaticRenew.UseVisualStyleBackColor = true;
      this.ckAutomaticRenew.CheckedChanged += this.ckAutomaticRenew_CheckedChanged;
      this.label10.AutoSize = true;
      this.label10.Location = new Point(27, 298);
      this.label10.Name = "label10";
      this.label10.Size = new Size(89, 13);
      this.label10.TabIndex = 29;
      this.label10.Text = "Renova tudo em:";
      this.label11.AutoSize = true;
      this.label11.Location = new Point(13, 128);
      this.label11.Name = "label11";
      this.label11.Size = new Size(55, 13);
      this.label11.TabIndex = 31;
      this.label11.Text = "Thread ID";
      this.tbThreadID.Location = new Point(16, 145);
      this.tbThreadID.Name = "tbThreadID";
      this.tbThreadID.Size = new Size(100, 20);
      this.tbThreadID.TabIndex = 30;
      this.tbThreadID.Text = "1";
      this.label12.AutoSize = true;
      this.label12.Location = new Point(125, 269);
      this.label12.Name = "label12";
      this.label12.Size = new Size(56, 13);
      this.label12.TabIndex = 1;
      this.label12.Text = "Licença(s)";
      this.numericUpDown1.Location = new Point(83, 266);
      NumericUpDown numericUpDown = this.numericUpDown1;
      int[] array = new int[4];
      array[0] = 1;
      numericUpDown.Minimum = new decimal(array);
      this.numericUpDown1.Name = "numericUpDown1";
      this.numericUpDown1.Size = new Size(39, 20);
      this.numericUpDown1.TabIndex = 33;
      NumericUpDown numericUpDown2 = this.numericUpDown1;
      array = new int[4];
      array[0] = 1;
      numericUpDown2.Value = new decimal(array);
      this.button3.Location = new Point(2, 498);
      this.button3.Name = "button3";
      this.button3.Size = new Size(68, 23);
      this.button3.TabIndex = 34;
      this.button3.Text = "Limpar Log";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += this.button3_Click;
      base.AutoScaleDimensions = new SizeF(6f, 13f);
      base.AutoScaleMode = AutoScaleMode.Font;
      base.ClientSize = new Size(792, 725);
      base.Controls.Add(this.button3);
      base.Controls.Add(this.numericUpDown1);
      base.Controls.Add(this.label12);
      base.Controls.Add(this.label11);
      base.Controls.Add(this.tbThreadID);
      base.Controls.Add(this.label10);
      base.Controls.Add(this.groupBox3);
      base.Controls.Add(this.label9);
      base.Controls.Add(this.tParentThreadID);
      base.Controls.Add(this.bGetCode);
      base.Controls.Add(this.label8);
      base.Controls.Add(this.tbTimeOut);
      base.Controls.Add(this.button2);
      base.Controls.Add(this.button1);
      base.Controls.Add(this.btnEmergKey);
      base.Controls.Add(this.btninitKey);
      base.Controls.Add(this.btnGetIdHL);
      base.Controls.Add(this.btnGetTotal);
      base.Controls.Add(this.lsResult);
      base.Controls.Add(this.ckAutomaticRenew);
      base.Controls.Add(this.tbRenewDelay);
      base.Controls.Add(this.splitContainer1);
      base.Controls.Add(this.tbLicence);
      base.Controls.Add(this.label3);
      base.Controls.Add(this.tbServerPort);
      base.Controls.Add(this.label2);
      base.Controls.Add(this.tbServerIP);
      base.Controls.Add(this.label1);
      base.Controls.Add(this.btnConsumeLicence);
      base.Name = "LicenceTestForm";
      this.Text = "Testar TOTVS Licence Server";
      base.FormClosing += this.Form1_FormClosing;
      this.groupBox1.ResumeLayout(false);
      this.splitContainer2.Panel1.ResumeLayout(false);
      this.splitContainer2.Panel1.PerformLayout();
      this.splitContainer2.Panel2.ResumeLayout(false);
      this.splitContainer2.Panel2.PerformLayout();
      ((ISupportInitialize)this.splitContainer2).EndInit();
      this.splitContainer2.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      ((ISupportInitialize)this.dataGridView1).EndInit();
      ((ISupportInitialize)this.bindingSource1).EndInit();
      ((ISupportInitialize)this.dsLicences1).EndInit();
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((ISupportInitialize)this.splitContainer1).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      ((ISupportInitialize)this.numericUpDown1).EndInit();
      base.ResumeLayout(false);
      base.PerformLayout();
    }

    // Token: 0x06000048 RID: 72 RVA: 0x000054F7 File Offset: 0x000036F7
    public LicenceTestForm()
    {
      this.InitializeComponent();
      this._uniqId = this.GetUniqId();
    }

    // Token: 0x1700000B RID: 11
    // (get) Token: 0x06000049 RID: 73 RVA: 0x0000551C File Offset: 0x0000371C
    private DataTable Licences {
      get {
        return this.dsLicences1.Tables[0];
      }
    }

    // Token: 0x1700000C RID: 12
    // (get) Token: 0x0600004A RID: 74 RVA: 0x00005540 File Offset: 0x00003740
    // (set) Token: 0x0600004B RID: 75 RVA: 0x00005558 File Offset: 0x00003758
    public int RenewTime {
      get {
        return this._renewTime;
      }
      set {
        this._renewTime = value;
        this.tbRenewDelay.Text = this._renewTime.ToString();
      }
    }

    // Token: 0x1700000D RID: 13
    // (get) Token: 0x0600004C RID: 76 RVA: 0x0000557C File Offset: 0x0000377C
    public TOTVSLicence TotvsLicence {
      get {
        return this.CreateTotvsLicence();
      }
    }

    // Token: 0x0600004D RID: 77 RVA: 0x00005594 File Offset: 0x00003794
    private TOTVSLicence CreateTotvsLicence()
    {
      TOTVSLicence totvslicence = new TOTVSLicence();
      totvslicence.ServerIP = this.tbServerIP.Text;
      totvslicence.ServerPort = Convert.ToInt32(this.tbServerPort.Text);
      totvslicence.UnicId = Convert.ToInt32(this.tbThreadID.Text);
      totvslicence.DoAtualiza += this.TotvsLicence_atualiza;
      totvslicence.TimeOut = Convert.ToInt32(this.tbTimeOut.Text);
      totvslicence.ParentThreadId = Convert.ToInt32(this.tParentThreadID.Text);
      totvslicence.Usuario = "mestre";
      return totvslicence;
    }

    // Token: 0x0600004E RID: 78 RVA: 0x0000563C File Offset: 0x0000383C
    private void ConsumeLicence()
    {
      this.CreateTotvsLicence();
      try
      {
        byte[] array = this.cbRenewCredential.Checked ? null : this._credential;
        string text;
        int num = this.TotvsLicence.ConsumeLicence(ref array, Convert.ToInt32(this.tbLicence.Text), out text);
        if (num >= 0)
        {
          this.LogResult("Credencial Obtida! Dias restantes: " + num);
          this.StartReviewCount();
          this.ckAutomaticRenew.Enabled = true;
          if (!this.cbRenewCredential.Checked)
          {
            this.Licences.Rows.Add(new object[]
            {
              array
            });
          }
          else
          {
            this._credential = array;
          }
        }
        else
        {
          this.LogResult(string.Concat(new object[]
          {
            "Erro ao recuperar licença: Cod. ",
            num,
            " Message: ",
            text
          }));
          this.ckAutomaticRenew.Enabled = false;
        }
      }
      catch (Exception ex)
      {
        this.LogResult("Erro ao conectar ao LicenceServer: " + ex.Message);
        this.ckAutomaticRenew.Enabled = false;
      }
    }

    // Token: 0x0600004F RID: 79 RVA: 0x00005780 File Offset: 0x00003980
    private void RenewLicence(byte[] credential)
    {
      try
      {
        string text;
        int num = this.TotvsLicence.RenewLicence(credential, Convert.ToInt32(this.tbLicence.Text), out text);
        if (num >= 0)
        {
          this.LogResult("Licença renovada!");
        }
        else
        {
          this.LogResult("Licença não renovada! Erro cod.: " + num);
        }
      }
      catch (Exception ex)
      {
        this.LogResult("Erro ao conectar ao LicenceServer: " + ex.Message);
      }
    }

    // Token: 0x06000050 RID: 80 RVA: 0x0000580C File Offset: 0x00003A0C
    private void RenewLicence()
    {
      if (this.cbRenewCredential.Checked)
      {
        this.Licences.Clear();
        this.Licences.Rows.Add(new object[]
        {
          this._credential
        });
      }
      foreach (object obj in this.Licences.Rows)
      {
        DataRow dataRow = (DataRow)obj;
        byte[] credential = dataRow["Credential"] as byte[];
        this.RenewLicence(credential);
      }
    }

    // Token: 0x06000051 RID: 81 RVA: 0x000058D4 File Offset: 0x00003AD4
    private void ReleaseLicence(byte[] credential)
    {
      try
      {
        string msg;
        this.TotvsLicence.ReleaseLicence(credential, Convert.ToInt32(this.tbLicence.Text), out msg);
        this.LogResult(msg);
      }
      catch (Exception ex)
      {
        this.LogResult("Erro ao conectar ao LicenceServer: " + ex.Message);
      }
      this.ckAutomaticRenew.Enabled = false;
    }

    // Token: 0x06000052 RID: 82 RVA: 0x00005948 File Offset: 0x00003B48
    private void GetTotal()
    {
      this.CreateTotvsLicence();
      try
      {
        byte[] credential = this.cbRenewCredential.Checked ? null : this._credential;
        string text;
        int total = this.TotvsLicence.GetTotal(ref credential, Convert.ToInt32(this.tbLicence.Text), out text);
        if (total > 0)
        {
          this.LogResult("Valor Obtido: " + total);
          if (this.cbRenewCredential.Checked)
          {
            this._credential = credential;
          }
        }
        else
        {
          this.LogResult(string.Concat(new object[]
          {
            "Erro ao recuperar licença: Cod. ",
            total,
            " Message: ",
            text
          }));
        }
      }
      catch (Exception ex)
      {
        this.LogResult("Erro ao conectar ao LicenceServer: " + ex.Message);
      }
    }

    // Token: 0x06000053 RID: 83 RVA: 0x00005A44 File Offset: 0x00003C44
    private void GetTotalWithRules()
    {
      this.CreateTotvsLicence();
      try
      {
        byte[] credential = this.cbRenewCredential.Checked ? null : this._credential;
        string text;
        int totalWithRules = this.TotvsLicence.GetTotalWithRules(ref credential, Convert.ToInt32(this.tbLicence.Text), out text);
        if (totalWithRules > 0)
        {
          this.LogResult("Valor Obtido: " + totalWithRules);
          if (this.cbRenewCredential.Checked)
          {
            this._credential = credential;
          }
        }
        else
        {
          this.LogResult(string.Concat(new object[]
          {
            "Erro ao recuperar licença: Cod. ",
            totalWithRules,
            " Message: ",
            text
          }));
        }
      }
      catch (Exception ex)
      {
        this.LogResult("Erro ao conectar ao LicenceServer: " + ex.Message);
      }
    }

    // Token: 0x06000054 RID: 84 RVA: 0x00005B40 File Offset: 0x00003D40
    private void GetAvailableWithRules()
    {
      this.CreateTotvsLicence();
      try
      {
        byte[] credential = this.cbRenewCredential.Checked ? null : this._credential;
        string text;
        int availableWithRules = this.TotvsLicence.GetAvailableWithRules(ref credential, Convert.ToInt32(this.tbLicence.Text), out text);
        if (availableWithRules > 0)
        {
          this.LogResult("Valor Obtido: " + availableWithRules);
          if (this.cbRenewCredential.Checked)
          {
            this._credential = credential;
          }
        }
        else
        {
          this.LogResult(string.Concat(new object[]
          {
            "Erro ao recuperar licença: Cod. ",
            availableWithRules,
            " Message: ",
            text
          }));
        }
      }
      catch (Exception ex)
      {
        this.LogResult("Erro ao conectar ao LicenceServer: " + ex.Message);
      }
    }

    // Token: 0x06000055 RID: 85 RVA: 0x00005C3C File Offset: 0x00003E3C
    private void GetIdHL()
    {
      this.CreateTotvsLicence();
      try
      {
        byte[] credential = this.cbRenewCredential.Checked ? null : this._credential;
        string text;
        int idHL = this.TotvsLicence.GetIdHL(ref credential, out text);
        if (idHL > 0)
        {
          this.LogResult("HardLock: " + idHL);
          if (this.cbRenewCredential.Checked)
          {
            this._credential = credential;
          }
        }
        else
        {
          this.LogResult(string.Concat(new object[]
          {
            "Erro ao recuperar ID: Cod. ",
            idHL,
            " Message: ",
            text
          }));
        }
      }
      catch (Exception ex)
      {
        this.LogResult("Erro ao conectar ao LicenceServer: " + ex.Message);
      }
    }

    // Token: 0x06000056 RID: 86 RVA: 0x00005D28 File Offset: 0x00003F28
    private void StartReviewCount()
    {
      if (this.ckAutomaticRenew.Checked)
      {
        this.RenewTime = 120;
        this.timerRenew.Enabled = true;
      }
      else
      {
        this.RenewTime = 0;
        this.timerRenew.Enabled = false;
      }
    }

    // Token: 0x06000057 RID: 87 RVA: 0x00005D79 File Offset: 0x00003F79
    private void StopReviewCount()
    {
      this.RenewTime = 120;
      this.timerRenew.Enabled = false;
    }

    // Token: 0x06000058 RID: 88 RVA: 0x00005D94 File Offset: 0x00003F94
    private string ByteToString(byte[] myByteArray)
    {
      Encoding ascii = Encoding.ASCII;
      return ascii.GetString(myByteArray);
    }

    // Token: 0x06000059 RID: 89 RVA: 0x00005DB4 File Offset: 0x00003FB4
    private int GetUniqId()
    {
      return Thread.CurrentThread.ManagedThreadId;
    }

    // Token: 0x0600005A RID: 90 RVA: 0x00005DD0 File Offset: 0x00003FD0
    private void LogResult(string msg)
    {
      this.lsResult.Items.Add(string.Format("{0}: {1}", DateTime.Now.ToString(), msg));
      this.lsResult.SelectedIndex = this.lsResult.Items.Count - 1;
    }

    // Token: 0x0600005B RID: 91 RVA: 0x00005E2C File Offset: 0x0000402C
    private void TotvsLicence_atualiza(object sender, EventArgs e)
    {
      this.tbEnCred.Text = this.TotvsLicence.BufferGetCredencial;
      this.tbEnLic.Text = this.TotvsLicence.BufferGetLicence;
      this.tbRvCred.Text = this.TotvsLicence.RespCredencial;
      this.tbRvLic.Text = this.TotvsLicence.RespServer;
    }

    // Token: 0x0600005C RID: 92 RVA: 0x00005E98 File Offset: 0x00004098
    private void btnConsumeLicence_Click(object sender, EventArgs e)
    {
      int num = 0;
      while (num <= --this.numericUpDown1.Value)
      {
        this.ConsumeLicence();
        num++;
      }
    }

    // Token: 0x0600005D RID: 93 RVA: 0x00005ED4 File Offset: 0x000040D4
    private void btnRenewLicence_Click(object sender, EventArgs e)
    {
      this.RenewLicence();
    }

    // Token: 0x0600005E RID: 94 RVA: 0x00005EE0 File Offset: 0x000040E0
    private void timerRenew_Tick(object sender, EventArgs e)
    {
      if (--this.RenewTime == 0)
      {
        this.RenewLicence();
        this.StartReviewCount();
      }
    }

    // Token: 0x0600005F RID: 95 RVA: 0x00005F1A File Offset: 0x0000411A
    private void ckAutomaticRenew_CheckedChanged(object sender, EventArgs e)
    {
      this.StartReviewCount();
    }

    // Token: 0x06000060 RID: 96 RVA: 0x00005F24 File Offset: 0x00004124
    private void lsResult_DoubleClick(object sender, EventArgs e)
    {
      MessageBox.Show(this.lsResult.SelectedItem.ToString());
    }

    // Token: 0x06000061 RID: 97 RVA: 0x00005F3D File Offset: 0x0000413D
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
    }

    // Token: 0x06000062 RID: 98 RVA: 0x00005F40 File Offset: 0x00004140
    private void btnGetTotal_Click(object sender, EventArgs e)
    {
      this.GetTotal();
    }

    // Token: 0x06000063 RID: 99 RVA: 0x00005F4A File Offset: 0x0000414A
    private void btnGetIdHL_Click(object sender, EventArgs e)
    {
      this.GetIdHL();
    }

    // Token: 0x06000064 RID: 100 RVA: 0x00005F54 File Offset: 0x00004154
    private void btninitKey_Click(object sender, EventArgs e)
    {
      TestValidateInitKeyForm testValidateInitKeyForm = new TestValidateInitKeyForm();
      testValidateInitKeyForm.ShowDialog();
    }

    // Token: 0x06000065 RID: 101 RVA: 0x00005F70 File Offset: 0x00004170
    private void btnEmergKey_Click(object sender, EventArgs e)
    {
      TestEmergencyKeyForm testEmergencyKeyForm = new TestEmergencyKeyForm();
      testEmergencyKeyForm.ShowDialog();
    }

    // Token: 0x06000066 RID: 102 RVA: 0x00005F8B File Offset: 0x0000418B
    private void button1_Click(object sender, EventArgs e)
    {
      this.GetTotalWithRules();
    }

    // Token: 0x06000067 RID: 103 RVA: 0x00005F95 File Offset: 0x00004195
    private void button2_Click(object sender, EventArgs e)
    {
      this.GetAvailableWithRules();
    }

    // Token: 0x06000068 RID: 104 RVA: 0x00005FA0 File Offset: 0x000041A0
    private void bGetCode_Click(object sender, EventArgs e)
    {
      this.CreateTotvsLicence();
      try
      {
        byte[] credential = this.cbRenewCredential.Checked ? null : this._credential;
        string text;
        int version = this.TotvsLicence.GetVersion(ref credential, out text);
        if (version > 0)
        {
          this.LogResult("Valor Obtido: " + version);
          if (this.cbRenewCredential.Checked)
          {
            this._credential = credential;
          }
        }
        else
        {
          this.LogResult(string.Concat(new object[]
          {
            "Erro ao recuperar a versão: Cod. ",
            version,
            " Message: ",
            text
          }));
        }
      }
      catch (Exception ex)
      {
        this.LogResult("Erro ao conectar ao LicenceServer: " + ex.Message);
      }
    }

    // Token: 0x06000069 RID: 105 RVA: 0x0000608C File Offset: 0x0000428C
    private void radioButton2_CheckedChanged(object sender, EventArgs e)
    {
      this.TotvsLicence.LicenceServerMode = (this.radioButton2.Checked ? 2010 : 2009);
    }

    // Token: 0x0600006A RID: 106 RVA: 0x000060B4 File Offset: 0x000042B4
    private void splitContainer3_SplitterMoved(object sender, SplitterEventArgs e)
    {
    }

    // Token: 0x0600006B RID: 107 RVA: 0x000060B8 File Offset: 0x000042B8
    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      if (e.ColumnIndex == 0 && e.RowIndex > -1 && e.Value is byte[])
      {
        byte[] values = e.Value as byte[];
        e.Value = string.Join<byte>(" ", values);
      }
    }

    // Token: 0x0600006C RID: 108 RVA: 0x00006110 File Offset: 0x00004310
    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex > -1)
      {
        DataRowView dataRowView = this.dataGridView1.Rows[e.RowIndex].DataBoundItem as DataRowView;
        if (e.ColumnIndex == 1)
        {
          this.ReleaseLicence(dataRowView["Credential"] as byte[]);
          this.Licences.Rows.Remove(dataRowView.Row);
        }
        else if (e.ColumnIndex == 2)
        {
          this.RenewLicence(dataRowView["Credential"] as byte[]);
        }
      }
    }

    // Token: 0x0600006D RID: 109 RVA: 0x000061BD File Offset: 0x000043BD
    private void button3_Click(object sender, EventArgs e)
    {
      this.lsResult.Items.Clear();
    }

    // Token: 0x04000015 RID: 21
    private const int cRenewInterval = 120;

    // Token: 0x04000016 RID: 22
    private IContainer components = null;

    // Token: 0x04000017 RID: 23
    private Label label1;

    // Token: 0x04000018 RID: 24
    private TextBox tbServerIP;

    // Token: 0x04000019 RID: 25
    private TextBox tbServerPort;

    // Token: 0x0400001A RID: 26
    private Label label2;

    // Token: 0x0400001B RID: 27
    private TextBox tbLicence;

    // Token: 0x0400001C RID: 28
    private Label label3;

    // Token: 0x0400001D RID: 29
    private GroupBox groupBox1;

    // Token: 0x0400001E RID: 30
    private GroupBox groupBox2;

    // Token: 0x0400001F RID: 31
    private SplitContainer splitContainer1;

    // Token: 0x04000020 RID: 32
    private SplitContainer splitContainer2;

    // Token: 0x04000021 RID: 33
    private Label label4;

    // Token: 0x04000022 RID: 34
    private TextBox tbEnCred;

    // Token: 0x04000023 RID: 35
    private Label label5;

    // Token: 0x04000024 RID: 36
    private TextBox tbEnLic;

    // Token: 0x04000025 RID: 37
    private System.Windows.Forms.Timer timerRenew;

    // Token: 0x04000026 RID: 38
    private ListBox lsResult;

    // Token: 0x04000027 RID: 39
    private Button btnGetTotal;

    // Token: 0x04000028 RID: 40
    private Button btnGetIdHL;

    // Token: 0x04000029 RID: 41
    private Button btninitKey;

    // Token: 0x0400002A RID: 42
    private Button btnEmergKey;

    // Token: 0x0400002B RID: 43
    private Button button1;

    // Token: 0x0400002C RID: 44
    private Button button2;

    // Token: 0x0400002D RID: 45
    private TextBox tbTimeOut;

    // Token: 0x0400002E RID: 46
    private Label label8;

    // Token: 0x0400002F RID: 47
    private Button bGetCode;

    // Token: 0x04000030 RID: 48
    private Label label9;

    // Token: 0x04000031 RID: 49
    private TextBox tParentThreadID;

    // Token: 0x04000032 RID: 50
    private GroupBox groupBox3;

    // Token: 0x04000033 RID: 51
    private RadioButton radioButton2;

    // Token: 0x04000034 RID: 52
    private RadioButton radioButton1;

    // Token: 0x04000035 RID: 53
    private CheckBox cbRenewCredential;

    // Token: 0x04000036 RID: 54
    private Button btnConsumeLicence;

    // Token: 0x04000037 RID: 55
    private TextBox tbRenewDelay;

    // Token: 0x04000038 RID: 56
    private CheckBox ckAutomaticRenew;

    // Token: 0x04000039 RID: 57
    private Label label6;

    // Token: 0x0400003A RID: 58
    private TextBox tbRvLic;

    // Token: 0x0400003B RID: 59
    private Label label7;

    // Token: 0x0400003C RID: 60
    private TextBox tbRvCred;

    // Token: 0x0400003D RID: 61
    private DataGridView dataGridView1;

    // Token: 0x0400003E RID: 62
    private BindingSource bindingSource1;

    // Token: 0x0400003F RID: 63
    private DSLicences dsLicences1;

    // Token: 0x04000040 RID: 64
    private Label label10;

    // Token: 0x04000041 RID: 65
    private DataGridViewTextBoxColumn credentialDataGridViewImageColumn;

    // Token: 0x04000042 RID: 66
    private DataGridViewButtonColumn Liberar;

    // Token: 0x04000043 RID: 67
    private DataGridViewButtonColumn Column1;

    // Token: 0x04000044 RID: 68
    private Label label11;

    // Token: 0x04000045 RID: 69
    private TextBox tbThreadID;

    // Token: 0x04000046 RID: 70
    private Label label12;

    // Token: 0x04000047 RID: 71
    private NumericUpDown numericUpDown1;

    // Token: 0x04000048 RID: 72
    private Button button3;

    // Token: 0x04000049 RID: 73
    private byte[] _credential;

    // Token: 0x0400004A RID: 74
    private int _uniqId;

    // Token: 0x0400004B RID: 75
    private int _renewTime;
  }
}