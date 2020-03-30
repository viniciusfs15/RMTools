using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Win32;

namespace RMTools
{
  public class RegistryMonitor : IDisposable
  {
    // Token: 0x060001AB RID: 427
    [DllImport("advapi32.dll", SetLastError = true)]
    private static extern int RegOpenKeyEx(IntPtr hKey, string subKey, uint options, int samDesired, out IntPtr phkResult);

    // Token: 0x060001AC RID: 428
    [DllImport("advapi32.dll", SetLastError = true)]
    private static extern int RegNotifyChangeKeyValue(IntPtr hKey, bool bWatchSubtree, RegistryMonitor.RegChangeNotifyFilterEnum dwNotifyFilter, IntPtr hEvent, bool fAsynchronous);

    // Token: 0x060001AD RID: 429
    [DllImport("advapi32.dll", SetLastError = true)]
    private static extern int RegCloseKey(IntPtr hKey);

    // Token: 0x060001AE RID: 430 RVA: 0x00008414 File Offset: 0x00006614
    protected virtual void OnRegChanged()
    {
      EventHandler regChanged = this.RegChanged;
      if (regChanged != null)
      {
        regChanged(this, null);
      }
    }

    // Token: 0x060001AF RID: 431 RVA: 0x00008434 File Offset: 0x00006634
    protected virtual void OnError(Exception e)
    {
      ErrorEventHandler error = this.Error;
      if (error != null)
      {
        error(this, new ErrorEventArgs(e));
      }
    }

    // Token: 0x1400000D RID: 13
    // (add) Token: 0x060001B0 RID: 432 RVA: 0x00008458 File Offset: 0x00006658
    // (remove) Token: 0x060001B1 RID: 433 RVA: 0x00008490 File Offset: 0x00006690
    public event EventHandler RegChanged;

    // Token: 0x1400000E RID: 14
    // (add) Token: 0x060001B2 RID: 434 RVA: 0x000084C8 File Offset: 0x000066C8
    // (remove) Token: 0x060001B3 RID: 435 RVA: 0x00008500 File Offset: 0x00006700
    public event ErrorEventHandler Error;

    // Token: 0x060001B4 RID: 436 RVA: 0x00008535 File Offset: 0x00006735
    public RegistryMonitor(RegistryKey registryKey)
    {
      this.InitRegistryKey(registryKey.Name);
    }

    // Token: 0x060001B5 RID: 437 RVA: 0x00008568 File Offset: 0x00006768
    public RegistryMonitor(string name)
    {
      if (name == null || name.Length == 0)
      {
        throw new ArgumentNullException("name");
      }
      this.InitRegistryKey(name);
    }

    // Token: 0x060001B6 RID: 438 RVA: 0x000085B7 File Offset: 0x000067B7
    public RegistryMonitor(RegistryHive registryHive, string subKey)
    {
      this.InitRegistryKey(registryHive, subKey);
    }

    // Token: 0x060001B7 RID: 439 RVA: 0x000085E8 File Offset: 0x000067E8
    private void InitRegistryKey(RegistryHive hive, string name)
    {
      switch (hive)
      {
        case RegistryHive.ClassesRoot:
          this._registryHive = RegistryMonitor.HKEY_CLASSES_ROOT;
          break;
        case RegistryHive.CurrentUser:
          this._registryHive = RegistryMonitor.HKEY_CURRENT_USER;
          break;
        case RegistryHive.LocalMachine:
          this._registryHive = RegistryMonitor.HKEY_LOCAL_MACHINE;
          break;
        case RegistryHive.Users:
          this._registryHive = RegistryMonitor.HKEY_USERS;
          break;
        case RegistryHive.PerformanceData:
          this._registryHive = RegistryMonitor.HKEY_PERFORMANCE_DATA;
          break;
        case RegistryHive.CurrentConfig:
          this._registryHive = RegistryMonitor.HKEY_CURRENT_CONFIG;
          break;
        case RegistryHive.DynData:
          this._registryHive = RegistryMonitor.HKEY_DYN_DATA;
          break;
        default:
          throw new InvalidEnumArgumentException("hive", (int)hive, typeof(RegistryHive));
      }
      this._registrySubName = name;
    }

