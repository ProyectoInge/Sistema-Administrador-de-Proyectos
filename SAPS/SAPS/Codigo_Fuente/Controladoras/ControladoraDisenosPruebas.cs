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
        * @param datos Un vector tipo objeto que contiene toda la información necesaria
           para crear un requerimeinto, el orden de los parámetros va de la siguiente manera:
            | Índice |      Descripción     | Tipo de datos |
            |:------:|:--------------------:|:-------------:|
            |    0   |     ID del diseño    |       int     |
            |    1   |    ID del proyecto   |       int     |
            |    2   |   Nombre del diseño  |     string    |
            |    3   |   Fecha de inicio    |    DateTime   |
            |    4   |  Tecnica de prueba   |     string    |
            |    5   |    Tipo de prueba    |     string    |
            |    6   |    Nivel de prueba   |     string    |
            |    7   | Username responsable |     string    |
        * @return 0 si tuvo éxito, números negativos si se presentó un error con la base de datos.
        */
        public int insertar_diseno_pruebas(Object[] datos)
        {
            if (datos.Length != 8)
                return -1;
            DisenoPruebas diseno_pruebas = new DisenoPruebas(datos);
            return m_base_datos.insertar_diseno_pruebas(diseno_pruebas);
        }

        /** @brief Método que se encarga de las operaciones necesarias para modificar un diseño de pruebas en la base de datos.
        * @param datos Un vector tipo objeto que contiene toda la información necesaria
           para crear un requerimeinto, el orden de los parámetros va de la siguiente manera:
            | Índice |      Descripción     | Tipo de datos |
            |:------:|:--------------------:|:-------------:|
            |    0   |     ID del diseño    |       int     |
            |    1   |    ID del proyecto   |       int     |
            |    2   |   Nombre del diseño  |     string    |
            |    3   |   Fecha de inicio    |    DateTime   |
            |    4   |  Tecnica de prueba   |     string    |
            |    5   |    Tipo de prueba    |     string    |
            |    6   |    Nivel de prueba   |     string    |
            |    7   | Username responsable |     string    |
        * @return 0 si tuvo éxito, números negativos si se presentó un error con la base de datos.
        */
        public int modificar_diseno_pruebas(Object[] datos)
        {
            if (datos.Length != 8)
                return -1;
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

        /** @brief Método que se encarga de buscar los requerimientos asociados a un diseño.
         * @param El identificador del diseño al que se le quieren encontrar los requerimientos que tiene asociados.
         * @return DataTable con todos los requerimientos que tiene asociados el diseño consultado.
        */
        public DataTable solicitar_requerimientos_asociados(int id_diseno)
        {
            return m_base_datos.solicitar_requerimientos_asociados(id_diseno);
        }

        /** @brief Método que se encarga de buscar los requerimientos NO asociados a un diseño.
         * @param El identificador del diseño al que se le quieren encontrar los requerimientos que NO tiene asociados.
         * @return DataTable con todos los requerimientos que NO tiene asociados el diseño consultado.
        */
        public DataTable solicitar_requerimientos_no_asociados(int id_diseno)
        {
            return m_base_datos.solicitar_requerimientos_no_asociados(id_diseno);
        }

        /** @brief Método que se encarga de buscar los diseños asociados a un proyecto.
         * @param El identificador del proyecto al que se le quieren encontrar los diseños que tiene asociados.
         * @return DataTable con todos los diseños que tiene asociados el proyecto.
        */
        public DataTable solicitar_disenos_asociados_proyecto(int id_proyecto)
        {
            return m_base_datos.solicitar_disenos_asociados_proyecto(id_proyecto);
        }
    }
}