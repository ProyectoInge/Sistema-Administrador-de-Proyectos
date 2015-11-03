using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPS.Entidades
{
    public class DisenoPruebas
    {
        private int m_id_diseno;
        private int m_id_proyecto;
        private string m_nombre_diseno;
        private DateTime m_fecha_incicio;
        private string m_tecnica_prueba;
        private string m_tipo_prueba;
        private string m_nivel_prueba;
        private string m_username_responsable;
        
        public DisenoPruebas(Object[] datos)
        {

        }

        public int id_diseno
        {
            get { return m_id_diseno; }
            set { m_id_diseno = value; }
        }
    }
}