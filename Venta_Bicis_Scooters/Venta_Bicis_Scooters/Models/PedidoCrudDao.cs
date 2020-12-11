using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Venta_Bicis_Scooters.DATABASE;
using Venta_Bicis_Scooters.ENTITY;
using Venta_Bicis_Scooters.SERVICE;

namespace Venta_Bicis_Scooters.Models
{
    public class PedidoCrudDao : IPedidoCrudDao<Pedido>
    {
        public List<Pedido> ListarPedido()
        {
            List<Pedido> lista = new List<Pedido>();

            try
            {
                SqlConnection cn = AccesoDato.getConnection();
                SqlCommand cmd = new SqlCommand("usp_Pedido_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Pedido emp = new Pedido()
                    {
                        ID = Convert.ToInt32(dr["nro_pedido"]),
                        Fecha = dr["fecha_pedido"].ToString(),
                        Total = Convert.ToDecimal(dr["total_pedido"])

                    };
                    lista.Add(emp);
                }
                dr.Close();
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lista;
        }
    
    
    
    }
}