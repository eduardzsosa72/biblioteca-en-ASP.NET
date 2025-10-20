namespace biblioteca_en_ASP_NET.Models
{
    public class Usuario
    {
        private int id;
        private string nombre;
        private string rol;
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Rol { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public int PersonaId { get; set; } // <-- Agregar esta propiedad
    }
}
