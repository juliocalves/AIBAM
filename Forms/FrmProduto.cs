using AIBAM.Classes;
using AIBAM.Classes.Servicos;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AIBAM.Forms
{
    public partial class FrmProduto : Form
    {
        #region PROPRIEDADES
        internal List<Produto> produtos;
        private Produto produto;
        private ProdutoService produtoService;
        public Utils utils;
        public event Action<string> OnStatusChanged;
        public event Action AtualizaBarraProgresso;
        private Navegador<Produto> navegador;
        #endregion
        public FrmProduto()
        {
            InitializeComponent();
            AdicionarNavegador();
            produtoControl1.DesabilitaAcoes();
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
            itens = itens.OrderBy(p => p.NomeProd).ToList();
            navegador = new(itens);
            produto = new();
            produto = navegador.ItemAtual;
            CarregarImagem();
            produtoControl1.SetProd(navegador.ItemAtual);
            textBox2.Text = (navegador._indiceAtual + 1).ToString();
            textBox3.Text = navegador._itens.Count.ToString();
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
                this.Size = new System.Drawing.Size(this.Width, 300);
                groupBox1.Dock = DockStyle.Fill;
                produtoControl1.DesabilitaAcoes();
                splitContainer1.Panel1Collapsed = true;
                splitContainer2.Panel2Collapsed = true;
                btnSugestaoDescricao.Enabled = false;
                btnSugestaoTags.Enabled = false;

            }
            else if (novoItem)
            {
                splitContainer1.Panel1Collapsed = true;
                splitContainer2.Panel2Collapsed = true;
                textBox1.Visible = false;
                label1.Visible = false;
                btnAnterior.Visible = false;
                btnExcluir.Visible = false;
                btnProximo.Visible = false;
                btnSalvarAlteracoes.Visible = false;
                toolStrip4.Visible = false;
                this.Size = new System.Drawing.Size(this.Width, 300);
                groupBox1.Dock = DockStyle.Fill;
            }
        }


        private void FrmProduto_Load(object sender, EventArgs e)
        {
            produtoControl1.util = this.utils;
            produtoControl1.AtualizaBarraProgresso += this.AtualizaBarraProgresso;
            produtoControl1.OnStatusChanged += this.OnStatusChanged;
        }
        private void novaToolStripButton1_Click(object sender, EventArgs e)
        {
            FrmProduto frm = new(true);
            frm.utils = this.utils;
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
            SalvarProd();
        }

        private void SalvarProd()
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
                textBox2.Text = (navegador._indiceAtual + 1).ToString();
                CarregarImagem();
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
                if (navegador._indiceAtual > 0)
                    textBox2.Text = (navegador._indiceAtual - 1).ToString();
                else
                    textBox2.Text = "1";
                CarregarImagem();
            }
            HabitaDesabilitaNavegacao();
        }

        private void FrmProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.R)
                {
                    e.SuppressKeyPress = true;
                    AtualizaNavegador();
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
                if (e.KeyCode == Keys.A)
                {
                    SalvarProd();
                    e.SuppressKeyPress = true;
                    AtualizaNavegador();
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void AtualizaNavegador()
        {

            var item = navegador.ItemAtual;
            AdicionarNavegador();
            navegador.SelecionarItem(item);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            produtoControl1.ParseProduto();
            var newprod = produtoControl1.prod;
            newprod.Id = Guid.Empty;

            ProdutoService _produtoService = new();
            _ = _produtoService.AtualizarProdutoAsync(newprod);
            AtualizaNavegador();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitaDesabilitaControlesEdicao();
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            HabilitaDesabilitaControlesEdicao();
        }

        private void HabilitaDesabilitaControlesEdicao()
        {
            produtoControl1.DesabilitaAcoes();
            textBox1.Visible = !textBox1.Visible;
            label1.Visible = !label1.Visible;
            btnAnterior.Visible = !btnAnterior.Visible;
            btnExcluir.Visible = !btnExcluir.Visible;
            btnProximo.Visible = !btnProximo.Visible;
            btnSalvarAlteracoes.Visible = !btnSalvarAlteracoes.Visible;
            btnCancelar.Visible = !btnCancelar.Visible;
            btnSugestaoDescricao.Enabled = !btnSugestaoDescricao.Enabled;
            btnSugestaoTags.Enabled = !btnSugestaoTags.Enabled;
        }

        private void FrmProduto_SizeChanged(object sender, EventArgs e)
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

        private List<Image> imagens = new List<Image>(); // Lista para armazenar as imagens
        private int indiceImagemAtual = 0; // Índice da imagem atual exibida
        private void btnAdiconarImagem_Click(object sender, EventArgs e)
        {
            // Cria um OpenFileDialog para selecionar imagens
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Selecionar Imagens";
                openFileDialog.Multiselect = true; // Permite seleção de múltiplos arquivos
                openFileDialog.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Limpa a lista de imagens (se necessário, remova esta linha)
                    imagens.Clear();

                    // Adiciona cada imagem selecionada à lista
                    foreach (string fileName in openFileDialog.FileNames)
                    {
                        try
                        {
                            Image img = Image.FromFile(fileName);
                            imagens.Add(img); // Adiciona a imagem na lista
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Erro ao carregar a imagem: {fileName}\n{ex.Message}",
                                            "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    if (produto.Imagens == null)
                        produto.Imagens = new();
                    imgPath.AddRange(openFileDialog.FileNames);
                    produto.Imagens = imgPath;
                    ProdutoService _produtoService = new();
                    _ = _produtoService.AtualizarProdutoAsync(produto);
                    // Atualiza o status após salvar
                    OnStatusChanged?.Invoke("Produto salvo com sucesso!");
                    // Define a primeira imagem da lista no PictureBox
                    if (imagens.Count > 0)
                    {
                        pictureBox1.Image = imagens[0]; // Exibe a primeira imagem
                        indiceImagemAtual = 0; // Define o índice da imagem atual
                    }
                    else
                    {
                        MessageBox.Show("Nenhuma imagem foi adicionada.",
                                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            VizualizarImagemGrande(pictureBox1.Image);
        }

        private void VizualizarImagemGrande(Image image)
        {
            // Criar um novo formulário para exibir a imagem
            Form formVisualizar = new Form
            {
                Text = "Visualizar Imagem",
                Size = new Size(800, 600), // Tamanho inicial
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen
            };

            // Adicionar PictureBox para exibir a imagem no formulário
            PictureBox pictureBoxGrande = new PictureBox
            {
                Image = image,
                SizeMode = PictureBoxSizeMode.Zoom,
                Dock = DockStyle.Fill // Preencher todo o formulário
            };

            formVisualizar.Controls.Add(pictureBoxGrande);
            formVisualizar.KeyDown += (s, ev) =>
            {
                if (ev.KeyCode == Keys.Escape)
                {
                    formVisualizar.Close();
                }
            };
            formVisualizar.KeyPreview = true;

            // Abrir o formulário como modal
            formVisualizar.ShowDialog();
        }

        // Exibe a imagem anterior na lista
        private void btnImgAnterior_Click(object sender, EventArgs e)
        {
            if (imagens.Count > 0)
            {
                // Decrementa o índice e verifica os limites
                if (indiceImagemAtual > 0)
                {
                    indiceImagemAtual--;
                }
                else
                {
                    indiceImagemAtual = imagens.Count - 1; // Volta para a última imagem
                }

                // Atualiza o PictureBox para a imagem anterior
                pictureBox1.Image = imagens[indiceImagemAtual];
            }
        }

        // Exibe a imagem próxima na lista
        private void btnImgProximo_Click(object sender, EventArgs e)
        {
            if (imagens.Count > 0)
            {
                // Incrementa o índice e verifica os limites
                if (indiceImagemAtual < imagens.Count - 1)
                {
                    indiceImagemAtual++;
                }
                else
                {
                    indiceImagemAtual = 0; // Volta para a primeira imagem
                }

                // Atualiza o PictureBox para a imagem próxima
                pictureBox1.Image = imagens[indiceImagemAtual];
            }
        }

        // Remove a imagem atual da lista
        private void btnExcluirImg_Click(object sender, EventArgs e)
        {
            if (imagens.Count > 0)
            {
                // Remove a imagem da lista
                imagens.RemoveAt(indiceImagemAtual);
                imgPath.RemoveAt(indiceImagemAtual);
                produto.Imagens = imgPath;
                ProdutoService _produtoService = new();
                _ = _produtoService.AtualizarProdutoAsync(produto);
                // Verifica se ainda há imagens na lista
                if (imagens.Count > 0)
                {
                    // Atualiza o índice e exibe a nova imagem
                    if (indiceImagemAtual >= imagens.Count)
                    {
                        indiceImagemAtual = imagens.Count - 1; // Se estiver na última imagem, volta para a anterior
                    }
                    pictureBox1.Image = imagens[indiceImagemAtual];

                    // Atualiza o status após salvar
                    OnStatusChanged?.Invoke("Produto salvo com sucesso!");
                }
                else
                {
                    // Se a lista estiver vazia, limpa o PictureBox
                    pictureBox1.Image = null;
                    MessageBox.Show("Nenhuma imagem restante.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private List<string> imgPath = new List<string>();
        private void CarregarImagem()
        {
            pictureBox1.Image = null;
            imagens = new();
            imgPath = new();
            if (produto.Imagens != null)
            {
                imgPath = produto.Imagens;
                foreach (string fileName in imgPath)
                {
                    try
                    {
                        Image img = Image.FromFile(fileName);
                        imagens.Add(img); // Adiciona a imagem na lista
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao carregar a imagem: {fileName}\n{ex.Message}",
                                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                // Define a primeira imagem da lista no PictureBox
                if (imagens.Count > 0)
                {
                    pictureBox1.Image = imagens[0]; // Exibe a primeira imagem
                    indiceImagemAtual = 0; // Define o índice da imagem atual
                }
            }
        }

        private void btnSugestaoDescricao_Click(object sender, EventArgs e)
        {
            CarregarSugestao("descricao");
        }

        private void CarregarSugestao(string tipo)
        {
            FrmSugestao frm = new();
            ConfigModeloSugestao configModelo = null;
            frm.Text = $"AIBAM | SUGESTÕES {tipo.ToUpper()}";
            frm.path = Path.Combine(Settings.Default.DiretorioRaiz, "DATASETS", $"modelo_sugestao_{tipo}.json");
            frm.prompt = GerarPrompt(tipo);
            if(produto.Imagens != null && produto.Imagens.Count > 0)
            {
                frm.imgPath = produto.Imagens.First();
            }
            switch (tipo)
            {
                case "descricao":
                    configModelo = VerificaModeloSugestao("descricao");
                    break;
                case "tags":
                    configModelo = VerificaModeloSugestao("tags");
                    break;
                default:
                    MessageBox.Show("Tipo de sugestão inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            if (configModelo != null)
            {
                frm.ConfigModelo = configModelo;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Implementar lógica para tratar o retorno do formulário
                    MessageBox.Show("Sugestão carregada com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Modelo de sugestão não encontrado ou configurado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string GerarPrompt(string tipo)
        {
            if (produto == null || string.IsNullOrEmpty(tipo))
            {
                throw new ArgumentException("Tipo ou informações do produto estão inválidas.");
            }

            return tipo.ToLower() switch
            {
                "tags" => $"Gere tags relevantes para o produto: {produto.NomeProd}.",
                "descricao" => $"Gere descrições para o produto: {produto.NomeProd}.",
                _ => throw new NotSupportedException($"Tipo de prompt '{tipo}' não é suportado."),
            };
        }


        private ConfigModeloSugestao VerificaModeloSugestao(string name)
        {
            string fileName = $"modelo_sugestao_{name}.json";
            string filePath = Path.Combine(Settings.Default.DiretorioRaiz, "DATASETS", fileName);

            if (File.Exists(filePath))
            {
                try
                {
                    string jsonContent = File.ReadAllText(filePath);
                    return JsonConvert.DeserializeObject<ConfigModeloSugestao>(jsonContent);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar o modelo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            else
            {
                FrmConfigSugestao frm = new();
                frm.utils = this.utils;
                frm.Text = $"AIBAM | COFIGURAR SUGESTÃO {name.ToUpper()}";
                frm.Tipo = name;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Salva o novo modelo configurado pelo usuário
                    ConfigModeloSugestao novoModelo = frm.ObterConfigModelo(); // Supondo que o formulário tenha um método para retornar o modelo configurado

                    try
                    {
                        string novoJson = JsonConvert.SerializeObject(novoModelo, Formatting.Indented);
                        Directory.CreateDirectory(Path.GetDirectoryName(filePath)); // Garante que o diretório existe
                        File.WriteAllText(filePath, novoJson);

                        MessageBox.Show("Modelo configurado e salvo com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return novoModelo;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao salvar o modelo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            return null;
        }


        private void btnSugestaoTags_Click(object sender, EventArgs e)
        {
            CarregarSugestao("tags");
        }

        private void btnPesquisarProdutosSimilares_Click(object sender, EventArgs e)
        {

        }
    }
}

