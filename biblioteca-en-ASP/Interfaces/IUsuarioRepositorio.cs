using biblioteca_en_ASP_NET.Models;
using System.Collections.Generic;

namespace biblioteca_en_ASP_NET.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Usuario ValidarUsuario(string correo, string password);
        IEnumerable<Usuario> ObtenerUsuarios();

        // Métodos nuevos para registro
        int CrearPersona(Persona persona);
        void CrearUsuario(Usuario usuario);

        // Método para buscar usuario por Id
        Usuario ObtenerPorId(int id);
    }
}
