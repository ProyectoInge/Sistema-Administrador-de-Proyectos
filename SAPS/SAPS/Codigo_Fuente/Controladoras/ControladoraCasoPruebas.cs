/*
 * Universidad de Costa Rica
 * Escuela de Ciencias de la Computación e Informática
 * Ingeniería de Software I
 * Sistema Administrador de Proyectos de Software (SAPS)
 * II Semestre 2015
*/

using System;
using SAPS.Base_de_Datos;
using SAPS.Entidades;
using SAPS.Entidades.Ayudantes;
using System.Data;
using System.Collections.Generic;

namespace SAPS.Controladoras
{
    /** @brief Efectuar las comunicaciones relacionadas con los casos de pruebas con la capa de
     *  interfaz, la capa de  base de datos y controladoras de otros módulos.
     */
    public class ControladoraCasoPruebas
    {
        // Variables de instancia
        private BDCasoPruebas m_base_datos;

        private ControladoraRecursosHumanos m_controladora_rh;
        private ControladoraProyectoPruebas m_controladora_pdp;
        private ControladoraDisenosPruebas m_controladora_dp;

        // Constructor de la clase
        public ControladoraCasoPruebas()
        {
            m_base_datos = new BDCasoPruebas();
        }

        /** @brief Método que se encarga de las operaciones necesarias para insertar un nuevo caso de pruebas en la base de datos.
        * @param datos de "objects" con los datos para el nuevo caso de pruebas.
        * @param entrada_de_datos asociados al caso de prueba.
        * @return 0 si tuvo éxito, números negativos si se presentó un error con la base de datos.
        */
        public int insertar_caso_pruebas(Object[] datos, Dato[] entrada_de_datos)
        {
            CasoPruebas caso_pruebas = new CasoPruebas(datos, entrada_de_datos);
            return m_base_datos.insertar_caso_pruebas(caso_pruebas);
        }

        /** @brief Método que se encarga de las operaciones necesarias para insertar un nuevo caso de pruebas en la base de datos.
        * @param datos de "objects" con los datos para el nuevo caso de pruebas.
        * @param entrada_de_datos asociados al caso de prueba.
        * @return 0 si tuvo éxito, números negativos si se presentó un error con la base de datos.
        */
        public int modificar_caso_pruebas(Object[] datos, Dato[] entrada_de_datos)
        {
            CasoPruebas caso_pruebas = new CasoPruebas(datos, entrada_de_datos);
            return m_base_datos.modificar_caso_pruebas(caso_pruebas);
        }

        /** @brief Eliminar un caso de pruebas en la base de datos.
        * @param id_caso que se desea eliminar.
        * @return 0 si tuvo éxito, números negativos si se presentó un error con la base de datos.
        */
        public int eliminar_caso_pruebas(string id_caso)
        {
            return m_base_datos.eliminar_caso_pruebas(id_caso);
        }

        /** @brief Obtiene un caso de pruebas en especìfico.
        * @param id_caso que se desea consultar.
        * @return DataTable con los datos del caso de pruebas que se consultó.
        */
        public DataTable consultar_caso_pruebas(string id_caso)
        {
            return m_base_datos.consultar_caso_pruebas(id_caso);
        }

        /** @brief Obtiene en un array las entradas disponibles para un caso de prueba.
         *  @param id_caso id del caso de prueba al cual se quiere consultar las entradas de datos asociadas.
         *  @return Array de la clase Datos con los resultados.
         */
        public DataTable consultar_entrada_dato(string id_caso)
        {
            return m_base_datos.consultar_entrada_datos(id_caso);
        }


        /** @brief Obtiene los casos de pruebas disponibles para un diseño en especìfico.
         * @param id_diseno Diseño del cual se quiere saber los caso de prueba asociados.
        * @return DataTable con los datos de todos los casos de pruebas que pertencen a id_diseno.
        */
        public DataTable solicitar_casos_pruebas_disponibles(int id_diseno)
        {
            return m_base_datos.solicitar_casos_disponibles(id_diseno);
        }


        public DataTable solicitar_casos_filtrados(List<int> llaves_disenos)
        {
            return m_base_datos.solicitar_casos_filtrados(llaves_disenos);
        }

        // Métodos que llaman a otras controladoras

        public bool es_administrador(string nombre_usuario)
        {
            m_controladora_rh = new ControladoraRecursosHumanos();
            return m_controladora_rh.es_administrador(nombre_usuario);
        }

        public DataTable consultar_mi_proyecto(string nombre_usuario)
        {
            m_controladora_pdp = new ControladoraProyectoPruebas();
            return m_controladora_pdp.consultar_mi_proyecto(nombre_usuario);
        } 

        public DataTable solicitar_proyectos_no_eliminados()
        {
            m_controladora_pdp = new ControladoraProyectoPruebas();
            return m_controladora_pdp.solicitar_proyectos_no_eliminados();
        }

        public DataTable solicitar_disenos_asociados_proyecto(int id_proyecto)
        {
            m_controladora_dp = new ControladoraDisenosPruebas();
            return m_controladora_dp.solicitar_disenos_asociados_proyecto(id_proyecto);
        }

        public DataTable solicitar_requerimientos_asociados(int id_diseno)
        {
            m_controladora_dp = new ControladoraDisenosPruebas();
            return m_controladora_dp.solicitar_requerimientos_asociados(id_diseno);
        }

    }
}