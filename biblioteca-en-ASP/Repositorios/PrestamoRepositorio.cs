using System.Collections.Generic;
using System.Linq;
using biblioteca_en_ASP_NET.Models;
using biblioteca_en_ASP_NET.Interfaces;

namespace biblioteca_en_ASP_NET.Repositorios
{
    public class PrestamoRepositorio : IPrestamoRepositorio
    {
        private static List<Prestamo> prestamos = new List<Prestamo>();
        private readonly LibroRepositorio libroRepo = new LibroRepositorio();
        private readonly UsuarioRepositorio usuarioRepo = new UsuarioRepositorio();

        public IEnumerable<Prestamo> ObtenerPrestamos()
        {
            // Asignamos las propiedades de navegación Libro y Usuario
            foreach (var p in prestamos)
            {
                p.Libro = libroRepo.ObtenerPorId(p.LibroId);
                p.Usuario = usuarioRepo.ObtenerPorId(p.UsuarioId);
            }
            return prestamos;
        }

        public Prestamo ObtenerPorId(int id)
        {
            var p = prestamos.FirstOrDefault(x => x.Id == id);
            if (p != null)
            {
                p.Libro = libroRepo.ObtenerPorId(p.LibroId);
                p.Usuario = usuarioRepo.ObtenerPorId(p.UsuarioId);
            }
            return p;
        }

        public void AgregarPrestamo(Prestamo prestamo)
        {
            prestamo.Id = prestamos.Count > 0 ? prestamos.Max(p => p.Id) + 1 : 1;
            prestamos.Add(prestamo);
        }

        public void ActualizarPrestamo(Prestamo prestamo)
        {
            var p = ObtenerPorId(prestamo.Id);
            if (p != null)
            {
                p.LibroId = prestamo.LibroId;
                p.UsuarioId = prestamo.UsuarioId;
                p.FechaPrestamo = prestamo.FechaPrestamo;
                p.FechaDevolucion = prestamo.FechaDevolucion;
            }
        }

        public void EliminarPrestamo(int id)
        {
            var p = ObtenerPorId(id);
            if (p != null) prestamos.Remove(p);
        }
    }
}
