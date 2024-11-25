using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBAM.Classes
{
    public class Catalogo
    {
        public Catalogo() { 
        
            this.ProdutoList = new List<Produto>();
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<Produto> ProdutoList { get; set; }
        // Relacionamento muitos-para-muitos
       // public ICollection<CatalogoProduto> Produtos { get; set; } = new List<CatalogoProduto>();
        public PublicoAlvo PublicoAlvo { get; set; }
        public int PublicoAlvoId { get; set; }
        public int ProdutoCount { get; set; } = 0;
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime DataAtualizacao { get; set; }
        public decimal LucroMedio { get; set; }
        public decimal CustoMedio { get; set; }
        public bool AtivoInativo { get; set; }

        public void AdicionarProdutoCatalogo(Produto produto)
        {
            ProdutoList.Add(produto);
            ProdutoCount = ProdutoList.Count;
            CalcularCustoMedio();
            CalcularLucroMedio();
        }
        public void RemoverProdutoCatalogo(Produto produto)
        {
            ProdutoList.Remove(produto);
            ProdutoCount = ProdutoList.Count;
            CalcularCustoMedio();
            CalcularLucroMedio();
        }
        // Calcula o custo médio
        public decimal CalcularCustoMedio()
        {
            if (ProdutoCount == 0) return 0; // Evita divisão por zero
            return ProdutoList.Sum(p => p.CustoProd) / ProdutoCount;
        }

        // Calcula o lucro médio
        public decimal CalcularLucroMedio()
        {
            if (ProdutoCount == 0) return 0; // Evita divisão por zero
            return ProdutoList.Sum(p => p.LucroUnidade) / ProdutoCount;
        }
    }

}
