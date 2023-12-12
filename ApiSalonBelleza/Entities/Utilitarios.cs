using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace ApiSalonBelleza.Entities
{
    public class Utilitarios
    {
        public void EnviarCorreo(String CorreoDelUsuario, String Asunto, String Contenido) {

            MailMessage message = new MailMessage();

            //Correo de la persona que lo envía
            message.From = new MailAddress(CorreoDelUsuario);

            //Correo de la persona que lo recibe
            message.To.Add(new MailAddress("Srojas80278@ufice.ac.cr"));

            message.Subject = Asunto;
            message.Body = Contenido;
            message.Priority = MailPriority.Normal;
            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient("smtp.office365.com", 587);
            client.Credentials = new System.Net.NetworkCredential("xpronoobdev@hotmail.com", "dEvpAssword9.");
            client.EnableSsl = true;
            client.Send(message);
        }
    }
}