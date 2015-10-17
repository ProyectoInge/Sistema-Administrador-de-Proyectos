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
    /** @brief Esta clase entidad se encarga de crear objetos Oficina para encapsular los atributos
        de las oficinas.
    */
    public class Oficina
    {
        private string m_nombre;
        private int m_id;
        private string m_representante;
        private string m_telefono1;
        private string m_telefono2;

        public Oficina(Object[] datos)
        {
            m_nombre = datos[0].ToString();
            m_id = Convert.ToInt32(datos[1]);
            m_representante = datos[2].ToString();
            m_telefono1 = datos[3].ToString();
            m_telefono2 = datos[4].ToString();
        }

        public string nombre
        {
            get { return m_nombre; }
            set { m_nombre = value; }
        }

        public int id
        {
            get { return m_id; }
            set { m_id = value; }
        }
        public string representante
        {
            get { return m_representante; }
            set { m_representante = value; }
        }

        public string telefono_1
        {
            get { return m_telefono1; }
            set { m_telefono1 = value; }
        }

        public string telefono_2
        {
            get { return m_telefono2; }
            set { m_telefono2 = value; }
        }
    }
}