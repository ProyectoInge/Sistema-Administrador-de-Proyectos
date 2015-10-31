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
    /** @brief Efectuar las comunicaciones relacionadas con Requerimientos con la capa de
               interfaz, la capa de  base de datos y controladoras de otros módulos.
     */
    public class ControladoraRequerimientos
    {
        BDRequerimientos m_base_datos;

        //Constructor
        public ControladoraRequerimientos()
        {
            m_base_datos = new BDRequerimientos();
        }

        /** @brief Método que asigna las operaciones necesarias para poder insertar un requerimiento.
         * @param datos vector que contiene los datos para poder crear un requerimientos.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int insertar_requerimiento(Object[] datos)
        {
            Requerimiento requerimiento = new Requerimiento(datos);
            return m_base_datos.insertar_requerimiento(requerimiento);
        }

        /** @brief Método que asigna las operaciones necesarias para poder modificar un requerimiento.
         * @param datos vector que contiene los datos para poder modificar un requerimiento.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int modificar_requerimiento(Object[] datos)
        {
            Requerimiento requerimiento = new Requerimiento(datos);
            return m_base_datos.modificar_requerimiento(requerimiento);
        }

        /** @brief Método que asigna las operaciones necesarias para poder eliminar un requerimiento.
         * @param id del requerimiento a eliminar.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int eliminar_requerimiento(int id_requerimiento)
        {
            return m_base_datos.eliminar_requerimiento(id_requerimiento);
        }

        /** @brief Método que asigna las operaciones necesarias para poder consultar un requerimiento en específico.
         * @param id del requerimiento a consultar.
         * @return DataTable con los resultados de la consulta.
         */
        public DataTable consultar_requerimiento(int id_requerimiento)
        {
            return m_base_datos.consultar_requerimiento(id_requerimiento);
        }

        /** @brief Método que realiza las operaciones necesarias para consultar los requerimientos disponibles
        * @return DataTable con los resultados de la consulta.
        */
        public DataTable solicitar_requerimientos_disponibles()
        {
            return m_base_datos.solicitar_requerimientos_disponibles();
        }
    }
}