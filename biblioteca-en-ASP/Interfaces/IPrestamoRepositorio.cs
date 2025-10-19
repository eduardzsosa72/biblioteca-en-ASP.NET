using System.Collections.Generic;
using biblioteca_en_ASP_NET.Models;

namespace biblioteca_en_ASP_NET.Interfaces
{
    public interface IPrestamoRepositorio
    {
        IEnumerable<Prestamo> ObtenerTodos();
        void Registrar(Prestamo prestamo);
        void DevolverLibro(int id);
    }
}
