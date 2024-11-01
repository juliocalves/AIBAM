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
        public List<Produto> ProdutoList { get; set; }
    }
    public class Produto
    {
        public Produto() { }
        public Guid Id { get; set; } 
        public string NomeProd { get; set; }
        public Decimal CustoProd { get; set; } = Decimal.Zero;
        public Decimal ValorVendaProd { get; set; } = Decimal.Zero;
        public Decimal ValorVendaPromocional { get; set; } = Decimal.Zero;
        public Decimal PercentualDesconto { get; set; } = Decimal.Zero;
        public Decimal LucroUnidade { get; set; } = Decimal.Zero;
        public string LinkProd { get; set; }
        public string CategoriaProd { get; set; }
        public string GrupoProd { get; set; }
        public string DescricaoProd { get; set; }
        public List<string> TagsProd { get; set; }
        public bool DescontoPix { get; set; }


        /// <summary>
        /// Calcula o valor do desconto e o lucro com base no valor promocional.
        /// </summary>
        /// <returns>Uma tupla contendo o valor do desconto e o lucro.</returns>
        public void CalcularDescontoELucro()
        {
            // Verifica se os valores são válidos
            if (ValorVendaProd <= 0)
            {
                PercentualDesconto = 0;
                LucroUnidade = 0;
                return; // Se o valor de venda for inválido, não faz mais nada
            }
            // Calcula o valor do desconto
            decimal desconto = ValorVendaProd - ValorVendaPromocional;
         
            // Calcula o percentual de desconto
            decimal percentualDesconto = (desconto / ValorVendaProd) * 100;

            // Calcula o lucro
            decimal lucro = ValorVendaPromocional > 0
                ? ValorVendaPromocional - CustoProd
                : ValorVendaProd - CustoProd;

            // Armazena os resultados
            this.PercentualDesconto = ValorVendaPromocional > 0 ? Math.Max(0, percentualDesconto) : 0; // Garantir que o percentual não seja negativo
            this.LucroUnidade = lucro; // Garantir que o lucro não seja negativo
        }
        public void AplicarDescontoPix()
        {
            // Se não houver valor promocional, define o valor promocional igual ao valor de venda
            if (ValorVendaPromocional == 0)
            {
                ValorVendaPromocional = ValorVendaProd;
            }
            // Aplica o desconto adicional de 3% se o pagamento for via Pix
            if (DescontoPix)
            {
                
                ValorVendaPromocional -= ValorVendaPromocional * 0.03m; // Remove 3% do valor promocional
            }
            else
            {
                ValorVendaPromocional += ValorVendaPromocional * 0.03m;

                ValorVendaPromocional = ValorVendaPromocional == ValorVendaProd ? 0 : ValorVendaPromocional; // ou você pode manter o valor promocional atual
            }
        }

    }
}
