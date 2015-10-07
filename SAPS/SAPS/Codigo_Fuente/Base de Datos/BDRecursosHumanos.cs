using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using SAPS.Codigo_Fuente.Base_de_Datos;
using SAPS.Entidades;

namespace SAPS.Codigo_Fuente.Base_de_Datos
{
    public class BDRecursosHumanos
    {
        // Variables de instacia
        DataBaseAdapter m_data_base_adapter;

        // Constructor
        public BDRecursosHumanos()
        {
            m_data_base_adapter = new DataBaseAdapter();
        }

        // Métodos

        public int insertar_recurso_humano(RecursoHumano recurso_humano)
        {
            string consulta = "INSERT INTO RecursosHumanos VALUES( \'" + recurso_humano.usuario +
                "\' , \'" + recurso_humano.proyecto_asociado +
                "\' , \'" + recurso_humano.telefono +
                "\' , \'" + recurso_humano.contrasena +
                "\' , \'" + recurso_humano.correo +
                "\' , \'" + recurso_humano.es_administrador +
                "\' );";

            Console.WriteLine("Ejecutando: " + consulta);
            return m_data_base_adapter.ejecutar_consulta(consulta);
        }

        public int modificar_recurso_humano(RecursoHumano recurso_humano)
        {
            string consulta = "UPDATE RecursosHumanos SET id_proyecto = \'" + recurso_humano.proyecto_asociado +
                "\', telefono = \'" + recurso_humano.telefono +
                "\', nombre = \'" + recurso_humano.nombre +
                "\', correo = \'" + recurso_humano.correo +
                "\' WHERE username = \'" + recurso_humano.usuario +
                "\';";

            Console.WriteLine("Ejecutando: " + consulta);
            return m_data_base_adapter.ejecutar_consulta(consulta);
        }

        public int eliminar_recurso_humano(string nombre_usuario)
        {
            string consulta = "DELETE FROM RecursosHumanos WHERE username = \'" + nombre_usuario +
                "\';";

            Console.WriteLine("Ejecutando: " + consulta);
            return m_data_base_adapter.ejecutar_consulta(consulta);
        }

        public DataTable consultar_recurso_humano(string nombre_usuario)
        {
            string consulta = "SELECT * FROM RecursosHumanos WHERE username = \'" + nombre_usuario +
                "\';";

            Console.WriteLine("Ejecutando: " + consulta);
            return m_data_base_adapter.obtener_resultado_consulta(consulta);
        }

        public DataTable solicitar_recursos_disponibles()
        {
            string consulta = "SELECT nombre FROM RecursosHumanos";

            Console.WriteLine("Ejecutando: "+ consulta);
            return m_data_base_adapter.obtener_resultado_consulta(consulta);
        }
    }
}