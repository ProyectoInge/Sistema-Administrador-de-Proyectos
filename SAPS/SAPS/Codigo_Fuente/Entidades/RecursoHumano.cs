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
using SAPS.Ayudantes;

namespace SAPS.Entidades
{
    public class RecursoHumano
    { 
        // Variables de instancia
        private Seguridad m_seguridad;
        private string m_usuario;
        private string m_nombre;
        private string m_correo;
        private string m_telefono;
        private string m_proyecto_asociado;
        private string m_contrasena;
        private bool m_es_administrador;
        private string m_cedula;
        private string m_rol;

        // Constructor
        public RecursoHumano(Object[] datos) {
            m_seguridad = new Seguridad();

            m_usuario = datos[0].ToString();
            m_nombre = datos[1].ToString();
            m_correo = datos[2].ToString();
            m_telefono = datos[3].ToString();
            m_proyecto_asociado = datos[4].ToString();
            m_contrasena = m_seguridad.hash_constrasena(datos[5].ToString());         // LA CONTRASEÑA HASHEADA AQUÍ
            m_es_administrador = Convert.ToBoolean(datos[6]);
            m_cedula = datos[7].ToString();
            m_rol = datos[8].ToString();
        }


        // Métodos

        public string usuario
        {
            get { return m_usuario; }
            set { m_usuario = value; }
        }

        public string rol
        {
            get { return m_rol; }
            set { m_rol = value; }
        }

        public string cedula
        {
            get { return m_cedula; }
            set { m_cedula = value; }
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
            set { m_contrasena = value; }
        }

        public bool es_administrador
        {
            get { return m_es_administrador; }
            set { m_es_administrador = value; }
        }
    }
}