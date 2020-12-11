using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Venta_Bicis_Scooters.Models;

namespace Venta_Bicis_Scooters.ENTITY
{
    public class CarritoItem
    {
        public Bicicleta Bicicleta { get; set; }

        public Scooter Scooter { get; set; }

        public Accesorio Accesorio { get; set; }

        public int Cantidad { get; set; }

        public CarritoItem()
        {
            Bicicleta = new Bicicleta();
            Scooter = new Scooter();
            Accesorio = new Accesorio();
        }

        public CarritoItem(Bicicleta bicicleta, Scooter scooter, Accesorio accesorio, int cantidad)
        {

            Bicicleta = bicicleta;
            Scooter = scooter;
            Accesorio = accesorio;
            Cantidad = cantidad;
        }

        public CarritoItem(Bicicleta bicicleta, int cantidad)
        {
            Bicicleta = bicicleta;
            Cantidad = cantidad;
        }
    }
}