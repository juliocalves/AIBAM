using AIBAM.Classes.BancoDados;

using Microsoft.EntityFrameworkCore;

namespace AIBAM.Classes
{
    public class ProdutoService
    {
        private readonly AibamDbContext _db;

        public ProdutoService()
        {
            _db = new AibamDbContextFactory().CreateDbContext();
        }
        public async Task AdicionarProduto(Produto Produto)
        {
            _db.Produtos.Add(Produto);
            await _db.SaveChangesAsync();
        }
        public async Task<Produto> ObterProdutoPorIdAsync(Guid id)
        {
            return await _db.Produtos.FindAsync(id);
        }
        public async Task AtualizarProdutoAsync(Produto Produto)
        {
            _db.Produtos.Update(Produto);
            await _db.SaveChangesAsync();
        }

        public async Task RemoverProdutoAsync(Guid id)
        {
            var Produto = await ObterProdutoPorIdAsync(id);
            if (Produto != null)
            {
                _db.Produtos.Remove(Produto);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<List<Produto>> ListarProdutoAsync()
        {
            return await _db.Produtos.ToListAsync();
        }

        public async Task<Produto> ObterProdutoPorNomeAsync(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return null; // Retorna null se o texto for vazio ou apenas espaços em branco

            return await _db.Produtos
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.NomeProd.Contains(text));
        }
    }
}
