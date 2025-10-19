using System.Collections.Generic;
using biblioteca_en_ASP_NET.Models;

namespace biblioteca_en_ASP_NET.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Usuario ValidarUsuario(string correo, string password);

        // Agregamos este método para listar todos los usuarios
        IEnumerable<Usuario> ObtenerUsuarios();
    }
}
