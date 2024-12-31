using AIBAM.Classes;
using AIBAM.Controles;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static AIBAM.Classes.Modelo;

namespace AIBAM
{
    public partial class FrmListar : Form
    {
        private List<BriefingCopy> _briefingList;
        private List<Produto> _produtos;
        private List<Colecao> _colecoes;
        private List<PublicoAlvo> _publicosAlvo;
        public BriefingCopy SelectedBriefing { get; private set; }
        public Produto SelectedProduto { get; internal set; }
        public Colecao SelectedColecao { get; internal set; }
        public PublicoAlvo SelectedPublicoAlvo { get; internal set; }
        private List<Produto> produtosSelecionados = new List<Produto>();
        string objeto = "";

        public FrmListar(List<BriefingCopy> briefingList)
        {
            InitializeComponent();
            _briefingList = briefingList;
            objeto = "BRIEFINGCOPY";
            this.Text = "AIBAM | Brienfing Copy";
        }

        public FrmListar(List<Produto> produtos)
        {
            InitializeComponent();
            _produtos = produtos;
            objeto = "PRODUTOS";
            this.Text = "AIBAM | Produtos";
        }
      
        public FrmListar(List<Colecao> colecao)
        {
            InitializeComponent();
            _colecoes = colecao;
            objeto = "COLECAO";
            this.Text = "AIBAM | Colecao";
        }
        public FrmListar(List<PublicoAlvo> publicosAlvo)
        {
            InitializeComponent();
            _publicosAlvo = publicosAlvo;
            objeto = "PUBLICO ALVO";
            this.Text = "AIBAM | Publico Alvo";
        }
        public FrmListar(string Objeto)
        {
            InitializeComponent();
            switch (Objeto)
            {

                case "PRODUTOS":
                    objeto = "PRODUTOS";
                    this.Text = "AIBAM | Lista de Produtos";
                    break;
                case "MODELOS":
                    objeto = "MODELOS";
                    this.Text = "AIBAM | Lista de Modelos";
                    break;
            }
        }

        private async Task CarregarProduto()
        {
            ProdutoService produtoService = new ProdutoService();
            _produtos = new();
            _produtos = await produtoService.ListarProdutoAsync();
            dgvView.DataSource = _produtos;
        }

        private void FrmListar_Load(object sender, EventArgs e)
        {
            dgvView.AutoGenerateColumns = true;

            // Configurar a fonte de dados
            switch (objeto)
            {
                case "BRIEFINGCOPY":
                    dgvView.DataSource = _briefingList;
                    break;
                case "PRODUTOS":
                    if (_produtos != null)
                    {
                        dgvView.DataSource = _produtos;
                    }
                    else
                    {
                        _= CarregarProduto();
                    }
                    break;
                case "COLECAO":
                    dgvView.DataSource = _colecoes;
                    break;
                case "PUBLICO ALVO":
                    dgvView.DataSource = _publicosAlvo;
                    break;
                case "MODELOS":
                    var modeloManager = new ModeloManager();
                    var modelos = modeloManager.CarregarModelos();
                    splitContainer1.Panel1Collapsed = true;
                    // Ocultar a coluna de seleção, se existir
                    dgvView.Columns["Select"].Visible = false;

                    // Converter a lista de detalhes em uma string concatenada
                    var modelosFormatados = modelos.Select(m => new
                    {
                        NomeModelo = m.NomeModelo,
                        IdentificacaoModelo = m.IdentificacaoModelo,
                        DescricaoModelo = m.DescricaoModelo,
                        DetalhesModelo = m.RegrasModelo != null
                            ? string.Join(", ", m.RegrasModelo)
                            : string.Empty
                    }).ToList();

                    dgvView.DataSource = modelosFormatados;
                    break;
            }
            

        }

