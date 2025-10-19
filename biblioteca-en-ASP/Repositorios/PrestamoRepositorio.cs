using biblioteca_en_ASP_NET.Interfaces;
using biblioteca_en_ASP_NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace biblioteca_en_ASP_NET.Repositorios
{
    public class PrestamoRepositorio : IPrestamoRepositorio
    {
        private static List<Prestamo> prestamos = new List<Prestamo>();
        private readonly ILibroRepositorio _libroRepo = new LibroRepositorio();

        public IEnumerable<Prestamo> ObtenerTodos() => prestamos;

        public void Registrar(Prestamo prestamo)
        {
            var libro = _libroRepo.ObtenerPorId(prestamo.LibroId);
            if (libro != null && libro.Disponible)
            {
                libro.Disponible = false;
                prestamo.Id = prestamos.Count + 1;
                prestamo.FechaPrestamo = DateTime.Now;
                prestamo.FechaDevolucionEsperada = DateTime.Now.AddDays(7);
                prestamos.Add(prestamo);
            }
        }

        public void DevolverLibro(int id)
        {
            var prestamo = prestamos.FirstOrDefault(p => p.Id == id);
            if (prestamo != null)
            {
                prestamo.FechaDevolucionReal = DateTime.Now;
                var libro = _libroRepo.ObtenerPorId(prestamo.LibroId);
                if (libro != null)
                    libro.Disponible = true;
            }
        }
    }
}
