using System;
using System.Globalization;
using System.Windows.Forms;

using AIBAM.Classes;
using AIBAM.Controles;
using Newtonsoft.Json;

namespace AIBAM
{
    public partial class FrmCatalogoProdServ : Form
    {
        public event Action<string> OnStatusUpdate;
        private string filePath;

        public FrmCatalogoProdServ()
        {
            InitializeComponent();
            // Assumindo que produtoControl é uma instância de ProdutoControl no formulário
            produtoControl1.OnStatusChanged += ProdutoControl_OnStatusChanged;
        }

        private void ProdutoControl_OnStatusChanged(string statusMessage)
        {
            // Dispara o evento para atualizar o FrmPrincipal
            OnStatusUpdate?.Invoke(statusMessage);
        }

        private void FrmCatalogoProdServ_Load(object sender, EventArgs e)
        {
            // Define o caminho do arquivo JSON
            string directoryPath = Path.Combine(Settings.Default.DiretorioRaiz, "DATASETS");
            filePath = Path.Combine(directoryPath, "PRODUTOS.json");
            AtualizaGrid();
        }

        private void AtualizaGrid()
        {
            if (File.Exists(filePath))
            {
                try
                {
                    // Lê o conteúdo do arquivo JSON
                    string json = File.ReadAllText(filePath);

                    // Desserializa o JSON em uma lista de objetos Produto
                    List<Produto> produtos = JsonConvert.DeserializeObject<List<Produto>>(json);

                    // Limpa os dados atuais do DataGridView
                    dgvProdutos.Rows.Clear();

                    // Adiciona cada produto à DataGridView
                    foreach (var produto in produtos)
                    {
                        dgvProdutos.Rows.Add(
                            false, // Valor padrão para a coluna "select" (checkbox)
                            produto.Id.ToString(),
                            produto.NomeProd,
                            produto.CustoProd.ToString("C"),
                            produto.ValorVendaProd.ToString("C"),
                            produto.ValorVendaPromocional.ToString("C"),
                            produto.PercentualDesconto.ToString("C"), // Exibe como porcentagem
                            produto.DescontoPix,
                            produto.LucroUnidade.ToString("C"),
                            produto.LinkProd,
                            produto.CategoriaProd,
                            produto.GrupoProd,
                            produto.DescricaoProd,
                            string.Join(", ", produto.TagsProd ?? new List<string>()) // Concatena as tags em uma string
                        );
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar dados do arquivo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Arquivo de dados PRODUTOS.json não encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvProdutos_MouseDoubleClick(object sender, MouseEventArgs e)
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
                    PercentualDesconto = decimal.Parse(dgvProdutos.CurrentRow.Cells["pDesconto"].Value.ToString(), NumberStyles.Currency),
                    DescontoPix = (bool)dgvProdutos.CurrentRow.Cells["pix"].Value,
                    LucroUnidade = decimal.Parse(dgvProdutos.CurrentRow.Cells["vrLucro"].Value.ToString(), NumberStyles.Currency),
                    LinkProd = dgvProdutos.CurrentRow.Cells["linkProd"].Value.ToString(),
                    CategoriaProd = dgvProdutos.CurrentRow.Cells["catProd"].Value.ToString(),
                    GrupoProd = dgvProdutos.CurrentRow.Cells["grupoProd"].Value.ToString(),
                    DescricaoProd = dgvProdutos.CurrentRow.Cells["descricao"].Value.ToString(),
                    TagsProd = dgvProdutos.CurrentRow.Cells["tags"].Value.ToString().Split(new[] { ", " }, StringSplitOptions.None).ToList()
                };

                // Chama o método para preencher os dados no controle de produto
                produtoControl1.SetProd(selectedProd);
            }
        }

       

        private void FrmCatalogoProdServ_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.R)
            {
                e.SuppressKeyPress = true;
                AtualizaGrid();
            }
        }
    }
}
