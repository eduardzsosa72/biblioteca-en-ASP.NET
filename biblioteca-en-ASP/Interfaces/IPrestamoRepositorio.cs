using System.Collections.Generic;
using biblioteca_en_ASP_NET.Models;

namespace biblioteca_en_ASP_NET.Interfaces
{
    public interface IPrestamoRepositorio
    {
        IEnumerable<Prestamo> ObtenerPrestamos(); // Listar todos los préstamos
        Prestamo ObtenerPorId(int id);            // Obtener préstamo por Id
        void AgregarPrestamo(Prestamo prestamo);  // Registrar nuevo préstamo
        void ActualizarPrestamo(Prestamo prestamo); // Actualizar préstamo (opcional)
        void EliminarPrestamo(int id);            // Eliminar préstamo (opcional)
    }
}
