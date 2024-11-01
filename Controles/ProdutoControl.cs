using AIBAM.Classes;

using System;
using System.Windows.Forms;

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


        public ProdutoControl()
        {
            InitializeComponent();
            prod = new Produto();
            util = new Utils(message => OnStatusChanged?.Invoke(message));
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
            ParseProduto();
            if (!isUpdate)
            {
                util.SaveDataSetToJson(prod, "PRODUTOS");

                // Atualiza o status após salvar
                OnStatusChanged?.Invoke("Produto salvo com sucesso!");
            }
            else
            {
                util.EditItemInJson(Path.Combine("DATASETS","PRODUTOS.json"), prod.Id,prod );
                // Atualiza o status após salvar
                isUpdate = false;
            }
            btnLimpar.PerformClick();

        }

        private void btnLimpar_Click(object sender, EventArgs e)
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
            ApenasDecimal(sender, e);
        }
        private void txtVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            ApenasDecimal(sender, e);

        }
        private void txtVrPromo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ApenasDecimal(sender, e);
        }

        private void ApenasDecimal(object sender, KeyPressEventArgs e)
        {
            // Verifica se o caractere digitado é um número, vírgula ou tecla de controle (como backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                // Se não for, cancela o evento, impedindo o caractere de ser inserido
                e.Handled = true;
            }

            // Evita a inserção de mais de uma vírgula
            TextBox txtBox = sender as TextBox;
            if (e.KeyChar == ',' && txtBox.Text.Contains(","))
            {
                e.Handled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!isSetItem)
            {
                prod.DescontoPix = checkBox1.Checked;
                prod.AplicarDescontoPix();
                AtualizarValores();
            }
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

                    OnStatusChanged?.Invoke("Data loaded successfully.");
                }
                catch (Exception ex)
                {
                    OnStatusChanged?.Invoke($"Error loading data: {ex.Message}");
                }
            }
            else
            {
                OnStatusChanged?.Invoke("File not found.");
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

                    OnStatusChanged?.Invoke("Group name saved successfully.");
                }
                catch (Exception ex)
                {
                    OnStatusChanged?.Invoke($"Error saving group name: {ex.Message}");
                }

            }
        }

        private void ProdutoControl_Load(object sender, EventArgs e)
        {
            CarregarDadosComboBox();
        }

        
    }
}
