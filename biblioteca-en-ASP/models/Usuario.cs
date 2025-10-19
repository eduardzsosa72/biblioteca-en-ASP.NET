namespace BibliotecaApp.Core.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public int PersonaId { get; set; }
        public string UserName { get; set; } // sAMAccountName o UPN
        public string Email { get; set; }
        public string Rol { get; set; } // "Administrador"|"Profesor"|"Estudiante"
    }
}