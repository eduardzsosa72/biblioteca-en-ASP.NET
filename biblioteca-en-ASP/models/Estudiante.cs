using System;

namespace biblioteca_en_ASP_NET.Models
{
    public class Estudiante : Persona
    {
        private string carrera;
        private string matricula;

        public string Carrera { get => carrera; set => carrera = value; }
        public string Matricula { get => matricula; set => matricula = value; }

        public override string MostrarInfo()
        {
            return $"Estudiante: {Nombre} {Apellido}, Matrícula: {Matricula}, Carrera: {Carrera}";
        }
    }
}
