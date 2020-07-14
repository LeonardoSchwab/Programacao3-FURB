using System.Collections.Generic;
using System.Linq;
using RestApi.Domain.Interfaces;
using RestApi.Domain.Models;
namespace RestApi.Persistence.PostgreEF
{
    public class ProdutoRepositoryEF : IProdutoRepository
    {
        private readonly ProdutoContext context;
        public ProdutoRepositoryEF(ProdutoContext context)
        {
            this.context = context;
        }

        public List<Produto> ListAll()
        {
            return context.Produto.ToList();
        }

        public Produto GetById(int id)
        {
            var produto = context.Produto.SingleOrDefault(x => x.Id == id);
            return produto;
        }

        public void Add(Produto produto)
        {
            context.Produto.Add(produto);
            context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var produto = context.Produto.SingleOrDefault(x => x.Id == id);
            if (produto == null)
                return;
            context.Produto.Remove(produto);
            context.SaveChanges();
        }

        public void Update(Produto produto)
        {
            var persisted = context.Produto.SingleOrDefault(x => x.Id == produto.Id);
            if (persisted == null)
                return;
            persisted.Nome = produto.Nome;
            persisted.Preco = produto.Preco;                     
            context.SaveChanges();
        }        
    }
}