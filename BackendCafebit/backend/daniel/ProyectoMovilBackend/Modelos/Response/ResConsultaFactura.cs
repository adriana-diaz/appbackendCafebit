﻿using ProyectoMovilBackend.Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMovilBackend.Modelos.Response
{
    public class ResConsultaFactura : ResBase
    {
        public List<Factura.Consultar> listaDefacturas = new List<Factura.Consultar>();
    }
}
