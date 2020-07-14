using System.Collections.Generic;
using RestApi.Domain.Models;
namespace RestApi.Domain.Services
{
    public interface IProdutoService
    {
        List<Produto> ListAll();
        Produto GetById(int id);
        void Add(Produto produto);
        void Update(Produto produto);
        void DeleteById(int id);        
    }
}