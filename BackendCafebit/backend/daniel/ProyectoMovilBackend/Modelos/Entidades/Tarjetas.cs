using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMovilBackend.Modelos.Entidades
{
    public class Tarjetas
    {
        public class InsertarTarjetas
        {
            public string numero_trajeta { get; set; }
            public string fecha_expiracion { get; set; }
            public string CVV { get; set; }
            public int? id_usuario { get; set; }

        }
        public class EliminarTarjetas
        {
            public string numero_trajeta { get; set; }

        }
        public class ActualizarTarjetas
        {
            public string numero_trajeta { get; set; }
            public string nuevo_numero_trajeta { get; set; }
            public string nueva_fecha_expiracion { get; set; }
            public string nuevo_CVV { get; set; }
        }
        public class consultaTarjeta
        {
            public int? id_usuario { get; set; }
            public int? id_tarjeta { get; set; }
            public string numero_trajeta { get; set; }
            public DateTime fecha_expiracion { get; set; }
            public string CVV { get; set; }
        }
    }
}
