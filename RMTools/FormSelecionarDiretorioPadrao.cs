using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace RMTools
{
  public partial class FormSelecionarDiretorioPadrao : Form
  {
    public FormSelecionarDiretorioPadrao()
    {
      InitializeComponent();
      CreateAppConfig();
    }

    private static void CreateAppConfig()
    {
      XmlDocument config = new XmlDocument();
      string caminho = Path.Combine(Directory.GetCurrentDirectory(), "RMTools.exe.config");
      if (!File.Exists(caminho))
      {
        System.IO.File.Create(caminho);
        string str = "<?xml version=\"1.0\" encoding=\"utf - 8\" ?>" +
                     "<configuration>" +
                     "  <appSettings>" +
                     "    <add key=\"Path\" value=\"C:\\totvs\" />" +
                     "  </appSettings>" +
                     "</configuration>";
        config.Value = str;
        config.Save(caminho);
      }
    }

    private void btnSelecionar_Click(object sender, EventArgs e)
    {
      if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
      {
        txtDiretorio.Text = folderBrowserDialog1.SelectedPath;
      }
    }

    private void btnSalvar_Click(object sender, EventArgs e)
    {
      ConfigAction.Update(Path.Combine(Directory.GetCurrentDirectory(), "RMTools.exe.config"), "Path", txtDiretorio.Text);
      this.Close();
    }
  }
}
