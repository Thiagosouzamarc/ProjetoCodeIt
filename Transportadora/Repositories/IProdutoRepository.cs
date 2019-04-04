using System.Collections.Generic;
using Transportadora.Models;

namespace Transportadora.Repositories
{
    public interface IProdutoRepository
    {
        void SaveProdutos(List<ProdutoItem> Itens);
        IList<Produto> GetProdutos();
    }
}