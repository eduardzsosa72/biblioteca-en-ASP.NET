using System.Collections.Generic;
using biblioteca_en_ASP_NET.Models;
using biblioteca_en_ASP_NET.Interfaces;
using System.Linq;

namespace biblioteca_en_ASP_NET.Repositorios
{
    public class LibroRepositorio : ILibroRepositorio
    {
        private static List<Libro> libros = new List<Libro>();

        public IEnumerable<Libro> ObtenerLibros()
        {
            return libros;
        }

        public Libro ObtenerPorId(int id)
        {
            return libros.FirstOrDefault(l => l.Id == id);
        }

        public void AgregarLibro(Libro libro)
        {
            libro.Id = libros.Count > 0 ? libros.Max(l => l.Id) + 1 : 1;
            libros.Add(libro);
        }

        public void ActualizarLibro(Libro libro)
        {
            var l = ObtenerPorId(libro.Id);
            if (l != null)
            {
                l.Titulo = libro.Titulo;
                l.Autor = libro.Autor;
                l.ISBN = libro.ISBN;
                l.Cantidad = libro.Cantidad;
            }
        }

        public void EliminarLibro(int id)
        {
            var libro = ObtenerPorId(id);
            if (libro != null)
                libros.Remove(libro);
        }
    }
}
