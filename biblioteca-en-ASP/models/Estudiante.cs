using System;


namespace BibliotecaApp.Core.Models
{
    public class Estudiante : Persona
    {
        private string matricula;
        public string Matricula { get => matricula; set => matricula = value; }


        public override string MostrarInfo()
        {
            return $"Estudiante: {Nombre} {Apellido}, Matrícula: {Matricula}";
        }
    }
}