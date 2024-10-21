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
        }

        private async Task ExecutePythonChat()
        {
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

            // Exibe o prompt (mensagem do usuário) no ChatControl
            chatControl.AddUserMessage(txtPrompt.Text);

            // Processamento da saída em streaming
            await ReadOutputAsync();

            // Captura e exibe erros, se houver
            string errorOutput = await process.StandardError.ReadToEndAsync();
            if (!string.IsNullOrEmpty(errorOutput))
            {
                MessageBox.Show($"Erro no script Python: {errorOutput}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtPrompt.Clear();
            txtPrompt.Focus(); // Foca no campo de entrada
        }

        // Método separado para ler a saída do processo
        private async Task ReadOutputAsync()
        {
            bool first = true;

            while (!process.StandardOutput.EndOfStream)
            {
                string fragment = await process.StandardOutput.ReadLineAsync();
                if (!string.IsNullOrWhiteSpace(fragment))
                {
                    // Adiciona fragmentos da resposta do bot conforme são recebidos
                    chatControl.AddBotResponse(fragment, first);
                    first = false;
                }
            }
        }

        // Detecta Enter para enviar o prompt
        private async void txtPrompt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AtualizaCursor(true);
                e.SuppressKeyPress = true;
                toolStripProgressBar1.Visible = true;
                toolStripProgressBar1.Style = ProgressBarStyle.Marquee;

                // Execute the Python chat asynchronously
                await ExecutePythonChat();

                toolStripProgressBar1.Visible = false;
                AtualizaCursor(false);
            }
        }


        // Função para salvar a conversa
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            SaveConversation();
        }

        // Atualiza o cursor entre o cursor de espera e o cursor padrão
        private void AtualizaCursor(bool esperando)
        {
            Cursor = esperando ? Cursors.WaitCursor : Cursors.Default;
        }

        // Salva a conversação em um arquivo Markdown
        private void SaveConversation()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Markdown files (*.md)|*.md|Text files (*.txt)|*.txt";
                saveFileDialog.Title = "Salvar Conversação";
                saveFileDialog.DefaultExt = "md";
                saveFileDialog.AddExtension = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    try
                    {
                        string conversationText = chatControl.rTxtChat.Text;
                        File.WriteAllText(filePath, conversationText);
                        MessageBox.Show($"Conversação salva em: {filePath}", "Salvo com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao salvar a conversação: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            txtPrompt.Clear();
            txtPrompt.Focus();
        }
    }
}
