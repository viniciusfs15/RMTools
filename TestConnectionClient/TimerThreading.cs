using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestConnectionClient
{
  public class TimerThreading
  {
    private static Timer _stateTimer;
    
    public void Start(string ip, int port)
    {
      AutoResetEvent autoEvent = new AutoResetEvent(false);
      StatusChecker statusChecker = new StatusChecker(-1, ip, port);

      _stateTimer = new Timer(statusChecker.CheckStatus,
                                 autoEvent, 1000, 1300);      
    }

    public void Stop()
    {
      _stateTimer.Change(-1, -1);
      _stateTimer.Dispose();
    }
  }

  class StatusChecker
  {
    private int invokeCount;
    private int maxCount;
    private string _ip;
    private int _port;

    public StatusChecker(int count, string ip, int port)
    {
      invokeCount = 0;
      maxCount = count;
      _ip = ip;
      _port = port;
    }

    public void CheckStatus(Object stateInfo)
    {
      AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;

      TestConnectionClientAction server = new TestConnectionClientAction();
      server.Request(_ip, _port);

      if (invokeCount == maxCount)
      {
        invokeCount = 0;
        autoEvent.Set();
      }
    }
  }
}