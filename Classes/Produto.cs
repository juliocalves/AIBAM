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
        public int CatalotoId { get; set; }
        // Relacionamento muitos-para-muitos
        // public ICollection<CatalogoProduto> Catalogos { get; set; } = new List<CatalogoProduto>();
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

        /// <summary>
        /// Aplica o desconto adicional de 3% para pagamentos via Pix.
        /// </summary>
        public void AplicarDescontoPix()
        {
            if (ValorVendaPromocional <= 0)
            {
                ValorVendaPromocional = ValorVendaProd; // Assume o valor original de venda
            }

            if (DescontoPix)
            {
                // Aplica o desconto Pix ao valor promocional, arredondado para duas casas decimais
                ValorVendaPromocional = Math.Round(ValorVendaPromocional * 0.97m, 2);
            }
            else
            {
                // Remove o desconto Pix (apenas se o valor promocional estiver ativo)
                ValorVendaPromocional = Math.Round(ValorVendaPromocional / 0.97m, 2);

                // Reseta o valor promocional caso ele seja igual ao valor de venda
                if (Math.Abs(ValorVendaProd - ValorVendaPromocional) < 0.01m) // Comparação para evitar erros de precisão
                {
                    ValorVendaPromocional = 0;
                }
            }
        }
    }
}
