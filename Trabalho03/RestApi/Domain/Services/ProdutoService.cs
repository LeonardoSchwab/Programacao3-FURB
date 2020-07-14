using System.Collections.Generic;
using RestApi.Domain.Interfaces;
using RestApi.Domain.Models;
namespace RestApi.Domain.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository repository;
        public ProdutoService(IProdutoRepository repository)
        {
            this.repository = repository;
        }

        public void Add(Produto produto)
        {
            repository.Add(produto);
        }

        public void DeleteById(int id)
        {
            repository.DeleteById(id);
        }

        public Produto GetById(int id)
        {
            return repository.GetById(id);
        }

        public List<Produto> ListAll()
        {
            return repository.ListAll();
        }

        public void Update(Produto produto)
        {
            repository.Update(produto);
        }        
    }
}