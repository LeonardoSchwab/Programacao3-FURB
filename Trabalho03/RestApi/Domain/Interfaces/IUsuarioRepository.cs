using System.Collections.Generic;
using RestApi.Domain.Models;
namespace RestApi.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuario> ListAll();
        Usuario GetById(int id);
        void Add(Usuario usuario);
        void Update(Usuario usuario);
        void DeleteById(int id);        
    }
}