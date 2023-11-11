using ProyectoSalonBelleza.Entidades;
using ProyectoSalonBelleza.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSalonBelleza.Controllers
{
    public class CitasController : Controller
    {
        CitasModelo CitaModelo = new CitasModelo();

        [HttpGet]
        public ActionResult RegistrarCita()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarCita(CitaEntidad entidad)
        {
            string respuesta = CitaModelo.RegistrarCita(entidad);
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
        public ActionResult ConsultarCitas()
        {
            var datos = CitaModelo.ConsultarCitas();
            return View(datos);
        }



        //Actualizar Citas
        [HttpPost] //Aqui no se cambia a PUT porque estamos trabajando en MCV y solo existen (Post y Get)
        public ActionResult ActualizarCita(CitaEntidad entidad)
        {
            string respuesta = CitaModelo.ActualizarCita(entidad);
            if (respuesta == "OK")
            {
                ViewBag.MensajeUsuario = "Registro Exitoso"; 
                return RedirectToAction("ConsultarCitas", "Citas"); //"Accion", "Controller"
            }
            {
                ViewBag.MensajeUsuario = "No se ha podido registrar su información";
                return View();
            }
        }
    }
}
