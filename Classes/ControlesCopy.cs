using AIBAM.Classes.BancoDados;

using Microsoft.EntityFrameworkCore;

namespace AIBAM.Classes
{
    public class ControlesCopy
    {
        public int Id { get; set; } 
        public int Entonacao { get; set; }
        public int Originalidade { get; set; }
        public List<string>? Sentimento { get; set; }
        public string? Perspectiva { get; set; }
        public List<string>? PalavrasChave { get; set; }

    }
    public class ControlesCopyService
    {
        private readonly AibamDbContext _db;

        public ControlesCopyService(AibamDbContext db)
        {
            _db = db;
        }
        public async Task AdcionarControlesCopy(ControlesCopy ControlesCopy)
        {
            _db.ControlesCopy.Add(ControlesCopy);
            await _db.SaveChangesAsync();
        }
        public async Task<ControlesCopy> ObterControlesCopyPorIdAsync(int id)
        {
            return await _db.ControlesCopy.FindAsync(id);
        }
        public async Task AtualizarControlesCopyAsync(ControlesCopy ControlesCopy)
        {
            _db.ControlesCopy.Update(ControlesCopy);
            await _db.SaveChangesAsync();
        }

        public async Task RemoverControlesCopyAsync(int id)
        {
            var ControlesCopy = await ObterControlesCopyPorIdAsync(id);
            if (ControlesCopy != null)
            {
                _db.ControlesCopy.Remove(ControlesCopy);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<List<ControlesCopy>> ListarControlesCopyAsync()
        {
            return await _db.ControlesCopy.ToListAsync();
        }
    }
}