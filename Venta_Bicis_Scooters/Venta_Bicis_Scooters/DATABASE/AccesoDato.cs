using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Venta_Bicis_Scooters.DATABASE
{
    public class AccesoDato
    {

        public static SqlConnection getConnection()
        {
            SqlConnection cn = new SqlConnection
                (ConfigurationManager.ConnectionStrings["CNX_BD"].ConnectionString);

            return cn;
        }

    }
}