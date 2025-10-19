using System.Collections.Generic;

namespace ProyectoBiblioteca.Interfaces
{
    public interface IRepositorio<T>
    {
        IEnumerable<T> ObtenerTodos();
        T ObtenerPorId(int id);
        void Agregar(T entidad);
        void Actualizar(T entidad);
        void Eliminar(int id);
    }
}
