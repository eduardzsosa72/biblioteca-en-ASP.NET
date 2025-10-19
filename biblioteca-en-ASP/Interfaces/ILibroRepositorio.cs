using biblioteca_en_ASP_NET.Models;
using System.Collections.Generic;

namespace biblioteca_en_ASP_NET.Interfaces
{
    public interface ILibroRepositorio
    {
        IEnumerable<Libro> GetAll();
        Libro GetById(int id);
        void Add(Libro libro);
        void Update(Libro libro);
        void Delete(int id);
    }
}
