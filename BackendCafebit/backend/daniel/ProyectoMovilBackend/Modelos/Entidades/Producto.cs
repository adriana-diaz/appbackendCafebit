using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMovilBackend.Modelos.Entidades
{
    public class Producto
    {
        public class Agregar
        {
            public string nombre_categoria { get; set; }
            public string nombre { get; set; }
            public string descripcion { get; set; }
            public decimal? precio_producto { get; set; }
        }
        public class Cambiar
        {
            public string nombre_actual { get; set; }
            public string nuevo_nombre { get; set; }
            public string descripcion { get; set; }
            public decimal? precio_producto { get; set; }
            public string nombre_categoria { get; set; }
        }
        public class Borrar
        {
            public string nombre { get; set; }
        }
        public class ConsultarTodos
        {
            public string nombre_categoria { get; set; }
            public string nombre { get; set; }
            public string descripcion { get; set; }
            public decimal? precio_producto { get; set; }

        }
    }
}
