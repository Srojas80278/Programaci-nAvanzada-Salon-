using ApiSalonBelleza.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

using System.IO;
using ApiSalonBelleza;
using ApiSalonBelleza.Smtp;


namespace ApiSalonBelleza.Controllers
{
    public class LoginController : ApiController
    {
        Smtp.Smtp smtp = new Smtp.Smtp();

        [HttpPost]
        [Route("RegistrarCuenta")]
        public string RegistrarCuenta(UserEnt entidad)
        {
            try
            {
                using (var context = new salonEntities())
                {
                    context.RegistrarCuentaSP(entidad.name, entidad.email, entidad.password, entidad.role_id);
                    return "OK";
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        [HttpPost]
        [Route("IniciarSesion")]
        public IniciarSesionSP_Result IniciarSesion(UserEnt entidad)
        {
            try
            {
                using (var context = new salonEntities())
                {

                    return context.IniciarSesionSP(entidad.email, entidad.password).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("RecuperarCuenta")]
        public string RecuperarCuenta(string email)
        {
            try
            {
                using (var context = new salonEntities())
                {
                    var datos = context.RecuperarCuentaSP(email).FirstOrDefault();

                    if (datos != null)
                    {
                        string rutaArchivo = AppDomain.CurrentDomain.BaseDirectory + "Smtp\\Templates\\RecuperarCuenta.html";
                        string html = File.ReadAllText(rutaArchivo);

                        html = html.Replace("@@name", datos.name);
                        html = html.Replace("@@password", datos.password);

                        smtp.EnviarCorreo(datos.email, "Contraseña de Acceso", html);
                        return "OK";
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

    }
}
