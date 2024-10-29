using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBAM
{
    public class Utils
    {
        public string ObterTextoGroupBox(GroupBox groupBox)
        {
            // Itera pelos controles no GroupBox
            foreach (Control control in groupBox.Controls)
            {
                // Verifica se o controle é um RadioButton e se está marcado
                if (control is RadioButton radioButton && radioButton.Checked)
                {
                    return radioButton.Text; // Retorna o texto do RadioButton selecionado
                }
            }

            return string.Empty; // Retorna vazio se nenhum RadioButton estiver selecionado
        }
        public List<string> ObterItensSelecionado(CheckedListBox ckList)
        {
            List<string> itensSelecionados = new List<string>();

            // Itera pelos itens checados em ckList
            foreach (var item in ckList.CheckedItems)
            {
#pragma warning disable CS8604 // Possível argumento de referência nula.
                itensSelecionados.Add(item.ToString());
#pragma warning restore CS8604 // Possível argumento de referência nula.
            }

            return itensSelecionados;
        }
    }
}
