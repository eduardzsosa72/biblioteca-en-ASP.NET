using biblioteca_en_ASP_NET.Interfaces;
using biblioteca_en_ASP_NET.Models;
using System.Collections.Generic;
using System.Linq;

namespace biblioteca_en_ASP_NET.Repositorios
{
    public class LibroRepositorio : ILibroRepositorio
    {
        private static List<Libro> libros = new List<Libro>
        {
            new Libro { Id = 1, Titulo = "Cien años de soledad", Autor = "Gabriel García Márquez", ISBN = "978-3-16-148410-0", Disponible = true },
            new Libro { Id = 2, Titulo = "El Principito", Autor = "Antoine de Saint-Exupéry", ISBN = "978-0-14-132872-2", Disponible = true }
        };

        public IEnumerable<Libro> ObtenerTodos() => libros;

        public Libro ObtenerPorId(int id) => libros.FirstOrDefault(l => l.Id == id);

        public void Agregar(Libro libro)
        {
            libro.Id = libros.Count + 1;
            libros.Add(libro);
        }

        public void Editar(Libro libro)
        {
            var existente = ObtenerPorId(libro.Id);
            if (existente != null)
            {
                existente.Titulo = libro.Titulo;
                existente.Autor = libro.Autor;
                existente.ISBN = libro.ISBN;
                existente.Disponible = libro.Disponible;
            }
        }

        public void Eliminar(int id)
        {
            var libro = ObtenerPorId(id);
            if (libro != null)
                libros.Remove(libro);
        }
    }
}
