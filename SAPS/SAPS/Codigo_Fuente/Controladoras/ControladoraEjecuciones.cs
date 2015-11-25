/*
 * Universidad de Costa Rica
 * Escuela de Ciencias de la Computación e Informática
 * Ingeniería de Software I
 * Sistema Administrador de Proyectos de Software (SAPS)
 * II Semestre 2015
*/

using System;
using SAPS.Base_de_Datos;
using SAPS.Entidades;
using System.Data;

namespace SAPS.Controladoras
{
    public class ControladoraEjecuciones
    {
        // Variables de instancia
        private BDEjecuciones m_base_datos;

        // Controladoras de las clases con las que interactua la clase EjecucionesPruebas
        private ControladoraRecursosHumanos m_controladora_rh;
        private ControladoraDisenosPruebas m_controladora_dp;
        private ControladoraCasoPruebas m_controladora_cp;

        ///@brief Constructor
        public ControladoraEjecuciones()
        {
            m_base_datos = new BDEjecuciones();
        }

        /** @brief Método que se encarga de las operaciones necesarias para eliminar una ejecucion de pruebas de la base de datos.
        * @param num_ejecuccion de la ejecución que se desea eliminar y el id de diseño relacionado.
        * @return 0 si tuvo éxito, números negativos si se presentó un error con la base de datos.
        */
        public int eliminar_ejecucion(int id_diseno, int num_ejecucion)
        {
            return m_base_datos.eliminar_ejecucion(id_diseno, num_ejecucion);
        }

        /** @brief se encarga de las operaciones necesarias para eliminar un reusltado en específico de una ejecucion dada.
         * @param num del resultado que se desea eliminar y num de la ejecución y el id de diseño relacionados.
        * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
        */
        public int eliminar_resultado(int id_diseno, int num_ejecucion, int num_resultado)
        {
            return m_base_datos.eliminar_resultado(id_diseno, num_ejecucion, num_resultado);
        }

        /** @brief Método que ingresa una ejecución nueva al sistema.
         * @param Vector de Objects con los datos de la ejecución a ingresar.
            | Índice | Descripción             | Tipo de datos |
            |:------:|:-----------------------:|:-------------:|
            |    0   |  Numero de ejecucion    |      int      |
            |    1   |  Responsable            |     string    |
            |    2   |  Id del diseno          |      int      |
            |    3   |  Fecha de ejecucion     |     Datetime  |
            |    4   |  Incidencias            |     string    |
         * @return 0 si no hubo algun problema, números negativos si se presentó algún inconveniente.
         */
        public int insertar_ejecucion(Object[] datos_ejecucion)
        {
            if (datos_ejecucion.Length != 5)
                return -1;
            EjecucionPruebas ejecucion = new EjecucionPruebas(datos_ejecucion);
            return m_base_datos.insertar_ejecucion(ejecucion);
        }

        /** @brief Método que ingresa un resultado nuevo al sistema.
         * @param Vector de Objects con los datos del resultado a ingresar.
                | Índice | Descripción             | Tipo de datos |
                |:------:|:-----------------------:|:-------------:|
                |    0   |  Numero de resultado    |      int      |
                |    1   |  Id del diseno          |      int      |
                |    2   |  Numero de ejecucion    |      int      |
                |    3   |  Estado                 |     string    |
                |    4   |  Tipo No Conformidad    |     string    |
                |    5   |  Id del Caso            |     string    |
                |    6   |  Descripcion No Conf.   |     string    |
                |    7   |  Justificacion          |     string    |
                |    8   |  Ruta de la imagen      |     string    |
         * @return 0 si no hubo algun problema, números negativos si se presentó algún inconveniente.
         */
        public int insertar_resultado(Object[] datos_resultado)
        {
            if (datos_resultado.Length != 9)
                return -1;
            ResultadosEP resultado = new ResultadosEP(datos_resultado);
            return m_base_datos.insertar_resultado(resultado);
        }



        /** @brief Método que modifica una ejecución del sistema.
         * @param Vector de Objects con los datos de la ejecución a ingresar.
            | Índice | Descripción             | Tipo de datos |
            |:------:|:-----------------------:|:-------------:|
            |    0   |  Numero de ejecucion    |      int      |
            |    1   |  Responsable            |     string    |
            |    2   |  Id del diseno          |      int      |
            |    3   |  Fecha de ejecucion     |     Datetime  |
            |    4   |  Incidencias            |     string    |
         * @return 0 si no hubo algun problema, números negativos si se presentó algún inconveniente.
         */
        public int modificar_ejecucion(Object[] datos_ejecucion)
        {
            EjecucionPruebas ejecucion = new EjecucionPruebas(datos_ejecucion);

            int primer_resultado = m_base_datos.eliminar_ejecucion(Convert.ToInt32(datos_ejecucion[2]), Convert.ToInt32(datos_ejecucion[0]));

            int segundo_resultado = m_base_datos.insertar_ejecucion(ejecucion);

            return primer_resultado + segundo_resultado;
        }


