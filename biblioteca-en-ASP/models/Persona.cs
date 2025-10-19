using System;


namespace BibliotecaApp.Core.Models
{
    public abstract class Persona
    {
        private int id;
        private string nombre;
        private string apellido;
        private string email;
        private DateTime fechaNacimiento;


        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Email { get => email; set => email = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }


        public virtual string MostrarInfo()
        {
            return $"{Nombre} {Apellido} - {Email}";
        }
    }
}