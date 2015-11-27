/*
 * Universidad de Costa Rica
 * Escuela de Ciencias de la Computación e Informática
 * Ingeniería de Software I
 * Sistema Administrador de Proyectos de Software (SAPS)
 * II Semestre 2015
*/

using System.Data;
using SAPS.Entidades;
using System.Data.SqlClient;
using System;

namespace SAPS.Base_de_Datos
{
    /** @brief capa encargada de comunicarse con la base de datos 
     * para efectuar las correspondientes inserciones, modificaciones, eliminaciones y consultas SQL
     * relacionadas con los recusros humanos.
     */
    public class BDProyectoPruebas
    {
        // Variables de instancia
        DataBaseAdapter m_data_base_adapter;

        // Constructor
        public BDProyectoPruebas()
        {
            m_data_base_adapter = new DataBaseAdapter();
        }


        // Métodos

        /** @brief Método que realiza la setencia SQL para insertar un proyecto.
         * @param proyecto a guardar en la base de datos.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int insertar_proyecto(ProyectoPruebas proyecto)
        {
            // Procedimiento almacenado
            SqlCommand comando = new SqlCommand("INSERTAR_PYP");
            rellenar_parametros_proyecto_pruebas(ref comando, proyecto);
            return m_data_base_adapter.ejecutar_consulta(comando);
        }

        /** @brief Método que realiza la setencia SQL para modificar un proyecto.
         * @param proyecto a guardar en la base de datos.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int modificar_proyecto(ProyectoPruebas proyecto)
        {
            // Procedimiento almacenado
            SqlCommand comando = new SqlCommand("MODIFICAR_PYP");
            rellenar_parametros_proyecto_pruebas(ref comando, proyecto);
            return m_data_base_adapter.ejecutar_consulta(comando);
        }


        /** @brief Método que realiza la setencia SQL para eliminar un proyecto en específico.
         * @param id_proyecto del proyecto que se desea consultar.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int eliminar_proyecto(int id_proyecto)
        {
            // Procedimiento almacenado
            SqlCommand comando = new SqlCommand("ELIMINAR_PYP");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id_proyecto", SqlDbType.Int).Value = id_proyecto;
            return m_data_base_adapter.ejecutar_consulta(comando);
        }

        /** @brief Método que realiza la setencia SQL para conultar un proyecto en específico.
         * @param id_proyecto del proyecto que se desea consultar.
         * @return DataTable con los resultados de la consultas.
         */
        public DataTable consultar_proyecto(int id_proyecto)
        {
            // Procedimiento almacenado
            SqlCommand comando = new SqlCommand("CONSULTAR_PYP");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id_proyecto", SqlDbType.Int).Value = id_proyecto;
            return m_data_base_adapter.obtener_resultado_consulta(comando);
        }

        /** @brief Método que realiza la setencia SQL para consultar todos los proyectos de pruebas que se encuentran en la Base de Datos.
         * @return DataTable con los resultados de la consultas.
        */
        public DataTable solicitar_proyectos_disponibles()
        {
            // Procedimiento almacenado
            SqlCommand comando = new SqlCommand("CONSULTAR_PROYECTOS_DISPONIBLES");
            comando.CommandType = CommandType.StoredProcedure;
            return m_data_base_adapter.obtener_resultado_consulta(comando);
        }

        /** @brief Método que realiza la setencia SQL para consultar la informacion de mi proyecto de pruebas
         * @param username de quien realiza la consulta
         * @return DataTable con el resultado de la consultas.
         */
        public DataTable solicitar_mi_proyecto(string nombre_usuario)
        {
            // Procedimiento almacenado
            SqlCommand comando = new SqlCommand("CONSULTAR_MI_PROYECTO");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@username", SqlDbType.VarChar).Value = nombre_usuario;
            return m_data_base_adapter.obtener_resultado_consulta(comando);
        }


        /** @brief Método que realiza la setencia SQL para consultar todas las oficinas que se encuentran en la Base de Datos.
         * @return DataTable con los resultados de la consultas.
         */
        public DataTable solicitar_oficinas_disponibles()
        {
            //Procedimiento almacenado
            SqlCommand comando = new SqlCommand("CONSULTAR_OFICINAS_DISPONIBLES");
            comando.CommandType = CommandType.StoredProcedure;
            return m_data_base_adapter.obtener_resultado_consulta(comando);
        }

