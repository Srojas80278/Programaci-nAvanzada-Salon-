//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiSalonBelleza.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class citas
    {
        public int id_cita { get; set; }
        public string estilista { get; set; }
        public System.DateTime fecha { get; set; }
        public string sede { get; set; }
        public string nombre_cliente { get; set; }
        public string servicio { get; set; }
        public string descripcion_servicio { get; set; }
    }
}
