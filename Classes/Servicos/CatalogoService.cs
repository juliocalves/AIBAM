using AIBAM.Classes.BancoDados;
using Microsoft.EntityFrameworkCore;

namespace AIBAM.Classes.Servicos
{
    public class CatalogoService
    {
        private readonly AibamDbContext _db;

        public CatalogoService()
        {
            _db = new AibamDbContextFactory().CreateDbContext();
        }
        public async Task AdicionarCatalogo(Catalogo catalogo)
        {
            // Certifique-se de que o catálogo está correto
            if (catalogo == null)
            {
                throw new ArgumentNullException(nameof(catalogo));
            }

            var prods = catalogo.ProdutoList;
            catalogo.ProdutoList = new();
            _db.Catalogos.Add(catalogo);
            await _db.SaveChangesAsync();

            foreach (var produto in prods)
            {
                produto.CatalotoId = catalogo.Id;
                ProdutoService produtoService = new ProdutoService();
                await produtoService.AtualizarProdutoAsync(produto);
            }

        }

        public async Task<Catalogo> ObterCatalogoPorIdAsync(int id)
        {
            var cat = await _db.Catalogos.FindAsync(id);
            //ProdutoService produtoService = new ProdutoService();
            //var prods = await produtoService.ListarProdutoAsync();
            //cat.ProdutoList = prods.Where(x => x.CatalotoId == id).ToList();
            //PublicoAlvoService publicoAlvoService = new();
            //var pubs = await publicoAlvoService.
            return cat;
        }
        public async Task<Catalogo> ObterCatalogoPorNomeAsync(string nome)
        {
            // Busca usando LINQ e FirstOrDefaultAsync
            return await _db.Catalogos
                .AsNoTracking() // Evita rastreamento para melhorar a performance em consultas simples
                .FirstOrDefaultAsync(c => c.Nome == nome); // Filtra pelo nome
        }

        public async Task AtualizarCatalogoAsync(Catalogo Catalogo)
        {
            _db.Catalogos.Update(Catalogo);
            await _db.SaveChangesAsync();
        }

        public async Task RemoverCatalogoAsync(int id)
        {
            var Catalogo = await ObterCatalogoPorIdAsync(id);
            if (Catalogo != null)
            {
                _db.Catalogos.Remove(Catalogo);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<List<Catalogo>> ListarCatalogoAsync()
        {
            return await _db.Catalogos.ToListAsync();
        }
    }

}
