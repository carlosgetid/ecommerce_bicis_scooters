using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venta_Bicis_Scooters.SERVICE
{
    public interface IFacturaCrudDao<T>
    {
        void InsertFactura(T e);
        List<T> ListarFactura();
    }
}
