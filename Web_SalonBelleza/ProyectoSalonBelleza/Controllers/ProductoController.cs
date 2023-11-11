using ProyectoSalonBelleza.Entidades;
using ProyectoSalonBelleza.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSalonBelleza.Controllers
{
    public class ProductoController : Controller
    {
        ProductoModelo ProductoModelo = new ProductoModelo();
       
        [HttpGet]
        public ActionResult RegistrarProducto()

        {
            return View();
        }


        [HttpPost]
        public ActionResult RegistrarProducto(ProductoEnt entidad)
        {
            string respuesta = ProductoModelo.RegistrarProducto(entidad);
            if (respuesta == "OK")
            {
                ViewBag.MensajeUsuario = "Registro Exitoso";
            }
            {
                ViewBag.MensajeUsuario = "No se ha podido registrar su información";
                return View();
            }
        }

        [HttpGet]
        public ActionResult ConsultarProducto()
        {
            var datos = ProductoModelo.ConsultarProducto();
            return View(datos);
        }

        
        //[HttpPost]
        //public ActionResult EliminarProducto(int id)
        //{
        //    string respuesta = ProductoModelo.EliminarProducto(id);

        //    if (respuesta == "Producto eliminado correctamente")
        //    {
        //        ViewBag.MensajeUsuario = respuesta;
        //    }
        //    else
        //    {
        //        ViewBag.MensajeUsuario = "No se ha podido eliminar el producto.";
        //    }

        //    var datos = ProductoModelo.ConsultarProducto();
        //    return View("ConsultarProducto", datos);
        //}
    }
}