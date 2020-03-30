using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TestConnectionServer
{
  public static class ServerLog
  {
    private static string logName;
    private static string logFullName;
    private static DateTime logDate;

    /// <summary>
    /// Verifica a data do arquivo de log criado
    /// </summary>
    /// <returns></returns>
    private static bool VerifyLogDate()
    {
      if (logDate.AddHours(1) >= DateTime.Now)
        return false;
      else
        return true;
    }

    /// <summary>
    /// Grava a string recebida no log
    /// </summary>
    /// <param name="message"></param>
    public static void Write(string message)
    {
      VerifyLog();

      using (StreamWriter sw = File.AppendText(logFullName))
      {
        sw.WriteLine(message);
      }
    }

    /// <summary>
    /// Verifica se o log já existe
    /// </summary>
    private static void VerifyLog()
    {
      if (logDate.ToString() == "01/01/0001 00:00:00")
        CreateArchive();
      else
      {
        if (VerifyLogDate())
          CreateArchive();
      }
    }

    /// <summary>
    /// Cria o arquivo de log
    /// </summary>
    private static void CreateArchive()
    {
      CreateDirectory();

      string caminho = Directory.GetCurrentDirectory() + "\\Logs\\Server";

      logDate = DateTime.Now;
      string cod = DateTime.Now.ToString().Replace("/", "_").Replace(":", "-").Replace(" ", "#").Trim();
      logName = String.Format("{0}_{1}", "ServerLOG", cod);
      logFullName = String.Format("{0}\\{1}.txt", caminho, logName);
      string[] lines = {"Inicio do Log", DateTime.Now.ToString(), "_______________________________________________________"};
      System.IO.File.WriteAllLines(logFullName, lines);
    }

    /// <summary>
    /// Cria o diretório para guardar os logs
    /// </summary>
    private static void CreateDirectory()
    {
      string caminho = Directory.GetCurrentDirectory() + "\\Logs\\Server";
      if (Directory.Exists(caminho))
      {
        return;
      }
      Directory.CreateDirectory(caminho);
    }
  }
}
