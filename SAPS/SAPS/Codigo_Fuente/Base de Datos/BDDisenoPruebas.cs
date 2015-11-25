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
               eliminaciones y consultas SQL relacionadas con los diseños de pruebas.
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
            comando.Parameters.Add("@id_diseno", SqlDbType.Int).Value = id_diseno;
            return m_data_base_adapter.ejecutar_consulta(comando);
        }

        /** @brief Método que realiza la setencia SQL para modificar un diseño de pruebas.
         * @param proyecto a guardar en la base de datos.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int modificar_diseno_pruebas(DisenoPruebas diseno)
        {
            SqlCommand comando = new SqlCommand("MODIFICAR_DP");
            rellena_parametros_diseno_pruebas(ref comando, diseno);
            return m_data_base_adapter.ejecutar_consulta(comando);
        }

        /** @brief Método que realiza la setencia SQL para conultar un diseño de pruebas en específico
         * @param id del disñeo que se desea consultar.
         * @return DataTable con los resultados de la consultas.
         */
        public DataTable consultar_diseno_pruebas(int id_diseno)
        {
            SqlCommand comando = new SqlCommand("CONSULTAR_DP");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id_diseno", SqlDbType.Int).Value = id_diseno;
            return m_data_base_adapter.obtener_resultado_consulta(comando);
        }

        /** @brief Método que realiza la setencia SQL para consultar todos los diseños de pruebas que se encuentran en la base de datos.
         * @return DataTable con los resultados de la consultas.
        */
        public DataTable solicitar_disenos_disponibles()
        {
            SqlCommand comando = new SqlCommand("CONSULTAR_DISENOS_DISPONIBLES");
            comando.CommandType = CommandType.StoredProcedure;
            return m_data_base_adapter.obtener_resultado_consulta(comando);
        }

        /** @brief Método que se encarga de buscar los requerimientos NO asociados a un diseño.
         * @param El identificador del diseño al que se le quieren encontrar los requerimientos que NO tiene asociados.
         * @return DataTable con todos los requerimientos que NO tiene asociados el diseño consultado.
        */
        public DataTable solicitar_requerimientos_no_asociados(int id_diseno)
        {
            SqlCommand comando = new SqlCommand("SOLICITAR_REQUERIMIENTOS_NO_ASOCIADOS");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id_diseno", SqlDbType.Int).Value = id_diseno;
            return m_data_base_adapter.obtener_resultado_consulta(comando);
        }

        /** @brief Método que se encarga de buscar los requerimientos asociados a un diseño.
         * @param El identificador del diseño al que se le quieren encontrar los requerimientos que tiene asociados.
         * @return DataTable con todos los requerimientos que tiene asociados el diseño consultado.
        */
        public DataTable solicitar_requerimientos_asociados(int id_diseno)
        {
            SqlCommand comando = new SqlCommand("SOLICITAR_REQUERIMIENTOS_ASOCIADOS");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id_diseno", SqlDbType.Int).Value = id_diseno;
            return m_data_base_adapter.obtener_resultado_consulta(comando);
        }

        /** @brief Método que se encarga de buscar los diseños asociados a un proyecto.
         * @param El identificador del proyecto al que se le quieren encontrar los diseños que tiene asociados.
         * @return DataTable con todos los diseños que tiene asociados el proyecto.
        */
        public DataTable solicitar_disenos_asociados_proyecto(int id_proyecto)
        {
            SqlCommand comando = new SqlCommand("SOLICITAR_DISENOS_ASOCIADOS_PROYECTO");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id_proyecto", SqlDbType.Int).Value = id_proyecto;
            return m_data_base_adapter.obtener_resultado_consulta(comando);
        }

        // Métodos auxiliares

        /** @brief Método auxiliar que rellena los parámetros de un diseño de pruebas para poder realizar un procedimiento almacenado,
                   se usa para agregar y modificar diseños de prueba.
        *  @param comando comando sql que contendrá el procedimiento y sus respectivos parámetros. Se envía por referencia por lo tanto
                  se va a modificar.
        *  @param diseno_pruebas con la información necesaria para realizar el procedimiento.
        */
        private void rellena_parametros_diseno_pruebas(ref SqlCommand comando, DisenoPruebas diseno_pruebas)
        {
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id_diseno", SqlDbType.Int).Value = diseno_pruebas.id_diseno;
            comando.Parameters.Add("@id_proyecto", SqlDbType.Int).Value = diseno_pruebas.id_proyecto;
            comando.Parameters.Add("@nombre_diseno", SqlDbType.VarChar).Value = diseno_pruebas.nombre_diseno;
            comando.Parameters.Add("@fecha_inicio", SqlDbType.DateTime).Value = diseno_pruebas.fecha_inicio;
            comando.Parameters.Add("@tecnica_prueba", SqlDbType.VarChar).Value = diseno_pruebas.tecnica_prueba;
            comando.Parameters.Add("@tipo_prueba", SqlDbType.VarChar).Value = diseno_pruebas.tipo_prueba;
            comando.Parameters.Add("@nivel_prueba", SqlDbType.VarChar).Value = diseno_pruebas.nivel_prueba;
            comando.Parameters.Add("@username_responsable", SqlDbType.VarChar).Value = diseno_pruebas.username_responsable;
            comando.Parameters.Add("@ambiente", SqlDbType.VarChar).Value = diseno_pruebas.ambiente;
            comando.Parameters.Add("@procedimiento", SqlDbType.VarChar).Value = diseno_pruebas.procedimiento;
            comando.Parameters.Add("@criterio_aceptacion", SqlDbType.VarChar).Value = diseno_pruebas.criterio_aceptacion;
        }
    }
}