using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMTools
{
  public class Tag
  {
    public string Key;
    public string Value;
    public string Side; // Server / Client / Both
    public Tag(string key, string value)
    {
      this.Key = key;
      this.Value = value;
    }
  }
}
