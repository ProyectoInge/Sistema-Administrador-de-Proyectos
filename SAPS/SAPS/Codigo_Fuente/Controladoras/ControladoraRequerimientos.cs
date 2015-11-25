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
        private BDRequerimientos m_base_datos;

        //Constructor
        public ControladoraRequerimientos()
        {
            m_base_datos = new BDRequerimientos();
        }

        /** @brief Método que asigna las operaciones necesarias para poder insertar un requerimiento.
         * @param datos Un vector tipo objeto que contiene toda la información necesaria
                   para crear un requerimeinto, el orden de los parámetros va de la siguiente manera:
            | Índice |       Descripción       | Tipo de datos |
            |:------:|:-----------------------:|:-------------:|
            |    0   |   ID del requerimiento  |     String    |
            |    1   |         Nombre          |     String    |
            |    2   | Criterios de aceptación |     String    |

         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int insertar_requerimiento(Object[] datos)
        {
            if (datos.Length != 3)
                return -1;
            Requerimiento requerimiento = new Requerimiento(datos);
            return m_base_datos.insertar_requerimiento(requerimiento);
        }

        /** @brief Método que asigna las operaciones necesarias para poder modificar un requerimiento.
         * @param datos Un vector tipo objeto que contiene toda la información necesaria
                   para crear un requerimeinto, el orden de los parámetros va de la siguiente manera:
            | Índice |       Descripción       | Tipo de datos |
            |:------:|:-----------------------:|:-------------:|
            |    0   |   ID del requerimiento  |     String    |
            |    1   |         Nombre          |     String    |
            |    2   | Criterios de aceptación |     String    |

         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int modificar_requerimiento(Object[] datos)
        {
            if (!existe_requerimiento(Convert.ToString(datos[0])) && datos.Length != 3) //Verifica que el requerimiento exista
                return -1;
            Requerimiento requerimiento = new Requerimiento(datos);
            return m_base_datos.modificar_requerimiento(requerimiento);
        }

        /** @brief Método que asigna las operaciones necesarias para poder eliminar un requerimiento.
         * @param id del requerimiento a eliminar.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int eliminar_requerimiento(string id_requerimiento)
        {
            if (!existe_requerimiento(id_requerimiento))
                return -1;
            return m_base_datos.eliminar_requerimiento(id_requerimiento);
        }

        /** @brief Método que asigna las operaciones necesarias para poder consultar un requerimiento en específico.
         * @param id del requerimiento a consultar.
         * @return DataTable con los resultados de la consulta.
         */
        public DataTable consultar_requerimiento(string id_requerimiento)
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

        /** @brief Método que se encarga de asociar un requerimiento a un diseño de pruebas.
         * @param Vector de objetos que tiene que venir de la siguiente manera:
         
            | Índice |        Descripción       | Tipo de datos |
            |:------:|:------------------------:|:-------------:|
            |   0    |     ID del diseño        |       int     |
            |   1    |  ID del requerimiento    |     String    |

         * @return 0 si no hubo ningún problema, números negativos si hubo algún problema con la base de datos.
        */
        public int asociar_requerimiento(Object[] datos)
        {
            if (existe_requerimiento(Convert.ToString(datos[1])) && datos.Length != 2) //Verifica que el requerimiento exista
                return -1;
                return m_base_datos.asociar_requerimiento(datos);
        }

        /** @brief Método que se encarga de verificar si un requerimiento existe en la base de datos.
         * @param El identificador del requerimiento que se quiere verificar si existe.
         * @return True si el requerimiento está en la base, False si no.
        */
        public bool existe_requerimiento(string id_requerimiento)
        {
            DataTable resultado = solicitar_requerimientos_disponibles();
            int cant_filas = resultado.Rows.Count;
            for (int i = 0; i < cant_filas; ++i)
            {
                if (Convert.ToString(resultado.Rows[i]["id_requerimiento"]) == id_requerimiento)
                    return true;
            }
            return false;
        }
    }
}