using ProyectoSalonBelleza.Entidades;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Json;

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

        public CitaEntidad ConsultarUnaCita(int q)
        {
            using (var client = new HttpClient())
            {
                var urlApi = rutaServidor + "ConsultarUnaCita?q=" + q;
                var res = client.GetAsync(urlApi).Result;
                return res.Content.ReadFromJsonAsync<CitaEntidad>().Result;
            }
        }

        /*
        public string BorrarUnaCita(int q)
        {
            using (var client = new HttpClient())
            {
                var urlApi = rutaServidor + "BorrarUnaCita?q=" + q;
                var res = client.GetAsync(urlApi).Result;
                return res.Content.ReadFromJsonAsync<string>().Result;
            }
        }
        */




        public string ActualizarCita(CitaEntidad entidad) //Cambiamos Nombre
        {
            using (var client = new HttpClient())
            {
                var urlApi = rutaServidor + "ActualizarCita";
                var jsonData = JsonContent.Create(entidad);
                var res = client.PutAsync(urlApi, jsonData).Result;    //Cambiamos el "Put"
                return res.Content.ReadFromJsonAsync<string>().Result;
            }
        }
    }
}