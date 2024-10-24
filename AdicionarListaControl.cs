using System;
using System.Windows.Forms;

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
            foreach (var iten in ckList.Items)
            {
                ckList.Items.Remove(iten);
            }
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

        }

        private void toolSalvarLista_Click(object sender, EventArgs e)
        {
            if(ckList.Items.Count > 0)
            {
                saveFileDialog1.Filter = "Text Files (*.txt)|*.txt";
                saveFileDialog1.Title = "Salvar Lista";
                saveFileDialog1.DefaultExt = "txt";
                saveFileDialog1.AddExtension = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog1.FileName;

                    try
                    {
                        string conversationText = ckList.Items.ToString();
                        File.WriteAllText(filePath, conversationText);
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
    }
}
