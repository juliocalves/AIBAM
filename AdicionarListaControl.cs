namespace AIBAM
{
    public partial class AdicionarListaControl : UserControl
    {
        public event Action<string> OnExecutaAcao;
        public AdicionarListaControl()
        {
            InitializeComponent();
        }

        // Propriedade para definir o texto de lblDescricao
        public string Descricao
        {
            get { return lblDescricao.Text; }
            set { lblDescricao.Text = value; }
        }

        public string NomeLista
        {
            get { return lblNomeLista.Text; }
            set { lblNomeLista.Text = value; }
        }

        // Método para adicionar o item à lista com check automático
        private void AdicionaItemLista()
        {
            string item = txtItem.Text.Trim();

            if (!string.IsNullOrEmpty(item))
            {
                // Verifica se o item já está na lista
                if (!ckList.Items.Contains(item))
                {
                    ckList.Items.Add(item, true); // Adiciona item e marca o checkbox
                    txtItem.Clear(); // Limpa o campo de entrada após adicionar
                    ScrollToLastItem(ckList);
                }
                else
                {
                    MessageBox.Show("Este item já foi adicionado à lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Por favor, insira um item antes de adicionar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ScrollToLastItem(CheckedListBox ckList)
        {
            if (ckList.Items.Count > 0)
            {
                // Define o índice do item final para o topo da lista
                ckList.TopIndex = ckList.Items.Count - 1;
            }
        }

        // Método para remover itens selecionados
        private void RemoverItemLista()
        {
            // Verifica se há um item selecionado
            if (ckList.SelectedItem != null)
            {
                ckList.Items.Remove(ckList.SelectedItem); // Remove o item selecionado
            }
            else
            {
                MessageBox.Show("Nenhum item selecionado para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                AdicionaItemLista();
            }
        }

        private void ckList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoverItemLista();
            }
        }

        private void toolNovoItemLista_Click(object sender, EventArgs e)
        {
            AdicionaItemLista();
        }

        private void toolLimparLista_Click(object sender, EventArgs e)
        {
            LimparLista();
            MessageBox.Show("Todos os itens foram removidos.", "Lista Limpa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void LimparLista()
        {
            ckList.Items.Clear(); // Limpa todos os itens da lista de uma só vez
        }

        private void toolRemoverSelecionados_Click(object sender, EventArgs e)
        {
            // Verifica se há itens selecionados
            if (ckList.CheckedItems.Count > 0)
            {
                for (int i = ckList.CheckedItems.Count - 1; i >= 0; i--)
                {
                    ckList.Items.Remove(ckList.CheckedItems[i]);
                }
            }
        }

        private void toolAbrirLista_Click(object sender, EventArgs e)
        {
            // Configura o filtro e o título da caixa de diálogo para abrir arquivos
            openFileDialog1.Filter = "Text Files (*.txt)|*.txt";
            openFileDialog1.Title = "Abrir Lista";
            saveFileDialog1.FileName = lblNomeLista.Text;
            openFileDialog1.InitialDirectory = Path.Combine(Settings.Default.DiretorioRaiz, "LISTAS");
            // Exibe a caixa de diálogo para o usuário selecionar o arquivo
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;  // Obtém o caminho do arquivo selecionado

                try
                {
                    // Lê todas as linhas do arquivo de texto
                    string[] lines = File.ReadAllLines(filePath);

                    // Limpa a lista atual antes de carregar novos itens
                    ckList.Items.Clear();

                    // Adiciona cada linha como um item na ckList, marcando todos os itens por padrão
                    foreach (string line in lines)
                    {
                        ckList.Items.Add(line, true); // Adiciona o item e marca o checkbox
                    }

                    MessageBox.Show("Lista carregada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Em caso de erro ao abrir o arquivo
                    MessageBox.Show($"Erro ao abrir o arquivo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public List<string> GetItensSelecionados()
        {
            List<string> itensSelecionados = new List<string>();

            // Itera pelos itens checados em ckList
            foreach (var item in ckList.CheckedItems)
            {
                itensSelecionados.Add(item.ToString());
            }

            return itensSelecionados;
        }


        private void toolSalvarLista_Click(object sender, EventArgs e)
        {
            if (ckList.Items.Count > 0)
            {
                saveFileDialog1.Filter = "Text Files (*.txt)|*.txt";
                saveFileDialog1.Title = "Salvar Lista";
                saveFileDialog1.DefaultExt = "txt";
                saveFileDialog1.AddExtension = true;
                saveFileDialog1.FileName = lblNomeLista.Text;
                openFileDialog1.InitialDirectory = Path.Combine(Settings.Default.DiretorioRaiz, "LISTAS");

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog1.FileName;
                    try
                    {
                        string conteudo = string.Join(Environment.NewLine, GetItensSelecionados());
                        File.WriteAllText(filePath, conteudo);
                        MessageBox.Show($"Lista salva em: {filePath}", "Salvo com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Atualiza o status após o salvamento bem-sucedido
                        OnExecutaAcao?.Invoke("Lista salva com sucesso!");
                    }
                    catch (Exception ex)
                    {
                        // Mostra a mensagem de erro
                        MessageBox.Show($"Erro ao salvar a Lista: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        // Atualiza o status em caso de erro
                        OnExecutaAcao?.Invoke("Erro ao salvar a Lista.");
                    }
                }
                else
                {
                    // Atualiza o status se o usuário cancelar a operação de salvamento
                    OnExecutaAcao?.Invoke("Operação de salvamento cancelada.");
                }
            }
            else
            {
                MessageBox.Show("Não há itens para salvar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void SetItensSelecionados(List<string> itensSelecionados)
        {
            if (itensSelecionados != null || itensSelecionados.Any())
            {
                // Percorre todos os itens do CheckedListBox
                foreach (var linha in itensSelecionados)
                {
                    ckList.Items.Add(linha, true); // Adiciona o item e marca o checkbox
                }
            }
        }
    }
}
