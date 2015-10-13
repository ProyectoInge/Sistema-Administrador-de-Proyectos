﻿/*
 * Universidad de Costa Rica
 * Escuela de Ciencias de la Computación e Informática
 * Ingeniería de Software I
 * Sistema Administrador de Proyectos de Software (SAPS)
 * II Semestre 2015
*/
﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAPS.Entidades;
using SAPS.Base_de_Datos;
using SAPS.Ayudantes;


namespace SAPS.Controladoras
{
    public class ControladoraProyectoPruebas
    {
        //Variables de instancia
        BDProyectoPruebas m_base_datos;
        //Constructor
        public ControladoraProyectoPruebas()
        {
            m_base_datos = new BDProyectoPruebas();
        }

        // Métodos

        /** @brief Método que asigna las operaciones necesarias para poder insertar un proyecto de pruebas.
         * @param datos array que contiene los datos para poder insertar un proyecto de pruebas.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int insertar_proyecto(Object[] datos)
        {
            ProyectoPruebas proyecto = new ProyectoPruebas(datos);
            return m_base_datos.insertar_proyecto(proyecto);
        }

        /** @brief Método que asigna las operaciones necesarias para poder modificar un proyecto de pruebas.
         * @param datos array que contiene los datos para poder crear un proyecto de pruebas.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int modificar_proyecto(Object[] datos)
        {
            ProyectoPruebas proyecto = new ProyectoPruebas(datos);
            return m_base_datos.modificar_proyecto(proyecto);
        }

        /** @brief Método que asigna las operaciones necesarias para poder eliminar un proyecto de pruebas.
         * @param id_proyecto con el nombre del proyecto que se desea eliminar.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int eliminar_proyecto(int id_proyecto)
        {
            return m_base_datos.eliminar_proyecto(id_proyecto);
        }

        /** @brief Método que asigna las operaciones necesarias para poder consultar un proyecto de pruebas en específico.
         * @param id_proyecto con el nombre del proyecto que se desea cosultar.
         * @return DataTable con los resultados de la consultas.
         */
        public DataTable consultar_proyecto(int id_proyecto)
        {
            return m_base_datos.consultar_proyecto(id_proyecto);
        }

        /** @brief Método que asigna las operaciones necesarias para poder consultar los resucursos humanos dispinibles.
         * @return DataTable con los resultados de la consultas.
         */
        public DataTable solicitar_recursos_disponibles()
        {
            ControladoraRecursosHumanos controladora_rh = new ControladoraRecursosHumanos();
            return controladora_rh.solicitar_recursos_disponibles();

        }
    }
}