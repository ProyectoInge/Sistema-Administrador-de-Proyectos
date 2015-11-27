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
        private List<Pair> m_proyectos; //Va a tener los proyectos que se estan mostrando en la interfaz
        /*
            |   Indice  | Significado    | Tipo  |
            |:---------:|:--------------:|:-----:|
            |     0     |   ID Proyecto  |  int  |
            |     1     |   Estado       |  bool |
            */
        private List<Pair> m_disenos; //Va a tener los diseños que se estan mostrando en la interfaz
        /*
             |   Indice  | Significado    | Tipo  |
             |:---------:|:--------------:|:-----:|
             |     0     |   ID Diseño    |  int  |
             |     1     |   Estado       |  bool |
             */
        private List<Pair> m_casos; //Va a tener los casos que se estan mostrando en la interfaz
        /*
             |   Indice  | Significado    |   Tipo   |
             |:---------:|:--------------:|:--------:|
             |     0     |   ID Caso      |  string  |
             |     1     |   Estado       |  bool    |
             */
        private List<Pair> m_ejecuciones; //Va a tener las ejecuciones que se estan mostrando en la interfaz
        /*
             |   Indice  | Significado    |                 Tipo                     |
             |:---------:|:--------------:|:----------------------------------------:|
             |     0     |  ID Ejecucion  |  Pair<int id_diseno, int num_ejecucion>  |
             |     1     |   Estado       |                 bool                     |
             */
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                alerta_advertencia.Visible = false;
                alerta_error.Visible = false;
                alerta_exito.Visible = false;
                m_controladora_rep = new ControladoraReportes();
                if (!IsPostBack)    //Primera vez que carga la pagina
                {
                    m_proyectos = new List<Pair>();
                    m_casos = new List<Pair>();
                    m_disenos = new List<Pair>();
                    m_ejecuciones = new List<Pair>();
                    ///@todo Llenar estas listas con la informacion que hay en el sistema (toda si soy administrador, con base en el id_proyecto si soy usuario normal)
                }
                else
                {

                }
            }
            else
            {
                Response.Redirect("~/Codigo_Fuente/Fronteras/InterfazLogin.aspx");
            }

        }

        /** @brief Metodo que actualiza los proyectos que hay en el sistema en la interfaz
        */
        private void actualiza_proyectos_disponibles()
        {
            vacia_proyectos_disponibles();
            llena_proyectos_disponibles();
        }

        /** @brief Metodo que borra todas las filas de la tabla de los proyectos
        */
        private void vacia_proyectos_disponibles()
        {
            tabla_proyectos.Rows.Clear();
        }


        /** @brief Metodo que llena la tabla con los proyectos que hay disponibles en el sistema.
         */
        private void llena_proyectos_disponibles()
        {
            DataTable proyectos_disponibles = m_controladora_rep.solicitar_proyectos_disponibles();
            ///@todo Si soy usuario, solo me sale mi proyecto
        }

        protected void btn_generar_reporte_Click(object sender, EventArgs e)
        {
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {

        }
    }
}