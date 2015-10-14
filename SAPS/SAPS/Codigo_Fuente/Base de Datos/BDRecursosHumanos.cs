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
using SAPS.Entidades;

namespace SAPS.Base_de_Datos
{
    /** @brief capa encargada de comunicarse con la base de datos 
      * para efectuar las correspondientes inserciones, modificaciones, eliminaciones y consultas SQL
     *  relacionadas con los recusros humanos.
     */
    public class BDRecursosHumanos
    {
        // Variables de instancia
        DataBaseAdapter m_data_base_adapter;

        // Constructor
        public BDRecursosHumanos()
        {
            m_data_base_adapter = new DataBaseAdapter();
        }


        // Métodos

        /** @brief Método que realiza la setencia SQL para insertar un recurso humano.
         * @param recurso_humano a guardar en la base de datos.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int insertar_recurso_humano(RecursoHumano recurso_humano)
        {
            // Procedimiento almacenado
            SqlCommand comando = new SqlCommand("INSERTAR_RH");
            rellenar_parametros_recurso_humano(ref comando, recurso_humano);
            return m_data_base_adapter.ejecutar_consulta(comando);
        }

        /** @brief Método que realiza la setencia SQL para modificar un recurso humano.
         * @param recurso_humano a guardar en la base de datos.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int modificar_recurso_humano(RecursoHumano recurso_humano)
        {
            // Procedimiento almacenado
            SqlCommand comando = new SqlCommand("MODIFICAR_RH");
            rellenar_parametros_recurso_humano(ref comando, recurso_humano);
            return m_data_base_adapter.ejecutar_consulta(comando);
        }


        /** @brief Método que realiza la setencia SQL para eliminar un recurso humano en específico.
         * @param nombre_usuario del recuros humano que se desea consultar.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int eliminar_recurso_humano(string nombre_usuario)
        {
            // Procedimiento almacenado
            SqlCommand comando = new SqlCommand("ELIMINAR_RH");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@username", SqlDbType.VarChar).Value = nombre_usuario;
            return m_data_base_adapter.ejecutar_consulta(comando);
        }

        /** @brief Método que realiza la setencia SQL para conultar un recurso humano en específico.
         * @param nombre_usuario del recuros humano que se desea consultar.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public DataTable consultar_recurso_humano(string nombre_usuario)
        {
            // Procedimiento almacenado
            SqlCommand comando = new SqlCommand("CONSULTAR_RH");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@username", SqlDbType.VarChar).Value = nombre_usuario;
            return m_data_base_adapter.obtener_resultado_consulta(comando);
        }

        /** @brief Método que realiza la setencia SQL para consultar todos recursos humanos que se encuentran en la Base de Datos.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public DataTable solicitar_recursos_disponibles()
        {
            // Procedimiento almacenado
            SqlCommand comando = new SqlCommand("CONSULTAR_RECURSOS_DISPONIBLES");
            comando.CommandType = CommandType.StoredProcedure;
            return m_data_base_adapter.obtener_resultado_consulta(comando);
        }

        /** @brief Método que realiza la setencia SQL para consultar la contraseña de un recurso humano especìfico que se encuentran en la Base de Datos.
         * @return string con la contraseña del ususario.
        */
        public string recuperar_contrasena(string nombre_usuario)
        {
            // Procedimiento almacenado
            SqlCommand comando = new SqlCommand("CONSULTAR_CONTRASENA");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@username", SqlDbType.VarChar).Value = nombre_usuario;
            DataTable tabla_contrasena = m_data_base_adapter.obtener_resultado_consulta(comando);
            return tabla_contrasena.Rows[0]["contrasena"].ToString();
        }


        // Métodos auxiliares

        /** @brief Método auxiliar que rellena los parámetros de un recurso humano para poder realizar un procedimiento almacenado.
        *  @param comando comando sql que contendrá el procedimiento y sus respectivos parámetros. Se envía por referencia por lo tanto se va a modificar.
        *  @param recurso_humano recurso humano con la información necesaria para realizar el procedimiento.
        */
        private void rellenar_parametros_recurso_humano(ref SqlCommand comando, RecursoHumano recurso_humano)
        {
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@username", SqlDbType.VarChar).Value = recurso_humano.usuario;
            comando.Parameters.Add("@cedula", SqlDbType.VarChar).Value = recurso_humano.cedula;
            if (recurso_humano.es_administrador)
            {
                comando.Parameters.Add("@id_proyecto", SqlDbType.Int).Value = DBNull.Value;
                comando.Parameters.Add("@rol", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                comando.Parameters.Add("@id_proyecto", SqlDbType.Int).Value = recurso_humano.proyecto_asociado;
                comando.Parameters.Add("@rol", SqlDbType.VarChar).Value = recurso_humano.rol;
            }
            comando.Parameters.Add("@telefono", SqlDbType.VarChar).Value = recurso_humano.telefono;
            comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = recurso_humano.nombre;
            comando.Parameters.Add("@hashed", SqlDbType.VarChar).Value = recurso_humano.contrasena;
            comando.Parameters.Add("@correo", SqlDbType.VarChar).Value = recurso_humano.correo;
            comando.Parameters.Add("@admin", SqlDbType.Bit).Value = recurso_humano.es_administrador ? 1 : 0;
        }

    }
}
