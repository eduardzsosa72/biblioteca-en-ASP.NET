using System;
using System.Text.RegularExpressions;

namespace biblioteca_en_ASP_NET.Models
{
    public class Libro
    {
        private int id;
        private string titulo;
        private string autor;
        private string isbn;

        public int Id { get => id; set => id = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Autor { get => autor; set => autor = value; }
        public string ISBN
        {
            get => isbn;
            set
            {
                if (!ValidarISBN(value))
                    throw new Exception("ISBN no válido");
                isbn = value;
            }
        }

        private bool ValidarISBN(string isbn)
        {
            // Expresión regular simple para ISBN-13
            string pattern = @"^\d{3}-\d{1,5}-\d{1,7}-\d{1,7}-\d{1}$";
            return Regex.IsMatch(isbn, pattern);
        }
    }
}
