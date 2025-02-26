using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIBAM.Forms
{
    public partial class FrmWeb : Form
    {
        public string url = "";
        internal Utils utils;
        public FrmWeb()
        {
            InitializeComponent();
            utils = new(SetStatus, AtualizaBarraProgresso);
            //  utils.SetarThema(this, "black");
            CarregarNavegador();
        }
        public FrmWeb(string url)
        {
            InitializeComponent();
            utils = new(SetStatus, AtualizaBarraProgresso);
            // utils.SetarThema(this, "black");
            CarregarNavegador(url);
        }

        private void CarregarNavegador(string url = "https://google.com")
        {
            // Inicializa o WebView2 e aguarda o carregamento completo
            webView.CoreWebView2InitializationCompleted += WebView_CoreWebView2InitializationCompleted;
            // Carregar a URL
            webView.Source = new Uri(url);
        }
        // Evento chamado quando o WebView2 está completamente carregado
        private async void WebView_CoreWebView2InitializationCompleted(object sender, EventArgs e)
        {
            try
            {
                // Aguardar o script de título da página ser executado
                string pageTitle = await webView.CoreWebView2.ExecuteScriptAsync("document.title");

                // Atualizar o título do botão ou outro controle com o título da página
                //tabControl1.cu.Text = pageTitle.Trim('"');  // Remove as aspas

                // Obter o URL atual (de forma assíncrona)
                string currentUrl = webView.Source.AbsoluteUri;

                // Exibir o URL no TextBox ou outro controle
                txtUrl.Text = currentUrl;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao acessar o WebView2: {ex.Message}");
            }
        }

        private void AtualizaBarraProgresso()
        {
            toolStripProgressBar1.Visible = !toolStripProgressBar1.Visible;
            toolStripProgressBar1.Style = toolStripProgressBar1.Style == ProgressBarStyle.Marquee ? ProgressBarStyle.Blocks : ProgressBarStyle.Marquee;
        }
        // Função para definir o status no ToolStripStatusLabel
        public void SetStatus(string message)
        {
            toolStripStatusLabel1.Text = message;
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (webView.CoreWebView2.CanGoBack)
            {
                webView.CoreWebView2.GoBack();
            }
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            if (webView.CoreWebView2.CanGoForward)
            {
                webView.CoreWebView2.GoForward();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            webView.Reload();
        }

        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string input = txtUrl.Text.Trim();

                // Verificar se contém "." e se não é uma palavra isolada
                if (input.Contains(".") && !input.Contains(" "))
                {
                    // Se é um domínio ou URL, adicionar esquema se necessário
                    if (!input.StartsWith("http://") && !input.StartsWith("https://"))
                    {
                        input = "https://" + input;
                    }

                    try
                    {
                        // Navegar para o URL digitado
                        webView.Source = new Uri(input);
                    }
                    catch (UriFormatException)
                    {
                        MessageBox.Show("URL inválida. Por favor, insira um endereço válido.");
                    }
                }
                else
                {
                    // Caso contrário, realizar pesquisa no Google
                    string searchUrl = $"https://www.google.com/search?q={Uri.EscapeDataString(input)}";
                    webView.Source = new Uri(searchUrl);
                }
            }
        }

    }
}
