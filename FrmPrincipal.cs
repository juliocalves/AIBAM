using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace AIBAM
{
    public partial class FrmPrincipal : Form
    {


        #region CONFIGURAÇÃO MIC
        // Importa a função keybd_event da API do Windows
        [DllImport("user32.dll", SetLastError = true)]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        // Definições de códigos de tecla
        private const int KEYEVENTF_KEYDOWN = 0x0000; // Pressionar tecla
        private const int KEYEVENTF_KEYUP = 0x0002;   // Soltar tecla
        private const byte VK_LWIN = 0x5B;            // Tecla Windows (bandeira esquerda)
        private const byte VK_H = 0x48;
        private const byte VK_ESC = 0x1B;            // Tecla Escape (ESC)
        #endregion

        // Caminho para o ambiente virtual Python e o script
        string pythonExePath = System.IO.Path.Combine(@"A:\DESKTOP\mars\venv", "Scripts", "python.exe");
        private string scriptPath = @"A:\DESKTOP\mars\gemini.py";
        Process chatProcess = new Process();

        public FrmPrincipal()
        {
            InitializeComponent();
            SetStatus("Carregando ferramentas...");
            ChatEngine();
            SetStatus("Pronto!");
        }

        // CONFIGURAÇÃO CHATPROCESS
        private void ChatEngine()
        {
            // Configuração do processo Python
            chatProcess.StartInfo.FileName = pythonExePath;
            chatProcess.StartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(scriptPath);
            chatProcess.StartInfo.RedirectStandardOutput = true;
            chatProcess.StartInfo.RedirectStandardError = true;
            chatProcess.StartInfo.UseShellExecute = false;
            chatProcess.StartInfo.CreateNoWindow = true;
        }
        private async Task ExecutePythonChat()
        {
            // Define o status antes de iniciar a execução do script Python
            SetStatus("Executando o chat...");

            // Passa argumento
            chatProcess.StartInfo.Arguments = $"\"{scriptPath}\" \"{txtPrompt.Text}\"";

            // Inicia o processo
            chatProcess.Start();

            // Exibe o prompt (mensagem do usuário) no ChatControl
            chatControl.AddUserMessage(txtPrompt.Text);

            try
            {
                // Processamento da saída em streaming
                await ReadOutputAsync();

                // Captura e exibe erros, se houver
                string errorOutput = await chatProcess.StandardError.ReadToEndAsync();
                if (!string.IsNullOrEmpty(errorOutput))
                {
                    MessageBox.Show($"Erro no script Python: {errorOutput}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SetStatus("Erro durante a execução do chat.");
                }
                else
                {
                    // Atualiza o status após o processamento bem-sucedido
                    SetStatus("Processo concluído com sucesso!");
                }
            }
            catch (Exception ex)
            {
                // Captura exceções que podem ocorrer durante a execução
                MessageBox.Show($"Erro ao executar o chat: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetStatus("Erro ao executar o chat.");
            }
            finally
            {
                txtPrompt.Clear();
                txtPrompt.Focus(); // Foca no campo de entrada
            }
        }


        // Método separado para ler a saída do processo
        private async Task ReadOutputAsync()
        {
            bool first = true;

            while (!chatProcess.StandardOutput.EndOfStream)
            {
                string fragment = await chatProcess.StandardOutput.ReadLineAsync();
                if (!string.IsNullOrWhiteSpace(fragment))
                {
                    // Adiciona fragmentos da resposta do bot conforme são recebidos
                    chatControl.AddBotResponse(fragment, first);
                    first = false;
                }
            }
        }



        // Atualiza o cursor entre o cursor de espera e o cursor padrão
        private void AtualizaCursor(bool esperando)
        {
            Cursor = esperando ? Cursors.WaitCursor : Cursors.Default;
        }

        // Salva a conversação em um arquivo Markdown
        // Salva a conversação em um arquivo Markdown
        private void SaveConversation()
        {
            // Define o status antes de iniciar o salvamento
            SetStatus("Salvando a conversação...");

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

                        // Atualiza o status após o salvamento bem-sucedido
                        SetStatus("Conversação salva com sucesso!");
                    }
                    catch (Exception ex)
                    {
                        // Mostra a mensagem de erro
                        MessageBox.Show($"Erro ao salvar a conversação: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        // Atualiza o status em caso de erro
                        SetStatus("Erro ao salvar a conversação.");
                    }
                }
                else
                {
                    // Atualiza o status se o usuário cancelar a operação de salvamento
                    SetStatus("Operação de salvamento cancelada.");
                }
            }

            // Limpa e foca no txtPrompt
            txtPrompt.Clear();
            txtPrompt.Focus();
        }


        private void salvarToolStripButton_Click(object sender, EventArgs e)
        {
            SaveConversation();
        }

        // Função para definir o status no ToolStripStatusLabel
        public void SetStatus(string message)
        {
            toolStripStatusLabel1.Text = message;
        }
        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveConversation();
        }

        // Detecta Enter para enviar o prompt
        private async void txtPrompt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                RequestToChat();
            }
        }

        private async void RequestToChat()
        {
            SetStatus("Enviando solicitação...");
            AtualizaCursor(true);

            toolStripProgressBar1.Visible = true;
            toolStripProgressBar1.Style = ProgressBarStyle.Marquee;

            // Execute the Python chat asynchronously
            await ExecutePythonChat();

            toolStripProgressBar1.Visible = false;
            AtualizaCursor(false);
        }

        private void btnMic_Click(object sender, EventArgs e)
        {
            // Pressiona a tecla "Windows" (bandeira) + "H"
            keybd_event(VK_LWIN, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);  // Pressiona Windows
            keybd_event(VK_H, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero);     // Pressiona H

            // Solta as teclas
            keybd_event(VK_H, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);       // Solta H
            keybd_event(VK_LWIN, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);    // Solta Windows

            txtPrompt.Focus();

            //// Espera 3 segundos (3000 milissegundos)
            //await Task.Delay(3000);

            //RequestToChat();
            // Simula pressionamento da tecla ESC
            //keybd_event(VK_ESC, 0, KEYEVENTF_KEYDOWN, UIntPtr.Zero); // Pressiona ESC
            //keybd_event(VK_ESC, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);   // Solta ESC
        }

        private void toolMenu_Click(object sender, EventArgs e)
        {
            toolMenu.Checked = !toolMenu.Checked;
            toolMenu.DisplayStyle = toolMenu.Checked ? ToolStripItemDisplayStyle.ImageAndText : ToolStripItemDisplayStyle.Image;
            splitContainer1.SplitterDistance = toolMenu.Checked ? 200 : 25;
        }

        private void toolChatLivre_Click(object sender, EventArgs e)
        {
            toolChatParametrizado.Checked = !toolChatLivre.Checked;
            splitContainer2.Panel1Collapsed = !toolChatParametrizado.Checked;
            splitContainer2.Panel2Collapsed = !toolChatLivre.Checked;
        }

        private void toolChatParametrizado_Click(object sender, EventArgs e)
        {
            toolChatLivre.Checked = !toolChatParametrizado.Checked;
            splitContainer2.Panel1Collapsed = !toolChatLivre.Checked;
            splitContainer2.Panel2Collapsed = !toolChatParametrizado.Checked;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            splitContainer2.Panel1Collapsed = !toolChatParametrizado.Checked;
        }

    }
}