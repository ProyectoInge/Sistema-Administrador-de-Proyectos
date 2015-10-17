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
         * @return DataTable con los resultados de la consultas.
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
         * @return DataTable con los resultados de la consultas.
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

        /** @brief Método que realiza la setencia SQL para reestablece la contraseña de un recurso humano especìfico que se encuentran en la Base de Datos.
         * @param nombre_usuario del recuros humano que se desea consultar.
         * @param nueva_contrasena que tendrá el recurso humano.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
        */
        public int cambiar_contrasena(RecursoHumano recurso_humano)
        {
            SqlCommand comando = new SqlCommand("CAMBIAR_CONTRASENA");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@username", SqlDbType.VarChar).Value = recurso_humano.usuario;
            comando.Parameters.Add("@nueva_contrasena", SqlDbType.VarChar).Value = recurso_humano.contrasena;
            return m_data_base_adapter.ejecutar_consulta(comando);
        }


        /** @brief Método que realiza la setencia SQL para cambiar el estado del bit de "sesion" de un usuario a encendido, marcando la sesion como iniciada
        * @param nombre_usuario del recuros humano que se desea consultar.
        * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
       */
        public int iniciar_sesion(string nombre_usuario)
        {
            SqlCommand comando = new SqlCommand("INICIAR_SESION");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@username", SqlDbType.VarChar).Value = nombre_usuario;
            return m_data_base_adapter.ejecutar_consulta(comando);
        }

        /** @brief Método que realiza la setencia SQL para cambiar el estado del bit de "sesion" de un usuario a apagado, marcando la sesion como cerrada
        * @param nombre_usuario del recuros humano que se desea consultar.
        * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
       */
        public int cerrar_sesion(string nombre_usuario)
        {
            SqlCommand comando = new SqlCommand("CERRAR_SESION");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@username", SqlDbType.VarChar).Value = nombre_usuario;
            return m_data_base_adapter.ejecutar_consulta(comando);
        }

        /** @brief Método que realiza la setencia SQL para consultar si un usuario tiene sesion iniciada o no
        * @param nombre_usuario del recuros humano que se desea consultar.
        * @return 0 si el usuario no tiene sesion iniciada, 1 si sí la tiene iniciada
       */
        public bool consultar_sesion(string nombre_usuario)
        {
            SqlCommand comando = new SqlCommand("ESTADO_SESION");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@username", SqlDbType.VarChar).Value = nombre_usuario;
            return (bool)m_data_base_adapter.obtener_resultado_consulta(comando).Rows[0]["sesion_iniciada"];
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
