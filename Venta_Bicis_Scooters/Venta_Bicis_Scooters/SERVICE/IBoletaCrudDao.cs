using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venta_Bicis_Scooters.SERVICE
{
    public interface IBoletaCrudDao<T>
    {
        void InsertBoleta(T e);
        List<T> ListarBoleta();
    }
}
