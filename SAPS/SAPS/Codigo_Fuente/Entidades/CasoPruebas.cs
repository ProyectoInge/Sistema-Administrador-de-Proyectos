/*
 * Universidad de Costa Rica
 * Escuela de Ciencias de la Computación e Informática
 * Ingeniería de Software I
 * Sistema Administrador de Proyectos de Software (SAPS)
 * II Semestre 2015
*/

using System;
using SAPS.Entidades.Ayudantes;

namespace SAPS.Entidades
{
    /** @brief Esta clase entidad se encarga de crear objetos CasoPruebas para encapsular los atributos
     de los casos de prueba.
    */
    public class CasoPruebas
    {
        // Campos
        private string m_id;
        private int m_id_diseno;
        private string m_proposito;
        private string m_flujo_central;
        private Datos[] m_entrda_de_datos;

        /* @param datos contiene los datos para poder crear un Caso de pruebas, el orden va de la siguiente manera:
           | Índice | Descripción             | Tipo de datos |
           |:------:|:-----------------------:|:-------------:|
           |    0   |  Id del caso de prueba  |      int      |
           |    1   |  Id del diseño asociado |      int      |
           |    2   |  Propósito de la prueba |     String    |
           |    3   |  Flujo central          |     String    |
         * 
         * @param entrada_datos array que contendrá todo las entradas de datos relacionados al caso de prueba. 
        */
        public CasoPruebas(Object[] datos, Datos[] entrada_datos)
        {
            m_id = datos[0].ToString();
            m_id_diseno = Convert.ToInt32(datos[1]);
            m_proposito = datos[2].ToString();
            m_flujo_central = datos[3].ToString();
            m_entrda_de_datos = entrada_datos;
        }


        // Métodos

        public string id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        public int id_diseno
        {
            get { return m_id_diseno; }
            set { m_id_diseno = value; }
        }

        public string proposito
        {
            get { return m_proposito; }
            set { m_proposito = value; }
        }

        public string flujo_central
        {
            get { return m_flujo_central; }
            set { m_flujo_central = value; }
        }

        public Datos[] entrada_de_datos
        {
            get { return m_entrda_de_datos; }
            set { m_entrda_de_datos = value; }
        }
    }
}