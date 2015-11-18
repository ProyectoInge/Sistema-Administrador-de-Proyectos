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
        internal int eliminar_requerimiento(int id_diseno, int num_ejecucion)
        {
            SqlCommand comando = new SqlCommand("ELIMINAR_EP");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@num_ejecucion", SqlDbType.Int).Value = num_ejecucion;
            comando.Parameters.Add("@id_diseno", SqlDbType.Int).Value = id_diseno;
            return m_data_base_adapter.ejecutar_consulta(comando);
        }
    }
}