using ApiSalonBelleza.Entities;
using ApiSalonBelleza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiSalonBelleza.Controllers
{
    public class CitasController : ApiController
    {
        [HttpPost]
        [Route("RegistrarCita")]
        public String RegistrarCita(Cita q)
        {

            using (var context = new salonbellezaMNEntities1())
            {
                context.RegistrarCitaSP(q.estilista, q.fecha = DateTime.Now,
                q.sede, q.nombre_cliente, q.servicio, q.descripcion_servicio);

                return "Registro Realizado Correctamente";
            }
        }

        [HttpGet]
        [Route("ConsultarCitas")]
        public List<ConsultarCitaSP_Result> ConsultarCitas() //Retornamos el resultado de el SP.
        {
            using (var contexto = new salonbellezaMNEntities1())
            {
                return contexto.ConsultarCitaSP().ToList(); 
                //To List permite devolver en una lista de objetos en formato JSON.
            }
        }




    }
}
