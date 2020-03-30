using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestConnectionServer
{
  public partial class FormServer : Form
  {
    public FormServer()
    {
      InitializeComponent();
    }

    private void btnIniciar_Click(object sender, EventArgs e)
    {
      string response = "Server parado.";
      TestConnectionServerAction server = new TestConnectionServerAction();
      if (txbPort.Text != "" && btnIniciar.Text == "Iniciar")
      {
        server.Port = Convert.ToInt32(txbPort.Text);
        server.Start(out response);
        btnIniciar.Text = "Parar";
        txbPort.Enabled = false;
        picBox.Image = TestConnectionServer.Properties.Resources.switch_on_icon;
      }
      else if (txbPort.Text == "" && btnIniciar.Text == "Iniciar")
      {
        MessageBox.Show("Para iniciar entre com uma porta válida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      else if (btnIniciar.Text == "Parar")
      {
        server.Stop();
        btnIniciar.Text = "Iniciar";
        txbPort.Enabled = true;
        picBox.Image = TestConnectionServer.Properties.Resources.switch_off_icon;
      }
      txbLog.Text = response;
    }

    private void txbPort_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (!char.IsControl(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        e.Handled = true;
    }
  }
}
