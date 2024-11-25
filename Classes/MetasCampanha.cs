using AIBAM.Classes.BancoDados;

using Microsoft.EntityFrameworkCore;

namespace AIBAM.Classes
{
    public class MetasCampanha
    {
        public int Id { get; set; }
        public bool AdicaoCarrinho { get; set; }
        public bool CadastroFrm { get; set; }
        public bool Clickslink { get; set; }
        public bool Compartilhamentos { get; set; }
        public bool Desempenho { get; set; }
        public bool Engajamento { get; set; }
        public bool Interacao { get; set; }
        public bool PermanenciaPag { get; set; }
        public bool Registro { get; set; }
        public bool Seguidores { get; set; }
        public bool Vendas { get; set; }
        public bool Vizualizacoes { get; set; }
    }
    public class MetasCampanhaService
    {
        private readonly AibamDbContext _db;

        public MetasCampanhaService(AibamDbContext db)
        {
            _db = db;
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