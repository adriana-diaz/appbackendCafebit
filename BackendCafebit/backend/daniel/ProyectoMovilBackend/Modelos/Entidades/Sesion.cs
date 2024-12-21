using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMovilBackend.Modelos.Entidades
{
    public class Sesion
    {
        public Int32 sesion_id { get; set; }
        public string sesion { get; set; }
        public Int32 usuario { get; set; }
        public string origen { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_final { get; set; }
        public int estado { get; set; }
        public DateTime fecha_actualizacion { get; set; }

    }
}
