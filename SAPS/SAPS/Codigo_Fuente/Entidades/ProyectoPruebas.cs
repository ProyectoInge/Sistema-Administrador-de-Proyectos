/*
 * Universidad de Costa Rica
 * Escuela de Ciencias de la Computación e Informática
 * Ingeniería de Software I
 * Sistema Administrador de Proyectos de Software (SAPS)
 * II Semestre 2015
*/

using System;

namespace SAPS.Entidades
{
    /** @brief Esta clase entidad se encarga de crear objetos ProyectoPruebas para encapsular los atributos
     *  de los proyectos.
     */
    public class ProyectoPruebas
    {
        private int m_id;
        private int m_id_oficina;
        private string m_nombre_sistema;
        private string m_estado;
        private DateTime m_fecha_inicio;
        private DateTime m_fecha_asignacion;
        private DateTime m_fecha_finalizacion;
        private string m_objetivo;
        private string m_nombre;

        /* @param datos contiene los datos para poder crear un ProyectoPruebas, el orden va de la siguiente manera:
           | Índice | Descripción           | Tipo de datos |
           |:------:|-----------------------|---------------|
           |    0   |    Id del proyecto    |      int      |
           |    1   |    Id de la oficina   |      int      |
           |    2   |  Nombre del sistemna  |     String    |
           |    3   |         Estado        |     String    |
           |    4   |        Objetivo       |     String    |
           |    5   |         Nombre        |     String    |
           |    6   |    Fecha de inicio    |      Date     |
           |    7   |  Fecha de asignación  |      Date     |
           |    8   | Fecha de finalización |      Date     |
        */
        public ProyectoPruebas(Object[] datos)
        {
            m_id = Convert.ToInt32(datos[0]);
            m_id_oficina = Convert.ToInt32(datos[1]);
            m_nombre_sistema = datos[2].ToString();
            m_estado = datos[3].ToString();
            m_objetivo = datos[4].ToString();
            m_nombre = datos[5].ToString();
            m_fecha_inicio = Convert.ToDateTime(datos[6]);
            m_fecha_asignacion = Convert.ToDateTime(datos[7]);
            if (datos[8] == "")
                m_fecha_finalizacion = default(DateTime);
            else
                m_fecha_finalizacion = Convert.ToDateTime(datos[8]);

        }


        public int id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        public int id_oficina
        {
            get { return m_id_oficina; }
            set { m_id_oficina = value; }
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