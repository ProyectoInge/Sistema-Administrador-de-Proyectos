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
using SAPS.Entidades;
using System.Data.SqlClient;
using System.Data;

namespace SAPS.Base_de_Datos
{
    /** @brief capa encargada de comunicarse con la base de datos para efectuar las correspondientes inserciones, modificaciones,
               eliminaciones y consultas SQL relacionadas con los casos de pruebas.
     */

    // Variables de instancia

    DataBaseAdapter m_data_base_adapter;

    //Constructor
    public class BDCasoPruebas
    {
        m_data_base_adapter = new DataBaseAdapter();
    }


    // Métodos

    /** @brief Método que realiza la setencia SQL para insertar un nuevo caso de pruebas.
     * @param caso de pruebas a guardar en la base de datos.
     * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
     */

    public int insertar_caso_pruebas()
    {

    }

    /** @brief Método que realiza la setencia SQL para modificar un caso de pruebas.
         * @param caso a guardar en la base de datos.
         * @return 0 si la operación se realizó con éxito, números negativos si pasó algún error con la Base de Datos.
         */
    public int modificar_diseno_pruebas()
    {

    }

    /** @brief Método que realiza la setencia SQL para conultar un caso de pruebas en específico
        * @param id del caso que se desea consultar.
        * @return DataTable con los resultados de la consultas.
        */

    public DataTable consultar_caso_pruebas()
    {


    }

    /** @brief Método que realiza la setencia SQL para consultar todos los casos de pruebas que se encuentran en la base de datos.
         * @return DataTable con los resultados de la consultas.
        */
    public DataTable solicitar_casos_disponibles()
    {

    }

                                                    // Métodos auxiliares

}