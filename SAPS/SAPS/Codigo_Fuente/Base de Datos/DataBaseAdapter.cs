
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace SAPS.App_Code.Base_de_Datos
{
    public class DataBaseAdapter

    {
        String conexion = "Data Source=proyectopruebas.cph3bzyte6rr.us-west-2.rds.amazonaws.com,1433;" +
            "Initial Catalog=proyectoDB;" +
            "User id=masterwizard;" +
            "Password=urenaselacome;";

        public DataTable ejecutar_consulta(String consulta)
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
    }

}