using AIBAM.Classes;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIBAM
{
    public partial class FrmListar : Form
    {
        private List<BriefingCopy> _briefingList; // Lista interna para armazenar os itens
        private List<Produto> _produtos;
        private List<Catalogo> _catalogos;
        private List<PublicoAlvo> _publicosAlvo;
        public BriefingCopy SelectedBriefing { get; private set; } // Objeto selecionado
        public Produto SelectedProduto { get; internal set; }
        public Catalogo SelectedCatalogo { get; internal set; }
        public PublicoAlvo SelectedPublicoAlvo { get; internal set; }



        string objeto = "";

        public FrmListar(List<BriefingCopy> briefingList)
        {
            InitializeComponent();
            _briefingList = briefingList;
            objeto = "BRIEFINGCOPY";
        }

        public FrmListar(List<Produto> produtos)
        {
            InitializeComponent();
            _produtos = produtos;
            objeto = "PRODUTOS";
        }
        public FrmListar(List<Catalogo> catalogos)
        {
            InitializeComponent();
            _catalogos = catalogos;
            objeto = "CATALOGO";
        }
        public FrmListar(List<PublicoAlvo> publicosAlvo)
        {
            InitializeComponent();
            _publicosAlvo = publicosAlvo;
            objeto = "PUBLICO ALVO";
        }

        private void FrmListar_Load(object sender, EventArgs e)
        {
            dgvView.AutoGenerateColumns = true;
            switch (objeto)
            {

                case "BRIEFINGCOPY":
                    // Configurar dgvView com a lista
                    dgvView.DataSource = _briefingList;
                    break;
                case "PRODUTOS":
                    // Configurar dgvView com a lista
                    dgvView.DataSource = _produtos;
                    break;
                case "CATALOGO":
                    dgvView.DataSource = _catalogos;
                    break;
                case "PUBLICO ALVO":
                    dgvView.DataSource = _publicosAlvo;
                    break;
            }

        }

        private void dgvView_MouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Verificar se há uma linha selecionada
            if (dgvView.SelectedRows.Count > 0)
            {
                int index = dgvView.SelectedRows[0].Index;
                switch (objeto)
                {
                    case "BRIEFINGCOPY":
                        SelectedBriefing = _briefingList[index]; // Retorna o item selecionado
                        break;
                    case "PRODUTOS":
                        SelectedProduto = _produtos[index];
                        break;
                    case "CATALOGO":
                        SelectedCatalogo = _catalogos[index];
                        break;
                    case "PUBLICO ALVO":
                        SelectedPublicoAlvo = _publicosAlvo[index];
                        break;
                }
                this.DialogResult = DialogResult.OK; // Indica que o formulário foi concluído com sucesso
                this.Close();
            }
            else
            {
                MessageBox.Show("Selecione um item antes de continuar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
