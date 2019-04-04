using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Transportadora.Models;
using Transportadora.Repositories;

namespace Transportadora
{
    public partial class Startup
    {
        class DataService : IDataService
        {
            private readonly ApplicationContext contexto;
            private readonly IProdutoRepository produtoRepository;

            public DataService(ApplicationContext contexto,
                IProdutoRepository produtoRepository)
            {
                this.contexto = contexto;
                this.produtoRepository = produtoRepository;
            }

            public void InicializaDB()
            {
                contexto.Database.EnsureCreated();
                List<ProdutoItem> Itens = GetLivros();
                produtoRepository.SaveProdutos(Itens);
            }

            

            private static List<ProdutoItem> GetLivros()
            {
                var json = File.ReadAllText("produtos.json");
                var Itens = JsonConvert.DeserializeObject<List<ProdutoItem>>(json);
                return Itens;
            }
        }

        
    }
}
