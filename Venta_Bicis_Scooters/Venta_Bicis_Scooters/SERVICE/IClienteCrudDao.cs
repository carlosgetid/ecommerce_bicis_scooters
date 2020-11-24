using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venta_Bicis_Scooters.SERVICE
{
    public interface IClienteCrudDao<T>
    {

        void InsertCliente(T e);
        void UpdateCliente(T e);

        T BuscarCliente(string user, string pass);


        List<T> ConsultarCliente(string dni);

    }
}
