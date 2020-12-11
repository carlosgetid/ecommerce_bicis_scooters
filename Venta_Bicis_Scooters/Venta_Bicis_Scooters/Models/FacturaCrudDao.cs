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
    public class FacturaCrudDao : IFacturaCrudDao<Factura>
    {
        public void InsertFactura(Factura e)
        {
            try
            {
                SqlConnection cn = AccesoDato.getConnection();
                SqlCommand cmd = new SqlCommand("usp_Factura_Insertar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@cod_ruc", e.Ruc);
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

        public List<Factura> ListarFactura()
        {
            List<Factura> lista = new List<Factura>();

            try
            {
                SqlConnection cn = AccesoDato.getConnection();
                SqlCommand cmd = new SqlCommand("usp_Factura_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Factura emp = new Factura()
                    {
                        ID = Convert.ToInt32(dr["nro_factura"]),
                        Ruc = dr["cod_ruc"].ToString(),
                        Fecha = dr["fecha_factura"].ToString(),
                        Pedido = Convert.ToInt32(dr["nro_pedido"]),
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