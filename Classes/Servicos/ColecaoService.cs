using AIBAM.Classes.BancoDados;
using Microsoft.EntityFrameworkCore;

namespace AIBAM.Classes.Servicos
{
    public class ColecaoService
    {
        private readonly AibamDbContext _db;

        public ColecaoService()
        {
            _db = new AibamDbContextFactory().CreateDbContext();
        }
        public async Task AdicionarColecao(Colecao colecao)
        {
            // Certifique-se de que o catálogo está correto
            if (colecao == null)
            {
                throw new ArgumentNullException(nameof(colecao));
            }

            var prods = colecao.ProdutoList;
            colecao.ProdutoList = new();
            _db.Colecoes.Add(colecao);
            await _db.SaveChangesAsync();

            foreach (var produto in prods)
            {
                produto.ColecaoId = colecao.Id;
                ProdutoService produtoService = new ProdutoService();
                await produtoService.AtualizarProdutoAsync(produto);
            }

        }

        public async Task<Colecao> ObterColecaoPorIdAsync(int id)
        {
            var cat = await _db.Colecoes.FindAsync(id);
            //ProdutoService produtoService = new ProdutoService();
            //var prods = await produtoService.ListarProdutoAsync();
            //cat.ProdutoList = prods.Where(x => x.CatalotoId == id).ToList();
            //PublicoAlvoService publicoAlvoService = new();
            //var pubs = await publicoAlvoService.
            return cat;
        }
        public async Task<Colecao> ObterColecaoPorNomeAsync(string nome)
        {
            // Busca usando LINQ e FirstOrDefaultAsync
            return await _db.Colecoes
                .AsNoTracking() // Evita rastreamento para melhorar a performance em consultas simples
                .FirstOrDefaultAsync(c => c.Nome == nome); // Filtra pelo nome
        }

        public async Task AtualizarColecaoAsync(Colecao Colecao)
        {
            _db.Colecoes.Update(Colecao);
            await _db.SaveChangesAsync();
        }

        public async Task RemoverColecaoAsync(int id)
        {
            var Colecao = await ObterColecaoPorIdAsync(id);
            if (Colecao != null)
            {
                _db.Colecoes.Remove(Colecao);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<List<Colecao>> ListarColecaoAsync()
        {
            return await _db.Colecoes.ToListAsync();
        }
    }

}
