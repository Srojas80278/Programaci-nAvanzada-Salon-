using ProyectoSalonBelleza.Entities;
using ProyectoSalonBelleza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSalonBelleza.Controllers
{
    public class LoginController : Controller
    {
        UserModel entityModel = new UserModel();

        //[HttpGet]
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult CerrarSesion()
        {
            Session.Clear();
            return RedirectToAction("FormularioLogin", "Home");
        }

        [HttpGet]
        public ActionResult FormularioLogin()
        {
            ViewBag.Message = "Iniciar Sesión";
            return View("~/Views/Login/FormularioLogin.cshtml");
        }

        [HttpPost]
        public ActionResult IniciarSesion(UserEnt entidad)
        {
            var respuesta = entityModel.IniciarSesion(entidad);

            if (respuesta != null)
            {
                Session["id"] = respuesta.id;
                Session["name"] = respuesta.name;
                Session["role"] = respuesta.role_id;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.MensajeUsuario = "No se ha podido validar su información";
                return View("~/Views/Login/FormularioLogin.cshtml");
            }
        }

        [HttpGet]
        public ActionResult FormularioRegistro()
        {
            ViewBag.Message = "Registro.";
            return View("~/Views/Login/FormularioRegistro.cshtml");
        }

        [HttpPost]
        public ActionResult RegistrarCuenta(UserEnt entidad)
        {
            entidad.role_id = 2;
            string respuesta = entityModel.RegistrarCuenta(entidad);

            if (respuesta == "OK")
            {
                ViewBag.MensajeRegistro = "Su cuenta se a creado correctamente";
                return View("~/Views/Login/FormularioLogin.cshtml");
            }
            else
            {
                ViewBag.MensajeUsuario = "No se ha podido registrar su información";
                return View("~/Views/Login/FormularioRegistro.cshtml");
            }
        }

        [HttpGet]
        public ActionResult FormularioRecuperar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RecuperarCuenta(UserEnt entidad)
        {
            string respuesta = entityModel.RecuperarCuenta(entidad);

            if (respuesta == "OK")
            {
                return RedirectToAction("FormularioLogin", "Home");
            }
            else
            {
                ViewBag.MensajeUsuario = "No se ha podido recuperar su información";
                return View("~/Views/Login/FormularioRecuperar.cshtml");
            }
        }

    }
}