/*
 * Universidad de Costa Rica
 * Escuela de Ciencias de la Computación e Informática
 * Ingeniería de Software I
 * Sistema Administrador de Proyectos de Software (SAPS)
 * II Semestre 2015
*/

using System;

namespace SAPS.Entidades.Ayudantes
{
    public class Datos
    {
        // Campos
        private string m_valores;
        private string m_estado_datos;
        private string m_resultado_esperado;

        /** @brief Constructor de un dato utilizado en caso de pruebas.
         * @param valor ingresado  
         * @param estado_dato contendrá el estado del dato (Válido, Inválido, No aplica)
         */
        public Datos(string valores, string estado_datos, string resultado_esperado)
        {
            m_valores = valores;
            m_estado_datos = estado_datos;
            m_resultado_esperado = resultado_esperado;
        }

        public string valor
        {
            get { return m_valores; }
            set { m_valores = value; }
        }

        public string estado
        {
            get { return m_estado_datos; }
            set { m_estado_datos = value; }
        }
    }
}