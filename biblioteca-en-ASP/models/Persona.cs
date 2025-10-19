using System;

namespace biblioteca_en_ASP_NET.Models
{
    public abstract class Persona
    {
        private int id;
        private string nombre;
        private string apellido;
        private DateTime fechaNacimiento;
        private string correo;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Correo { get => correo; set => correo = value; }

        public abstract string MostrarInfo();
    }
}
