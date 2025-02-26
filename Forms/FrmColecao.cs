using System;
using System.Globalization;
using System.Windows.Forms;

using AIBAM.Classes;
using AIBAM.Classes.Servicos;
using AIBAM.Controles;
using AIBAM.Forms;

using Newtonsoft.Json;

namespace AIBAM
{
    public partial class FrmColecao : Form
    {
        public Utils utils;
        public event Action<string> OnStatusChanged;
        public event Action AtualizaBarraProgresso;
        private string filePath;
        private Colecao colecao;
        private List<Colecao> colecoes;
        private Produto prodSelec;
        private List<Produto> produtos;
        private ColecaoService _colecoesService;
        private ProdutoService _produtoService;
        private PublicoAlvo publicoAlvo;
        private Navegador<Colecao> navegador;
        private bool IsUpdate = false;
        public FrmColecao()
        {
            InitializeComponent();
            colecao = new();
            produtos = new();
            _colecoesService = new();
            _produtoService = new();
            HabitaDesabilitaCampos();
        }
        private bool _novo;
        public FrmColecao(bool Novo)
        {
            InitializeComponent();
            _novo = Novo;
            HabitaDesabilitaCampos();
            colecao = new();
            produtos = new();
            _colecoesService = new();
            _produtoService = new();
        }

