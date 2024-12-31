using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static AIBAM.ChatClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

using Button = System.Windows.Forms.Button;

namespace AIBAM.Forms
{
    public partial class FrmSugestao : Form
    {
        public ConfigModeloSugestao ConfigModelo { get; internal set; }
        readonly ChatClient chatClient = new ChatClient("localhost", 8080);
        internal ChatData chatData = new ChatData();
        public string path;
        public string imgPath;
        public string prompt;
        public string SugestaoSelecionada ="";
        public FrmSugestao()
        {
            InitializeComponent();
            chatClient.OnConect += ChatClient_Status;
            chatClient.OnMessageReceived += ChatClient_OnMessageReceived;
            this.FormClosing += FrmConfiguracoes_FormClosing;
        }
        private async void FrmSugestao_Load(object sender, EventArgs e)
        {
            // Conecta ao servidor e inicializa o chat após a conexão
            await chatClient.Connect(InicializarChat);
        }

        private void ChatClient_OnMessageReceived(string response)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => chatControl1.AddSugestResponse(response)));
                PreencherFlowLayoutComTexto();
            }
            else
            {
                chatControl1.AddSugestResponse(response);
                PreencherFlowLayoutComTexto();
            }
        }
        private void PreencherFlowLayoutComTexto()
        {
            // Obtém o texto do chat control
            string texto = chatControl1.RetornaTexto();

            if (string.IsNullOrWhiteSpace(texto))
            {
                MessageBox.Show("Nenhum texto encontrado para exibir.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Limpa o FlowLayoutPanel antes de adicionar novos itens
            flowLayoutPanel1.Controls.Clear();

            // Divide o texto em linhas
            string[] linhas = texto.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            // Itera pelas linhas para criar os "cards"
            foreach (string linha in linhas)
            {
                // Cria o painel para o card
                Panel card = new Panel
                {
                    BorderStyle = BorderStyle.FixedSingle,
                    Padding = new Padding(10),
                };
                card.Width = 200;
                card.Height = 200;

                // Adiciona um Label para o texto
                Label lblTexto = new Label
                {
                    Text = linha,
                    AutoSize = false,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Segoe UI", 10, FontStyle.Regular),
                    ForeColor = Color.Black
                };

                // Adiciona um botão para interagir com o card
                Button btnInteragir = new Button
                {
                    Text = "Selecionar",
                    Dock = DockStyle.Bottom,
                    BackColor = Color.DarkSeaGreen,
                    ForeColor = SystemColors.ControlLightLight,
                    Size = new Size(152, 29)
                };

                btnInteragir.Click += (sender, e) =>
                {
                    //MessageBox.Show($"Você selecionou: {linha}", "Item Selecionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Selecionar(linha);
                };

                // Adiciona os controles ao painel
                card.Controls.Add(lblTexto);
                card.Controls.Add(btnInteragir);

                // Adiciona o card ao FlowLayoutPanel
                flowLayoutPanel1.Controls.Add(card);
            }
        }




        private void ChatClient_Status(string response)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => SetarStatus(response)));
                Invoke(new Action(() => CarregarSugestoes()));
            }
            else
            {
                SetarStatus(response);
                CarregarSugestoes();
            }
        }
        private void FrmConfiguracoes_FormClosing(object? sender, FormClosingEventArgs e)
        {
            var chatData = new ChatData();
            chatData.Command = "sair";
            chatClient.SendMessage(chatData);
        }
        private async void CarregarSugestoes()
        {
            chatData.Command = "carregar_sugestao";
            chatData.OpcaoModelo = ConfigModelo.Modelo.IdentificacaoModelo;
            chatData.Modelo = ConfigModelo.Modelo.NomeModelo;
            chatData.Path = path;
            chatData.Prompt = prompt;

            if (!string.IsNullOrEmpty(imgPath))
            {
                chatData.ImgPath = imgPath;
            }

            await chatClient.SendMessage(chatData);
        }

        private void SetarStatus(string response)
        {
            try
            {
                if (string.IsNullOrEmpty(response))
                {
                    label1.Text = "Nenhum status recebido.";
                    progressBar1.Style = ProgressBarStyle.Blocks;
                    progressBar1.Value = 0;
                    return;
                }

                // Atualiza o texto do label com a resposta
                label1.Text = response;

                // Define o progresso com base no status da resposta
                if (response.Contains("Conectado"))
                {
                    progressBar1.Style = ProgressBarStyle.Continuous;
                    progressBar1.Value = 100;
                }
                else if (response.Contains("Tentativa"))
                {
                    progressBar1.Style = ProgressBarStyle.Marquee; // Indicador de progresso indefinido
                }
                else if (response.Contains("Erro"))
                {
                    progressBar1.Style = ProgressBarStyle.Blocks;
                    progressBar1.Value = 0;
                }
                else
                {
                    // Estado genérico
                    progressBar1.Style = ProgressBarStyle.Blocks;
                    progressBar1.Value = 50;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar o status: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async Task InicializarChat()
        {
            //try
            //{
            //    chatData.Command = "instanciar_chat";
            //    await chatClient.SendMessage(chatData);
            //}
            //catch (Exception ex)
            //{
            //    // Log ou exibição de erro
            //    MessageBox.Show($"Erro ao inicializar o chat: {ex.Message}");
            //}
        }

        private void Selecionar(string select)
        {
            SugestaoSelecionada = select;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var tipo = this.Text.Split();
            FrmConfigSugestao frm = new();
            frm.modeloSugestao = ConfigModelo;
            frm.Text = $"AIBAM | SUGESTÕES {tipo[3].ToUpper()}";
            frm.Tipo = tipo[3].ToLower();
            frm.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            CarregarSugestoes();
        }
    }
}
