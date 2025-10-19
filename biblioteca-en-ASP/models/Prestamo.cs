using System;


namespace BibliotecaApp.Core.Models
{
    public class Prestamo
    {
        public int Id { get; set; }
        public int LibroId { get; set; }
        public int PersonaId { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucionEsperada { get; set; }
        public DateTime? FechaDevolucionReal { get; set; }
    }
}