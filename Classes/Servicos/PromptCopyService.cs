using AIBAM.Classes.BancoDados;
using Microsoft.EntityFrameworkCore;

namespace AIBAM.Classes.Servicos
{
    public class PromptCopyService
    {
        private readonly AibamDbContext _db;

        public PromptCopyService()
        {
            _db = new AibamDbContextFactory().CreateDbContext();
        }
        public async Task AdcionarPromptCopy(PromptCopy PromptCopy)
        {
            _db.PromptsCopy.Add(PromptCopy);
            await _db.SaveChangesAsync();
        }
        public async Task<PromptCopy> ObterPromptCopyPorIdAsync(int id)
        {
            return await _db.PromptsCopy.FindAsync(id);
        }
        public async Task AtualizarPromptCopyAsync(PromptCopy PromptCopy)
        {
            _db.PromptsCopy.Update(PromptCopy);
            await _db.SaveChangesAsync();
        }

        public async Task RemoverPromptCopyAsync(int id)
        {
            var PromptCopy = await ObterPromptCopyPorIdAsync(id);
            if (PromptCopy != null)
            {
                _db.PromptsCopy.Remove(PromptCopy);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<List<PromptCopy>> ListarPromptCopyAsync()
        {
            return await _db.PromptsCopy.ToListAsync();
        }
    }
}
