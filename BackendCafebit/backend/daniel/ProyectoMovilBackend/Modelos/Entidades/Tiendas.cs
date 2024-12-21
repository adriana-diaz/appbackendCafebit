using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMovilBackend.Modelos.Entidades
{
    public class Tiendas
    {
        public class Addtiendas
        {
            public string nombre { get; set; }
        }
        public class actualizarTiendas
        {
            public string nombre { get; set; }
        }
        public class Eliminartiendas
        {
            public string nombre { get; set; }
        }
        public class ConsultarTiendas
        {
            public string nombre { get; set; }
        }
    }
}
