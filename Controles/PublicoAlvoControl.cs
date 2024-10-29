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
        public PublicoAlvoControl()
        {
            InitializeComponent();
        }
        private void ParsePublicoAlvo()
        {
            publicoAlvo = new();
            utils = new();
            publicoAlvo.IdadeInicial = (int)nIdadeInicial.Value;
            publicoAlvo.IdadeFinal = (int)nIdadeFinal.Value;
            publicoAlvo.Genero = utils.ObterTextoGroupBox(gbGenero);
            publicoAlvo.NivelAcademico = cboNivelAcademico.Text;
            publicoAlvo.PropostaValor = txtPropostaValor.Text;
            publicoAlvo.Interesses = lstInteresses.GetItensSelecionados();
            publicoAlvo.Ocupacoes = lstOcupacoes.GetItensSelecionados();
            publicoAlvo.Dores = lstDores.GetItensSelecionados();
            publicoAlvo.DiferenciasCompetitivos = listDiferenciais.GetItensSelecionados();
            publicoAlvo.NivelConsciencia = utils.ObterTextoGroupBox(gbNivelConsciencia);
            publicoAlvo.OutrasInf = txtOutrasInf.Text;
        }
    }
}
