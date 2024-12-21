using ProyectoMovilBackend.Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMovilBackend.Modelos.Request
{
    public class ReqActualizarCategoria
    {
        public Categoria.CambiosaCategoria categoria { get; set; }
    }
}
