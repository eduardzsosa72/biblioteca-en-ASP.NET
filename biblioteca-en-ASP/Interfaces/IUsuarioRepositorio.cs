using BibliotecaApp.Core.Models;


namespace biblioteca_en_ASP.NET.Interfaces

    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        Usuario ObtenerPorCorreo(string correo);
        bool ValidarCredencialesAD(string usuarioDominio, string contraseña);
    }
}