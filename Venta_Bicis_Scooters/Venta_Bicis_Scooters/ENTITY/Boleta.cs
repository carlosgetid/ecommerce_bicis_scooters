using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Venta_Bicis_Scooters.ENTITY
{
    public class Boleta
    {
        public int ID { get; set; }
        public string Fecha { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
        public int Pedido { get; set; }
    }
}