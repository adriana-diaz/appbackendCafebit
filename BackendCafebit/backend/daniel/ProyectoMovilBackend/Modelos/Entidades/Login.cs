using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMovilBackend.Modelos.Entidades
{
    public class Login
    {
        public class Entrar
        {
            public string email { get; set; }
            public string password { get; set; }
        }
        public class Salir
        {
            public int sesion_id { get; set; }
        }
    }
}
