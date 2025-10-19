using System;

namespace biblioteca_en_ASP_NET.Models
{
    public class Prestamo
    {
        public int Id { get; set; }
        public Persona Persona { get; set; }
        public Libro Libro { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }
    }
}
