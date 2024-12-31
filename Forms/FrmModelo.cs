using AIBAM.Classes;
using AIBAM.Controles;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static AIBAM.ChatClient;
using static AIBAM.Classes.Modelo;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AIBAM.Forms
{
    public partial class FrmModelo : Form
    {
        bool isViewItemItem;
        private Navegador<Modelo> navegador;
        private Modelo modelo;
        private ModeloManager modeloManager = new ModeloManager();
        public event Action<string> OnStatusChanged;
        public event Action AtualizaBarraProgresso;
        public Utils utils;
        readonly ChatClient chatClient = new ChatClient("localhost", 8080);
        public FrmModelo(bool isItemaItem = false)
        {
            InitializeComponent();
            isViewItemItem = isItemaItem;
           _= CarregarComboBoxAsync();
        }

        private  void FrmModelo_Load(object sender, EventArgs e)
        {
            
            if (isViewItemItem)
            {
                HabilitaDesabilitaBotoesNavegacao();
                CarregarNavegacaoItem();
                HabilitaDesabilitaEdicaoItem();
                this.Text = "AIBAM | Ler Modelos";
                btnEditar.Visible = !btnEditar.Visible;
                splitContainer2.Panel2Collapsed = !splitContainer2.Panel2Collapsed;
            }
           
        }

        private async Task CarregarComboBoxAsync()
        {
            
            chatClient.OnMessageReceived += ChatClient_OnMessageReceived;
            await chatClient.Connect(CarregarDados);
            var chatData = new ChatData();
            chatData.Command = "sair";
            await chatClient.SendMessage(chatData,modelo);
        }

        private void ChatClient_OnMessageReceived(string response)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => AddResponseToComboBox(response)));
            }
            else
            {
                AddResponseToComboBox(response);
            }
        }

        private void AddResponseToComboBox(string response)
        {
            if (!string.IsNullOrWhiteSpace(response))
            {
                // Separa a string em itens usando delimitadores como vírgula ou quebra de linha
                var items = response.Split(new[] { ',', '\n', ';' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in items)
                {
                    // Remove espaços extras antes de adicionar
                    string trimmedItem = item.Trim();

                    // Adiciona ao ComboBox apenas se não estiver vazio e ainda não existir no ComboBox
                    if (!string.IsNullOrWhiteSpace(trimmedItem) && !cboModelName.Items.Contains(trimmedItem))
                    {
                        cboModelName.Items.Add(trimmedItem);
                    }
                }

                // Opcional: Seleciona o primeiro item adicionado, se houver
                if (cboModelName.Items.Count > 0)
                {
                    cboModelName.SelectedItem = cboModelName.Items[0];
                }
            }
        }

        private async Task CarregarDados()
        {
            // Conecta ao servidor e inicializa o chat após a conexão
            var chatData = new ChatData();
            chatData.Command = "listar_modelos";
            await chatClient.SendMessage(chatData);
            
        }

        private void HabilitaDesabilitaEdicaoItem()
        {
            txtNomeModelo.ReadOnly = !txtNomeModelo.ReadOnly;
            txtIdentificacaoModelo.ReadOnly = !txtIdentificacaoModelo.ReadOnly;
            txtDescricacaoModelo.ReadOnly = !txtDescricacaoModelo.ReadOnly;
            adicionarListaControl1.DesabilitaAcoes();
        }

        private void HabilitaDesabilitaBotoesNavegacao()
        {
            splitContainer1.Panel2Collapsed = !splitContainer1.Panel2Collapsed;
        }

        private void CarregarNavegacaoItem()
        {
            var modelos = modeloManager.CarregarModelos();
            navegador = new(modelos);
            modelo = new();
            modelo = navegador.ItemAtual;
            AtribuirModelo();
        }

        private void AtribuirModelo()
        {
            txtNomeModelo.Text = modelo.NomeModelo.ToString().Replace("_"," ").ToUpper();
            txtIdentificacaoModelo.Text = modelo.IdentificacaoModelo.ToString().Replace("_", " ").ToUpper(); 
            txtDescricacaoModelo.Text = modelo.DescricaoModelo.ToString();
            adicionarListaControl1.LimparLista();
            adicionarListaControl1.SetItensSelecionados(modelo.RegrasModelo);
            cboModelName.Text = modelo.IANome;
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            if (navegador.TemProximo())
            {
                navegador.Proximo();
                modelo = navegador.ItemAtual;
                AtribuirModelo();
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
                modelo = navegador.ItemAtual;
                AtribuirModelo();
            }
            HabitaDesabilitaNavegacao();
        }


        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }

        private void FrmModelo_KeyDown(object sender, KeyEventArgs e)
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
            }
        }
        private void AtualizaNavegador()
        {

            var item = navegador.ItemAtual;
            CarregarNavegacaoItem();
            navegador.SelecionarItem(item);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2Collapsed = !splitContainer2.Panel2Collapsed;
            HabilitaDesabilitaBotoesNavegacao();
            btnEditar.Visible = !btnEditar.Visible;
            HabilitaDesabilitaEdicaoItem();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2Collapsed = !splitContainer2.Panel2Collapsed;
            HabilitaDesabilitaBotoesNavegacao();
            btnEditar.Visible = !btnEditar.Visible;
            HabilitaDesabilitaEdicaoItem();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            ParseModelo();
            modeloManager.SalvarModelo(modelo);
            HabilitaDesabilitaBotoesNavegacao();
            btnEditar.Visible = !btnEditar.Visible;
            HabilitaDesabilitaEdicaoItem();
            splitContainer2.Panel2Collapsed = !splitContainer2.Panel2Collapsed;
            CarregarNavegacaoItem();
        }

        private void ParseModelo()
        {
            modelo.NomeModelo = FormatarTexto(txtNomeModelo.Text);
            modelo.IdentificacaoModelo = FormatarTexto(txtIdentificacaoModelo.Text);
            modelo.DescricaoModelo = txtDescricacaoModelo.Text;
            modelo.RegrasModelo = adicionarListaControl1.GetItensSelecionados();
            modelo.IANome = cboModelName.Text;
        }

        private string FormatarTexto(string text)
        {
            var texto_formatado = text.Replace(" ", "_");
            return texto_formatado;
        }

        private void btnAbrirChat_Click(object sender, EventArgs e)
        {
            // Aqui você cria o formulário e passa o modelo e a identificação que foi clicada
            FrmChat frm = new(modelo.NomeModelo, modelo.IdentificacaoModelo);
            frm.utils = this.utils;  // Passando outros dados, se necessário
            frm.AtualizaBarraProgresso += AtualizaBarraProgresso;
            frm.Show();
        }
    }
}
