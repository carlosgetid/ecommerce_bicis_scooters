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
    public class BoletaCrudDao : IBoletaCrudDao<Boleta>
    {
        public void InsertBoleta(Boleta e)
        {
            try
            {
                SqlConnection cn = AccesoDato.getConnection();
                SqlCommand cmd = new SqlCommand("usp_Boleta_Insertar", cn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@nro_pedido", e.Pedido);


                cn.Open();
                bool iresult = cmd.ExecuteNonQuery() == 1 ? true : false;
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public List<Boleta> ListarBoleta()
        {
            List<Boleta> lista = new List<Boleta>();

            try
            {
                SqlConnection cn = AccesoDato.getConnection();
                SqlCommand cmd = new SqlCommand("usp_Boleta_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Boleta emp = new Boleta()
                    {
                        ID = Convert.ToInt32(dr["nro_boleta"]),
                        Fecha = dr["fecha_boleta"].ToString(),
                        Producto = dr["descrp_bicicleta"].ToString(),
                        Cantidad = Convert.ToInt32(dr["cantidad"]),
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