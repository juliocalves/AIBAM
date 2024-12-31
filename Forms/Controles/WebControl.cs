using Markdig;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIBAM
{
    public partial class WebControl : UserControl
    {

        //StringBuilder html;
        private string html = "";
        private string htmlContent = ""; // Acumula o conteúdo HTML completo
        StringBuilder _botRes;
        Guid currentId;
        private bool isFirst = true;
        public WebControl()
        {
            InitializeComponent();
            // Inicializa o WebView2
            ConfigureWebView();
        }
        private async void ConfigureWebView()
        {
            // Inicializa o WebView2
            await webView.EnsureCoreWebView2Async();
        }
      
        public void SetaTexto(string texto)
        {
            // Separar e formatar mensagens
            string formattedHtml = ProcessMessages(texto);
            var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
            htmlContent = Markdown.ToHtml(formattedHtml, pipeline);
            // Envolver conteúdo HTML em estrutura básica
            var markdownHtml = WrapHtmlContent(htmlContent);

            

            // Renderizar o conteúdo formatado no WebView
            webView.NavigateToString(markdownHtml);
            // Garantir que a página role automaticamente para a última mensagem
            //string scrollScript = "window.scrollTo(0, document.body.scrollHeight);";
            //webView.ExecuteScriptAsync(scrollScript);
        }

        private string ProcessMessages(string texto)
        {
            StringBuilder htmlBuilder = new StringBuilder();

            // Separar mensagens por delimitadores
            string[] lines = texto.Split(new[] { "**Você :**", "**AIBAM :**" }, StringSplitOptions.None);

            // Alternar entre classes de usuário e bot
            bool isUser = true; // Assume que o texto começa com uma mensagem de usuário

            foreach (string line in lines)
            {
                string trimmedLine = line.Trim();
                if (string.IsNullOrWhiteSpace(trimmedLine))
                    continue;

                // Determinar a classe CSS com base no remetente
                string cssClass = isUser ? "user-message" : "bot-message";
                string identifica = isUser ? "**Você:** " : "**AIBAM:** ";
                // Construir o elemento HTML
                htmlBuilder.AppendLine($"<div class='{cssClass}'>" +
                       
                    $"{trimmedLine}</div>");

                // Alternar remetente
                isUser = !isUser;
            }

            return htmlBuilder.ToString();
        }


        // Envolve o conteúdo HTML em uma estrutura básica
        private string WrapHtmlContent(string htmlContent)
        {
            return $@"
                  <html>
                    <head>
                        <meta charset=""UTF-8"">
                        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                        <title>Chat Style</title>
                        <link href=""https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css"" rel=""stylesheet"">
                        <style>
                            body {{
                                font-family: 'Roboto', sans-serif;
                                background-color: #f9f9f9;
                                padding: 20px;
                                color: #333;
                            }}
                            .chat-container {{
                                max-width: 800px;
                                margin: 0 auto;
                            }}
                            .user-message {{
                                text-align: left;
                                color: #007bff;
                                margin: 1em 0;
                                padding: 0.75em 1em;
                                background-color: #e9f7ff;
                                border-radius: 8px;
                                box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
                            }}
                            .bot-message {{
                                text-align: left;
                                color: #333;
                                margin: 1em 0;
                                padding: 0.75em 1em;
                                background-color: #fff;
                                border-radius: 8px;
                                box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
                            }}
                            .chat-header {{
                                text-align: center;
                                margin-bottom: 2em;
                                font-weight: bold;
                                color: #555;
                            }}
                            code {{
                                background-color: #f4f4f4;
                                padding: 0.2em 0.4em;
                                border-radius: 3px;
                                font-family: 'Courier New', monospace;
                            }}
                            ul, ol {{
                                padding-left: 1.5em;
                            }}
                            li {{
                                margin-bottom: 0.5em;
                            }}
                        </style>
                    </head>
                    <body>{htmlContent}</body>
                </html>";
        }
    }
}
