﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion1.Modelos
{
    public class Usuario
    {
            public string Rut { get; set; }
            public string Nombre { get; set; }
            public Boolean Empresa { get; set; }
            public string Telefono { get; set; }
            public string Direccion { get; set; }
            public DateTime FechaRegistro { get; set; }
            public int CantidadFacturas { get; set; }
            public int NumeroUltimaFactura { get; set; }
            public int MontoUltimaFactura { get; set; }
        }
}

