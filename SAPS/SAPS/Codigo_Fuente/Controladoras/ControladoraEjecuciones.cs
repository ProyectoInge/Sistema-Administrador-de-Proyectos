using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAPS.Base_de_Datos;

namespace SAPS.Codigo_Fuente.Controladoras
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
        public int eliminar_diseno_pruebas(int id_diseno, int num_ejecucion)
        {
            return m_base_datos.eliminar_requerimiento(id_diseno, num_ejecucion);
        }
    }
}