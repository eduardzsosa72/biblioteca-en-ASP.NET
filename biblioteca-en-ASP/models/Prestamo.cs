using System;

namespace biblioteca_en_ASP_NET.Models
{
    public class Prestamo
    {
        public int Id { get; set; }
        public string UsuarioCorreo { get; set; }   // Correo del usuario (Profesor o Estudiante)
        public int LibroId { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucionEsperada { get; set; }
        public DateTime? FechaDevolucionReal { get; set; }
    }
}
