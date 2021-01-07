using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using RMTools.AliasDir;

namespace RMTools
{
  public partial class FormPrincipal : Form
  {
    //internal string _hostActive = "";
    public FormPrincipal()
    {
      InitializeComponent();
      btnRmexe.Click += new EventHandler(bntRmexe_Click);
      btnApagarBroker.Click += new EventHandler(btnApagarBroker_Click);
      btnAliasManager.Click += new EventHandler(btnAliasManager_Click);
      btnEncerraAmbiente.Click += new EventHandler(btnEncerraAmbiente_Click);
      btnHostApp.Click += new EventHandler(btnHostApp_Click);
      btnAplicar.Click += new EventHandler(btnAplicar_Click);
      btnServiceManager.Click += new EventHandler(btnServiceManager_Click);
      btnRefreshAmbientes.Click += new EventHandler(btnRefreshAmbientes_Click);
      chbSmartClient.CheckStateChanged += new EventHandler(chbSmartClient_CheckStateChanged);
      chbUpdateServer.CheckStateChanged += new EventHandler(chbUpdateServer_CheckStateChanged);
      chbUpdateClient.CheckStateChanged += new EventHandler(chbUpdateClient_CheckStateChanged);
      lstConfig.MouseDoubleClick += new MouseEventHandler(lstConfig_MouseDoubleClick);
      lstAmbientes.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(lstAmbientes_ItemSelectionChanged);

      #region [ToolTip]
      toolTip1.SetToolTip(lstAmbientes, Properties.Resources.lstAmbientes);
      toolTip1.SetToolTip(btnAliasManager, Properties.Resources.btnAliasManager);
      toolTip1.SetToolTip(btnRmexe, Properties.Resources.btnRmexe);
      toolTip1.SetToolTip(btnServiceManager, Properties.Resources.btnServiceManager);
      toolTip1.SetToolTip(btnHostApp, Properties.Resources.btnHostAppInit);
      toolTip1.SetToolTip(btnEncerraAmbiente, Properties.Resources.btnEncerraAmbiente);
      toolTip1.SetToolTip(chbEnableCompression, Properties.Resources.chbEnableCompression);
      toolTip1.SetToolTip(chbEnableDynamicLocalization, Properties.Resources.chbEnableDynamicLocalization);
      toolTip1.SetToolTip(chbNCamadas, Properties.Resources.chbNCamadas);
      toolTip1.SetToolTip(chbSmartClient, Properties.Resources.chbSmartClient);
      toolTip1.SetToolTip(chbUpdateClient, Properties.Resources.chbUpdateClient);
      toolTip1.SetToolTip(chbUpdateServer, Properties.Resources.chbUpdateServer);
      toolTip1.SetToolTip(lstConfig, Properties.Resources.lstConfig);
      toolTip1.SetToolTip(btnAbrirRmNet, Properties.Resources.btnAbrirRmNet);


      #endregion
    }

    private void lstAmbientes_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    {
      LoadAmbiente();
      grpConfig.Enabled = false;
      pnlButtons.Enabled = true;
      btnAbrirRmNet.Enabled = true;
      lblMessage.Visible = false;
      grpAliasDat.Enabled = false;
      grpInfoAlias.Enabled = false;
      grpServicosAlias.Enabled = false;
      e.Item.BackColor = Color.Silver;
      cbAlias.ResetText();
    }

    private void InitializeLstAmbientes()
    {
      ImageList imageList = new ImageList();
      imageList.Images.Add("Icone_RM", RMTools.Properties.Resources.Icone_RM);
      imageList.Images.Add("Host_Off", RMTools.Properties.Resources.Host_Off);
      imageList.Images.Add("Host_Off2", RMTools.Properties.Resources.Host_Off2);
      imageList.Images.Add("Host_on", RMTools.Properties.Resources.Host_On);
      lstAmbientes.LargeImageList = imageList;
    }

    private void UpdateLstAmbientes()
    {
      Ambiente.LoadAmbientes();
      lstAmbientes.Items.Clear();
      foreach (var ambiente in Ambiente.ListAmbientes)
      {
        ListViewItem item = lstAmbientes.Items.Add(ambiente.name);
        item.ImageKey = "Host_off2";
        item.ForeColor = Color.Black;
      }
      UpdateLstAmbientesIcons();
    }

