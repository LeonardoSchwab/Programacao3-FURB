using System.Collections.Generic;
using RestApi.Domain.Models;
namespace RestApi.Domain.Interfaces
{
    public interface ICarroRepository
    {
        List<Carro> ListAll();
        Carro GetById(int id);
        void Add(Carro carro);
        void Update(Carro carro);
        void DeleteById(int id);        
    }
}