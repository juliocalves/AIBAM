using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBAM.Classes
{
    /// <summary>
    /// Classe representativa de Brieng para desenvolvimento de copy
    /// </summary>
    public class Briefing
    {
        public Briefing()
        {
            this.metasCampanhas = new();
        }

        public string? TipoVenda {  get; set; }
        public string? Marca { get; set; }
        public string? IdeiaPromovida { get; set; }
        public string? LinkSite { get; set; }
        public string? LinkCatalogoProdServ { get; set; }
        public string? SegmentoNegocio { get; set; }
        public string? SubSegmentoNegocio { get; set; }
        public string? ELancamentoProdServ { get; set; }
        public string? InformacoesProdServ { get; set; }
        public string? ObjetivoGeral { get; set; }
        public string? ObjetivoEspecifico { get; set; }
        public string? Observacoes { get; set; }
        public string? DestinoCopy { get; set; }
        public string? MensagemTransmitida { get; set; }
        public MetasCampanha? metasCampanhas { get; set; }
    }
}
