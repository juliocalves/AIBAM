using Markdig;

using Microsoft.Web.WebView2.Core;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

using static AIBAM.ChatClient;
using static AIBAM.WebControl;
using static System.Runtime.InteropServices.JavaScript.JSType;
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
        private string htmlFilePath = @"A:\DESKTOP\AIBAM\src\html\SugestaoPage.html"; // Caminho para o arquivo HTML
        public FrmSugestao()
        {
            InitializeComponent();
            InitializeWebViewAsync();
            chatClient.OnConect += ChatClient_Status;
            chatClient.OnMessageReceived += ChatClient_OnMessageReceived;
            this.FormClosing += FrmConfiguracoes_FormClosing;
            CarregaHtmlBase();
        }
        private bool IsProdutoSimilar = false;
        public FrmSugestao(string html)
        {
            InitializeComponent();
            InitializeWebViewAsync();
            htmlFilePath = html;
            chatClient.OnConect += ChatClient_Status;
            chatClient.OnMessageReceived += ChatClient_OnMessageReceived;
            this.FormClosing += FrmConfiguracoes_FormClosing;
            CarregaHtmlBase();
            IsProdutoSimilar = true;
            splitContainer1.Panel2Collapsed = true;
            splitContainer2.Panel1Collapsed = true;
        }
        private async void FrmSugestao_Load(object sender, EventArgs e)
        {
            // Conecta ao servidor e inicializa o chat após a conexão
            await chatClient.Connect(InicializarChat);
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
        private async Task InitializeWebViewAsync()
        {
            await webView.EnsureCoreWebView2Async();
            //SelecionarVoz();
            // Configurar tratamento de links externos (seu código existente)
            string filtroDeUrl = @"^(https?://)?(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)$";
            webView.NavigationStarting += (sender, e) =>
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(e.Uri, filtroDeUrl))
                {
                    e.Cancel = true;
                    FrmWeb frm = new(e.Uri);
                    frm.Show();
                }
               
            };
        }
  

        private void CarregaHtmlBase()
        {
            // Navega para o arquivo HTML
            if (File.Exists(htmlFilePath))
            {
                webView.Source = new Uri(htmlFilePath);
            }
            else
            {
                MessageBox.Show("O arquivo HTML não foi encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChatClient_OnMessageReceived(string response)
        {
            if (InvokeRequired)
            {
                if (IsProdutoSimilar)
                {
                    CarregarWebViewSimilares(response);
                }
                else
                {
                    PreencherWebViewComTexto(response);
                    FinalizaStatus();
                }
            }
            else
            {
                if (IsProdutoSimilar)
                {
                    CarregarWebViewSimilares(response);
                }
                else
                {
                    PreencherWebViewComTexto(response);
                    FinalizaStatus();
                }
            }
            
        }
        string builder = "";
        public async Task ScrollToBottomAsync()
        {
            // Este script obtém a altura total do documento e define o scroll para o final
            string script = @"
        (function() {
            window.scroll(0, document.body.scrollHeight);
            return document.body.scrollHeight;
        })();";

            // Executa o script no WebView2
            await webView.CoreWebView2.ExecuteScriptAsync(script);
        }
        private async void CarregarWebViewSimilares(string jsonResponse)
        {
            var res = JsonSerializer.Deserialize<ResJsonBody>(jsonResponse);
            builder += res.content;
            if (res.type == "data")
            {
                //// Converte o Markdown para HTML e escapa caracteres problemáticos
                //var htmlContent = Markdown.ToHtml(res.content, new MarkdownPipelineBuilder().UseAdvancedExtensions().Build())
                //    .Replace("'", "\\'").Replace("\n", "\\n").Replace("\r", "");
                //await SpeakText(res.content.Replace("'", "\\'").Replace("\n", "\\n").Replace("\r", ""));
                var htmlContent = res.content.Replace("'", "\\'").Replace("\n", "\\n").Replace("\r", "");
                // Injeta o fragmento no WebView
                await webView.CoreWebView2.ExecuteScriptAsync($"addProdutosSimilares('{htmlContent}', false);");
                await ScrollToBottomAsync();

            }
            else if (res.type == "end")
            {
                // Converte o Markdown para HTML e escapa caracteres problemáticos
                var htmlContent = Markdown.ToHtml(builder, new MarkdownPipelineBuilder().UseAdvancedExtensions().Build())
                    .Replace("'", "\\'").Replace("\n", "\\n").Replace("\r", "");
                // Finaliza a mensagem atual
                await webView.CoreWebView2.ExecuteScriptAsync($"addProdutosSimilares('{htmlContent}', true);");
                await ScrollToBottomAsync();

                builder = "";
            }
        }

        private void FinalizaStatus()
        {
            label1.Text = "Sugestões Carregadas";
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.Value = 100;
        }

        private async void PreencherWebViewComTexto(string jsonResponse)
        {
            var res = JsonSerializer.Deserialize<ResJsonBody>(jsonResponse);
            string texto = res?.content;

            if (string.IsNullOrWhiteSpace(texto) || res?.type != "data")
            {
                return;
            }

            // Divide o texto em linhas
            string[] linhas = texto.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            // Remove números iniciais e formata cada linha
            var cards = linhas.Select(linha =>
            {
                // Remove prefixos numéricos, como "1.", "2.", etc.
                string textoLimpo = System.Text.RegularExpressions.Regex.Replace(linha, @"^\d+\.\s*", "");

                return new
                {
                    text = Markdown.ToHtml(textoLimpo, new MarkdownPipelineBuilder().UseAdvancedExtensions().Build())
                    .Replace("'", "\\'").Replace("\n", "").Replace("<p>","")
                    .Replace("\r", "").Replace("</p>",""), // Codifica o texto para HTML
                    action = System.Web.HttpUtility.JavaScriptStringEncode(textoLimpo) // Codifica o texto para JavaScript
                };
            });

            // Converte os cards para JSON
            string cardsJson = JsonSerializer.Serialize(cards);

            // Gera o script para invocar a função JavaScript
            string script = $@"
            (function() {{
                if (typeof addCards !== 'function') {{
                    console.error('Função addCards não encontrada no contexto do WebView2.');
                    return;
                }}
                addCards({cardsJson});
            }})();";

            // Executa o script no WebView2
            await webView.CoreWebView2.ExecuteScriptAsync(script);
            // Register for messages from JavaScript
            webView.CoreWebView2.WebMessageReceived += CoreWebView2_WebMessageReceived;
            
        }

        private void CoreWebView2_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs args)
        {
            string receivedText = args.WebMessageAsJson;

            // Exibe uma caixa de diálogo para confirmar a alteração
            var result = MessageBox.Show(
                $"Você deseja confirmar a alteração para:\n\n\"{receivedText}\"?",
                "Confirmação de Alteração",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Processa a alteração se confirmado
                Selecionar(receivedText);
            }
        }
        private void ChatClient_Status(string response)
        {
            if (InvokeRequired)
            {
               
                Invoke(new Action(() => SetarStatus(response)));
                Invoke(new Action(() => CarregarSugestoes()));
                SetaStatusBusca();
            }
            else
            {
                SetarStatus(response);
                CarregarSugestoes();
                SetaStatusBusca();
            }
        }

        private void SetaStatusBusca()
        {
            label1.Text = "Gerando Sugestões";
            progressBar1.Style = ProgressBarStyle.Marquee; // Indicador de progresso indefinido
        }

        private void FrmConfiguracoes_FormClosing(object? sender, FormClosingEventArgs e)
        {
            var chatData = new ChatData();
            chatData.Command = "sair";
            _=chatClient.SendMessage(chatData);
        }
        private async void CarregarSugestoes()
        {
            if (IsProdutoSimilar)
            {
                chatData.Command = "carregar_produtos_similares";
            }
            else
            {
                chatData.Command = "carregar_sugestao";
                chatData.OpcaoModelo = ConfigModelo.Modelo.IdentificacaoModelo;
                chatData.Modelo = ConfigModelo.Modelo.NomeModelo;
                chatData.Path = path;
            }
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
                label1.Text = "";

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
            SetaStatusBusca();
        }
    }
}
