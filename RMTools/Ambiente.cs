using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System;
using System.Linq;
using System.Configuration;

namespace RMTools
{
  public class Ambiente
  {
    #region Static  
    public static List<Ambiente> ListAmbientes = new List<Ambiente>();
    public static Ambiente Selected = new Ambiente();

    public static string ActionsPath { get; set; }
    public static string ApiPort { get; set; }
    public static bool EnableCompression { get; set; }
    public static bool EnableDynamicLocalization { get; set; }
    public static string Host { get; set; }
    public static string DefaultDb { get; set; }
    public static string HttpPort { get; set; }
    public static bool JobServer3Camadas { get; set; }
    public static string LibPath { get; set; }
    public static string LocalizationLaguage { get; set; }
    public static string Port { get; set; }
    public static bool TraceFileHost { get; set; }
    public static bool TraceFileRMExe { get; set; }
    public static bool TraceLs { get; set; }
    public static string ConfigPath { get; set; }
    public static bool UpdateServerEnabled { get; set; }
    public static string UpdateServer { get; set; }
    public static string FileServerPath { get; set; }

    #endregion

    public string name { get; internal set; }
    public string libVersion { get; internal set; }
    public string path { get; internal set; }
    public string pathRmnet { get; internal set; }
    public string rmExe { get; internal set; }
    public string hostManager { get; internal set; }
    public string aliasManager { get; internal set; }

    #region TagsInternas
    private static Tag _actionsPath;
    private static Tag _apiPort;
    private static Tag _enableCompression;
    private static Tag _enableDynamicLocalization;
    private static Tag _host;
    private static Tag _httpPort;
    private static Tag _jobServer3Camadas;
    private static Tag _libPath;
    private static Tag _localizationLaguage;
    private static Tag _port;
    private static Tag _traceFileRMExe;
    private static Tag _traceFileHost;
    private static Tag _traceLs;
    private static Tag _configPath;
    private static Tag _updateServerEnabled;
    private static Tag _updateServer;
    private static Tag _defaultDb;
    private static Tag _fileServerPath;
    #endregion

    public static bool LoadAmbientes()
    {
      if (Ambiente.ListAmbientes.Count > 0)
            Ambiente.ListAmbientes.Clear();

      // Busca o diretorio configurado no RMTools.config
      DirectoryInfo dirTotvs = new DirectoryInfo(ToolProcess.DirectoryPath());
      var listDirTotvs = dirTotvs.EnumerateDirectories();
      try
      {
        foreach (var dirCorporeRM  in listDirTotvs)
        {
          DirectoryInfo dirCorporeRMInfo = new DirectoryInfo(dirCorporeRM.FullName);
          var listDirCorporeRM = dirCorporeRMInfo.EnumerateDirectories();

          foreach (var subDir in listDirCorporeRM)
          {
            if (subDir.Name == "RM.Net")
            {
              if (File.Exists(subDir.FullName + @"\RM.Host.Service.exe"))
              {
                Ambiente ambiente = new Ambiente();
                ambiente.name = dirCorporeRM.Name;
                ambiente.path = dirCorporeRM.FullName;
                ambiente.pathRmnet = subDir.FullName;
                FileInfo libVersion = new FileInfo(subDir.FullName + @"\RM.Version.dll");
                ambiente.libVersion = FileVersionInfo.GetVersionInfo(libVersion.FullName).FileVersion.ToString();
                ambiente.rmExe = subDir.FullName + @"\RM.exe";
                ambiente.hostManager = subDir.FullName + @"\RM.Host.ServiceManager.exe";
                ambiente.aliasManager = subDir.FullName + @"\RM.AliasManager.exe";

                Ambiente.ListAmbientes.Add(ambiente);
              }
            }
          }
        }
        if (Ambiente.ListAmbientes.Count() == 0)
        {
          if(ToolProcess.Print("Diretório inválido!\nDeseja configurar um novo diretório?","y") == System.Windows.Forms.DialogResult.Yes)
          {
            FormSelecionarDiretorioPadrao formSelecionarDiretorio = new FormSelecionarDiretorioPadrao();
            formSelecionarDiretorio.ShowDialog();
            if(!LoadAmbientes())
              return false;
          }
          else
          {
            return false;
          }
        }
        return true;
      }
      catch (System.Exception err)
      {
        Console.WriteLine(err);
        return false;
      }
    }

