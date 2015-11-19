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
    public class ResultadosEP
    {
        private int m_numero_resultado;
        private int m_id_diseno;
        private int m_numero_ejecucion;
        private string m_estado;
        private string m_tipo_no_conformidad;
        private string m_id_caso;
        private string m_desc_no_conformidad;
        private string m_justificacion;
        /// @todo Manejar la imagen

        /* @brief Constructor de la entidad de resultados de ejecucion de pruebas.
        @param datos contiene los datos para poder crear un conjunto asociado a una ejecucion de pruebas, el orden va de la siguiente manera:
                             * | Índice | Descripción             | Tipo de datos |
                             * |:------:|:-----------------------:|:-------------:|
                             * |    0   |  Numero de resultado    |      int      |
                             * |    1   |  Id del diseno          |      int      |
                             * |    2   |  Numero de ejecucion    |      int      |
                             * |    3   |  Estado                 |     String    |
                             * |    4   |  Tipo No Conformidad    |     String    |
                             * |    5   |  Id del Caso            |     String    |
                             * |    6   |  Descripcion No Conf.   |     String    |
                             * |    7   |  Justificacion          |     String    |
                             * |    8   |  Imagen                 |    Averiguar  |
        * **/
        public ResultadosEP(Object[ ] datos)
        {
            m_numero_resultado = Convert.ToInt32(datos[0]);
            m_id_diseno = Convert.ToInt32(datos[1]);
            m_numero_ejecucion = Convert.ToInt32(datos[2]);
            m_estado = datos[3].ToString();
            m_tipo_no_conformidad = datos[4].ToString();
            m_id_caso = datos[5].ToString();
            m_desc_no_conformidad = datos[6].ToString();
            m_justificacion = datos[7].ToString();
            /// @todo Agregar la imagen
        }

        public int num_resultado
        {
            get { return m_numero_resultado; }
            set { m_numero_resultado = value; }
        }

        public int identificador_diseno
        {
            get { return m_id_diseno; }
            set { m_id_diseno = value; }
        }

        public int num_ejecucion
        {
            get { return num_ejecucion; }
            set { num_ejecucion = value; }
        }

        public string estado
        {
            get { return m_estado; }
            set { m_estado = value; }
        }

        public string tipo_no_conf
        {
            get { return m_tipo_no_conformidad; }
            set { m_tipo_no_conformidad = value; }
        }

        public string identificador_caso
        {
            get { return m_id_caso; }
            set { m_id_caso = value; }
        }

        public string descripcion_no_conformidad
        {
            get { return m_desc_no_conformidad; }
            set { m_desc_no_conformidad = value; }
        }

        public string justificacion
        {
            get { return m_justificacion; }
            set { m_justificacion = value; }
        }

        /// @todo Sets y gets para la imagen
    }    
}