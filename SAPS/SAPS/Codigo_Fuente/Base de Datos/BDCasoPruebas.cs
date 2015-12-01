﻿/*
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
using System.Collections.Generic;
using System;

namespace SAPS.Base_de_Datos
{
    /** @brief capa encargada de comunicarse con la base de datos para efectuar las correspondientes inserciones, modificaciones,
     * eliminaciones y consultas SQL relacionadas con los casos de pruebas.
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
        public int insertar_caso_pruebas(CasoPruebas caso_prueba)
        {
            // Procedimiento almacenado
            SqlCommand comando = new SqlCommand("INSERTAR_CP");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id_diseno_asociado", SqlDbType.Int).Value = caso_prueba.id_diseno;
            comando.Parameters.Add("@id_req_asociado", SqlDbType.VarChar).Value = caso_prueba.requerimiento;

            rellena_parametros_caso_pruebas(ref comando, caso_prueba);
            DataTable id = m_data_base_adapter.obtener_resultado_consulta(comando);

            string caso_id = id.Rows[0]["id_caso"].ToString();

            int resultado = 0;
            // Guardar entrada de datos
            if (caso_prueba.entrada_de_datos != null)
            {
                for (int i = 0; i < caso_prueba.entrada_de_datos.Length; ++i)
                {
                    guardar_entrada_de_datos(caso_prueba.entrada_de_datos[i], caso_id);
                }
            }
            return resultado;
        }

        /** @brief Método que realiza la setencia SQL para modificar un caso de pruebas.
         * @param caso a guardar en la base de datos.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int modificar_caso_pruebas(CasoPruebas caso_prueba)
        {
            borrar_entrada_de_datos_asociados(caso_prueba.id);

            // Se actualizan los datos del caso de pruebas
            SqlCommand comando = new SqlCommand("MODIFICAR_CP");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id_caso", SqlDbType.VarChar).Value = caso_prueba.id;

            rellena_parametros_caso_pruebas(ref comando, caso_prueba);
            int result = m_data_base_adapter.ejecutar_consulta(comando);

            // Actualiza los datos asociados a un caso de pruebas (entrada_datos[])
            if (caso_prueba.entrada_de_datos != null)
            {
                for (int i = 0; i < caso_prueba.entrada_de_datos.Length; ++i)
                {
                    guardar_entrada_de_datos(caso_prueba.entrada_de_datos[i], caso_prueba.id);
                }
            }
            return result;
        }

        /** @brief Método que realiza la setencia SQL para eliminar un caso de pruebas en específico.
         * @param id del caso que se quiere eliminar.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int eliminar_caso_pruebas(string id_caso_prueba)
        {
            borrar_entrada_de_datos_asociados(id_caso_prueba);

            SqlCommand comando = new SqlCommand("ELIMINAR_CP");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id_caso", SqlDbType.VarChar).Value = id_caso_prueba;

            return m_data_base_adapter.ejecutar_consulta(comando);
        }

        /** @brief Método que realiza la setencia SQL para conultar un caso de pruebas en específico
         * @param id del caso que se desea consultar.
         * @return DataTable con los resultados de la consultas.
         */
        public DataTable consultar_caso_pruebas(string id_caso_prueba)
        {
            SqlCommand comando = new SqlCommand("CONSULTAR_CP");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id_caso", SqlDbType.VarChar).Value = id_caso_prueba;
            return m_data_base_adapter.obtener_resultado_consulta(comando);
        }

        public DataTable consultar_entrada_datos(string id_caso_prueba)
        {
            SqlCommand comando = new SqlCommand("CONSULTAR_ENTRADA_DATOS");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id_caso_prueba", SqlDbType.VarChar).Value = id_caso_prueba;
            DataTable resultados = m_data_base_adapter.obtener_resultado_consulta(comando);
            return resultados;
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

        public DataTable solicitar_casos_filtrados(List<int> llaves_disenos)
        {
            string llaves_disenos_string = "";
            
            for (int i = 0; i < llaves_disenos.Count-1; ++i)
            {
                llaves_disenos_string += llaves_disenos[i] + ",";
            }
            llaves_disenos_string += llaves_disenos[llaves_disenos.Count - 1];

            SqlCommand comando = new SqlCommand("FILTRAR_CASOS");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id_disenos_pruebas", SqlDbType.VarChar).Value = llaves_disenos_string;
            return m_data_base_adapter.obtener_resultado_consulta(comando);
        }

        // Métodos auxiliares

        /** @brief Método auxiliar que rellena los parámetros de un caso de pruebas para poder realizar un procedimiento almacenado,
                   se usa para agregar y modificar casos de prueba.
        *  @param comando comando sql que contendrá el procedimiento y sus respectivos parámetros. Se envía por referencia por lo tanto
                  se va a modificar.
        *  @param caso de pruebas con la información necesaria para realizar el procedimiento.
        */
        private void rellena_parametros_caso_pruebas(ref SqlCommand comando, CasoPruebas caso_prueba)
        {
            comando.Parameters.Add("@proposito", SqlDbType.VarChar).Value = caso_prueba.proposito;
            comando.Parameters.Add("@resultado_esperado", SqlDbType.VarChar).Value = caso_prueba.resultado_esperado;
            comando.Parameters.Add("@flujo", SqlDbType.VarChar).Value = caso_prueba.flujo_central;
        }

        /** @brief Método auxiliar que guarda un dato el la base de datos.
        *  @param entrada_dato dato a guardar en la base de datos.
        *  @param id_caso_prueba id del caso de prueba.
        */
        private void guardar_entrada_de_datos(Dato entrada_dato, string id_caso_prueba)
        {
            SqlCommand comando_dato = new SqlCommand("INSERTAR_DATO_CP");
            comando_dato.CommandType = CommandType.StoredProcedure;
            comando_dato.Parameters.Add("@id_caso_prueba", SqlDbType.VarChar).Value = id_caso_prueba;
            comando_dato.Parameters.Add("@valor", SqlDbType.VarChar).Value = entrada_dato.valor;
            comando_dato.Parameters.Add("@tipo", SqlDbType.VarChar).Value = entrada_dato.tipo;
            m_data_base_adapter.ejecutar_consulta(comando_dato);
        }

        /** @brief Método auxiliar que borra todos los datos asociados a un caso de prueba.
        *  @param id_caso_prueba id del caso de prueba.
        */
        private void borrar_entrada_de_datos_asociados(string id_caso_pruebas)
        {
            SqlCommand comando_limpieza = new SqlCommand("BORRAR_DATO_CASO");
            comando_limpieza.CommandType = CommandType.StoredProcedure;
            comando_limpieza.Parameters.Add("@id_caso", SqlDbType.VarChar).Value = id_caso_pruebas;
            m_data_base_adapter.ejecutar_consulta(comando_limpieza);
        }
    }
}