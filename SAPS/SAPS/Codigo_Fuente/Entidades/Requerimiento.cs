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

namespace SAPS.Entidades
{
    /** @brief Esta clase entidad se encarga de crear objetos Requerimiento para encapsular los atributos
               de los requerimientos.
     */
    public class Requerimiento
    {
        private int m_id;
        private string m_nombre;
        private string m_criterio_aceptacion;

        /** @param datos Un vector tipo objeto que contiene toda la información necesaria
                   para crear un requerimeinto, el orden de los parámetros va de la siguiente manera:
            | Índice |       Descripción       | Tipo de datos |
            |:------:|:-----------------------:|:-------------:|
            |    0   |   ID del requerimiento  |       int     |
            |    1   |         Nombre          |     String    |
            |    2   | Criterios de aceptación |     String    |
        */
        public Requerimiento(Object[] datos)
        {
            m_id = Convert.ToInt32(datos[0]);
            m_nombre = Convert.ToString(datos[1]);
            m_criterio_aceptacion = Convert.ToString(datos[2]);
        }

        public int id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        public string nombre
        {
            get { return m_nombre; }
            set { m_nombre = value; }
        }

        public string criterio_aceptacion
        {
            get { return m_criterio_aceptacion; }
            set { m_criterio_aceptacion = value; }
        }
    }
}