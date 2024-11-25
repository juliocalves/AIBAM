using System.Linq;

namespace AIBAM.Classes
{
    /// <summary>
    /// Classe representativa de Pesona ou Personas Publico Alvo
    /// </summary>
    public class PublicoAlvo
    {
        #region PROPRIEDADES
        public int Id { get; set; }
        // Informações Gerais
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string? PropostaValor { get; set; }
        public string? NivelConsciencia { get; set; }
        public string? OutrasInformacoes { get; set; }

        // Segmentação Geográfica
        public string? Pais { get; set; }
        public string? Estado { get; set; }
        public string? Cidade { get; set; }
        public string? Regiao { get; set; }

        // Segmentação Demográfica
        public int IdadeInicial { get; set; }
        public int IdadeFinal { get; set; }
        public string? Genero { get; set; }
        public string? NivelAcademico { get; set; }
        public List<string>? Ocupacoes { get; set; }

        // Segmentação Comportamental
        public List<string>? Interesses { get; set; }
        public List<string>? Dores { get; set; }
        public List<string>? DiferenciaisCompetitivos { get; set; }

        // Segmentação de Volume
        public int TamanhoMercado { get; set; } // Tamanho do mercado-alvo em quantidade estimada
        public decimal? ReceitaAnualMedia { get; set; } // Receita média anual do público-alvo
        public decimal? TicketMedio { get; set; } // Valor médio gasto pelo público-alvo

        #endregion

        #region MÉTODOS


       

        #endregion


    }
}
