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
            rTxtChat.AppendText("**Você :**" + Environment.NewLine);
            rTxtChat.SelectionFont = new System.Drawing.Font(rTxtChat.Font, System.Drawing.FontStyle.Italic);
            rTxtChat.AppendText(userMessage + Environment.NewLine);
            rTxtChat.SelectionFont = new System.Drawing.Font(rTxtChat.Font, System.Drawing.FontStyle.Bold);
            rTxtChat.AppendText("**AIBAM :**" + Environment.NewLine);
            ScrollTexto();
        }
        public string RetornaTexto()
        {
            return rTxtChat.Text;
        }

        // Método para exibir a resposta (mensagem do bot)
        public void AddBotResponse(string botResponse)
        {
            rTxtChat.SelectionFont = new System.Drawing.Font(rTxtChat.Font, System.Drawing.FontStyle.Regular);
            
            rTxtChat.AppendText(botResponse); // Adiciona sem quebra de linha extra
            ScrollTexto();
        }
        public void AddSugestResponse(string botResponse)
        {
           
            rTxtChat.SelectionFont = new System.Drawing.Font(rTxtChat.Font, System.Drawing.FontStyle.Regular);

            rTxtChat.AppendText(botResponse); // Adiciona sem quebra de linha extra
            ScrollTexto();
        }
    }
}
