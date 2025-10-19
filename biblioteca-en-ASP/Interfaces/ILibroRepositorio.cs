using System.Collections.Generic;
using biblioteca_en_ASP_NET.Models;

namespace biblioteca_en_ASP_NET.Interfaces
{
    public interface ILibroRepositorio
    {
        IEnumerable<Libro> ObtenerLibros();    // Listar todos los libros
        Libro ObtenerPorId(int id);             // Obtener un libro por Id
        void AgregarLibro(Libro libro);        // Agregar nuevo libro
        void ActualizarLibro(Libro libro);     // Editar libro existente
        void EliminarLibro(int id);            // Eliminar libro (opcional)
    }
}