    public void UpdateListConfig()
    {
      Config.List.Clear();
      DirectoryInfo directory = new DirectoryInfo(pathRmnet);
      if (directory.Exists)
      {
        var files = directory.EnumerateFiles();
        foreach (var file in files)
        {
          if (file.Extension == ".config")
          {
            Config config = new Config();
            config.name = file.Name;
            config.path = file.FullName;
            Config.List.Add(config);
          }
        }
      }
    }

    public static void UpdateTags()
    {
      InitTags();
      string pathRMExeConfig = Path.Combine(Ambiente.Selected.pathRmnet, "RM.exe.config");
      string pathHostConfig = Path.Combine(Ambiente.Selected.pathRmnet, "RM.Host.Service.exe.config");

      _actionsPath.Value = ConfigAction.TagValue(pathRMExeConfig, _actionsPath);
      _apiPort.Value = ConfigAction.TagValue(pathHostConfig, _apiPort);
      _enableCompression.Value = ConfigAction.TagValue(pathRMExeConfig, _enableCompression);
      _enableDynamicLocalization.Value = ConfigAction.TagValue(pathRMExeConfig, _enableDynamicLocalization);
      _host.Value = ConfigAction.TagValue(pathRMExeConfig, _host);
      _httpPort.Value = ConfigAction.TagValue(pathHostConfig, _httpPort);
      _jobServer3Camadas.Value = ConfigAction.TagValue(pathRMExeConfig, _jobServer3Camadas);
      _libPath.Value = ConfigAction.TagValue(pathRMExeConfig, _libPath);
      _localizationLaguage.Value = ConfigAction.TagValue(pathRMExeConfig, _localizationLaguage);
      _port.Value = ConfigAction.TagValue(pathHostConfig, _port);
      _traceFileRMExe.Value = ConfigAction.TagValue(pathRMExeConfig, _traceFileRMExe);
      _traceFileHost.Value = ConfigAction.TagValue(pathHostConfig, _traceFileHost);
      _traceLs.Value = ConfigAction.TagValue(pathHostConfig, _traceLs);
      _configPath.Value = ConfigAction.TagValue(pathRMExeConfig, _configPath);
      _updateServer.Value = ConfigAction.TagValue(pathRMExeConfig, _updateServer);
      _updateServerEnabled.Value = ConfigAction.TagValue(pathHostConfig, _updateServerEnabled);
      _defaultDb.Value = ConfigAction.TagValue(pathHostConfig, _defaultDb);
      _fileServerPath.Value = ConfigAction.TagValue(pathHostConfig, _fileServerPath);

      ActionsPath = _actionsPath.Value;
      ApiPort = _apiPort.Value;
      EnableCompression = ConvertBooleanValue(_enableCompression.Value);
      EnableDynamicLocalization = ConvertBooleanValue(_enableDynamicLocalization.Value);
      Host = _host.Value;
      HttpPort = _httpPort.Value;
      JobServer3Camadas = ConvertBooleanValue(_jobServer3Camadas.Value);
      LibPath = _libPath.Value;
      LocalizationLaguage = _localizationLaguage.Value;
      Port = _port.Value;
      TraceFileHost = ConvertBooleanValue(_traceFileHost.Value);
      TraceFileRMExe = ConvertBooleanValue(_traceFileRMExe.Value);
      TraceLs = ConvertBooleanValue(_traceLs.Value);
      ConfigPath = _configPath.Value;
      DefaultDb = _defaultDb.Value;
      UpdateServer = _updateServer.Value;
      UpdateServerEnabled = ConvertBooleanValue(_updateServerEnabled.Value);
      FileServerPath = _fileServerPath.Value;
    }

    private static bool ConvertBooleanValue(string value)
    {
      if (value == "true" || value == "false")
      {
        return Convert.ToBoolean(value);
      }
      return false;
    }

