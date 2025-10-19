using biblioteca_en_ASP_NET.Models;
using System.Collections.Generic;

namespace biblioteca_en_ASP_NET.Interfaces
{
    public interface IPrestamoRepositorio
    {
        IEnumerable<Prestamo> GetAll();
        Prestamo GetById(int id);
        void Add(Prestamo prestamo);
        void Update(Prestamo prestamo);
        void Delete(int id);
    }
}
