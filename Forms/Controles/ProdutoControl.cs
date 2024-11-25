using AIBAM.Classes;
using AIBAM.Forms;
using System.ComponentModel;

namespace AIBAM.Controles
{
    public partial class ProdutoControl : UserControl
    {
        internal Produto prod;
        private Utils util;
        internal bool isUpdate = false;
        private bool isSetItem = false;

        // Delegado para atualizar o status no Form principal
        public event Action<string> OnStatusChanged;
        // private readonly ProdutoService _produtoService;

        public ProdutoControl()
        {

            //  _produtoService = new();
            InitializeComponent();
            prod = new Produto();
            util = new Utils(message => OnStatusChanged?.Invoke(message));
        }
        private void ProdutoControl_Load(object sender, EventArgs e)
        {
            CarregarDadosComboBox();
        }
        public Produto ParseProduto()
        {
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
            return prod;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }
        public void DesabilitaAcoes()
        {
            toolStrip4.Enabled = false;
            adicionarListaControl1.DesabilitaAcoes();
        }

        public void Salvar()
        {
            ParseProduto();
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            prod.DescontoPix = checkBox1.Checked;
            prod.AplicarDescontoPix();
            AtualizarValores();
        }

        private void AtualizarValores()
        {
            prod.CalcularDescontoELucro();
            txtDesc.Text = prod.PercentualDesconto.ToString("N2");
            txtLuc.Text = prod.LucroUnidade.ToString("N2");
            txtVrPromo.Text = prod.ValorVendaPromocional.ToString("N2");
        }

        private void txtCusto_Leave(object sender, EventArgs e)
        {
            prod.CustoProd = !String.IsNullOrEmpty(txtCusto.Text) ?
                Convert.ToDecimal(txtCusto.Text) : 0;
            txtCusto.Text = prod.CustoProd.ToString("N2");
            AtualizarValores();
        }

        private void txtVenda_Leave(object sender, EventArgs e)
        {
            prod.ValorVendaProd = !String.IsNullOrEmpty(txtVenda.Text) ?
                Convert.ToDecimal(txtVenda.Text) : 0;
            txtVenda.Text = prod.ValorVendaProd.ToString("N2");
            AtualizarValores();
        }

        private void txtVrPromo_Leave(object sender, EventArgs e)
        {
            prod.ValorVendaPromocional = !String.IsNullOrEmpty(txtVrPromo.Text) ?
                Convert.ToDecimal(txtVrPromo.Text) : 0;
            AtualizarValores();
        }
        public void SetProd(Produto _prod)
        {
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
            isUpdate = true;
            isSetItem = false;
            ParseProduto();
        }
        private void CarregarDadosComboBox()
        {
            string filePath = Path.Combine(Settings.Default.DiretorioRaiz, "DATASETS/GRUPOPRODUTO.txt");

            if (File.Exists(filePath))
            {
                try
                {
                    // Clear existing items in ComboBox
                    cboGrupoProd.Items.Clear();

                    // Read each line from the file and add it to the ComboBox
                    foreach (string line in File.ReadLines(filePath))
                    {
                        cboGrupoProd.Items.Add(line.Trim());
                    }

                    OnStatusChanged?.Invoke("Dados carregados com sucesso.");
                }
                catch (Exception ex)
                {
                    OnStatusChanged?.Invoke($"Erro ao carregar dados: {ex.Message}");
                }
            }
            else
            {
                OnStatusChanged?.Invoke("Arquivo não encontrado.");
            }
        }


        private void cboGrupoProd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string groupName = cboGrupoProd.Text;
                string filePath = Path.Combine(Settings.Default.DiretorioRaiz, "DATASETS/GRUPOPRODUTO.txt");

                try
                {
                    // Check if file exists; if not, create it, then append the group name.
                    using (StreamWriter writer = new StreamWriter(filePath, true))
                    {
                        writer.WriteLine(groupName);
                    }

                    OnStatusChanged?.Invoke("Nome de grupo salvo com sucesso!.");
                }
                catch (Exception ex)
                {
                    OnStatusChanged?.Invoke($"Erro ao salvar nome de grupo: {ex.Message}");
                }

            }
        }

        private void txtLinkProd_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLinkProd.Text))
            {
                // Abre o link em uma nova janela com o WebView2
                FrmWebView frmWebView = new FrmWebView(txtLinkProd.Text);
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

    }
}
