using System.Collections.Generic;
using System.Linq;
using RestApi.Domain.Interfaces;
using RestApi.Domain.Models;
namespace RestApi.Persistence.Memory
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private static int idCount = 1;
        private Dictionary<int, Usuario> usuarios = new Dictionary<int, Usuario>();

        public List<Usuario> ListAll()
        {
            return usuarios.Values.ToList();
        }

        public Usuario GetById(int id)
        {
            if (usuarios.ContainsKey(id))
                return usuarios[id];
            else
                return null;
        }
        public void Add(Usuario usuario)
        {
            usuario.Id = idCount++;
            usuarios.Add(usuario.Id, usuario);
        }

        public void Update(Usuario usuario)
        {
            if (usuarios.ContainsKey(usuario.Id))
                usuarios[usuario.Id] = usuario;
        }

        public void DeleteById(int id)
        {
            if (usuarios.ContainsKey(id))
                usuarios.Remove(id);
        }        
    }
}