using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Venta_Bicis_Scooters.ENTITY
{
    public class Cliente
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }

        public string paswoord { get; set; }


        public string Direccion { get; set; }

        public string Tarjeta { get; set; }
    
        public string Codigo_Seguridad { get; set; }


        public string estado { get; set; }



    }
}