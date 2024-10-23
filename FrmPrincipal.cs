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
            toolChatLivre.CheckState = CheckState.Checked;
            toolChatParametrizado.Checked = !toolChatLivre.Checked;
            splitContainer2.Panel1Collapsed = !toolChatParametrizado.Checked;
            splitContainer2.Panel2Collapsed = !toolChatLivre.Checked;
            toolChatParametrizado.CheckState = CheckState.Unchecked;
            toolChatLivre.CheckState = CheckState.Checked;
        }

        private void toolChatParametrizado_Click(object sender, EventArgs e)
        {
            toolChatParametrizado.CheckState = CheckState.Checked;
            toolChatLivre.Checked = !toolChatParametrizado.Checked;
            splitContainer2.Panel1Collapsed = !toolChatParametrizado.Checked;
            splitContainer2.Panel2Collapsed = !toolChatLivre.Checked;
            toolChatLivre.CheckState = CheckState.Unchecked;
            toolChatParametrizado.CheckState = CheckState.Checked;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            toolChatLivre.Checked = !toolChatParametrizado.Checked;
            splitContainer2.Panel1Collapsed = !toolChatParametrizado.Checked;
        }

        private void cboSegmento_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Limpa os itens do ComboBox de subsegmentos
            cboSubSegmentos.Items.Clear();

            // Obtém o segmento selecionado
            string segmentoSelecionado = cboSegmento.SelectedItem.ToString();

            // Adiciona os subsegmentos de acordo com o segmento selecionado
            switch (segmentoSelecionado)
            {
                case "Tecnologia da Informação (TI)":
                    cboSubSegmentos.Items.AddRange(new string[]
                    {
                "Desenvolvimento de Software",
                "Consultoria em TI",
                "Segurança da Informação",
                "Infraestrutura de Redes",
                "Serviços em Nuvem (Cloud Computing)",
                "Desenvolvimento de Aplicativos Mobile"
                    });
                    break;

                case "Educação":
                    cboSubSegmentos.Items.AddRange(new string[]
                    {
                "Escolas e Universidades",
                "Cursos Online (EAD)",
                "Formação Profissional",
                "Treinamento Corporativo",
                "Plataformas de Ensino à Distância",
                "Educação Infantil"
                    });
                    break;

                case "Saúde e Bem-Estar":
                    cboSubSegmentos.Items.AddRange(new string[]
                    {
                "Clínicas Médicas e Odontológicas",
                "Farmácias",
                "Hospitais",
                "Academias e Centros de Fitness",
                "Terapias Alternativas (Fisioterapia, Acupuntura)",
                "Saúde Mental (Psicologia e Psiquiatria)"
                    });
                    break;

                case "Alimentação e Bebidas":
                    cboSubSegmentos.Items.AddRange(new string[]
                    {
                "Restaurantes e Bares",
                "Fast Food",
                "Food Trucks",
                "Indústria Alimentícia",
                "Delivery de Alimentos",
                "Cafeterias"
                    });
                    break;

                case "Varejo":
                    cboSubSegmentos.Items.AddRange(new string[]
                    {
                "Supermercados",
                "Lojas de Roupas e Acessórios",
                "E-commerce",
                "Lojas de Conveniência",
                "Lojas de Móveis e Decoração",
                "Produtos Eletrônicos"
                    });
                    break;

                case "Turismo e Hotelaria":
                    cboSubSegmentos.Items.AddRange(new string[]
                    {
                "Agências de Viagens",
                "Hotéis e Resorts",
                "Pousadas e Hostels",
                "Turismo de Aventura",
                "Turismo de Luxo",
                "Aluguel de Temporada"
                    });
                    break;

                case "Construção Civil e Imobiliário":
                    cboSubSegmentos.Items.AddRange(new string[]
                    {
                "Construtoras e Incorporadoras",
                "Arquitetura e Design de Interiores",
                "Corretoras de Imóveis",
                "Engenharia Civil",
                "Venda e Aluguel de Imóveis",
                "Manutenção Predial"
                    });
                    break;

                case "Entretenimento e Cultura":
                    cboSubSegmentos.Items.AddRange(new string[]
                    {
                "Produtoras de Eventos",
                "Cinema e Produção Audiovisual",
                "Música e Shows",
                "Parques Temáticos",
                "Editoração e Publicação",
                "Streaming de Conteúdo"
                    });
                    break;

                case "Finanças e Seguros":
                    cboSubSegmentos.Items.AddRange(new string[]
                    {
                "Bancos e Instituições Financeiras",
                "Fintechs",
                "Corretoras de Seguros",
                "Consultoria Financeira",
                "Investimentos e Bolsa de Valores",
                "Cartões de Crédito e Pagamentos"
                    });
                    break;

                case "Logística e Transporte":
                    cboSubSegmentos.Items.AddRange(new string[]
                    {
                "Transporte de Cargas",
                "Empresas de Transporte Público",
                "Aluguel de Veículos",
                "Logística e Armazenagem",
                "Transporte Internacional (Importação e Exportação)",
                "Entregas de Pequenas Mercadorias"
                    });
                    break;

                case "Indústria":
                    cboSubSegmentos.Items.AddRange(new string[]
                    {
                "Indústria Automobilística",
                "Indústria Têxtil",
                "Indústria Química",
                "Indústria de Plásticos",
                "Indústria de Alimentos e Bebidas",
                "Indústria Metalúrgica"
                    });
                    break;

                case "Moda e Beleza":
                    cboSubSegmentos.Items.AddRange(new string[]
                    {
                "Salões de Beleza e Barbearias",
                "Indústria de Cosméticos",
                "Lojas de Roupas e Acessórios",
                "Consultoria de Imagem",
                "Maquiagem e Estética",
                "Spa e Clínicas de Beleza"
                    });
                    break;

                case "Agronegócio":
                    cboSubSegmentos.Items.AddRange(new string[]
                    {
                "Produção Agrícola",
                "Pecuária",
                "Produção de Alimentos Orgânicos",
                "Agroindústria",
                "Máquinas e Equipamentos Agrícolas",
                "Exportação de Produtos Agrícolas"
                    });
                    break;

                case "Energia e Sustentabilidade":
                    cboSubSegmentos.Items.AddRange(new string[]
                    {
                "Energia Renovável (Solar, Eólica)",
                "Mineração",
                "Tratamento de Resíduos",
                "Consultoria Ambiental",
                "Eficiência Energética",
                "Gestão de Recursos Naturais"
                    });
                    break;

                case "Comunicação e Marketing":
                    cboSubSegmentos.Items.AddRange(new string[]
                    {
                "Agências de Publicidade",
                "Marketing Digital",
                "Relações Públicas",
                "Consultoria em Branding",
                "Produção de Conteúdo",
                "Mídias Sociais"
                    });
                    break;

                default:
                    cboSubSegmentos.Items.Clear();
                    break;
            }

            // Opcional: Seleciona o primeiro subsegmento automaticamente
            if (cboSubSegmentos.Items.Count > 0)
            {
                cboSubSegmentos.SelectedIndex = 0;
            }
        }

        private void nEntonacao_Enter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(nEntonacao, " 1-Pouco Informal e 10-Muito Formal");
        }

        private void nOriginalidade_Enter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(nOriginalidade, " 1-Pouco Original e 10-Muito Original");
        }
    }
}