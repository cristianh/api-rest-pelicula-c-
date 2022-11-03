using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppPeliculas.Models;
using AppPeliculas.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace AppPeliculas.Data
{
    public class PeliculaData
    {
        public static bool registrarPelicula(Pelicula oPelicula)
        {
            ConexionBD objEST = new ConexionBD();
            string sentencia;


            //sentencia = "execute usp_insertar_pelicula ' " + "Capitan America: Primer vengador" + "','" + "acción" + "','" + "Tras tres meses de someterse a un programa de entrenamiento físico y táctico, Steve Rogers es encomendado su primera misión como Capitán América. Armado con un escudo indestructible." + "','" + oPelicula.directorPelicula + "','" + "07-22-2011" + "','" + oPelicula.productoraPelicula + "','" + oPelicula.actorPelicula + "','" + oPelicula.duracionPelicula +  "','" + oPelicula.puntuacionPelicula + "'";
            sentencia = $"execute usp_insertar_pelicula '{oPelicula.nombrePelicula}','{oPelicula.generoPelicula}','{oPelicula.sinopsisPelicula}','{oPelicula.directorPelicula}','{oPelicula.fechaEstrenoPelicula.ToString("d")}','{oPelicula.productoraPelicula}','{oPelicula.actorPelicula}','{oPelicula.duracionPelicula}',{oPelicula.puntuacionPelicula.ToString().Replace(',','.')}";
            if (!objEST.EjecutarSentencia(sentencia, false))
            {
                objEST = null;
                return false;
            }
            else
            {
                objEST = null;
                return true;
            }
        }

        public static bool actualizarPelicula(Pelicula oPelicula)
        {
            ConexionBD objEST = new ConexionBD();
            string sentencia;
            //sentencia = "execute usp_actualizar_pelicula '" + oPelicula.IdPelicula + "','" + oPelicula.nombrePelicula + "','" + oPelicula.generoPelicula + "','" + oPelicula.sinopsisPelicula + "','" + oPelicula.directorPelicula + "','" + oPelicula.fechaEstrenoPelicula + "','" + oPelicula.productoraPelicula + "','" + oPelicula.actorPelicula + "','" + oPelicula.duracionPelicula + "','" + oPelicula.puntuacionPelicula + "'";
            sentencia = $"execute usp_actualizar_pelicula '{oPelicula.IdPelicula}','{oPelicula.nombrePelicula}','{oPelicula.generoPelicula}','{oPelicula.sinopsisPelicula}','{oPelicula.directorPelicula}','{oPelicula.fechaEstrenoPelicula.ToString("d")}','{oPelicula.productoraPelicula}','{oPelicula.actorPelicula}','{oPelicula.duracionPelicula}',{oPelicula.puntuacionPelicula.ToString().Replace(',', '.')}";
            if (!objEST.EjecutarSentencia(sentencia, false))
            {
                objEST = null;
                return false;
            }
            else
            {
                objEST = null;
                return true;
            }
        }


        public static bool eliminarPelicula(string id)
        {
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "execute usp_eliminar_pelicula ' " + id + "'";



            if (!objEst.EjecutarSentencia(sentencia, false))
            {
                objEst = null;
                return false;
            }
            else
            {
                objEst = null;
                return true;
            }
        }

      
        public static List<Pelicula> Listar()
        {
            List<Pelicula> oListarPelicula = new List<Pelicula>();
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "execute usp_listar_peliculas ";

            if (objEst.Consultar(sentencia, false))
            {
                SqlDataReader dr = objEst.Reader;
                while (dr.Read())
                {
                    oListarPelicula.Add(new Pelicula()
                    {
                        IdPelicula = Convert.ToInt32(dr["IdPelicula"]),
                        nombrePelicula = dr["nombrePelicula"].ToString(),
                        generoPelicula = dr["generoPelicula"].ToString(),
                        sinopsisPelicula = dr["sinopsisPelicula"].ToString(),
                        directorPelicula = dr["directorPelicula"].ToString(),
                        fechaEstrenoPelicula = Convert.ToDateTime(dr["fechaEstrenoPelicula"].ToString()),
                        productoraPelicula = dr["productoraPelicula"].ToString(),
                        actorPelicula = dr["actorPrincipal"].ToString(),
                        duracionPelicula = dr["actorPrincipal"].ToString(),
                        puntuacionPelicula = float.Parse(dr["puntuacionPelicula"].ToString())

                    });
                }
                return oListarPelicula;
            }
            else
            {
                return oListarPelicula;
            }
        }

        public static List<Pelicula> Obtener(string id)
        {
            List<Pelicula> oListarPelicula = new List<Pelicula>();
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = $"EXECUTE usp_listar_pelicula_id '{id}'";



            if (objEst.Consultar(sentencia, false))
            {
                SqlDataReader dr = objEst.Reader;
                while (dr.Read())
                {
                    oListarPelicula.Add(new Pelicula()
                    {
                        IdPelicula = Convert.ToInt32(dr["IdPelicula"]),
                        nombrePelicula = dr["nombrePelicula"].ToString(),
                        generoPelicula = dr["generoPelicula"].ToString(),
                        sinopsisPelicula = dr["sinopsisPelicula"].ToString(),
                        directorPelicula = dr["directorPelicula"].ToString(),
                        fechaEstrenoPelicula = Convert.ToDateTime(dr["fechaEstrenoPelicula"].ToString()),
                        productoraPelicula = dr["productoraPelicula"].ToString(),
                        actorPelicula = dr["actorPrincipal"].ToString(),
                        duracionPelicula = dr["actorPrincipal"].ToString(),
                        puntuacionPelicula = float.Parse(dr["puntuacionPelicula"].ToString())
                    });
                }
                return oListarPelicula;
            }
            else
            {
                return oListarPelicula;
            }
        }
    }
}