    // Token: 0x060001B8 RID: 440 RVA: 0x00008698 File Offset: 0x00006898
    private void InitRegistryKey(string name)
    {
      string[] array = name.Split(new char[]
      {
        '\\'
      });
      string text = array[0];
      uint num = PrivateImplementationDetails.ComputeStringHash(text);
      if (num <= 1198714601u)
      {
        if (num <= 457190004u)
        {
          if (num != 126972219u)
          {
            if (num != 457190004u)
            {
              goto IL_154;
            }
            if (!(text == "HKEY_LOCAL_MACHINE"))
            {
              goto IL_154;
            }
            goto IL_12D;
          }
          else
          {
            if (!(text == "HKEY_CURRENT_CONFIG"))
            {
              goto IL_154;
            }
            this._registryHive = RegistryMonitor.HKEY_CURRENT_CONFIG;
            goto IL_17C;
          }
        }
        else if (num != 1097425318u)
        {
          if (num != 1198714601u)
          {
            goto IL_154;
          }
          if (!(text == "HKEY_USERS"))
          {
            goto IL_154;
          }
          this._registryHive = RegistryMonitor.HKEY_USERS;
          goto IL_17C;
        }
        else if (!(text == "HKEY_CLASSES_ROOT"))
        {
          goto IL_154;
        }
      }
      else
      {
        if (num <= 1596321728u)
        {
          if (num != 1568329430u)
          {
            if (num != 1596321728u)
            {
              goto IL_154;
            }
            if (!(text == "HKCU"))
            {
              goto IL_154;
            }
          }
          else if (!(text == "HKEY_CURRENT_USER"))
          {
            goto IL_154;
          }
          this._registryHive = RegistryMonitor.HKEY_CURRENT_USER;
          goto IL_17C;
        }
        if (num != 1713765061u)
        {
          if (num != 2536015487u)
          {
            goto IL_154;
          }
          if (!(text == "HKLM"))
          {
            goto IL_154;
          }
          goto IL_12D;
        }
        else if (!(text == "HKCR"))
        {
          goto IL_154;
        }
      }
      this._registryHive = RegistryMonitor.HKEY_CLASSES_ROOT;
      goto IL_17C;
      IL_12D:
      this._registryHive = RegistryMonitor.HKEY_LOCAL_MACHINE;
      goto IL_17C;
      IL_154:
      this._registryHive = IntPtr.Zero;
      throw new ArgumentException("The registry hive '" + array[0] + "' is not supported", "value");
      IL_17C:
      this._registrySubName = string.Join("\\", array, 1, array.Length - 1);
    }

    // Token: 0x060001B9 RID: 441 RVA: 0x00008838 File Offset: 0x00006A38
    private void MonitorThread()
    {
      try
      {
        this.ThreadLoop();
      }
      catch (Exception e)
      {
        this.OnError(e);
      }
      this._thread = null;
    }

    // Token: 0x060001BA RID: 442 RVA: 0x00008870 File Offset: 0x00006A70
    private void ThreadLoop()
    {
      IntPtr intPtr;
      int num = RegistryMonitor.RegOpenKeyEx(this._registryHive, this._registrySubName, 0u, 131089, out intPtr);
      if (num != 0)
      {
        throw new Win32Exception(num);
      }
      try
      {
        AutoResetEvent autoResetEvent = new AutoResetEvent(false);
        WaitHandle[] waitHandles = new WaitHandle[]
        {
          autoResetEvent,
          this._eventTerminate
        };
        while (!this._eventTerminate.WaitOne(0, true))
        {
          num = RegistryMonitor.RegNotifyChangeKeyValue(intPtr, true, this._regFilter, autoResetEvent.Handle, true);
          if (num != 0)
          {
            throw new Win32Exception(num);
          }
          if (WaitHandle.WaitAny(waitHandles) == 0)
          {
            this.OnRegChanged();
          }
        }
      }
      finally
      {
        if (intPtr != IntPtr.Zero)
        {
          RegistryMonitor.RegCloseKey(intPtr);
        }
      }
    }

    // Token: 0x1700005A RID: 90
    // (get) Token: 0x060001BB RID: 443 RVA: 0x00008924 File Offset: 0x00006B24
    // (set) Token: 0x060001BC RID: 444 RVA: 0x0000892C File Offset: 0x00006B2C
    public RegistryMonitor.RegChangeNotifyFilterEnum RegChangeNotifyFilter {
      get {
        return this._regFilter;
      }
      set {
        object threadLock = this._threadLock;
        lock (threadLock)
        {
          if (this.IsMonitoring)
          {
            throw new InvalidOperationException("Monitoring thread is already running");
          }
          this._regFilter = value;
        }
      }
    }

