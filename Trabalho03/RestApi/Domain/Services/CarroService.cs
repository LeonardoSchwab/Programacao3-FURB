using System.Collections.Generic;
using RestApi.Domain.Interfaces;
using RestApi.Domain.Models;
namespace RestApi.Domain.Services
{
    public class CarroService : ICarroService
    {
        private readonly ICarroRepository repository;
        public CarroService(ICarroRepository repository)
        {
            this.repository = repository;
        }

        public void Add(Carro carro)
        {
            repository.Add(carro);
        }

        public void DeleteById(int id)
        {
            repository.DeleteById(id);
        }

        public Carro GetById(int id)
        {
            return repository.GetById(id);
        }

        public List<Carro> ListAll()
        {
            return repository.ListAll();
        }

        public void Update(Carro carro)
        {
            repository.Update(carro);
        }        
    }
}