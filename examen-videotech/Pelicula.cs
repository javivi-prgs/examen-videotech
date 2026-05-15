using System;

namespace examen_videotech
{
    public class Pelicula
    {
        private string titulo;
        private string director;
        private int anyo;
        private bool disponible;

        public Pelicula(string titulo, string director, int anyo, bool disponible)
        {
            this.titulo = titulo;
            this.director = director;
            this.anyo = anyo;
            this.disponible = disponible;
        }

        public string GetTitulo()
        {
            return titulo;
        }

        public string GetDirector()
        {
            return director;
        }

        public int GetAnyo()
        {
            return anyo;
        }

        public bool IsDisponible()
        {
            return disponible;
        }

        public override string ToString()
        {
            return $"{titulo} - {director} ({anyo})";
        }
    }
}