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
        private string html = ""; // Acumula o conteúdo HTML completo
        private bool botPrefixAdded = false; // Controla a adição do prefixo para o bot
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
        // Método para exibir a mensagem do usuário em Markdown com prefixo e alinhamento à direita
        public void AddUserMessage(string userMessage)
        {
            string markdownHtml = "";
            if (botPrefixAdded)
            {
                botPrefixAdded = false;
                markdownHtml = ConvertMarkdownToHtml("</div>", "bot-message", true);
                markdownHtml = "";
                isFirst = true;
            }
            string prefixedMessage = $"**Você:** {userMessage}";
            markdownHtml = ConvertMarkdownToHtml(prefixedMessage, "user-message");
            // Após navegar, injetar JavaScript para rolar a página
            string scrollScript = "window.scrollTo(0, document.body.scrollHeight);";
            webView.ExecuteScriptAsync(scrollScript);
            webView.NavigateToString(markdownHtml);
        }

        // Método para exibir a resposta do bot em Markdown com alinhamento padrão (à esquerda)
        public void AddBotResponse(string botResponse)
        {
            string prefixMessage = "";
            string markdownHtml = "";
            if (!botPrefixAdded)
            {
                prefixMessage = $"**AIBAM:** {botResponse}";
                botPrefixAdded = true;
                markdownHtml = ConvertMarkdownToHtml(prefixMessage, "bot-message", true);
            }
            else
            {
                markdownHtml = ConvertMarkdownToHtml(botResponse, "bot-message", true);
            }

            // Após navegar, injetar JavaScript para rolar a página
            string scrollScript = "window.scrollTo(0, document.body.scrollHeight);";
            webView.ExecuteScriptAsync(scrollScript);
            webView.NavigateToString(markdownHtml);
        }

        // Converte Markdown em HTML
        private string ConvertMarkdownToHtml(string markdown, string cssClass, bool bot = false)
        {
            var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
            string htmlContent = Markdown.ToHtml(markdown, pipeline);
            if (!bot)
            {
                html += $"<div class='{cssClass}'>{htmlContent}</div>"; // Adiciona a classe CSS especificada
            }
            else if (botPrefixAdded && isFirst)
            {
                html += $"<div class='{cssClass}'>{htmlContent}"; // Adiciona a classe CSS especificada
                isFirst = false;
            }
            else
            {
                html += htmlContent;
            }
            // Remove quebras de linha extras que o WebView2 adiciona
            htmlContent = htmlContent.Replace("<p>", "").Replace("</p>", "");
            return WrapHtmlContent(html);
        }

        // Envolve o conteúdo HTML em uma estrutura básica
        private string WrapHtmlContent(string htmlContent)
        {
            return $@"
                  <html>
                    <head>
                         <style>
                        body {{
                            font-family: 'Roboto', sans-serif; 
                            padding: 10px; 
                            background-color: #f9f9f9; 
                            color: #333; 
                        }}
                        .user-message {{
                            text-align: left; 
                            color: #007bff; 
                            margin-bottom: 1.5em;
                            margin: 1em 0; 
                            padding: 0.5em 1em; 
                            background-color: #fff; 
                            border-radius: 5px; 
                            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1); 
                        }}
                        .bot-message {{
                            text-align: left; 
                            color: #333; 
                            margin-bottom: 1.5em; 
                            padding: 0.5em 1em; 
                            background-color: #fff; 
                            border-radius: 5px; 
                            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1); 
                        }}
                        h1, h2, h3, h4, h5, h6 {{
                            color: #222; 
                            margin-top: 1em; 
                        }}
                        p {{
                            color: #555; 
                            margin: 1em 0; 
                            padding: 0.5em 1em; 
                        }}
                        ul, ol {{
                            color: #555; 
                            margin: 1em 0; 
                            padding-left: 2em; 
                        }}
                        li {{
                            margin-bottom: 0.5em; 
                        }}
                        code {{
                            background-color: #f4f4f4; 
                            padding: 3px; 
                            border-radius: 3px; 
                            font-family: 'Courier New', monospace; 
                        }}
                    </style>
                    </head>
                    <body>{htmlContent}</body>
                </html>";
        }
    }
}
