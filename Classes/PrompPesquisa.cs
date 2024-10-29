using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBAM.Classes
{
    public class PrompPesquisa
    {
        public PrompPesquisa() {
            this.briefingPesquisa = new();
        }
        public string DescricaoPrompt {get;set;}
        public string ModeloPesquisa { get; set; }
        public BriefingPesquisa briefingPesquisa { get; set; }
    }
}