    /// <summary>
    /// Inicializa todas as tags adicionando seus values.
    /// Obs. Atentar para se a tag vai para o JobRunner ou não, se sim, altere o valor tag.JobRunner para true
    /// </summary>
    private static void InitTags()
    {
      _actionsPath = new Tag("ActionsPath","");
      _actionsPath.Side = "Both";
      _actionsPath.JobRunner = true;

      _apiPort = new Tag("ApiPort","");      
      _apiPort.Side = "Server";

      _enableCompression = new Tag("EnableCompression", "");
      _enableCompression.Side = "Both";
      _enableCompression.JobRunner = true;

      _enableDynamicLocalization = new Tag("EnableDynamicLocalization", "");
      _enableDynamicLocalization.Side = "Both";
      _enableDynamicLocalization.JobRunner = true;

      _host = new Tag("Host", "");
      _host.Side = "Client";

      _httpPort = new Tag("HTTPPort", "");
      _httpPort.Side = "Server";

      _jobServer3Camadas = new Tag("JobServer3Camadas", "");
      _jobServer3Camadas.Side = "Both";
      _jobServer3Camadas.JobRunner = true;

      _libPath = new Tag("LibPath", "");
      _libPath.Side = "Both";
      _libPath.JobRunner = true;

      _localizationLaguage = new Tag("LocalizationLanguage", "");
      _localizationLaguage.Side = "Both";
      _localizationLaguage.JobRunner = true;

      _port = new Tag("Port", "");
      _port.Side = "Both";

      _traceFileHost = new Tag("TraceFile", "");
      _traceFileHost.Side = "Server";

      _traceFileRMExe = new Tag("TraceFile", "");
      _traceFileRMExe.Side = "Client";

      _traceLs = new Tag("TraceLS", "");
      _traceLs.Side = "Server";

      _configPath = new Tag("CONFIGPATH", "");
      _configPath.Side = "Both";

      _updateServer = new Tag("UpdateServer", "");
      _updateServer.Side = "Client";

      _defaultDb = new Tag("DefaultDB", "");
      _defaultDb.Side = "Server";
      _defaultDb.JobRunner = true;

      _updateServerEnabled = new Tag("UpdateServerEnabled", "");
      _updateServerEnabled.Side = "Server";

      _fileServerPath = new Tag("FileServerPath", "");
      _fileServerPath.Side = "Server";
    }

