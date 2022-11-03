using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppPeliculas.Models
{
    public class Pelicula
    {
        public int IdPelicula { get; set; }
        public string nombrePelicula{ get; set; }
        public string generoPelicula { get; set; }
        public string sinopsisPelicula { get; set; }
        public string directorPelicula { get; set; }
        public DateTime fechaEstrenoPelicula { get; set; }
        public string productoraPelicula { get; set; }
        public string actorPelicula { get; set; }
        public string duracionPelicula { get; set; }
        public double puntuacionPelicula { get; set; }

    }
}