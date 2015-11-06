/*
 * Universidad de Costa Rica
 * Escuela de Ciencias de la Computación e Informática
 * Ingeniería de Software I
 * Sistema Administrador de Proyectos de Software (SAPS)
 * II Semestre 2015
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAPS.Base_de_Datos;
using SAPS.Entidades;
using SAPS.Entidades.Ayudantes;
using System.Data;

namespace SAPS.Controladoras
{
    /** @brief Efectuar las comunicaciones relacionadas con los casos de pruebas con la capa de
     *  interfaz, la capa de  base de datos y controladoras de otros módulos.
     */
    public class ControladoraCasoPruebas
    {
        private BDCasoPruebas m_base_datos;

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
        public int insertar_caso_pruebas(Object[] datos, Datos[] entrada_de_datos)
        {
             CasoPruebas caso_pruebas = new CasoPruebas(datos, entrada_de_datos);              
             return m_base_datos.insertar_caso_pruebas(caso_pruebas);                    
        }

        /** @brief Método que se encarga de las operaciones necesarias para insertar un nuevo caso de pruebas en la base de datos.
        * @param datos de "objects" con los datos para el nuevo caso de pruebas.
        * @param entrada_de_datos asociados al caso de prueba.
        * @return 0 si tuvo éxito, números negativos si se presentó un error con la base de datos.
        */
        public int modificar_caso_pruebas(Object[] datos, Datos[] entrada_de_datos)
        {
            CasoPruebas caso_pruebas = new CasoPruebas(datos, entrada_de_datos);      
            return m_base_datos.insertar_caso_pruebas(caso_pruebas);            
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

        /** @brief Obtiene los casos de pruebas disponibles para un diseño en especìfico.
         * @param id_diseno Diseño del cual se quiere saber los caso de prueba asociados.
        * @return DataTable con los datos de todos los casos de pruebas que pertencen a id_diseno.
        */
        public DataTable solicitar_casos_pruebas_disponibles(int id_diseno) {
            return m_base_datos.solicitar_casos_disponibles(id_diseno);
        }

        /** @brief Asocia un caso de prueba con un requerimiento
         * @param id_caso_prueba id del caso de prueba que se quiere relacionar.
         * @param id_requerimiento id del requerimiento que se quiere relacionar.
         */
        public int asociar_caso_prueba_con_requerimiento(int id_caso_prueba, int id_requerimiento)
        {
            return 0;
        } 
    }
}