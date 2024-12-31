using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBAM.Classes
{
    public class CatalogoProduto
    {
        public int Id { get; set; }
        public Guid ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public int CatalogoId { get; set; }
        public Catalogo Catalogo { get; set; }
    }

}
