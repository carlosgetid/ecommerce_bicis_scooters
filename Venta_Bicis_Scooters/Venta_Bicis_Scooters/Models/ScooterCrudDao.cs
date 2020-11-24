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
    public class ScooterCrudDao : IScooterCrudDao<Scooter>
    {
        public Scooter BuscarScooter(int id)
        {
            Scooter emp = null;
            try
            {
                SqlConnection cn = AccesoDato.getConnection();
                SqlCommand cmd = new SqlCommand("usp_Scooter_Buscar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);


                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    emp = new Scooter()
                    {
                        ID = Convert.ToInt32(dr["cod_scooter"]),
                        Descripcion = dr["descrp_scooter"].ToString(),
                        codMarca = Convert.ToInt32(dr["cod_marca"]),
                        Marca = dr["descrp_marca"].ToString(),
                        Aro = dr["aro_scooter"].ToString(),
                        Color = dr["color_scooter"].ToString(),
                        Velocidad = dr["velocidad_scooter"].ToString(),
                        Motor = dr["motor_scooter"].ToString(),
                        Freno = dr["freno_scooter"].ToString(),
                        Material = dr["material_scooter"].ToString(),
                        Precio = Convert.ToDouble(dr["precio_scooter"]),
                        Stock = Convert.ToInt32(dr["stock_scooter"]),
                        codImagen = Convert.ToInt32(dr["cod_imagen"]),
                        Imagen=dr["url_imagen"].ToString()
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


        public void InsertScooter(Scooter e)
        {
            try
            {
                SqlConnection cn = AccesoDato.getConnection();
                SqlCommand cmd = new SqlCommand("usp_Scooter_Insertar", cn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@Descrp_Scooter", e.Descripcion);
                cmd.Parameters.AddWithValue("@Cod_Marca", e.codMarca);
                cmd.Parameters.AddWithValue("@Aro_Scooter", e.Aro);
                cmd.Parameters.AddWithValue("@Color_Scooter", e.Color);
                cmd.Parameters.AddWithValue("@Velocidad_Scooter", e.Velocidad);
                cmd.Parameters.AddWithValue("@Motor_Scooter", e.Motor);
                cmd.Parameters.AddWithValue("@Freno_Scooter", e.Freno);
                cmd.Parameters.AddWithValue("@Material_Scooter", e.Material);
                cmd.Parameters.AddWithValue("@Precio_Scooter", e.Precio);
                cmd.Parameters.AddWithValue("@Stock_Scooter", e.Stock);
                cmd.Parameters.AddWithValue("@Cod_Imagen", e.codImagen);

                cn.Open();
                bool iresult = cmd.ExecuteNonQuery() == 1 ? true : false;
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }


        public List<Scooter> ListarScooter()
        {
            List<Scooter> lista = new List<Scooter>();

            try
            {
                SqlConnection cn = AccesoDato.getConnection();
                SqlCommand cmd = new SqlCommand("usp_Scooter_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Scooter emp = new Scooter()
                    {
                        ID = Convert.ToInt32(dr["cod_scooter"]),
                        Descripcion = dr["descrp_scooter"].ToString(),
                        Marca = dr["descrp_marca"].ToString(),
                        Aro = dr["aro_scooter"].ToString(),
                        Color = dr["color_scooter"].ToString(),
                        Velocidad = dr["velocidad_scooter"].ToString(),
                        Motor = dr["motor_scooter"].ToString(),
                        Freno = dr["freno_scooter"].ToString(),
                        Material = dr["material_scooter"].ToString(),
                        Precio = Convert.ToDouble(dr["precio_scooter"]),
                        Stock = Convert.ToInt32(dr["stock_scooter"]),
                        Imagen = dr["url_imagen"].ToString()
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



        public void UpdateScooter(Scooter e)
        {
            try
            {
                SqlConnection cn = AccesoDato.getConnection();
                SqlCommand cmd = new SqlCommand("usp_Scooter_Actualizar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
             
               
                cmd.Parameters.AddWithValue("@Descrp_Scooter", e.Descripcion);
                cmd.Parameters.AddWithValue("@Cod_Marca", e.codMarca);
                cmd.Parameters.AddWithValue("@Aro_Scooter", e.Aro);
                cmd.Parameters.AddWithValue("@Color_Scooter", e.Color);
                cmd.Parameters.AddWithValue("@Velocidad_Scooter", e.Velocidad);
                cmd.Parameters.AddWithValue("@Motor_Scooter", e.Motor);
                cmd.Parameters.AddWithValue("@Freno_Scooter", e.Freno);
                cmd.Parameters.AddWithValue("@Material_Scooter", e.Material);
                cmd.Parameters.AddWithValue("@Precio_Scooter", e.Precio);
                cmd.Parameters.AddWithValue("@Stock_Scooter", e.Stock);
                cmd.Parameters.AddWithValue("@Cod_Imagen", e.codImagen);
                cmd.Parameters.AddWithValue("@Cod_Scooter", e.ID);

                cn.Open();
                bool iresult = cmd.ExecuteNonQuery() == 1 ? true : false;
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }


        public List<Scooter> ConsultaScooter(int cod, string descripcion)
        {
            List<Scooter> lista = new List<Scooter>();

            try
            {
                SqlConnection cn = AccesoDato.getConnection();
                SqlCommand cmd = new SqlCommand("usp_Scooter_Consultar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cod_marca", cod);
                cmd.Parameters.AddWithValue("@descp_scooter", descripcion);


                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Scooter emp = new Scooter()
                    {
                        ID = Convert.ToInt32(dr["cod_scooter"]),
                        Descripcion = dr["descrp_scooter"].ToString(),
                        Marca = dr["descrp_marca"].ToString(),
                        Aro = dr["aro_scooter"].ToString(),
                        Color = dr["color_scooter"].ToString(),
                        Velocidad = dr["velocidad_scooter"].ToString(),
                        Motor = dr["motor_scooter"].ToString(),
                        Freno = dr["freno_scooter"].ToString(),
                        Material = dr["material_scooter"].ToString(),
                        Precio = Convert.ToDouble(dr["precio_scooter"]),
                        Stock = Convert.ToInt32(dr["stock_scooter"])

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