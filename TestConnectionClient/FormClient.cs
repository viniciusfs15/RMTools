using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestConnectionClient
{
  public partial class FormClient : Form
  {
    private int _port;

    private string _ip;

    TimerThreading _timer = new TimerThreading();

    public FormClient()
    {
      InitializeComponent();
      toolTip1.SetToolTip(txbIP, "Insira o Endereço IP do Servidor de Testes.");
      toolTip1.SetToolTip(txbPort, "Insira a Porta do Servidor de Testes.");
      toolTip1.SetToolTip(txbIntervalo, "Intervalo de tempo (em segundos) entre os requests e respostas entre Cliente e Servidor.");
    }

    public void UpdateGif()
    {
      if (txbLog.Text == TestConnectionClientAction.response)
      {
        return;
      }
      else if (TestConnectionClientAction.response == "Conectado!")
        picGif.Image = TestConnectionClient.Properties.Resources.Server_Connect;
      else if (TestConnectionClientAction.response != "Conectado!")
        picGif.Image = TestConnectionClient.Properties.Resources.Server_Disconnect;
    }

    private void btnIniciar_Click(object sender, EventArgs e)
    {
      if (!ValidateInputs())
      {
        MessageBox.Show("É necessário preencher todos os campos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      else if (btnIniciar.Text == "Iniciar"  && ValidateInputs())
      {
        timer1.Interval = 3000;
        timer1.Start();
        _ip = txbIP.Text.ToString();
        _port = Convert.ToInt32(txbPort.Text.ToString());
        pnlCampos.Enabled = false;
        btnIniciar.Text = "Parar";
        _timer.Start(_ip, _port);
      }
      else if (btnIniciar.Text == "Parar")
      {
        timer1.Stop();
        pnlCampos.Enabled = true;
        btnIniciar.Text = "Iniciar";
        
        _timer.Stop();
        picGif.Image = null;
        txbLog.Text = "";
      }
    }

    private static void Logar(object sender, EventArgs e)
    {
      Console.WriteLine("TESTE");
      Environment.Exit(0);
    }

    private bool ValidateInputs()
    {
      if (txbIP.Text != "" && txbPort.Text != "" && txbIntervalo.Text != "")
        return true;
      return false;
    }

    private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (!char.IsControl(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        e.Handled = true;
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      UpdateGif();
      txbLog.Text = TestConnectionClientAction.response;
    }
  }
}