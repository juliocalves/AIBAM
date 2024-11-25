using AIBAM.Classes;
using AIBAM.Classes.Servicos;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIBAM.Forms
{
    public partial class FrmProduto : Form
    {
        #region PROPRIEDADES
        internal List<Produto> produtos;
        private Produto produto;
        private ProdutoService produtoService;
        private Utils util;
        public event Action<string> OnStatusChanged;
        private Navegador<Produto> navegador;
        #endregion
        public FrmProduto()
        {
            InitializeComponent();
            AdicionarNavegador();
        }
        private bool novoItem;
        public FrmProduto(bool NovoItem)
        {
            InitializeComponent();
            novoItem = NovoItem;
            ConfigurarControles();
        }
        public FrmProduto(Produto produto)
        {
            InitializeComponent();
            produtoControl1.SetProd(produto);
        }
        public FrmProduto(Produto produto, bool verApenas)
        {
            InitializeComponent();
            _verApenas = verApenas;
            produtoControl1.SetProd(produto);
            ConfigurarControles();
        }
        private async void AdicionarNavegador()
        {
            produtoService = new ProdutoService();
            var itens = await produtoService.ListarProdutoAsync();
            navegador = new(itens);
            produto = new();
            produto = navegador.ItemAtual;
            produtoControl1.SetProd(navegador.ItemAtual);
        }
        private bool _verApenas;

        private void ConfigurarControles()
        {
            if (_verApenas)
            {
                textBox1.Visible = false;
                label1.Visible = false;
                btnAnterior.Visible = false;
                btnExcluir.Visible = false;
                btnProximo.Visible = false;
                btnSalvarAlteracoes.Visible = false;
                toolStrip4.Visible = false;
                this.Size = new System.Drawing.Size(995, 300);
                groupBox1.Dock = DockStyle.Fill;
                produtoControl1.DesabilitaAcoes();
            }else if (novoItem)
            {
                textBox1.Visible = false;
                label1.Visible = false;
                btnAnterior.Visible = false;
                btnExcluir.Visible = false;
                btnProximo.Visible = false;
                btnSalvarAlteracoes.Visible = false;
                toolStrip4.Visible = false;
                this.Size = new System.Drawing.Size(995, 300);
                groupBox1.Dock = DockStyle.Fill;
            }
        }


        private void FrmProduto_Load(object sender, EventArgs e)
        {
            util = new Utils(message => OnStatusChanged?.Invoke(message));
        }
        private void novaToolStripButton1_Click(object sender, EventArgs e)
        {
            FrmProduto frm = new(true);
            frm.Show();
        }

        private void abrirToolStripButton1_Click(object sender, EventArgs e)
        {
            CarregarProdutos();
        }

        private async void CarregarProdutos()
        {
            produtos = new();
            ProdutoService produtoService = new();
            produtos = await produtoService.ListarProdutoAsync();
            if (produtos == null || produtos.Count == 0)
            {
                MessageBox.Show("Não há itens a listar.");
            }
            else
            {
                using (FrmListar frm = new(produtos))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        // Obter o objeto selecionado
                        Produto prod = frm.SelectedProduto;

                        if (prod != null)
                        {
                            produtoControl1.SetProd(prod);
                        }
                    }
                }
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                CarregarProdutos();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            _ = BuscarProdutoPorNomeAsync();
        }

        private async Task BuscarProdutoPorNomeAsync()
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                produto = new();
                ProdutoService produtoService = new();
                var prod = await produtoService.ObterProdutoPorNomeAsync(textBox1.Text);
                if (prod != null)
                {
                    produto = prod;
                    produtoControl1.SetProd(produto);
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            produtoControl1.ParseProduto();
            // Exibe uma mensagem de confirmação
            var confirmResult = MessageBox.Show(
                $"Deseja realmente excluir o produto '{produtoControl1.prod.NomeProd}'?",
                "Confirmação de Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            // Executa a exclusão apenas se o usuário confirmar
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    ProdutoService _produtoService = new();
                    // Remove o produto de forma assíncrona
                    _ = _produtoService.RemoverProdutoAsync(produtoControl1.prod.Id);


                    // Invoca o método para atualizar o estado
                    OnStatusChanged?.Invoke("Produto excluído com sucesso.");
                }
                catch (Exception ex)
                {
                    // Exibe mensagem de erro, se necessário
                    MessageBox.Show($"Erro ao excluir o produto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnSalvarAlteracoes_Click(object sender, EventArgs e)
        {
            produtoControl1.ParseProduto();
            // Exibe uma mensagem de confirmação
            var confirmResult = MessageBox.Show(
                $"Deseja realmente alterar o produto '{produtoControl1.prod.NomeProd}'?",
                "Confirmação de Alteração",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            // Executa a exclusão apenas se o usuário confirmar
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    produtoControl1.Salvar();
                    this.Close();
                }
                catch (Exception ex)
                {
                    // Exibe mensagem de erro, se necessário
                    MessageBox.Show($"Erro ao alterar o produto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnProximo_Click(object sender, EventArgs e)
        {
            if (navegador.TemProximo())
            {
                navegador.Proximo();
                produto = navegador.ItemAtual;
                produtoControl1.SetProd(navegador.ItemAtual);
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
            if (navegador.TemAnterior())
            {
                navegador.Anterior();
                produto = navegador.ItemAtual;
                produtoControl1.SetProd(navegador.ItemAtual);
            }
            HabitaDesabilitaNavegacao();
        }

        private void FrmProduto_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifica se a tecla Ctrl está pressionada
            if (e.Control)
            {
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

    }
}

