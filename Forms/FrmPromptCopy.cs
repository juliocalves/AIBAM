using AIBAM.Classes;
using AIBAM.Classes.Servicos;
using AIBAM.Forms.Componentes;
using AIBAM.Templates;

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

using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AIBAM.Forms
{
    public partial class FrmPromptCopy : Form
    {
        PromptCopy promptCopy;
        public string textoPromptCopy = "";
        public Utils utils;
        public event Action<string> OnStatusChanged;
        public event Action AtualizaBarraProgresso;
        public FrmPromptCopy()
        {
            InitializeComponent();
        }

        private void novaToolStripButton1_Click(object sender, EventArgs e)
        {
            LimparConteudoPromptCopy();
        }

        private void LimparConteudoPromptCopy()
        {
            // Limpa o conteúdo dos controles onde o prompt é exibido
            txtNomePromptCopy.Clear();

            //LIMPAR CAMPOS BRIEFING 
            briefingCopyControl1.LimparCampos();
            //LIMPA CAMPOS DE PUBLICO ALVO
            publicoAlvoControl1.LimparCampos();

            // Limpa os controles de criação
            nEntonacao.Value = nEntonacao.Minimum; // ou 0, dependendo do seu controle
            nOriginalidade.Value = nOriginalidade.Minimum; // ou 0, dependendo do seu controle
            utils.SetSelectedValue(gbPerspectiva, string.Empty); // Limpa a perspectiva
            lstPalavrasChave.LimparLista();
            utils.SetSelectedValue(ckSentimentos, new List<string>());

            // Cria um novo objeto promptCopy vazio
            promptCopy = new PromptCopy(); // Supondo que PromptCopy é a classe que você está usando

            // Atualiza o status indicando que um novo prompt está pronto para ser criado
            OnStatusChanged?.Invoke("Novo Modelo Prompt iniciado.");
        }

        private void abrirToolStripButton1_Click(object sender, EventArgs e)
        {

            // Configurações do diálogo de abertura de arquivo
            openFileDialog1.Filter = "JSON files (*.json)|*.json";
            openFileDialog1.Title = "Abrir Modelo Prompt";
            openFileDialog1.AddExtension = false;
            openFileDialog1.InitialDirectory = Path.Combine(Settings.Default.DiretorioRaiz, "DATASETS");
            // Exibe o diálogo e verifica se o usuário selecionou um arquivo
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;

                try
                {
                    // Lê o conteúdo do arquivo JSON selecionado
                    string json = File.ReadAllText(filePath);
                    promptCopy = new();
                    LimparConteudoPromptCopy();
                    // Deserializa o conteúdo JSON para o objeto promptCopy
                    promptCopy = JsonConvert.DeserializeObject<PromptCopy>(json);
                    // Atualiza os campos da interface com os dados do promptCopy
                    txtNomePromptCopy.Text = promptCopy.DescricaoCopy;
                    //ATRIBUI PUBLICO ALVO NO CONTROLE 
                    publicoAlvoControl1.AtribuirPublicoAlvo(promptCopy.publicoAlvo);
                    // Atualiza os controles de criação
                    utils.SetSelectedValue(ckSentimentos, promptCopy.controlesCopy.Sentimento);
                    nEntonacao.Value = promptCopy.controlesCopy.Entonacao;
                    nOriginalidade.Value = promptCopy.controlesCopy.Originalidade;
                    utils.SetSelectedValue(gbPerspectiva, promptCopy.controlesCopy.Perspectiva);
                    lstPalavrasChave.SetItensSelecionados(promptCopy.controlesCopy.PalavrasChave);

                    //ATRIBUIR BRIEFING
                    briefingCopyControl1.AtribuirBriefing(promptCopy.briefing);

                    // Atualiza o status de sucesso
                    OnStatusChanged?.Invoke($"Modelo Prompt carregado de: {filePath}");
                }
                catch (Exception ex)
                {
                    // Mostra mensagem de erro se algo falhar
                    MessageBox.Show($"Erro ao abrir o Modelo Prompt: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Atualiza o status em caso de erro
                    OnStatusChanged?.Invoke("Erro ao abrir o Modelo Prompt.");
                }
            }
            else
            {
                // Atualiza o status se o usuário cancelar a operação de abertura
                OnStatusChanged?.Invoke("Operação de abertura cancelada.");
            }
        }

        private async void salvarToolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                AtualizaBarraProgresso?.Invoke();
                OnStatusChanged?.Invoke("Iniciando processo de salvar...");

                // Atualiza e prepara os dados do prompt
                ParsePromptCopy();
                PromptCopyTemplate prompt = new(promptCopy);
                textoPromptCopy = prompt.MontaPrompt();

                // Exibe o diálogo personalizado de salvamento
                string message = "Escolha uma opção de salvamento:";
                List<string> options = new List<string> { "Banco", "Local", "Ambos", "Cancelar" };
                string selectedOption = FrmSalvarDialog.ShowDialog(message, options);

                // Lida com a opção selecionada
                switch (selectedOption)
                {
                    case "Local":
                        SalvarLocal();
                        OnStatusChanged?.Invoke("Arquivo salvo localmente com sucesso.");
                        break;

                    case "Banco":
                        await SalvarBancoDadosAsync();
                        OnStatusChanged?.Invoke("Prompt salvo no banco de dados com sucesso.");
                        break;

                    case "Ambos":
                        SalvarLocal();
                        await SalvarBancoDadosAsync();
                        OnStatusChanged?.Invoke("Arquivo salvo localmente e no banco de dados com sucesso.");
                        break;

                    case "Cancelar":
                    default:
                        OnStatusChanged?.Invoke("Operação de salvamento cancelada pelo usuário.");
                        break;
                }
            }
            catch (Exception ex)
            {
                OnStatusChanged?.Invoke($"Erro ao salvar: {ex.Message}");
            }
            finally
            {
                AtualizaBarraProgresso?.Invoke();
            }
        }


        private async Task SalvarBancoDadosAsync()
        {
            try
            {
                OnStatusChanged?.Invoke("Salvando dados no banco de dados...");
                PromptCopyService promptCopyService = new();
                await promptCopyService.AdcionarPromptCopy(promptCopy);
            }
            catch (Exception ex)
            {
                OnStatusChanged?.Invoke($"Erro ao salvar no banco de dados: {ex.Message}");
                throw;
            }
        }


        private void SalvarLocal()
        {
            saveFileDialog1 = new();
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt";
            saveFileDialog1.Title = "Salvar Modelo Prompt";
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.FileName = txtNomePromptCopy.Text;
            saveFileDialog1.AddExtension = true;
            string diretorio = Path.Combine(Settings.Default.DiretorioRaiz, "PROMPTS");
            saveFileDialog1.InitialDirectory = diretorio;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;
                utils.SaveToJson(promptCopy, txtNomePromptCopy.Text);
                try
                {
                    File.WriteAllText(filePath, textoPromptCopy);
                    OnStatusChanged?.Invoke("Modelo Prompt salva com sucesso!");
                }
                catch (Exception ex)
                {
                    OnStatusChanged?.Invoke("Erro ao salvar a Modelo Prompt.");
                }
            }
            else
            {
                OnStatusChanged?.Invoke("Operação de salvamento cancelada.");
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OnStatusChanged?.Invoke("Configurando prompt");
            ParsePromptCopy();
            PromptCopyTemplate prompt = new(promptCopy);
            ///salva aquivo em formato de texto concatenado
            textoPromptCopy = prompt.MontaPrompt();
            OnStatusChanged?.Invoke("Promtpt pronto!");
            //SelecionaTipoChat("False");
            //txtPrompt.Text = textoPromptCopy;
            //RequestToChat();

        }
        private void ParsePromptCopy()
        {
            promptCopy.DescricaoCopy = txtNomePromptCopy.Text;
            //ATRIBUI BRIEFING COPY
            promptCopy.briefing = briefingCopyControl1.RetornaBriefing();
            //ATRIBUI PUBLICO ALVO DE CONTROLE PUBLICO ALVO
            promptCopy.publicoAlvo = publicoAlvoControl1.RetonaPublicoAlvo();

            //ATRIBUI CONTROLES DE CRIAÇÃO COPY
            promptCopy.controlesCopy.Entonacao = (int)nEntonacao.Value;
            promptCopy.controlesCopy.Originalidade = (int)nOriginalidade.Value;
            promptCopy.controlesCopy.Sentimento = utils.ObterItensSelecionado(ckSentimentos);
            promptCopy.controlesCopy.Perspectiva = utils.ObterTextoGroupBox(gbPerspectiva);
            promptCopy.controlesCopy.PalavrasChave = lstPalavrasChave.GetItensSelecionados();
        }

        private void nEntonacao_Enter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(nEntonacao, " 1-Pouco Informal e 10-Muito Formal");
        }
        private void nOriginalidade_Enter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(nOriginalidade, " 1-Pouco Original e 10-Muito Original");
        }
    }
}
