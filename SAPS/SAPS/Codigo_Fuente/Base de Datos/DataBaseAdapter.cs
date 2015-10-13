/*
 * Universidad de Costa Rica
 * Escuela de Ciencias de la Computación e Informática
 * Ingeniería de Software I
 * Sistema Administrador de Proyectos de Software (SAPS)
 * II Semestre 2015
*/

using System;
using System.Data;
using System.Data.SqlClient;

namespace SAPS.Base_de_Datos
{
    public class DataBaseAdapter
    {
        String conexion = "Data Source=proyectopruebas.cph3bzyte6rr.us-west-2.rds.amazonaws.com,1433;" +
            "Initial Catalog=proyectoDB;" +
            "User id=masterwizard;" +
            "Password=urenaselacome;";

        public DataTable obtener_resultado_consulta(String consulta)
        {
            SqlConnection conexionSQL = new SqlConnection(conexion);
            conexionSQL.Open(); //comienza a recibir consultas
            SqlCommand comandoSQL = new SqlCommand(consulta, conexionSQL);
            SqlDataAdapter adaptadorSQL = new SqlDataAdapter(comandoSQL); //recibe el resultado de la consulta

            SqlCommandBuilder constructorSQL = new SqlCommandBuilder(adaptadorSQL);

            DataTable tabla = new DataTable(); //la tabla recibe el resultado del comando
            adaptadorSQL.Fill(tabla); //se popula la tabla

            return tabla;
        }

        public int ejecutar_consulta(String consulta)
        {
            try
            {
                SqlConnection conexionSQL = new SqlConnection(conexion);
                conexionSQL.Open(); //comienza a recibir consultas
                SqlCommand comandoSQL = new SqlCommand(consulta, conexionSQL);
                comandoSQL.ExecuteNonQuery();
                comandoSQL.Dispose();
                conexionSQL.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error de ejecucion: " + ex.ToString());
                return -1;
            }

            return 0;
        }
    }
}