using System;
using System.Windows.Forms;

namespace AIBAM
{
    public partial class AdicionarListaControl : UserControl
    {
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
            //// Verifica se há itens selecionados
            //if (ckList.CheckedItems.Count > 0)
            //{
            //    for (int i = ckList.CheckedItems.Count - 1; i >= 0; i--)
            //    {
            //        ckList.Items.Remove(ckList.CheckedItems[i]);
            //    }
            //}
            else
            {
                MessageBox.Show("Nenhum item selecionado para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Evento do botão 'Adicionar'
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            AdicionaItemLista();
        }

        //// Evento do botão 'Remover'
        //private void btnRemover_Click(object sender, EventArgs e)
        //{
        //    RemoverItemLista();
        //}

        // Evento da tecla 'Enter' no campo de texto 'txtItem'
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
            if(e.KeyCode == Keys.Delete)
            {
                RemoverItemLista();
            }
        }
    }
}
