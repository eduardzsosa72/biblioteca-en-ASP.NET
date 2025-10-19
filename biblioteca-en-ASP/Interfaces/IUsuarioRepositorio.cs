using biblioteca_en_ASP_NET.Models;
using System.Collections.Generic;

namespace biblioteca_en_ASP_NET.Interfaces
{
    public interface IUsuarioRepositorio
    {
        IEnumerable<Usuario> GetAll();
        Usuario GetById(int id);
        Usuario GetByUsername(string username);
        void Add(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(int id);
    }
}
