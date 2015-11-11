/*
 * Universidad de Costa Rica
 * Escuela de Ciencias de la Computación e Informática
 * Ingeniería de Software I
 * Sistema Administrador de Proyectos de Software (SAPS)
 * II Semestre 2015
*/


using SAPS.Base_de_Datos;
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
               eliminaciones y consultas SQL relacionadas con los requerimientos.
     */
    public class BDRequerimientos
    {
        // Variables de instancia
        DataBaseAdapter m_data_base_adapter;

        //Constructor
        public BDRequerimientos()
        {
            m_data_base_adapter = new DataBaseAdapter();
        }

        //Metodos

        /** @brief Método que realiza la setencia SQL para insertar un requerimiento.
         * @param requerimiento a guardar en la base de datos.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int insertar_requerimiento(Requerimiento requerimiento)
        {
            SqlCommand comando = new SqlCommand("INSERTAR_REQUERIMIENTO");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id_requerimiento", SqlDbType.VarChar).Value = requerimiento.id;
            comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = requerimiento.nombre;
            comando.Parameters.Add("@criterio_aceptacion", SqlDbType.VarChar).Value = requerimiento.criterio_aceptacion;
            return m_data_base_adapter.ejecutar_consulta(comando);
        }

        /** @brief Método que realiza la setencia SQL para modificar un requerimiento.
         * @param requerimiento a modificar en la base de datos.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int modificar_requerimiento(Requerimiento requerimiento)
        {
            SqlCommand comando = new SqlCommand("MODIFICAR_REQUERIMIENTO");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id_requerimiento", SqlDbType.VarChar).Value = requerimiento.id;
            comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = requerimiento.nombre;
            comando.Parameters.Add("@criterio_aceptacion", SqlDbType.VarChar).Value = requerimiento.criterio_aceptacion;
            return m_data_base_adapter.ejecutar_consulta(comando);
        }

        /** @brief Método que realiza la setencia SQL para eliminar un requerimiento en específico.
         * @param id del requerimiento que se desea eliminar.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int eliminar_requerimiento(string id_requerimiento)
        {
            SqlCommand comando = new SqlCommand("ELIMINAR_REQUERIMIENTO");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id_requerimiento", SqlDbType.VarChar).Value = id_requerimiento;
            return m_data_base_adapter.ejecutar_consulta(comando);
        }

        /** @brief Método que realiza la setencia SQL para conultar un requerimiento en específico.
         * @param id del requerimiento que se desea consultar.
         * @return DataTable con los resultados de la consultas.
         */
        public DataTable consultar_requerimiento(string id_requerimiento)
        {
            SqlCommand comando = new SqlCommand("CONSULTAR_REQUERIMIENTO");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id_requerimiento", SqlDbType.VarChar).Value = id_requerimiento;
            return m_data_base_adapter.obtener_resultado_consulta(comando);
        }

        /** @brief Método que realiza la setencia SQL para consultar todos requerimientos que se encuentran en la Base de Datos.
         * @return DataTable con los resultados de la consultas.
         */
        public DataTable solicitar_requerimientos_disponibles()
        {
            SqlCommand comando = new SqlCommand("CONSULTAR_REQUERIMIENTOS_DISPONIBLES");
            comando.CommandType = CommandType.StoredProcedure;
            return m_data_base_adapter.obtener_resultado_consulta(comando);
        }

        /** @brief Método que se encarga de asociar un requerimiento con un diseño en la base de datos
         * @param Vector de objetos que viene el ID del diseño (int), el ID del requerimiento (int), los criterios de aceptacion (String), propósito (String) y el procedimiento (String). 
         * @return 0 si no hubo problema, números negativos si hubo algun problema en la base.
        */
        public int asociar_requerimiento(Object[] datos)
        {
            SqlCommand comando = new SqlCommand("ASOCIAR_REQUERIMIENTO");
            comando.CommandType = CommandType.StoredProcedure;
            // Se agarran los datos del vector de objects.
            comando.Parameters.Add("@id_diseno", SqlDbType.Int).Value = Convert.ToInt32(datos[0]);
            comando.Parameters.Add("@id_requerimiento", SqlDbType.VarChar).Value = Convert.ToInt32(datos[1]);
            comando.Parameters.Add("@proposito", SqlDbType.VarChar).Value = Convert.ToString(datos[2]);
            comando.Parameters.Add("@procedimiento", SqlDbType.VarChar).Value = Convert.ToString(datos[3]);
            // Se ejecuta el procedimiento almacenado.
            return m_data_base_adapter.ejecutar_consulta(comando);
        }
    }
}