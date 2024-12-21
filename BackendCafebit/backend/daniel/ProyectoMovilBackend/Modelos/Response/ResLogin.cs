using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMovilBackend.Modelos.Response
{
    public class ResLogin : ResBase
    {
        public long? sesion_id { get; set; }
        public int? id_usuario { get; set; }
        public string email { get; set; }
        public string nombre { get; set; }
    }
}
