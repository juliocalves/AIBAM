using System;
using System.IO;
using System.Windows.Forms;

using AIBAM.Properties; // Certifique-se de ter o namespace correto para as configurações

namespace AIBAM
{
    public partial class FrmConfiguracoes : Form
    {
        public FrmConfiguracoes()
        {
            InitializeComponent();
        }
        private void FrmConfiguracoes_Load(object sender, EventArgs e)
        {
            // Exibe o diretório salvo nas configurações, se já foi definido anteriormente
            txtDiretorioRaiz.Text = Settings.Default.DiretorioRaiz;

            tabControl1.ImageList = imageList1;
            tabControl1.TabPages[0].ImageIndex = 0;
        }

        private void btnDefinirDiretorio_Click(object sender, EventArgs e)
        {
            // Exibe a caixa de diálogo para seleção de pasta
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                // Salva o caminho selecionado nas configurações
                Settings.Default.DiretorioRaiz = Path.Combine(folderBrowserDialog1.SelectedPath, "AIBAM");

                // Atualiza o TextBox com o caminho selecionado
                txtDiretorioRaiz.Text = Settings.Default.DiretorioRaiz;

                // Salva as configurações
                Settings.Default.Save();
            }
        }

        private void btnCriarEstrutura_Click(object sender, EventArgs e)
        {
            // Verifica se o diretório raiz está definido
            if (!string.IsNullOrEmpty(Settings.Default.DiretorioRaiz))
            {
                // Define o caminho base
                string basePath = Settings.Default.DiretorioRaiz;

                // Define a estrutura de diretórios desejada
                string[] subdirectories = {
                    basePath,
                    Path.Combine(basePath,"PROMPTS"),
                    Path.Combine(basePath,"LISTAS"),
                    Path.Combine(basePath,"DATASETS"),
                    Path.Combine(basePath,"CONVERSAS"),
                };

                try
                {
                    // Cria cada diretório se não existir
                    foreach (string dir in subdirectories)
                    {
                        if (!Directory.Exists(dir))
                        {
                            Directory.CreateDirectory(dir);
                        }
                    }

                    MessageBox.Show("Estrutura de diretórios criada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao criar a estrutura de diretórios: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, defina o diretório raiz antes de criar a estrutura.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
