using biblioteca_en_ASP_NET.Interfaces;
using biblioteca_en_ASP_NET.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace biblioteca_en_ASP_NET.Repositorios
{
    public class PrestamoRepositorio : IPrestamoRepositorio
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["BibliotecaDB"].ConnectionString;

        public IEnumerable<Prestamo> ObtenerPrestamos()
        {
            var lista = new List<Prestamo>();
            using (var con = new SqlConnection(_connectionString))
            {
                con.Open();
                var query = @"SELECT p.Id, p.UsuarioId, p.LibroId, p.FechaPrestamo, p.FechaDevolucion,
                                     l.Titulo AS LibroTitulo, u.Id AS UsuarioId, per.Nombre AS UsuarioNombre
                              FROM Prestamos p
                              INNER JOIN Libros l ON p.LibroId = l.Id
                              INNER JOIN Usuarios u ON p.UsuarioId = u.Id
                              INNER JOIN Personas per ON u.PersonaId = per.Id";

                using (var cmd = new SqlCommand(query, con))
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Prestamo
                        {
                            Id = (int)dr["Id"],
                            UsuarioId = (int)dr["UsuarioId"],
                            LibroId = (int)dr["LibroId"],
                            FechaPrestamo = (DateTime)dr["FechaPrestamo"],
                            FechaDevolucion = dr["FechaDevolucion"] != DBNull.Value ? (DateTime?)dr["FechaDevolucion"] : null,
                            Libro = new Libro { Titulo = dr["LibroTitulo"].ToString() },
                            Usuario = new Usuario { Persona = new Persona { Nombre = dr["UsuarioNombre"].ToString() } }
                        });
                    }
                }
            }
            return lista;
        }

        public void CrearPrestamo(Prestamo prestamo)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                con.Open();
                var query = @"INSERT INTO Prestamos (UsuarioId, LibroId, FechaPrestamo, FechaDevolucion)
                              VALUES (@UsuarioId,@LibroId,@FechaPrestamo,@FechaDevolucion)";
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UsuarioId", prestamo.UsuarioId);
                    cmd.Parameters.AddWithValue("@LibroId", prestamo.LibroId);
                    cmd.Parameters.AddWithValue("@FechaPrestamo", prestamo.FechaPrestamo);
                    cmd.Parameters.AddWithValue("@FechaDevolucion", prestamo.FechaDevolucion ?? (object)DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
