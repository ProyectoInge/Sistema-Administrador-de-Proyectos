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
    /** @brief Esta clase entidad se encarga de crear objetos ProyectoPruebas para encapsular los atributos
     * de los proyectos.
     */
    public class ProyectoPruebas
    {
        private string m_id;
        private string m_nombre_sistema;
        private string m_nombre_proceso;
        private string m_nombre_lider;
        private string m_objetivo;
        private string m_oficina_asociada;
        private string m_telefono1;
        private string m_telefono2;
        private string m_representante_oficina;
        private string m_estado_proyecto;
        private DateTime m_fecha_inicio;
        private DateTime m_fecha_asignacion;
        private DateTime m_fecha_finalizacion;
        
        

        public ProyectoPruebas(Object[] datos)
        {
            /**
                Orden de recepcion de los datos
                
            0 - nombre de sistema
            1 - nombre de proceso
            2 - nombre de lider
            3 - objetivo
            4 - oficina asociada
            5 - telefono 1
            6 - telefono 2
            7 - representante de ofcina
            8 - estado de proyecto

            */

            m_nombre_sistema = datos[0].ToString();
            m_nombre_proceso = datos[1].ToString();
            m_nombre_lider = datos[2].ToString();
            m_objetivo = datos[3].ToString();
            m_oficina_asociada = datos[4].ToString();
            m_telefono1 = datos[5].ToString();
            m_telefono2 = datos[6].ToString();
            m_representante_oficina = datos[7].ToString();
            m_estado_proyecto = datos[8].ToString();
        }


        public string id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        public string nombre_sistema
        {
            get { return m_nombre_sistema; }
            set { m_nombre_sistema = value; }
        }
        
        
        public string objetivo
        {
            get { return m_objetivo; }
            set { m_objetivo = value; }
        }

        
        public DateTime fecha_inicio
        {
            get { return m_fecha_inicio; }
            set { m_fecha_inicio = value; }
        }

        public DateTime fecha_asignacion
        {
            get { return m_fecha_asignacion; }
            set { m_fecha_asignacion = value; }
        }

        public DateTime fecha_finalizacion
        {
            get { return m_fecha_finalizacion; }
            set { m_fecha_finalizacion = value; }
        }
    }
}