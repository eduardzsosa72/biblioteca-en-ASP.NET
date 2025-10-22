using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using biblioteca_en_ASP_NET.Interfaces;
using biblioteca_en_ASP_NET.Models;

namespace biblioteca_en_ASP_NET.Repositorios
{
    public class LibroRepositorio : ILibroRepositorio
    {
        private readonly string _connectionString;

        public LibroRepositorio()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["ConexionSQL"].ConnectionString;
        }

        public IEnumerable<Libro> ObtenerLibros()
        {
            var libros = new List<Libro>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string query = "SELECT Id, Titulo, Autor, Genero, Cantidad FROM Libros";
                using (SqlCommand cmd = new SqlCommand(query, con))
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        libros.Add(new Libro
                        {
                            Id = (int)dr["Id"],
                            Titulo = dr["Titulo"].ToString(),
                            Autor = dr["Autor"].ToString(),
                            Genero = dr["Genero"].ToString(),
                            Cantidad = (int)dr["Cantidad"]
                        });
                    }
                }
            }

            return libros;
        }

        public Libro ObtenerPorId(int id)
        {
            Libro libro = null;

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string query = "SELECT Id, Titulo, Autor, Genero, Cantidad FROM Libros WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            libro = new Libro
                            {
                                Id = (int)dr["Id"],
                                Titulo = dr["Titulo"].ToString(),
                                Autor = dr["Autor"].ToString(),
                                Genero = dr["Genero"].ToString(),
                                Cantidad = (int)dr["Cantidad"]
                            };
                        }
                    }
                }
            }

            return libro;
        }

        public void AgregarLibro(Libro libro)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string query = @"INSERT INTO Libros (Titulo, Autor, Genero, Cantidad)
                                 VALUES (@Titulo, @Autor, @Genero, @Cantidad)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", libro.Titulo);
                    cmd.Parameters.AddWithValue("@Autor", libro.Autor);
                    cmd.Parameters.AddWithValue("@Genero", libro.Genero);
                    cmd.Parameters.AddWithValue("@Cantidad", libro.Cantidad);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarLibro(Libro libro)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string query = @"UPDATE Libros 
                                 SET Titulo = @Titulo, Autor = @Autor, Genero = @Genero, Cantidad = @Cantidad
                                 WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", libro.Id);
                    cmd.Parameters.AddWithValue("@Titulo", libro.Titulo);
                    cmd.Parameters.AddWithValue("@Autor", libro.Autor);
                    cmd.Parameters.AddWithValue("@Genero", libro.Genero);
                    cmd.Parameters.AddWithValue("@Cantidad", libro.Cantidad);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarLibro(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string query = "DELETE FROM Libros WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