        /** @brief Método que realiza la setencia SQL para insertar una nueva oficina.
         * @param datos array con los datos de la oficina.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int insertar_oficina(Oficina nueva_oficina)
        {
            //Procedimiento almacenado
            SqlCommand comando = new SqlCommand("INSERTAR_OFICINA");
            rellenar_parametros_oficina(ref comando, nueva_oficina);
            return m_data_base_adapter.ejecutar_consulta(comando);
        }

        /** @brief Método que realiza la setencia SQL para conultar una oficina en específico.
         * @param id de la oficina que se desea consultar.
         * @return DataTable con los resultados de la consultas.
         */
        public DataTable consultar_oficina(int id_oficina)
        {
            //Procedimiento almacenado
            SqlCommand comando = new SqlCommand("CONSULTAR_OFICINA");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id_oficina", SqlDbType.Int).Value = id_oficina;
            return m_data_base_adapter.obtener_resultado_consulta(comando);
        }

        /** @brief Método que se encarga de realizar una sentencia SQL para obtener los proyectos que no han sido eliminados
         * @return Información de todos los proyectos que no han sido eliminados.
        */
        public DataTable solicitar_proyectos_no_eliminados()
        {
            SqlCommand comando = new SqlCommand("SOLICITAR_PROYECTOS_NO_ELIMINADOS");
            comando.CommandType = CommandType.StoredProcedure;
            return m_data_base_adapter.obtener_resultado_consulta(comando);
        }


        /**@brief Método que se encarga de realizar una sentencia SQL para obtener los proyectos aplicandole una serie de filtros
        * @param datos array con los valores de los filtros que se desean aplicar.
        * @return Información de todos los proyectos que cumplen las condiciones específicadas en los filtros.
        */
        public DataTable aplicar_filtros_proyecto_pruebas(string[] datos)
        {
            SqlCommand comando = new SqlCommand("");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@filtro_id_oficina", SqlDbType.Int).Value = datos[0];
            comando.Parameters.Add("@filtro_despues_de", SqlDbType.DateTime).Value = datos[1];
            comando.Parameters.Add("@filtro_antes_de", SqlDbType.DateTime).Value = datos[2];
            comando.Parameters.Add("@filtro_nombre_sistema", SqlDbType.VarChar).Value = datos[3];
            comando.Parameters.Add("@filtro_estado", SqlDbType.VarChar).Value = datos[4];
            return m_data_base_adapter.obtener_resultado_consulta(comando);
        }




        // Métodos auxiliares

        /** @brief Metodo que se encarga de sacar la informacion del objeto "ProyectoPruebas" y con esta informacion
                   construye llama al procedimiento almacenado de la base de datos.
         * @param La referencia al procedimiento almacenado en la base.
         * @param El objeto ProyectoPruebas del que va a obtener la información.
        */
        private void rellenar_parametros_proyecto_pruebas(ref SqlCommand comando, ProyectoPruebas proyecto)
        {
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id_proyecto", SqlDbType.Int).Value = proyecto.id;
            comando.Parameters.Add("@id_oficina", SqlDbType.Int).Value = proyecto.id_oficina;
            comando.Parameters.Add("@fecha_inicio", SqlDbType.DateTime).Value = proyecto.fecha_inicio;
            comando.Parameters.Add("@fecha_asignacion", SqlDbType.DateTime).Value = proyecto.fecha_asignacion;
            if (proyecto.fecha_finalizacion == default(DateTime))
                comando.Parameters.Add("@fecha_final", SqlDbType.DateTime).Value = DBNull.Value;
            else
                comando.Parameters.Add("@fecha_final", SqlDbType.DateTime).Value = proyecto.fecha_finalizacion;
            comando.Parameters.Add("@nombre_sistema", SqlDbType.VarChar).Value = proyecto.nombre_sistema;
            comando.Parameters.Add("@obj_general", SqlDbType.VarChar).Value = proyecto.objetivo;
            comando.Parameters.Add("@nombre_proyecto", SqlDbType.VarChar).Value = proyecto.nombre;
            comando.Parameters.Add("@estado", SqlDbType.VarChar).Value = proyecto.estado;

        }

        /** @brief Metodo que se encarga de sacar la informacion del objeto "Oficina" y con esta informacion
                   construye llama al procedimiento almacenado de la base de datos.
         * @param La referencia al procedimiento almacenado en la base.
         * @param El objeto Oficina del que va a obtener la información.
        */
        private void rellenar_parametros_oficina(ref SqlCommand comando, Oficina oficina)
        {
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@nombre_oficina", SqlDbType.VarChar).Value = oficina.nombre;
            comando.Parameters.Add("@telefono", SqlDbType.VarChar).Value = oficina.telefono_1;
            comando.Parameters.Add("@telefono2", SqlDbType.VarChar).Value = oficina.telefono_2;
            comando.Parameters.Add("@nom_representante", SqlDbType.VarChar).Value = oficina.representante;
        }
    }

}