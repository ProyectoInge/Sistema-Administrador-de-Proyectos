/*
 * Universidad de Costa Rica
 * Escuela de Ciencias de la Computación e Informática
 * Ingeniería de Software I
 * Sistema Administrador de Proyectos de Software (SAPS)
 * II Semestre 2015
*/

using System;
using SAPS.Ayudantes;
using SAPS.Base_de_Datos;
using System.Data;
using SAPS.Entidades;

namespace SAPS.Controladoras
{
    /** @brief efectuar las comunicaciones relacionadas con Recursos Humanos con la capa de
               interfaz, la capa de base de datos y las controladoras de otros módulos.
     */
    public class ControladoraRecursosHumanos
    {
        // Variables de instancia
        private BDRecursosHumanos m_base_datos;


        // Constructor
        public ControladoraRecursosHumanos()
        {
            m_base_datos = new BDRecursosHumanos();
        }


        // Métodos

        /** @brief Método que asigna las operaciones necesarias para poder insertar un recurso humano.
         * @param datos vector que contiene los datos para poder crear un recurso humano.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int insertar_recurso_humano(Object[] datos)
        {
            RecursoHumano recurso_humano = new RecursoHumano(datos);
            return m_base_datos.insertar_recurso_humano(recurso_humano);
        }

        /** @brief Método que asigna las operaciones necesarias para poder modificar un recurso humano.
         * @param datos vector que contiene los datos para poder modificar un recurso humano.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int modificar_recurso_humano(Object[] datos)
        {
            RecursoHumano recurso_humano = new RecursoHumano(datos);
            return m_base_datos.modificar_recurso_humano(recurso_humano);
        }

        /** @brief Método que asigna las operaciones necesarias para poder eliminar un recurso humano.
         * @param nombre_usuario nombre de usuario del recursos humano a eliminar.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int eliminar_recurso_humano(string nombre_usuario)
        {
            return m_base_datos.eliminar_recurso_humano(nombre_usuario);
        }

        /** @brief Método que asigna las operaciones necesarias para poder consultar un recurso humano en específico.
         * @param nombre_usuario nombre de usuario del recursos humano a consultar.
         * @return DataTable con los resultados de la consulta.
         */
        public DataTable consultar_recurso_humano(string nombre_usuario)
        {
            return m_base_datos.consultar_recurso_humano(nombre_usuario);
        }

        /** @brief Método que asigna las operaciones necesarias para poder consultar los recursos humanos disponibles.
         * @return DataTable con los resultados de la consultas.
         */
        public DataTable solicitar_recursos_disponibles()
        {
            return m_base_datos.solicitar_recursos_disponibles();
        }

        /** @brief Método que se encarga de buscar los recursos humanos que están asociados a un proyecto de pruebas.
         * @param El identificador del proyecto al que se le quieren consultar los recursos humanos asociados.
         * @return DataTable con todos los recursos humanos asociados a un proyecto.
        */
        public DataTable consultar_rh_asociados_proyecto(int id_proyecto)
        {
            return m_base_datos.consultar_rh_asociados_proyecto(id_proyecto);
        }


        // Módulo Seguridad

        /** @brief Método que reestablece la contraseña de un recurso humano.
         * @param nombre_usuario usuario al cual se desea cambiar la contraseña.
         * @param nueva_contrasena string con la nueva contraseña deseada.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int restablecer_contrasena(string nombre_usuario, string nueva_contrasena)
        {
            return m_base_datos.cambiar_contrasena(new RecursoHumano(nombre_usuario, nueva_contrasena));
        }

        /** @brief Método que verifica si el nombre de usuario y la contraseña coinciden.
         * @param nombre_usuario usuario al cual se desea cambiar la contraseña.
         * @param contrasena string que contiene la contraseña digitada por el usuario.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int autenticar(string nombre_usuario, string contrasena_a_probar)
        {
            int resultado_autenticacion = -1;
            DataTable consulta_de_usuario = m_base_datos.consultar_recurso_humano(nombre_usuario);

            // La consulta tuvo resultados
            if (consulta_de_usuario.Rows.Count != 0)
            {
                string contrasena_hasheada = m_base_datos.recuperar_contrasena(nombre_usuario);
                bool resultado = Seguridad.valida_contrasena_hash(contrasena_a_probar, contrasena_hasheada);
                if (resultado)
                {
                    resultado_autenticacion = 0;
                }
            }
            return resultado_autenticacion;
        }

        /** @brief Método que inicia la sesión para un usuario.
         * @param nombre_usuario usuario cuya sesion se desea iniciar.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int iniciar_sesion(string nombre_usuario)
        {
            return m_base_datos.iniciar_sesion(nombre_usuario);
        }

        /** @brief Método que cierra la sesión iniciada en una computadora.
         * @param nombre_usuario usuario cuya sesion se desea cerrar.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int cerrar_sesion(string nombre_usuario)
        {
            return m_base_datos.cerrar_sesion(nombre_usuario);
        }

        /** @brief Método que consulta el estado de la sesion de un nombre de usuario
         * @param nombre_usuario usuario cuya sesion se desea consultar.
         * @return false si la sesion no esta iniciada, true si está iniciada
         */
        public bool consultar_sesion(string nombre_usuario)
        {
            return m_base_datos.consultar_sesion(nombre_usuario);
        }

        /** @brief Método que consulta el perfil de un usuario del sistema.
         * @param nombre_usuario usuario cuyo perfil se desea consultar.
         * @return false si es administrador, true si es miembro
         */
        public bool es_administrador(string nombre_usuario)
        {
            return m_base_datos.es_administrador(nombre_usuario);
        }

        /** @brief Metodo que revisa si el nombre de usuario ya esta siendo utilizado en el sistema.
         * @param El nombre de usuario que se desea verificar.
         * @return True si ya existe, False si no.
        */
        public bool existe_usuario(string nombre_usuario)
        {
            bool a_retornar = false;
            DataTable usuarios_disponibles = m_base_datos.solicitar_recursos_disponibles();
            int index = 0;
            while (!a_retornar && index < usuarios_disponibles.Rows.Count)
            {
                if (Convert.ToString(usuarios_disponibles.Rows[index]["username"]) == nombre_usuario)
                    a_retornar = true;
                ++index;
            }
            return a_retornar;
        }

    }
}