    private void UpdateLstAmbientesIcons()
    {
      // Carrega a lista de hosts ativos
      ToolProcess.ListarHosts();

      foreach (ListViewItem item in lstAmbientes.Items)
      {
        // reseta a cor e o incone do item
        item.ForeColor = Color.Black;
        item.ImageKey = "Host_off2";

        foreach (var ambiente in Ambiente.ListAmbientes)
        {
          item.BackColor = SystemColors.Control;
          if (ambiente.name.ToLower() == item.Text.ToLower())
          {
            foreach (Host host in ToolProcess.ListHosts)
            {
              if (ambiente.pathRmnet.ToLower() == Path.GetDirectoryName(host.HostPath).ToLower() && item.Text.ToLower() == ambiente.name.ToLower())
              {
                item.ImageKey = "Host_on";
                item.ForeColor = Color.Green;
              }
            }
            
          }
        }
      }
    }

    private void lstAmbientes_DoubleClick(object sender, EventArgs e)
    {
      ResetTagsConfig();
      UpdateConfig();
      InitCbAlias();
    }

    private void FormPrincipal_Load(object sender, EventArgs e)
    {
      //Checa se o app esta sendo executado no dominio BH01
      if (!ToolProcess.CheckDomain())
      {
        ToolProcess.Print(Properties.Resources.AppForaDoDominio, "e");
        Application.Exit();
      }        

      bool validaAmbientes = Ambiente.LoadAmbientes();
      if (!validaAmbientes)
      {
        Application.Exit();
      }
      InitializeLstAmbientes();
      UpdateLstAmbientes();

      // Reset dos campos do Form
      this.Text = "RM Tools " + Application.ProductVersion.ToString();
      lbVersao.Text = "";
      lbVersaoaLabel.Visible = false;
      pnlButtons.Enabled = false;
      btnAbrirRmNet.Enabled = false;
      grpConfig.Enabled = false;
      grpAliasDat.Enabled = false;
      grpInfoAlias.Enabled = false;
      grpServicosAlias.Enabled = false;
      timer1.Interval = 2000;
      timer1.Enabled = true;

      lstAmbientes.Items[0].Focused = true;
      lstAmbientes.Items[0].Selected = true;
    }

    private void LoadAmbiente()
    {
      // Proteção para caso não existam ambientes listados
      if (lstAmbientes.SelectedItems.Count == 0)
        return;

      ListViewItem item = lstAmbientes.SelectedItems[0];
      UpdateLstAmbientesIcons();
      Ambiente ambiente = Ambiente.ListAmbientes.Find(x => x.name == item.Text);

      // Verifica se o ambiente foi alterado durante a execução do app
      if (!File.Exists(ambiente.pathRmnet + @"\RM.Host.exe"))
      {
        timer1.Enabled = false;
        ToolProcess.Print(Properties.Resources.MsgAmbienteAlterado, "w");
        UpdateLstAmbientes();
        timer1.Enabled = true;
      }
          

      // Define o ambiente selecionado no cbxAmbientes
      Ambiente.Selected = ambiente;
      lbVersao.Text = ambiente.libVersion;
      lbVersaoaLabel.Visible = true;
      string value = "";
      if (!ToolProcess.VerifyHost(Ambiente.Selected, out value))
      {
        UpdateHostStatus(2);
        return;
      }
      switch (value)
      {
        case ("App"):
          UpdateHostStatus(1);
          break;
        case ("Service"):
          UpdateHostStatus(3);
          break;
      }
    }

    private void UpdateHostStatus(int value)
    {
      switch (value)
      {
        case (1): //Host App iniciado
          btnHostApp.BackColor = Color.LightCoral;
          btnHostApp.Text = "Parar Host App";
          btnHostApp.Enabled = true;
          toolTip1.SetToolTip(btnHostApp, Properties.Resources.btnHostAppStop);
          btnEncerraAmbiente.Visible = true;
          //_hostActive = Ambiente.Selected.path;
          break;
        case (2): //Host Parado
          btnHostApp.BackColor = Color.LightGreen;
          btnHostApp.Text = "Iniciar Host App";
          btnHostApp.Enabled = true;
          toolTip1.SetToolTip(btnHostApp, Properties.Resources.btnHostAppInit);
          btnEncerraAmbiente.Visible = false;
          break;
        case (3): //Host Service iniciado
          btnHostApp.BackColor = Color.LightGray;
          btnHostApp.Text = "Host Service iniciado";
          btnHostApp.Enabled = false;
          toolTip1.SetToolTip(btnHostApp, Properties.Resources.btnHostAppStop);
          btnEncerraAmbiente.Visible = true;
          break;
      }
    }
    
