using ProyectoSalonBelleza.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;

namespace ProyectoSalonBelleza.Modelos
{
    public class ProductoModelo
    {
        public string rutaServidor = ConfigurationManager.AppSettings["RutaApi"];
        public string RegistrarProducto(ProductoEnt entidad)
        {
            using (var client = new HttpClient())
            {
                var urlApi = rutaServidor + "RegistrarProducto";
                var jsonData = JsonContent.Create(entidad);
                var res = client.PostAsync(urlApi, jsonData).Result;
                return res.Content.ReadFromJsonAsync<string>().Result;
            }
        }
        public List<ProductoEnt> ConsultarProducto()
        {
            using (var client = new HttpClient())
            {
                var urlApi = rutaServidor + "ConsultarProducto";
                var res = client.GetAsync(urlApi).Result;
                return res.Content.ReadFromJsonAsync<List<ProductoEnt>>().Result;
            }
        }
        //public string EliminarProducto(int ConProducto)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        var urlApi = $"{rutaServidor}EliminarProducto/{ConProducto}";
        //        var res = client.DeleteAsync(urlApi).Result;
        //        return res.Content.ReadFromJsonAsync<string>().Result;
        //    }
        //}
    }

}