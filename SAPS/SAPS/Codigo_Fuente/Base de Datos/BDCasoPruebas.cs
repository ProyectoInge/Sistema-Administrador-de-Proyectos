/*
 * Universidad de Costa Rica
 * Escuela de Ciencias de la Computación e Informática
 * Ingeniería de Software I
 * Sistema Administrador de Proyectos de Software (SAPS)
 * II Semestre 2015
*/

using SAPS.Entidades;
using SAPS.Entidades.Ayudantes;
using System.Data.SqlClient;
using System.Data;

namespace SAPS.Base_de_Datos
{
    /** @brief capa encargada de comunicarse con la base de datos para efectuar las correspondientes inserciones, modificaciones,
               eliminaciones y consultas SQL relacionadas con los casos de pruebas.
     */
    public class BDCasoPruebas
    {
        // Variables de instancia
        DataBaseAdapter m_data_base_adapter;

        //Constructor
        public BDCasoPruebas()
        {
            m_data_base_adapter = new DataBaseAdapter();
        }


        // Métodos

        /** @brief Método que realiza la setencia SQL para insertar un nuevo caso de pruebas.
         * @param caso de pruebas a guardar en la base de datos.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int insertar_caso_pruebas(CasoPruebas caso_pruebas)
        {
            // Procedimiento almacenado
            SqlCommand comando = new SqlCommand("INSERTAR_CP");
            rellena_parametros_caso_pruebas(ref comando, caso_pruebas, 'i');
            int resultado = m_data_base_adapter.ejecutar_consulta(comando);

            // Guardar entrada de datos
            if (caso_pruebas.entrada_de_datos != null)
            {
                for (int i = 0; i < caso_pruebas.entrada_de_datos.Length; ++i)
                {
                    guardar_entrada_de_datos(caso_pruebas.entrada_de_datos[i], caso_pruebas.id);
                    m_data_base_adapter.ejecutar_consulta(comando);
                }
            }
            return resultado;
        }

        /** @brief Método que realiza la setencia SQL para modificar un caso de pruebas.
         * @param caso a guardar en la base de datos.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int modificar_caso_pruebas(CasoPruebas caso)
        {
            borrar_entrada_de_datos_asociados(caso.id);

            // Se actualizan los datos del caso de pruebas
            SqlCommand comando = new SqlCommand("MODIFICAR_CP");
            rellena_parametros_caso_pruebas(ref comando, caso, 'm');
            int result = m_data_base_adapter.ejecutar_consulta(comando);

            // Actualiza los datos asociados a un caso de pruebas (entrada_datos[])
            if (caso.entrada_de_datos != null)
            {
                for (int i = 0; i < caso.entrada_de_datos.Length; ++i)
                {
                    guardar_entrada_de_datos(caso.entrada_de_datos[i], caso.id);
                }
            }

            return result;
        }

        /** @brief Método que realiza la setencia SQL para eliminar un caso de pruebas en específico.
         * @param id del caso que se quiere eliminar.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int eliminar_caso_pruebas(string id_caso)
        {
            borrar_entrada_de_datos_asociados(id_caso);

            SqlCommand comando = new SqlCommand("ELIMINAR_CP");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id_caso", SqlDbType.VarChar).Value = id_caso;

            return m_data_base_adapter.ejecutar_consulta(comando);
        }

        /** @brief Método que realiza la setencia SQL para conultar un caso de pruebas en específico
         * @param id del caso que se desea consultar.
         * @return DataTable con los resultados de la consultas.
         */
        public DataTable consultar_caso_pruebas(string id_caso)
        {
            SqlCommand comando = new SqlCommand("CONSULTAR_CP");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id_caso", SqlDbType.VarChar).Value = id_caso;
            return m_data_base_adapter.obtener_resultado_consulta(comando);
        }

