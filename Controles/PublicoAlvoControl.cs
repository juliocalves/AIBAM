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

namespace AIBAM.Controles
{
    public partial class PublicoAlvoControl : UserControl
    {
        public PublicoAlvo publicoAlvo;
        internal Utils utils;
        // Delegado para atualizar o status no Form principal
        public Action<string>? statusUpdater;
        public PublicoAlvoControl()
        {
            InitializeComponent();
        }
        private void ParsePublicoAlvo()
        {
            publicoAlvo = new();
            utils = new(statusUpdater);
            publicoAlvo.IdadeInicial = (int)nIdadeInicial.Value;
            publicoAlvo.IdadeFinal = (int)nIdadeFinal.Value;
            publicoAlvo.Genero = utils.ObterTextoGroupBox(gbGenero);
            publicoAlvo.NivelAcademico = cboNivelAcademico.Text;
            publicoAlvo.Interesses = lstInteresses.GetItensSelecionados();
            publicoAlvo.Ocupacoes = lstOcupacoes.GetItensSelecionados();
            publicoAlvo.Dores = lstDores.GetItensSelecionados();
            publicoAlvo.NivelConsciencia = utils.ObterTextoGroupBox(gbNivelConsciencia);
            publicoAlvo.OutrasInf = txtOutrasInf.Text;
        }
    }
}
