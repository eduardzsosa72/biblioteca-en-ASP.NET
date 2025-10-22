using biblioteca_en_ASP_NET.Models;
using System.Collections.Generic;

namespace biblioteca_en_ASP_NET.Interfaces
{
    public interface IPrestamoRepositorio
    {
        IEnumerable<Prestamo> ObtenerPrestamos();
        void CrearPrestamo(Prestamo prestamo);
    }
}
