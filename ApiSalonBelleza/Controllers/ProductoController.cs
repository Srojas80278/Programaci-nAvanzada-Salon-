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

        //[HttpDelete]
        //[Route("EliminarProducto/{id}")]
        //public IHttpActionResult EliminarProducto(int id)
        //{
        //    try
        //    {
        //        using (var context = new salonEntities())
        //        {
        //            context.EliminarProductoSP(id);

        //            return Ok("Producto eliminado correctamente");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return InternalServerError(ex);
        //    }
        //}
    }
}