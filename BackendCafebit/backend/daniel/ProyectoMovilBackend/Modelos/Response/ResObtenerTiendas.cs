using ProyectoMovilBackend.Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMovilBackend.Modelos.Response
{
    public class ResObtenerTiendas : ResBase
    {
        public List<Tiendas.ConsultarTiendas> listaDeconsultas = new List<Tiendas.ConsultarTiendas>();
    }
}