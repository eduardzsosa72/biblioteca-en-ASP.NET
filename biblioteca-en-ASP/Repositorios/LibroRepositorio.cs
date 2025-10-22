using biblioteca_en_ASP_NET.Interfaces;
using biblioteca_en_ASP_NET.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;

namespace biblioteca_en_ASP_NET.Repositorios
{
    public class LibroRepositorio : ILibroRepositorio
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["BibliotecaDB"].ConnectionString;

        public IEnumerable<Libro> ObtenerLibros()
        {
            var lista = new List<Libro>();
            using (var con = new SqlConnection(_connectionString))
            {
                con.Open();
                var query = "SELECT * FROM Libros";
                using (var cmd = new SqlCommand(query, con))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Libro
                        {
                            Id = (int)reader["Id"],
                            Titulo = reader["Titulo"].ToString(),
                            Autor = reader["Autor"].ToString(),
                            ISBN = reader["ISBN"].ToString(),
                            Cantidad = (int)reader["Cantidad"]
                        });
                    }
                }
            }
            return lista;
        }

        public void AgregarLibro(Libro libro)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                con.Open();
                var query = @"INSERT INTO Libros (Titulo, Autor, ISBN, Cantidad)
                              VALUES (@Titulo,@Autor,@ISBN,@Cantidad)";
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", libro.Titulo);
                    cmd.Parameters.AddWithValue("@Autor", libro.Autor);
                    cmd.Parameters.AddWithValue("@ISBN", libro.ISBN);
                    cmd.Parameters.AddWithValue("@Cantidad", libro.Cantidad);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarLibro(Libro libro)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                con.Open();
                var query = @"UPDATE Libros SET Titulo=@Titulo, Autor=@Autor, ISBN=@ISBN, Cantidad=@Cantidad
                              WHERE Id=@Id";
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", libro.Id);
                    cmd.Parameters.AddWithValue("@Titulo", libro.Titulo);
                    cmd.Parameters.AddWithValue("@Autor", libro.Autor);
                    cmd.Parameters.AddWithValue("@ISBN", libro.ISBN);
                    cmd.Parameters.AddWithValue("@Cantidad", libro.Cantidad);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Libro ObtenerPorId(int id)
        {
            Libro libro = null;
            using (var con = new SqlConnection(_connectionString))
            {
                con.Open();
                var query = "SELECT * FROM Libros WHERE Id=@Id";
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            libro = new Libro
                            {
                                Id = (int)reader["Id"],
                                Titulo = reader["Titulo"].ToString(),
                                Autor = reader["Autor"].ToString(),
                                ISBN = reader["ISBN"].ToString(),
                                Cantidad = (int)reader["Cantidad"]
                            };
                        }
                    }
                }
            }
            return libro;
        }
    }
}
