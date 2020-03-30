using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
      btnServiceManager.Click += new EventHandler(btnServiceManager_Click);
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


      #endregion
    }

    private void lstAmbientes_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    {
      grpConfig.Enabled = false;
      pnlButtons.Enabled = true;
      LoadAmbiente();
      ResetTagsConfig();
      lblMessage.Visible = false;
      e.Item.BackColor = Color.Silver;
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
      foreach (ListViewItem item in lstAmbientes.Items)
      {
        item.ForeColor = Color.Black;
        item.ImageKey = "Host_off2";
        foreach (var ambiente in Ambiente.ListAmbientes)
        {
          item.BackColor = Color.WhiteSmoke;

          foreach (Host host in ToolProcess.ListHosts())
          {
            if (ambiente.name.ToLower() == item.Text.ToLower())
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
      UpdateConfig();
    }

    private void FormPrincipal_Load(object sender, EventArgs e)
    {
      if (!ToolProcess.CheckDomain())
      {
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
      lbVersao.Text = "";
      lbVersaoaLabel.Visible = false;
      pnlButtons.Enabled = false;
      grpConfig.Enabled = false;
    }
    
    private void LoadAmbiente()
    {
      if (lstAmbientes.SelectedItems.Count == 0)
        return;
      ListViewItem item = lstAmbientes.SelectedItems[0];
      UpdateLstAmbientesIcons();
      foreach (var ambiente in Ambiente.ListAmbientes)
      {
        //if (ambiente.name == cbxAmbientes.SelectedItem.ToString())
        if (ambiente.name == item.Text)
        {
          // Define o ambiente selecionado no cbxAmbientes
          Ambiente.Selected = ambiente;
          lbVersao.Text = ambiente.libVersion;
          lbVersaoaLabel.Visible = true;
          string value = "";
          if (!ToolProcess.VerifyHost(Ambiente.Selected, out value))
          {
            UpdateHostStatus(2);
          }
          else
          {
            if (value == "App")
            {
              UpdateHostStatus(1);
            }
            else if (value == "Service")
            {
              UpdateHostStatus(3);
            }
          }
        }
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

    private void btnCarregarConfig_Click(object sender, EventArgs e)
    {
      
    }

    private void UpdateConfig()
    {
      lstConfig.Items.Clear();
      lstConfig.Enabled = true;
      grpConfig.Enabled = true;
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
      StartTimer();
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

    private void StartTimer()
    {
      timer1.Interval = 1000;
      timer1.Start();
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      LoadAmbiente();
      timer1.Stop();
    }

    private void btnEncerraAmbiente_Click(object sender, EventArgs e)
    {
      ToolProcess.KillAmbiente();
      StartTimer();
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
        btnCarregarConfig_Click(sender, e);
      }
    }

    private void chbSmartClient_CheckStateChanged(object sender, EventArgs e)
    {
      txbServidor.Text = "";
      chbUpdateServer.Checked = false;
      if (chbSmartClient.Checked == true)
      {
        grpSmartClient.Enabled = true;
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
  }
}

