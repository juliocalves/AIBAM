using AIBAM.Classes;
using AIBAM.Classes.Servicos;
using AIBAM.Forms;

using System.ComponentModel;
using System.Net;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace AIBAM.Controles
{
    public partial class ProdutoControl : UserControl
    {
        internal Produto prod;
        public Utils util;
        internal bool isUpdate = false;
        private bool isSetItem = false;

        // Delegado para atualizar o status no Form principal
        public event Action<string> OnStatusChanged;
        // private readonly ProdutoService _produtoService;
        public event Action AtualizaBarraProgresso;
        public ProdutoControl()
        {
            //  _produtoService = new();
            InitializeComponent();
            prod = new Produto();
        }
        private void ProdutoControl_Load(object sender, EventArgs e)
        {
            _ = CarregarDadosComboBoxAsync();
        }
        public Produto ParseProduto()
        {
            AtualizaBarraProgresso?.Invoke();
            OnStatusChanged?.Invoke("Processamento iniciado");
            if (isUpdate)
            {
                prod.Id = Guid.Parse(lblId.Text);
            }
            else
            {
                prod.Id = Guid.NewGuid();
            }

            prod.NomeProd = txtNomeProd.Text;
            prod.LinkProd = txtLinkProd.Text;
            prod.CustoProd = Convert.ToDecimal(txtCusto.Text);
            prod.ValorVendaProd = Convert.ToDecimal(txtVenda.Text);
            prod.DescricaoProd = txtDescricao.Text;
            prod.GrupoProd = cboGrupoProd.Text;
            prod.CategoriaProd = cboCategoriaProd.Text;
            prod.PercentualDesconto = Convert.ToDecimal(txtDesc.Text);
            prod.ValorVendaPromocional = Convert.ToDecimal(txtVrPromo.Text);
            prod.DescontoPix = checkBox1.Checked;
            prod.LucroUnidade = Convert.ToDecimal(txtLuc.Text);
            prod.TagsProd = adicionarListaControl1.GetItensSelecionados();
            prod.PercentualDescontoPix = Convert.ToDecimal(txtDescontoPix.Text);
            prod.LucroUnidadePix = Convert.ToDecimal(txtLucroComPix.Text);
            OnStatusChanged?.Invoke("Fim de Processamento.");
            AtualizaBarraProgresso?.Invoke();
            return prod;
        }
        public void SetaDescricao(string txt)
        {
            txtDescricao.Text = txt;
        }
        public void SetaTags(string tags)
        {
            adicionarListaControl1.SetaItens(tags);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }
        public void DesabilitaAcoes()
        {
            toolStrip4.Enabled = !toolStrip4.Enabled;
            txtNomeProd.ReadOnly = !txtNomeProd.ReadOnly;
            txtCusto.ReadOnly = !txtCusto.ReadOnly;
            txtVenda.ReadOnly = !txtVenda.ReadOnly;
            checkBox1 .Enabled = !checkBox1.Enabled;
            txtVrPromo.ReadOnly = !txtVrPromo.ReadOnly;
            txtDescontoPix.ReadOnly = !txtDescontoPix.ReadOnly;
            txtLinkProd.ReadOnly = !txtLinkProd.ReadOnly;
            cboCategoriaProd.Enabled = !cboCategoriaProd.Enabled;
            cboGrupoProd.Enabled = !cboGrupoProd.Enabled;
            txtDescricao.ReadOnly = !txtDescricao.ReadOnly;

            adicionarListaControl1.DesabilitaAcoes();
        }

        public void Salvar()
        {
            ParseProduto();
            AtualizaBarraProgresso?.Invoke();
            OnStatusChanged?.Invoke("Executando açõo de banco de dados.");
            ProdutoService _produtoService = new();

            if (!isUpdate)
            {

                _ = _produtoService.AdicionarProduto(prod);
                // Atualiza o status após salvar
                OnStatusChanged?.Invoke("Produto salvo com sucesso!");
            }
            else
            {
                _ = _produtoService.AtualizarProdutoAsync(prod);
                // Atualiza o status após salvar
                isUpdate = false;
            }
            AtualizaBarraProgresso?.Invoke();
            btnLimpar.PerformClick();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        public void LimparCampos()
        {
            txtNomeProd.Text = string.Empty;
            txtLinkProd.Text = string.Empty;
            txtCusto.Text = string.Empty;
            txtVenda.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            cboGrupoProd.Text = string.Empty;
            cboCategoriaProd.Text = string.Empty;
            txtVrPromo.Text = string.Empty;
            txtDesc.Text = string.Empty;
            txtLuc.Text = string.Empty;
            txtVrPromo.Text = string.Empty;
            checkBox1.Checked = false;
            txtDescontoPix.Text = string.Empty;
            txtLucroComPix.Text = string.Empty;
            adicionarListaControl1.LimparLista();
            if (isUpdate)
            {
                isUpdate = false;
            }
        }

        private void ProdutoControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                e.SuppressKeyPress = true;
                btnSalvar.PerformClick();
            }
            else if (e.Control && e.KeyCode == Keys.L)
            {
                e.SuppressKeyPress = true;
                btnLimpar.PerformClick();
            }
        }
        private void txtCusto_KeyPress(object sender, KeyPressEventArgs e)
        {
            util.ApenasDecimal(sender, e);
        }
        private void txtVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            util.ApenasDecimal(sender, e);

        }
        private void txtVrPromo_KeyPress(object sender, KeyPressEventArgs e)
        {
            util.ApenasDecimal(sender, e);
        }

        public void SetProd(Produto _prod)
        {
            AtualizaBarraProgresso?.Invoke();
            OnStatusChanged?.Invoke("Atualizando interface.");
            btnLimpar.PerformClick();
            isSetItem = true;
            lblId.Text = _prod.Id.ToString();
            // Atribui valores aos campos da interface com base nas propriedades do objeto Produto
            txtNomeProd.Text = _prod.NomeProd;
            txtLinkProd.Text = _prod.LinkProd;
            txtCusto.Text = _prod.CustoProd.ToString("N2");
            txtVenda.Text = _prod.ValorVendaProd.ToString("N2");
            txtDescricao.Text = _prod.DescricaoProd;
            cboGrupoProd.Text = _prod.GrupoProd;
            cboCategoriaProd.Text = _prod.CategoriaProd;
            txtDesc.Text = _prod.PercentualDesconto.ToString("N2");
            txtVrPromo.Text = _prod.ValorVendaPromocional.ToString("N2");
            checkBox1.Checked = _prod.DescontoPix;
            txtLuc.Text = _prod.LucroUnidade.ToString("N2");
            checkBox1.Checked = _prod.DescontoPix;
            // Adiciona as tags do produto à lista de seleção
            if (_prod.TagsProd.Count > 0)
            {
                adicionarListaControl1.SetItensSelecionados(_prod.TagsProd);
            }
            txtDescontoPix.Text = _prod.PercentualDescontoPix.ToString("N2");
            txtLucroComPix.Text = _prod.LucroUnidadePix.ToString("N2");
            isUpdate = true;
            isSetItem = false;
            ParseProduto();
            OnStatusChanged?.Invoke("Interface pronta!");
            AtualizaBarraProgresso?.Invoke();
        }

        private void txtLinkProd_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLinkProd.Text))
            {
                // Abre o link em uma nova janela com o WebView2
                FrmWeb frmWebView = new FrmWeb(txtLinkProd.Text);
                frmWebView.Show();
            }
        }

        private void txtNomeProd_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNomeProd.Text))
            {
                // Processa o nome do produto para criar o link
                string nomeFormatado = txtNomeProd.Text
                    .Trim()                       // Remove espaços extras
                    .Replace(" ", "-")            // Substitui espaços por "-"
                    .ToLower();                   // Converte para minúsculas

                // Define o link formatado
                txtLinkProd.Text = $"https://reserva.ink/peralta/{nomeFormatado}";
            }
        }
        private async Task CarregarDadosComboBoxAsync()
        {
            try
            {
                // Limpa os itens existentes no ComboBox
                cboGrupoProd.Items.Clear();

                // Obtém os itens do ColecaoService
                ColecaoService colecaoService = new ColecaoService();
                var colecoes = await colecaoService.ListarColecaoAsync();

                // Adiciona os nomes das coleções ao ComboBox
                foreach (var colecao in colecoes)
                {
                    cboGrupoProd.Items.Add(colecao.Nome.Trim());
                }

                OnStatusChanged?.Invoke("Dados carregados com sucesso.");
            }
            catch (Exception ex)
            {
                OnStatusChanged?.Invoke($"Erro ao carregar dados: {ex.Message}");
            }
        }

        private void cboGrupoProd_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifica se a tecla pressionada foi Enter
            if (e.KeyCode == Keys.Enter)
            {
                // Obtém o texto atual do ComboBox
                string texto = cboGrupoProd.Text.Trim();

                // Verifica se o texto não está vazio e não é um item existente
                if (!string.IsNullOrEmpty(texto) && !cboGrupoProd.Items.Contains(texto))
                {
                    try
                    {
                        // Adiciona o novo item ao ComboBox
                        cboGrupoProd.Items.Add(texto);

                        _ = CriaNovaColecaoAsync(texto);

                        OnStatusChanged?.Invoke("Nova coleção adicionada com sucesso.");
                    }
                    catch (Exception ex)
                    {
                        OnStatusChanged?.Invoke($"Erro ao adicionar nova coleção: {ex.Message}");
                    }
                }
                else if (string.IsNullOrEmpty(texto))
                {
                    OnStatusChanged?.Invoke("O texto não pode estar vazio.");
                }
                else
                {
                    OnStatusChanged?.Invoke("O item já existe no ComboBox.");
                }

                // Previne o som padrão ao pressionar Enter
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private async Task CriaNovaColecaoAsync(string texto)
        {
            // Opcional: Atualiza o ColecaoService para salvar a nova coleção
            ColecaoService colecaoService = new ColecaoService();
            Colecao colecao = new();
            colecao.Nome = texto;
            await colecaoService.AdicionarColecao(colecao);
        }

        private void cboCategoriaProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Define os valores de custo associados a cada item
            Dictionary<string, decimal> custos = new Dictionary<string, decimal>
            {
                { "CAMISETA", 59 },
                { "CAMISETA ALGODÃO PERUANO", 79 },
                { "CAMISETA OVERSIZED", 80 },
                { "CAMISETA INFANTIL", 59},
                { "BODY INFANTIL",59},
                { "CROPPED",59 },
                { "CROPPED MOLETOM",119 },
                { "HOODIE MOLETOM", 159 },
                { "SUÉTER MOLETOM", 139}
            };

            // Obtém o item selecionado
            string itemSelecionado = cboCategoriaProd.SelectedItem?.ToString();

            // Verifica se o item está no dicionário de custos
            if (!string.IsNullOrEmpty(itemSelecionado) && custos.TryGetValue(itemSelecionado, out decimal custo))
            {
                // Atualiza o campo txtCusto com o valor correspondente
                txtCusto.Text = custo.ToString("F2"); // Formata como moeda (2 casas decimais)
            }
            else
            {
                // Caso o item não esteja na lista, limpa o campo txtCusto
                txtCusto.Clear();
            }
        }
        private void AtualizarValores()
        {
            txtVenda.Text = prod.ValorVendaProd.ToString("N2");
            txtDesc.Text = prod.PercentualDesconto.ToString("N2");
            txtLuc.Text = prod.LucroUnidade.ToString("N2");
            txtVrPromo.Text = prod.ValorVendaPromocional.ToString("N2");
            txtDescontoPix.Text = prod.PercentualDescontoPix.ToString("N2");
            txtLucroComPix.Text = prod.LucroUnidadePix.ToString("N2");
        }

        private void txtCusto_Leave(object sender, EventArgs e)
        {
            prod.CustoProd = !String.IsNullOrEmpty(txtCusto.Text) ?
                Convert.ToDecimal(txtCusto.Text) : 0;
            txtCusto.Text = prod.CustoProd.ToString("N2");
            prod.CalcularDescontoELucro();
            AtualizarValores();
        }

        private void txtVenda_Leave(object sender, EventArgs e)
        {
            prod.ValorVendaProd = !String.IsNullOrEmpty(txtVenda.Text) ?
                Convert.ToDecimal(txtVenda.Text) : 0;
            txtVenda.Text = prod.ValorVendaProd.ToString("N2");
            prod.CalcularDescontoELucro();
            AtualizarValores();
        }

        private void txtVrPromo_Leave(object sender, EventArgs e)
        {
            prod.ValorVendaPromocional = !String.IsNullOrEmpty(txtVrPromo.Text) ?
                Convert.ToDecimal(txtVrPromo.Text) : 0;
            prod.CalcularDescontoELucro();
            AtualizarValores();
        }
        private void txtCusto_TextChanged(object sender, EventArgs e)
        {
            if (!isSetItem)
            {
                prod.CustoProd = !String.IsNullOrEmpty(txtCusto.Text) ?
                Convert.ToDecimal(txtCusto.Text) : 0;
                prod.CalcularDescontoELucro();
                AtualizarValores();
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!isSetItem)
            {
                prod.DescontoPix = checkBox1.Checked;
                prod.PercentualDescontoPix = !String.IsNullOrEmpty(txtDescontoPix.Text) ?
                        Convert.ToDecimal(txtDescontoPix.Text) : 3;
                prod.AplicarDescontoPix();
                AtualizarValores();
            }
        }

        private void txtDescontoPix_KeyPress(object sender, KeyPressEventArgs e)
        {
            util.ApenasDecimal(sender, e);
        }

        private void txtDescontoPix_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtDescontoPix.Text) &&
                Convert.ToDecimal(txtDescontoPix.Text) > 0)
            {
                prod.PercentualDescontoPix = !String.IsNullOrEmpty(txtDescontoPix.Text) ?
                    Convert.ToDecimal(txtDescontoPix.Text) : 3;

                prod.AplicarDescontoPix();
                AtualizarValores();
            }
        }

        private void btnAplicarMarkup_Click(object sender, EventArgs e)
        {
            double markup = 2.1;
            prod.ValorVendaProd = prod.CustoProd * Convert.ToDecimal( markup);
            prod.AplicarDescontoPix();
            prod.CalcularDescontoELucro();
            AtualizarValores();
        }
    }
}
