using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIBAM
{
    public partial class FrmPrincipal : Form
    {
        // Caminho para o ambiente virtual Python e o script
        string pythonExePath = System.IO.Path.Combine(@"A:\DESKTOP\mars\venv", "Scripts", "python.exe");
        private string scriptPath = @"A:\DESKTOP\mars\gemini.py";
        Process process = new Process();

        public FrmPrincipal()
        {
            InitializeComponent();
            lstPrompts.AutoScroll = true; // Ativa a rolagem automática
        }

        private async Task ExecutePythonChat()
        {
            toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
            // Configuração do processo Python
            process.StartInfo.FileName = pythonExePath;
            process.StartInfo.Arguments = $"\"{scriptPath}\" \"{txtPrompt.Text}\"";
            process.StartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(scriptPath);
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            // Inicia o processo
            process.Start();

            // Exibe a mensagem do usuário no RichTextBox
            AppendMessageToRichTextBox(txtPrompt.Text, true);

            // Processamento da saída em streaming
            while (!process.StandardOutput.EndOfStream)
            {
                string fragment = await process.StandardOutput.ReadLineAsync();
                if (!string.IsNullOrWhiteSpace(fragment))
                {
                    // Adiciona fragmentos da resposta do bot conforme são recebidos
                    AppendMessageToRichTextBox(fragment.Trim(), false);
                    first = false;
                }
            }

            // Captura e exibe erros, se houver
            string errorOutput = await process.StandardError.ReadToEndAsync();
            if (!string.IsNullOrEmpty(errorOutput))
            {
                MessageBox.Show($"Erro no script Python: {errorOutput}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            toolStripProgressBar1.Style = ProgressBarStyle.Blocks; // Volta para o estilo padrão quando desativada
            first = true;
            //AppendFormattedText();
            txtPrompt.Clear();
            txtPrompt.Focus(); // Foca no campo de entrada
        }
        private bool first = true;
        // Adiciona mensagens ao RichTextBox
        private void AppendMessageToRichTextBox(string message, bool isUser)
        {
            if (first)
            {
                string prefix = isUser ? "** Você: " : "** AIBAM: ";
                rTxtResponse.AppendText(Environment.NewLine + prefix + message);
            }
            else
            {
                rTxtResponse.AppendText(message);
            }
            // Rolagem automática até o final do RichTextBox
            rTxtResponse.SelectionStart = rTxtResponse.Text.Length;
            rTxtResponse.ScrollToCaret();
        }

        // Detecta Enter para enviar o prompt
        private void txtPrompt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AtualizaCursor(true);
                e.SuppressKeyPress = true;
                ExecutePythonChat();
                AtualizaCursor(false);
            }
        }

        // Função para salvar a conversa
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            SaveConversationAsMarkdown();
        }


        // Atualiza o cursor entre o cursor de espera e o cursor padrão
        private void AtualizaCursor(bool esperando)
        {
            if (esperando)
            {
                Cursor = Cursors.WaitCursor; // Define o cursor como cursor de espera (relógio de areia)
            }
            else
            {
                Cursor = Cursors.Default; // Volta para o cursor padrão
            }
        }


        // Salva a conversação em um arquivo Markdown
        private void SaveConversationAsMarkdown()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Markdown files (*.md)|*.md|Text files (*.txt)|*.txt";
                saveFileDialog.Title = "Salvar Conversação";
                saveFileDialog.DefaultExt = "md";
                saveFileDialog.AddExtension = true;

                // Exibir o diálogo de salvamento
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    try
                    {
                        // Capturar o texto do RichTextBox
                        string conversationText = rTxtResponse.Text;

                        // Salvar a conversa no arquivo selecionado
                        File.WriteAllText(filePath, conversationText);

                        // Mensagem de sucesso
                        MessageBox.Show($"Conversação salva em: {filePath}", "Salvo com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // Mensagem de erro
                        MessageBox.Show($"Erro ao salvar a conversação: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            // Limpar o campo de entrada e focar nele
            txtPrompt.Clear();
            txtPrompt.Focus();
        }

        // Método para adicionar texto formatado ao RichTextBox
        private void AppendFormattedText()
        {
            string inputText = rTxtResponse.Text;
            // Limpa o RichTextBox para nova formatação
            rTxtResponse.Clear();

            // Remove caracteres indesejados
            inputText = inputText.Replace("[", "").Replace("]", "").Replace("'", "");

            // Fragmenta o texto em partes, usando "\n" como indicador de nova linha
            string[] lines = inputText.Split(new[] { "\n" }, StringSplitOptions.None);

            foreach (string line in lines)
            {
                // Trim para remover espaços em branco no início e no fim
                string trimmedLine = line.Trim();

                // Verifica se a linha é um título
                if (trimmedLine.StartsWith("####"))
                {
                    rTxtResponse.SelectionFont = new Font(rTxtResponse.Font.FontFamily, 14, FontStyle.Bold); // Título
                    rTxtResponse.AppendText(trimmedLine.Substring(4) + Environment.NewLine); // Adiciona texto do título
                }
                else if (trimmedLine.StartsWith("* ") || trimmedLine.StartsWith("** "))
                {
                    rTxtResponse.SelectionFont = new Font(rTxtResponse.Font.FontFamily, rTxtResponse.Font.Size, FontStyle.Bold); // Subtítulo
                    rTxtResponse.AppendText(trimmedLine.Substring(trimmedLine.StartsWith("** ") ? 3 : 2) + Environment.NewLine); // Adiciona texto do subtítulo
                }
                else
                {
                    // Define o texto como normal
                    rTxtResponse.SelectionFont = new Font(rTxtResponse.Font.FontFamily, rTxtResponse.Font.Size, FontStyle.Regular);
                    rTxtResponse.AppendText(trimmedLine + Environment.NewLine); // Adiciona texto normal
                }
            }

            // Desabilita a rolagem automática para o topo
            rTxtResponse.ScrollToCaret();
        }
    }
}