    // Token: 0x060001BD RID: 445 RVA: 0x00008980 File Offset: 0x00006B80
    public void Dispose()
    {
      this.Stop();
      this._disposed = true;
      GC.SuppressFinalize(this);
    }

    // Token: 0x1700005B RID: 91
    // (get) Token: 0x060001BE RID: 446 RVA: 0x00008995 File Offset: 0x00006B95
    public bool IsMonitoring {
      get {
        return this._thread != null;
      }
    }

    // Token: 0x060001BF RID: 447 RVA: 0x000089A0 File Offset: 0x00006BA0
    public void Start()
    {
      if (this._disposed)
      {
        throw new ObjectDisposedException(null, "This instance is already disposed");
      }
      object threadLock = this._threadLock;
      lock (threadLock)
      {
        if (!this.IsMonitoring)
        {
          this._eventTerminate.Reset();
          this._thread = new Thread(new ThreadStart(this.MonitorThread));
          this._thread.IsBackground = true;
          this._thread.Start();
        }
      }
    }

    // Token: 0x060001C0 RID: 448 RVA: 0x00008A30 File Offset: 0x00006C30
    public void Stop()
    {
      if (this._disposed)
      {
        throw new ObjectDisposedException(null, "This instance is already disposed");
      }
      object threadLock = this._threadLock;
      lock (threadLock)
      {
        Thread thread = this._thread;
        if (thread != null)
        {
          this._eventTerminate.Set();
          thread.Join();
        }
      }
    }

    // Token: 0x040000B0 RID: 176
    private const int KEY_QUERY_VALUE = 1;

    // Token: 0x040000B1 RID: 177
    private const int KEY_NOTIFY = 16;

    // Token: 0x040000B2 RID: 178
    private const int STANDARD_RIGHTS_READ = 131072;

    // Token: 0x040000B3 RID: 179
    private static readonly IntPtr HKEY_CLASSES_ROOT = new IntPtr(int.MinValue);

    // Token: 0x040000B4 RID: 180
    private static readonly IntPtr HKEY_CURRENT_USER = new IntPtr(-2147483647);

    // Token: 0x040000B5 RID: 181
    private static readonly IntPtr HKEY_LOCAL_MACHINE = new IntPtr(-2147483646);

    // Token: 0x040000B6 RID: 182
    private static readonly IntPtr HKEY_USERS = new IntPtr(-2147483645);

    // Token: 0x040000B7 RID: 183
    private static readonly IntPtr HKEY_PERFORMANCE_DATA = new IntPtr(-2147483644);

    // Token: 0x040000B8 RID: 184
    private static readonly IntPtr HKEY_CURRENT_CONFIG = new IntPtr(-2147483643);

    // Token: 0x040000B9 RID: 185
    private static readonly IntPtr HKEY_DYN_DATA = new IntPtr(-2147483642);

    // Token: 0x040000BA RID: 186
    private IntPtr _registryHive;

    // Token: 0x040000BB RID: 187
    private string _registrySubName;

    // Token: 0x040000BC RID: 188
    private object _threadLock = new object();

    // Token: 0x040000BD RID: 189
    private Thread _thread;

    // Token: 0x040000BE RID: 190
    private bool _disposed;

    // Token: 0x040000BF RID: 191
    private ManualResetEvent _eventTerminate = new ManualResetEvent(false);

    // Token: 0x040000C0 RID: 192
    private RegistryMonitor.RegChangeNotifyFilterEnum _regFilter = RegistryMonitor.RegChangeNotifyFilterEnum.Key | RegistryMonitor.RegChangeNotifyFilterEnum.Attribute | RegistryMonitor.RegChangeNotifyFilterEnum.Value | RegistryMonitor.RegChangeNotifyFilterEnum.Security;

    // Token: 0x0200005E RID: 94
    [Flags]
    public enum RegChangeNotifyFilterEnum
    {
      // Token: 0x0400019E RID: 414
      Key = 1,
      // Token: 0x0400019F RID: 415
      Attribute = 2,
      // Token: 0x040001A0 RID: 416
      Value = 4,
      // Token: 0x040001A1 RID: 417
      Security = 8
    }
  }
}