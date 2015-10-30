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
    /** @brief capa encargada de comunicarse con la base de datos 
     *  para efectuar las correspondientes inserciones, modificaciones, eliminaciones y consultas SQL
     *  relacionadas con los diseños de pruebas.
     */
    public class BDDisenoPruebas
    {
        // Variables de instancia
        DataBaseAdapter m_data_base_adapter;

        //Constructor
        public BDDisenoPruebas()
        {
            m_data_base_adapter = new DataBaseAdapter();
        }

        // Métodos

        /** @brief Método que realiza la setencia SQL para insertar un nuevo diseno de pruebas.
         * @param diseno de pruebas a guardar en la base de datos.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int insertar_diseno_pruebas(DisenoPruebas diseno_pruebas)
        {
            // Procedimiento almacenado
            SqlCommand comando = new SqlCommand("INSERTAR_DP");
            rellena_parametros_diseno_pruebas(ref comando, diseno_pruebas);
            return m_data_base_adapter.ejecutar_consulta(comando);
        }

        /** @brief Método que realiza la setencia SQL para eliminar un diseño de pruebas en específico.
         * @param id del diseño que se quiere eliminar.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int eliminar_diseno_pruebas(int id_diseno)
        {
            SqlCommand comando = new SqlCommand("ELIMINAR_DP");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@username", SqlDbType.Int).Value = id_diseno;
            return m_data_base_adapter.ejecutar_consulta(comando);
        }

        // Métodos auxiliares

        /** @brief Método auxiliar que rellena los parámetros de un diseño de pruebas para poder realizar un procedimiento almacenado.
        *  @param comando comando sql que contendrá el procedimiento y sus respectivos parámetros. Se envía por referencia por lo tanto se va a modificar.
        *  @param diseno_pruebas con la información necesaria para realizar el procedimiento.
        */
        private void rellena_parametros_diseno_pruebas(ref SqlCommand comando, DisenoPruebas diseno_pruebas)
        {
            /// @todo
        }
    }
}