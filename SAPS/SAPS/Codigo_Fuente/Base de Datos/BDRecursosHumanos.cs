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
using System.Data;
using System.Data.SqlClient;
using SAPS.Codigo_Fuente.Base_de_Datos;
using SAPS.Entidades;

namespace SAPS.Codigo_Fuente.Base_de_Datos
{
    public class BDRecursosHumanos
    {
        // Variables de instacia
        DataBaseAdapter m_data_base_adapter;

        // Constructor
        public BDRecursosHumanos()
        {
            m_data_base_adapter = new DataBaseAdapter();
        }

        // Métodos

        /** @brief Método que realiza la setencia SQL para insertar un recurso humano.
         * @param recurso_humano a guardar en la base de datos.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int insertar_recurso_humano(RecursoHumano recurso_humano)
        {
            string consulta="";
            int admin = recurso_humano.es_administrador ? 1 : 0; //si se tira el bool a la consulta, este imprime True o False, no 1 o 0.
            if (recurso_humano.es_administrador)
            {
                consulta = "INSERT INTO RecursosHumanos VALUES( \'" + recurso_humano.usuario +
                    "\' , \'" + recurso_humano.cedula +
                    "' , null "+
                    " , \'" + recurso_humano.telefono +
                    "\' , \'"+recurso_humano.nombre +
                    "\' , \'" + recurso_humano.contrasena +
                    "\' , \'" + recurso_humano.correo +
                    "' , null "+
                    " , " + admin +
                    " );\n";
            }
            else
            {
                
                consulta = "INSERT INTO RecursosHumanos VALUES( \'" + recurso_humano.usuario +
                    "\' , \'" + recurso_humano.proyecto_asociado +
                    "\' , \'" + recurso_humano.telefono +
                    "\' , \'" + recurso_humano.nombre +
                    "\' , \'" + recurso_humano.contrasena +
                    "\' , \'" + recurso_humano.correo +
                    "\' , \'" + recurso_humano.rol + 
                    "\' , " + admin +
                    " );\n";
            }
            

            // DEBUG
            System.Diagnostics.Debug.Write("Ejecutando: " + consulta);
            return m_data_base_adapter.ejecutar_consulta(consulta);
        }

        /** @brief Método que realiza la setencia SQL para modificar un recurso humano.
         * @param recurso_humano a guardar en la base de datos.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int modificar_recurso_humano(RecursoHumano recurso_humano)
        {
            string consulta = "UPDATE RecursosHumanos SET id_proyecto = \'" + recurso_humano.proyecto_asociado +
                "\', telefono = \'" + recurso_humano.telefono +
                "\', nombre = \'" + recurso_humano.nombre +
                "\', correo = \'" + recurso_humano.correo +
                "\', rol = \'" + recurso_humano.rol +
                "\' WHERE username = \'" + recurso_humano.usuario +
                "\';";

            // DEBUG
            System.Diagnostics.Debug.Write("Ejecutando: " + consulta);
            return m_data_base_adapter.ejecutar_consulta(consulta);
        }


        /** @brief Método que realiza la setencia SQL para eliminar un recurso humano en específico.
         * @param nombre_usuario del recuros humano que se desea consultar.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public int eliminar_recurso_humano(string nombre_usuario)
        {
            string consulta = "DELETE FROM RecursosHumanos WHERE username = \'" + nombre_usuario +
                "\';";

            // DEBUG
            System.Diagnostics.Debug.Write("Ejecutando: " + consulta);
            return m_data_base_adapter.ejecutar_consulta(consulta);
        }

        /** @brief Método que realiza la setencia SQL para conultar un recurso humano en específico.
         * @param nombre_usuario del recuros humano que se desea consultar.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public DataTable consultar_recurso_humano(string nombre_usuario)
        {
            string consulta = "SELECT * FROM RecursosHumanos WHERE username = \'" + nombre_usuario +
                "\';";

            // DEBUG
            System.Diagnostics.Debug.Write("Ejecutando: " + consulta);
            return m_data_base_adapter.obtener_resultado_consulta(consulta);
        }

        /** @brief Método que realiza la setencia SQL para conultar todos recursos humanos que se encuentran en la Base de Datos.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
        public DataTable solicitar_recursos_disponibles()
        {
            string consulta = "SELECT nombre FROM RecursosHumanos";

            // DEBUG
            System.Diagnostics.Debug.Write("Ejecutando: " + consulta);
            return m_data_base_adapter.obtener_resultado_consulta(consulta);
        }
    }
}