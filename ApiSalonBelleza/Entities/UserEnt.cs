using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiSalonBelleza.Entities
{
    public class UserEnt
    {
        public long id { get; set; }

        public string name { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public long role_id { get; set; }
    }
}