using biblioteca_en_ASP_NET.Interfaces;
using biblioteca_en_ASP_NET.Models;
using System.Collections.Generic;
using System.Linq;

namespace biblioteca_en_ASP_NET.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly List<Usuario> usuarios = new List<Usuario>();

        public IEnumerable<Usuario> GetAll()
        {
            return usuarios;
        }

        public Usuario GetById(int id)
        {
            return usuarios.FirstOrDefault(u => u.Id == id);
        }

        public Usuario GetByUsername(string username)
        {
            return usuarios.FirstOrDefault(u => u.Username == username);
        }

        public void Add(Usuario usuario)
        {
            if (usuarios.Any(u => u.Username == usuario.Username))
                throw new System.Exception("El usuario ya existe");
            usuarios.Add(usuario);
        }

        public void Update(Usuario usuario)
        {
            var existing = GetById(usuario.Id);
            if (existing != null)
            {
                existing.Username = usuario.Username;
                existing.Rol = usuario.Rol;
            }
        }

        public void Delete(int id)
        {
            var existing = GetById(id);
            if (existing != null)
                usuarios.Remove(existing);
        }
    }
}