        private void HabitaDesabilitaCampos()
        {
            if (_novo)
            {
                label5.Visible = false;
                txtPesquisaCatalogo.Visible = false;
                btnAnterior.Visible = false;
                btnProximo.Visible = false;
                btnSalvarAlteracoes.Visible = false;
                btnExcluir.Visible = false;
                splitContainer1.Dock = DockStyle.Fill;
                dgvProdutos.Dock = DockStyle.Bottom;
                return;
            }
            label5.Visible = !IsUpdate;
            txtPesquisaCatalogo.Visible = !IsUpdate;
            btnAnterior.Visible = !IsUpdate;
            btnProximo.Visible = !IsUpdate;
            btnSalvarAlteracoes.Visible = IsUpdate;
        }
        private async void AtualizaGrid()
        {
            try
            {
                AtualizaBarraProgresso?.Invoke();
                ProdutoControl_OnStatusChanged($"Carregando dados ...");
                // Atualiza a lista geral apenas se ainda não tiver sido carregada
                if (produtos.Count == 0)
                {
                    produtos = await _produtoService.ListarProdutoAsync();
                }
                else if (isRefresh)
                {
                    produtos = new();
                    produtos = await _produtoService.ListarProdutoAsync();
                    isRefresh = false;
                }

                // Limpa os dados atuais do DataGridView
                dgvProdutos.Rows.Clear();

                // Adiciona cada produto ao DataGridView
                foreach (var produto in produtos)
                {
                    // Verifica se o produto já foi selecionado no Coleção
                    bool selecionado = colecao.ProdutoList.Any(p => p.Id == produto.Id);

                    // Adiciona a linha ao DataGridView com o checkbox marcado/desmarcado
                    dgvProdutos.Rows.Add(
                        selecionado,
                        produto.Id.ToString(),
                        produto.NomeProd,
                        produto.CustoProd.ToString("C"),
                        produto.ValorVendaProd.ToString("C"),
                        produto.ValorVendaPromocional.ToString("C"),
                        (produto.PercentualDesconto / 100).ToString("P", CultureInfo.CurrentCulture),                                                                                                       // Exibe como porcentagem
                        produto.DescontoPix,
                        produto.LucroUnidade.ToString("C"),
                        produto.LinkProd,
                        produto.CategoriaProd,
                        produto.GrupoProd,
                        produto.DescricaoProd,
                        string.Join(", ", produto.TagsProd ?? new List<string>()) // Concatena as tags em uma string
                    );
                    ProdutoControl_OnStatusChanged($"Carregado com sucesso!");
                    AtualizaBarraProgresso?.Invoke();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados do arquivo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProdutos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvProdutos.Columns[e.ColumnIndex].Name == "select")
            {
                // Obtém o ID do produto selecionado
                var produtoId = Guid.Parse(dgvProdutos.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                var produtoSelecionado = produtos.FirstOrDefault(p => p.Id == produtoId);

                if (produtoSelecionado != null)
                {
                    // Verifica o estado do checkbox
                    bool selecionado = (bool)dgvProdutos.Rows[e.RowIndex].Cells["select"].Value;

                    if (selecionado)
                    {
                        colecao.AdicionarProdutoCatalogo(produtoSelecionado);
                    }
                    else
                    {
                        colecao.RemoverProdutoCatalogo(produtoSelecionado);
                    }
                    txtQtdProdutos.Text = colecao.ProdutoCount.ToString();
                    // Atualiza os valores de custo e lucro médio
                    txtCustoMedio.Text = colecao.CalcularCustoMedio().ToString("N2");
                    txtLucroMedio.Text = colecao.CalcularLucroMedio().ToString("N2");
                }
            }
        }
        private void ProdutoControl_OnStatusChanged(string statusMessage)
        {
            // Dispara o evento para atualizar o FrmPrincipal
            OnStatusChanged?.Invoke(statusMessage);
        }
        private void FrmCatalogoProdServ_Load(object sender, EventArgs e)
        {
            if (_novo)
            {
                AtualizaGrid();
                return;
            }
            if (!IsUpdate)
            {
                _ = AcionarNavegadorAsync();
            }
        }

        private async Task AcionarNavegadorAsync(Colecao item = null)
        {
            var itens = await _colecoesService.ListarColecaoAsync();
            if (itens != null && itens.Count > 0)
            {
                navegador = new(itens);
                if (item != null)
                {
                    navegador.SelecionarItem(item);
                }
                colecao = navegador.ItemAtual;
                _ = AtribuirColecaoAsync();
            }
            else
            {
                _novo = true;
                AtualizaGrid();
                HabitaDesabilitaCampos();
                txtNomeCatalogo.Focus();
            }
        }

        private void dgvProdutos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            AbrirProdutoSelecionado();
        }

        private void AbrirProdutoSelecionado()
        {
            if (dgvProdutos.CurrentRow != null)
            {
                var selectedProd = new Produto
                {
                    Id = Guid.Parse(dgvProdutos.CurrentRow.Cells["id"].Value.ToString()),
                    NomeProd = dgvProdutos.CurrentRow.Cells["prodNome"].Value.ToString(),
                    CustoProd = decimal.Parse(dgvProdutos.CurrentRow.Cells["custoProd"].Value.ToString(), NumberStyles.Currency),
                    ValorVendaProd = decimal.Parse(dgvProdutos.CurrentRow.Cells["vrVendaProd"].Value.ToString(), NumberStyles.Currency),
                    ValorVendaPromocional = decimal.Parse(dgvProdutos.CurrentRow.Cells["vrPromo"].Value.ToString(), NumberStyles.Currency),
                    PercentualDesconto = decimal.Parse(dgvProdutos.CurrentRow.Cells["pDesconto"].Value.ToString().Replace("%", "")),
                    DescontoPix = (bool)dgvProdutos.CurrentRow.Cells["pix"].Value,
                    LucroUnidade = decimal.Parse(dgvProdutos.CurrentRow.Cells["vrLucro"].Value.ToString(), NumberStyles.Currency),
                    LinkProd = dgvProdutos.CurrentRow.Cells["linkProd"].Value.ToString(),
                    CategoriaProd = dgvProdutos.CurrentRow.Cells["catProd"].Value.ToString(),
                    GrupoProd = dgvProdutos.CurrentRow.Cells["grupoProd"].Value.ToString(),
                    DescricaoProd = dgvProdutos.CurrentRow.Cells["descricao"].Value.ToString(),
                    TagsProd = dgvProdutos.CurrentRow.Cells["tags"].Value.ToString().Split(new[] { ", " }, StringSplitOptions.None).ToList()
                };
                splitContainer1.Panel1Collapsed = false;

                FrmProduto frm = new(selectedProd, true);
                frm.utils = this.utils;
                frm.FormClosed += (s, args) => AtualizaGrid(); // Associa a atualização ao evento de fechamento
                frm.ShowDialog();
            }
        }
        private bool isRefresh = false;
        private void FrmCatalogoProdServ_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.R)
                {
                    e.SuppressKeyPress = true;
                    isRefresh = true;
                    //splitContainer1.Panel1Collapsed = true;
                    AtualizaGrid();
                }
                if (e.KeyCode == Keys.Right) // Ctrl + Seta Direita
                {
                    btnProximo.PerformClick();
                    e.Handled = true; // Marca o evento como tratado
                }
                else if (e.KeyCode == Keys.Left) // Ctrl + Seta Esquerda
                {
                    btnAnterior.PerformClick();
                    e.Handled = true; // Marca o evento como tratado
                }
            }
        }
        private async void salvarToolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                // Exibe o status inicial de salvamento
                ProdutoControl_OnStatusChanged("Salvando o Coleção...");

                ParseCatalogo();

                if (colecao.Id == 0)
                {
                    // Adiciona um novo Coleção
                    await _colecoesService.AdicionarColecao(colecao);
                    ProdutoControl_OnStatusChanged($"Coleção '{colecao.Nome}' adicionado com sucesso.");
                }
                else
                {
                    // Atualiza um Coleção existente
                    await _colecoesService.AtualizarColecaoAsync(colecao);
                    ProdutoControl_OnStatusChanged($"Coleção '{colecao.Nome}' atualizado com sucesso.");
                }
                produtos = new();
                if (_novo)
                {
                    // Limpa o formulário após a operação
                    btnLimpar.PerformClick();
                }
                else
                {
                    var item = navegador.ItemAtual;
                    _ = AcionarNavegadorAsync(item);
                }
            }
            catch (Exception ex)
            {
                // Atualiza o status com a mensagem de erro
                ProdutoControl_OnStatusChanged($"Erro ao salvar o Coleção: {ex.Message}");
            }
        }


        private void ParseCatalogo()
        {
            colecao.Nome = txtNomeCatalogo.Text;
            colecao.Descricao = txtDescricao.Text;
            colecao.AtivoInativo = chkAtivoInativo.Checked;
            colecao.PublicoAlvo = publicoAlvo;
            colecao.CustoMedio = Convert.ToDecimal(txtCustoMedio.Text);
            colecao.LucroMedio = Convert.ToDecimal(txtLucroMedio.Text);
            colecao.ProdutoCount = Convert.ToInt32(txtQtdProdutos.Text);
            colecao.DataCriacao = Convert.ToDateTime(dtCriacao.Text);
            colecao.DataAtualizacao = DateTime.Now;
            //colecao.ProdutoList = produtos;
        }

        private void dgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se a célula clicada é a coluna de link
            if (e.RowIndex >= 0 && dgvProdutos.Columns[e.ColumnIndex].Name == "linkProd")
            {
                // Obtém o valor do link na célula
                string linkProd = dgvProdutos.Rows[e.RowIndex].Cells["linkProd"].Value.ToString();

                // Verifica se o link não está vazio ou nulo
                if (!string.IsNullOrEmpty(linkProd))
                {
                    // Abre o link em uma nova janela com o WebView2
                    FrmWeb frmWebView = new FrmWeb(linkProd);
                    frmWebView.Show();
                }
                else
                {
                    MessageBox.Show("Link do produto não está disponível.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private async void ObterProdAsync()
        {
            prodSelec = new();
            prodSelec = await _produtoService.ObterProdutoPorIdAsync(Guid.Parse(
                dgvProdutos.CurrentRow.Cells["id"].Value.ToString()));

        }

        private void abrirToolStripButton1_Click(object sender, EventArgs e)
        {
            CarregarCatalogoAsync();
            IsUpdate = true;
            HabitaDesabilitaCampos();
        }
        private async Task CarregarCatalogoAsync()
        {
            var _colecoes = new List<Colecao>();
            ColecaoService colecaoService = new();
            _colecoes = await colecaoService.ListarColecaoAsync();
            if (_colecoes == null || _colecoes.Count == 0)
            {
                MessageBox.Show("Não há itens a listar.");
            }
            else
            {
                using (FrmListar frm = new(_colecoes))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        // Obter o objeto selecionado
                        colecao = frm.SelectedColecao;

                        if (colecao != null)
                        {
                            _ = AtribuirColecaoAsync();
                        }
                    }
                }
            }
        }
        private async Task AtribuirColecaoAsync()
        {
            txtNomeCatalogo.Text = colecao.Nome;
            txtDescricao.Text = colecao.Descricao;
            chkAtivoInativo.Checked = colecao.AtivoInativo;
            if (colecao.PublicoAlvo != null)
            {
                txtNomePublicoAlvo.Text = colecao.PublicoAlvo.Nome;
            }
            txtCustoMedio.Text = colecao.CustoMedio.ToString("N2");
            txtLucroMedio.Text = colecao.LucroMedio.ToString("N2");
            dtCriacao.Text = colecao.DataCriacao.ToString();
            produtos = new();
            var _produtos = await _produtoService.ListarProdutoAsync();
            txtQtdProdutos.Text = colecao.ProdutoCount.ToString();
            produtos = _produtos.Where(x => x.ColecaoId == colecao.Id).ToList();
            colecao.ProdutoList.Clear();
            colecao.ProdutoList.AddRange(produtos);
            PublicoAlvoService publicoAlvoService = new();
            var pubs = await publicoAlvoService.ListarPublicoAlvoAsync();
            publicoAlvo = new();
            publicoAlvo = pubs.Where(x => x.Id == colecao.PublicoAlvoId).FirstOrDefault();
            if (publicoAlvo != null)
            {
                txtNomePublicoAlvo.Text = publicoAlvo.Nome;
            }
            else
            {
                txtNomePublicoAlvo.Text = string.Empty;
            }
            AtualizaGrid();
        }
        private void dgvProdutos_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifica se a tecla pressionada foi Delete
            if (e.KeyCode == Keys.Delete)
            {
                // Garante que há uma linha selecionada
                if (dgvProdutos.CurrentRow != null)
                {
                    // Obtém o item da linha selecionada
                    var selectedRow = dgvProdutos.CurrentRow;

                    // Exemplo: Acessar uma célula específica (por índice ou nome da coluna)
                    var produtoId = Guid.Parse(selectedRow.Cells["Id"].Value.ToString());
                    var produtoNome = selectedRow.Cells["prodNome"].Value.ToString();

                    // Exibe uma mensagem de confirmação
                    var confirmResult = MessageBox.Show(
                        $"Deseja realmente excluir o produto '{produtoNome}'?",
                        "Confirmação de Exclusão",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    // Executa a exclusão apenas se o usuário confirmar
                    if (confirmResult == DialogResult.Yes)
                    {
                        try
                        {
                            // Remove o produto de forma assíncrona
                            _ = _produtoService.RemoverProdutoAsync(produtoId);
                            AtualizaBarraProgresso?.Invoke();
                            // Atualiza o grid após a exclusão
                            AtualizaGrid();

                            // Invoca o método para atualizar o estado
                            OnStatusChanged?.Invoke("Produto excluído com sucesso.");
                            AtualizaBarraProgresso?.Invoke();
                        }
                        catch (Exception ex)
                        {
                            // Exibe mensagem de erro, se necessário
                            MessageBox.Show($"Erro ao excluir o produto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    // Impede o comportamento padrão ao pressionar Delete
                    e.Handled = true;
                }
            }
        }

        private void btnSalvarAlteracoes_Click(object sender, EventArgs e)
        {
            salvarToolStripButton1.PerformClick();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            FrmProduto frm = new(true);
            frm.utils = this.utils;
            frm.Show();
        }

        private void novaToolStripButton1_Click(object sender, EventArgs e)
        {
            FrmColecao frm = new(true);
            frm.utils = this.utils;
            frm.Show();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            // Limpa os dados atuais do DataGridView
            dgvProdutos.Rows.Clear();
            txtPesquisaCatalogo.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            txtNomePublicoAlvo.Text = string.Empty;
            txtCustoMedio.Text = "0";
            txtLucroMedio.Text = "0";
            txtQtdProdutos.Text = "0";
            chkAtivoInativo.Checked = true;
            dtCriacao.Text = DateTime.Now.ToString();
        }

        private void txtNomePublicoAlvo_TextChanged(object sender, EventArgs e)

        {
            if (!string.IsNullOrEmpty(txtNomePublicoAlvo.Text))
            {
                btnVerPublicoAlvo.Enabled = true;
                toolStripButton5.Enabled = true;
            }
            else
            {
                btnVerPublicoAlvo.Enabled = false;
                toolStripButton5.Enabled = false;
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            publicoAlvo = new();
            txtNomePublicoAlvo.Text = string.Empty;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            _ = CarregarPublicoAlvoAsync();
        }

        private async Task CarregarPublicoAlvoAsync()
        {
            publicoAlvo = new();
            PublicoAlvoService publicoAlvoService = new();
            var pubs = await publicoAlvoService.ListarPublicoAlvoAsync();
            if (pubs == null || pubs.Count == 0)
            {
                MessageBox.Show("Não há itens a listar.");
            }
            else
            {
                using (FrmListar frm = new(pubs))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        // Obter o objeto selecionado
                        publicoAlvo = frm.SelectedPublicoAlvo;

                        if (publicoAlvo != null)
                        {
                            txtNomePublicoAlvo.Text = publicoAlvo.Nome.ToString();
                        }
                    }
                }
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            FrmPublicoAlvo frm = new(true);
            frm.utils = this.utils;
            frm.Show();
        }

        private void btnBuscarPublicoAlvo_Click(object sender, EventArgs e)
        {
            FrmPublicoAlvo frm = new(publicoAlvo, true);
            frm.utils = this.utils;
            frm.Show();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            AbrirProdutoSelecionado();
        }

        private void btnListarProdutos_Click(object sender, EventArgs e)
        {
            CarregarTodosProdutosAsync();
        }

        private async Task CarregarTodosProdutosAsync()
        {
            var _produtos = await _produtoService.ListarProdutoAsync();
            // Filtra os produtos que não estão selecionados
            produtos.AddRange(_produtos.Where(p => !colecao.ProdutoList.Any(c => c.Id == p.Id)).ToList());
            AtualizaGrid();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            ExcluirItem();
        }

        private async void ExcluirItem()
        {
            // Exibe uma mensagem de confirmação
            var confirmResult = MessageBox.Show(
                "Tem certeza de que deseja excluir este item?",
                "Confirmação de Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    ColecaoService colecaoService = new();
                    await colecaoService.RemoverColecaoAsync(colecao.Id);

                    // Atualiza o status após a exclusão bem-sucedida
                    ProdutoControl_OnStatusChanged($"O item '{colecao.Nome}' foi excluído com sucesso.");
                    btnLimpar.PerformClick();
                }
                catch (Exception ex)
                {
                    // Caso ocorra um erro, atualiza o status com a mensagem de erro
                    ProdutoControl_OnStatusChanged($"Erro ao excluir o item: {ex.Message}");
                }
            }
            else
            {
                // Caso o usuário cancele, atualiza o status com a mensagem de cancelamento
                ProdutoControl_OnStatusChanged("Exclusão cancelada pelo usuário.");
            }
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            if (navegador.TemProximo()) // Verifica se há próximo item
            {
                navegador.Proximo(); // Move para o próximo item
                colecao = navegador.ItemAtual; // Atualiza o objeto catalogo
                _ = AtribuirColecaoAsync(); // Reatribui os dados do Coleção à interface
            }
            HabitaDesabilitaNavegacao();

        }

        private void HabitaDesabilitaNavegacao()
        {
            btnProximo.Enabled = navegador.TemProximo();
            btnAnterior.Enabled = navegador.TemAnterior();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (navegador.TemAnterior()) // Verifica se há item anterior
            {
                navegador.Anterior(); // Move para o item anterior
                colecao = navegador.ItemAtual; // Atualiza o objeto catalogo
                _ = AtribuirColecaoAsync(); // Reatribui os dados do Coleção à interface
            }
            HabitaDesabilitaNavegacao();
        }

        private void txtPesquisaCatalogo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                abrirToolStripButton1.PerformClick();
            }
        }

        private async void txtPesquisaCatalogo_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPesquisaCatalogo.Text))
            {
                colecao = new();
                ColecaoService colecaoService = new();
                var cat = await colecaoService.ObterColecaoPorNomeAsync(txtPesquisaCatalogo.Text);
                colecao = cat;
                _ = AtribuirColecaoAsync();
            }
        }

        private void dgvProdutos_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            colecao.CalcularQtdProdutos();
        }

        private void FrmColecao_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.ShowIcon = false;
            }
            else
            {
                this.ShowIcon = true;
            }
        }
    }
}
