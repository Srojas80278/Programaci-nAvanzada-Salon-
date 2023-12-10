using ApiSalonBelleza.Entities;
using ApiSalonBelleza.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
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
                return "OK";
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

        [HttpGet]
        [Route("ConsultarUnaCita")]
        public ConsultarUnaCita_Result ConsultarUnaCita(int q) //Retornamos el resultado de el SP.
        {
            using (var contexto = new salonbellezaMNEntities())
            {
                return contexto.ConsultarUnaCita(q).FirstOrDefault();
            }
        }


        [HttpPut]
        [Route("ActualizarCita")]
        public String ActualizarCita(Cita q) 
        {
                using (var context = new salonbellezaMNEntities())   //La fecha en el sistema es para ver cuando solicita la cita.
                                                                     //Como M.N el salon debe comunicarle al cliente cuando lo puede atender.
                {
                    context.ActualizarCitaSP(q.estilista, q.fecha = DateTime.Now,
                    q.sede, q.nombre_cliente, q.servicio, q.descripcion_servicio, q.id_cita);

                    return "OK";
                }
        }
    
        [HttpPost]
        [Route("BorrarUnaCita2")]
        public String BorrarUnaCita2(Cita q)
        {

            using (var context = new salonbellezaMNEntities())
            {
                context.BorrarCita_SP(q.id_cita);
                return "OK";
            }
        }

    }
}
