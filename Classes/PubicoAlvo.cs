using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBAM.Classes
{
    /// <summary>
    /// Classe representativa de Pesona ou Personas Publico Alvo
    /// </summary>
    public class PubicoAlvo
    {
        public int IdadeInicial {  get; set; }
        public int IdadeFinal { get; set; }
        public string NivelAcademico {  get; set; }
        public List<string> Interesses { get; set; }
        public List<string> Ocupacoes { get; set; }
        public List<string> Dores { get; set; }
        public List<string> DiferenciasCompetitivos { get; set; }
        public string PropostaValor { get; set; }
        public string NivelConsciencia { get; set; }
        public string Genero { get; set; }
        public string OutrasInf { get; set; }
    }
}
