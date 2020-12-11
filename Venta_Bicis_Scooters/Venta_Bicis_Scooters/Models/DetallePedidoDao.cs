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
    public class DetallePedidoDao : IDetallePedidoCrudDao<DetallePedido>
    {
        public List<DetallePedido> ListarDetallePedido()
        {
            List<DetallePedido> lista = new List<DetallePedido>();

            try
            {
                SqlConnection cn = AccesoDato.getConnection();
                SqlCommand cmd = new SqlCommand("usp_DTPedido_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DetallePedido emp = new DetallePedido()
                    {
                        ID = Convert.ToInt32(dr["cod_detalle_pedido"]),
                        Pedido = Convert.ToInt32(dr["nro_pedido"]),
                        Producto = dr["descrp_bicicleta"].ToString(),
                        Cantidad = Convert.ToInt32(dr["cantidad"]),
                        Total = Convert.ToDecimal(dr["total"])

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