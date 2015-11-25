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
using System.Data;
using System.Linq;
using System.Web;

namespace SAPS.Controladoras
{
    public class ControladoraReportes
    {

        // Controladoras de las clases con las que interactua la clase EjecucionesPruebas
        private ControladoraRecursosHumanos m_controladora_rh;
        private ControladoraDisenosPruebas m_controladora_dp;
        private ControladoraCasoPruebas m_controladora_cp;

        ///@brief Constructor
        public ControladoraReportes()
        {
            m_controladora_rh = new ControladoraRecursosHumanos();
            m_controladora_dp = new ControladoraDisenosPruebas();
            m_controladora_cp = new ControladoraCasoPruebas(); 
         }

        /** @brief Recolectar información de un proyecto de pruebas en específico.
        *   @param datos_incluidos datos extra a incluir en la consulta, filtros filtros aplicables a la consulta 
        *   @return DataTable con los datos de un proyecto  en específico.
        */
        public DataTable recolectar_info_proyecto(Object [] datos_incluidos, Object [] filtros)
        {

            return null;
        }

        /** @brief Recolectar información de un diseño de pruebas en específico.
        *   @param datos_incluidos datos extra a incluir en la consulta, filtros filtros aplicables a la consulta 
        *   @return DataTable con los datos de un proyecto  en específico.
        */
        public DataTable recolectar_info_diseno(Object[] datos_incluidos, Object[] filtros)
        {

            return null;
        }

        /** @brief Recolectar información de un caso de pruebas  en específico.
        *   @param datos_incluidos datos extra a incluir en la consulta, filtros filtros aplicables a la consulta 
        *   @return DataTable con los datos de un proyecto  en específico.
        */
        public DataTable recolectar_info_caso(Object[] datos_incluidos, Object[] filtros)
        {

            return null;
        }

        /** @brief Recolectar información de una ejecución de pruebas  en específica.
        *   @param datos_incluidos datos extra a incluir en la consulta, filtros filtros aplicables a la consulta 
        *   @return DataTable con los datos de un proyecto  en específico.
        */
        public DataTable recolectar_info_ejecucion(Object[] datos_incluidos, Object[] filtros)
        {

            return null;
        }







    }
}