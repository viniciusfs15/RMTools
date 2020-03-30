using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestConnectionServer
{
  public class TestConnectionServerAction
  {
    public int Port;

    /// <summary>
    /// Inicia a escuta do servidor
    /// </summary>
    /// <param name="response"></param>
    public void Start(out string response)
    {
      SynchronousStart(this.Port, out response);
      ServerLog.Write("!.....Server iniciado................................");
    }

    /// <summary>
    /// Para a escuta do servidor
    /// </summary>
    public void Stop()
    {
      NetworkComms.Shutdown();
      ServerLog.Write("!.....Server desativado manualmente..................");
    }

    /*
    private void SynchronousStop(int port)
    {
      NetworkComms.Shutdown();
    }*/

    #region [... Print ...]
    private static void PrintIncomingMessage(PacketHeader header, Connection connection, string message)
    {
      string conn = connection.ToString().Replace("[TCP-E-E]", "").Split('-').First().Trim();
      ServerLog.Write("[" + DateTime.Now + "][Incoming][" + conn.ToString() + "][" + message + "]");
    }

    private static void PrintOutputMessage(PacketHeader header, Connection connection, string message)
    {
      string conn = connection.ToString().Replace("[TCP-E-E]", "").Split('-').First().Trim();
      ServerLog.Write("[" + DateTime.Now + "][Output..][" + conn.ToString() + "][" + message + "]");
    }
    #endregion

    #region Synchronous
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Port"></param>
    /// <param name="response"></param>
    private static void SynchronousStart(int Port, out string response)
    {
      try
      {
        //Append a packet handler that will get executed when the server receives a "RequestCustomObject" packetType.
        //Note: The expected incoming object type here is irrelevant because the client is not providing an object
        //If the client does not provide an object when sending the incoming object is set to GetDefault(Type).
        NetworkComms.AppendGlobalIncomingPacketHandler<int>("RequestCustomObject", (packetHeader, connection, input) =>
        {
          //For this short example we just reply with a new CustomObject
          //CustomObject myCustomObject = new CustomObject("TESTE",1010);
          string myCustomObject = Guid.NewGuid().ToString().Split('-').First();


          PrintIncomingMessage(packetHeader, connection, myCustomObject);
          //When this is received by the client it will complete the synchronous request
          connection.SendObject("CustomObjectReply", myCustomObject);

          PrintOutputMessage(packetHeader, connection, myCustomObject);
        });

        Listening(Port);

        response = "Server em escuta nos endereços:";
        foreach (System.Net.IPEndPoint localEndPoint in Connection.ExistingLocalListenEndPoints(ConnectionType.TCP))
        response += Environment.NewLine + String.Format("{0}:{1}", localEndPoint.Address, localEndPoint.Port);
      }
      catch (Exception err)
      {
        response = err.ToString();
      }

    }

    private static void Listening(int Port)
    {
      //Start listening for incoming TCP connections
      //The 0 (zero) port number is used to select a random port. You can use a fixed port by changing this number.
      //If the fixed port is unavailable however you will have to handle a possible CommsSetupShutdownException
      Connection.StartListening(ConnectionType.TCP, new IPEndPoint(IPAddress.Any, Port));
      //Or if we want to use UDP
      //Connection.StartListening(ConnectionType.UDP, new IPEndPoint(IPAddress.Any, 1010));
    }
    #endregion

  }
}
