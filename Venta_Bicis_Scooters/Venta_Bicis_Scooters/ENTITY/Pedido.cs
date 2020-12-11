using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Venta_Bicis_Scooters.ENTITY
{
    public class Pedido
    {
        public int ID { get; set; }
        public string Fecha { get; set; }
        public decimal Total { get; set; }
    }
}