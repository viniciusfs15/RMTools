using System.Collections.Generic;

namespace RMTools
{
  public class Config
  {
    public static Config Selected = new Config();

    public static List<Config> List = new List<Config>();
    public string name { get; set; }
    public string path { get; set; }

    public static void UpdateSelect(string configName)
    {
      foreach (var config in List)
      {
        if (config.name == configName)
        {
          Selected = config;
        }
      }
    }
  }
}