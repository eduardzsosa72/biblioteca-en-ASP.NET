using System;

namespace biblioteca_en_ASP_NET.Models
{

    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Correo { get; set; }
        public string TipoPersona { get; set; }

        public virtual string MostrarInfo()
        {
            return $"{TipoPersona}: {Nombre} {Apellido}";
        }
    }

}
