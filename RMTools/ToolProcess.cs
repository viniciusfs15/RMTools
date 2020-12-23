using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
using System.Management;
using System.Management.Instrumentation;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.ServiceProcess;
using System.Linq;

namespace RMTools
{
  public class ToolProcess
  {
    public static List<Host> ListHosts = new List<Host>();

    internal static bool VerifyHost(out string value)
    {
      value = "N/A";
      string pathHostService = GetProcessPath("RM.HOST.SERVICE").ToUpper();
      string pathHostApp = GetProcessPath("RM.HOST").ToUpper();

      if (pathHostService.ToUpper() == (Ambiente.Selected.pathRmnet + @"\RM.Host.Service.exe").ToUpper())
      {
        value = "Service";
        return true;
      }
      else if (pathHostApp.ToUpper() == (Ambiente.Selected.pathRmnet + @"\RM.Host.exe").ToUpper())
      {
        value = "App";
        return true;
      }
      else
      {
        return false;
      }
    }

    internal static bool VerifyHost(Ambiente ambiente, out string value)
    {
      value = "N/A";
      List<Host> hosts = ListHosts;

      Host host = hosts.Find(x => x.GetDiretory().ToUpper() == ambiente.pathRmnet.ToUpper());
      if (host != null)
      {
        if (host.Type == "Service")
        {
          value = "Service";
          return true;
        }
        else if (host.Type == "App")
        {
          value = "App";
          return true;
        }
      }
      return false;
    }

    private static string GetProcessPath(string processName)
    {
      Process[] listaProcessos = Process.GetProcesses();
      string retorno = processName;

      foreach (Process pr in listaProcessos)
      {
        if (pr.ProcessName.ToUpper() == processName)
        {
          retorno = pr.GetProcessPath();
        }
      }
      return retorno;
    }

    private static int GetProcessID(string processName)
    {
      Process[] listaProcessos = Process.GetProcesses();
      int retorno = 0;

      foreach (Process pr in listaProcessos)
      {
        if (pr.ProcessName.ToUpper() == processName.ToUpper() && Path.GetDirectoryName(pr.GetProcessPath()).ToUpper() == Ambiente.Selected.pathRmnet.ToUpper())
        {
          retorno = pr.Id;
        }
      }
      return retorno;
    }

    public static bool StartRMexe()
    {
      string value = "";

      if (!VerifyHost(Ambiente.Selected, out value))
      {
        return false;
      }
      System.Diagnostics.Process.Start(Ambiente.Selected.pathRmnet + @"\RM.exe", "multi=true");
      return true;
    }

    public static bool StopRMexe()
    {
      try
      {
        KillProcess(GetProcessID("RM"));
        return true;
      }
      catch
      {
        return false;
      }
    }

    public static void StartHostApp()
    {
      string result = "";
      bool condition = VerifyHost(out result);
      if (condition)
      {
        return;
      }
      else
      {
        if(File.Exists(Ambiente.Selected.pathRmnet + @"\RM.Host.exe"))
          System.Diagnostics.Process.Start(Ambiente.Selected.pathRmnet + @"\RM.Host.exe");
      }
    }

    public static void StopHostApp()
    {
      KillProcess("RM.Host.JobRunner");

      Host host = ListHosts.Find(x => Path.GetDirectoryName(x.HostPath).ToLower() == Ambiente.Selected.pathRmnet.ToLower());
      if(host != null)
      {
        if (host.Type == "App")
        {
          KillProcess(host.PID);
        }
      }
    }

    public static void ListarHosts()
    {
      ListHosts.Clear();
      Process[] listProcess = Process.GetProcesses();

      var rmHost = from n in listProcess
                  where n.ProcessName.Contains("RM.Host") 
                  && !n.ProcessName.Contains("ServiceManager")
                  && !n.ProcessName.Contains("Cleaner")
                  && !n.ProcessName.Contains("JobRunner")
                  select n;
      
      foreach (var process in rmHost)
      {
          Host host = new Host();
          host.Name = process.ProcessName;
          host.HostPath = process.GetProcessPath();
          host.PID = process.Id;
          if (process.ProcessName.Contains("Service"))
            host.Type = "Service";
          else
            host.Type = "App";
        ListHosts.Add(host);
      }
    }

