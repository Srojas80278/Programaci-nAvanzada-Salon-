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
                return RedirectToAction("ConsultarCitas", "Citas"); //"Accion", "Controller"
            
            }else{
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


        [HttpGet] 
        public ActionResult ActualizarCita(int q)
        {
            var datos = CitaModelo.ConsultarUnaCita(q);
            return View(datos);
        }



        [HttpGet]
        public ActionResult ConfirmarBorrarCita(int q)
        {
            var datos = CitaModelo.ConsultarUnaCita(q);
            return View(datos);
        }


        [HttpPost]
        public ActionResult BorrarUnaCita2(CitaEntidad entidad)
        {
            string respuesta = CitaModelo.BorrarUnaCita2(entidad);
            if (respuesta == "OK")
            {
                return RedirectToAction("ConsultarCitas", "Citas"); //"Accion", "Controller"
            }
            {
                ViewBag.MensajeUsuario = "No se ha podido registrar su información";
                return View();
            }
        }



        [HttpPost] //Aqui no se cambia a PUT porque estamos trabajando en MCV y solo existen (Post y Get)
        public ActionResult ActualizarCita(CitaEntidad entidad)
        {
            string respuesta = CitaModelo.ActualizarCita(entidad);
            if (respuesta == "OK")
            {
                ViewBag.MensajeUsuario = "Actualización Exitoso";
                return RedirectToAction("ConsultarCitas", "Citas"); //"Accion", "Controller"

            }
            else
            {
                ViewBag.MensajeUsuario = "No se ha podido registrar su información";
                return View();
            }
        }
    }
}
