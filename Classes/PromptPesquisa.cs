using AIBAM.Classes.BancoDados;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBAM.Classes
{
    public class PromptPesquisa
    {
        public PromptPesquisa() {
            this.briefingPesquisa = new();
        }
        public int Id { get; set; }
        public string DescricaoPrompt {get;set;}
        public string ModeloPesquisa { get; set; }
        public BriefingPesquisa briefingPesquisa { get; set; }
    }
    public class PromptPesquisaService
    {
        private readonly AibamDbContext _db;

        public PromptPesquisaService(AibamDbContext db)
        {
            _db = db;
        }
        public async Task AdcionarPromptPesquisa(PromptPesquisa PromptPesquisa)
        {
            _db.PromptsPesquisa.Add(PromptPesquisa);
            await _db.SaveChangesAsync();
        }
        public async Task<PromptPesquisa> ObterPromptPesquisaPorIdAsync(int id)
        {
            return await _db.PromptsPesquisa.FindAsync(id);
        }
        public async Task AtualizarPromptPesquisaAsync(PromptPesquisa PromptPesquisa)
        {
            _db.PromptsPesquisa.Update(PromptPesquisa);
            await _db.SaveChangesAsync();
        }

        public async Task RemoverPromptPesquisaAsync(int id)
        {
            var PromptPesquisa = await ObterPromptPesquisaPorIdAsync(id);
            if (PromptPesquisa != null)
            {
                _db.PromptsPesquisa.Remove(PromptPesquisa);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<List<PromptPesquisa>> ListarPromptPesquisaAsync()
        {
            return await _db.PromptsPesquisa.ToListAsync();
        }
    }
}
