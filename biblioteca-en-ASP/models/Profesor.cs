using System;


namespace BibliotecaApp.Core.Models
{
    public class Profesor : Persona
    {
        private string departamento;
        public string Departamento { get => departamento; set => departamento = value; }


        public override string MostrarInfo()
        {
            return $"Profesor: {Nombre} {Apellido}, Dept.: {Departamento}";
        }
    }
}