        private void dgvView_MouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Verificar se há uma linha selecionada
            if (dgvView.SelectedRows.Count > 0)
            {
                int index = dgvView.SelectedRows[0].Index;
                switch (objeto)
                {
                    case "BRIEFINGCOPY":
                        SelectedBriefing = _briefingList[index]; // Retorna o item selecionado
                        break;
                    case "PRODUTOS":
                        SelectedProduto = _produtos[index];
                        break;
                    case "CATALOGO":
                        SelectedColecao = _colecoes[index];
                        break;
                    case "PUBLICO ALVO":
                        SelectedPublicoAlvo = _publicosAlvo[index];
                        break;
                }
                this.DialogResult = DialogResult.OK; // Indica que o formulário foi concluído com sucesso
                this.Close();
            }
            else
            {
                MessageBox.Show("Selecione um item antes de continuar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnCarregarFonteDados_Click(object sender, EventArgs e)
        {
            // Criar e configurar o OpenFileDialog
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Arquivos CSV (*.csv)|*.csv";
                openFileDialog.Title = "Selecione um arquivo CSV";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    try
                    {
                        // Ler o conteúdo do arquivo CSV e converter para DataTable
                        DataTable dataTable = LoadCsvToDataTable(filePath);

                        // Vincular o DataTable ao DataGridView
                        dgvView.DataSource = dataTable;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao carregar o arquivo CSV: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Carrega um arquivo CSV para um DataTable.
        /// </summary>
        /// <param name="filePath">Caminho do arquivo CSV.</param>
        /// <returns>DataTable contendo os dados do CSV.</returns>
        private DataTable LoadCsvToDataTable(string filePath)
        {
            DataTable dataTable = new DataTable();

            using (StreamReader sr = new StreamReader(filePath))
            {
                // Ler a primeira linha como cabeçalho
                string headerLine = sr.ReadLine();
                if (headerLine == null)
                    throw new Exception("O arquivo CSV está vazio.");

                // Criar colunas no DataTable a partir do cabeçalho
                string[] headers = headerLine.Split(',');
                foreach (string header in headers)
                {
                    dataTable.Columns.Add(header.Trim());
                }

                // Ler as linhas seguintes como dados
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');
                    dataTable.Rows.Add(fields.Select(field => field.Trim()).ToArray());
                }
            }

            return dataTable;
        }

        private void btnSalvarLista_Click(object sender, EventArgs e)
        {
            switch (objeto)
            {
                case "PRODUTOS":
                    break;
            }
        }


        

        // Método para salvar a lista de produtos
        private void SalvarListaProdutos(List<string> categoriasSelecionadas)
        {
            try
            {
                

                foreach (var produto in produtosSelecionados)
                {
                    foreach (var categoria in categoriasSelecionadas)
                    {
                        ProdutoService produtoService = new ProdutoService();
                        var novoProduto = produto;
                        novoProduto.Id = Guid.Empty;
                        novoProduto.CategoriaProd = categoria;

                        _ = produtoService.AdicionarProduto(novoProduto); // Salvar novo produto no banco
                    }
                }

                MessageBox.Show("Produtos atualizados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar os produtos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método disparado ao alterar a coluna "Select" do DataGridView
        private void dgvView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvView.Columns[e.ColumnIndex].Name == "Select")
            {
                bool isSelected = Convert.ToBoolean(dgvView.Rows[e.RowIndex].Cells["Select"].Value);
                var produto = (Produto)dgvView.Rows[e.RowIndex].DataBoundItem;

                if (isSelected)
                {
                    // Adicionar o produto selecionado à lista
                    if (!produtosSelecionados.Contains(produto))
                        produtosSelecionados.Add(produto);
                }
                else
                {
                    // Remover o produto da lista
                    produtosSelecionados.Remove(produto);
                }
            }
        }

        // Método para criar variantes de produtos
        private void btnCriarVariantesProduto_Click(object sender, EventArgs e)
        {
            if (produtosSelecionados.Count == 0)
            {
                MessageBox.Show("Nenhum produto selecionado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (Form formDialog = new Form())
            {
                formDialog.Text = "Criar Variantes";
                formDialog.Size = new System.Drawing.Size(400, 400);
                formDialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                formDialog.StartPosition = FormStartPosition.CenterParent;

                GroupBox groupBox = new GroupBox
                {
                    Text = "Selecione as categorias para criar variantes",
                    Dock = DockStyle.Fill
                };
                formDialog.Controls.Add(groupBox);

                CheckedListBox checkedListBox = new CheckedListBox
                {
                    Dock = DockStyle.Fill,
                    CheckOnClick = true, // Permite alternar o estado do check ao clicar no texto
                    Items =
                    {
                        "CAMISETA",
                        "CAMISETA ALGODÃO PERUANO",
                        "CAMISETA INFANTIL",
                        "CAMISETA OVERSIZED",
                        "BODY INFANTIL",
                        "CROPPED",
                        "CROPPED MOLETOM",
                        "HOODIE MOLETOM",
                        "REGATA",
                        "SUÉTER MOLETOM"
                    }
                                };
                groupBox.Controls.Add(checkedListBox);

                Button btnApply = new Button
                {
                    Text = "Aplicar",
                    Dock = DockStyle.Bottom,
                    DialogResult = DialogResult.OK
                };
                formDialog.Controls.Add(btnApply);


                if (formDialog.ShowDialog() == DialogResult.OK)
                {
                    var categoriasSelecionadas = checkedListBox.CheckedItems.Cast<string>().ToList();
                    if (categoriasSelecionadas.Count == 0)
                    {
                        MessageBox.Show("Nenhuma categoria selecionada!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    try
                    {
                        SalvarListaProdutos(categoriasSelecionadas);

                        MessageBox.Show("Variantes criadas com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao criar variantes: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
