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

        /// @todo completar los metodos


    }
}