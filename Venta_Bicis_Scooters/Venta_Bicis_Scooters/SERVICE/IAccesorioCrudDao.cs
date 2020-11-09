using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venta_Bicis_Scooters.SERVICE
{
    public interface IAccesorioCrudDao<T>
    {
        void InsertAccesorio(T e);
        void UpdateAccesorio(T e);
        void DeleteAccesorio(T e);
        T BuscarAccesorio(int id);


        List<T> ListarAccesorio();
        List<T> ConsultaAccesorio(int cod, string descripcion);
    }
}
