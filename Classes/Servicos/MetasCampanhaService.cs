using AIBAM.Classes.BancoDados;

using Microsoft.EntityFrameworkCore;

namespace AIBAM.Classes
{
    public class MetasCampanhaService
    {
        private readonly AibamDbContext _db;

        public MetasCampanhaService()
        {
            _db = new AibamDbContextFactory().CreateDbContext();
        }
        public async Task AdcionarMetasCampanha(MetasCampanha MetasCampanha)
        {
            _db.MetasCampanha.Add(MetasCampanha);
            await _db.SaveChangesAsync();
        }
        public async Task<MetasCampanha> ObterMetasCampanhaPorIdAsync(int id)
        {
            return await _db.MetasCampanha.FindAsync(id);
        }
        public async Task AtualizarMetasCampanhaAsync(MetasCampanha MetasCampanha)
        {
            _db.MetasCampanha.Update(MetasCampanha);
            await _db.SaveChangesAsync();
        }

        public async Task RemoverMetasCampanhaAsync(int id)
        {
            var MetasCampanha = await ObterMetasCampanhaPorIdAsync(id);
            if (MetasCampanha != null)
            {
                _db.MetasCampanha.Remove(MetasCampanha);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<List<MetasCampanha>> ListarMetasCampanhaAsync()
        {
            return await _db.MetasCampanha.ToListAsync();
        }
    }
}