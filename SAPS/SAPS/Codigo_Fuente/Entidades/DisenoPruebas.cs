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
    /** @brief Clase que se encarga de crear un objeto "Diseño de pruebas", encapsula los datos correspondientes.
    */
    public class DisenoPruebas
    {
        //Atributos del objeto
        private int m_id_diseno;
        private int m_id_proyecto;
        private string m_nombre_diseno;
        private DateTime m_fecha_incicio;
        private string m_tecnica_prueba;
        private string m_tipo_prueba;
        private string m_nivel_prueba;
        private string m_username_responsable;
        private string m_ambiente;
        private string m_criterio_aceptacion;

        /** @param datos Un vector tipo objeto que contiene toda la información necesaria
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
            |    8   |      Ambiente        |     string    |
            |    9   | Criterio aceptacion  |     string    |
        */
        public DisenoPruebas(Object[] datos)
        {
            m_id_diseno = Convert.ToInt32(datos[0]);
            m_id_proyecto = Convert.ToInt32(datos[1]);
            m_nombre_diseno = Convert.ToString(datos[2]);
            m_fecha_incicio = Convert.ToDateTime(datos[3]);
            m_tecnica_prueba = Convert.ToString(datos[4]);
            m_tipo_prueba = Convert.ToString(datos[5]);
            m_nivel_prueba = Convert.ToString(datos[6]);
            m_username_responsable = Convert.ToString(datos[7]);
            m_ambiente = Convert.ToString(datos[8]);
            m_criterio_aceptacion = Convert.ToString(datos[9]);
        }

        //Métodos de get y set

        public string criterio_aceptacion
        {
            get { return m_criterio_aceptacion; }
            set { m_criterio_aceptacion = value; }
        }

        public string ambiente
        {
            get { return m_ambiente; }
            set { m_ambiente = value; }
        }

        public string username_responsable
        {
            get { return m_username_responsable; }
            set { m_username_responsable = value; }
        }

        public string nivel_prueba
        {
            get { return m_nivel_prueba; }
            set { m_nivel_prueba = value; }
        }

        public string tipo_prueba
        {
            get { return m_tipo_prueba; }
            set { m_tipo_prueba = value; }
        }

        public string tecnica_prueba
        {
            get { return m_tecnica_prueba; }
            set { m_tecnica_prueba = value; }
        }

        public DateTime fecha_inicio
        {
            get { return m_fecha_incicio; }
            set { m_fecha_incicio = value; }
        }
        public string nombre_diseno
        {
            get { return m_nombre_diseno; }
            set { m_nombre_diseno = value; }
        }
        public int id_diseno
        {
            get { return m_id_diseno; }
            set { m_id_diseno = value; }
        }

        public int id_proyecto
        {
            get { return m_id_proyecto; }
            set { m_id_proyecto = value; }
        }
    }
}