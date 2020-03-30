using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RMTools
{
  public class Host
  {
    public string Name { get; set; }
    public string HostPath { get; set; }
    public string Type { get; set; }
    public int PID { get; set; }
    public string GetDiretory()
    {
      return Path.GetDirectoryName(HostPath);
    }
  }
}
