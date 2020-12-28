using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace RMTools
{
  class ConfigAction
  {
    public static void Remove(string configPath, string key)
    {
      if (File.Exists(configPath))
      {
        try
        {
          XDocument config = XDocument.Load(configPath);
          XElement appSettings = config.Element("configuration").Element("appSettings");
          appSettings.Descendants("add").Where(x => (string)x.Attribute("key") == key).Remove();
          config.Save(configPath);
        }
        catch (Exception err)
        {
          //throw Log.Write("Config.Remove:\n" + err);
        }
      }
    }

    public static void Remove(Tag tag, string configPath)
    {
      if (File.Exists(configPath))
      {
        try
        {
          XDocument config = XDocument.Load(configPath);
          XElement appSettings = config.Element("configuration").Element("appSettings");
          appSettings.Descendants("add").Where(x => (string)x.Attribute("key") == tag.Key).Remove();
          config.Save(configPath);
        }
        catch (Exception err)
        {
          //throw Log.Write("Config.Remove:\n" + err);
        }
      }
    }

    public static void Add(string configPath, string key, string value)
    {
      if (File.Exists(configPath))
      {
        try
        {
          XDocument config = XDocument.Load(configPath);
          if (!TagExists(key, configPath))
          {
            XElement appSettings = config.Element("configuration").Element("appSettings");

            // Cria Elemento
            XElement add = new XElement("add");
            add.SetAttributeValue("key", key);
            add.SetAttributeValue("value", value.ToLower());

            appSettings.Add(add);

            config.Save(configPath);
          }
        }
        catch (Exception err)
        {
          //throw Log.Write("Config.Add:\n" + err);
        }
      }
    }

    public static void Add(Tag tag, string configPath)
    {
      if (File.Exists(configPath))
      {
        try
        {
          XDocument config = XDocument.Load(configPath);
          if (!TagExists(configPath, tag.Key))
          {
            XElement appSettings = config.Element("configuration").Element("appSettings");

            // Cria Elemento
            XElement add = new XElement("add");
            add.SetAttributeValue("key", tag.Key);
            add.SetAttributeValue("value", tag.Value.ToLower());

            appSettings.Add(add);

            config.Save(configPath);
          }
          else Update(configPath, tag.Key, tag.Value);
        }
        catch (Exception err)
        {
          //throw Log.Write("Config.Add:\n" + err);
        }
      }
    }

    private static bool TagExists(string configPath, string key)
    {

      XmlDocument config = new XmlDocument();

      config.Load(configPath);
      XmlNodeList nodeList = (config.SelectNodes("configuration/appSettings/add"));

      foreach (XmlNode elem in nodeList)
      {
        if (elem.Attributes[0].Value.ToUpper() == key.ToUpper())
          return true;
      }

      return false;
    }

    public static void Update(string configPath, string key, string value)
    {
      try
      {
        XmlDocument config = new XmlDocument();
        if (File.Exists(configPath))
        {
          config.Load(configPath);
          XmlNodeList nodeList = (config.SelectNodes("configuration/appSettings/add"));

          foreach (XmlNode elem in nodeList)
          {
            if (elem.Attributes[0].Value.ToUpper() == key.ToUpper())
              elem.Attributes[1].Value = value.ToLower();
          }
          config.Save(configPath);
        }
      }
      catch (Exception err)
      {
        //throw Log.Write("Config.Update:\n" + err);
      }
    }

    public static void Update(Tag tag, string caminhoConfig)
    {
      try
      {
        XmlDocument config = new XmlDocument();
        if (File.Exists(caminhoConfig))
        {
          config.Load(caminhoConfig);
          XmlNodeList nodeList = (config.SelectNodes("configuration/appSettings/add"));

          foreach (XmlNode elem in nodeList)
          {
            if (elem.Attributes[0].Value.ToUpper() == tag.Key.ToUpper())
              elem.Attributes[1].Value = tag.Value.ToLower();
          }
          config.Save(caminhoConfig);
        }
      }
      catch (Exception err)
      {
        //throw Log.Write("Config.Update:\n" + err);
      }
    }

    public static void UpdateAll(Tag tag, string caminho)
    {
      try
      {
        List<string> listConfig = ListConfigPath(caminho);
        foreach (string caminhoConfig in listConfig)
        {
          XmlDocument config = new XmlDocument();
          if (File.Exists(caminhoConfig))
          {
            config.Load(caminhoConfig);
            XmlNodeList nodeList = (config.SelectNodes("configuration/appSettings/add"));

            foreach (XmlNode elem in nodeList)
            {
              if (elem.Attributes[0].Value.ToUpper() == tag.Key.ToUpper())
                elem.Attributes[1].Value = tag.Value.ToLower();
            }
            config.Save(caminhoConfig);
          }
        }
      }
      catch (Exception err)
      {
        //throw Log.Write("Config.Update:\n" + err);
      }
    }

    /// <summary>
    /// Atualiza os arquivos Config conforme o Side da TAG recebida
    /// </summary>
    /// <param name="tag"></param>
    /// <param name="caminho"></param>
    public static void UpdateAllSide(Tag tag, string caminho)
    {
      try
      {
        List<string> listConfig = ListConfigPath(caminho, tag);
        foreach (string caminhoConfig in listConfig)
        {
          XmlDocument config = new XmlDocument();
          if (File.Exists(caminhoConfig))
          {
            config.Load(caminhoConfig);
            XmlNodeList nodeList = (config.SelectNodes("configuration/appSettings/add"));

            foreach (XmlNode elem in nodeList)
            {
              if (elem.Attributes[0].Value.ToUpper() == tag.Key.ToUpper())
                elem.Attributes[1].Value = tag.Value;
            }
            config.Save(caminhoConfig);
          }
        }
      }
      catch (Exception err)
      {
        //throw Log.Write("Config.Update:\n" + err);
      }
    }

    public static string TagValue(string configPath, Tag tag)
    {
      XmlDocument config = new XmlDocument();
      if (File.Exists(configPath))
      {
        config.Load(configPath);
        XmlNodeList nodeList = (config.SelectNodes("configuration/appSettings/add"));

        foreach (XmlNode elem in nodeList)
        {
          if (elem.Attributes[0].Value.ToUpper() == tag.Key.ToUpper())
            return elem.Attributes[1].Value.ToString();
        }
      }

      return "0";
    }

    public static List<string> ListConfigName(string caminhoAmbiente)
    {
      List<string> arquivos = new List<string>();

      foreach (var arquivo in Directory.GetFiles(caminhoAmbiente))
      {
        if (arquivo.Contains(".config"))
        {
          string[] array = arquivo.Split(Path.DirectorySeparatorChar);
          arquivos.Add(@"\\" + array[array.Length - 1].ToUpper());
        }

      }
      return arquivos;
    }

    public static List<string> ListConfigPath(string caminhoAmbiente)
    {
      List<string> arquivos = new List<string>();

      foreach (var arquivo in Directory.GetFiles(caminhoAmbiente))
      {
        if (arquivo.Contains(".config"))
          arquivos.Add(arquivo.ToString());
      }
      return arquivos;
    }

    public static List<string> ListConfigPath(string caminhoAmbiente, Tag tag)
    {
      List<string> arquivos = new List<string>();
      string side = tag.Side;

      switch (side)
      {
        case "Both":
          if (tag.JobRunner)
            arquivos = ListConfigPath(caminhoAmbiente);
          else
            foreach (var arquivo in Directory.GetFiles(caminhoAmbiente))
            {
              if (arquivo.Contains(".config") && !arquivo.Contains("JobRunner"))
                arquivos.Add(arquivo.ToString());
            }
          return arquivos;

        case "Server":
          if (tag.JobRunner)
          {
            foreach (var arquivo in Directory.GetFiles(caminhoAmbiente))
            {
              if (arquivo.Contains(".config") && arquivo.Contains("Host"))
                arquivos.Add(arquivo.ToString());
            }
          }
          else
            foreach (var arquivo in Directory.GetFiles(caminhoAmbiente))
            {
              if (arquivo.Contains(".config") && arquivo.Contains("Host") && !arquivo.Contains("JobRunner"))
                arquivos.Add(arquivo.ToString());
            }
          return arquivos;

        case "Client":
          foreach (var arquivo in Directory.GetFiles(caminhoAmbiente))
          {
            if (arquivo.Contains(".config") && !arquivo.Contains("Host"))
              arquivos.Add(arquivo.ToString());
          }
          return arquivos;

        default:
          return arquivos;

      }
    }
  }
}
