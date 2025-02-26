using AIBAM.Classes.BancoDados;

using Microsoft.EntityFrameworkCore;

namespace AIBAM.Classes.Servicos
{
    public class BriefingCopyService
    {
        private readonly AibamDbContext _db;

        public BriefingCopyService()
        {
            _db = new AibamDbContextFactory().CreateDbContext();
        }
        public async Task AdcionarBriefingCopy(BriefingCopy briefingCopy)
        {
            _db.BriefingsCopy.Add(briefingCopy);
            await _db.SaveChangesAsync();
        }
        public async Task<BriefingCopy> ObterBriefingCopyPorIdAsync(int id)
        {
            return await _db.BriefingsCopy.FindAsync(id);
        }
        public async Task AtualizarBriefingCopyAsync(BriefingCopy briefingCopy)
        {
            _db.BriefingsCopy.Update(briefingCopy);
            await _db.SaveChangesAsync();
        }

        public async Task RemoverBriefingCopyAsync(int id)
        {
            var BriefingCopy = await ObterBriefingCopyPorIdAsync(id);
            if (BriefingCopy != null)
            {
                _db.BriefingsCopy.Remove(BriefingCopy);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<List<BriefingCopy>> ListarBriefingCopyAsync()
        {
            return await _db.BriefingsCopy.ToListAsync();
        }
    }
}
