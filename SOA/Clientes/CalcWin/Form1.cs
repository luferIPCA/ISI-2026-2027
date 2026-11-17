using System;
using System.Windows.Forms;

namespace CalcWin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WS.CalcWsPLusSoapClient ws = new WS.CalcWsPLusSoapClient(WS.CalcWsPLusSoapClient.EndpointConfiguration.CalcWsPLusSoap);

            ws.Soma(2, 3);
            MessageBox.Show(ws.Soma(2, 3).ToString(), "Caption");
        }
    }
}
