using System.Collections.Generic;
using System.Linq;
using biblioteca_en_ASP_NET.Models;
using biblioteca_en_ASP_NET.Interfaces;

namespace biblioteca_en_ASP_NET.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private static List<Usuario> _usuarios = new List<Usuario>();

        public Usuario ValidarUsuario(string correo, string password)
        {
            return _usuarios.FirstOrDefault(u => u.Correo == correo && u.Password == password);
        }

        public IEnumerable<Usuario> ObtenerUsuarios()
        {
            return _usuarios;
        }

        // Agregar este método para corregir el error
        public Usuario ObtenerPorId(int id)
        {
            return _usuarios.FirstOrDefault(u => u.Id == id);
        }
    }
}