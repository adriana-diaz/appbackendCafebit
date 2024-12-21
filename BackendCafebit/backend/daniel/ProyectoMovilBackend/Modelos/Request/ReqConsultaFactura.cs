using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMovilBackend.Modelos.Request
{
    public class ReqConsultaFactura
    {
        public int id_usuario { get; set; }
        public int id_tarjeta { get; set; }
    }
}
