using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Venta_Bicis_Scooters.ENTITY
{
    public class Trabajador
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }
        public string CodigoDireccion { get; set; }
        public string UsernameTrabajador { get; set; }
        public string PasswordTrabajador { get; set; }
    }
}