/*
 * Universidad de Costa Rica
 * Escuela de Ciencias de la Computación e Informática
 * Ingeniería de Software I
 * Sistema Administrador de Proyectos de Software (SAPS)
 * II Semestre 2015
*/

using SAPS.Entidades;
using System.Data;
using System.Data.SqlClient;

namespace SAPS.Base_de_Datos
{
    public class BDEjecuciones
    {
        /// Variables de instancia
        private DataBaseAdapter m_data_base_adapter;

        ///@brief Constructor
        public BDEjecuciones()
        {
            m_data_base_adapter = new DataBaseAdapter();
        }

        /** @brief Método que realiza la setencia SQL para eliminar una ejecución en específico.
         * @param num de la ejecución que se desea eliminar y el id de diseño relacionado.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        internal int eliminar_ejecucion(int id_diseno, int num_ejecucion)
        {
            SqlCommand comando = new SqlCommand("ELIMINAR_EP");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id_diseno", SqlDbType.Int).Value = id_diseno;
            comando.Parameters.Add("@num_ejecucion", SqlDbType.Int).Value = num_ejecucion;
            return m_data_base_adapter.ejecutar_consulta(comando);
        }


        /** @brief Método que realiza la setencia SQL para eliminar un resultado en específico de una ejecucion dada.
         * @param num del resultado que se desea eliminar y num de la ejecución y el id de diseño relacionados.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        internal int eliminar_resultado(int id_diseno, int num_ejecucion, int num_resultado)
        {
            SqlCommand comando = new SqlCommand("ELIMINAR_RESULTADO");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id_diseno", SqlDbType.Int).Value = id_diseno;
            comando.Parameters.Add("@num_ejecucion", SqlDbType.Int).Value = num_ejecucion;
            comando.Parameters.Add("@num_resultado", SqlDbType.Int).Value = num_resultado;
            return m_data_base_adapter.ejecutar_consulta(comando);
        }

        /** @brief Método que realiza la sentencia para agregar una ejecucion a la base de datos
         * @param El objeto "EjecucionPruebas" que se desea agregar al sistema.
         * @return 0 si tuvo éxito la operación, números negativos si ocurrió algún error con la Base de Datos.
         */
        internal int insertar_ejecucion(EjecucionPruebas ejecucion)
        {
            SqlCommand comando = new SqlCommand("INSERTAR_EP");
            comando.CommandType = CommandType.StoredProcedure;
            llena_parametros_ejecucion(ref comando, ejecucion);
            return m_data_base_adapter.ejecutar_consulta(comando);
        }

        /** @brief Método que realiza la sentencia para agregar un resultado a la base de datos
         * @param El objeto "Resultados_EP" que se desea agregar al sistema.
         * @return 0 si tuvo éxito la operación, números negativos si ocurrió algún problema en la base.
         */
        internal int insertar_resultado(ResultadosEP resultado)
        {
            SqlCommand comando = new SqlCommand("INSERTAR_RESULTADO");
            comando.CommandType = CommandType.StoredProcedure;
            llena_parametros_resultado(ref comando, resultado);
            return m_data_base_adapter.ejecutar_consulta(comando);
        }

        /** @brief Consulta los datos de una ejecución de una prueba.
        *   @param id_ejecucion id de la ejecucción a consultar.
        *   @return DataTable con los datos de la ejecución de pruebas.
        */
        internal DataTable consultar_ejecucion(int id_ejecucion)
        {
            SqlCommand comando = new SqlCommand("CONSULTAR_EJECUCION");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("numero_ejecucion", SqlDbType.Int).Value = id_ejecucion;
            return m_data_base_adapter.obtener_resultado_consulta(comando);
        }

        /** @brief Consulta todos los resultados asociados a una ejecución de una prueba.
        *   @param id_ejecucion id de la ejecucción a consultar.
        *   @return DataTable con los resultados asociados a la ejecución de pruebas.
        */
        internal DataTable consultar_resultados(int id_ejecucion)
        {
            SqlCommand comando = new SqlCommand("CONSULTAR_RESULTADOS");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("numero_ejecucion", SqlDbType.Int).Value = id_ejecucion;
            return m_data_base_adapter.obtener_resultado_consulta(comando);
        }

        internal DataTable consultar_ejecuciones(int id_diseno)
        {
            SqlCommand comando = new SqlCommand("CONSULTAR_EJECUCIONES");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("id_diseno", SqlDbType.Int).Value = id_diseno;
            return m_data_base_adapter.obtener_resultado_consulta(comando);
        }


        // ----------------------------------------------------------- Métodos auxiliares -----------------------------------------------------------------

        /** @brief Método auxiliar que rellena los parámetros de una ejecucion de pruebas para poder realizar un procedimiento almacenado,
                   se usa para agregar y modificar ejecuciones de pruebas.
        *  @param comando comando sql que contendrá el procedimiento y sus respectivos parámetros. Se envía por referencia por lo tanto
                  se va a modificar.
        *  @param EjecucionPruebas ejecucion con la información necesaria para realizar el procedimiento.
        */
        private void llena_parametros_ejecucion(ref SqlCommand comando, EjecucionPruebas ejecucion)
        {
            comando.Parameters.Add("@responsable", SqlDbType.VarChar).Value = ejecucion.responsable;
            comando.Parameters.Add("@id_diseno", SqlDbType.Int).Value = ejecucion.diseno_asociado;
            comando.Parameters.Add("@fecha_ultima_ejec", SqlDbType.DateTime).Value = ejecucion.fecha_ejecucion;
            comando.Parameters.Add("@incidencias", SqlDbType.VarChar).Value = ejecucion.incidencias;
        }

        /** @brief Método auxiliar que rellena los parámetros de un resultado de una ejecucion para poder realizar un procedimiento almacenado,
                   se usa para agregar resultado.
        *  @param comando comando sql que contendrá el procedimiento y sus respectivos parámetros. Se envía por referencia por lo tanto
                  se va a modificar.
        *  @param Resultado_EP resultado con la información necesaria para realizar el procedimiento.
        */
        private void llena_parametros_resultado(ref SqlCommand comando, ResultadosEP resultado)
        {
            comando.Parameters.Add("@id_diseno", SqlDbType.Int).Value = resultado.identificador_diseno;
            comando.Parameters.Add("@num_ejecucion", SqlDbType.Int).Value = resultado.num_ejecucion;
            comando.Parameters.Add("@estado", SqlDbType.VarChar).Value = resultado.estado;
            comando.Parameters.Add("@tipo_no_conformidad", SqlDbType.VarChar).Value = resultado.tipo_no_conf;
            comando.Parameters.Add("@id_caso", SqlDbType.VarChar).Value = resultado.identificador_caso;
            comando.Parameters.Add("@desc_no_conformidad", SqlDbType.VarChar).Value = resultado.descripcion_no_conformidad;
            comando.Parameters.Add("@justificacion", SqlDbType.VarChar).Value = resultado.justificacion;
            comando.Parameters.Add("@ruta_imagen", SqlDbType.VarChar).Value = resultado.ruta_imagen;
        }

    }
}