        /** @brief Método que modifica un resultado del sistema.
         * @param Vector de Objects con los datos del resultado a ingresar.
                | Índice | Descripción             | Tipo de datos |
                |:------:|:-----------------------:|:-------------:|
                |    0   |  Numero de resultado    |      int      |
                |    1   |  Id del diseno          |      int      |
                |    2   |  Numero de ejecucion    |      int      |
                |    3   |  Estado                 |     string    |
                |    4   |  Tipo No Conformidad    |     string    |
                |    5   |  Id del Caso            |     string    |
                |    6   |  Descripcion No Conf.   |     string    |
                |    7   |  Justificacion          |     string    |
                |    8   |  Ruta de la imagen      |     string    |
         * @return 0 si no hubo algun problema, números negativos si se presentó algún inconveniente.
         */
        public int modificar_resultado(Object[] datos_resultado)
        {
            ResultadosEP resultado = new ResultadosEP(datos_resultado);

            int primer_resultado = m_base_datos.eliminar_resultado(Convert.ToInt32(datos_resultado[1]), Convert.ToInt32(datos_resultado[2]), Convert.ToInt32(datos_resultado[0]));

            int segundo_resultado = m_base_datos.insertar_resultado(resultado);

            return primer_resultado + segundo_resultado;
        }

        /** @brief Consultar los datos de una ejecución de pruebas.
        *   @param id_ejecucion id de la ejecucion a consultar.
        *   @return DataTable con los datos de la ejecución de prueba.
        */
        public DataTable consultar_ejecucion(int id_ejecucion)
        {
            return m_base_datos.consultar_ejecucion(id_ejecucion);
        }

        /** @brief Consultar los resultados de una ejecución de pruebas.
        *   @param id_ejecucion id de la ejecucion a consultar.
        *   @return DataTable con los resultados de una ejecución de prueba.
        */
        public DataTable consultar_resultados(int id_ejecucion)
        {
            return m_base_datos.consultar_resultados(id_ejecucion);
        }

        public DataTable consultar_ejecuciones(int id_diseno)
        {
            return m_base_datos.consultar_ejecuciones(id_diseno);
        }


        // -------------------------------------- Métodos que corresponden a otras clases --------------------------------------

        /** @brief Método que busca todos los recursos humanos que estan asociados a un determinado proyecto.
         * @param El identificador del proyecto.
         * @return DataTable con la informacion de todos los recursos humanos asociados al proyecto puesto
        */
        public DataTable consultar_rh_asociados_proyecto(int id_proyecto)
        {
            m_controladora_rh = new ControladoraRecursosHumanos();
            return m_controladora_rh.consultar_rh_asociados_proyecto(id_proyecto);
        }

        /** @brief Método que se encarga de obtener todos los diseños de prueba que hay en el sistema.
         * @return DataTable con toda la información de todos los diseños que estan presentes en el sistema.
        */
        public DataTable solicitar_disenos_disponibles()
        {
            m_controladora_dp = new ControladoraDisenosPruebas();
            return m_controladora_dp.solicitar_disenos_disponibles();
        }

        /** @brief Método que solicita todos los casos de prueba que estan asociados a un diseño de pruebas.
         * @param Identificador del diseño del que se quiere conocer los casos que tiene asociado.
         * @return DataTable con toda la información de todos los casos asociados al diseño.
         */
        public DataTable solicitar_casos_asociados_diseno(int id_diseno)
        {
            m_controladora_cp = new ControladoraCasoPruebas();
            return m_controladora_cp.solicitar_casos_pruebas_disponibles(id_diseno);
        }

        /** @brief Método que se encarga de buscar la información correspondiente a un diseño de pruebas.
         * @param El identificador del diseño del cual se desea conocer la información.
         * @return DataTable con la información del diseño que se consultó.
         */
        public DataTable consultar_diseno(int id_diseno)
        {
            m_controladora_dp = new ControladoraDisenosPruebas();
            return m_controladora_dp.consultar_diseno_pruebas(id_diseno);
        }

        public string obtener_proposito_diseno(int id_diseno)
        {
            return consultar_diseno(id_diseno).Rows[0]["nombre_diseno"].ToString();
        }

        /** @brief Metodo que revisa si un usario es administrador o no.
         * @param String con el nombre de usuario que se quiere saber si es administrador.
         * @return True si es administrador, False si es un usuario normal.
         */
        public bool es_administrador(String nombre_usuario)
        {
            m_controladora_rh = new ControladoraRecursosHumanos();
            return m_controladora_rh.es_administrador(nombre_usuario);
        }

        public DataTable obtener_recurso_humano(string nombre_usuario)
        {
            m_controladora_rh = new ControladoraRecursosHumanos();
            return m_controladora_rh.consultar_recurso_humano(nombre_usuario);
        }
    }
}