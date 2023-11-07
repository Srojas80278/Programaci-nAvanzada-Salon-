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





    }
}