    public static void ApplyConfig()
    {
      string pathRMExeConfig = Path.Combine(Ambiente.Selected.pathRmnet, "RM.exe.config");
      string pathHostServiceConfig = Path.Combine(Ambiente.Selected.pathRmnet, "RM.Host.Service.exe.config");
      string pathHostAppConfig = Path.Combine(Ambiente.Selected.pathRmnet, "RM.Host.exe.config");

      _actionsPath.Value = ActionsPath;
      _apiPort.Value = ApiPort;
      _enableCompression.Value = EnableCompression.ToString();
      _enableDynamicLocalization.Value = EnableDynamicLocalization.ToString();
      _host.Value = Host;
      _httpPort.Value = HttpPort;
      _jobServer3Camadas.Value = JobServer3Camadas.ToString();
      _libPath.Value = LibPath;
      _localizationLaguage.Value = LocalizationLaguage;
      _port.Value = Port;
      _traceFileHost.Value = TraceFileHost.ToString();
      _traceFileRMExe.Value = TraceFileRMExe.ToString();
      _traceLs.Value = TraceLs.ToString();
      _configPath.Value = ConfigPath;
      _defaultDb.Value = DefaultDb;
      _updateServer.Value = UpdateServer;
      _updateServerEnabled.Value = UpdateServerEnabled.ToString();
      _fileServerPath.Value = FileServerPath.ToString();

      // Utilizando a ApdateAll para também atualizar o Config do JobRunner
      ConfigAction.UpdateAll(_actionsPath, Ambiente.Selected.pathRmnet);
      ConfigAction.UpdateAllSide(_apiPort, Ambiente.Selected.pathRmnet);
      ConfigAction.UpdateAll(_enableCompression, Ambiente.Selected.pathRmnet);
      ConfigAction.UpdateAll(_enableDynamicLocalization, Ambiente.Selected.pathRmnet);
      ConfigAction.UpdateAllSide(_host, Ambiente.Selected.pathRmnet);
      ConfigAction.UpdateAllSide(_httpPort, Ambiente.Selected.pathRmnet);
      ConfigAction.UpdateAll(_jobServer3Camadas, Ambiente.Selected.pathRmnet);
      ConfigAction.UpdateAll(_libPath, Ambiente.Selected.pathRmnet);
      ConfigAction.UpdateAll(_localizationLaguage, Ambiente.Selected.pathRmnet);
      ConfigAction.UpdateAll(_port, Ambiente.Selected.pathRmnet);
      ConfigAction.UpdateAllSide(_defaultDb, Ambiente.Selected.pathRmnet);


      if (_jobServer3Camadas.Value.ToLower() == "true")
      {
        ConfigAction.Add(_fileServerPath, pathHostAppConfig);
        ConfigAction.Add(_fileServerPath, pathHostServiceConfig);
      }
      else
      {
        ConfigAction.Remove(_fileServerPath, pathHostAppConfig);
        ConfigAction.Remove(_fileServerPath, pathHostServiceConfig);
      }

      if (_updateServerEnabled.Value.ToLower() == "true")
      {
        ConfigAction.Remove(_updateServer, pathRMExeConfig);
        ConfigAction.Remove(_updateServerEnabled, pathHostAppConfig);
        ConfigAction.Remove(_updateServerEnabled, pathHostServiceConfig);

        ConfigAction.Add(_updateServer, pathRMExeConfig);
        ConfigAction.Add(_updateServerEnabled, pathHostAppConfig);
        ConfigAction.Add(_updateServerEnabled, pathHostServiceConfig);
      }
      else if(_updateServer.Value != "0" && _updateServer.Value != "")
      {
        ConfigAction.Remove(_updateServer, pathRMExeConfig);
        ConfigAction.Remove(_updateServerEnabled, pathHostAppConfig);
        ConfigAction.Remove(_updateServerEnabled, pathHostServiceConfig);

        ConfigAction.Add(_updateServer, pathRMExeConfig);
      }
      else
      {
        ConfigAction.Remove(_updateServer, pathRMExeConfig);
        ConfigAction.Remove(_updateServerEnabled, pathHostAppConfig);
        ConfigAction.Remove(_updateServerEnabled, pathHostServiceConfig);
      }
      

      if (_traceFileHost.Value.ToLower() == "true")
      {
        ConfigAction.Remove(_traceFileHost, pathHostServiceConfig);
        ConfigAction.Remove(_traceFileHost, pathHostAppConfig);

        ConfigAction.Add(_traceFileHost, pathHostServiceConfig);
        ConfigAction.Add(_traceFileHost, pathHostAppConfig);
      }
      else
      {
        ConfigAction.Remove(_traceFileHost, pathHostServiceConfig);
        ConfigAction.Remove(_traceFileHost, pathHostAppConfig);
      }
      if (_traceFileRMExe.Value.ToLower() == "true")
      {
        ConfigAction.Remove(_traceFileRMExe, pathRMExeConfig);
        ConfigAction.Add(_traceFileRMExe, pathRMExeConfig);
      }
      else
        ConfigAction.Remove(_traceFileRMExe, pathRMExeConfig);

      if (_traceLs.Value.ToLower() == "true")
      {
        ConfigAction.Remove(_traceLs, pathHostServiceConfig);
        ConfigAction.Remove(_traceLs, pathHostAppConfig);

        ConfigAction.Add(_traceLs, pathHostServiceConfig);
        ConfigAction.Add(_traceLs, pathHostAppConfig);
      }
      else
      {
        ConfigAction.Remove(_traceLs, pathHostServiceConfig);
        ConfigAction.Remove(_traceLs, pathHostAppConfig);
      }
    }
  }
}


