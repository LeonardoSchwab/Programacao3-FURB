using System.Collections.Generic;
using RestApi.Domain.Interfaces;
using RestApi.Domain.Models;
namespace RestApi.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository repository;
        public UsuarioService(IUsuarioRepository repository)
        {
            this.repository = repository;
        }

        public void Add(Usuario usuario)
        {
            repository.Add(usuario);
        }

        public void DeleteById(int id)
        {
            repository.DeleteById(id);
        }

        public Usuario GetById(int id)
        {
            return repository.GetById(id);
        }

        public List<Usuario> ListAll()
        {
            return repository.ListAll();
        }

        public void Update(Usuario usuario)
        {
            repository.Update(usuario);
        }                
    }
}