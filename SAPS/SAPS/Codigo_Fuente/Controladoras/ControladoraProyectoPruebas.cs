/*
 * Universidad de Costa Rica
 * Escuela de Ciencias de la Computación e Informática
 * Ingeniería de Software I
 * Sistema Administrador de Proyectos de Software (SAPS)
 * II Semestre 2015
*/

using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPS.Codigo_Fuente.Controladoras
{
    /** @brief efectuar las comunicaciones relacionadas con Proyecto Pruebas con la capa de
     * interfaz y la capa de  base de datos.
     */
    public class ControladoraProyectoPruebas
    {
        //Variables de instancia

        //Constructor
        public ControladoraProyectoPruebas()
        {

        }
        
        public int insertar_proyecto(Object[] datos)
        {
            return 0;
        }

        public int modificar_proyecto(Object[] datos)
        {
            return 0;
        }

        public int eliminar_proyecto(string nombre_pryecto)
        {
            return 0;
        }

        public DataTable consultar_proyecto(string nombre_proyecto)
        {

            return null;
        }

        public DataTable solicitar_recursos_disponibles()
        {
            return null;
        }

    }
}
