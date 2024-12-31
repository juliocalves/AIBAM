using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AIBAM.Forms
{
    public partial class FrmWebView : Form
    {
        public string url = "";
        // Variáveis para controlar o movimento e redimensionamento do formulário
        private bool isDragging = false;
        private Point lastCursor;
        private const int padding = 6; // Padding do formulário (conforme especificado)

        // Variáveis para redimensionamento
        private const int resizeEdgeThickness = 5;

        public FrmWebView(string url)
        {
            InitializeComponent();

            // Inicializa o WebView2 e aguarda o carregamento completo
            webView.CoreWebView2InitializationCompleted += WebView_CoreWebView2InitializationCompleted;

            // Carregar a URL
            webView.Source = new Uri(url);

            SetRoundedCorners();  // Definir bordas arredondadas
        }

        public FrmWebView()
        {
            InitializeComponent();

            // Inicializa o WebView2 e aguarda o carregamento completo
            webView.CoreWebView2InitializationCompleted += WebView_CoreWebView2InitializationCompleted;

            // Carregar a URL padrão
            webView.Source = new Uri("https://google.com");

            SetRoundedCorners();  // Definir bordas arredondadas
        }

        // Evento chamado quando o WebView2 está completamente carregado
        private async void WebView_CoreWebView2InitializationCompleted(object sender, EventArgs e)
        {
            try
            {
                // Aguardar o script de título da página ser executado
                string pageTitle = await webView.CoreWebView2.ExecuteScriptAsync("document.title");

                // Atualizar o título do botão ou outro controle com o título da página
                button1.Text = pageTitle.Trim('"');  // Remove as aspas

                // Obter o URL atual (de forma assíncrona)
                string currentUrl = webView.Source.AbsoluteUri;

                // Exibir o URL no TextBox ou outro controle
                txtUrl.Text = currentUrl;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao acessar o WebView2: {ex.Message}");
            }
        }


        // Método para definir bordas arredondadas
        private void SetRoundedCorners()
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                // Se o formulário estiver maximizado, remova a região arredondada
                this.Region = null;  // Remove a região arredondada
            }
            else
            {
                // Caso contrário, defina a região com bordas arredondadas
                int borderRadius = 30;
                var path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddArc(0, 0, borderRadius, borderRadius, 180, 90); // Canto superior esquerdo
                path.AddArc(this.Width - borderRadius, 0, borderRadius, borderRadius, 270, 90); // Canto superior direito
                path.AddArc(this.Width - borderRadius, this.Height - borderRadius, borderRadius, borderRadius, 0, 90); // Canto inferior direito
                path.AddArc(0, this.Height - borderRadius, borderRadius, borderRadius, 90, 90); // Canto inferior esquerdo
                path.CloseFigure();

                // Aplica a região com as bordas arredondadas ao formulário
                this.Region = new Region(path);
            }
        }

        // Evento que é chamado sempre que o formulário for redimensionado ou maximizado/restaurado
        private void FrmWebView_Resize(object sender, EventArgs e)
        {
            SetRoundedCorners();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // Método para mover o formulário
        private void splitContainer1_Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            // Inicia o movimento do formulário
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastCursor = e.Location;
            }
        }

        // Método para arrastar o formulário
        private void splitContainer1_Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                // Calcula o novo local para mover o formulário
                Point delta = new Point(e.X - lastCursor.X, e.Y - lastCursor.Y);
                this.Location = new Point(this.Location.X + delta.X, this.Location.Y + delta.Y);
            }
        }

        // Finaliza o movimento do formulário
        private void splitContainer1_Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        // Método para permitir o redimensionamento
        private void FrmWebView_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Verificar se o mouse está perto das bordas para redimensionar
                if (e.X >= this.ClientSize.Width - resizeEdgeThickness)  // Borda direita
                {
                    this.Cursor = Cursors.SizeWE;
                    if (this.Cursor == Cursors.SizeWE)
                    {
                        this.Width = Math.Max(200, e.X); // Limita a largura mínima
                    }
                }
                else if (e.Y >= this.ClientSize.Height - resizeEdgeThickness) // Borda inferior
                {
                    this.Cursor = Cursors.SizeNS;
                    if (this.Cursor == Cursors.SizeNS)
                    {
                        this.Height = Math.Max(200, e.Y); // Limita a altura mínima
                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void FrmWebView_MouseDown(object sender, MouseEventArgs e)
        {
            // Finaliza o redimensionamento ou movimento
            if (e.Button == MouseButtons.Left)
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {

        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (webView.CoreWebView2.CanGoBack)
            {
                webView.CoreWebView2.GoBack();
            }
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            if (webView.CoreWebView2.CanGoForward)
            {
                webView.CoreWebView2.GoForward();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            webView.Reload();
        }

        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string input = txtUrl.Text.Trim();

                // Verificar se contém "." e se não é uma palavra isolada
                if (input.Contains(".") && !input.Contains(" "))
                {
                    // Se é um domínio ou URL, adicionar esquema se necessário
                    if (!input.StartsWith("http://") && !input.StartsWith("https://"))
                    {
                        input = "https://" + input;
                    }

                    try
                    {
                        // Navegar para o URL digitado
                        webView.Source = new Uri(input);
                    }
                    catch (UriFormatException)
                    {
                        MessageBox.Show("URL inválida. Por favor, insira um endereço válido.");
                    }
                }
                else
                {
                    // Caso contrário, realizar pesquisa no Google
                    string searchUrl = $"https://www.google.com/search?q={Uri.EscapeDataString(input)}";
                    webView.Source = new Uri(searchUrl);
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
