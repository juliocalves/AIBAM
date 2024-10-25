using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using AIBAM.Classes;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
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


        // Configurar o cliente de chat
        ChatClient chatClient = new ChatClient("localhost", 8080);

        PromptCopy promptCopy;

        private string textoPromptCopy = "";

        public FrmPrincipal()
        {
            InitializeComponent();
            promptCopy = new();
            AdicionarEventosControles();
        }

        private void AdicionarEventosControles()
        {

            chatClient.OnMessageReceived += ChatClient_OnMessageReceived;
            chatClient.OnConect += ChatClient_Status;
            lstInteresses.OnExecutaAcao += AdicionarListaControl_OnStateChange;
            lstOcupacoes.OnExecutaAcao += AdicionarListaControl_OnStateChange;
            lstDores.OnExecutaAcao += AdicionarListaControl_OnStateChange;
            listDiferenciais.OnExecutaAcao += AdicionarListaControl_OnStateChange;
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
            // Adiciona a resposta ao controle de chat (chatControl)
            if (InvokeRequired)
            {
                Invoke(new Action(() => chatControl.AddBotResponse(response)));
            }
            else
            {
                chatControl.AddBotResponse(response);
            }
        }

        private async void RequestToChat()
        {
            SetStatus("Enviando solicitação...");
            AtualizaCursor(true);
            AtualizaBarraProgresso();

            // Exibe o prompt (mensagem do usuário) no ChatControl
            chatControl.AddUserMessage(txtPrompt.Text);

            string _ = "chat " + txtPrompt.Text;
            // Envia a mensagem para o servidor via socket
            await chatClient.SendMessage(_);

            AtualizaBarraProgresso();
            AtualizaCursor(false);

            // Limpa o campo de entrada após o envio
            txtPrompt.Clear();
            txtPrompt.Focus();
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
        private void toolChatLivre_Click(object sender, EventArgs e)
        {
            AtualizaBarraProgresso();
            toolChatLivre.CheckState = CheckState.Checked;
            toolChatParametrizado.Checked = !toolChatLivre.Checked;
            splitContainer2.Panel1Collapsed = !toolChatParametrizado.Checked;
            splitContainer2.Panel2Collapsed = !toolChatLivre.Checked;
            toolChatParametrizado.CheckState = CheckState.Unchecked;
            toolChatLivre.CheckState = CheckState.Checked;
            AtualizaBarraProgresso();
        }

        private void toolChatParametrizado_Click(object sender, EventArgs e)
        {
            AtualizaBarraProgresso();
            toolChatParametrizado.CheckState = CheckState.Checked;
            toolChatLivre.Checked = !toolChatParametrizado.Checked;
            splitContainer2.Panel1Collapsed = !toolChatParametrizado.Checked;
            splitContainer2.Panel2Collapsed = !toolChatLivre.Checked;
            toolChatLivre.CheckState = CheckState.Unchecked;
            toolChatParametrizado.CheckState = CheckState.Checked;
            AtualizaBarraProgresso();
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


        #region CONFIGURA PROMPT DE COPY
        #region PROMPTCOPY
        private void txtNomePromptCopy_Leave(object sender, EventArgs e)
        {
            promptCopy.DescricaoCopy = txtNomePromptCopy.Text;
        }

        private void gBTipoVenda_Leave(object sender, EventArgs e)
        {
            promptCopy.briefing.TipoVenda = rdbProduto.Checked ? rdbProduto.Text : rdbServico.Text;
        }

        private void textMarca_Leave(object sender, EventArgs e)
        {
            promptCopy.briefing.Marca = txtMarca.Text;
        }


        private void txtLinkSite_Leave(object sender, EventArgs e)
        {
            promptCopy.briefing.LinkSite = txtLinkSite.Text;
        }

        private void cboSegmento_Leave(object sender, EventArgs e)
        {
            promptCopy.briefing.SegmentoNegocio = cboSegmento.Text;
        }

        private void cboSubSegmentos_Leave(object sender, EventArgs e)
        {
            promptCopy.briefing.SubSegmentoNegocio = cboSubSegmentos.Text;
        }

        private void gBLancamento_Leave(object sender, EventArgs e)
        {
            promptCopy.briefing.ELancamentoProdServ = rdbSim.Checked ? rdbSim.Text : rdbNao.Text;
        }

        private void txtLinkCatalogo_Leave(object sender, EventArgs e)
        {
            promptCopy.briefing.LinkCatalogoProdServ = txtLinkCatalogo.Text;
        }

        private void txtObservacoes_Leave(object sender, EventArgs e)
        {
            promptCopy.briefing.Observacoes = txtObservacoes.Text;
        }

        private void txtInforProdServ_Leave(object sender, EventArgs e)
        {
            promptCopy.briefing.InformacoesProdServ = txtInforProdServ.Text;
        }

        private void txtObjetivoGeral_Leave(object sender, EventArgs e)
        {
            promptCopy.briefing.ObjetivoGeral = txtObjetivoGeral.Text;
        }

        private void txtObjetivoEspecifico_Leave(object sender, EventArgs e)
        {
            promptCopy.briefing.ObjetivoEspecifico = txtObjetivoEspecifico.Text;
        }

        private void cboDestinoCopy_Leave(object sender, EventArgs e)
        {
            promptCopy.briefing.DestinoCopy = cboDestinoCopy.Text;
        }

        private void txtMensagemCopy_Leave(object sender, EventArgs e)
        {
            promptCopy.briefing.MensagemTransmitida = txtMensagemCopy.Text;
        }

        private void gBMetas_Leave(object sender, EventArgs e)
        {
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
        }
        private void txtIdeiaPromovida_Leave(object sender, EventArgs e)
        {
            promptCopy.briefing.IdeiaPromovida = txtIdeiaPromovida.Text;
        }
        #endregion
        #region PUBLICO ALVO
        private void gbRangeIdade_Leave(object sender, EventArgs e)
        {
            promptCopy.publicoAlvo.IdadeInicial = (int)nIdadeInicial.Value;
            promptCopy.publicoAlvo.IdadeFinal = (int)nIdadeFinal.Value;
        }

        private void gbGenero_Leave(object sender, EventArgs e)
        {
            promptCopy.publicoAlvo.Genero = ObterTextoGroupBox(gbGenero);
        }

        private void cboNivelAcademico_Leave(object sender, EventArgs e)
        {
            promptCopy.publicoAlvo.NivelAcademico = cboNivelAcademico.Text;
        }

        private void txtPropostaValor_Leave(object sender, EventArgs e)
        {
            promptCopy.publicoAlvo.PropostaValor = txtPropostaValor.Text;
        }

        private void lstInteresses_Leave(object sender, EventArgs e)
        {
            // Acessa o método GetItensSelecionados da instância 
            // Atribui os interesses selecionados à propriedade no promptCopy
            promptCopy.publicoAlvo.Interesses = lstInteresses.GetItensSelecionados();
        }


        private void lstOcupacoes_Leave(object sender, EventArgs e)
        {
            promptCopy.publicoAlvo.Ocupacoes = lstOcupacoes.GetItensSelecionados();
        }

        private void lstDores_Leave(object sender, EventArgs e)
        {
            promptCopy.publicoAlvo.Dores = lstDores.GetItensSelecionados();
        }

        private void listDiferenciais_Leave(object sender, EventArgs e)
        {
            promptCopy.publicoAlvo.DiferenciasCompetitivos = listDiferenciais.GetItensSelecionados();
        }

        private void gbNivelConsciencia_Leave(object sender, EventArgs e)
        {
            promptCopy.publicoAlvo.NivelConsciencia = ObterTextoGroupBox(gbNivelConsciencia);
        }

        private void txtOutrasInf_Leave(object sender, EventArgs e)
        {
            promptCopy.publicoAlvo.OutrasInf = txtOutrasInf.Text;

        }
        #endregion
        #region CONTROLES CRIAÇÃO
        private void nEntonacao_Leave(object sender, EventArgs e)
        {
            promptCopy.controlesCopy.Entonacao = (int)nEntonacao.Value;
        }

        private void nOriginalidade_Leave(object sender, EventArgs e)
        {
            promptCopy.controlesCopy.Originalidade = (int)nOriginalidade.Value;
        }

        private void ckSentimentos_Leave(object sender, EventArgs e)
        {
            promptCopy.controlesCopy.Sentimeto = ObterItensSelecionado(ckSentimentos);
        }

        private void gbPerspectiva_Leave(object sender, EventArgs e)
        {
            promptCopy.controlesCopy.Perspectiva = ObterTextoGroupBox(gbPerspectiva);
        }

        private void lstPalavrasChave_Leave(object sender, EventArgs e)
        {
            promptCopy.controlesCopy.PalavrasChave = lstPalavrasChave.GetItensSelecionados();
        }
        #endregion
        #endregion


        #region SALVA DADOS EM FORMATO JSON
        public void SaveToJson(dynamic obj, string nome)
        {
            // Caminho do diretório de execução
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(directoryPath, $"{nome}.json");

            try
            {
                // Serializa o objeto promptCopy em JSON
                string json = JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);

                // Salva o arquivo JSON no diretório de execução
                File.WriteAllText(filePath, json);

                SetStatus("Dados salvos com sucesso!");
            }
            catch (Exception ex)
            {
                SetStatus($"Erro ao salvar os dados: {ex.Message}");
            }
        }
        #endregion

        private void salvarToolStripButton1_Click(object sender, EventArgs e)
        {
            AtualizaBarraProgresso();
            SetStatus("Iniciando processo salvar");
            ///salva aquivo em formato de texto concatenado
            MontaPrompt();

            saveFileDialog1.Filter = "Text files (*.txt)|*.txt";
            saveFileDialog1.Title = "Salvar Modelo Prompt";
            saveFileDialog1.DefaultExt = "md";
            saveFileDialog1.FileName = txtNomePromptCopy.Text;
            saveFileDialog1.AddExtension = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;
                ///salva arquivo em dbjson para iteração
                SaveToJson(promptCopy, txtNomePromptCopy.Text);
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

        #region  GERA TEXTO DE COPY PARAMETRIZADO
        private void MontaPrompt()
        {
            textoPromptCopy = $@"Você é um copywriter experiente com mais de 25 anos de carreira. Um profissional com
MBA especializado que escreve textos persuasivos e envolventes, com o objetivo de
promover produtos, serviços ou ideias.
Mas vamos além, você é um copywriter com textos publicitários vencedores de prêmios
da mais alta importância. Por isso, você é capaz de produzir excelentes textos
publicitários, seja ele impresso, online, em comerciais de TV, rádio ou qualquer outro
meio de comunicação.
Seu principal objetivo é criar mensagens que despertem interesse, gerem impacto
emocional com o intuito de persuadir o leitor ou espectador a tomar uma ação
específica, como fazer uma compra, se inscrever em uma lista de e-mails, solicitar mais
informações ou compartilhar um conteúdo. Para alcançar esse objetivo, um você utiliza
técnicas de redação persuasiva, conhecimento sobre o público-alvo, estratégias de
marketing e branding.
Além de escrever textos persuasivos, você também pode estar envolvido no processo
criativo e na elaboração de conceitos para campanhas publicitárias. Em colaboração
com equipes de marketing, publicidade ou agências de comunicação para desenvolver
mensagens que sejam eficazes e estejam alinhadas com os objetivos do cliente.
Em resumo, você é responsável por criar textos que vendem, seja para promover
produtos, serviços, marcas ou ideias, utilizando técnicas persuasivas e estratégias de
marketing para engajar o público-alvo e levá-lo a tomar ação.

Você vai criar umas peças de texto que eu vou solicitar.
Para isso, ira utilizar os detalhes do que queremos promover. 
As iformações delimitadas por <ATENCAO></ATENCAO>, 
são diretrizes para você considerar ao realizar as avaliações, sempre serão dispostas após o ponto critico.

Primeiro ira avaliar o Briefing detalhado do cliente.

{GerarTextoBriefing()}

Segundo irá avaliar a Definição do público alvo do cliente.

{GerarTextoPublicoAlvo()}

Terceiro irá avaliar Controles para gerar a peça de texto.

{GerarTextoControles()}
";
        }

        private string GerarTextoControles()
        {
            StringBuilder texto = new StringBuilder();

            texto.AppendLine("Controles:");
            texto.AppendLine("===============================");
            // Entonação
            texto.AppendLine($"Entonação: {promptCopy.controlesCopy.Entonacao}");

            texto.AppendLine("<ATENCAO>1-Muito informal e 10-Muito formal</ATENCAO>");

            // Originalidade
            texto.AppendLine($"Originalidade: {promptCopy.controlesCopy.Originalidade}");

            // Sentimentos
            if (promptCopy.controlesCopy.Sentimeto?.Count > 0)
            {
                texto.AppendLine("Sentimentos:");
                foreach (var sentimento in promptCopy.controlesCopy.Sentimeto)
                {
                    texto.AppendLine($"- {sentimento}");
                }
                texto.AppendLine("<ATENCAO>Emoção(ções) que serão expressas no texto</ATENCAO>");
            }

            // Perspectiva
            texto.AppendLine($"Perspectiva: {promptCopy.controlesCopy.Perspectiva}");
            texto.AppendLine("<ATENCAO>Forma de escrita do texto</ATENCAO>");


            // Palavras-chave
            if (promptCopy.controlesCopy.PalavrasChave?.Count > 0)
            {
                texto.AppendLine("Palavras-chave:");
                foreach (var palavraChave in promptCopy.controlesCopy.PalavrasChave)
                {
                    texto.AppendLine($"- {palavraChave}");
                }
            }
            texto.AppendLine("===============================");
            return texto.ToString();
        }

        private object GerarTextoPublicoAlvo()
        {
            StringBuilder texto = new StringBuilder();

            texto.AppendLine("Público-Alvo:");
            texto.AppendLine("===============================");

            // Faixa de idade
            texto.AppendLine($"Idade: de {promptCopy.publicoAlvo.IdadeInicial} a {promptCopy.publicoAlvo.IdadeFinal} anos.");

            // Gênero
            texto.AppendLine($"Gênero: {promptCopy.publicoAlvo.Genero}");

            // Nível Acadêmico
            texto.AppendLine($"Nível Acadêmico: {promptCopy.publicoAlvo.NivelAcademico}");

            // Proposta de Valor
            if (!string.IsNullOrEmpty(promptCopy.publicoAlvo.PropostaValor))
            {
                texto.AppendLine($"Proposta de Valor: {promptCopy.publicoAlvo.PropostaValor}");
            }

            // Interesses
            if (promptCopy.publicoAlvo.Interesses?.Count > 0)
            {
                texto.AppendLine("Interesses:");
                foreach (var interesse in promptCopy.publicoAlvo.Interesses)
                {
                    texto.AppendLine($"- {interesse}");
                }
            }

            // Ocupações
            if (promptCopy.publicoAlvo.Ocupacoes?.Count > 0)
            {
                texto.AppendLine("Ocupações:");
                foreach (var ocupacao in promptCopy.publicoAlvo.Ocupacoes)
                {
                    texto.AppendLine($"- {ocupacao}");
                }
            }

            // Dores
            if (promptCopy.publicoAlvo.Dores?.Count > 0)
            {
                texto.AppendLine("Dores do público:");
                foreach (var dor in promptCopy.publicoAlvo.Dores)
                {
                    texto.AppendLine($"- {dor}");
                }
                texto.AppendLine("<ATENCAO>Essa informação permitirá:\r\n● Destacar os pontos problemáticos, criando identificação e engajamento com a\r\nmensagem.\r\n● Apresentar o produto/serviço como a solução perfeita para suprir essa dor e\r\nnecessidade.\r\n● Enfatizar os benefícios como a transformação e o \"depois\" que o público-alvo\r\nterá ao utilizar o produto/serviço.\r\n● Antecipar objeções e quebras de confiança, tratando-as de forma empática.\r\n● Criar uma narrativa da jornada do usuário, da dor à solução, gerando\r\nenvolvimento emocional.</ATENCAO>");
            }

            // Diferenciais Competitivos
            if (promptCopy.publicoAlvo.DiferenciasCompetitivos?.Count > 0)
            {
                texto.AppendLine("Diferenciais Competitivos:");
                foreach (var diferencial in promptCopy.publicoAlvo.DiferenciasCompetitivos)
                {
                    texto.AppendLine($"- {diferencial}");
                }
            }

            // Nível de Consciência
            texto.AppendLine($"Nível de Consciência: {promptCopy.publicoAlvo.NivelConsciencia}");
            texto.AppendLine("<ATENCAO>Baseado no nível de consciência, adapte a abordagem\r\nda cópia para o nível de prontidão e conhecimento do público - alvo, usando:\r\n● Educacional para inconscientes do problema\r\n● Identificação da dor para conscientes do problema\r\n● Apresentação da solução para conscientes da solução\r\n● Diferenciação e benefícios para conscientes do produto\r\n● Oferta irresistível para totalmente conscientes\r\n● Reforço de decisão para clientes</ATENCAO>");
            
            // Outras Informações
            if (!string.IsNullOrEmpty(promptCopy.publicoAlvo.OutrasInf))
            {
                texto.AppendLine($"Outras Informações: {promptCopy.publicoAlvo.OutrasInf}");
            }
            texto.AppendLine("===============================");
            return texto.ToString();

        }

        public string GerarTextoBriefing()
        {
            StringBuilder briefingTexto = new StringBuilder();

            // Início do briefing
            briefingTexto.AppendLine("Briefing:");
            briefingTexto.AppendLine("===============================");

            // Descrição do Prompt
            briefingTexto.AppendLine($"Descrição do Copy: {promptCopy.DescricaoCopy}");

            // Tipo de Venda
            briefingTexto.AppendLine($"Tipo de Venda: {promptCopy.briefing.TipoVenda}");

            // Marca
            briefingTexto.AppendLine($"Marca: {promptCopy.briefing.Marca}");

            // Ideia Promovida
            briefingTexto.AppendLine($"Ideia Promovida: {promptCopy.briefing.IdeiaPromovida}");

            // Link do Site
            briefingTexto.AppendLine($"Link do Site: {promptCopy.briefing.LinkSite}");

            // Segmento e Subsegmento de Negócio
            briefingTexto.AppendLine($"Segmento de Negócio: {promptCopy.briefing.SegmentoNegocio}");
            briefingTexto.AppendLine($"Subsegmento de Negócio: {promptCopy.briefing.SubSegmentoNegocio}");

            // É lançamento de produto/serviço?
            briefingTexto.AppendLine($"É lançamento de produto ou serviço?: {promptCopy.briefing.ELancamentoProdServ}");

            // Link do Catálogo de Produto ou Serviço
            briefingTexto.AppendLine($"Link do Catálogo: {promptCopy.briefing.LinkCatalogoProdServ}");

            // Observações
            briefingTexto.AppendLine($"Observações: {promptCopy.briefing.Observacoes}");

            // Informações sobre Produto ou Serviço
            briefingTexto.AppendLine($"Informações sobre Produto ou Serviço: {promptCopy.briefing.InformacoesProdServ}");

            // Objetivos
            briefingTexto.AppendLine($"Objetivo Geral: {promptCopy.briefing.ObjetivoGeral}");
            briefingTexto.AppendLine($"Objetivo Específico: {promptCopy.briefing.ObjetivoEspecifico}");

            // Destino do Copy
            briefingTexto.AppendLine($"Destino do Copy: {promptCopy.briefing.DestinoCopy}");

            // Mensagem a ser Transmitida
            briefingTexto.AppendLine($"Mensagem a ser Transmitida: {promptCopy.briefing.MensagemTransmitida}");

            // Metas da Campanha
            briefingTexto.AppendLine("Metas da Campanha:");
            briefingTexto.AppendLine($"- Adição ao Carrinho: {(promptCopy.briefing.metasCampanhas.AdicaoCarrinho ? "Sim" : "Não")}");
            briefingTexto.AppendLine($"- Cadastro de Formulário: {(promptCopy.briefing.metasCampanhas.CadastroFrm ? "Sim" : "Não")}");
            briefingTexto.AppendLine($"- Cliques no Link: {(promptCopy.briefing.metasCampanhas.Clickslink ? "Sim" : "Não")}");
            briefingTexto.AppendLine($"- Compartilhamentos: {(promptCopy.briefing.metasCampanhas.Compartilhamentos ? "Sim" : "Não")}");
            briefingTexto.AppendLine($"- Desempenho: {(promptCopy.briefing.metasCampanhas.Desempenho ? "Sim" : "Não")}");
            briefingTexto.AppendLine($"- Engajamento: {(promptCopy.briefing.metasCampanhas.Engajamento ? "Sim" : "Não")}");
            briefingTexto.AppendLine($"- Interação: {(promptCopy.briefing.metasCampanhas.Interacao ? "Sim" : "Não")}");
            briefingTexto.AppendLine($"- Permanência na Página: {(promptCopy.briefing.metasCampanhas.PermanenciaPag ? "Sim" : "Não")}");
            briefingTexto.AppendLine($"- Registro: {(promptCopy.briefing.metasCampanhas.Registro ? "Sim" : "Não")}");
            briefingTexto.AppendLine($"- Seguidores: {(promptCopy.briefing.metasCampanhas.Seguidores ? "Sim" : "Não")}");
            briefingTexto.AppendLine($"- Vendas: {(promptCopy.briefing.metasCampanhas.Vendas ? "Sim" : "Não")}");
            briefingTexto.AppendLine($"- Visualizações: {(promptCopy.briefing.metasCampanhas.Vizualizacoes ? "Sim" : "Não")}");

            // Final do briefing
            briefingTexto.AppendLine("===============================");

            return briefingTexto.ToString();
        }

        #endregion

        private string ObterTextoGroupBox(GroupBox groupBox)
        {
            // Itera pelos controles no GroupBox
            foreach (Control control in groupBox.Controls)
            {
                // Verifica se o controle é um RadioButton e se está marcado
                if (control is RadioButton radioButton && radioButton.Checked)
                {
                    return radioButton.Text; // Retorna o texto do RadioButton selecionado
                }
            }

            return string.Empty; // Retorna vazio se nenhum RadioButton estiver selecionado
        }

        private List<string> ObterItensSelecionado(CheckedListBox ckList)
        {
            List<string> itensSelecionados = new List<string>();

            // Itera pelos itens checados em ckList
            foreach (var item in ckList.CheckedItems)
            {
                itensSelecionados.Add(item.ToString());
            }

            return itensSelecionados;
        }
    }
}