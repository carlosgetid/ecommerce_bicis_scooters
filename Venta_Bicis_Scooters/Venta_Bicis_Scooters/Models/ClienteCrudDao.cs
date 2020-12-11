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
    public class ClienteCrudDao : IClienteCrudDao<Cliente>
    {

        public Cliente BuscarCliente(string user, string pass)
        {
            Cliente emp = null;
            try
            {
                SqlConnection cn = AccesoDato.getConnection();
                SqlCommand cmd = new SqlCommand("usp_Cliente_Buscar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@correo_cliente", user);
                cmd.Parameters.AddWithValue("@password_cliente", pass);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    emp = new Cliente()
                    {
        
                        Nombre = dr["nom_cliente"].ToString(),
                        Apellido = dr["ape_cliente"].ToString(),
                        DNI = dr["dni_cliente"].ToString(),
                        Correo = dr["correo_cliente"].ToString(),
                        Celular = dr["cel_cliente"].ToString(),
                        paswoord = dr["password_cliente"].ToString(),
                        Direccion = dr["direccion"].ToString(),
                        Tarjeta = dr["nro_tarjeta"].ToString(),
                        Codigo_Seguridad= dr["cod_seguridad_tarjeta"].ToString()
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

        public Cliente FindCliente(int id)
        {
            Cliente emp = null;
            try
            {
                SqlConnection cn = AccesoDato.getConnection();
                SqlCommand cmd = new SqlCommand("usp_Cliente_Find", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@cod_cliente", id);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    emp = new Cliente()
                    {
                        ID = Convert.ToInt32(dr["cod_cliente"].ToString()),
                        Nombre = dr["nom_cliente"].ToString(),
                        Apellido = dr["ape_cliente"].ToString(),
                        DNI = dr["dni_cliente"].ToString(),
                        Correo = dr["correo_cliente"].ToString(),
                        Celular = dr["cel_cliente"].ToString(),
                        paswoord = dr["password_cliente"].ToString(),
                        Direccion = dr["direccion"].ToString(),
                        Tarjeta = dr["nro_tarjeta"].ToString(),
                        Codigo_Seguridad = dr["cod_seguridad_tarjeta"].ToString()
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

        public List<Cliente> ConsultarCliente(string dni)
        {
            List<Cliente> lista = new List<Cliente>();

            try
            {
                SqlConnection cn = AccesoDato.getConnection();
                SqlCommand cmd = new SqlCommand("usp_Cliente_Consultar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@dni", dni);



                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Cliente emp = new Cliente()
                    {
                        ID = Convert.ToInt32(dr["cod_cliente"]),
                        Nombre = dr["nom_cliente"].ToString(),
                        Apellido = dr["ape_cliente"].ToString(),
                        DNI = dr["dni_cliente"].ToString(),
                        Correo = dr["correo_cliente"].ToString(),
                        Celular = dr["cel_cliente"].ToString(),
                        Direccion = dr["direccion"].ToString(),
                        Tarjeta = dr["nro_tarjeta"].ToString(),
                        Codigo_Seguridad = dr["cod_seguridad_tarjeta"].ToString()

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


        public void InsertCliente(Cliente e)
        {
            try
            {
                SqlConnection cn = AccesoDato.getConnection();
                SqlCommand cmd = new SqlCommand("usp_Cliente_Insertar", cn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@nom_cliente", e.Nombre);
                cmd.Parameters.AddWithValue("@ape_cliente", e.Apellido);
                cmd.Parameters.AddWithValue("@dni_cliente", e.DNI);
                cmd.Parameters.AddWithValue("@correo_cliente", e.Correo);
                cmd.Parameters.AddWithValue("@cel_cliente", e.Celular);
                cmd.Parameters.AddWithValue("@password_cliente", e.paswoord);
                cmd.Parameters.AddWithValue("@direc", e.Direccion);
                cmd.Parameters.AddWithValue("@nro_tarjeta", e.Tarjeta);
                cmd.Parameters.AddWithValue("@cod_seguridad", e.Codigo_Seguridad);

                cn.Open();
                bool iresult = cmd.ExecuteNonQuery() == 1 ? true : false;
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }


        }





        
        public void UpdateCliente(Cliente e)
        {
            try
            {
                SqlConnection cn = AccesoDato.getConnection();
                SqlCommand cmd = new SqlCommand("usp_Cliente_Actualizar", cn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@nom_cliente", e.Nombre);
                cmd.Parameters.AddWithValue("@ape_cliente", e.Apellido);
                cmd.Parameters.AddWithValue("@dni_cliente", e.DNI);
                cmd.Parameters.AddWithValue("@correo_cliente", e.Correo);
                cmd.Parameters.AddWithValue("@cel_cliente", e.Celular);
                cmd.Parameters.AddWithValue("@password_cliente", e.paswoord);
                cmd.Parameters.AddWithValue("@cod_cliente", e.ID);

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