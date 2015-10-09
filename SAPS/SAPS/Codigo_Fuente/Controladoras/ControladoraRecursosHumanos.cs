using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SAPS.Entidades;
using SAPS.Codigo_Fuente.Base_de_Datos;
using SAPS.Codigo_Fuente.Ayudantes;

namespace SAPS.Codigo_Fuente.Controladoras
{
    public class ControladoraRecursosHumanos
    {
        // Variables de instancia
        BDRecursosHumanos m_base_datos;


        // Constructor
        public ControladoraRecursosHumanos()
        {
            m_base_datos = new BDRecursosHumanos();
        }


        // Métodos

        /** @brief Método que asigna las operaciones necesarias para poder insertar un recurso humano.
         * @param datos array que contiene los datos para poder crear un recurso humano.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int insertar_recurso_humano(Object[] datos) 
        {
            RecursoHumano recurso_humano = new RecursoHumano(datos);
            return m_base_datos.insertar_recurso_humano(recurso_humano);
        }

        /** @brief Método que asigna las operaciones necesarias para poder modificar un recurso humano.
         * @param datos array que contiene los datos para poder crear un recurso humano.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int modificar_recurso_humano(Object[] datos) 
        {
            RecursoHumano recurso_humano = new RecursoHumano(datos);
            return m_base_datos.modificar_recurso_humano(recurso_humano);
        }

        /** @brief Método que asigna las operaciones necesarias para poder eliminar un recurso humano.
         * @param datos array que contiene los datos para poder crear un recurso humano.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int eliminar_recurso_humano(string nombre_usuario) 
        {
            return m_base_datos.eliminar_recurso_humano(nombre_usuario);
        }

        /** @brief Método que asigna las operaciones necesarias para poder consultar un recurso humano en específico.
         * @param datos array que contiene los datos para poder crear un recurso humano.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public DataTable consultar_recurso_humano(string nombre_usuario)
        {
            return m_base_datos.consultar_recurso_humano(nombre_usuario);
        }

        /** @brief Método que asigna las operaciones necesarias para poder consultar los recursos humanos disponibles.
         * @param datos array que contiene los datos para poder crear un recurso humano.
         * @return DataTable con los resultados de la consultas.
         */
        public DataTable solicitar_recursos_disponibles()
        {
            return m_base_datos.solicitar_recursos_disponibles();
        }

        // Módulo Seguridad

        /** @brief Método que reestablece la contraseña de un recurso humano.
         * @param nombre_usuario usuario al cual se desea cambiar la contraseña.
         * @param nueva_contrasena string con la nueva contraseña deseada.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int restablecer_contrasena(string nombre_usuario, string nueva_contrasena) 
        {
            return 0;
        }

        /** @brief Método que verifica si el nombre de usuario y la contraseña coinciden.
         * @param nombre_usuario usuario al cual se desea cambiar la contraseña.
         * @param contrasena string que contiene la contraseña digitada por el usuario.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int autenticar(string nombre_usuario, string contrasena) 
        {
            return 0;
        }

        /** @brief Método que cierra la sesión iniciada en una computadora.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int cerrar_sesion() 
        {
            return 0;
        }
    }
}