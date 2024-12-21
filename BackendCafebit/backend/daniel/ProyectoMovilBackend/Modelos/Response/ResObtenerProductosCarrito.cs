using ProyectoMovilBackend.Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMovilBackend.Modelos.Response
{
    public class ResObtenerProductosCarrito : ResBase
    {
        public List<Carrito.consulta> listaDeconsultas = new List<Carrito.consulta>();
    }
}
