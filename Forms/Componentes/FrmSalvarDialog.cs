using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AIBAM.Forms.Componentes
{
    public partial class FrmSalvarDialog : Form
    {
        public string SelectedOption { get; private set; } = string.Empty;

        public FrmSalvarDialog(string message, List<string> options)
        {
            InitializeComponent();

            // Configurações básicas do formulário
            this.Text = "Salvar";
            this.Size = new Size(400, 180);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Painel superior para ícone e mensagem
            Panel topPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70,
                Padding = new Padding(10)
            };
            this.Controls.Add(topPanel);

            // Adiciona o ícone
            PictureBox pictureBox = new PictureBox
            {
                Image = SystemIcons.Question.ToBitmap(),
                Size = new Size(48, 48),
                Location = new Point(10, 10),
                SizeMode = PictureBoxSizeMode.CenterImage
            };
            topPanel.Controls.Add(pictureBox);

            // Adiciona a mensagem
            Label lblMessage = new Label
            {
                Text = message,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                AutoSize = false,
                Location = new Point(70, 10),
                Size = new Size(this.ClientSize.Width - 90, 50),
                TextAlign = ContentAlignment.MiddleLeft
            };
            topPanel.Controls.Add(lblMessage);

            // Adiciona os botões dinamicamente
            FlowLayoutPanel buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(10),
                Height = 50
            };
            this.Controls.Add(buttonPanel);

            // Cores personalizadas para os botões
            var buttonColors = new Dictionary<string, Color>
            {
                { "Banco", Color.DodgerBlue },
                { "Local", Color.MediumSeaGreen },
                { "Ambos", Color.Goldenrod },
                { "Cancelar", Color.IndianRed }
            };

            foreach (var option in options)
            {
                Button button = new Button
                {
                    Text = option,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    BackColor = buttonColors.ContainsKey(option) ? buttonColors[option] : Color.Gray,
                    ForeColor = Color.White,
                    Size = new Size(75, 23)
                };

                button.Click += (s, e) =>
                {
                    SelectedOption = option;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                };

                buttonPanel.Controls.Add(button);
            }
        }

        public static string ShowDialog(string message, List<string> options)
        {
            using (FrmSalvarDialog dialog = new FrmSalvarDialog(message, options))
            {
                return dialog.ShowDialog() == DialogResult.OK ? dialog.SelectedOption : string.Empty;
            }
        }
    }
}
