using System;
using System.Windows.Forms;
namespace AIBAM.Forms
{

    public class FrmAjudaParametros : Form
    {
        private Panel pnlConteudo;
        private Button btnProximo;
        private Button btnAnterior;
        private Label lblTitulo;
        private Label lblDescricao;

        private int indiceAtual = 0;
        private readonly string[] titulos = { "Temperatura", "Tokens", "Filtros de Segurança" };
        private readonly string[] descricoes = {
        "Temperatura:\n\nControla a aleatoriedade das respostas. Valores mais baixos (ex.: 0.2) tornam as respostas mais previsíveis, enquanto valores mais altos (ex.: 0.8) tornam as respostas mais criativas e variáveis.",
        "Tokens:\n\nOs tokens representam unidades de texto. Este parâmetro define o limite máximo de tokens que podem ser gerados ou processados. É importante ajustá-lo para balancear entre desempenho e tamanho da resposta.",
        "Filtros de Segurança:\n\nControlam o bloqueio de conteúdos indesejados ou inadequados. Exemplos de filtros incluem para discurso ofensivo, material perigoso, ou conteúdo sexual. Ajuste conforme a aplicação para garantir segurança sem comprometer a funcionalidade."
    };

        public FrmAjudaParametros()
        {
            // Configuração da janela
            Text = "Ajuda: Parâmetros do Modelo";
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

        private void AtualizarConteudo()
        {
            lblTitulo.Text = titulos[indiceAtual];
            lblDescricao.Text = descricoes[indiceAtual];
            btnAnterior.Enabled = indiceAtual > 0;
            btnProximo.Enabled = indiceAtual < titulos.Length - 1;
        }
    }

}