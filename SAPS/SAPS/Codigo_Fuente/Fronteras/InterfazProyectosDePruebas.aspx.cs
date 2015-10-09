/*
 * Universidad de Costa Rica
 * Escuela de Ciencias de la Computación e Informática
 * Ingeniería de Software I
 * Sistema Administrador de Proyectos de Software (SAPS)
 * II Semestre 2015
 * --------------------------------------------------------------------------------------------
 * Esta clase frontera se encarga de obtener los datos y los eventos que el usuario selecciona,
 * se lo pasa a la controladora de la clase proyecto_de_pruebas.
 * --------------------------------------------------------------------------------------------
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAPS.Codigo_Fuente.Controladoras;
using System.Text.RegularExpressions;

namespace SAPS.Fronteras
{
    public partial class InterfazProyectosDePruebas : System.Web.UI.Page
    {
        ControladoraProyectoPruebas m_controladora_pdp;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}