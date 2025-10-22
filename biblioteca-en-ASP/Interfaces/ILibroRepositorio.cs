using biblioteca_en_ASP_NET.Models;
using System.Collections.Generic;

namespace biblioteca_en_ASP_NET.Interfaces
{
    public interface ILibroRepositorio
    {
        IEnumerable<Libro> ObtenerLibros();
        void AgregarLibro(Libro libro);
        void ActualizarLibro(Libro libro);
        Libro ObtenerPorId(int id);
    }
}
