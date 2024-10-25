using System;
using System.Windows.Forms;

namespace AIBAM
{
    public partial class ChatControl : UserControl
    {
        public ChatControl()
        {
            InitializeComponent();
        }
        public void ScrollTexto()
        {
            // Rola automaticamente para o fim do conteúdo
            rTxtChat.SelectionStart = rTxtChat.Text.Length;
            rTxtChat.ScrollToCaret();
        }
        // Método para exibir o prompt (mensagem do usuário)
        public void AddUserMessage(string userMessage)
        {
            rTxtChat.SelectionFont = new System.Drawing.Font(rTxtChat.Font, System.Drawing.FontStyle.Bold);
            rTxtChat.AppendText("VOCÊ" + Environment.NewLine);
            rTxtChat.SelectionFont = new System.Drawing.Font(rTxtChat.Font, System.Drawing.FontStyle.Italic);
            rTxtChat.AppendText(userMessage + Environment.NewLine);
            rTxtChat.SelectionFont = new System.Drawing.Font(rTxtChat.Font, System.Drawing.FontStyle.Bold);
            rTxtChat.AppendText("AIBAM" + Environment.NewLine);
            ScrollTexto();
        }


        // Método para exibir a resposta (mensagem do bot)
        public void AddBotResponse(string botResponse)
        {
            rTxtChat.SelectionFont = new System.Drawing.Font(rTxtChat.Font, System.Drawing.FontStyle.Regular);
            //// Verifica se a resposta já contém quebra de linha
            //if (!botResponse.Contains("\n") && !botResponse.Contains("\r\n"))
            //{
            //    rTxtChat.AppendText(botResponse + Environment.NewLine); // Adiciona a quebra de linha
            //}
            //else
            //{
                rTxtChat.AppendText(botResponse); // Adiciona sem quebra de linha extra
            //}
            ScrollTexto();
        }
    }
}
