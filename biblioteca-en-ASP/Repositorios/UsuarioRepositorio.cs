using biblioteca_en_ASP_NET.Interfaces;
using biblioteca_en_ASP_NET.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;

namespace biblioteca_en_ASP_NET.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["BibliotecaDB"].ConnectionString;

        public Usuario ValidarUsuario(string correo, string password)
        {
            Usuario usuario = null;
            using (var con = new SqlConnection(_connectionString))
            {
                con.Open();
                var query = @"SELECT u.Id, u.PersonaId, u.Rol, u.Password,
                                     p.Nombre, p.Apellido, p.Correo
                              FROM Usuarios u
                              INNER JOIN Personas p ON u.PersonaId = p.Id
                              WHERE p.Correo = @Correo AND u.Password = @Password";

                using (var cmd = new SqlCommand(query, con))
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
                                Rol = reader["Rol"].ToString(),
                                Password = reader["Password"].ToString(),
                                Persona = new Persona
                                {
                                    Nombre = reader["Nombre"].ToString(),
                                    Apellido = reader["Apellido"].ToString(),
                                    Correo = reader["Correo"].ToString()
                                }
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
            using (var con = new SqlConnection(_connectionString))
            {
                con.Open();
                var query = @"SELECT u.Id, u.PersonaId, u.Rol, p.Nombre, p.Apellido, p.Correo
                              FROM Usuarios u
                              INNER JOIN Personas p ON u.PersonaId = p.Id";

                using (var cmd = new SqlCommand(query, con))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Usuario
                        {
                            Id = (int)reader["Id"],
                            PersonaId = (int)reader["PersonaId"],
                            Rol = reader["Rol"].ToString(),
                            Persona = new Persona
                            {
                                Nombre = reader["Nombre"].ToString(),
                                Apellido = reader["Apellido"].ToString(),
                                Correo = reader["Correo"].ToString()
                            }
                        });
                    }
                }
            }
            return lista;
        }

        public Usuario ObtenerPorId(int id)
        {
            Usuario usuario = null;
            using (var con = new SqlConnection(_connectionString))
            {
                con.Open();
                var query = @"SELECT u.Id, u.PersonaId, u.Rol, p.Nombre, p.Apellido, p.Correo
                              FROM Usuarios u
                              INNER JOIN Personas p ON u.PersonaId = p.Id
                              WHERE u.Id = @Id";

                using (var cmd = new SqlCommand(query, con))
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
                                Rol = reader["Rol"].ToString(),
                                Persona = new Persona
                                {
                                    Nombre = reader["Nombre"].ToString(),
                                    Apellido = reader["Apellido"].ToString(),
                                    Correo = reader["Correo"].ToString()
                                }
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
            using (var con = new SqlConnection(_connectionString))
            {
                con.Open();
                var query = @"INSERT INTO Personas (Nombre, Apellido, Correo, FechaNacimiento, TipoPersona)
                              OUTPUT INSERTED.Id
                              VALUES (@Nombre,@Apellido,@Correo,@FechaNacimiento,@TipoPersona)";
                using (var cmd = new SqlCommand(query, con))
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
            using (var con = new SqlConnection(_connectionString))
            {
                con.Open();
                var query = @"INSERT INTO Usuarios (PersonaId, Rol, Password)
                              VALUES (@PersonaId,@Rol,@Password)";
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@PersonaId", usuario.PersonaId);
                    cmd.Parameters.AddWithValue("@Rol", usuario.Rol);
                    cmd.Parameters.AddWithValue("@Password", usuario.Password);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
