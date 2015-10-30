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
        private string m_proposito;
        private string m_flujo_central;

        public CasoPruebas(Object[] datos, Datos[] entrada_datos)
        {
            m_proposito = datos[0].ToString();
            m_flujo_central = datos[1].ToString();
        }

        // Métodos

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
    }
}