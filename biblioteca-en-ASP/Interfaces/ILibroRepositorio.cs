using System.Collections.Generic;
using biblioteca_en_ASP_NET.Models;

namespace biblioteca_en_ASP_NET.Interfaces
{
    public interface ILibroRepositorio
    {
        IEnumerable<Libro> ObtenerTodos();
        Libro ObtenerPorId(int id);
        void Agregar(Libro libro);
        void Editar(Libro libro);
        void Eliminar(int id);
    }
}
