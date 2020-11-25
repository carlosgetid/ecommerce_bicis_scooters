﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
           
            Accesorio = new Accesorio();
        }

        public CarritoItem(Bicicleta bicicleta, Scooter scooter, Accesorio accesorio, int cantidad)
        {
             Scooter = new Scooter()  ;
            Bicicleta = bicicleta;
            Scooter = scooter;
            Accesorio = accesorio;
            Cantidad = cantidad;
        }
    }
}