    private void UpdateConfig()
    {
      lstConfig.Items.Clear();
      lstConfig.Enabled = true;
      grpConfig.Enabled = true;
      grpAliasDat.Enabled = true;
      UpdateTagsConfig();
      GetConfigs();
    }

    private void GetConfigs()
    {
      if (lstAmbientes.SelectedItems.Count == 0)
        return;
      ListViewItem item = lstAmbientes.SelectedItems[0];
      if (Ambiente.Selected.name == item.Text)
      {
        Ambiente.Selected.UpdateListConfig();
        foreach (var config in Config.List)
        {
          lstConfig.Items.Add(config.name);
        }
      }
    }

    private void UpdateTagsConfig()
    {
      Ambiente.Clear();
      Ambiente.UpdateTags();
      if (Ambiente.ConfigPath != "0")
      {
        ResetTagsConfig();
        lblMessage.Visible = true;
        lblMessage.Text = "Config Global ativo!";
        grpConfig.Enabled = false;
      }
      else
      {
        // Preenche os campos do Form conforme as configurções do ambiente
        chbNCamadas.Checked = Ambiente.JobServer3Camadas;
        chbEnableDynamicLocalization.Checked = Ambiente.EnableDynamicLocalization;
        chbEnableCompression.Checked = Ambiente.EnableCompression;
        chbTraceFileHost.Checked = Ambiente.TraceFileHost;
        chbTraceFileRmExe.Checked = Ambiente.TraceFileRMExe;
        chbTraceLS.Checked = Ambiente.TraceLs;
        chbSmartClient.Checked = Ambiente.UpdateServerEnabled;
        chbUpdateServer.Checked = Ambiente.UpdateServerEnabled;
        txbActionsPath.Text = Ambiente.ActionsPath;
        txbPort.Text = Ambiente.Port == "0" ? "" : Ambiente.Port;
        txbApiPort.Text = Ambiente.ApiPort == "0" ? "" : Ambiente.ApiPort;
        txbHttpPort.Text = Ambiente.HttpPort == "0" ? "" : Ambiente.HttpPort;
        txbHost.Text = Ambiente.Host;
        txbLocalizationLanguage.Text = Ambiente.LocalizationLaguage;
        txbLibPath.Text = Ambiente.LibPath;
        txbServidor.Text = Ambiente.UpdateServer == "0" ? "" : Ambiente.UpdateServer;
        txbDefaultDb.Text = Ambiente.DefaultDb == "0" ? "" : Ambiente.DefaultDb;
      }
    }

    private void InitCbAlias()
    {
      AliasDat.InitializeAliasDat();
      foreach (string alias in AliasDat.ListAliasNames)
      {
        cbAlias.Items.Add(alias);
      }
    }

    private void ClearAliasDat()
    {
      txbAlias.Text = "";
      txbServerBD.Text = "";
      chbSql.Checked = false;
      chbOracle.Checked = false;
      txbBase.Text = "";
      chbJSEnabled.Checked = false;
      chbJSLocalOnly.Checked = false;
      chbProcessPool.Checked = false;
      txbJSMaxTreads.Text = "";
      txbJSPollingInterval.Text = "";
    }

    private void ResetTagsConfig()
    {
      chbNCamadas.Checked = false;
      chbEnableDynamicLocalization.Checked = false;
      chbEnableCompression.Checked = false;
      chbTraceFileHost.Checked = false;
      chbTraceFileRmExe.Checked = false;
      chbTraceLS.Checked = false;
      txbActionsPath.Text = "";
      txbPort.Text = "";
      txbApiPort.Text = "";
      txbHttpPort.Text = "";
      txbHost.Text = "";
      txbLocalizationLanguage.Text = "";
      txbLibPath.Text = "";
      txbServidor.Text = "";

      // Alias
      cbAlias.Items.Clear();
    }

    private void lstConfig_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      int index = lstConfig.SelectedIndex;
      if (index == -1)
        return;
      
      string config = lstConfig.Items[index].ToString();
      
      // Define o config selecionado
      Config.UpdateSelect(config);

      System.Diagnostics.Process.Start(Config.Selected.path);
    }

    private void bntRmexe_Click(object sender, EventArgs e)
    {
      ToolProcess.StartRMexe();
    }

