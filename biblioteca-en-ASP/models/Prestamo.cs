using System;

namespace biblioteca_en_ASP_NET.Models
{
    public class Prestamo
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int LibroId { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }

        public Libro Libro { get; set; }
        public Usuario Usuario { get; set; }
    }
}
