using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace RMTools
{
  public static class ProcessExtensions
  {
    /// <summary>
    /// Returns the process executable full path
    /// </summary>
    /// <param name="Process">The process</param>
    /// <returns>A string containing the process executable path</returns>
    public static string GetProcessPath(this Process Process)
    {
      int capacity = 1024;
      StringBuilder sb = new StringBuilder(capacity);

      IntPtr handle = OpenProcess(ProcessAccessFlags.QueryLimitedInformation, false, Process.Id);

      QueryFullProcessImageName(handle, 0, sb, ref capacity);

      string fullPath = sb.ToString(0, capacity);
      CloseHandle(handle);
      return fullPath;
    }

    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool CloseHandle(IntPtr hObject);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool QueryFullProcessImageName([In]IntPtr hProcess, [In]int dwFlags, [Out]StringBuilder lpExeName, ref int lpdwSize);

    [DllImport("kernel32.dll")]
    private static extern IntPtr OpenProcess(
         ProcessAccessFlags processAccess,
         bool bInheritHandle,
         int processId
    );

    [Flags]
    private enum ProcessAccessFlags : uint
    {
      All = 0x001F0FFF,
      Terminate = 0x00000001,
      CreateThread = 0x00000002,
      VirtualMemoryOperation = 0x00000008,
      VirtualMemoryRead = 0x00000010,
      VirtualMemoryWrite = 0x00000020,
      DuplicateHandle = 0x00000040,
      CreateProcess = 0x000000080,
      SetQuota = 0x00000100,
      SetInformation = 0x00000200,
      QueryInformation = 0x00000400,
      QueryLimitedInformation = 0x00001000,
      Synchronize = 0x00100000
    }
  }
}
