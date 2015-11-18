using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAPS.Base_de_Datos;

namespace SAPS.Controladoras
{
    public class ControladoraEjecuciones
    {
        /// Variables de instancia
        private BDEjecuciones m_base_datos;

        ///@brief Constructor
        public ControladoraEjecuciones()
        {
            m_base_datos = new BDEjecuciones();
        }

        /** @brief Método que se encarga de las operaciones necesarias para eliminar una ejecucion de pruebas de la base de datos.
        * @param num de la ejecución que se desea eliminar y el id de diseño relacionado.
        * @return 0 si tuvo éxito, números negativos si se presentó un error con la base de datos.
        */
        internal int eliminar_ejecucion(int id_diseno, int num_ejecucion)
        {
            return m_base_datos.eliminar_ejecucion(id_diseno, num_ejecucion);
        }

        /** @brief se encarga de las operaciones necesarias para eliminar un reusltado en específico de una ejecucion dada.
         * @param num del resultado que se desea eliminar y num de la ejecución y el id de diseño relacionados.
        * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
        */
        internal int eliminar_resultado(int id_diseno, int num_ejecucion, int num_resultado)
        {
            return m_base_datos.eliminar_resultado(id_diseno, num_ejecucion, num_resultado);
        }
    }
}