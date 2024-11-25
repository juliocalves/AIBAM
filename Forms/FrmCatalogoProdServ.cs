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
    public partial class FrmCatalogoProdServ : Form
    {
        public event Action<string> OnStatusUpdate;
        private string filePath;
        private Catalogo catalogo;
        private List<Catalogo> catalogos;
        private Produto prodSelec;
        private List<Produto> produtos;
        private CatalogoService _catalogoService;
        private ProdutoService _produtoService;
        private PublicoAlvo publicoAlvo;
        private Navegador<Catalogo> navegador;
        private bool IsUpdate = false;
        public FrmCatalogoProdServ()
        {
            InitializeComponent();
            catalogo = new();
            produtos = new();
            _catalogoService = new();
            _produtoService = new();
            HabitaDesabilitaCampos();
        }
        private bool _novo;
        public FrmCatalogoProdServ(bool Novo)
        {
            InitializeComponent();
            _novo = Novo;
            HabitaDesabilitaCampos();
            catalogo = new();
            produtos = new();
            _catalogoService = new();
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
                ProdutoControl_OnStatusChanged($"Carregando dados ...");
                // Atualiza a lista geral apenas se ainda não tiver sido carregada
                if (produtos.Count == 0)
                {
                    produtos = await _produtoService.ListarProdutoAsync();
                }

                // Limpa os dados atuais do DataGridView
                dgvProdutos.Rows.Clear();

                // Adiciona cada produto ao DataGridView
                foreach (var produto in produtos)
                {
                    // Verifica se o produto já foi selecionado no catálogo
                    bool selecionado = catalogo.ProdutoList.Any(p => p.Id == produto.Id);

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
                        catalogo.AdicionarProdutoCatalogo(produtoSelecionado);
                    }
                    else
                    {
                        catalogo.RemoverProdutoCatalogo(produtoSelecionado);
                    }
                    txtQtdProdutos.Text = catalogo.ProdutoCount.ToString();
                    // Atualiza os valores de custo e lucro médio
                    txtCustoMedio.Text = catalogo.CalcularCustoMedio().ToString("N2");
                    txtLucroMedio.Text = catalogo.CalcularLucroMedio().ToString("N2");
                }
            }
        }
        private void ProdutoControl_OnStatusChanged(string statusMessage)
        {
            // Dispara o evento para atualizar o FrmPrincipal
            OnStatusUpdate?.Invoke(statusMessage);
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

        private async Task AcionarNavegadorAsync()
        {
            var itens = await _catalogoService.ListarCatalogoAsync();
            navegador = new(itens);
            catalogo = navegador.ItemAtual;
            _ = AtribuirCatalogoAsync();
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
                frm.FormClosed += (s, args) => AtualizaGrid(); // Associa a atualização ao evento de fechamento
                frm.ShowDialog();
            }
        }

        private void FrmCatalogoProdServ_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.R)
            {
                e.SuppressKeyPress = true;
                //splitContainer1.Panel1Collapsed = true;
                AtualizaGrid();

            }
        }
        private async void salvarToolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                // Exibe o status inicial de salvamento
                ProdutoControl_OnStatusChanged("Salvando o catálogo...");

                ParseCatalogo();

                if (catalogo.Id == 0)
                {
                    // Adiciona um novo catálogo
                    await _catalogoService.AdicionarCatalogo(catalogo);
                    ProdutoControl_OnStatusChanged($"Catálogo '{catalogo.Nome}' adicionado com sucesso.");
                }
                else
                {
                    // Atualiza um catálogo existente
                    await _catalogoService.AtualizarCatalogoAsync(catalogo);
                    ProdutoControl_OnStatusChanged($"Catálogo '{catalogo.Nome}' atualizado com sucesso.");
                }
                produtos = new();
                // Limpa o formulário após a operação
                btnLimpar.PerformClick();
            }
            catch (Exception ex)
            {
                // Atualiza o status com a mensagem de erro
                ProdutoControl_OnStatusChanged($"Erro ao salvar o catálogo: {ex.Message}");
            }
        }


        private void ParseCatalogo()
        {
            catalogo.Nome = txtNomeCatalogo.Text;
            catalogo.Descricao = txtDescricao.Text;
            catalogo.AtivoInativo = chkAtivoInativo.Checked;
            catalogo.PublicoAlvo = publicoAlvo;
            catalogo.CustoMedio = Convert.ToDecimal(txtCustoMedio.Text);
            catalogo.LucroMedio = Convert.ToDecimal(txtLucroMedio.Text);
            catalogo.ProdutoCount = Convert.ToInt32(txtQtdProdutos.Text);
            catalogo.DataCriacao = Convert.ToDateTime(dtCriacao.Text);
            catalogo.DataAtualizacao = DateTime.Now;
            //catalogo.ProdutoList = produtos;
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
                    FrmWebView frmWebView = new FrmWebView(linkProd);
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
            var _catalogos = new List<Catalogo>();
            CatalogoService catalogoService = new();
            _catalogos = await catalogoService.ListarCatalogoAsync();
            if (_catalogos == null || _catalogos.Count == 0)
            {
                MessageBox.Show("Não há itens a listar.");
            }
            else
            {
                using (FrmListar frm = new(_catalogos))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        // Obter o objeto selecionado
                        catalogo = frm.SelectedCatalogo;

                        if (catalogo != null)
                        {
                            AtribuirCatalogoAsync();
                        }
                    }
                }
            }
        }
        private async Task AtribuirCatalogoAsync()
        {
            txtNomeCatalogo.Text = catalogo.Nome;
            txtDescricao.Text = catalogo.Descricao;
            chkAtivoInativo.Checked = catalogo.AtivoInativo;
            if (catalogo.PublicoAlvo != null)
            {
                txtNomePublicoAlvo.Text = catalogo.PublicoAlvo.Nome;
            }
            txtCustoMedio.Text = catalogo.CustoMedio.ToString("N2");
            txtLucroMedio.Text = catalogo.LucroMedio.ToString("N2");
            txtQtdProdutos.Text = catalogo.ProdutoCount.ToString();
            dtCriacao.Text = catalogo.DataCriacao.ToString();
            produtos = new();
            var _produtos = await _produtoService.ListarProdutoAsync();
            produtos = _produtos.Where(x => x.CatalotoId == catalogo.Id).ToList();
            catalogo.ProdutoList.AddRange(produtos);
            PublicoAlvoService publicoAlvoService = new();
            var pubs = await publicoAlvoService.ListarPublicoAlvoAsync();
            publicoAlvo = new();
            publicoAlvo = pubs.Where(x => x.Id == catalogo.PublicoAlvoId).FirstOrDefault();
            txtNomePublicoAlvo.Text = publicoAlvo.Nome;
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

                            // Atualiza o grid após a exclusão
                            AtualizaGrid();

                            // Invoca o método para atualizar o estado
                            OnStatusUpdate("Produto excluído com sucesso.");
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
            FrmProduto frm = new();
            frm.Show();
        }

        private void novaToolStripButton1_Click(object sender, EventArgs e)
        {
            FrmCatalogoProdServ frm = new(true);
            frm.Show();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            // Limpa os dados atuais do DataGridView
            dgvProdutos.Rows.Clear();
            txtPesquisaCatalogo.Text = string.Empty;
            txtNomeCatalogo.Text = string.Empty;
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
            frm.Show();
        }

        private void btnBuscarPublicoAlvo_Click(object sender, EventArgs e)
        {
            FrmPublicoAlvo frm = new(publicoAlvo, true);
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
            produtos.AddRange(_produtos.Where(p => !catalogo.ProdutoList.Any(c => c.Id == p.Id)).ToList());
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
                    CatalogoService catalogoService = new();
                    await catalogoService.RemoverCatalogoAsync(catalogo.Id);

                    // Atualiza o status após a exclusão bem-sucedida
                    ProdutoControl_OnStatusChanged($"O item '{catalogo.Nome}' foi excluído com sucesso.");
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
                catalogo = navegador.ItemAtual; // Atualiza o objeto catalogo
                _ = AtribuirCatalogoAsync(); // Reatribui os dados do catálogo à interface
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
                catalogo = navegador.ItemAtual; // Atualiza o objeto catalogo
                _ = AtribuirCatalogoAsync(); // Reatribui os dados do catálogo à interface
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
                catalogo = new();
                CatalogoService catalogoService = new();
                var cat = await catalogoService.ObterCatalogoPorNomeAsync(txtPesquisaCatalogo.Text);
                catalogo = cat;
                _= AtribuirCatalogoAsync();
            }
        }
    }
}
