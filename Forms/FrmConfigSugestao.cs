using AIBAM.Classes;
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

namespace AIBAM.Forms
{
    public partial class FrmConfigSugestao : Form
    {
        public Utils utils;
        public Modelo modelo = new();
        public ConfigModeloSugestao modeloSugestao = new();
        public string Tipo;
        public FrmConfigSugestao()
        {
            InitializeComponent();
            _ = CarregarComboBoxAsync();
        }
        private async Task CarregarComboBoxAsync()
        {
            var _chatClient = new ChatClient("localhost", 8080);
            string listaModelos = await _chatClient.CarregarListaAsync();
            AddResponseToComboBox(listaModelos);
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
                var iaNome = modelo?.IANome;

                cboModelName.SelectedItem = iaNome;
            }
        }
        internal ConfigModeloSugestao ObterConfigModelo()
        {
            ParseModelosSugestao();
            return modeloSugestao;
        }

        private void ParseModelosSugestao()
        {
            ParseModelo();
            modeloSugestao.Modelo = modelo;
            modeloSugestao.FormatoSaida = cboFormatoSaida.Text;
            modeloSugestao.Quantidade = Convert.ToInt32(numericUpDown1.Value);
            SetarExemplosEntradaSaida(adicionarListaControl2.GetItensSelecionados(), adicionarListaControl3.GetItensSelecionados());
        }

        public void SetarExemplosEntradaSaida(List<string> exemplosEntrada, List<string> exemplosSaida)
        {
            // Valida os parâmetros antes de definir a tupla
            if (exemplosEntrada == null || exemplosSaida == null)
            {
                throw new ArgumentNullException("As listas de exemplos não podem ser nulas.");
            }

            modeloSugestao.Modelo.ExemplosEntradaSaida = new Tuple<List<string>, List<string>>(exemplosEntrada, exemplosSaida);
        }
        public void AtribuirExemplosEntradaSaida(Tuple<List<string>, List<string>> exemplosEntradaSaida)
        {
            // Verifica se a tupla é nula
            if (exemplosEntradaSaida == null)
            {
                throw new ArgumentNullException(nameof(exemplosEntradaSaida), "A tupla de exemplos não pode ser nula.");
            }

            // Obtém os valores da tupla
            List<string> exemplosEntrada = exemplosEntradaSaida.Item1;
            List<string> exemplosSaida = exemplosEntradaSaida.Item2;

            // Verifica se os valores não são nulos
            if (exemplosEntrada == null || exemplosSaida == null)
            {
                throw new ArgumentNullException("Os exemplos de entrada ou saída não podem ser nulos.");
            }

            // Atribui os valores aos controles
            adicionarListaControl2.SetItensSelecionados(exemplosEntrada);
            adicionarListaControl3.SetItensSelecionados(exemplosSaida);
        }


