using AIBAM.Classes;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static AIBAM.ChatClient;
using static AIBAM.Classes.Modelo;

namespace AIBAM.Forms
{
    public partial class FrmChat : Form
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
        // Configurar o cliente de chat
        readonly ChatClient chatClient = new ChatClient("localhost", 8080);
        public event Action<string> OnStatusChanged;
        public event Action AtualizaBarraProgresso;
        public Utils utils;
        private string ChatModel;
        private string ChatOpcaoModelo;
        private Modelo modelo = new();
        public string TipoChat = "chat";
        private ModeloManager modeloManager = new ModeloManager();
        public FrmChat(string Modelo = "livre", string OpcaoModelo = "")
        {
            
            InitializeComponent();
            // Após a inicialização, carrega os dados para o ComboBox
            ChatModel = Modelo;
            ChatOpcaoModelo = OpcaoModelo;
            this.FormClosing += FrmConfiguracoes_FormClosing;
            CarregarCarregarModelo();
            _ = CarregarComboBoxAsync();
            if (Modelo != "livre")
            {
                splitContainer5.Panel1Collapsed = !splitContainer5.Panel1Collapsed;
                splitContainer6.Panel1Collapsed = !splitContainer6.Panel1Collapsed;
            }
            else
            {
                modelo = new() { IANome = "default" };
                txtNomeModelo.Text = "rascunho";
                txtIdentificacaoModelo.Text = "modelo livre";
            }
            splitContainer7.Panel2Collapsed = !splitContainer7.Panel2Collapsed;
            splitContainer8.Panel1Collapsed = !splitContainer8.Panel1Collapsed;
           
        }

        private async Task InicializarChat()
        {
            try
            {
                // Carrega os dados necessários para inicializar o chat
                var chatData = CarregarChatData("instanciar_chat");
                await chatClient.SendMessage(chatData);


            }
            catch (Exception ex)
            {
                // Log ou exibição de erro
                MessageBox.Show($"Erro ao inicializar o chat: {ex.Message}");
            }
        }

        private void RequestToChat()
        {
            OnStatusChanged?.Invoke("Enviando solicitação...");
            AtualizaCursor(true);
            AtualizaBarraProgresso();


            // Exibe o prompt (mensagem do usuário) no ChatControl
            chatControl1.AddUserMessage(txtPrompt.Text);
            webControl1.AddUserInput(txtPrompt.Text);
            //webControl1.AddUserMessage(txtPrompt.Text);
            var chatData = CarregarChatData(TipoChat);
            // Envia a mensagem para o servidor via socket
            chatClient.SendMessage(chatData);

            AtualizaBarraProgresso();
            AtualizaCursor(false);

            // Limpa o campo de entrada após o envio
            txtPrompt.Clear();
            txtPrompt.Focus();
            OnStatusChanged?.Invoke("Pronto!");

        }

        private async void FrmChat_Load(object sender, EventArgs e)
        {
            chatClient.OnConect += ChatClient_Status;
            chatClient.OnMessageReceived += ChatClient_OnMessageReceived;

            // Conecta ao servidor e inicializa o chat após a conexão
            await chatClient.Connect(InicializarChat);
            //utils.SetarThema(this, "black");
        }
        private async Task CarregarComboBoxAsync()
        {
            var _chatClient = new ChatClient("localhost", 8080);
            string listaModelos = await _chatClient.CarregarListaAsync();
            AddResponseToComboBox(listaModelos);
        }



