/*
 * Universidad de Costa Rica
 * Escuela de Ciencias de la Computación e Informática
 * Ingeniería de Software I
 * Sistema Administrador de Proyectos de Software (SAPS)
 * II Semestre 2015
 * ---------------------------------------------------------------------------------------------
 * Esta clase entidad se encarga de crear objetos "ProyectoPruebas" para encapsular los atributos
 * de los proyectos.
 * ---------------------------------------------------------------------------------------------
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPS.Codigo_Fuente.Entidades
{
    public class ProyectoPruebas
    {
        private string m_id;
        private string m_nombre_sistema;
        private string m_estado;
        private DateTime m_fecha_inicio;
        private DateTime m_fecha_asignacion;
        private DateTime m_fecha_finalizacion;
        private string m_objetivo;
        private string m_nombre;

        public ProyectoPruebas(Object[] datos)
        {
            m_id = datos[0].ToString();
            m_nombre_sistema = datos[1].ToString();
            m_estado = datos[2].ToString();
            m_objetivo = datos[3].ToString();
            m_nombre = datos[4].ToString();
            m_fecha_inicio = Convert.ToDateTime(datos[5]);
            m_fecha_asignacion = Convert.ToDateTime(datos[6]);
            m_fecha_finalizacion = Convert.ToDateTime(datos[7]);

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

        public string estado
        {
            get { return m_estado; }
            set { m_estado = value; }
        }
        
        public string objetivo
        {
            get { return m_objetivo; }
            set { m_objetivo = value; }
        }

        public string nombre
        {
            get { return m_nombre; }
            set { m_nombre = value; }
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