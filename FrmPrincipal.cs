using AIBAM.Classes;
using AIBAM.Forms;
using AIBAM.Templates;

using Newtonsoft.Json;

using System.Runtime.InteropServices;
using System.Text;

using static AIBAM.Classes.Modelo;

namespace AIBAM
{
    public partial class FrmPrincipal : Form
    {
        internal Utils utils;
        private string textoPromptCopy = "";

        public FrmPrincipal()
        {
            InitializeComponent();
            utils = new(SetStatus, AtualizaBarraProgresso);
        }
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            AtualizaBarraProgresso();
            SetStatus("Carregando ferramentas...");

            SetStatus("Preparando UI...");
            CarregarMenuModelos();
            AtualizaBarraProgresso();
            SetStatus("Pronto!");
        }

        private void AtualizaBarraProgresso()
        {
            toolStripProgressBar1.Visible = !toolStripProgressBar1.Visible;
            toolStripProgressBar1.Style = toolStripProgressBar1.Style == ProgressBarStyle.Marquee ? ProgressBarStyle.Blocks : ProgressBarStyle.Marquee;
        }
        // Função para definir o status no ToolStripStatusLabel
        public void SetStatus(string message)
        {
            toolStripStatusLabel1.Text = message;
        }

        private void opçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConfiguracoes frm = new FrmConfiguracoes();
            DialogResult result = frm.ShowDialog();
            if (result == DialogResult.OK) { }
            else if (result == DialogResult.Cancel) { }
        }

        private void catalogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            utils.AbrirFormulario<FrmCatalogo>(this, frm =>
            {
                frm.OnStatusChanged += SetStatus; // Configura evento de status
                frm.AtualizaBarraProgresso += AtualizaBarraProgresso;
                frm.utils = this.utils;          // Configura a instância de utils
            });
        }
        private void publicoAlvoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            utils.AbrirFormulario<FrmPublicoAlvo>(this, frm =>
            {
                frm.OnStatusChanged += SetStatus; // Configura evento de status
                frm.AtualizaBarraProgresso += AtualizaBarraProgresso;
                frm.utils = this.utils;          // Configura a instância de utils
            });

        }

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            utils.AbrirFormulario<FrmProduto>(this, frm =>
            {
                frm.OnStatusChanged += SetStatus; // Configura evento de status
                frm.AtualizaBarraProgresso += AtualizaBarraProgresso;
                frm.utils = this.utils;          // Configura a instância de utils
            });
        }

        private void copyWriterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            utils.AbrirFormulario<FrmPromptCopy>(this, frm =>
            {
                frm.OnStatusChanged += SetStatus; // Configura evento de status
                frm.AtualizaBarraProgresso += AtualizaBarraProgresso;
                frm.utils = this.utils;          // Configura a instância de utils
            });
        }

        private void colecaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            utils.AbrirFormulario<FrmColecao>(this, frm =>
            {
                frm.OnStatusChanged += SetStatus; // Configura evento de status
                frm.AtualizaBarraProgresso += AtualizaBarraProgresso;
                frm.utils = this.utils;          // Configura a instância de utils
            });
        }
        private void novoProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProduto frm = new(true);
            frm.OnStatusChanged += SetStatus; // Configura evento de status
            frm.AtualizaBarraProgresso += AtualizaBarraProgresso;
            frm.utils = this.utils;          // Configura a instância de utils
            frm.Show();
        }

        private void webToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmWebView web = new();
            web.Show();
        }

        private void listaProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListar frm = new FrmListar("PRODUTOS");
            frm.Show();
        }

        private void novaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmModelo frm = new();
            frm.utils = this.utils;
            frm.AtualizaBarraProgresso += AtualizaBarraProgresso;
            frm.ShowDialog();
        }

        private void listaDeModelosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmListar frm = new("MODELOS");
            frm.Show();
        }

        private void exibirModelosItemAItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmModelo frm = new(true);
            frm.utils = this.utils;
            frm.AtualizaBarraProgresso += AtualizaBarraProgresso;
            frm.ShowDialog();
        }

        private void livreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChat frm = new();
            frm.utils = this.utils;
            frm.AtualizaBarraProgresso += AtualizaBarraProgresso;
            frm.Show();
        }
        private void CarregarMenuModelos()
        {
            var modeloManager = new ModeloManager();
            var modelos = modeloManager.CarregarModelos();

            // Agrupar os modelos por nome
            var modelosAgrupados = modelos
                .GroupBy(m => m.NomeModelo) // Agrupa os modelos pelo nome
                .ToDictionary(g => g.Key, g => g.ToList()); // Cria um dicionário com nome do modelo como chave e lista de modelos como valor

            // Iterando sobre cada grupo de modelos agrupados por nome
            foreach (var modeloGroup in modelosAgrupados)
            {
                // Tratar o nome do modelo (transformar em maiúsculas e substituir _ por espaço)
                string nomeModelo = modeloGroup.Key.Replace('_', ' ').Replace("modelo", "assis. ").ToUpper();

                // Criar o item de menu principal com o nome tratado
                var itemMenuModelo = new ToolStripMenuItem(nomeModelo);

                // Iterando sobre os modelos do grupo
                foreach (var modelo in modeloGroup.Value)
                {
                    // Criando um submenu para cada identificação do modelo
                    var itemSubMenu = new ToolStripMenuItem(modelo.IdentificacaoModelo.Replace('_', ' ').ToUpper());  // Substituindo _ por espaço e colocando em maiúsculas
                    itemSubMenu.Click += (sender, e) => ModeloMenuItem_Click(sender, e, modelo, modelo.IdentificacaoModelo);

                    // Adicionando o item de submenu ao item do menu principal
                    itemMenuModelo.DropDownItems.Add(itemSubMenu);
                }

                // Adicionando o item de menu principal ao menu principal (arquivoToolStripMenuItem)
                arquivoToolStripMenuItem.DropDownItems.Add(itemMenuModelo);
            }
        }

        private void ModeloMenuItem_Click(object sender, EventArgs e, Modelo modelo, string identificacao)
        {
            // Aqui você cria o formulário e passa o modelo e a identificação que foi clicada
            FrmChat frm = new(modelo.NomeModelo, identificacao);
            frm.utils = this.utils;  // Passando outros dados, se necessário
            frm.AtualizaBarraProgresso += AtualizaBarraProgresso;
            frm.Show();
        }

       
    }
}