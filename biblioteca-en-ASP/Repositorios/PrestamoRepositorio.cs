using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using biblioteca_en_ASP_NET.Interfaces;
using biblioteca_en_ASP_NET.Models;

namespace biblioteca_en_ASP_NET.Repositorios
{
    public class PrestamoRepositorio : IPrestamoRepositorio
    {
        private readonly string _connectionString;

        public PrestamoRepositorio()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["ConexionSQL"].ConnectionString;
        }

        public IEnumerable<Prestamo> ObtenerPrestamos()
        {
            var lista = new List<Prestamo>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string query = @"SELECT p.Id, p.UsuarioId, p.LibroId, p.FechaPrestamo, p.FechaDevolucion, 
                                        l.Titulo AS LibroTitulo, u.Nombre AS UsuarioNombre
                                 FROM Prestamos p
                                 INNER JOIN Libros l ON p.LibroId = l.Id
                                 INNER JOIN Usuarios u ON p.UsuarioId = u.Id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Prestamo
                        {
                            Id = (int)dr["Id"],
                            UsuarioId = (int)dr["UsuarioId"],
                            LibroId = (int)dr["LibroId"],
                            FechaPrestamo = (DateTime)dr["FechaPrestamo"],
                            FechaDevolucion = (DateTime)dr["FechaDevolucion"],
                            Libro = new Libro { Titulo = dr["LibroTitulo"].ToString() },
                            Usuario = new Usuario { Nombre = dr["UsuarioNombre"].ToString() }
                        });
                    }
                }
            }

            return lista;
        }

        public void CrearPrestamo(Prestamo prestamo)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string query = @"INSERT INTO Prestamos (UsuarioId, LibroId, FechaPrestamo, FechaDevolucion)
                                 VALUES (@UsuarioId, @LibroId, @FechaPrestamo, @FechaDevolucion)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UsuarioId", prestamo.UsuarioId);
                    cmd.Parameters.AddWithValue("@LibroId", prestamo.LibroId);
                    cmd.Parameters.AddWithValue("@FechaPrestamo", prestamo.FechaPrestamo);
                    cmd.Parameters.AddWithValue("@FechaDevolucion", prestamo.FechaDevolucion);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
