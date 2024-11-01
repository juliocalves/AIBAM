using AIBAM.Classes;
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
            AdicionarEventosControles();
            this.FormClosing += FrmConfiguracoes_FormClosing;
        }
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            AtualizaBarraProgresso();
            SetStatus("Carregando ferramentas...");

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

        private void AdicionarEventosControles()
        {

            chatClient.OnMessageReceived += ChatClient_OnMessageReceived;
            chatClient.OnConect += ChatClient_Status;
            lstObjetivosEspecificos.OnExecutaAcao += AdicionarListaControl_OnStateChange;
            lstInteresses.OnExecutaAcao += AdicionarListaControl_OnStateChange;
            lstOcupacoes.OnExecutaAcao += AdicionarListaControl_OnStateChange;
            lstDores.OnExecutaAcao += AdicionarListaControl_OnStateChange;
            lstDiferenciais.OnExecutaAcao += AdicionarListaControl_OnStateChange;
            lstPalavrasChave.OnExecutaAcao += AdicionarListaControl_OnStateChange;
        }

        private void AdicionarListaControl_OnStateChange(string obj)
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
        // Salva a conversação em um arquivo Markdown
        private void SaveConversation()
        {
            // Define o status antes de iniciar o salvamento
            SetStatus("Salvando a conversação...");
            AtualizaBarraProgresso();


            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Markdown files (*.md)|*.md|Text files (*.txt)|*.txt";
                saveFileDialog.Title = "Salvar Conversação";
                saveFileDialog.DefaultExt = "md";
                saveFileDialog.AddExtension = true;
                saveFileDialog.InitialDirectory = Path.Combine(Settings.Default.DiretorioRaiz, "CONVERSAS");
                saveFileDialog.FileName = "CONVERSA_LIVRE";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

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

        // Detecta Enter para enviar o prompt
        private void txtPrompt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                RequestToChat();
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

        private void cboSegmento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSegmento.SelectedItem != null && !string.IsNullOrEmpty(cboSegmento.SelectedItem.ToString()))
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
            promptCopy.briefing.TipoVenda = rdbProduto.Checked ? rdbProduto.Text : rdbServico.Text;
            promptCopy.briefing.Marca = txtMarca.Text;
            promptCopy.briefing.LinkSite = txtLinkSite.Text;
            promptCopy.briefing.SegmentoNegocio = cboSegmento.Text;
            promptCopy.briefing.SubSegmentoNegocio = cboSubSegmentos.Text;
            promptCopy.briefing.ELancamentoProdServ = rdbSim.Checked ? rdbSim.Text : rdbNao.Text;
            promptCopy.briefing.LinkCatalogoProdServ = txtLinkCatalogo.Text;
            promptCopy.briefing.Observacoes = txtObservacoes.Text;
            promptCopy.briefing.InformacoesProdServ = txtInforProdServ.Text;
            promptCopy.briefing.ObjetivoGeral = txtObjetivoGeral.Text;
            promptCopy.briefing.ObjetivoEspecifico = lstObjetivosEspecificos.GetItensSelecionados();
            promptCopy.briefing.DestinoCopy = cboDestinoCopy.Text;
            promptCopy.briefing.MensagemTransmitida = txtMensagemCopy.Text;
            promptCopy.briefing.metasCampanhas.AdicaoCarrinho = ckAdicao.Checked;
            promptCopy.briefing.metasCampanhas.CadastroFrm = chkCadastro.Checked;
            promptCopy.briefing.metasCampanhas.Clickslink = chkClick.Checked;
            promptCopy.briefing.metasCampanhas.Compartilhamentos = chkCompartilhamento.Checked;
            promptCopy.briefing.metasCampanhas.Desempenho = chkDesempenho.Checked;
            promptCopy.briefing.metasCampanhas.Engajamento = chkEngajamento.Checked;
            promptCopy.briefing.metasCampanhas.Interacao = chkInteracao.Checked;
            promptCopy.briefing.metasCampanhas.PermanenciaPag = chkPermanencia.Checked;
            promptCopy.briefing.metasCampanhas.Registro = chkRegistro.Checked;
            promptCopy.briefing.metasCampanhas.Seguidores = chkSeguidores.Checked;
            promptCopy.briefing.metasCampanhas.Vendas = chkVenda.Checked;
            promptCopy.briefing.metasCampanhas.Vizualizacoes = chkVizualizacao.Checked;
            promptCopy.briefing.IdeiaPromovida = txtIdeiaPromovida.Text;
            promptCopy.publicoAlvo.IdadeInicial = (int)nIdadeInicial.Value;
            promptCopy.publicoAlvo.IdadeFinal = (int)nIdadeFinal.Value;
            promptCopy.publicoAlvo.Genero = utils.ObterTextoGroupBox(gbGenero);
            promptCopy.publicoAlvo.NivelAcademico = cboNivelAcademico.Text;
            promptCopy.publicoAlvo.PropostaValor = txtPropostaValor.Text;
            // Acessa o método GetItensSelecionados da instância 
            // Atribui os interesses selecionados à propriedade no promptCopy
            promptCopy.publicoAlvo.Interesses = lstInteresses.GetItensSelecionados();
            promptCopy.publicoAlvo.Ocupacoes = lstOcupacoes.GetItensSelecionados();
            promptCopy.publicoAlvo.Dores = lstDores.GetItensSelecionados();
            promptCopy.publicoAlvo.DiferenciasCompetitivos = lstDiferenciais.GetItensSelecionados();
            promptCopy.publicoAlvo.NivelConsciencia = utils.ObterTextoGroupBox(gbNivelConsciencia);
            promptCopy.publicoAlvo.OutrasInf = txtOutrasInf.Text;
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
                ///salva arquivo em dbjson para iteração
                utils.SaveToJson(promptCopy, txtNomePromptCopy.Text);
                try
                {
                    File.WriteAllText(filePath, textoPromptCopy);
                    MessageBox.Show($"Modelo Prompt salvo em: {filePath}", "Salvo com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Atualiza o status após o salvamento bem-sucedido
                    SetStatus("Modelo Prompt salva com sucesso!");
                }
                catch (Exception ex)
                {
                    // Mostra a mensagem de erro
                    MessageBox.Show($"Erro ao salvar a Modelo Prompt: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Atualiza o status em caso de erro
                    SetStatus("Erro ao salvar a Modelo Prompt.");
                }
            }
            else
            {
                // Atualiza o status se o usuário cancelar a operação de salvamento
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
                    txtMarca.Text = promptCopy.briefing.Marca;
                    txtLinkSite.Text = promptCopy.briefing.LinkSite;
                    cboSegmento.Text = promptCopy.briefing.SegmentoNegocio;
                    cboSubSegmentos.Text = promptCopy.briefing.SubSegmentoNegocio;
                    txtLinkCatalogo.Text = promptCopy.briefing.LinkCatalogoProdServ;
                    txtObservacoes.Text = promptCopy.briefing.Observacoes;
                    txtInforProdServ.Text = promptCopy.briefing.InformacoesProdServ;
                    txtObjetivoGeral.Text = promptCopy.briefing.ObjetivoGeral;
                    lstObjetivosEspecificos.SetItensSelecionados(promptCopy.briefing.ObjetivoEspecifico);
                    cboDestinoCopy.Text = promptCopy.briefing.DestinoCopy;
                    txtMensagemCopy.Text = promptCopy.briefing.MensagemTransmitida;
                    txtIdeiaPromovida.Text = promptCopy.briefing.IdeiaPromovida;

                    // Atualiza os valores de metas de campanhas
                    ckAdicao.Checked = promptCopy.briefing.metasCampanhas.AdicaoCarrinho;
                    chkCadastro.Checked = promptCopy.briefing.metasCampanhas.CadastroFrm;
                    chkClick.Checked = promptCopy.briefing.metasCampanhas.Clickslink;
                    chkCompartilhamento.Checked = promptCopy.briefing.metasCampanhas.Compartilhamentos;
                    chkDesempenho.Checked = promptCopy.briefing.metasCampanhas.Desempenho;
                    chkEngajamento.Checked = promptCopy.briefing.metasCampanhas.Engajamento;
                    chkInteracao.Checked = promptCopy.briefing.metasCampanhas.Interacao;
                    chkPermanencia.Checked = promptCopy.briefing.metasCampanhas.PermanenciaPag;
                    chkRegistro.Checked = promptCopy.briefing.metasCampanhas.Registro;
                    chkSeguidores.Checked = promptCopy.briefing.metasCampanhas.Seguidores;
                    chkVenda.Checked = promptCopy.briefing.metasCampanhas.Vendas;
                    chkVizualizacao.Checked = promptCopy.briefing.metasCampanhas.Vizualizacoes;

                    // Atualiza o público-alvo
                    nIdadeInicial.Value = promptCopy.publicoAlvo.IdadeInicial;
                    nIdadeFinal.Value = promptCopy.publicoAlvo.IdadeFinal;
                    // Presume que ObterTextoGroupBox retorna o valor correto
                    SetSelectedValue(gbGenero, promptCopy.publicoAlvo.Genero);
                    cboNivelAcademico.Text = promptCopy.publicoAlvo.NivelAcademico;
                    txtPropostaValor.Text = promptCopy.publicoAlvo.PropostaValor;

                    // Atribui os interesses e ocupações usando o método GetItensSelecionados
                    lstInteresses.SetItensSelecionados(promptCopy.publicoAlvo.Interesses);
                    lstOcupacoes.SetItensSelecionados(promptCopy.publicoAlvo.Ocupacoes);
                    lstDores.SetItensSelecionados(promptCopy.publicoAlvo.Dores);
                    lstDiferenciais.SetItensSelecionados(promptCopy.publicoAlvo.DiferenciasCompetitivos);

                    // Atualiza o nível de consciência e outras informações
                    SetSelectedValue(gbNivelConsciencia, promptCopy.publicoAlvo.NivelConsciencia);
                    txtOutrasInf.Text = promptCopy.publicoAlvo.OutrasInf;
                    SetSelectedValue(ckSentimentos, promptCopy.controlesCopy.Sentimento);
                    // Atualiza os controles de criação
                    nEntonacao.Value = promptCopy.controlesCopy.Entonacao;
                    nOriginalidade.Value = promptCopy.controlesCopy.Originalidade;
                    SetSelectedValue(gbPerspectiva, promptCopy.controlesCopy.Perspectiva);
                    lstPalavrasChave.SetItensSelecionados(promptCopy.controlesCopy.PalavrasChave);

                    lblArquivo.Text = promptCopy.briefing.ArquivoImportado;
                    if (!string.IsNullOrEmpty(lblArquivo.Text))
                    {
                        toolStripButtonRemoverArquivo.Visible = true;
                    }

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

        private void SetSelectedValue(CheckedListBox ckList, List<string> itens)
        {
            // Itera sobre todos os itens no CheckedListBox
            for (int i = 0; i < ckList.Items.Count; i++)
            {
                // Verifica se o texto do item atual está na lista de itens fornecida
                if (itens.Contains(ckList.Items[i].ToString()))
                {
                    // Marca o item se estiver na lista
                    ckList.SetItemChecked(i, true);
                }
                else
                {
                    // Desmarca o item se não estiver na lista
                    ckList.SetItemChecked(i, false);
                }
            }
        }

        private void SetSelectedValue(GroupBox groupBox, string value)
        {
            foreach (Control control in groupBox.Controls)
            {
                if (control is RadioButton radioButton)
                {
                    radioButton.Checked = radioButton.Text == value;
                }
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
            txtMarca.Clear();
            txtLinkSite.Clear();
            cboSegmento.SelectedIndex = -1; // Limpa a seleção do ComboBox
            cboSubSegmentos.SelectedIndex = -1; // Limpa a seleção do ComboBox
            txtLinkCatalogo.Clear();
            txtObservacoes.Clear();
            txtInforProdServ.Clear();
            txtObjetivoGeral.Clear();
            lstObjetivosEspecificos.LimparLista();
            cboDestinoCopy.SelectedIndex = -1; // Limpa a seleção do ComboBox
            txtMensagemCopy.Clear();
            txtIdeiaPromovida.Clear();

            // Limpa os campos de metas de campanhas
            ckAdicao.Checked = false;
            chkCadastro.Checked = false;
            chkClick.Checked = false;
            chkCompartilhamento.Checked = false;
            chkDesempenho.Checked = false;
            chkEngajamento.Checked = false;
            chkInteracao.Checked = false;
            chkPermanencia.Checked = false;
            chkRegistro.Checked = false;
            chkSeguidores.Checked = false;
            chkVenda.Checked = false;
            chkVizualizacao.Checked = false;

            // Limpa o público-alvo
            nIdadeInicial.Value = nIdadeInicial.Minimum; // ou 0, dependendo do seu controle
            nIdadeFinal.Value = nIdadeFinal.Minimum; // ou 0, dependendo do seu controle
            SetSelectedValue(gbGenero, string.Empty); // Limpa o gênero
            cboNivelAcademico.SelectedIndex = -1; // Limpa a seleção do ComboBox
            txtPropostaValor.Clear();

            // Limpa os interesses e ocupações
            lstInteresses.LimparLista();
            lstOcupacoes.LimparLista();
            lstDores.LimparLista();
            lstDiferenciais.LimparLista();

            // Limpa o nível de consciência e outras informações
            SetSelectedValue(gbNivelConsciencia, string.Empty); // Limpa o nível de consciência
            txtOutrasInf.Clear();

            // Limpa os controles de criação
            nEntonacao.Value = nEntonacao.Minimum; // ou 0, dependendo do seu controle
            nOriginalidade.Value = nOriginalidade.Minimum; // ou 0, dependendo do seu controle
            SetSelectedValue(gbPerspectiva, string.Empty); // Limpa a perspectiva
            lstPalavrasChave.LimparLista();
            SetSelectedValue(ckSentimentos, new List<string>());

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

        private void toolStripButtonAdicionarArquivo_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Todos os Arquivos (*.*)|*.*";
            SetStatus("Carregando imagem");
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Armazena o caminho no Briefing atual
                promptCopy.briefing.ArquivoImportado = openFileDialog1.FileName;

                // Obtém apenas o nome do arquivo sem caminho e sem extensão
                string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName);

                // Exibe o nome do arquivo sem extensão na label
                lblArquivo.Text = "Item carregado: " + fileNameWithoutExtension;
                toolStripButtonRemoverArquivo.Visible = true;
            }
            SetStatus("Pronto");
        }

        private void toolStripButtonRemoverArquivo_Click(object sender, EventArgs e)
        {
            // Remove o arquivo do Briefing
            promptCopy.briefing.ArquivoImportado = string.Empty;

            // Atualiza a label e oculta o botão de remoção
            lblArquivo.Text = string.Empty;
            toolStripButtonRemoverArquivo.Visible = false;
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
            FrmPrincipal frm = new();
            frm.Show();
        }

        private void catalogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCatalogoProdServ frm = new();
            frm.OnStatusUpdate += SetStatus;
            frm.Show();
        }
    }
}