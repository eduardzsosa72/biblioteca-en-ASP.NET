namespace biblioteca_en_ASP_NET.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public int PersonaId { get; set; }
        public string Rol { get; set; }
        public string Password { get; set; }

        public Persona Persona { get; set; } // Información de la persona
    }
}