    private void btnAliasManager_Click(object sender, EventArgs e)
    {
      ToolProcess.StartApp(Ambiente.Selected, @"RM.AliasManager.exe");
    }

    private void btnServiceManager_Click(object sender, EventArgs e)
    {
      ToolProcess.StartApp(Ambiente.Selected, @"RM.Host.ServiceManager.exe");
    }

    private void btnHostApp_Click(object sender, EventArgs e)
    {
      if (btnHostApp.Text == "Parar Host App")
      {
        ToolProcess.StopHostApp();
      }
      else 
      {
        ToolProcess.StartHostApp();
      }
    }

    private void btnApagarBroker_Click(object sender, EventArgs e)
    {
      if (ToolProcess.DeleteBroker())
      {
        ToolProcess.Print(Properties.Resources.DeleteBrokerTrue, "s");
      }
      else
      {
        ToolProcess.Print(Properties.Resources.DeleteBrokerFalse, "e");
      } 
    }
    
    private void timer1_Tick(object sender, EventArgs e)
    {
      UpdateLstAmbientesIcons();
      LoadAmbiente();
    }

    private void btnEncerraAmbiente_Click(object sender, EventArgs e)
    {
      ToolProcess.KillAmbiente();
    }

    private void btnAplicar_Click(object sender, EventArgs e)
    {
      bgWorkerAplicar.RunWorkerAsync();
      btnAplicar.Enabled = false;
      btnAplicar.Text = "Trabalhando";
      progressBarAplicar.Visible = true;
      progressBarAplicar.Style = ProgressBarStyle.Marquee;
      progressBarAplicar.MarqueeAnimationSpeed = 5;
    }

    private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
    {
      Ambiente.Clear();
      // Validação da tag FileServerPath antes da execução das alterações de config
      if (chbNCamadas.Checked == true)
      {
        if (txbFileServerPath.Text == "" || txbFileServerPath.Text == null)
        {
          ToolProcess.Print("Ao utilizar o ambiente como N camada, é necessário preencher o campo FileServerPath com uma pasta publicada em seu ambiente.\nPor exemplo: \\\\" + txbHost.Text.ToUpper() +"\\PastaPublica","e");
          bgWorkerAplicar.CancelAsync();
          bgWorkerAplicar.Dispose();
          return;
        }
        else
        {
          Regex rx = new Regex(@"^\\\\(\w*)(\\)(\S\w*)",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);

          MatchCollection matches = rx.Matches(txbFileServerPath.Text);
          if (matches.Count == 0)
          {
            ToolProcess.Print("O endereço preenchido no campo FileServerPath, não parece ser um caminho de rede válido.\nA tag FileServerPath deve conter o caminho de rede de um diretório compartilhado de seu ambiente.\nPor exemplo: \\\\" + txbHost.Text.ToUpper() + "\\PastaPublica", "e");
            bgWorkerAplicar.CancelAsync();
            bgWorkerAplicar.Dispose();
            return;
          }
        }
      }

      Ambiente.JobServer3Camadas = chbNCamadas.Checked;
      Ambiente.EnableDynamicLocalization = chbEnableDynamicLocalization.Checked;
      Ambiente.EnableCompression = chbEnableCompression.Checked;
      Ambiente.TraceFileHost = chbTraceFileHost.Checked;
      Ambiente.TraceFileRMExe = chbTraceFileRmExe.Checked;
      Ambiente.TraceLs = chbTraceLS.Checked;
      Ambiente.ActionsPath = txbActionsPath.Text;
      Ambiente.Port = txbPort.Text;
      Ambiente.ApiPort = txbApiPort.Text;
      Ambiente.HttpPort = txbHttpPort.Text;
      Ambiente.Host = txbHost.Text;
      Ambiente.LocalizationLaguage = txbLocalizationLanguage.Text;
      Ambiente.LibPath = txbLibPath.Text;
      Ambiente.DefaultDb = txbDefaultDb.Text;
      Ambiente.FileServerPath = txbFileServerPath.Text;

      if (chbSmartClient.Checked)
      {
        if (chbUpdateServer.Checked)
        {
          Ambiente.UpdateServerEnabled = chbUpdateServer.Checked;
          Ambiente.UpdateServer = String.Format("{0}:{1}", Ambiente.Host, Ambiente.Port);
        }
        else if (chbUpdateClient.Checked)
        {
          Ambiente.UpdateServerEnabled = false;
          Ambiente.UpdateServer = String.Format(txbServidor.Text);
        }
      }
      else
      {
        Ambiente.UpdateServer = "";
        Ambiente.UpdateServerEnabled = false;
      }
      
      
      Ambiente.ApplyConfig();

      if (bgWorkerAplicar.CancellationPending)
      {
        e.Cancel = true;
        return;
      }
    }

