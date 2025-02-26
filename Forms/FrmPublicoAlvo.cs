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

namespace AIBAM.Forms
{
    public partial class FrmPublicoAlvo : Form
    {
        private PublicoAlvo _publicoAlvo;
        private bool _verApenas;
        private bool _novoItem;
        public Utils utils;
        public event Action<string> OnStatusChanged;
        public event Action AtualizaBarraProgresso;
        public FrmPublicoAlvo()
        {
            InitializeComponent();
        }
        public FrmPublicoAlvo(bool novoItem)
        {
            InitializeComponent();
            _novoItem = novoItem;
            ConfigurarControles();
        }
        public FrmPublicoAlvo(PublicoAlvo publicoAlvo, bool verApenas)
        {
            InitializeComponent();
            _publicoAlvo = publicoAlvo;
            _verApenas = verApenas;
            AtribuirPublicoAlvo();
            ConfigurarControles();
        }

        private void ConfigurarControles()
        {
            if (_verApenas  && _publicoAlvo != null)
            {
                btnAnterior.Visible = false;
                btnExcluir.Visible = false;
                btnSalvarAlteracoes.Visible = false;
                btnProximo.Visible = false;
                txtProcurarPub.Visible = false;
                label1.Visible = false;
                toolStrip3.Visible = false;
                this.Size = new System.Drawing.Size(1039, 640);
                publicoAlvoControl1.Dock = DockStyle.Fill;
            }
            else if (_novoItem)
            {
                toolStrip3.Visible = false;
                btnAnterior.Visible = false;
                btnExcluir.Visible = false;
                btnSalvarAlteracoes.Visible = false;
                btnProximo.Visible = false;
                txtProcurarPub.Visible = false;
                label1.Visible = false;
                this.Size = new System.Drawing.Size(1039, 640);
                publicoAlvoControl1.Dock = DockStyle.Fill;
            }
        }

        private void AtribuirPublicoAlvo()
        {
            publicoAlvoControl1.AtribuirPublicoAlvo(_publicoAlvo);
        }

        private void FrmPublicoAlvo_Load(object sender, EventArgs e)
        {
            publicoAlvoControl1.utils = this.utils;
        }
    }
}
