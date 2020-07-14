using System.Collections.Generic;
using System.Linq;
using RestApi.Domain.Interfaces;
using RestApi.Domain.Models;
namespace RestApi.Persistence.PostgreEF
{
    public class UsuarioRepositoryEF : IUsuarioRepository
    {
        private readonly UsuarioContext context;
        public UsuarioRepositoryEF(UsuarioContext context)
        {
            this.context = context;
        }

        public List<Usuario> ListAll()
        {
            return context.Usuario.ToList();
        }

        public Usuario GetById(int id)
        {
            var usuario = context.Usuario.SingleOrDefault(x => x.Id == id);
            return usuario;
        }

        public void Add(Usuario usuario)
        {
            context.Usuario.Add(usuario);
            context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var usuario = context.Usuario.SingleOrDefault(x => x.Id == id);
            if (usuario == null)
                return;
            context.Usuario.Remove(usuario);
            context.SaveChanges();
        }

        public void Update(Usuario usuario)
        {
            var persisted = context.Usuario.SingleOrDefault(x => x.Id == usuario.Id);
            if (persisted == null)
                return;
            persisted.Login = usuario.Login;
            persisted.Senha = usuario.Senha;            
            context.SaveChanges();
        }                
    }
}