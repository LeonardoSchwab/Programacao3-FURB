using System.Collections.Generic;
using System.Linq;
using RestApi.Domain.Interfaces;
using RestApi.Domain.Models;
namespace RestApi.Persistence.PostgreEF
{
    public class CarroRepositoryEF : ICarroRepository
    {
        private readonly CarroContext context;
        public CarroRepositoryEF(CarroContext context)
        {
            this.context = context;
        }

        public List<Carro> ListAll()
        {
            return context.Carro.ToList();
        }

        public Carro GetById(int id)
        {
            var carro = context.Carro.SingleOrDefault(x => x.Id == id);
            return carro;
        }

        public void Add(Carro carro)
        {
            context.Carro.Add(carro);
            context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var carro = context.Carro.SingleOrDefault(x => x.Id == id);
            if (carro == null)
                return;
            context.Carro.Remove(carro);
            context.SaveChanges();
        }

        public void Update(Carro carro)
        {
            var persisted = context.Carro.SingleOrDefault(x => x.Id == carro.Id);
            if (persisted == null)
                return;
            persisted.Nome = carro.Nome;
            persisted.Marca = carro.Marca;
            persisted.Modelo = carro.Modelo;            
            context.SaveChanges();
        }        
    }
}