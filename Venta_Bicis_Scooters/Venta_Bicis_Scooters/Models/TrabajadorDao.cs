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
    public class TrabajadorDao : ITrabajadorDao<Trabajador>
    {
        public Trabajador BuscarTrabajador(string user, string pass)
        {
            Trabajador trabajador = null;

            SqlConnection cn = AccesoDato.getConnection();
            SqlCommand cmd = new SqlCommand("usp_Trabajador_Buscar", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", user);
            cmd.Parameters.AddWithValue("@password", pass);

            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    trabajador = new Trabajador()
                    {
                        Nombre = dr[0].ToString(),
                        Apellido = dr[1].ToString(),
                        DNI = dr[2].ToString(),
                        Correo = dr[3].ToString(),
                        Celular = dr[4].ToString(),
                        UsernameTrabajador = dr[5].ToString(),
                        PasswordTrabajador = dr[6].ToString()
                    };
                }
                dr.Close();
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return trabajador;
        }

        public int UpdateTrabajador(Trabajador t)
        {
            throw new NotImplementedException();
        }
    }
}