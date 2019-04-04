using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transportadora.Models;
using static Transportadora.Startup;

namespace Transportadora.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public IList<Produto> GetProdutos()
        {
            return dbSet.ToList();
        }

        public void SaveProdutos(List<ProdutoItem> Itens)
        {
            foreach (var Item in Itens)
            {
                if (!dbSet.Where(p => p.Codigo == Item.Codigo).Any())
                {
                    dbSet.Add(new Produto(Item.Codigo, Item.Nome, Item.Preco, Item.Horas));

                }
            }
            contexto.SaveChanges();
        }
    }

    public class ProdutoItem
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Horas { get; set; }
    }
}
