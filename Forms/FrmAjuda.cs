using System;
using System.Windows.Forms;
namespace AIBAM.Forms
{
    public class FrmAjuda : Form
    {
        private Panel pnlConteudo;
        private Button btnProximo;
        private Button btnAnterior;
        private Label lblTitulo;
        private Label lblDescricao;

        private int indiceAtual = 0;
        private readonly string[] titulos = { "Zero-Shot", "One-Shot", "Few-Shot" };
        private readonly string[] descricoes = {
        "Zero-Shot:\n\nNo design de Zero-Shot, o modelo é solicitado a realizar uma tarefa sem receber exemplos específicos ou instruções claras além do prompt inicial. Ideal para tarefas gerais.",
        "One-Shot:\n\nNo design de One-Shot, o modelo recebe um exemplo único de entrada e saída esperado. Útil para guiar o modelo em casos simples.",
        "Few-Shot:\n\nNo design de Few-Shot, o modelo recebe múltiplos exemplos de entrada e saída esperados no prompt. É eficaz para tarefas que exigem contexto ou padrões claros."
    };

        public FrmAjuda()
        {
            // Configuração da janela
            Text = "Ajuda: Design de Comando";
            Width = 500;
            Height = 300;

            // Inicialização dos controles
            pnlConteudo = new Panel { Dock = DockStyle.Fill, Padding = new Padding(10) };
            lblTitulo = new Label { Dock = DockStyle.Top, Font = new Font("Segoe UI", 14, FontStyle.Bold), Height = 40, TextAlign = ContentAlignment.MiddleCenter };
            lblDescricao = new Label { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 10), TextAlign = ContentAlignment.TopLeft, Padding = new Padding(5) };
            btnAnterior = new Button { Text = "Anterior", Dock = DockStyle.Left, Width = 100 };
            btnProximo = new Button { Text = "Próximo", Dock = DockStyle.Right, Width = 100 };

            // Adiciona eventos aos botões
            btnAnterior.Click += BtnAnterior_Click;
            btnProximo.Click += BtnProximo_Click;

            // Adiciona controles ao painel
            pnlConteudo.Controls.Add(lblDescricao);
            pnlConteudo.Controls.Add(lblTitulo);
            Controls.Add(pnlConteudo);
            Controls.Add(btnAnterior);
            Controls.Add(btnProximo);

            // Carrega o primeiro item
            AtualizarConteudo();
        }

        private void BtnAnterior_Click(object sender, EventArgs e)
        {
            if (indiceAtual > 0)
            {
                indiceAtual--;
                AtualizarConteudo();
            }
        }

        private void BtnProximo_Click(object sender, EventArgs e)
        {
            if (indiceAtual < titulos.Length - 1)
            {
                indiceAtual++;
                AtualizarConteudo();
            }
        }

        private void InitializeComponent()
        {

        }

        private void AtualizarConteudo()
        {
            lblTitulo.Text = titulos[indiceAtual];
            lblDescricao.Text = descricoes[indiceAtual];
            btnAnterior.Enabled = indiceAtual > 0;
            btnProximo.Enabled = indiceAtual < titulos.Length - 1;
        }
    }
}