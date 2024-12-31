using System;
using System.Windows.Forms;

namespace AIBAM.Forms
{
    public class FrmAjudaInstrucoes : Form
    {
        private Panel pnlConteudo;
        private Label lblTitulo;
        private RichTextBox rtbConteudo;
        private Button btnFechar;

        public FrmAjudaInstrucoes()
        {
            // Configuração da janela
            Text = "Ajuda: Instruções para o Modelo";
            Width = 600;
            Height = 400;
            StartPosition = FormStartPosition.CenterScreen;

            // Inicializa os controles
            pnlConteudo = new Panel { Dock = DockStyle.Fill, Padding = new Padding(10) };
            lblTitulo = new Label
            {
                Text = "Instruções para Modelo",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 40,
                TextAlign = ContentAlignment.MiddleCenter
            };
            rtbConteudo = new RichTextBox
            {
                ReadOnly = true,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10),
                Text = ObterTextoAjuda()
            };
            btnFechar = new Button
            {
                Text = "Fechar",
                Dock = DockStyle.Bottom,
                Height = 40
            };

            // Evento para fechar a janela
            btnFechar.Click += (sender, e) => Close();

            // Adiciona os controles ao painel
            pnlConteudo.Controls.Add(rtbConteudo);
            Controls.Add(lblTitulo);
            Controls.Add(pnlConteudo);
            Controls.Add(btnFechar);
        }

        private string ObterTextoAjuda()
        {
            return @"As instruções para o modelo permitem definir como a IA deve interpretar e responder. Aqui estão as seções principais:

1. **Nome do Modelo**:
   - Identifica o modelo. Deve ser um nome claro e único.

2. **Identificação do Modelo (Chave)**:
   - Uma chave única usada para identificar o modelo em sistemas integrados.

3. **Instrução do Modelo**:
   - A instrução principal que guia o comportamento da IA.
   - Exemplo: 'Gere respostas criativas baseadas no contexto fornecido.'

4. **Regras do Modelo**:
   - Lista de regras para restringir ou direcionar as respostas da IA.
   - Exemplo:
     - Evite frases longas.
     - Use linguagem técnica, mas compreensível.
     - Assegure que as respostas são objetivas.

Dica: Combine instruções claras e regras bem definidas para obter resultados consistentes e alinhados ao objetivo.";
        }
    }

}