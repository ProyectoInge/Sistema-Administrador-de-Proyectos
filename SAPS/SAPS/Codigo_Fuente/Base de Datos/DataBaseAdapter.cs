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
        // Variables de instancia
        // Contiene la dirección del servidor donde se encuentra la base de datos
        const string conexion = "Data Source=proyectopruebas.cph3bzyte6rr.us-west-2.rds.amazonaws.com,1433;" +
            "Initial Catalog=proyectoDB;" +
            "User id=masterwizard;" +
            "Password=urenaselacome;";

        public DataTable obtener_resultado_consulta(SqlCommand comando_sql)
        {
            SqlConnection conexionSQL = new SqlConnection(conexion);   // @todo investigar si no lleva un try catch?
            comando_sql.Connection = conexionSQL;

            comando_sql.Connection.Open();
            SqlDataAdapter adaptador_sql = new SqlDataAdapter(comando_sql); // recibe el resultado de la consulta
            SqlCommandBuilder constructor_sql= new SqlCommandBuilder(adaptador_sql);

            DataTable tabla = new DataTable(); //la tabla recibe el resultado del comando
            adaptador_sql.Fill(tabla); //se llena la tabla
            comando_sql.Dispose();
            comando_sql.Connection.Close();

            return tabla;
        }

        public int ejecutar_consulta(SqlCommand comando_sql)
        {
            try
            {
                SqlConnection conexionSQL = new SqlConnection(conexion);
                comando_sql.Connection = conexionSQL;
                comando_sql.Connection.Open();           
                comando_sql.ExecuteNonQuery();
                comando_sql.Dispose();
                comando_sql.Connection.Close();
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