        public Datos[] consultar_entrada_datos(string id_caso_prueba)
        {
            SqlCommand comando = new SqlCommand("CONSULTAR_ENTRADA_DATOS");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id_caso", SqlDbType.VarChar).Value = id_caso_prueba;
            DataTable resultados = m_data_base_adapter.obtener_resultado_consulta(comando);

            Datos[] resultado = new Datos[resultados.Rows.Count];

            // Se convierte a Objetos Datos y se insertan en el array
            for (int i = 0; i < resultados.Rows.Count; ++i)
            {
                Datos dato = new Datos(resultados.Rows[i]["entrada_de_datos"].ToString(), resultados.Rows[i]["estado_datos"].ToString(), resultados.Rows[i]["resultado_esperado"].ToString());
                resultado.SetValue(dato, i);
            }
            return resultado;
        }

        /** @brief Método que realiza la setencia SQL para consultar todos los casos de pruebas que se encuentran en la base de datos.
         *  @param id_diseno diseno al que se quieren consultar los casos de pruebas asociados.
         * @return DataTable con los resultados de la consultas.
         */
        public DataTable solicitar_casos_disponibles(int id_diseno)
        {
            SqlCommand comando = new SqlCommand("CONSULTAR_CASOS_DISPONIBLES");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id_diseno", SqlDbType.Int).Value = id_diseno;
            return m_data_base_adapter.obtener_resultado_consulta(comando);
        }

        /** @brief Asocia un caso de prueba con un requerimiento.
         *  @param id_caso_prueba id con el caso de prueba que se desea asociar.
         *  @param id_requerimiento id con el requerimiento que se desea asociar.
         *  @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
        */
        public int asociar_caso_prueba_con_requerimiento(string id_caso_prueba, int id_requerimiento)
        {
            SqlCommand comando = new SqlCommand("ASOCIAR_CASO_CON_REQUERIMIENTO");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id_caso_prueba", SqlDbType.VarChar).Value = id_caso_prueba;
            comando.Parameters.Add("@id_requerimiento", SqlDbType.Int).Value = id_requerimiento;
            return m_data_base_adapter.ejecutar_consulta(comando);
        }


        // Métodos auxiliares

        /** @brief Método auxiliar que rellena los parámetros de un caso de pruebas para poder realizar un procedimiento almacenado,
                   se usa para agregar y modificar casos de prueba.
        *  @param comando comando sql que contendrá el procedimiento y sus respectivos parámetros. Se envía por referencia por lo tanto
                  se va a modificar.
        *  @param caso de pruebas con la información necesaria para realizar el procedimiento.
        */
        private void rellena_parametros_caso_pruebas(ref SqlCommand comando, CasoPruebas caso_pruebas, char tipo)
        {
            comando.CommandType = CommandType.StoredProcedure;
            if('i'!=tipo)comando.Parameters.Add("@id_caso", SqlDbType.VarChar).Value = caso_pruebas.id;
            comando.Parameters.Add("@id_diseno_asociado", SqlDbType.Int).Value = caso_pruebas.id_diseno;
            comando.Parameters.Add("@proposito", SqlDbType.VarChar).Value = caso_pruebas.proposito;
            comando.Parameters.Add("@flujo", SqlDbType.VarChar).Value = caso_pruebas.flujo_central;
        }

        private void borrar_entrada_de_datos_asociados(string id_caso_pruebas)
        {
            SqlCommand comando_limpieza = new SqlCommand("BORRAR_DATO_CASO");
            comando_limpieza.CommandType = CommandType.StoredProcedure;
            comando_limpieza.Parameters.Add("@id_caso", SqlDbType.VarChar).Value = id_caso_pruebas;
            m_data_base_adapter.ejecutar_consulta(comando_limpieza);
        }

        private void guardar_entrada_de_datos(Datos entrada_dato, string id_caso_prueba)
        {
            SqlCommand comando_dato = new SqlCommand("INSERTAR_DATO_CP");
            comando_dato.CommandType = CommandType.StoredProcedure;
            comando_dato.Parameters.Add("@id_caso_prueba", SqlDbType.VarChar).Value = id_caso_prueba;
            comando_dato.Parameters.Add("@entrada_de_datos", SqlDbType.VarChar).Value = entrada_dato.valor;
            comando_dato.Parameters.Add("@estado_datos", SqlDbType.VarChar).Value = entrada_dato.estado;
            comando_dato.Parameters.Add("@resultado_esperado", SqlDbType.VarChar).Value = entrada_dato.resultado_esperado;
        }
    }
}