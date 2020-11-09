using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venta_Bicis_Scooters.SERVICE
{
    public interface IBicicletaCrudDao<T>
    {
        void InsertBicicleta(T e);
        void UpdateBicicleta(T e);
        void DeleteBicicleta(T e);
        T BuscarBicicleta(int id);


        List<T> ListarBicicleta();
        List<T> ConsultaBicicleta(int cod, string descripcion);
    }
}
