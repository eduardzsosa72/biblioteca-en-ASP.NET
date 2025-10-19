using System.Collections.Generic;
using System.Linq;
using biblioteca_en_ASP_NET.Models;
using biblioteca_en_ASP_NET.Interfaces;

namespace biblioteca_en_ASP_NET.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly List<Usuario> _usuarios;

        public UsuarioRepositorio()
        {
            _usuarios = new List<Usuario>
            {
                new Usuario { Id = 1, Nombre = "Admin", Rol = "Administrador", Correo = "admin@biblioteca.com", Password = "admin123" },
                new Usuario { Id = 2, Nombre = "Juan", Rol = "Estudiante", Correo = "juan@biblioteca.com", Password = "12345" }
            };
        }

        public IEnumerable<Usuario> ObtenerTodos()
        {
            return _usuarios;
        }

        public Usuario ObtenerPorId(int id)
        {
            return _usuarios.FirstOrDefault(u => u.Id == id);
        }

        public void Agregar(Usuario entidad)
        {
            entidad.Id = _usuarios.Count + 1;
            _usuarios.Add(entidad);
        }

        public void Actualizar(Usuario entidad)
        {
            var existente = ObtenerPorId(entidad.Id);
            if (existente != null)
            {
                existente.Nombre = entidad.Nombre;
                existente.Correo = entidad.Correo;
                existente.Password = entidad.Password;
                existente.Rol = entidad.Rol;
            }
        }

        public void Eliminar(int id)
        {
            var usuario = ObtenerPorId(id);
            if (usuario != null)
                _usuarios.Remove(usuario);
        }

        public Usuario ValidarUsuario(string correo, string password)
        {
            return _usuarios.FirstOrDefault(u => u.Correo == correo && u.Password == password);
        }
    }
}
