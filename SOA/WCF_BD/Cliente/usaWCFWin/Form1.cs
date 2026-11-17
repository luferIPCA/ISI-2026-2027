using System;
using System.Data;  //DataSet
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
using WS;
using System.Xml;
using System.ServiceModel;

namespace usaWCFWin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Desativar o botão para evitar cliques duplicados
            button1.Enabled = false;
            Cursor = Cursors.WaitCursor;

            try
            {
                // 1. Instanciar o cliente SOAP gerado
                WS.VoosClient ws = new WS.VoosClient();
                //WS.VoosClient ws = new WS.VoosClient(WS.VoosClient.EndpointConfiguration.BasicHttpBinding_IVoos);
                
                var request = new WS.GetAllFlightsRequest();

                // 2. Chamar o serviço de forma assíncrona
                WS.GetAllFlightsResponse listaVoos = await ws.GetAllFlightsAsync(request);

                //ArrayOfXElement
                WS.ArrayOfXElement result = listaVoos.GetAllFlightsResult;

                //Cria DataSet para mostrar na Grid
                DataSet ds = new DataSet();
                if (result?.Nodes != null && result.Nodes.Count > 0)
                {
                    // Agrupa todos os nós num elemento raiz temporário
                    XElement raiz = new XElement("Root", result.Nodes);

                    using (XmlReader reader = raiz.CreateReader())
                    {
                        ds.ReadXml(reader);
                    }
                }

                // Verifica se o DataSet tem pelo menos uma tabela com dados
                if (ds != null && ds.Tables.Count > 0)
                {
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao comunicar com o serviço SOAP: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Restaurar o cursor e o botão
                button1.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Hoteis
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button2_Click(object sender, EventArgs e)
        {
            

            // Desativar o botão para evitar cliques duplicados
            button2.Enabled = false;
            Cursor = Cursors.WaitCursor;

            try
            {
                // 1. Instanciar o cliente SOAP gerado
                WSH.HotelsClient ws = new WSH.HotelsClient();

                // 2. Preparar pedido
                var request = new WSH.GetAllHoteisCidadeRequest();

                //Por omissão
                request.cidade = "Viana do Castelo";
                if (textBox1.Text.Length > 0)
                    request.cidade = textBox1.Text;
      

                // 2. Chamar o serviço de forma assíncrona
                WSH.GetAllHoteisCidadeResponse h = await ws.GetAllHoteisCidadeAsync(request);

                //MessageBox.Show(listaVoos.GetType().FullName);

                //ArrayOfXElement
                WSH.ArrayOfXElement result = h.GetAllHoteisCidadeResult;

                //Cria DataSet para mostrar na Grid
                DataSet ds = new DataSet();
                if (result?.Nodes != null && result.Nodes.Count > 0)
                {
                    // Agrupa todos os nós num elemento raiz temporário
                    XElement raiz = new XElement("Root", result.Nodes);

                    using (XmlReader reader = raiz.CreateReader())
                    {
                        ds.ReadXml(reader);
                    }
                }

                // Verifica se o DataSet tem pelo menos uma tabela com dados
                if (ds != null && ds.Tables.Count > 0)
                {
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao comunicar com o serviço SOAP: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Restaurar o cursor e o botão
                button2.Enabled = true;
                Cursor = Cursors.Default;
            }

        }
    }
}
