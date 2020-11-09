using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venta_Bicis_Scooters.SERVICE
{
    public interface IScooterCrudDao<T>
    {
        void InsertScooter(T e);
        void UpdateScooter(T e);
        void DeleteScooter(T e);
        T BuscarScooter(int id);


        List<T> ListarScooter();
        List<T> ConsultaScooter(int cod, string descripcion);
    }
}
