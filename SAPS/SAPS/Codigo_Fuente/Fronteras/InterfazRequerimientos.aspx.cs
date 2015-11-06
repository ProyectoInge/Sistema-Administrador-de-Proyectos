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
using System.Web.UI;
using System.Web.UI.WebControls;
using SAPS.Controladoras;
using System.Data;

namespace SAPS.Fronteras
{
    public partial class InterfazRequerimientos : System.Web.UI.Page
    {
        private static ControladoraRequerimientos m_controladora_requerimientos;
        private static char m_opcion = 'i';  // i = insertar, m = modificar, e = eliminar
        private static int m_id_requerimeinto_seleccionado = -1;

        /** @brief Metodo que se llama al cargar la página.
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                m_controladora_requerimientos = new ControladoraRequerimientos();
                alerta_advertencia.Visible = false;
                alerta_error.Visible = false;
                alerta_exito.Visible = false;
                activa_desactiva_botones_ime(false);

                    actualiza_tabla_requerimientos();
            }
            else
            {
                Response.Redirect("~/Codigo_Fuente/Fronteras/InterfazLogin.aspx");
            }
        }

        protected void btn_crear_Click(object sender, EventArgs e)
        {
            m_opcion = 'i';
            btn_crear.CssClass = "btn btn-default active";
            btn_modificar.CssClass = "btn btn-default";
            btn_eliminar.CssClass = "btn btn-default";
            activa_desactiva_botones_ime(false);
        }

        protected void btn_modificar_Click(object sender, EventArgs e)
        {
            m_opcion = 'm';
            input_criterio_aceptacion.Enabled = true;
            input_nombre_requerimiento.Enabled = true;
            btn_crear.CssClass = "btn btn-default";
            btn_modificar.CssClass = "btn btn-default active";
            btn_eliminar.CssClass = "btn btn-default";
            activa_desactiva_botones_ime(true);
        }

        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            m_opcion = 'e';
            btn_crear.CssClass = "btn btn-default";
            btn_modificar.CssClass = "btn btn-default";
            btn_eliminar.CssClass = "btn btn-default active";
            input_criterio_aceptacion.Enabled = false;
            input_nombre_requerimiento.Enabled = false;
            activa_desactiva_botones_ime(true);
        }

        protected void btn_Aceptar_Click(object sender, EventArgs e)
        {
            switch (m_opcion)
            {
                case 'e':
                    if (!eliminar_requerimiento()) // false si no logro eliminar el requerimiento
                    {

        }
                    break;
                case 'i':
                    if (!insertar_requerimiento()) // false si no logro insertar el requerimiento
                    {

                    }
                    break;
                case 'm':
                    if (!modificar_requerimiento()) // false si no logro modificar el requerimiento
                    {

                    }
                    break;

            }
        }

        protected void btn_Cancelar_Click(object sender, EventArgs e)
        {
            vaciar_campos();
            input_nombre_requerimiento.Enabled = true;
            input_criterio_aceptacion.Enabled = true;
        }

        protected void btn_Regresar_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Codigo_Fuente/Fronteras/InterfazDisenoPruebas.aspx");
        }

        protected void btn_lista_requerimientos_Click(object sender, EventArgs e)
        {
            int id_requerimiento_seleccionado = Convert.ToInt32(((Button)sender).ID);
            llena_info_consulta(id_requerimiento_seleccionado);
            input_criterio_aceptacion.Enabled = false;
            input_nombre_requerimiento.Enabled = false;
            activa_desactiva_botones_ime(true);
            m_id_requerimeinto_seleccionado = id_requerimiento_seleccionado;
        }

        // ------------------------------------------------------ Métodos auxiliares ------------------------------------------------------

        private bool eliminar_requerimiento()
        {
            /// @todo
            return true;
        }

        private bool insertar_requerimiento()
        {
            /// @todo
            return true;
        }

        private bool modificar_requerimiento()
        {
            /// @todo
            return true;
        }

        /** @brief Método que se encarga de vaciar los campos de los datos de un requerimiento.
        */
        private void vaciar_campos()
        {
            m_id_requerimeinto_seleccionado = -1;
            input_criterio_aceptacion.Text = "";
            input_nombre_requerimiento.Text = "";
            m_opcion = 'i';
        }

        /** @brief Método que llena la información en pantalla correspondiente a un requerimiento que se consulta.
         * @param El identificador del requerimiento que se desea consultar.
        */
        private void llena_info_consulta(int id_requerimiento)
        {
            DataTable info_requerimiento = m_controladora_requerimientos.consultar_requerimiento(id_requerimiento);
            input_nombre_requerimiento.Text = info_requerimiento.Rows[0]["nombre"].ToString();
            input_criterio_aceptacion.Text = info_requerimiento.Rows[0]["criterio_aceptacion"].ToString();

        }
        /** @brief Pone activos los botones de "Eliminar" y "Modificar"
         * @param Bool con el estado de activacion de los botones ime (true/false)
         */
        private void activa_desactiva_botones_ime(bool estado)
        {
            btn_eliminar.Enabled = estado;
            btn_modificar.Enabled = estado;
            btn_crear.Enabled = true;
        }


        private void actualiza_tabla_requerimientos()
        {
            vaciar_tabla_requerimientos();
            llena_tabla_requerimientos();
        }

        private void vaciar_tabla_requerimientos()
        {
            tabla_requerimientos.Rows.Clear();
        }

        private void llena_tabla_requerimientos()
        {
            TableHeaderRow header = new TableHeaderRow();
            TableHeaderCell celda_encabezado_nombre = new TableHeaderCell();
            celda_encabezado_nombre.Text = "Nombre del requerimiento";
            header.Cells.Add(celda_encabezado_nombre);
            tabla_requerimientos.Rows.Add(header);

            DataTable tabla_requerimientos_disponibles = m_controladora_requerimientos.solicitar_requerimientos_disponibles();
            for (int i = 0; i < tabla_requerimientos_disponibles.Rows.Count; ++i)
            {
                TableRow fila = new TableRow();
                TableCell celda_nombre = new TableCell();
                Button btn = new Button();
                btn.ID = tabla_requerimientos_disponibles.Rows[i]["id_requerimiento"].ToString();
                btn.Text = tabla_requerimientos_disponibles.Rows[i]["nombre"].ToString();
                btn.CssClass = "btn btn-link btn-block";
                btn.Click += new EventHandler(btn_lista_requerimientos_Click);

                celda_nombre.Controls.Add(btn);
                fila.Cells.Add(celda_nombre);
                tabla_requerimientos.Rows.Add(fila);
            }
        }
    }
}