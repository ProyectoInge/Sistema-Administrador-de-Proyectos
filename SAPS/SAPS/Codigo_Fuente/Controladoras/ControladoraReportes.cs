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
        private ControladoraProyectoPruebas m_controladora_pdp;

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
        public DataTable recolectar_info_proyecto(Object[] datos_incluidos, Object[] filtros)
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

        /** @brief Metodo que consulta los proyectos disponibles en el sistema.
         *  @return DataTable con la informacion de los proyectos disponibles en la base de datos.
         */
        public DataTable solicitar_proyectos_disponibles()
        {
            m_controladora_pdp = new ControladoraProyectoPruebas();
            return m_controladora_pdp.solicitar_proyectos_disponibles();
        }

        /** @brief Método que asigna las operaciones necesarias para poder consultar mi proyecto de pruebas.
         * @param username de quien hace la consulta.
         * @return DataTable con los resultados de la consultas.
         */
        public DataTable consultar_mi_proyecto(string nombre_usuario)
        {
            m_controladora_pdp = new ControladoraProyectoPruebas();
            return m_controladora_pdp.consultar_mi_proyecto(nombre_usuario);
        }

        /** @brief Método que consulta el perfil de un usuario del sistema, permite que se mantenga la arquitectura N capas.
         * @param nombre_usuario usuario cuyo perfil se desea consultar.
         * @return false si es administrador, true si es miembro
        */
        public bool es_administrador(string nombre_usuario)
        {
            m_controladora_rh = new ControladoraRecursosHumanos();
            return m_controladora_rh.es_administrador(nombre_usuario);
        }

        /** @brief Método que asigna las operaciones necesarias para poder consultar las oficibas disponibles.
         * @return DataTable con los resultados de la consultas.
         */
        public DataTable solicitar_oficinas_disponibles()
        {
            m_controladora_pdp = new ControladoraProyectoPruebas();
            return m_controladora_pdp.solicitar_oficinas_disponibles();
        }

        /** @brief Método que asigna las operaciones necesarias para poder consultar los recursos humanos disponibles.
         * @return DataTable con los resultados de la consultas.
         */
        public DataTable solicitar_recursos_disponibles()
        {
            m_controladora_rh = new ControladoraRecursosHumanos();
            return m_controladora_rh.solicitar_recursos_disponibles();
        }


        /** @brief Devuelve los casos de pruebas asociados a una lista de llaves primarias de disenos.
        *   @param llaves_disenos lista con las llaves primarias de los diseños
        */
        public DataTable obtener_casos_de_prueba(List<int> llaves_disenos)
        {
            return null;
        }


    }
}