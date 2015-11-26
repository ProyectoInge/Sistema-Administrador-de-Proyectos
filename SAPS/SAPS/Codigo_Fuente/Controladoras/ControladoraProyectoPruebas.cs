/*
 * Universidad de Costa Rica
 * Escuela de Ciencias de la Computación e Informática
 * Ingeniería de Software I
 * Sistema Administrador de Proyectos de Software (SAPS)
 * II Semestre 2015
*/
using System;
using System.Data;
using SAPS.Entidades;
using SAPS.Base_de_Datos;
using SAPS.Ayudantes;


namespace SAPS.Controladoras
{
    /** @brief efectuar las comunicaciones relacionadas con proyectos de pruebas con la capa de
               interfaz, la capa de base de datos y las controladoras de otros módulos.
     */
    public class ControladoraProyectoPruebas
    {
        //Variables de instancia
        private BDProyectoPruebas m_base_datos_pdp;

        // Para respetar la arquitectura de N capaz, solo las controladoras pueden hablar entre si
        private ControladoraRecursosHumanos m_controladora_rh;

        //Constructor
        public ControladoraProyectoPruebas()
        {
            m_base_datos_pdp = new BDProyectoPruebas();
        }

        // Métodos

        /** @brief Método que consulta el perfil de un usuario del sistema, permite que se mantenga la arquitectura N capas.
         * @param nombre_usuario usuario cuyo perfil se desea consultar.
         * @return false si es administrador, true si es miembro
        */
        public bool es_administrador(string nombre_usuario)
        {
            m_controladora_rh = new ControladoraRecursosHumanos();
            return m_controladora_rh.es_administrador(nombre_usuario);
        }

        /** @brief Método que asigna las operaciones necesarias para poder insertar un proyecto de pruebas.
         * @param datos array que contiene los datos para poder insertar un proyecto de pruebas.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int insertar_proyecto(Object[] datos)
        {
            ProyectoPruebas proyecto = new ProyectoPruebas(datos);
            return m_base_datos_pdp.insertar_proyecto(proyecto);
        }

        /** @brief Método que asigna las operaciones necesarias para poder modificar un proyecto de pruebas.
         * @param datos array que contiene los datos para poder crear un proyecto de pruebas.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int modificar_proyecto(Object[] datos)
        {
            ProyectoPruebas proyecto = new ProyectoPruebas(datos);
            return m_base_datos_pdp.modificar_proyecto(proyecto);
        }

        /** @brief Método que asigna las operaciones necesarias para poder eliminar un proyecto de pruebas.
         * @param id_proyecto con el nombre del proyecto que se desea eliminar.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int eliminar_proyecto(int id_proyecto)
        {
            return m_base_datos_pdp.eliminar_proyecto(id_proyecto);
        }

        /** @brief Método que asigna las operaciones necesarias para poder consultar mi proyecto de pruebas.
         * @param username de quien hace la consulta.
         * @return DataTable con los resultados de la consultas.
         */
        public DataTable consultar_mi_proyecto(string nombre_usuario)
        {
            return m_base_datos_pdp.solicitar_mi_proyecto(nombre_usuario);
        }

        /** @brief Método que asigna las operaciones necesarias para poder consultar una oficina en específico.
         * @param id_oficina con el identificador del proyecto que se desea cosultar.
         * @return DataTable con los resultados de la consultas.
         */
        public DataTable consultar_oficina(int id_oficina)
        {
            return m_base_datos_pdp.consultar_oficina(id_oficina);
        }

        /** @brief Método que asigna las operaciones necesarias para poder consultar las oficibas disponibles.
         * @return DataTable con los resultados de la consultas.
         */
        public DataTable solicitar_oficinas_disponibles()
        {
            return m_base_datos_pdp.solicitar_oficinas_disponibles();
        }

        /** @brief Método que asigna las operaciones necesarias para poder consultar un proyecto de pruebas en específico.
         * @param id_proyecto con el identificador del proyecto que se desea cosultar.
         * @return DataTable con los resultados de la consultas.
         */
        public DataTable consultar_proyecto(int id_proyecto)
        {
            return m_base_datos_pdp.consultar_proyecto(id_proyecto);
        }

        /** @brief Método que asigna las operaciones necesarias para poder consultar los proyectos de pruebas disponibles.
             * @return DataTable con los resultados de la consultas.
         */
        public DataTable solicitar_proyectos_disponibles()
        {
            return m_base_datos_pdp.solicitar_proyectos_disponibles();

        }

        /** @brief Método que asigna las operaciones necesarias para poder insertar una nueva oficina.
         * @param datos array que contiene los datos para poder insertar una nueva oficina.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int insertar_oficina(Object[] datos)
        {
            Oficina nueva_oficina = new Oficina(datos);
            return m_base_datos_pdp.insertar_oficina(nueva_oficina);
        }

        /** @brief Método que se encarga de realizar una sentencia SQL para obtener los proyectos que no han sido eliminados
         * @return Información de todos los proyectos que no han sido eliminados.
        */
        public DataTable solicitar_proyectos_no_eliminados()
        {
            return m_base_datos_pdp.solicitar_proyectos_no_eliminados();
        }


        public DataTable splicitar_proyectos_filtrados(string [] datos)
        {
            return m_base_datos_pdp.aplicar_filtros_proyecto_pruebas(datos);

        }




    }
}
