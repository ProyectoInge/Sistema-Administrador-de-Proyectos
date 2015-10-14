/*
 * Universidad de Costa Rica
 * Escuela de Ciencias de la Computación e Informática
 * Ingeniería de Software I
 * Sistema Administrador de Proyectos de Software (SAPS)
 * II Semestre 2015
*/

using System.Data;
using SAPS.Entidades;

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
            return 0;
        }

        /** @brief Método que realiza la setencia SQL para modificar un proyecto.
         * @param proyecto a guardar en la base de datos.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int modificar_proyecto(ProyectoPruebas proyecto)
        {
            return 0;
        }


        /** @brief Método que realiza la setencia SQL para eliminar un proyecto en específico.
         * @param id_proyecto del proyecto que se desea consultar.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int eliminar_proyecto(int id_proyecto)
        {
            return 0;
        }

        /** @brief Método que realiza la setencia SQL para conultar un proyecto en específico.
         * @param id_proyecto del proyecto que se desea consultar.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public DataTable consultar_proyecto(int id_proyecto)
        {
            return null;
        }
    }

}