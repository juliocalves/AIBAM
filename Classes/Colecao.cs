using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBAM.Classes
{
    public class Colecao
    {
        public Colecao() { 
        
            this.ProdutoList = new List<Produto>();
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public List<Produto>? ProdutoList { get; set; }
        
        public PublicoAlvo? PublicoAlvo { get; set; }
        public int? PublicoAlvoId { get; set; }
        public int? ProdutoCount { get; set; } = 0;
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime DataAtualizacao { get; set; }
        public decimal LucroMedio { get; set; } = 0;
        public decimal CustoMedio { get; set; } = 0;
        public bool AtivoInativo { get; set; } = true;

        public void AdicionarProdutoCatalogo(Produto produto)
        {
            ProdutoList.Add(produto);
            CalcularQtdProdutos();
            CalcularCustoMedio();
            CalcularLucroMedio();
        }
        public void RemoverProdutoCatalogo(Produto produto)
        {
            ProdutoList.Remove(produto);
            CalcularQtdProdutos();
            CalcularCustoMedio();
            CalcularLucroMedio();
        }
        public void CalcularQtdProdutos()
        {
            ProdutoCount = ProdutoList.Count;
        }
        // Calcula o custo médio
        public decimal CalcularCustoMedio()
        {
            if (ProdutoCount == 0) return 0; // Evita divisão por zero
            return (decimal)(ProdutoList.Sum(p => p.CustoProd) / ProdutoCount);
        }

        // Calcula o lucro médio
        public decimal CalcularLucroMedio()
        {
            if (ProdutoCount == 0) return 0; // Evita divisão por zero
            return (decimal)(ProdutoList.Sum(p => p.LucroUnidade) / ProdutoCount);
        }
    }

}
