using biblioteca_en_ASP_NET.Models;
using biblioteca_en_ASP_NET.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Configuration;


namespace biblioteca_en_ASP_NET.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly string _connectionString;

        public UsuarioRepositorio()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["ConexionSQL"].ConnectionString;
        }

        public Usuario ValidarUsuario(string correo, string password)
        {
            Usuario usuario = null;

            using (var conexion = new SqlConnection(_connectionString))
            {
                conexion.Open();
                var query = "SELECT * FROM Usuarios WHERE Correo = @Correo AND Password = @Password";

                using (var cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@Correo", correo);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario = new Usuario
                            {
                                Id = (int)reader["Id"],
                                PersonaId = (int)reader["PersonaId"],
                                Correo = reader["Correo"].ToString(),
                                Password = reader["Password"].ToString(),
                                Rol = reader["Rol"].ToString()
                            };
                        }
                    }
                }
            }

            return usuario;
        }

        public IEnumerable<Usuario> ObtenerUsuarios()
        {
            var lista = new List<Usuario>();

            using (var conexion = new SqlConnection(_connectionString))
            {
                conexion.Open();
                var query = "SELECT * FROM Usuarios";
                using (var cmd = new SqlCommand(query, conexion))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Usuario
                        {
                            Id = (int)reader["Id"],
                            PersonaId = (int)reader["PersonaId"],
                            Correo = reader["Correo"].ToString(),
                            Rol = reader["Rol"].ToString()
                        });
                    }
                }
            }

            return lista;
        }

       
        public Usuario ObtenerPorId(int id)
        {
            Usuario usuario = null;

            using (var conexion = new SqlConnection(_connectionString))
            {
                conexion.Open();
                var query = "SELECT * FROM Usuarios WHERE Id = @Id";
                using (var cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario = new Usuario
                            {
                                Id = (int)reader["Id"],
                                PersonaId = (int)reader["PersonaId"],
                                Correo = reader["Correo"].ToString(),
                                Rol = reader["Rol"].ToString()
                            };
                        }
                    }
                }
            }

            return usuario;
        }

      
        public int CrearPersona(Persona persona)
        {
            int personaId = 0;

            using (var conexion = new SqlConnection(_connectionString))
            {
                conexion.Open();
                var query = @"INSERT INTO Personas (Nombre, Apellido, Correo, FechaNacimiento, TipoPersona)
                              OUTPUT INSERTED.Id
                              VALUES (@Nombre, @Apellido, @Correo, @FechaNacimiento, @TipoPersona)";

                using (var cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@Nombre", persona.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", persona.Apellido);
                    cmd.Parameters.AddWithValue("@Correo", persona.Correo);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", persona.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@TipoPersona", persona.TipoPersona);

                    personaId = (int)cmd.ExecuteScalar();
                }
            }

            return personaId;
        }

     
        public void CrearUsuario(Usuario usuario)
        {
            using (var conexion = new SqlConnection(_connectionString))
            {
                conexion.Open();
                var query = @"INSERT INTO Usuarios (PersonaId, Correo, Password, Rol)
                              VALUES (@PersonaId, @Correo, @Password, @Rol)";

                using (var cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@PersonaId", usuario.PersonaId);
                    cmd.Parameters.AddWithValue("@Correo", usuario.Correo);
                    cmd.Parameters.AddWithValue("@Password", usuario.Password);
                    cmd.Parameters.AddWithValue("@Rol", usuario.Rol);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
