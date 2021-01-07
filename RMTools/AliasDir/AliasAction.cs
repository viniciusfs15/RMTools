using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace RMTools.AliasDir
{
  class AliasAction
  {
    public static List<Tag> ListTags(string aliasName)
    {
      aliasName = aliasName.ToLower();
      
      List<Tag> tags = new List<Tag>();

      string[] keys = new string[19];
      string[] values = new string[19];
      int count = 0;
      string alias = "0";

      string lastKey = "0";
      string lastSide = "0";

      Tag tagTest = new Tag("","");
      tagTest.Side = "0";

      using(XmlReader reader = new XmlTextReader(Path.Combine(Ambiente.Selected.pathRmnet, "Alias.dat")))
      {
        try
        {
          while (reader.Read())
          {
            if (tagTest.Value != "0" && tagTest.Side.ToLower() == aliasName)
            {
              tags.Add(tagTest);
              tagTest = new Tag("", "0");
            }
            switch (reader.NodeType)
            {
              case XmlNodeType.Element:
                if (reader.Name.ToLower() == "rmsaliasdata" || reader.Name.ToLower() == "dbconfig" || reader.Name.ToLower() == "")
                  break;
                tagTest.Key = reader.Name;
                tagTest.Value = "0";
                break;
              case XmlNodeType.Text:
                tagTest.Value = reader.Value;
                if (tagTest.Key.ToLower() == "alias")
                  lastSide = reader.Value;
                tagTest.Side = lastSide;
                break;
              default:
                break;
            }
          }
          /*
          for (int i = 0; i < count; i++)
          {
            Tag tag = new Tag(keys[i], values[i]);
            tags.Add(tag);
          }*/
        }
        catch (Exception)
        {
          throw;
        }
      }    
      return tags;
    }

    public static List<string> GetAliasNames()
    {
      List<string> result = new List<string>();
      bool alias = false;
      using (XmlReader reader = new XmlTextReader(Path.Combine(Ambiente.Selected.pathRmnet, "Alias.dat")))
      {     
        try
        {
          while (reader.Read())
          {
            switch (reader.NodeType)
            {
              case XmlNodeType.Element:
                if (reader.Name.ToLower() == "alias")
                {
                  alias = true;
                }
                break;
              case XmlNodeType.Text:
                if (alias)
                {
                  result.Add(reader.Value);
                  alias = false;
                }
                break;
              default:
                break;
            }
          }
        }
        catch (Exception)
        {
          throw;
        }
      }
      return result;
    }
  }
}
