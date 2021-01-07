using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RMTools.AliasDir
{
  public class AliasDat
  {
    public static List<AliasDat> ListAlias = new List<AliasDat>();
    public static AliasDat Selected = new AliasDat();
    public static List<string> ListAliasNames = new List<string>();

    public Tag Alias { get; set; }
    public Tag DbType { get; set; }
    public Tag DbProvider { get; set; }
    public Tag DbServer { get; set; }
    public Tag DbName { get; set; }
    public Tag UserName { get; set; }
    public Tag Password { get; set; }
    public Tag RunService { get; set; }
    public Tag JobServerEnabled { get; set; }
    public Tag JobServerMaxThreads { get; set; }
    public Tag JobServerLocalOnly { get; set; }
    public Tag JobServerPollingInterval { get; set; }
    public Tag ChartAlertEnabled { get; set; }
    public Tag ChartAlertPollingInterval { get; set; }
    public Tag ChartHistoryEnabled { get; set; }
    public Tag ChartHistoryPollingInterval { get; set; }
    public Tag RSSReaderMailEnabled { get; set; }
    public Tag RSSReaderMailPollingInterval { get; set; }
    public Tag JobServerProcessPoolEnabled { get; set; }

    public static void InitializeAliasDat()
    {
      ListAlias.Clear();
      ListAliasNames.Clear();

      ListAliasNames = AliasAction.GetAliasNames();
      foreach (string aliasName in ListAliasNames)
      {
        ListAlias.Add(GetAlias(aliasName));
      }
    }

    private static AliasDat GetAlias(string aliasName)
    {
      AliasDat alias = null;

      string caminhoAlias = Path.Combine(Ambiente.Selected.pathRmnet, "Alias.dat");
      if (!File.Exists(caminhoAlias))
        return alias;

      List<Tag> tags = AliasAction.ListTags(aliasName);

      alias = new AliasDat();

      alias.Alias = tags.Find(x => x.Key == "Alias");
      alias.DbType = tags.Find(x => x.Key == "DbType");
      alias.DbProvider = tags.Find(x => x.Key == "DbProvider");
      alias.DbServer = tags.Find(x => x.Key == "DbServer");
      alias.DbName = tags.Find(x => x.Key == "DbName");
      alias.UserName = tags.Find(x => x.Key == "UserName");
      alias.Password = tags.Find(x => x.Key == "Password");
      alias.RunService = tags.Find(x => x.Key == "RunService");
      alias.JobServerEnabled = tags.Find(x => x.Key == "JobServerEnabled");
      alias.JobServerMaxThreads = tags.Find(x => x.Key == "JobServerMaxThreads");
      alias.JobServerLocalOnly = tags.Find(x => x.Key == "JobServerLocalOnly");
      alias.JobServerPollingInterval = tags.Find(x => x.Key == "JobServerPollingInterval");
      alias.ChartAlertEnabled = tags.Find(x => x.Key == "ChartAlertEnabled");
      alias.ChartAlertPollingInterval = tags.Find(x => x.Key == "ChartAlertPollingInterval");
      alias.ChartHistoryEnabled = tags.Find(x => x.Key == "ChartHistoryEnabled");
      alias.ChartHistoryPollingInterval = tags.Find(x => x.Key == "ChartHistoryPollingInterval");
      alias.RSSReaderMailEnabled = tags.Find(x => x.Key == "RSSReaderMailEnabled");
      alias.RSSReaderMailPollingInterval = tags.Find(x => x.Key == "RSSReaderMailPollingInterval");
      alias.JobServerProcessPoolEnabled = tags.Find(x => x.Key == "JobServerProcessPoolEnabled");

      return alias;
    }

  }
}
