using AIBAM.Classes.BancoDados;
using Microsoft.EntityFrameworkCore;

namespace AIBAM.Classes.Servicos
{
    public class PublicoAlvoService
    {
        private readonly AibamDbContext _db;

        public PublicoAlvoService()
        {
            _db = new AibamDbContextFactory().CreateDbContext();
        }

        public async Task AdicionarPublicoAsync(PublicoAlvo publicoAlvo)
        {
            _db.PublicosAlvo.Add(publicoAlvo);
            await _db.SaveChangesAsync();
        }

        public async Task<PublicoAlvo> ObterPublicoAlvoPorIdAsync(int id)
        {
            return await _db.PublicosAlvo.FindAsync(id);
        }

        public async Task AtualizarPublicoAlvoAsync(PublicoAlvo publicoAlvo)
        {
            _db.PublicosAlvo.Update(publicoAlvo);
            await _db.SaveChangesAsync();
        }

        public async Task RemoverPublicoAlvoAsync(int id)
        {
            var publicoAlvo = await ObterPublicoAlvoPorIdAsync(id);
            if (publicoAlvo != null)
            {
                _db.PublicosAlvo.Remove(publicoAlvo);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<List<PublicoAlvo>> ListarPublicoAlvoAsync()
        {
            return await _db.PublicosAlvo.ToListAsync();
        }
    }
}
