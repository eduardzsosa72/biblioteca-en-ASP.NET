using System;

namespace biblioteca_en_ASP_NET.Models
{
    public class Prestamo
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int LibroId { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }

        // Relación (no obligatoria pero útil en vistas)
        public virtual Usuario Usuario { get; set; }
        public virtual Libro Libro { get; set; }
    }
}
