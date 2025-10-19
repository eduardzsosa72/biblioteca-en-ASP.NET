namespace BibliotecaApp.Core.Models
{
    public class Libro
    {
        private int id;
        private string titulo;
        private string isbn;
        private string autor;
        private int cantidadDisponible;


        public int Id { get => id; set => id = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string ISBN { get => isbn; set => isbn = value; }
        public string Autor { get => autor; set => autor = value; }
        public int CantidadDisponible { get => cantidadDisponible; set => cantidadDisponible = value; }
    }
}