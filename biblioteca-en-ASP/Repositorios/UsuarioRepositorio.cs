using biblioteca_en_ASP_NET.Models;
using biblioteca_en_ASP_NET.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace biblioteca_en_ASP_NET.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private static List<Persona> _personas = new List<Persona>();
        private static List<Usuario> _usuarios = new List<Usuario>();
        private static int _nextPersonaId = 1;
        private static int _nextUsuarioId = 1;

        public Usuario ValidarUsuario(string correo, string password)
        {
            return _usuarios.FirstOrDefault(u => u.Correo == correo && u.Password == password);
        }

        public IEnumerable<Usuario> ObtenerUsuarios()
        {
            return _usuarios;
        }

        public int CrearPersona(Persona persona)
        {
            persona.Id = _nextPersonaId++;
            _personas.Add(persona);
            return persona.Id;
        }

        public void CrearUsuario(Usuario usuario)
        {
            usuario.Id = _nextUsuarioId++;
            _usuarios.Add(usuario);
        }

        // --- Método que faltaba ---
        public Usuario ObtenerPorId(int id)
        {
            return _usuarios.FirstOrDefault(u => u.Id == id);
        }

    }
}
