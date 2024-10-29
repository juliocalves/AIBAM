using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIBAM.Componentes
{
    public partial class FrmEditItem : Form
    {
        public string ItemText { get; private set; }

        public FrmEditItem(string currentText)
        {
            InitializeComponent();
            textBoxEdit.Text = currentText;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            ItemText = textBoxEdit.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }

}