        private void AddResponseToComboBox(string response)
        {
            if (!string.IsNullOrWhiteSpace(response))
            {
                // Separa a string em itens usando delimitadores como vírgula ou quebra de linha
                var items = response.Split(new[] { ',', '\n', ';' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in items)
                {
                    // Remove espaços extras antes de adicionar
                    string trimmedItem = item.Trim();

                    // Adiciona ao ComboBox apenas se não estiver vazio e ainda não existir no ComboBox
                    if (!string.IsNullOrWhiteSpace(trimmedItem) && !cboModelName.Items.Contains(trimmedItem))
                    {
                        cboModelName.Items.Add(trimmedItem);
                    }
                }
                var iaNome = modelo?.IANome;

                cboModelName.SelectedItem = iaNome;
            }
        }


        private void ChatClient_Status(string obj)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => OnStatusChanged?.Invoke(obj)));
            }
            else
            {
                OnStatusChanged?.Invoke(obj);
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
                //webControl1.AddBotResponse(response);
                webControl1.AddBotResponse(response);
            }
        }
        private void FrmConfiguracoes_FormClosing(object? sender, FormClosingEventArgs e)
        {
            var chatData = new ChatData();
            chatData.Command = "sair";
            _=chatClient.SendMessage(chatData);
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

        // Detecta Enter ou Ctrl+Enter no campo de texto
        private void txtPrompt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.KeyCode == Keys.Enter)
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


        private ChatData CarregarChatData(string v)
        {
            var chatData = new ChatData();
            chatData.Command = v;
            chatData.Prompt = txtPrompt.Text;
            chatData.Modelo = ChatModel;
            chatData.OpcaoModelo = ChatOpcaoModelo;
            chatData.Path = ImgPath;
            return chatData;
        }

        // Atualiza o cursor entre o cursor de espera e o cursor padrão
        private void AtualizaCursor(bool esperando)
        {
            Cursor = esperando ? Cursors.WaitCursor : Cursors.Default;
        }

        private void salvarToolStripButton_Click(object sender, EventArgs e)
        {
            SaveConversation();
        }
        // Salva a conversação em um arquivo Markdown
        private void SaveConversation()
        {
            // Define o status antes de iniciar o salvamento
            OnStatusChanged?.Invoke("Salvando a conversação...");
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
                    OnStatusChanged?.Invoke("Conversação salva com sucesso!");
                }
                catch (Exception ex)
                {
                    // Mostra a mensagem de erro
                    MessageBox.Show($"Erro ao salvar a conversação: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Atualiza o status em caso de erro
                    OnStatusChanged?.Invoke("Erro ao salvar a conversação.");
                }
            }
            else
            {
                // Atualiza o status se o usuário cancelar a operação de salvamento
                OnStatusChanged?.Invoke("Operação de salvamento cancelada.");
            }

            AtualizaBarraProgresso();
            // Limpa e foca no txtPrompt
            txtPrompt.Clear();
            txtPrompt.Focus();
        }


        private void chatMarkdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.TipoChat = "MD";
            webControl1.Visible = true;
        }

        private void chatTextoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.TipoChat = "TXT";
            webControl1.Visible = false;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            splitContainer5.Panel1Collapsed = !splitContainer5.Panel1Collapsed;
            CarregarUi();
        }

        private void CarregarUi()
        {
            txtTemperatura.Text = modelo.Temperatura?.ToString("N2");
            tbTemperatura.Value = Convert.ToInt32(modelo.Temperatura * 100);
            txtTokens.Text = modelo.LimiteTokens?.ToString();
            tbTokens.Value = Convert.ToInt32(modelo.LimiteTokens);
        }

        private void tbTemperatura_Scroll(object sender, EventArgs e)
        {
            var valor = Convert.ToDouble((tbTemperatura.Value * 0.01));
            txtTemperatura.Text = valor.ToString("N2");
        }

        private void tbTokens_Scroll(object sender, EventArgs e)
        {
            txtTokens.Text = tbTokens.Value.ToString();
        }
        private void tbAssedio_Scroll(object sender, EventArgs e)
        {
            modelo.FiltroAssedio = GetFiltroValue(tbAssedio.Value);
        }

        private void tbDiscurso_Scroll(object sender, EventArgs e)
        {
            modelo.FiltroDiscurso = GetFiltroValue(tbDiscurso.Value);
        }

        private void tbSexual_Scroll(object sender, EventArgs e)
        {
            modelo.FiltroSexualmente = GetFiltroValue(tbSexual.Value);
        }

        private void tbPerigoso_Scroll(object sender, EventArgs e)
        {
            modelo.FiltroPerigoso = GetFiltroValue(tbPerigoso.Value);
        }


        private string GetFiltroValue(int value)
        {
            return value switch
            {
                5 => "Bloquear muitos",
                4 => "Bloquear alguns",
                3 => "Bloquear poucos",
                2 => "Não bloquear nada",
                1 => "N/A",
                _ => "N/A" // Valor padrão caso seja 0 ou inválido
            };
        }


        private void txtTemperatura_KeyPress(object sender, KeyPressEventArgs e)
        {
            utils.ApenasDecimal(sender, e);
        }

        private void txtTemperatura_Leave(object sender, EventArgs e)
        {
            var valor = Convert.ToDouble(txtTemperatura.Text);
            tbTemperatura.Value = Convert.ToInt32(valor * 100);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            splitContainer5.Panel1Collapsed = !splitContainer5.Panel1Collapsed;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            splitContainer6.Panel1Collapsed = !splitContainer6.Panel1Collapsed;
        }

        private void btnAplicarConfiguracao_Click(object sender, EventArgs e)
        {
            ParseGenerationConfig();
            SalvarModelo();
            var chatData = CarregarChatData("alterar_generation_config");
            // Envia a mensagem para o servidor via socket
            chatClient.SendMessage(chatData);
        }
        private void ParseModelo()
        {
            modelo.NomeModelo = FormatarTexto(txtNomeModelo.Text).ToLower();
            modelo.IdentificacaoModelo = FormatarTexto(txtIdentificacaoModelo.Text).ToLower();
            modelo.DescricaoModelo = txtDescricacaoModelo.Text;
            modelo.RegrasModelo = adicionarListaControl1.GetItensSelecionados();
            modelo.IANome = cboModelName.Text;
            modelo.LimiteTokens = Convert.ToInt32(txtTokens.Text);
            modelo.Temperatura = Convert.ToDouble(txtTemperatura.Text);
        }

        private string FormatarTexto(string text)
        {
            var texto_formatado = text.Replace(" ", "_");
            return texto_formatado;

        }
        private void SalvarModelo()
        {
            ParseModelo();
            modeloManager.SalvarModelo(modelo);
        }

        private void ParseGenerationConfig()
        {
            modelo.Temperatura = Convert.ToDouble(txtTemperatura.Text);
            modelo.LimiteTokens = Convert.ToInt32(txtTokens.Text);
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            splitContainer6.Panel1Collapsed = !splitContainer6.Panel1Collapsed;
            CarregarCarregarModelo();
        }
        private void CarregarCarregarModelo()
        {
            if (ChatModel != "livre")
            {
                var modelos = new ModeloManager().CarregarModelos();
                modelo = new();
                modelo = modelos.Where(m => m.NomeModelo == ChatModel && m.IdentificacaoModelo == ChatOpcaoModelo).FirstOrDefault();
                AtribuirModelo();
            }
        }

        private void AtribuirModelo()
        {
            txtNomeModelo.Text = modelo.NomeModelo.ToString().Replace("_", " ").ToUpper();
            txtIdentificacaoModelo.Text = modelo.IdentificacaoModelo.ToString().Replace("_", " ").ToUpper();
            txtDescricacaoModelo.Text = modelo.DescricaoModelo.ToString();
            adicionarListaControl1.LimparLista();
            adicionarListaControl1.SetItensSelecionados(modelo.RegrasModelo);
            cboModelName.Text = modelo.IANome;
            // Atribuir valores aos TrackBars com base nos filtros do modelo
            tbAssedio.Value = GetTrackBarValue(modelo.FiltroAssedio);
            tbDiscurso.Value = GetTrackBarValue(modelo.FiltroDiscurso);
            tbSexual.Value = GetTrackBarValue(modelo.FiltroSexualmente);
            tbPerigoso.Value = GetTrackBarValue(modelo.FiltroPerigoso);

        }
        private int GetTrackBarValue(string? filtro)
        {
            return filtro switch
            {
                "Bloquear muitos" => 5,
                "Bloquear alguns" => 4,
                "Bloquear poucos" => 3,
                "Não bloquear nada" => 2,
                "N/A" => 1,
                _ => 0 // Valor padrão caso o filtro seja inválido ou nulo
            };
        }


        private void label4_Click(object sender, EventArgs e)
        {
            CarregarUi();
        }
        private void btnAplicarInstrucoesModelo_Click(object sender, EventArgs e)
        {
            var chatData = CarregarChatData("atualizar_instrucao");
            chatClient.SendMessage(chatData);
        }
        private string ImgPath = "";
        private void btnCarregarArquivo_Click(object sender, EventArgs e)
        {
            // Verificar e remover imagem existente, se houver
            flowLayoutPanelImagens.Controls.Clear();
            flowLayoutPanelImagens.Dock = DockStyle.Fill;
            ImgPath = "";
            TipoChat = "chat";
            // Abrir diálogo para selecionar a imagem
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Imagens (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Selecione uma imagem";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    ImgPath = filePath;
                    TipoChat = "chat_img";
                    splitContainer8.Panel1Collapsed = !splitContainer8.Panel1Collapsed;
                    // Criar um painel para conter a imagem e o botão de remover
                    Panel panel = new Panel
                    {
                        BorderStyle = BorderStyle.None,
                        Width = 100,
                        Height = 100,
                        Margin = new Padding(5)
                    };

                    // Adicionar PictureBox para exibir a imagem
                    PictureBox pictureBox = new PictureBox
                    {
                        Image = Image.FromFile(filePath),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Dock = DockStyle.Top,
                        Height = 80
                    };

                    // Adicionar botão de remover
                    Button btnRemover = new Button
                    {
                        Text = "Remover",
                        Dock = DockStyle.Bottom,
                        Height = 30
                    };

                    // Evento de clique para remover a imagem
                    btnRemover.Click += (s, ev) =>
                    {
                        this.Controls.Remove(panel);
                        panel.Dispose();
                        splitContainer8.Panel1Collapsed = !splitContainer8.Panel1Collapsed;
                        ImgPath = "";
                        TipoChat = "chat";
                    };
                    // Evento para visualizar imagem em tamanho grande
                    pictureBox.Click += (s, ev) =>
                    {
                        VisualizarImagemGrande(filePath);
                    };

                    // Adicionar componentes ao painel
                    panel.Controls.Add(btnRemover);
                    panel.Controls.Add(pictureBox);

                    // Adicionar o painel ao formulário ou a um container, como FlowLayoutPanel
                    flowLayoutPanelImagens.Controls.Add(panel); // Certifique-se de ter um FlowLayoutPanel chamado "flowLayoutPanelImagens" no form.
                }
            }
        }
        // Método para visualizar a imagem em tamanho grande
        private void VisualizarImagemGrande(string filePath)
        {
            // Criar um novo formulário para exibir a imagem
            Form formVisualizar = new Form
            {
                Text = "Visualizar Imagem",
                Size = new Size(800, 600), // Tamanho inicial
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen
            };

            // Adicionar PictureBox para exibir a imagem no formulário
            PictureBox pictureBoxGrande = new PictureBox
            {
                Image = Image.FromFile(filePath),
                SizeMode = PictureBoxSizeMode.Zoom,
                Dock = DockStyle.Fill // Preencher todo o formulário
            };

            formVisualizar.Controls.Add(pictureBoxGrande);
            formVisualizar.KeyDown += (s, ev) =>
            {
                if (ev.KeyCode == Keys.Escape)
                {
                    formVisualizar.Close();
                }
            };
            formVisualizar.KeyPreview = true;

            // Abrir o formulário como modal
            formVisualizar.ShowDialog();
        }

        private void cboModelName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParseModeloNome();
            var chatData = CarregarChatData("alterar_instancia_modelo");
            if (ChatModel != "livre")
            {
                SalvarModelo();
                // Envia a mensagem para o servidor via socket
                chatClient.SendMessage(chatData);
            }
            else
            {
                // Envia a mensagem para o servidor via socket
                chatClient.SendMessage(chatData, modelo);
            }
        }

        private void ParseModeloNome()
        {
            modelo.IANome = cboModelName.Text;
        }

        private void btnComparar_Click(object sender, EventArgs e)
        {
            splitContainer7.Panel2Collapsed = !splitContainer7.Panel2Collapsed;
            if(modelo.ExemplosEntradaSaida != null)
            {
                adicionarListaControl2.LimparLista();
                adicionarListaControl3.LimparLista();
                AtribuirExemplosEntradaSaida(modelo.ExemplosEntradaSaida);
            }
        }
        public void AtribuirExemplosEntradaSaida(Tuple<List<string>, List<string>> exemplosEntradaSaida)
        {
            // Verifica se a tupla é nula
            if (exemplosEntradaSaida == null)
            {
                throw new ArgumentNullException(nameof(exemplosEntradaSaida), "A tupla de exemplos não pode ser nula.");
            }

            // Obtém os valores da tupla
            List<string> exemplosEntrada = exemplosEntradaSaida.Item1;
            List<string> exemplosSaida = exemplosEntradaSaida.Item2;

            // Verifica se os valores não são nulos
            if (exemplosEntrada == null || exemplosSaida == null)
            {
                throw new ArgumentNullException("Os exemplos de entrada ou saída não podem ser nulos.");
            }

            // Atribui os valores aos controles
            adicionarListaControl2.SetItensSelecionados(exemplosEntrada);
            adicionarListaControl3.SetItensSelecionados(exemplosSaida);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            splitContainer7.Panel2Collapsed = !splitContainer7.Panel2Collapsed;
        }

        private void ajudaToolStripButton1_Click_1(object sender, EventArgs e)
        {
            FrmAjuda frmAjuda = new FrmAjuda();
            frmAjuda.ShowDialog(); // Exibe a janela como um diálogo modal
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            FrmAjudaParametros frmAjudaParametros = new FrmAjudaParametros();
            frmAjudaParametros.ShowDialog(); // Exibe o formulário como diálogo modal
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            FrmAjudaInstrucoes frmAjuda = new FrmAjudaInstrucoes();
            frmAjuda.ShowDialog();
        }

        private void btnLimparDesginShot_Click(object sender, EventArgs e)
        {
            adicionarListaControl2.LimparLista();
            adicionarListaControl3.LimparLista();
        }

        private void btnAplicarDesignShot_Click(object sender, EventArgs e)
        {
            SetarExemplosEntradaSaida(adicionarListaControl2.GetItensSelecionados(), adicionarListaControl3.GetItensSelecionados());
            SalvarModelo();
            var chatData = CarregarChatData("atualizar_instrucao");
            // Envia a mensagem para o servidor via socket
            chatClient.SendMessage(chatData);
        }

        public void SetarExemplosEntradaSaida(List<string> exemplosEntrada, List<string> exemplosSaida)
        {
            // Valida os parâmetros antes de definir a tupla
            if (exemplosEntrada == null || exemplosSaida == null)
            {
                throw new ArgumentNullException("As listas de exemplos não podem ser nulas.");
            }

            modelo.ExemplosEntradaSaida = new Tuple<List<string>, List<string>>(exemplosEntrada, exemplosSaida);
        }
    }
}
