﻿/*
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
        private static bool m_es_administrador;
        private static ControladoraReportes m_controladora_rep;
        private static List<Pair> m_proyectos; //Va a tener los proyectos que se estan mostrando en la interfaz
        /*
            |   Indice  | Significado    | Tipo  |
            |:---------:|:--------------:|:-----:|
            |     0     |   ID Proyecto  |  int  |
            |     1     |   Estado       |  bool |
            */
        private static List<Pair> m_disenos; //Va a tener los diseños que se estan mostrando en la interfaz
        /*
             |   Indice  | Significado    | Tipo  |
             |:---------:|:--------------:|:-----:|
             |     0     |   ID Diseño    |  int  |
             |     1     |   Estado       |  bool |
             */
        private static List<Pair> m_casos; //Va a tener los casos que se estan mostrando en la interfaz
        /*
             |   Indice  | Significado    |   Tipo   |
             |:---------:|:--------------:|:--------:|
             |     0     |   ID Caso      |  string  |
             |     1     |   Estado       |  bool    |
             */
        private static List<Pair> m_ejecuciones; //Va a tener las ejecuciones que se estan mostrando en la interfaz
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
                    m_es_administrador = m_controladora_rep.es_administrador(Context.User.Identity.Name);
                }
                else
                {

                }
                actualiza_proyectos_disponibles();
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

        /** @brief Metodo que se activa cuando el usuario selecciona una casilla de los proyectos
        */
        protected void check_estado_proyecto_Cambia(object sender, EventArgs e)
        {
            int i = 24;
            ///@todo En el ID del sender viene el identificador dle proyecto que se selecciono
        }

        /** @brief Metodo que llena la tabla con los proyectos que hay disponibles en el sistema.
         */
        private void llena_proyectos_disponibles()
        {
            DataTable proyectos_disponibles = null;
            //Llena la DataTable con la información de todos los proyectos (si soy administrador) o con la del proyecto que tengo asociado (si soy usuario normal).
            if (m_es_administrador)
                proyectos_disponibles = m_controladora_rep.solicitar_proyectos_disponibles();
            else
                proyectos_disponibles = m_controladora_rep.consultar_mi_proyecto(Context.User.Identity.Name);

            for (int i = 0; i < proyectos_disponibles.Rows.Count; ++i)
            {
                //Lo agrego a la estructura que lleva control de los proyectos
                Pair pareja_tmp = new Pair();
                pareja_tmp.First = Convert.ToInt32(proyectos_disponibles.Rows[i]["id_proyecto"]);
                pareja_tmp.Second = false;
                m_proyectos.Add(pareja_tmp);

                //Agrego el elemento a la tabla que se muestra en la vista
                TableRow fila_tmp = new TableRow();
                TableCell celda_tmp = new TableCell();

                celda_tmp.Text = proyectos_disponibles.Rows[i]["nombre_proyecto"].ToString();
                fila_tmp.Cells.Add(celda_tmp);

                celda_tmp = new TableCell();
                CheckBox check_tmp = new CheckBox();
                check_tmp.ID = proyectos_disponibles.Rows[i]["id_proyecto"].ToString();
                check_tmp.CheckedChanged += new EventHandler(check_estado_proyecto_Cambia);
                check_tmp.AutoPostBack = true;
                check_tmp.CssClass = "checkbox-inline";
                celda_tmp.Controls.Add(check_tmp);

                //Esto es para poner la fila en rojo indicando que el proyecto fue eliminado
                if (Convert.ToBoolean(proyectos_disponibles.Rows[i]["eliminado"]))
                    fila_tmp.CssClass = "danger";

                fila_tmp.Cells.Add(celda_tmp);
                tabla_proyectos.Rows.Add(fila_tmp);

            }
        }

        protected void btn_generar_reporte_Click(object sender, EventArgs e)
        {
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {

        }
    }
}