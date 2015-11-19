using SAPS.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

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
        internal int insertar_ejecucion(EjecucionPruebas ejecucion) {
            /// @todo
            return 0;
        }

        /** @brief Método que realiza la sentencia para agregar un resultado a la base de datos
         * @param El objeto "Resultados_EP" que se desea agregar al sistema.
         * @return 0 si tuvo éxito la operación, números negativos si ocurrió algún problema en la base.
         */
        internal int insertar_resultado(Resultados_EP resultado) {
            /// @todo
            return 0;
        }

    }
}