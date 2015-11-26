/*
 * Universidad de Costa Rica
 * Escuela de Ciencias de la Computación e Informática
 * Ingeniería de Software I
 * Sistema Administrador de Proyectos de Software (SAPS)
 * II Semestre 2015
*/
using SAPS.Controladoras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAPS.Controladoras;
using System.Data;

namespace SAPS.Fronteras
{
    public partial class InterfazReportes : System.Web.UI.Page
    {
        #region Variables de instancia
        ///Variables de instancia
        private static ControladoraReportes m_controladora_rep;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            alerta_advertencia.Visible = false;
            alerta_error.Visible = false;
            alerta_exito.Visible = false;
            if (!IsPostBack)
            {
                m_controladora_rep = new ControladoraReportes();
            }
        }

        /** @brief Metodo que llena la tabla con los proyectos que hay disponibles en el sistema.
         */
        private void llena_proyectos_disponibles()
        {
            DataTable proyectos_disponibles = m_controladora_rep.solicitar_proyectos_disponibles();
        }

        protected void btn_generar_reporte_Click(object sender, EventArgs e)
        {
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {

        }
    }
}