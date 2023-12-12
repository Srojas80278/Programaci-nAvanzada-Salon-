using ApiSalonBelleza.Entities;
using ApiSalonBelleza.Modelo;
//using ApiSalonBelleza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiSalonBelleza.Controllers
{
    public class ProductoController : ApiController
    {
        [HttpPost]
        [Route("RegistrarProducto")]
        public String RegistrarProducto(ProductoEnt q)
        {

            using (var context = new salonEntities())
            {
                context.RegistrarProductoSP(q.Nombre, q.Descripcion, q.Cantidad, q.Precio, q.Imagen, q.Estado);

                return "Registro Realizado Correctamente";
            }
        }

        [HttpGet]
        [Route("ConsultarProducto")]
        public List<ConsultarProductoSP_Result> ConsultarProducto() 
        {
            using (var contexto = new salonEntities())
            {
                return contexto.ConsultarProductoSP().ToList();
            }
        }

        [HttpGet]
        [Route("ConsultarUnProducto")]
        public ConsultarUnProductoSP_Result ConsultarUnProducto(int q) 
        {
            using (var contexto = new salonEntities())
            {
                return contexto.ConsultarUnProductoSP(q).FirstOrDefault();
            }
        }


        [HttpPut]
        [Route("ActualizarProducto")]
        public String ActualizarProducto(ProductoEnt q)
        {
            using (var context = new salonEntities())   //La fecha en el sistema es para ver cuando solicita la cita.
            {
                context.ActualizarProductoSP(q.Nombre, q.Descripcion,
                q.Cantidad, q.Precio, q.Imagen, q.Estado, q.ConProducto);
                return "OK";
            }
        }

        [HttpPost]
        [Route("BorrarUnProducto2")]
        public String BorrarUnProducto2(ProductoEnt q)
        {
            using (var context = new salonEntities())
            {
                context.BorrarProducto_SP(q.ConProducto);
                return "OK";
            }
        }
    }
}