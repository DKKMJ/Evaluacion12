using System;

namespace Evaluacion1.Modelos
{
    public class Usuario
    {
        // Propiedad para el Rut del usuario
        public string Rut { get; set; }

        // Propiedad para el Nombre del usuario
        public string Nombre { get; set; }

        // Propiedad para indicar si el usuario es una empresa (true) o no (false)
        public Boolean Empresa { get; set; }

        // Propiedad para el número de teléfono del usuario
        public string Telefono { get; set; }

        // Propiedad para la dirección del usuario
        public string Direccion { get; set; }

        // Propiedad para la fecha de registro del usuario
        public DateTime FechaRegistro { get; set; }

        // Propiedad para la cantidad de facturas del usuario
        public int CantidadFacturas { get; set; }

        // Propiedad para el número de la última factura del usuario
        public int NumeroUltimaFactura { get; set; }

        // Propiedad para el monto de la última factura del usuario
        public int MontoUltimaFactura { get; set; }
    }
}
