using System;

namespace biblioteca_en_ASP_NET.Models
{
    public class Profesor : Persona
    {
        private string departamento;
        private string empleadoId;

        public string Departamento { get => departamento; set => departamento = value; }
        public string EmpleadoId { get => empleadoId; set => empleadoId = value; }

        public override string MostrarInfo()
        {
            return $"Profesor: {Nombre} {Apellido}, ID: {EmpleadoId}, Departamento: {Departamento}";
        }
    }
}
