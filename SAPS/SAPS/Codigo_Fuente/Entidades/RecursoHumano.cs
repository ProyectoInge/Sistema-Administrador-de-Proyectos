/*
 * Universidad de Costa Rica
 * Escuela de Ciencias de la Computación e Informática
 * Ingeniería de Software I
 * Sistema Administrador de Proyectos de Software (SAPS)
 * II Semestre 2015
 * ---------------------------------------------------------------------------------------------
 * Esta clase entidad se encarga de crear objetos "RecursoHumano" para encapsular los atributos
 * de un recurso humano de los proyectos.
 * ---------------------------------------------------------------------------------------------
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPS.Entidades
{
    public class RecursoHumano
    { 
        private string m_usuario;
        private string m_nombre;
        private string m_correo;
        private string m_telefono;
        private string m_proyecto_asociado;
        private string m_contrasena;
        private bool m_es_administrador;

        public RecursoHumano(Object[] datos) {
            m_usuario = datos[0].ToString();
            m_nombre = datos[1].ToString();
            m_correo = datos[2].ToString();
            m_telefono = datos[3].ToString();
            m_proyecto_asociado = datos[4].ToString();
            m_contrasena = datos[5].ToString();         // REVISAR EL SET_CONTRASENA
            m_es_administrador = Convert.ToBoolean(datos[6]);
        }

        public string usuario
        {
            get { return m_usuario; }
            set { m_usuario = value; }
        }

        public string nombre
        {
            get { return m_nombre; }
            set { m_nombre = value; }
        }

        public string correo
        {
            get { return m_correo; }
            set { m_correo = value; }
        }

        public string telefono
        {
            get { return m_telefono; }
            set { m_telefono = value; }
        }

        public string proyecto_asociado
        {
            get { return m_proyecto_asociado; }
            set { m_proyecto_asociado = value; }
        }

        public string contrasena
        {
            get { return m_contrasena; }
            set { m_contrasena = value; } // **** ESTO HAY QUE "HASHEARLO" ****
        }

        public bool es_administrador
        {
            get { return m_es_administrador; }
            set { m_es_administrador = value; }
        }
    }
}