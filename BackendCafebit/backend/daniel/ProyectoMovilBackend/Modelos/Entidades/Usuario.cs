﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMovilBackend.Modelos.Entidades
{
    public class Usuario
    {
        public class Ingresar
        {
            public string cedula { get; set; }
            public string nombre { get; set; }
            public string email { get; set; }
            public string password { get; set; }
        }
        public class Actualizar
        {
            public int id_usuario { get; set; }
            public string nombre { get; set; }
            public string email { get; set; }
            public string password { get; set; }
        }
        public class Eliminar
        {
            public string cedula { get; set; }
        }
    }
}
