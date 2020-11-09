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
    public class AccesorioDao : IAccesorioCrudDao<Accesorio>
    {
        public Accesorio BuscarAccesorio(int id)
        {
            Accesorio emp = null;
            try
            {
                SqlConnection cn = AccesoDato.getConnection();
                SqlCommand cmd = new SqlCommand("usp_Accesorio_Buscar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);


                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    emp = new Accesorio()
                    {
                        ID = Convert.ToInt32(dr["cod_accesorio"]),
                        Descripcion = dr["descrp_accesorio"].ToString(),
                        codMarca = Convert.ToInt32(dr["cod_marca"]),
                        Color = dr["color_accesorio"].ToString(),
                        Peso = dr["peso_accesorio"].ToString(),
                        Material = dr["material_accesorio"].ToString(),
                        Duracion = dr["duracion_accesorio"].ToString(),
                        Dimension = dr["dimension_accesorio"].ToString(),
                        Precio = Convert.ToDouble(dr["precio_accesorio"]),
                        Stock = Convert.ToInt32(dr["stock_accesorio"]),
                        codImg = Convert.ToInt32(dr["cod_imagen"])

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

        public List<Accesorio> ConsultaAccesorio(int cod, string descripcion)
        {
            List<Accesorio> lista = new List<Accesorio>();

            try
            {
                SqlConnection cn = AccesoDato.getConnection();
                SqlCommand cmd = new SqlCommand("usp_Accesorio_Consultar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cod_marca", cod);
                cmd.Parameters.AddWithValue("@descp_accesorio", descripcion);


                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Accesorio emp = new Accesorio()
                    {
                        ID = Convert.ToInt32(dr["cod_accesorio"]),
                        Descripcion = dr["descrp_accesorio"].ToString(),
                        Marca = dr["descrp_marca"].ToString(),
                        Color = dr["color_accesorio"].ToString(),
                        Peso = dr["peso_accesorio"].ToString(),
                        Material = dr["material_accesorio"].ToString(),
                        Duracion = dr["duracion_accesorio"].ToString(),
                        Dimension = dr["dimension_accesorio"].ToString(),
                        Precio = Convert.ToDouble(dr["precio_accesorio"]),
                        Stock = Convert.ToInt32(dr["stock_accesorio"])

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

        public void DeleteAccesorio(Accesorio e)
        {
            throw new NotImplementedException();
        }

        public void InsertAccesorio(Accesorio e)
        {
            try
            {
                SqlConnection cn = AccesoDato.getConnection();
                SqlCommand cmd = new SqlCommand("usp_Accesorio_Insertar", cn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@desc", e.Descripcion);
                cmd.Parameters.AddWithValue("@codmarca", e.codMarca);
                cmd.Parameters.AddWithValue("@color", e.Color);
                cmd.Parameters.AddWithValue("@peso", e.Peso);
                cmd.Parameters.AddWithValue("@material", e.Material);
                cmd.Parameters.AddWithValue("@duracion", e.Duracion);
                cmd.Parameters.AddWithValue("@dimension", e.Dimension);
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

        public List<Accesorio> ListarAccesorio()
        {
            List<Accesorio> lista = new List<Accesorio>();

            try
            {
                SqlConnection cn = AccesoDato.getConnection();
                SqlCommand cmd = new SqlCommand("usp_Accesorio_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Accesorio emp = new Accesorio()
                    {
                        ID = Convert.ToInt32(dr["cod_accesorio"]),
                        Descripcion = dr["descrp_accesorio"].ToString(),
                        Marca = dr["descrp_marca"].ToString(),
                        Color = dr["color_accesorio"].ToString(),
                        Peso = dr["peso_accesorio"].ToString(),
                        Material = dr["material_accesorio"].ToString(),
                        Duracion = dr["duracion_accesorio"].ToString(),
                        Dimension = dr["dimension_accesorio"].ToString(),
                        Precio = Convert.ToDouble(dr["precio_accesorio"]),
                        Stock = Convert.ToInt32(dr["stock_accesorio"])

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

        public void UpdateAccesorio(Accesorio e)
        {
            try
            {
                SqlConnection cn = AccesoDato.getConnection();
                SqlCommand cmd = new SqlCommand("usp_Accesorio_Insertar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", e.ID);
                cmd.Parameters.AddWithValue("@desc", e.Descripcion);
                cmd.Parameters.AddWithValue("@codmarca", e.codMarca);
                cmd.Parameters.AddWithValue("@color", e.Color);
                cmd.Parameters.AddWithValue("@peso", e.Peso);
                cmd.Parameters.AddWithValue("@material", e.Material);
                cmd.Parameters.AddWithValue("@duracion", e.Duracion);
                cmd.Parameters.AddWithValue("@dimension", e.Dimension);
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