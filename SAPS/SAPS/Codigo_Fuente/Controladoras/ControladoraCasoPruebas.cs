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
using System.Data;

namespace SAPS.Controladoras
{
    /** @brief Efectuar las comunicaciones relacionadas con los casos de pruebas con la capa de
               interfaz, la capa de  base de datos y controladoras de otros módulos.
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
        * @param Vector de "objects" con los datos para el nuevo caso de pruebas.
        * @return 0 si tuvo éxito, números negativos si se presentó un error con la base de datos.
        */
        public int insertar_caso_pruebas(Object[] datos)
        {
            CasoPruebas caso_pruebas = new CasoPruebas(datos);
            return m_base_datos.insertar_caso_pruebas(caso_pruebas);        
        }

        /** @brief Método que se encarga de las operaciones necesarias para modificar un caso de pruebas en la base de datos.
        * @param Vector de "objects" con los datos para el caso de pruebas.
        * @return 0 si tuvo éxito, números negativos si se presentó un error con la base de datos.
        */
        public int modificar_caso_pruebas(Object[] datos)
        {
            CasoPruebas caso_pruebas = new CasoPruebas(datos);
            return m_base_datos.insertar_caso_pruebas(caso_pruebas);
        }

        /** @brief Método que se encarga de las operaciones necesarias para eliminar un nuevo caso de pruebas en la base de datos.
        * @param ID del caso que se desea eliminar.
        * @return 0 si tuvo éxito, números negativos si se presentó un error con la base de datos.
        */
        public int eliminar_caso_pruebas(int id_caso)
        {
            return m_base_datos.eliminar_caso_pruebas(id_caso);
        }

        /** @brief Método que se encarga de las operaciones necesarias para consultar un nuevo caso de pruebas en específico.
        * @param ID del caso que se desea consultar.
        * @return DataTable con los datos del caso de pruebas que se consultó.
        */
        public DataTable consultar_caso_pruebas(int id_caso)
        {
            return m_base_datos.consultar_caso_pruebas(id_caso);
        }

        /** @brief Método que se encarga de las operaciones necesarias para consultar los casos de pruebas disponibles que hay en la base de datos.
        * @return DataTable con los datos de todos los casos de pruebas disponibles que hay en la base de datos.
        */
        public DataTable solicitar_disenos_disponibles() {
            return m_base_datos.solicitar_casos_disponibles();
        }


    }
}