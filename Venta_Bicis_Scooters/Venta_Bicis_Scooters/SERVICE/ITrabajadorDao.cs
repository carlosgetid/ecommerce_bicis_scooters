using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venta_Bicis_Scooters.ENTITY;

namespace Venta_Bicis_Scooters.SERVICE
{
    public interface ITrabajadorDao<T>
    {
        Trabajador BuscarTrabajador(string user, string pass);
        int UpdateTrabajador(T t);

    }
}
