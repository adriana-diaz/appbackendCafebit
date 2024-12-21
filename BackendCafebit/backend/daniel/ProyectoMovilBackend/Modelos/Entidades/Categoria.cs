using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMovilBackend.Modelos.Entidades
{
    public class Categoria
    {
        public class Insertar
        {
            public string nombre { get; set; }
        }

        public class CambiosaCategoria
        {

            public string nombre { get; set; }

            public string nuevo_nombre { get; set; }
        }

        public class Erase
        {
            public string nombre { get; set; }
        }
    }
}