    private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (e.Cancelled)
      {
        btnAplicar.Enabled = true;
        btnAplicar.Text = "Aplicar";
        progressBarAplicar.MarqueeAnimationSpeed = 0;
        progressBarAplicar.Style = ProgressBarStyle.Blocks;
        progressBarAplicar.Value = 0;
      }
      else if (e.Error != null)
      {
        btnAplicar.Enabled = true;
        btnAplicar.Text = "Aplicar";
        progressBarAplicar.MarqueeAnimationSpeed = 0;
        progressBarAplicar.Style = ProgressBarStyle.Blocks;
        progressBarAplicar.Value = 0;
      }
      else
      {
        btnAplicar.Enabled = true;
        btnAplicar.Text = "Aplicar";
        progressBarAplicar.MarqueeAnimationSpeed = 0;
        progressBarAplicar.Style = ProgressBarStyle.Blocks;
        progressBarAplicar.Value = 100;
        progressBarAplicar.Visible = false;
      }
    }

    private void chbSmartClient_CheckStateChanged(object sender, EventArgs e)
    {
      txbServidor.Text = "";
      chbUpdateServer.Checked = false;
      if (chbSmartClient.Checked == true)
      {
        grpSmartClient.Enabled = true;
        chbNCamadas.Checked = true;
        return;
      }
      grpSmartClient.Enabled = false;
    }

    private void chbUpdateServer_CheckStateChanged(object sender, EventArgs e)
    {
      if (chbUpdateServer.Checked == true)
      {
        txbServidor.Enabled = false;
        chbUpdateClient.Enabled = false;
        label3.Enabled = false;
        return;
      }
      txbServidor.Enabled = true;
      chbUpdateClient.Enabled = true;
      label3.Enabled = true;
    }

    private void chbUpdateClient_CheckStateChanged(object sender, EventArgs e)
    {
      if (chbUpdateClient.Checked)
      {
        chbUpdateServer.Enabled = false;
        return;
      }
      chbUpdateServer.Enabled = true;
    }

    private void btnRefreshAmbientes_Click(object sender, EventArgs e)
    {
      UpdateLstAmbientes();
    }

    private void btnAbrirRmNet_Click(object sender, EventArgs e)
    {
      Process.Start("explorer.exe", Ambiente.Selected.pathRmnet);
    }

    private void chbNCamadas_CheckStateChanged(object sender, EventArgs e)
    {
      txbFileServerPath.Enabled = false;
      if (chbNCamadas.Checked == true)
      {
        txbFileServerPath.Enabled = true;
      }
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {

      AliasDat alias = AliasDat.ListAlias.Find(x => x.Alias.Value == cbAlias.SelectedItem.ToString());
      AliasDat.Selected = alias;

      ClearAliasDat();
      UpdateAliasDat();

      grpInfoAlias.Enabled = true;
      grpServicosAlias.Enabled = true;

      //Habilitar os grupos InfoAlias e ServiçosAlias

    }

    private void UpdateAliasDat()
    {
      txbAlias.Text = AliasDat.Selected.Alias.Value;
      txbServerBD.Text = AliasDat.Selected.DbServer.Value;
      txbJSMaxTreads.Text = AliasDat.Selected.JobServerMaxThreads.Value;
      txbJSPollingInterval.Text = AliasDat.Selected.JobServerPollingInterval.Value;
      txbBase.Text = AliasDat.Selected.DbName.Value;

      chbSql.Checked = AliasDat.Selected.DbType.Value.ToLower() == "sqlserver"  ? true : false;
      chbOracle.Checked = AliasDat.Selected.DbType.Value.ToLower() == "oracle" ? true : false;
      chbJSEnabled.Checked = Convert.ToBoolean(AliasDat.Selected.JobServerEnabled.Value);
      chbJSLocalOnly.Checked = Convert.ToBoolean(AliasDat.Selected.JobServerLocalOnly.Value);
      chbProcessPool.Checked = Convert.ToBoolean(AliasDat.Selected.JobServerProcessPoolEnabled.Value);
      
    }

    private void btnTestar_Click(object sender, EventArgs e)
    {
      
    }

    
  }
}

