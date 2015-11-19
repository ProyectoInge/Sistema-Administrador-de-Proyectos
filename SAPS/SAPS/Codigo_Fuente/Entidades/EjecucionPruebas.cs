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
    public class EjecucionPruebas
    {
        // Elementos de ejecucion de pruebas

        private int m_numero_ejecucion;
        private string m_responsable;
        private int m_id_diseno;
        private DateTime m_fecha_ultima_ejecucion;
        private string m_incidencias;

        /* @brief Constructor de la entidad de ejecucion de pruebas.
        @param datos contiene los datos para poder crear una Ejecucion de pruebas, el orden va de la siguiente manera:
                             * | Índice | Descripción             | Tipo de datos |
                             * |:------:|:-----------------------:|:-------------:|
                             * |    0   |  Numero de ejecucion    |      int      |
                             * |    1   |  Responsable            |     String    |
                             * |    2   |  Id del diseno          |      int      |
                             * |    3   |  Fecha de ejecucion     |     Datetime  |
                             * |    4   |  Incidencias            |     String    |
        * **/
        public EjecucionPruebas(Object[] datos)
        {
            m_numero_ejecucion = Convert.ToInt32(datos[0]);
            m_responsable = datos[1].ToString();
            m_id_diseno = Convert.ToInt32(datos[2]);
            m_fecha_ultima_ejecucion = Convert.ToDateTime(datos[3]);
            m_incidencias = datos[4].ToString();
        }

        public int n_ejecucion
        {            
            get{ return m_numero_ejecucion;  }
            set { m_numero_ejecucion = value; }
        }

        public string responsable
        {
            get { return m_responsable; }
            set { m_responsable = value; }
        }

        public int diseno_asociado
        {
            get { return m_id_diseno; }
            set { m_id_diseno = value; }
        }

        public DateTime fecha_ejecucion
        {
            get { return m_fecha_ultima_ejecucion; }
            set { m_fecha_ultima_ejecucion = value; }
        }

        public string incidencias
        {
            get { return m_incidencias; }
            set { m_incidencias = value; }
        }
    }
}
 











