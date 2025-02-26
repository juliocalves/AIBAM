namespace AIBAM.Classes
{
    public class Catalogo
    {
        public int Id { get; set; } 
        // Relacionamento muitos-para-muitos
        public ICollection<CatalogoProduto> Produtos { get; set; } = new List<CatalogoProduto>();
    }
}