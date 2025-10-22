using System;

public class Persona
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Correo { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string TipoPersona { get; set; }

    // Implementación base, se puede sobreescribir
    public virtual string MostrarInfo()
    {
        return $"Nombre: {Nombre} {Apellido}";
    }
}