        private void FrmConfigSugestao_Load(object sender, EventArgs e)
        {
            //adicionarListaControl2.OcultarAcoes();
            //adicionarListaControl3.OcultarAcoes();
            if(modeloSugestao.Modelo != null)
            {
                modelo = modeloSugestao.Modelo;
                
                AtribuirModelo();
            }
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            ParseModelosSugestao();
            try
            {
                // Obtém o modelo configurado a partir do formulário
                ConfigModeloSugestao configModelo = ObterConfigModelo(); // Método que retorna o objeto configurado no formulário

                if (configModelo == null)
                {
                    MessageBox.Show("O modelo de sugestão não está configurado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Define o nome do arquivo com base no tipo de sugestão
                string fileName = $"modelo_sugestao_{Tipo.ToLower()}.json"; // Supondo que o modelo tenha uma propriedade "Tipo"
                string filePath = Path.Combine(Settings.Default.DiretorioRaiz, "DATASETS", fileName);

                // Serializa o modelo em formato JSON
                string jsonContent = JsonConvert.SerializeObject(configModelo, Formatting.Indented);

                // Garante que o diretório existe antes de salvar
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                // Salva o arquivo JSON no local especificado
                File.WriteAllText(filePath, jsonContent);

                MessageBox.Show("Modelo de sugestão salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Define o DialogResult para OK e fecha o formulário
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar o modelo de sugestão: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private string FormatarTexto(string text)
        {
            var texto_formatado = text.Replace(" ", "_");
            return texto_formatado;
        }
        private void ParseModelo()
        {
            modelo.NomeModelo = FormatarTexto(txtNomeModelo.Text).ToLower();
            modelo.IdentificacaoModelo = FormatarTexto(txtIdentificacaoModelo.Text).ToLower();
            modelo.DescricaoModelo = txtDescricacaoModelo.Text;
            modelo.RegrasModelo = adicionarListaControl1.GetItensSelecionados();
            modelo.IANome = cboModelName.Text;
            modelo.LimiteTokens = Convert.ToInt32(txtTokens.Text);
            modelo.Temperatura = Convert.ToDouble(txtTemperatura.Text);
            modelo.Temperatura = Convert.ToDouble(txtTemperatura.Text);
            modelo.LimiteTokens = Convert.ToInt32(txtTokens.Text);
        }
        private void AtribuirModelo()
        {
            txtNomeModelo.Text = modelo.NomeModelo.ToString().Replace("_", " ").ToUpper();
            txtIdentificacaoModelo.Text = modelo.IdentificacaoModelo.ToString().Replace("_", " ").ToUpper();
            txtDescricacaoModelo.Text = modelo.DescricaoModelo.ToString();
            adicionarListaControl1.LimparLista();
            adicionarListaControl1.SetItensSelecionados(modelo.RegrasModelo);
            cboModelName.Text = modelo.IANome;
            // Atribuir valores aos TrackBars com base nos filtros do modelo
            
            txtTemperatura.Text = modelo.Temperatura?.ToString("N2");
            tbTemperatura.Value = Convert.ToInt32(modelo.Temperatura * 100);
            txtTokens.Text = modelo.LimiteTokens?.ToString();
            tbTokens.Value = Convert.ToInt32(modelo.LimiteTokens);
            tbAssedio.Value = GetTrackBarValue(modelo.FiltroAssedio);
            tbDiscurso.Value = GetTrackBarValue(modelo.FiltroDiscurso);
            tbSexual.Value = GetTrackBarValue(modelo.FiltroSexualmente);
            tbPerigoso.Value = GetTrackBarValue(modelo.FiltroPerigoso);
            txtTemperatura.Text = modelo.Temperatura.ToString();
            txtTokens.Text = modelo.LimiteTokens.ToString();
            AtribuirExemplosEntradaSaida(modeloSugestao.Modelo.ExemplosEntradaSaida);
            cboFormatoSaida.SelectedItem = modeloSugestao.FormatoSaida;
            numericUpDown1.Value = modeloSugestao.Quantidade;
        }
        private void tbTemperatura_Scroll(object sender, EventArgs e)
        {
            var valor = Convert.ToDouble((tbTemperatura.Value * 0.01));
            txtTemperatura.Text = valor.ToString("N2");
        }
        private void tbTokens_Scroll(object sender, EventArgs e)
        {
            txtTokens.Text = tbTokens.Value.ToString();
        }
        private void tbAssedio_Scroll(object sender, EventArgs e)
        {
            modelo.FiltroAssedio = GetFiltroValue(tbAssedio.Value);
        }
        private void tbDiscurso_Scroll(object sender, EventArgs e)
        {
            modelo.FiltroDiscurso = GetFiltroValue(tbDiscurso.Value);
        }
        private void tbSexual_Scroll(object sender, EventArgs e)
        {
            modelo.FiltroSexualmente = GetFiltroValue(tbSexual.Value);
        }

        private void tbPerigoso_Scroll(object sender, EventArgs e)
        {
            modelo.FiltroPerigoso = GetFiltroValue(tbPerigoso.Value);
        }
        private string GetFiltroValue(int value)
        {
            return value switch
            {
                5 => "Bloquear muitos",
                4 => "Bloquear alguns",
                3 => "Bloquear poucos",
                2 => "Não bloquear nada",
                1 => "N/A",
                _ => "N/A" // Valor padrão caso seja 0 ou inválido
            };
        }
        private int GetTrackBarValue(string? filtro)
        {
            return filtro switch
            {
                "Bloquear muitos" => 5,
                "Bloquear alguns" => 4,
                "Bloquear poucos" => 3,
                "Não bloquear nada" => 2,
                "N/A" => 1,
                _ => 0 // Valor padrão caso o filtro seja inválido ou nulo
            };
        }
        private void txtTemperatura_KeyPress(object sender, KeyPressEventArgs e)
        {
            utils.ApenasDecimal(sender, e);
        }
        private void cboModelName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParseModeloNome();

        }
        private void txtTemperatura_Leave(object sender, EventArgs e)
        {
            var valor = Convert.ToDouble(txtTemperatura.Text);
            tbTemperatura.Value = Convert.ToInt32(valor * 100);
        }
        private void ParseModeloNome()
        {
            modelo.IANome = cboModelName.Text;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
    public class ConfigModeloSugestao()
    {
        public Modelo Modelo { get; set; } = new();
        public int Quantidade { get; set; } = 1;
        public string FormatoSaida { get; set; } = "TEXTO";
       
    }
}
