using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections.TCP;
using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConnectionClient
{
  class TestConnectionClientAction
  {
    public static string response { get; private set; }

    #region Print
    private void PrintRequestMessage(string ip, int port)
    {
      string conn = String.Format("{0}:{1}", ip, port);
      ClientLog.Write("[" + DateTime.Now + "][Request..][" + conn + "]");
    }

    private void PrintResponseMessage(string ip, int port, string objt)
    {
      string conn = String.Format("{0}:{1}", ip, port);
      ClientLog.Write("[" + DateTime.Now + "][Incoming.][" + conn + "][Response: " + objt + "]");
    }

    private void PrintErrorMessage(string ip, int port, string msg)
    {
      string conn = String.Format("{0}:{1}", ip, port);
      ClientLog.Write("##\n[" + DateTime.Now + "][Error....][" + conn + "][Details.: " + msg + "]\n##");
    }

    #endregion

    /// <summary>
    /// Faz o request com o servidor e aguarda o retorno.
    /// </summary>
    /// <param name="ip"></param>
    /// <param name="port"></param>
    public void Request(string ip, int port)
    {
      try
      {
        // Cria o objeto ConnectionInfo com o IP e Porta recebidos
        ConnectionInfo connectionInfo = new ConnectionInfo(ip, port);

        // Cria o Get da conexão com o Servidor
        TCPConnection serverConnection = TCPConnection.GetConnection(connectionInfo);

        // Imprime no log as informações do Request
        PrintRequestMessage(ip, port);

        // Faz o request e aguarda o retorno do servidor
        string myCustomObject = serverConnection.SendReceiveObject<string>("RequestCustomObject", "CustomObjectReply", 3000);

        // Imprime no log a resposta do servidor
        PrintResponseMessage(ip, port, myCustomObject);
        response = "Conectado!";

      }
      catch (Exception err)
      {
        if (err is ExpectedReturnTimeoutException)
        {
          string message = "Receive timed out after the 3000ms";
          response = message;
          PrintErrorMessage(ip, port, message);
        }
        else if (err is ConnectionSetupException)
        {
          string message = "Falha ao conectar com o servidor de testes no endereço: " + ip + ":" + port;
          response = message;
          PrintErrorMessage(ip, port, message);
        }
        else if (err is ConnectionShutdownException)
        {
          string message = "A comunicação com o Servidor não recebeu uma resposta";
          response = message;
          PrintErrorMessage(ip, port, message);
        }
        else
        {
          PrintErrorMessage(ip, port, err.ToString());
          response = err.ToString();
        }

      }

    }
  }
}
