using AIBAM.Forms;

using Markdig;

using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.Web.WebView2.Core;

using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.AudioFormat;
namespace AIBAM
{
    public partial class WebControl : UserControl
    {
        private string htmlFilePath = @"A:\DESKTOP\AIBAM\src\html\ChatPage.html"; // Caminho para o arquivo HTML
        public WebControl()
        {
            InitializeComponent();
            InitializeWebViewAsync(); // Inicialização assíncrona
            CarregaHtmlBase();
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

      

        public async Task AddUserInput(string texto)
        {
            // Substitui os caracteres especiais para evitar problemas de parsing
            var safeTexto = texto.Replace("'", "\\'").Replace("\n", "\\n").Replace("\r", "");
            await webView.CoreWebView2.ExecuteScriptAsync($"addUserMessage('{safeTexto}');");
        }
        internal string Voice { get; set; }
        private void SelecionarVoz()
        {
            SelecionarVozForm selecionarVozForm = new SelecionarVozForm();
            if (selecionarVozForm.ShowDialog() == DialogResult.OK)
            {
                // A voz foi selecionada e está armazenada na propriedade Voice
                Voice = selecionarVozForm.Voice;
            }
        }
        public async Task SpeakText(string text)
        {
            // Cria uma instância do sintetizador de fala
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.SelectVoice(Voice);
            synth.SetOutputToDefaultAudioDevice();
            // Reproduz o texto em voz alta
            synth.Speak(text);
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

        public async Task AddBotResponse(string jsonResponse)
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
                await webView.CoreWebView2.ExecuteScriptAsync($"addOrUpdateBotMessage('{htmlContent}', false);");
                await ScrollToBottomAsync();

            }
            else if (res.type == "end")
            {
                // Converte o Markdown para HTML e escapa caracteres problemáticos
                var htmlContent = Markdown.ToHtml(builder, new MarkdownPipelineBuilder().UseAdvancedExtensions().Build())
                    .Replace("'", "\\'").Replace("\n", "\\n").Replace("\r", "");
                // Finaliza a mensagem atual
                await webView.CoreWebView2.ExecuteScriptAsync($"addOrUpdateBotMessage('{htmlContent}', true);");
                await ScrollToBottomAsync();

                builder = "";
            }
        }

    }
}
