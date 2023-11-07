using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSalonBelleza.Entidades
{
    public class CitaEntidad
    {
       
            public string estilista { get; set; }
            public DateTime fecha { get; set; }
            public string sede { get; set; }
            public string nombre_cliente { get; set; }
            public string servicio { get; set; }
            public string descripcion_servicio { get; set; }
       

    }
}