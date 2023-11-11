using ApiSalonBelleza.Entities;
//using ApiSalonBelleza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Timers;
using System.Web.Http;

namespace ApiSalonBelleza.Controllers
{
    public class CitasController : ApiController
    {
        [HttpPost]
        [Route("RegistrarCita")]
        public String RegistrarCita(Cita q)
        {

            using (var context = new salonEntities())
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
            using (var contexto = new salonEntities())
            {
                return contexto.ConsultarCitaSP().ToList();
                //To List permite devolver en una lista de objetos en formato JSON.
            }
        }

        [HttpPut]
        [Route("ActualizarCita")]
        public String ActualizarCita(Cita q)
        {

            try
            {
                using (var context = new salonEntities())   //La fecha en el sistema es para ver cuando solicita la cita.
                                                                     //Como M.N el salon debe comunicarle al cliente cuando lo puede atender.
                {
                    context.ActualizarCitaSP(q.estilista, q.fecha = DateTime.Now,
                    q.sede, q.nombre_cliente, q.servicio, q.descripcion_servicio, q.id_cita);

                    return "OK";
                }
            }
            catch (Exception)
            {
                return string.Empty;

            }
        }
    }
}
