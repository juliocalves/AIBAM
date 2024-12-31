namespace AIBAM.Classes
{
    public class Produto
    {
        public Produto() { }
        #region PROPRIEDADES
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
        public Decimal PercentualDescontoPix { get; set; } = 3;
        public Decimal LucroUnidadePix { get; set; } = Decimal.Zero;
        public int? ColecaoId { get; set; }
        // Relacionamento muitos-para-muitos
        public ICollection<CatalogoProduto> Catalogos { get; set; } = new List<CatalogoProduto>();
        public List<string>? Imagens { get; set; }
        #endregion

        /// <summary>
        /// Calcula o valor do desconto e o lucro com base no valor promocional.
        /// </summary>
        /// <summary>
        /// Calcula o valor do desconto e o lucro com base no valor promocional.
        /// </summary>
        public void CalcularDescontoELucro()
        {
            // Verifica se os valores de entrada são válidos
            if (ValorVendaProd <= 0)
            {
                PercentualDesconto = 0;
                LucroUnidade = 0;
                return; // Encerra se o valor de venda for inválido
            }

            if (ValorVendaPromocional > 0)
            {
                // Calcula o valor do desconto e aplica o arredondamento
                decimal desconto = Math.Round(ValorVendaProd - ValorVendaPromocional, 2);
                PercentualDesconto = Math.Max(0, Math.Round((desconto / ValorVendaProd) * 100, 2));
            }
            else
            {
                PercentualDesconto = 0;
            }

            // Calcula o lucro, permitindo valores negativos, e aplica o arredondamento
            LucroUnidade = Math.Round(
                (ValorVendaPromocional > 0 ? ValorVendaPromocional : ValorVendaProd) - CustoProd,
                2
            );
        }

        public void AplicarDescontoPix()
        {
            
            if (DescontoPix)
            {
                if (ValorVendaPromocional > 0)
                {
                    LucroUnidadePix = Math.Round((ValorVendaPromocional -
                        (ValorVendaPromocional * (PercentualDescontoPix / 100))-CustoProd), 2);
                }
                else
                {
                    LucroUnidadePix = Math.Round((ValorVendaProd - 
                        (ValorVendaProd * (PercentualDescontoPix / 100)) - CustoProd), 2);
                }
            }
            else
            {
                LucroUnidadePix = 0;
                DescontoPix = false;
            }
        }
    }
}
