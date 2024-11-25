using AIBAM.Classes.BancoDados;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;

namespace AIBAM.Classes
{
    public class BriefingPesquisa
    {
        #region PROPRIEDADES
        public int Id { get; set; }
        // Dados Básicos do Projeto
        public string TituloProjeto { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        //public List<string> Responsaveis { get; set; } = new List<string>();

        // Objetivo da Pesquisa
        public string ObjetivoGeral { get; set; }
        public List<string> ObjetivosEspecificos { get; set; } = new List<string>();
        public string PerguntaPesquisa { get; set; }

        // Justificativa e Contexto
        public string Justificativa { get; set; }
        public string ContextoProblema { get; set; }

        // Público-Alvo
        public PublicoAlvo PerfilPublico { get; set; }
        public List<string> Segmentacao { get; set; } = new List<string>();
        public List<string> CriteriosInclusaoExclusao { get; set; }

        // Metodologia
        public string TipoPesquisa { get; set; }  // ex: Qualitativa, Quantitativa, Mista
        public List<string> MetodosColetaDados { get; set; } = new List<string>();  // ex: Entrevistas, Questionários
        public List<string> FerramentasPlataformas { get; set; } = new List<string>();
        public int TamanhoAmostra { get; set; }

        // Análise de Dados
        public string TecnicasAnalise { get; set; }  // ex: Estatística, Análise temática
        public List<string> IndicadoresChave { get; set; } = new List<string>();

        // Recursos Necessários
        public decimal Orçamento { get; set; }
        public List<string> RecursosHumanos { get; set; } = new List<string>();
        public List<string> MateriaisFerramentas { get; set; } = new List<string>();

        // Resultados Esperados
        public List<string> Hipoteses { get; set; } = new List<string>();
        public string ImpactoEsperado { get; set; }

        // Cronograma Detalhado
        public List<EtapaCronograma> Cronograma { get; set; } = new List<EtapaCronograma>();

        // Outras Observações
        public List<string> LimitacoesPesquisa { get; set; } = new List<string>();
        public List<string> FontesReferencias { get; set; } = new List<string>();
        public string ObservacoesAdicionais { get; set; }
        #endregion

        // Classe auxiliar para as etapas do cronograma
        public class EtapaCronograma
        {
            public int Id { get; set; }
            public string NomeEtapa { get; set; }
            public DateTime DataInicioEtapa { get; set; }
            public DateTime DataTerminoEtapa { get; set; }
        }

        // Método para exibir uma visão geral do briefing
        public override string ToString()
        {
            return $"Projeto: {TituloProjeto}\n" +
                   $"Objetivo Geral: {ObjetivoGeral}\n" +
                   $"Perfil do Público-Alvo: {PerfilPublico}\n" +
                   $"Orçamento: {Orçamento:C}\n" +
                   $"Data de Início: {DataInicio.ToShortDateString()} - Data de Término: {DataTermino.ToShortDateString()}\n";
        }
    }
    public class BriefingPesquisaService
    {
        private readonly AibamDbContext _db;

        public BriefingPesquisaService(AibamDbContext db)
        {
            _db = db;
        }
        public async Task AdcionarBriefingsPesquisa(BriefingPesquisa briefingPesquisa)
        {
            _db.BriefingsPesquisa.Add(briefingPesquisa);
            await _db.SaveChangesAsync();
        }
        public async Task<BriefingPesquisa> ObterBriefingsPesquisaPorIdAsync(int id)
        {
            return await _db.BriefingsPesquisa.FindAsync(id);
        }
        public async Task AtualizarBriefingsPesquisaAsync(BriefingPesquisa briefingPesquisa)
        {
            _db.BriefingsPesquisa.Update(briefingPesquisa);
            await _db.SaveChangesAsync();
        }

        public async Task RemoverBriefingsPesquisaAsync(int id)
        {
            var briefingPesquisa = await ObterBriefingsPesquisaPorIdAsync(id);
            if (briefingPesquisa != null)
            {
                _db.BriefingsPesquisa.Remove(briefingPesquisa);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<List<BriefingPesquisa>> ListarBriefingsPesquisaAsync()
        {
            return await _db.BriefingsPesquisa.ToListAsync();
        }
    }

}
