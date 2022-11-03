using AppPeliculas.Data;
using AppPeliculas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppPeliculas.Controllers
{
    public class PeliculaController : ApiController
    {
        // GET api/<controller>
        public List<Pelicula> Get()
        {
            return PeliculaData.Listar();
        }

        // GET api/<controller>/5
        public List<Pelicula> Get(string id)
        {
            return PeliculaData.Obtener(id);
        }

        // POST api/<controller>
        public bool Post([FromBody]Pelicula oPelicula)
        {
            return PeliculaData.registrarPelicula(oPelicula);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody]Pelicula oPelicula)
        {
            return PeliculaData.actualizarPelicula(oPelicula);
        }

        // DELETE api/<controller>/5
        public bool Delete(string id)
        {
            return PeliculaData.eliminarPelicula(id);
        }
    }
}