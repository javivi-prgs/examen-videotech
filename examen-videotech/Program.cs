using System;
using System.Collections.Generic;
using System.IO;

namespace examen_videotech
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pelicula> peliculas = new List<Pelicula>();

            peliculas.Add(new Pelicula("Interstellar", "Christopher Nolan", 2014, true));
            peliculas.Add(new Pelicula("El Padrino", "Francis Ford Coppola", 1972, false));
            peliculas.Add(new Pelicula("Dunkerque", "Christopher Nolan", 2017, true));

            Console.WriteLine("Todas las películas:");
            foreach (var pelicula in peliculas)
            {
                Console.WriteLine(pelicula.ToString());
            }   

            Console.WriteLine("\nPelículas dirigidas por Nolan:");
            foreach (var pelicula in peliculas)
            {
                if (pelicula.GetDirector().Contains("Nolan"))
                {
                    Console.WriteLine(pelicula.ToString());
                }
            }

            Console.WriteLine("\nFecha actual: " + DateTime.Now.ToShortDateString());

            string ruta = "peliculas.txt";
            GuardarPeliculas(peliculas, ruta);
            Console.WriteLine("\nPelículas guardadas en el fichero: " + ruta);
        }

        static void GuardarPeliculas(List<Pelicula> lista, string ruta)
        {
            using (StreamWriter writer = new StreamWriter(ruta))
            {
                foreach (var pelicula in lista)
                {
                    writer.WriteLine($"{pelicula.GetTitulo()};{pelicula.GetDirector()};{pelicula.GetAnyo()};{pelicula.IsDisponible()}");
                }
            }
        }
    }
}