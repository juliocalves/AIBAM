using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBAM.Classes
{
    public class Navegador<T>
    {
        private readonly IList<T> _itens;
        private int _indiceAtual;

        public Navegador(IList<T> itens)
        {
            _itens = itens ?? throw new ArgumentNullException(nameof(itens));
            _indiceAtual = 0; // Começa no primeiro item
        }

        // Propriedade para acessar o item atual
        public T ItemAtual => _itens.Count > 0 ? _itens[_indiceAtual] : default;

        // Método para ir ao próximo item
        public bool Proximo()
        {
            if (_indiceAtual < _itens.Count - 1)
            {
                _indiceAtual++;
                return true;
            }
            return false; // Fim da coleção
        }

        // Método para ir ao item anterior
        public bool Anterior()
        {
            if (_indiceAtual > 0)
            {
                _indiceAtual--;
                return true;
            }
            return false; // Início da coleção
        }

        // Método para reiniciar a navegação
        public void Reiniciar()
        {
            _indiceAtual = 0;
        }
        

        // Método para verificar se há próximo item
        public bool TemProximo() => _indiceAtual < _itens.Count - 1;

        // Método para verificar se há item anterior
        public bool TemAnterior() => _indiceAtual > 0;
    }

}
