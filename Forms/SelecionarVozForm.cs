using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace AIBAM.Forms
{
    public partial class SelecionarVozForm : Form
    {
        public string Voice { get; set; }

        private ComboBox comboBoxVozes;
        private Button buttonSelecionar;

        public SelecionarVozForm()
        {
            InitializeComponent();
            CarregarVozes();
        }

        private void InitializeComponent()
        {
            this.comboBoxVozes = new ComboBox();
            this.buttonSelecionar = new Button();

            // ComboBox para selecionar a voz
            this.comboBoxVozes.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxVozes.Location = new System.Drawing.Point(30, 30);
            this.comboBoxVozes.Size = new System.Drawing.Size(200, 30);

            // Botão para confirmar seleção
            this.buttonSelecionar.Text = "Selecionar Voz";
            this.buttonSelecionar.Location = new System.Drawing.Point(30, 70);
            this.buttonSelecionar.Click += new EventHandler(ButtonSelecionar_Click);

            // Adiciona os controles ao formulário
            this.Controls.Add(this.comboBoxVozes);
            this.Controls.Add(this.buttonSelecionar);

            // Configurações do Formulário
            this.Text = "Selecionar Voz";
            this.Size = new System.Drawing.Size(280, 150);
        }

        // Carrega as vozes disponíveis no sistema
        private void CarregarVozes()
        {
            // Instancia o sintetizador de fala
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();

            // Obtém as vozes disponíveis
            foreach (var voz in synthesizer.GetInstalledVoices())
            {
                comboBoxVozes.Items.Add(voz.VoiceInfo.Name);
            }

            // Seleciona a primeira voz por padrão
            if (comboBoxVozes.Items.Count > 0)
            {
                comboBoxVozes.SelectedIndex = 0;
            }
        }

        // Evento ao clicar no botão "Selecionar Voz"
        private void ButtonSelecionar_Click(object sender, EventArgs e)
        {
            // Seta a voz selecionada
            Voice = comboBoxVozes.SelectedItem.ToString();

            // Fecha o formulário
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
