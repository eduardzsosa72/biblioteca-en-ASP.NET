using System;
using System.ComponentModel.DataAnnotations;

namespace biblioteca_en_ASP_NET.Models
{
    public class Libro
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El autor es obligatorio.")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "El ISBN es obligatorio.")]
        [RegularExpression(@"^97[89]-\d{1,5}-\d{1,7}-\d{1,7}-\d{1}$", ErrorMessage = "Formato ISBN inválido. Ejemplo: 978-3-16-148410-0")]
        public string ISBN { get; set; }

        public int Cantidad { get; set; }

        public bool Disponible { get; set; } = true;
    }
}
