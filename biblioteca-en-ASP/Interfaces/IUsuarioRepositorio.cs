using biblioteca_en_ASP_NET.Models;

namespace biblioteca_en_ASP_NET.Interfaces
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        Usuario ValidarUsuario(string correo, string password);
    }
}
