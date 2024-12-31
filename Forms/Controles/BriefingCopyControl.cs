using AIBAM.Classes;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIBAM.Forms.Controles
{
    public partial class BriefingCopyControl : UserControl
    {
        public BriefingCopy briefing;
        public Utils utils;
        // Delegado para atualizar o status no Form principal
        public Action<string>? statusUpdater;
        public BriefingCopyControl()
        {
            InitializeComponent();
        }
        private void ParseBrienfing()
        {
            briefing = new();
            briefing.TipoVenda = rdbProduto.Checked ? rdbProduto.Text : rdbServico.Text;
            briefing.Marca = txtMarca.Text;
            briefing.LinkSite = txtLinkSite.Text;
            briefing.SegmentoNegocio = cboSegmento.Text;
            briefing.SubSegmentoNegocio = cboSubSegmentos.Text;
            briefing.ELancamentoProdServ = rdbSim.Checked ? rdbSim.Text : rdbNao.Text;
            briefing.LinkCatalogoProdServ = txtLinkCatalogo.Text;
            briefing.Observacoes = txtObservacoes.Text;
            briefing.InformacoesProdServ = txtInforProdServ.Text;
            briefing.ObjetivoGeral = txtObjetivoGeral.Text;
            briefing.ObjetivoEspecifico = lstObjetivosEspecificos.GetItensSelecionados();
            briefing.DestinoCopy = cboDestinoCopy.Text;
            briefing.MensagemTransmitida = txtMensagemCopy.Text;
            briefing.metasCampanhas.AdicaoCarrinho = ckAdicao.Checked;
            briefing.metasCampanhas.CadastroFrm = chkCadastro.Checked;
            briefing.metasCampanhas.Clickslink = chkClick.Checked;
            briefing.metasCampanhas.Compartilhamentos = chkCompartilhamento.Checked;
            briefing.metasCampanhas.Desempenho = chkDesempenho.Checked;
            briefing.metasCampanhas.Engajamento = chkEngajamento.Checked;
            briefing.metasCampanhas.Interacao = chkInteracao.Checked;
            briefing.metasCampanhas.PermanenciaPag = chkPermanencia.Checked;
            briefing.metasCampanhas.Registro = chkRegistro.Checked;
            briefing.metasCampanhas.Seguidores = chkSeguidores.Checked;
            briefing.metasCampanhas.Vendas = chkVenda.Checked;
            briefing.metasCampanhas.Vizualizacoes = chkVizualizacao.Checked;
            briefing.IdeiaPromovida = txtIdeiaPromovida.Text;
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

        public void AtribuirBriefing(BriefingCopy _briefing)
        {

            txtMarca.Text = _briefing.Marca;
            txtLinkSite.Text = _briefing.LinkSite;
            cboSegmento.Text = _briefing.SegmentoNegocio;
            cboSubSegmentos.Text = _briefing.SubSegmentoNegocio;
            txtLinkCatalogo.Text = _briefing.LinkCatalogoProdServ;
            txtObservacoes.Text = _briefing.Observacoes;
            txtInforProdServ.Text = _briefing.InformacoesProdServ;
            txtObjetivoGeral.Text = _briefing.ObjetivoGeral;
            lstObjetivosEspecificos.SetItensSelecionados(_briefing.ObjetivoEspecifico);
            cboDestinoCopy.Text = _briefing.DestinoCopy;
            txtMensagemCopy.Text = _briefing.MensagemTransmitida;
            txtIdeiaPromovida.Text = _briefing.IdeiaPromovida;
            ckAdicao.Checked = _briefing.metasCampanhas.AdicaoCarrinho;
            chkCadastro.Checked = _briefing.metasCampanhas.CadastroFrm;
            chkClick.Checked = _briefing.metasCampanhas.Clickslink;
            chkCompartilhamento.Checked = _briefing.metasCampanhas.Compartilhamentos;
            chkDesempenho.Checked = _briefing.metasCampanhas.Desempenho;
            chkEngajamento.Checked = _briefing.metasCampanhas.Engajamento;
            chkInteracao.Checked = _briefing.metasCampanhas.Interacao;
            chkPermanencia.Checked = _briefing.metasCampanhas.PermanenciaPag;
            chkRegistro.Checked = _briefing.metasCampanhas.Registro;
            chkSeguidores.Checked = _briefing.metasCampanhas.Seguidores;
            chkVenda.Checked = _briefing.metasCampanhas.Vendas;
            chkVizualizacao.Checked = _briefing.metasCampanhas.Vizualizacoes;
            lblArquivo.Text = _briefing.ArquivoImportado;
            if (!string.IsNullOrEmpty(lblArquivo.Text))
            {
                toolStripButtonRemoverArquivo.Visible = true;
            }
        }
        public void LimparCampos()
        {
            txtMarca.Clear();
            txtLinkSite.Clear();
            cboSegmento.SelectedIndex = -1; // Limpa a seleção do ComboBox
            cboSubSegmentos.SelectedIndex = -1; // Limpa a seleção do ComboBox
            txtLinkCatalogo.Clear();
            txtObservacoes.Clear();
            txtInforProdServ.Clear();
            // txtObjetivoGeral.Clear();
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
        }

        private void toolStripButtonAdicionarArquivo_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Todos os Arquivos (*.*)|*.*";
            statusUpdater?.Invoke("Carregando imagem");
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Armazena o caminho no Briefing atual
                briefing.ArquivoImportado = openFileDialog1.FileName;

                // Obtém apenas o nome do arquivo sem caminho e sem extensão
                string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName);

                // Exibe o nome do arquivo sem extensão na label
                lblArquivo.Text = "Item carregado: " + fileNameWithoutExtension;
                toolStripButtonRemoverArquivo.Visible = true;
            }
            statusUpdater?.Invoke("Pronto");
        }

        /// <summary>
        /// CARREGA IMAGEM OU DOC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonRemoverArquivo_Click(object sender, EventArgs e)
        {
            // Remove o arquivo do Briefing
            briefing.ArquivoImportado = string.Empty;

            // Atualiza a label e oculta o botão de remoção
            lblArquivo.Text = string.Empty;
            toolStripButtonRemoverArquivo.Visible = false;
        }

        internal BriefingCopy RetornaBriefing()
        {
            ParseBrienfing();
            return briefing;
        }

        private void salvarToolStripButton_Click(object sender, EventArgs e)
        {
            BriefingCopyService briefingCopyService = new();
            ParseBrienfing();
            try
            {
                _ = briefingCopyService.AdcionarBriefingCopy(briefing);
                statusUpdater?.Invoke("Briefing salvo com sucesso!");
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Erro ao salvar: {ex}");
            }
        }

        private void novaToolStripButton1_Click(object sender, EventArgs e)
        {
            LimparCampos();
            statusUpdater?.Invoke("Pronto!");
        }

        internal List<BriefingCopy> briefingList;
        private void abrirToolStripButton1_Click(object sender, EventArgs e)
        {
            CarregarDadosAsync();
        }

        private async void CarregarDadosAsync()
        {
            briefingList = new();
            BriefingCopyService briefingCopyService = new();
            briefingList = await briefingCopyService.ListarBriefingCopyAsync();
            if (briefingList == null || briefingList.Count == 0)
            {
                MessageBox.Show("Não há itens a listar");
            }
            else
            {
                // Criar e exibir o formulário secundário
                using (FrmListar frm = new FrmListar(briefingList))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        // Obter o objeto selecionado
                        BriefingCopy selectedBriefing = frm.SelectedBriefing;

                        if (selectedBriefing != null)
                        {
                            MetasCampanhaService metasCampanhaService = new();
                            selectedBriefing.metasCampanhas = await metasCampanhaService.ObterMetasCampanhaPorIdAsync(selectedBriefing.metasCampanhasId);
                            AtribuirBriefing(selectedBriefing); // Processar o objeto no formulário principal
                        }
                    }
                }
            }
        }
    }
}
