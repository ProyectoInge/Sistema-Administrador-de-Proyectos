/*
 * Universidad de Costa Rica
 * Escuela de Ciencias de la Computación e Informática
 * Ingeniería de Software I
 * Sistema Administrador de Proyectos de Software (SAPS)
 * II Semestre 2015
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAPS.Entidades;
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
            rellena_parametros_caso_pruebas(ref comando, caso_pruebas);
            return m_data_base_adapter.ejecutar_consulta(comando);

            
        }

        /** @brief Método que realiza la setencia SQL para eliminar un caso de pruebas en específico.
         * @param id del caso que se quiere eliminar.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int eliminar_caso_pruebas(int id_caso)
        {
            SqlCommand comando = new SqlCommand("ELIMINAR_CP");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id_caso", SqlDbType.Int).Value = id_caso;
            return m_data_base_adapter.ejecutar_consulta(comando);
        }

        /** @brief Método que realiza la setencia SQL para modificar un caso de pruebas.
             * @param caso a guardar en la base de datos.
             * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
             */
        public int modificar_caso_pruebas(CasoPruebas caso)
        {
            SqlCommand comando = new SqlCommand("MODIFICAR_CP");
            rellena_parametros_caso_pruebas(ref comando, caso);
            return m_data_base_adapter.ejecutar_consulta(comando);
        }

        /** @brief Método que realiza la setencia SQL para conultar un caso de pruebas en específico
            * @param id del caso que se desea consultar.
            * @return DataTable con los resultados de la consultas.
            */

        public DataTable consultar_caso_pruebas(int id_caso)
        {
            SqlCommand comando = new SqlCommand("CONSULTAR_CP");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id_caso", SqlDbType.Int).Value = id_caso;
            return m_data_base_adapter.obtener_resultado_consulta(comando);

        }

        /** @brief Método que realiza la setencia SQL para consultar todos los casos de pruebas que se encuentran en la base de datos.
             * @return DataTable con los resultados de la consultas.
            */
        public DataTable solicitar_casos_disponibles()
        {
            SqlCommand comando = new SqlCommand("CONSULTAR_CASOS_DISPONIBLES");
            comando.CommandType = CommandType.StoredProcedure;
            return m_data_base_adapter.obtener_resultado_consulta(comando);
        }

                                                     // Métodos auxiliares

        
        
        /** @brief Método auxiliar que rellena los parámetros de un caso de pruebas para poder realizar un procedimiento almacenado,
                   se usa para agregar y modificar casos de prueba.
        *  @param comando comando sql que contendrá el procedimiento y sus respectivos parámetros. Se envía por referencia por lo tanto
                  se va a modificar.
        *  @param caso de pruebas con la información necesaria para realizar el procedimiento.
        */
        private void rellena_parametros_caso_pruebas(ref SqlCommand comando, CasoPruebas caso_pruebas)
        {
            // analizar metodo
        }


    }
}