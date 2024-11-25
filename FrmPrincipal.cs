using AIBAM.Classes;
using AIBAM.Forms;
using AIBAM.Templates;

using Newtonsoft.Json;

using System.Runtime.InteropServices;
using System.Text;

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

        internal Utils utils;
        // Configurar o cliente de chat
        readonly ChatClient chatClient = new ChatClient("localhost", 8080);

        PromptCopy promptCopy;

        private string textoPromptCopy = "";

        public FrmPrincipal()
        {
            InitializeComponent();
            utils = new(SetStatus);
            promptCopy = new();
            this.FormClosing += FrmConfiguracoes_FormClosing;
        }
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            AtualizaBarraProgresso();
            SetStatus("Carregando ferramentas...");
            publicoAlvoControl1.utils = utils;
            briefingCopyControl1.utils = utils;
            chatClient.OnConect += ChatClient_Status;
            chatClient.OnMessageReceived += ChatClient_OnMessageReceived;
            Task.Run(() => chatClient.Connect());
            SetStatus("Preparando UI...");
            txtPrompt.Focus();
            AtualizaBarraProgresso();
            SetStatus("Pronto!");
            SelecionaTipoChat(Settings.Default.TipoChat);
        }

        private void FrmConfiguracoes_FormClosing(object? sender, FormClosingEventArgs e)
        {
#pragma warning disable CS4014 // Como esta chamada não é esperada, a execução do método atual continua antes de a chamada ser concluída
            chatClient.SendMessage("sair  ");
#pragma warning restore CS4014 // Como esta chamada não é esperada, a execução do método atual continua antes de a chamada ser concluída
        }

        private void ChatClient_Status(string obj)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => SetStatus(obj)));
            }
            else
            {
                SetStatus(obj);
            }
        }

        // Manipulador do evento
        private void ChatClient_OnMessageReceived(string response)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => chatControl1.AddBotResponse(response)));
                Invoke(new Action(() => webControl1.AddBotResponse(response)));
            }
            else
            {
                chatControl1.AddBotResponse(response);
                webControl1.AddBotResponse(response);
            }
        }

        private void RequestToChat()
        {
            SetStatus("Enviando solicitação...");
            AtualizaCursor(true);
            AtualizaBarraProgresso();


            // Exibe o prompt (mensagem do usuário) no ChatControl
            chatControl1.AddUserMessage(txtPrompt.Text);
            webControl1.AddUserMessage(txtPrompt.Text);

            string _ = "chat " + txtPrompt.Text;
            // Envia a mensagem para o servidor via socket
#pragma warning disable CS4014 // Como esta chamada não é esperada, a execução do método atual continua antes de a chamada ser concluída
            chatClient.SendMessage(_);
#pragma warning restore CS4014 // Como esta chamada não é esperada, a execução do método atual continua antes de a chamada ser concluída

            AtualizaBarraProgresso();
            AtualizaCursor(false);

            // Limpa o campo de entrada após o envio
            txtPrompt.Clear();
            txtPrompt.Focus();
            SetStatus("Pronto!");

        }

        private void AtualizaBarraProgresso()
        {
            toolStripProgressBar1.Visible = !toolStripProgressBar1.Visible;
            toolStripProgressBar1.Style = toolStripProgressBar1.Style == ProgressBarStyle.Marquee ? ProgressBarStyle.Blocks : ProgressBarStyle.Marquee;
        }
        // Atualiza o cursor entre o cursor de espera e o cursor padrão
        private void AtualizaCursor(bool esperando)
        {
            Cursor = esperando ? Cursors.WaitCursor : Cursors.Default;
        }

        // Salva a conversação em um arquivo Markdown
        private void SaveConversation()
        {
            // Define o status antes de iniciar o salvamento
            SetStatus("Salvando a conversação...");
            AtualizaBarraProgresso();

            saveFileDialog1.Filter = "Markdown files (*.md)|*.md|Text files (*.txt)|*.txt";
            saveFileDialog1.Title = "Salvar Conversação";
            saveFileDialog1.DefaultExt = "md";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.InitialDirectory = Path.Combine(Settings.Default.DiretorioRaiz, "CONVERSAS");
            saveFileDialog1.FileName = "CONVERSA_LIVRE";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;

                try
                {
                    string conversationText = chatControl1.rTxtChat.Text;
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

            AtualizaBarraProgresso();
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

        // Detecta Enter ou Ctrl+Enter no campo de texto
        private void txtPrompt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Enter)
            {
                // Adiciona uma quebra de linha no texto sem enviar a mensagem
                int selectionStart = txtPrompt.SelectionStart;
                txtPrompt.Text = txtPrompt.Text.Insert(selectionStart, Environment.NewLine);
                txtPrompt.SelectionStart = selectionStart + Environment.NewLine.Length;
                e.SuppressKeyPress = true; // Evita o comportamento padrão do Enter
            }
            else if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita o comportamento padrão do Enter
                RequestToChat(); // Envia a mensagem
            }
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

        private void SelecionaTipoChat(string ChatParametrizado)
        {
            AtualizaBarraProgresso();
            if (ChatParametrizado == "true")
            {
                toolChatParametrizado.CheckState = CheckState.Checked;
                toolChatLivre.Checked = !toolChatParametrizado.Checked;
                splitContainer2.Panel1Collapsed = !toolChatParametrizado.Checked;
                splitContainer2.Panel2Collapsed = !toolChatLivre.Checked;
                toolChatLivre.CheckState = CheckState.Unchecked;
                toolChatParametrizado.CheckState = CheckState.Checked;
                SetStatus("Chat Parametrizado pronto!");
            }
            else
            {
                toolChatLivre.CheckState = CheckState.Checked;
                toolChatParametrizado.Checked = !toolChatLivre.Checked;
                splitContainer2.Panel1Collapsed = !toolChatParametrizado.Checked;
                splitContainer2.Panel2Collapsed = !toolChatLivre.Checked;
                toolChatParametrizado.CheckState = CheckState.Unchecked;
                toolChatLivre.CheckState = CheckState.Checked;
                SetStatus("Chat Livre pronto!");
            }
            AtualizaBarraProgresso();
        }
        private void toolChatLivre_Click(object sender, EventArgs e)
        {
            SelecionaTipoChat("false");
            Settings.Default.TipoChat = "false";
        }
        private void toolChatParametrizado_Click(object sender, EventArgs e)
        {
            SelecionaTipoChat("true");
            Settings.Default.TipoChat = "true";
        }

        private void nEntonacao_Enter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(nEntonacao, " 1-Pouco Informal e 10-Muito Formal");
        }
        private void nOriginalidade_Enter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(nOriginalidade, " 1-Pouco Original e 10-Muito Original");
        }

        #region CONFIGURA PROMPT DE COPY
        private void ParsePromptCopy()
        {
            promptCopy.DescricaoCopy = txtNomePromptCopy.Text;
            //ATRIBUI BRIEFING COPY
            promptCopy.briefing = briefingCopyControl1.RetornaBriefing();
            //ATRIBUI PUBLICO ALVO DE CONTROLE PUBLICO ALVO
            promptCopy.publicoAlvo = publicoAlvoControl1.RetonaPublicoAlvo();

            //ATRIBUI CONTROLES DE CRIAÇÃO COPY
            promptCopy.controlesCopy.Entonacao = (int)nEntonacao.Value;
            promptCopy.controlesCopy.Originalidade = (int)nOriginalidade.Value;
            promptCopy.controlesCopy.Sentimento = utils.ObterItensSelecionado(ckSentimentos);
            promptCopy.controlesCopy.Perspectiva = utils.ObterTextoGroupBox(gbPerspectiva);
            promptCopy.controlesCopy.PalavrasChave = lstPalavrasChave.GetItensSelecionados();
        }
        #endregion


        #region AÇÕES PROMPT COPY
        private void salvarToolStripButton1_Click(object sender, EventArgs e)
        {
            AtualizaBarraProgresso();
            ParsePromptCopy();
            SetStatus("Iniciando processo salvar");
            PromptCopyTemplate prompt = new(promptCopy);
            ///salva aquivo em formato de texto concatenado
            textoPromptCopy = prompt.MontaPrompt();
            saveFileDialog1 = new();
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt";
            saveFileDialog1.Title = "Salvar Modelo Prompt";
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.FileName = txtNomePromptCopy.Text;
            saveFileDialog1.AddExtension = true;
            string diretorio = Path.Combine(Settings.Default.DiretorioRaiz, "PROMPTS");
            saveFileDialog1.InitialDirectory = diretorio;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;
                utils.SaveToJson(promptCopy, txtNomePromptCopy.Text);
                try
                {
                    File.WriteAllText(filePath, textoPromptCopy);
                    SetStatus("Modelo Prompt salva com sucesso!");
                }
                catch (Exception ex)
                {
                    SetStatus("Erro ao salvar a Modelo Prompt.");
                }
            }
            else
            {
                SetStatus("Operação de salvamento cancelada.");
            }

            AtualizaBarraProgresso();
        }
        private void abrirToolStripButton1_Click(object sender, EventArgs e)
        {

            // Configurações do diálogo de abertura de arquivo
            openFileDialog1.Filter = "JSON files (*.json)|*.json";
            openFileDialog1.Title = "Abrir Modelo Prompt";
            saveFileDialog1.AddExtension = false;
            openFileDialog1.InitialDirectory = Path.Combine(Settings.Default.DiretorioRaiz, "DATASETS");
            // Exibe o diálogo e verifica se o usuário selecionou um arquivo
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;

                try
                {
                    // Lê o conteúdo do arquivo JSON selecionado
                    string json = File.ReadAllText(filePath);
                    promptCopy = new();
                    LimparConteudoPromptCopy();
                    // Deserializa o conteúdo JSON para o objeto promptCopy
                    promptCopy = JsonConvert.DeserializeObject<PromptCopy>(json);
                    // Atualiza os campos da interface com os dados do promptCopy
                    txtNomePromptCopy.Text = promptCopy.DescricaoCopy;
                    //ATRIBUI PUBLICO ALVO NO CONTROLE 
                    publicoAlvoControl1.AtribuirPublicoAlvo(promptCopy.publicoAlvo);
                    // Atualiza os controles de criação
                    utils.SetSelectedValue(ckSentimentos, promptCopy.controlesCopy.Sentimento);
                    nEntonacao.Value = promptCopy.controlesCopy.Entonacao;
                    nOriginalidade.Value = promptCopy.controlesCopy.Originalidade;
                    utils.SetSelectedValue(gbPerspectiva, promptCopy.controlesCopy.Perspectiva);
                    lstPalavrasChave.SetItensSelecionados(promptCopy.controlesCopy.PalavrasChave);

                    //ATRIBUIR BRIEFING
                    briefingCopyControl1.AtribuirBriefing(promptCopy.briefing);

                    // Atualiza o status de sucesso
                    SetStatus($"Modelo Prompt carregado de: {filePath}");
                }
                catch (Exception ex)
                {
                    // Mostra mensagem de erro se algo falhar
                    MessageBox.Show($"Erro ao abrir o Modelo Prompt: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Atualiza o status em caso de erro
                    SetStatus("Erro ao abrir o Modelo Prompt.");
                }
            }
            else
            {
                // Atualiza o status se o usuário cancelar a operação de abertura
                SetStatus("Operação de abertura cancelada.");
            }
        }

        private void novaToolStripButton1_Click(object sender, EventArgs e)
        {
            LimparConteudoPromptCopy();
        }

        private void LimparConteudoPromptCopy()
        {
            // Limpa o conteúdo dos controles onde o prompt é exibido
            txtNomePromptCopy.Clear();

            //LIMPAR CAMPOS BRIEFING 
            briefingCopyControl1.LimparCampos();
            //LIMPA CAMPOS DE PUBLICO ALVO
            publicoAlvoControl1.LimparCampos();

            // Limpa os controles de criação
            nEntonacao.Value = nEntonacao.Minimum; // ou 0, dependendo do seu controle
            nOriginalidade.Value = nOriginalidade.Minimum; // ou 0, dependendo do seu controle
            utils.SetSelectedValue(gbPerspectiva, string.Empty); // Limpa a perspectiva
            lstPalavrasChave.LimparLista();
            utils.SetSelectedValue(ckSentimentos, new List<string>());

            // Cria um novo objeto promptCopy vazio
            promptCopy = new PromptCopy(); // Supondo que PromptCopy é a classe que você está usando

            // Atualiza o status indicando que um novo prompt está pronto para ser criado
            SetStatus("Novo Modelo Prompt iniciado.");
        }


        #endregion

        private void opçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConfiguracoes frm = new FrmConfiguracoes();
            DialogResult result = frm.ShowDialog();
            if (result == DialogResult.OK) { }
            else if (result == DialogResult.Cancel) { }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SetStatus("Configurando prompt");
            ParsePromptCopy();
            PromptCopyTemplate prompt = new(promptCopy);
            ///salva aquivo em formato de texto concatenado
            textoPromptCopy = prompt.MontaPrompt();
            SetStatus("Promtpt pronto!");
            SelecionaTipoChat("False");
            txtPrompt.Text = textoPromptCopy;
            RequestToChat();

        }

        private void toolViewMarkdown_Click(object sender, EventArgs e)
        {
            Settings.Default.TipoChat = "MD";
            webControl1.Visible = true;
            toolViewMarkdown.Checked = true;
            toolViewMarkdown.CheckState = CheckState.Checked;
            toolViewTexto.Checked = false;
            toolViewTexto.CheckState = CheckState.Unchecked;
        }

        private void toolViewTexto_Click(object sender, EventArgs e)
        {
            Settings.Default.TipoChat = "TXT";
            webControl1.Visible = false;
            toolViewMarkdown.Checked = false;
            toolViewMarkdown.CheckState = CheckState.Unchecked;
            toolViewTexto.Checked = true;
            toolViewTexto.CheckState = CheckState.Checked;
        }

        private void novaToolStripButton_Click(object sender, EventArgs e)
        {
            //FrmPrincipal frm = new();
            //frm.Show();
        }

        private void catalogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCatalogoProdServ frm = new();
            frm.OnStatusUpdate += SetStatus;
            frm.Show();
        }

        private void abrirToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void publicoAlvoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPublicoAlvo frm = new();
            frm.Show();
        }

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProduto frm = new();
            frm.Show();
        }
    }
}