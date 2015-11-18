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

namespace SAPS.Codigo_Fuente.Entidades
{
    public class EjecucionPruebas
    {
        // Elementos de ejecucion de pruebas

        private int numero_ejecucion;
        private string responsable;
        private int id_diseno;
        private DateTime fecha_ultima_ejecucion;
        private string incidencias;

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
            numero_ejecucion = Convert.ToInt32(datos[0]);
            responsable = datos[1].ToString();
            id_diseno = Convert.ToInt32(datos[2]);
            fecha_ultima_ejecucion = Convert.ToDateTime(datos[3]);
            incidencias = datos[4].ToString();
        }

        public int n_ejecucion
        {            
            get{ return numero_ejecucion;  }
            set { numero_ejecucion = value; }
        }

        public string ep_responsable
        {
            get { return responsable; }
            set { responsable = value; }
        }

        public int diseno_asociado
        {
            get { return id_diseno; }
            set { id_diseno = value; }
        }

        public DateTime fecha_ejecucion
        {
            get { return fecha_ultima_ejecucion; }
            set { fecha_ultima_ejecucion = value; }
        }

        public string incidencias_ep
        {
            get { return incidencias; }
            set { incidencias = value; }
        }
    }
}
 











