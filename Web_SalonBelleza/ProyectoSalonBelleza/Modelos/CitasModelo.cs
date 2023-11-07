using Newtonsoft.Json;
using ProyectoSalonBelleza.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSalonBelleza.Modelos
{
    public class CitasModelo
    {

        public string rutaServidor = ConfigurationManager.AppSettings["RutaApi"];

        public string RegistrarCita(CitaEntidad entidad)
        {
            using (var client = new HttpClient())
            {
                var urlApi = rutaServidor + "RegistrarCita";
                var jsonData = JsonContent.Create(entidad);
                var res = client.PostAsync(urlApi, jsonData).Result;
                return res.Content.ReadFromJsonAsync<string>().Result;
            }
        }


        public List<CitaEntidad> ConsultarCitas()
        {
            using (var client = new HttpClient())
            {
                var urlApi = rutaServidor + "ConsultarCitas";
                var res = client.GetAsync(urlApi).Result;
                return res.Content.ReadFromJsonAsync<List<CitaEntidad>>().Result;
            }
        }






    }
}