using AIBAM.Classes;
using AIBAM.Classes.Servicos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIBAM.Controles
{
    public partial class PublicoAlvoControl : UserControl
    {
        public PublicoAlvo publicoAlvo = new();
        public Utils? utils;
        // Delegado para atualizar o status no Form principal
        public Action<string>? statusUpdater;
        public event Action AtualizaBarraProgresso;
        //private readonly PublicoAlvoService _publicoAlvoService;
        public PublicoAlvoControl()
        {
            InitializeComponent();
            // Instanciar manualmente o PublicoAlvoService
            // _publicoAlvoService = new ();
            utils = new Utils(message => statusUpdater?.Invoke(message), AtualizaBarraProgresso);
        }

        private void ParsePublicoAlvo()
        {
            publicoAlvo = new()
            {
                //INFORMAÇÕES GERAIS
                Nome = txtNomePublico.Text,
                Descricao = txtDescricaoPublicoAlvo.Text,
                PropostaValor = txtPropostaValor.Text,
                NivelConsciencia = utils.ObterTextoGroupBox(gbNivelConsciencia),
                OutrasInformacoes = txtOutrasInf.Text,

                //SEGMENTAÇÃO DEMOGRÁFICA
                IdadeInicial = (int)nIdadeInicial.Value,
                IdadeFinal = (int)nIdadeFinal.Value,
                NivelAcademico = cboNivelAcademico.Text,
                Genero = utils.ObterTextoGroupBox(gbGenero),
                Ocupacoes = lstOcupacoes.GetItensSelecionados(),

                //SEGMENTAÇÃO GEOGRÁFICA
                Pais = txtPais.Text,
                Estado = txtEstado.Text,
                Cidade = txtCidade.Text,
                Regiao = cboRegiao.Text,

                //SEGMENTAÇÃO COMPORTAMENTAL
                Interesses = lstInteresses.GetItensSelecionados(),
                Dores = lstDores.GetItensSelecionados(),
                DiferenciaisCompetitivos = lstDiferenciais.GetItensSelecionados(),

                // SEGMENTAÇÃO DE VOLUME
                TamanhoMercado = string.IsNullOrWhiteSpace(txtTamanhoMercado.Text)
                    ? 0
                    : Convert.ToInt32(txtTamanhoMercado.Text),
                ReceitaAnualMedia = string.IsNullOrWhiteSpace(txtReceitaAnualMedia.Text)
                    ? 0m
                    : Convert.ToDecimal(txtReceitaAnualMedia.Text),
                TicketMedio = string.IsNullOrWhiteSpace(txtTicketMedio.Text)
                    ? 0m
                    : Convert.ToDecimal(txtTicketMedio.Text)

            };
        }
        public PublicoAlvo RetonaPublicoAlvo()
        {
            ParsePublicoAlvo();
            return publicoAlvo;
        }
        public void AtribuirPublicoAlvo(PublicoAlvo publicoAlvo)
        {
            // INFORMAÇÕES GERAIS
            txtNomePublico.Text = publicoAlvo.Nome;
            txtDescricaoPublicoAlvo.Text = publicoAlvo.Descricao;
            txtPropostaValor.Text = publicoAlvo.PropostaValor;
            utils.SetSelectedValue(gbNivelConsciencia, publicoAlvo.NivelConsciencia);
            txtOutrasInf.Text = publicoAlvo.OutrasInformacoes;

            // SEGMENTAÇÃO DEMOGRÁFICA
            nIdadeInicial.Value = publicoAlvo.IdadeInicial;
            nIdadeFinal.Value = publicoAlvo.IdadeFinal;
            cboNivelAcademico.Text = publicoAlvo.NivelAcademico;
            utils.SetSelectedValue(gbGenero, publicoAlvo.Genero);
            lstOcupacoes.SetItensSelecionados(publicoAlvo.Ocupacoes);

            // SEGMENTAÇÃO GEOGRÁFICA
            txtPais.Text = publicoAlvo.Pais;
            txtEstado.Text = publicoAlvo.Estado;
            txtCidade.Text = publicoAlvo.Cidade;
            cboRegiao.Text = publicoAlvo.Regiao;

            // SEGMENTAÇÃO COMPORTAMENTAL
            lstInteresses.SetItensSelecionados(publicoAlvo.Interesses);
            lstDores.SetItensSelecionados(publicoAlvo.Dores);
            lstDiferenciais.SetItensSelecionados(publicoAlvo.DiferenciaisCompetitivos);

            // SEGMENTAÇÃO DE VOLUME
            txtTamanhoMercado.Text = publicoAlvo.TamanhoMercado.ToString();
            txtReceitaAnualMedia.Text = publicoAlvo.ReceitaAnualMedia?.ToString("F2") ?? string.Empty;
            txtTicketMedio.Text = publicoAlvo.TicketMedio?.ToString("F2") ?? string.Empty;

            statusUpdater?.Invoke("Público-alvo atribuído com sucesso!");
        }

        public void LimparCampos()
        {
            // INFORMAÇÕES GERAIS
            txtNomePublico.Clear();
            txtDescricaoPublicoAlvo.Clear();
            txtPropostaValor.Clear();
            utils.SetSelectedValue(gbNivelConsciencia, string.Empty);
            txtOutrasInf.Clear();

            // SEGMENTAÇÃO DEMOGRÁFICA
            nIdadeInicial.Value = nIdadeInicial.Minimum;
            nIdadeFinal.Value = nIdadeFinal.Minimum;
            utils.SetSelectedValue(gbGenero, string.Empty);
            cboNivelAcademico.SelectedIndex = -1;
            lstOcupacoes.LimparLista();

            // SEGMENTAÇÃO GEOGRÁFICA
            txtPais.Clear();
            txtEstado.Clear();
            txtCidade.Clear();
            cboRegiao.SelectedIndex = -1;

            // SEGMENTAÇÃO COMPORTAMENTAL
            lstInteresses.LimparLista();
            lstDores.LimparLista();
            lstDiferenciais.LimparLista();

            // SEGMENTAÇÃO DE VOLUME
            txtTamanhoMercado.Clear();
            txtReceitaAnualMedia.Clear();
            txtTicketMedio.Clear();

            statusUpdater?.Invoke("Campos limpos com sucesso!");
        }

        private void novaToolStripButton1_Click(object sender, EventArgs e)
        {
            LimparCampos();
            statusUpdater?.Invoke("Pronto para novo objeto!");
        }

        private void txtReceitaAnualMedia_KeyPress(object sender, KeyPressEventArgs e)
        {
            utils.ApenasDecimal(sender, e);
        }

        private void txtTicketMedio_KeyPress(object sender, KeyPressEventArgs e)
        {
            utils.ApenasDecimal(sender, e);
        }

        private void txtTamanhoMercado_KeyPress(object sender, KeyPressEventArgs e)
        {
            utils.ApenasDecimal(sender, e);
        }

        private void salvarToolStripButton_Click(object sender, EventArgs e)
        {
            PublicoAlvoService _publicoAlvoService = new();
            ParsePublicoAlvo();
            _ = _publicoAlvoService.AdicionarPublicoAsync(publicoAlvo);
            statusUpdater?.Invoke("Publico alvo salvo sucesso!");
        }

        private void abrirToolStripButton1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Selecione o arquivo de dados de público-alvo";
                openFileDialog.Filter = "JSON Files (*.json)|*.json";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string publicoAlvoFile = openFileDialog.FileName;

                    try
                    {
                        // Carrega o conteúdo JSON e desserializa para uma instância de PublicoAlvo
                        string jsonContent = File.ReadAllText(publicoAlvoFile);
                        PublicoAlvo publicoAlvo = JsonSerializer.Deserialize<PublicoAlvo>(jsonContent);

                        if (publicoAlvo != null)
                        {

                            // Usa o método AtribuirPublicoAlvo para preencher o formulário
                            AtribuirPublicoAlvo(publicoAlvo);
                            statusUpdater?.Invoke("Dados de público-alvo carregados com sucesso.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao carregar dados de público-alvo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Nenhum arquivo selecionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void PublicoAlvoControl_Load(object sender, EventArgs e)
        {
            publicoAlvo = new();
        }
    }
}
