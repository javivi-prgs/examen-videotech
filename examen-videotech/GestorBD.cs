using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace examen_videotech
{
    public class GestorBD
    {
        private MySqlConnection conexion;

        public GestorBD()
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                UserID = "root",
                Password = "",
                Database = "videotech"
            };

            conexion = new MySqlConnection(builder.ConnectionString);
        }

        public void Insertar(Pelicula p)
        {
            try
            {
                conexion.Open();
                string query = "INSERT INTO pelicula (titulo, director, anyo, disponible) VALUES (@titulo, @director, @anyo, @disponible)";
                using (var cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@titulo", p.GetTitulo());
                    cmd.Parameters.AddWithValue("@director", p.GetDirector());
                    cmd.Parameters.AddWithValue("@anyo", p.GetAnyo());
                    cmd.Parameters.AddWithValue("@disponible", p.IsDisponible());

                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                conexion.Close();
            }
        }

        public List<Pelicula> ObtenerTodos()
        {
            var peliculas = new List<Pelicula>();

            try
            {
                conexion.Open();
                string query = "SELECT * FROM pelicula";
                using (var cmd = new MySqlCommand(query, conexion))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var pelicula = new Pelicula(
                            reader.GetString("titulo"),
                            reader.GetString("director"),
                            reader.GetInt32("anyo"),
                            reader.GetBoolean("disponible")
                        );
                        peliculas.Add(pelicula);
                    }
                }
            }
            finally
            {
                conexion.Close();
            }

            return peliculas;
        }
    }
}