    internal static bool CheckDomain()
    {
      try
      {
        if (Domain.GetComputerDomain().ToString().ToUpper() != "BH01.LOCAL")
        {
          return false;
        }
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }

    public static void StopHostService()
    {
      string result = "";
      bool condition = VerifyHost(out result);
      if (!condition)
      {
        return;
      }
      else if (result == "Service")
      {
        KillProcess("RM.Host.JobRunner");        
        Host host = ListHosts.Find(x => Path.GetDirectoryName(x.HostPath).ToLower() == Ambiente.Selected.pathRmnet.ToLower());
        if (host != null)
        {
          if (host.Type == "Service")
          {
            KillProcess(host.Name);
          }
        }
      }
    }

    public static void KillAmbiente()
    {
      try
      {
        StopRMexe();
        StopHostApp();
        StopHostService();
      }
      catch {  }
    }

    public static void KillProcess(int processID)
    {
      try
      {
        Process[] processArray = Process.GetProcesses();

        foreach (var process in processArray)
        {
          if (process.Id == processID)
          {
            process.Kill();
            process.Dispose();
          }
        }
      }
      catch {}
    }

    public static void KillProcess(string processName)
    {
      try
      {
        Process[] processArray = Process.GetProcesses();

        foreach (var process in processArray)
        {
          if (process.ProcessName == processName)
          {
            process.Kill();
            process.Dispose();
          }
        }
      }
      catch { }
    }

    public static void StartApp(Ambiente ambiente, string app)
    {
      ProcessStartInfo info = new ProcessStartInfo(ambiente.pathRmnet + @"\" + app, "multi=true");
      info.UseShellExecute = true;
      info.Verb = "runas";
      Process.Start(info);
    }

    public static bool DeleteBroker()
    {
      string result = "";
      string pathBroker = Ambiente.Selected.pathRmnet + @"\_Broker.dat";
      if (VerifyHost(out result))
      {
        return false;
      }
      if (System.IO.File.Exists(pathBroker))
      {
        try
        {
          System.IO.File.Delete(pathBroker);
        }
        catch (Exception)
        {
          return false;          
        }
      }
      return true;
    }

    public static DialogResult Print(string message, string cod)
    {
      DialogResult dialog = DialogResult.Abort;
      switch (cod.ToLower())
      {
        case ("e"):
          MessageBox.Show(message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
          break;
        case ("s"):
          MessageBox.Show(message, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.None);
          break;
        case ("w"):
          MessageBox.Show(message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          break;
        case ("y"):
          dialog = MessageBox.Show(message, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
          break;
        default:
          break;
      }
      return dialog;
    }

    public static string DirectoryPath()
    {
      string result = "c:\totvs";

      Tag tag = new Tag("Path","");

      result = ConfigAction.TagValue(Path.Combine(Directory.GetCurrentDirectory(), "RMTools.exe.config"), tag);
      if (result == "0")
      {
        CreateAppConfig();
        result = DirectoryPath();
      }
      return result;
    }

    private static void CreateAppConfig()
    {
      //XmlDocument config = new XmlDocument();
      string caminho = Path.Combine(Directory.GetCurrentDirectory(), "RMTools.exe.config");
      if (!File.Exists(caminho))
      {
        //System.IO.File.Create(caminho);
        string[] str = { "<?xml version=\"1.0\" encoding=\"utf-8\" ?>", "<configuration>", "  <appSettings>", "    <add key=\"Path\" value=\"C:\\totvs\" />", "  </appSettings>", " <startup>", "    <supportedRuntime version=\"v4.0\" sku=\".NETFramework,Version=v4.7.2\" />", "  </startup>", "</configuration>" };
        File.WriteAllLines(caminho, str);
      }
    }

  }
}