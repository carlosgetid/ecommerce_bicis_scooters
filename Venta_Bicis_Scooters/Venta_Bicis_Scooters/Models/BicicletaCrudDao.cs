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
    public class BicicletaCrudDao : IBicicletaCrudDao<Bicicleta>
    {
        public Bicicleta BuscarBicicleta(int id)
        {
            Bicicleta emp = null;
            try
            {
                SqlConnection cn = AccesoDato.getConnection();
                SqlCommand cmd = new SqlCommand("usp_Bicicleta_Buscar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);


                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    emp = new Bicicleta()
                    {
                        ID = Convert.ToInt32(dr["cod_bicicleta"]),
                        Descripcion = dr["descrp_bicicleta"].ToString(),
                        codMarca = Convert.ToInt32(dr["cod_marca"]),
                        Marca = dr["descrp_marca"].ToString(),
                        Aro = dr["aro_bicicleta"].ToString(),
                        Color = dr["color_bicicleta"].ToString(),
                        Freno = dr["freno_bicicleta"].ToString(),
                        Peso = dr["peso_bicicleta"].ToString(),
                        Precio = Convert.ToDouble(dr["precio_bicicleta"]),
                        Stock = Convert.ToInt32(dr["stock_bicicleta"]),
                        codImg = Convert.ToInt32(dr["cod_imagen"]),
                        Imagen = dr["url_imagen"].ToString(),
                    };
                }
                dr.Close();
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return emp;
        }

        public List<Bicicleta> ConsultaBicicleta(int cod, string descripcion)
        {
            List<Bicicleta> lista = new List<Bicicleta>();

            try
            {
                SqlConnection cn = AccesoDato.getConnection();
                SqlCommand cmd = new SqlCommand("usp_Bicicleta_Consultar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cod_marca", cod);
                cmd.Parameters.AddWithValue("@descp_bicicleta", descripcion);


                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Bicicleta emp = new Bicicleta()
                    {
                        ID = Convert.ToInt32(dr["cod_bicicleta"]),
                        Descripcion = dr["descrp_bicicleta"].ToString(),
                        Marca = dr["descrp_marca"].ToString(),
                        Aro = dr["aro_bicicleta"].ToString(),
                        Color = dr["color_bicicleta"].ToString(),
                        Freno = dr["freno_bicicleta"].ToString(),
                        Peso = dr["peso_bicicleta"].ToString(),
                        Precio = Convert.ToDouble(dr["precio_bicicleta"]),
                        Stock = Convert.ToInt32(dr["stock_bicicleta"])

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

        public void DeleteBicicleta(Bicicleta e)
        {
            throw new NotImplementedException();
        }

        public void InsertBicicleta(Bicicleta e)
        {
            try
            {
                SqlConnection cn = AccesoDato.getConnection();
                SqlCommand cmd = new SqlCommand("usp_Bicicleta_Insertar", cn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@desc", e.Descripcion);
                cmd.Parameters.AddWithValue("@codmarca", e.codMarca);
                cmd.Parameters.AddWithValue("@aro", e.Aro);
                cmd.Parameters.AddWithValue("@color", e.Color);
                cmd.Parameters.AddWithValue("@freno", e.Freno);
                cmd.Parameters.AddWithValue("@peso", e.Peso);
                cmd.Parameters.AddWithValue("@precio", e.Precio);
                cmd.Parameters.AddWithValue("@stock", e.Stock);
                cmd.Parameters.AddWithValue("@codimg", e.codImg);

                cn.Open();
                bool iresult = cmd.ExecuteNonQuery() == 1 ? true : false;
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public List<Bicicleta> ListarBicicleta()
        {
            List<Bicicleta> lista = new List<Bicicleta>();

            try
            {
                SqlConnection cn = AccesoDato.getConnection();
                SqlCommand cmd = new SqlCommand("usp_Bicicleta_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Bicicleta emp = new Bicicleta()
                    {
                        ID = Convert.ToInt32(dr["cod_bicicleta"]),
                        Descripcion = dr["descrp_bicicleta"].ToString(),
                        Marca = dr["descrp_marca"].ToString(),
                        Aro = dr["aro_bicicleta"].ToString(),
                        Color = dr["color_bicicleta"].ToString(),
                        Freno = dr["freno_bicicleta"].ToString(),
                        Peso = dr["peso_bicicleta"].ToString(),
                        Precio = Convert.ToDouble(dr["precio_bicicleta"]),
                        Stock = Convert.ToInt32(dr["stock_bicicleta"]),
                        Imagen =dr["url_imagen"].ToString()
                        
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

        public void UpdateBicicleta(Bicicleta e)
        {
            try
            {
                SqlConnection cn = AccesoDato.getConnection();
                SqlCommand cmd = new SqlCommand("usp_Bicicleta_Actualizar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", e.ID);
                cmd.Parameters.AddWithValue("@desc", e.Descripcion);
                cmd.Parameters.AddWithValue("@codmarca", e.codMarca);
                cmd.Parameters.AddWithValue("@aro", e.Aro);
                cmd.Parameters.AddWithValue("@color", e.Color);
                cmd.Parameters.AddWithValue("@freno", e.Freno);
                cmd.Parameters.AddWithValue("@peso", e.Peso);
                cmd.Parameters.AddWithValue("@precio", e.Precio);
                cmd.Parameters.AddWithValue("@stock", e.Stock);
                cmd.Parameters.AddWithValue("@codimg", e.codImg);

                cn.Open();
                bool iresult = cmd.ExecuteNonQuery() == 1 ? true : false;
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }





    }
}