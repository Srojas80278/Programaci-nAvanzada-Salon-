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

        [HttpGet]
        public ActionResult ActualizarProducto(int q)
        {
            var datos = ProductoModelo.ConsultarUnProducto(q);
            return View(datos);
        
        }


        [HttpGet]
        public ActionResult ConfirmarBorrarProducto(int q)
        {
            var datos = ProductoModelo.ConsultarUnProducto(q);
            return View(datos);

        }

        [HttpPost]
        public ActionResult BorrarUnProducto2(ProductoEnt entidad)
        {
            string respuesta = ProductoModelo.BorrarUnProducto2(entidad);
            if (respuesta == "OK")
            {
                return RedirectToAction("ConsultarProducto", "Producto"); //"Accion", "Controller"
            }
            {
                ViewBag.MensajeUsuario = "No se ha podido registrar su información";
                return View();
            }
        }



        [HttpPost] //Aqui no se cambia a PUT porque estamos trabajando en MCV y solo existen (Post y Get)
        public ActionResult ActualizarProducto(ProductoEnt entidad)
        {
            string respuesta = ProductoModelo.ActualizarProducto(entidad);
            if (respuesta == "OK")
            {
                ViewBag.MensajeUsuario = "Actualización Exitoso";
                return RedirectToAction("ConsultarProducto", "Producto"); //"Accion", "Controller"
            }
            else
            {
                ViewBag.MensajeUsuario = "No se ha podido registrar su información";
                return View();
            }
        }








    }
}