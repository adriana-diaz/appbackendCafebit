using ProyectoMovilBackend.Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMovilBackend.Modelos.Request
{
    public class ReqEliminarTarjeta
    {
        public Tarjetas.EliminarTarjetas tarjetas { get; set; }
    }
}
