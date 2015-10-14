/*
 * Universidad de Costa Rica
 * Escuela de Ciencias de la Computación e Informática
 * Ingeniería de Software I
 * Sistema Administrador de Proyectos de Software (SAPS)
 * II Semestre 2015
*/

using System.Data;
using SAPS.Entidades;
using System.Data.SqlClient;

namespace SAPS.Base_de_Datos
{
    /** @brief capa encargada de comunicarse con la base de datos 
     * para efectuar las correspondientes inserciones, modificaciones, eliminaciones y consultas SQL
     * relacionadas con los recusros humanos.
     */
    public class BDProyectoPruebas
    {
        // Variables de instancia
        DataBaseAdapter m_data_base_adapter;

        // Constructor
        public BDProyectoPruebas()
        {
            m_data_base_adapter = new DataBaseAdapter();
        }


        // Métodos

        /** @brief Método que realiza la setencia SQL para insertar un proyecto.
         * @param proyecto a guardar en la base de datos.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int insertar_proyecto(ProyectoPruebas proyecto)
        {
            // Procedimiento almacenado
            SqlCommand comando = new SqlCommand("INSERTAR_PYP"); // Cambiar nombre
            rellenar_parametros_proyecto_pruebas(ref comando, proyecto);
            return m_data_base_adapter.ejecutar_consulta(comando);
        }

        /** @brief Método que realiza la setencia SQL para modificar un proyecto.
         * @param proyecto a guardar en la base de datos.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int modificar_proyecto(ProyectoPruebas proyecto)
        {
            // Procedimiento almacenado
            SqlCommand comando = new SqlCommand("MODIFICAR_PYP"); // Cambiar nombre
            rellenar_parametros_proyecto_pruebas(ref comando, proyecto);
            return m_data_base_adapter.ejecutar_consulta(comando);
        }


        /** @brief Método que realiza la setencia SQL para eliminar un proyecto en específico.
         * @param id_proyecto del proyecto que se desea consultar.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int eliminar_proyecto(int id_proyecto)
        {
            // Procedimiento almacenado
            SqlCommand comando = new SqlCommand("ELIMINAR_PYP"); // Cambiar nombre
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id_proyecto", SqlDbType.Int).Value = id_proyecto;
            return m_data_base_adapter.ejecutar_consulta(comando);
        }

        /** @brief Método que realiza la setencia SQL para conultar un proyecto en específico.
         * @param id_proyecto del proyecto que se desea consultar.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public DataTable consultar_proyecto(int id_proyecto)
        {
            // Procedimiento almacenado
            SqlCommand comando = new SqlCommand("CONSULTAR_PYP"); // Cambiar nombre
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id_proyecto", SqlDbType.Int).Value = id_proyecto;
            return m_data_base_adapter.obtener_resultado_consulta(comando);
        }


        // Métodos auxiliares
        private void rellenar_parametros_proyecto_pruebas(ref SqlCommand comando, ProyectoPruebas proyecto)
        {
            comando.CommandType = CommandType.StoredProcedure;
            /// @todo rellenar procedimineto almacenado

            //comando.Parameters.Add("@id_oficina", SqlDbType.VarChar).Value = proyecto.; // Falta oficina
            comando.Parameters.Add("@fecha_inicio", SqlDbType.VarChar).Value = proyecto.fecha_inicio;
            comando.Parameters.Add("@fecha_asignacion", SqlDbType.VarChar).Value = proyecto.fecha_asignacion;
            comando.Parameters.Add("@fecha_final", SqlDbType.VarChar).Value = proyecto.fecha_finalizacion;
            comando.Parameters.Add("@nombre_sistema", SqlDbType.VarChar).Value = proyecto.nombre_sistema;
            comando.Parameters.Add("@obj_general", SqlDbType.VarChar).Value = proyecto.objetivo;
            comando.Parameters.Add("@nombre_proyecto", SqlDbType.VarChar).Value = proyecto.nombre;
            comando.Parameters.Add("@estado", SqlDbType.VarChar).Value = proyecto.estado;
        }
    }

}