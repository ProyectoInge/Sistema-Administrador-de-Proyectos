/*
 * Universidad de Costa Rica
 * Escuela de Ciencias de la Computación e Informática
 * Ingeniería de Software I
 * Sistema Administrador de Proyectos de Software (SAPS)
 * II Semestre 2015
*/

namespace SAPS.Entidades.Ayudantes
{
    public class Dato
    {
        // Campos
        private string m_valor;
        private string m_tipo;

        /** @brief Constructor de un dato utilizado en caso de pruebas.
         * @param valor ingresado.
         * @param estado_dato contendrá el tipo del dato (Válido, Inválido, No aplica).
         */
        public Dato(string valor, string tipo)
        {
            m_valor = valor;
            m_tipo = tipo;
        }

        public string valor
        {
            get { return m_valor; }
            set { m_valor = value; }
        }

        public string estado
        {
            get { return m_tipo; }
            set { m_tipo = value; }
        }
    }
}