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
    /** @brief Efectuar las comunicaciones relacionadas con los diseños de pruebas con la capa de
               interfaz, la capa de  base de datos y controladoras de otros módulos.
    */
    public class ControladoraDisenosPruebas
    {
        private BDDisenoPruebas m_base_datos;

        //Constructor
        public ControladoraDisenosPruebas()
        {
            m_base_datos = new BDDisenoPruebas();
        }

        /** @brief Método que se encarga de las operaciones necesarias para insertar un nuevo diseño de pruebas en la base de datos.
        * @param Vector de "objects" con los datos para el nuevo diseño de pruebas.
        * @return 0 si tuvo éxito, números negativos si se presentó un error con la base de datos.
        */
        public int insertar_diseno_pruebas(Object[] datos)
        {
            DisenoPruebas diseno_pruebas = new DisenoPruebas(datos);
            return m_base_datos.insertar_diseno_pruebas(diseno_pruebas);
        }

        /** @brief Método que se encarga de las operaciones necesarias para modificar un diseño de pruebas en la base de datos.
        * @param Vector de "objects" con los datos para el diseño de pruebas.
        * @return 0 si tuvo éxito, números negativos si se presentó un error con la base de datos.
        */
        public int modificar_diseno_pruebas(Object[] datos)
        {
            DisenoPruebas diseno_pruebas = new DisenoPruebas(datos);
            return m_base_datos.modificar_diseno_pruebas(diseno_pruebas);
        }

        /** @brief Método que se encarga de las operaciones necesarias para eliminar un nuevo diseño de pruebas en la base de datos.
        * @param ID del diseño que se desea eliminar.
        * @return 0 si tuvo éxito, números negativos si se presentó un error con la base de datos.
        */
        public int eliminar_diseno_pruebas(int id_diseno)
        {
            return m_base_datos.eliminar_diseno_pruebas(id_diseno);
        }

        /** @brief Método que se encarga de las operaciones necesarias para consultar un nuevo diseño de pruebas en específico.
        * @param ID del diseño que se desea consultar.
        * @return DataTable con los datos del diseño que se consultó.
        */
        public DataTable consultar_diseno_pruebas(int id_diseno)
        {
            return m_base_datos.consultar_diseno_pruebas(id_diseno);
        }
        
        /** @brief Método que se encarga de las operaciones necesarias para consultar los diseños de pruebas disponibles que hay en la base de datos.
        * @return DataTable con los datos de todos los diseños disponibles que hay en la base de datos.
        */
        public DataTable solicitar_disenos_disponibles()
        {
            return m_base_datos.solicitar_disenos_disponibles();
        }
    }
}