namespace biblioteca_en_ASP_NET.Models
{
    public class Usuario
    {
        private int id;
        private string username;
        private string rol;

        public int Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Rol { get => rol; set => rol = value; }
    }
}
