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
    public partial class InterfazEjecucionPruebas : System.Web.UI.Page
    {
        ///Variables de instancia
        private static ControladoraEjecuciones m_controladora_ep;
        private static char m_opcion = 'i';
        private static int[] m_llave_ejecucion; //posiciones: 0 - num_ejecucion, 1 - id_diseno

        private static bool m_es_administrador;


        /** @brief Metodo que se llama al cargar la página.
        */
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                m_controladora_ep = new ControladoraEjecuciones();
                m_opcion = 'i';
                m_llave_ejecucion = new int[2] { -1, -1 };
                alerta_advertencia.Visible = false;
                alerta_error.Visible = false;
                alerta_exito.Visible = false;

                if (!IsPostBack)
                {

                    m_es_administrador = m_controladora_ep.es_administrador(Context.User.Identity.Name);
                    actualiza_disenos();
                }
            }
            else
            {
                Response.Redirect("~/Codigo_Fuente/Fronteras/InterfazLogin.aspx");
            }

        }

        /** @brief Método que activa o desactiva todos los espacios de ingreso de datos.
        * @param bool que indica si se desea activar o desactivar todos los campos.
        */
        protected void activa_desactiva_inputs(bool v)
        {
            drop_disenos_disponibles.Enabled = v;
            tabla_resultados.Enabled = v;
            drop_rh_disponibles.Enabled = v;
            input_fecha.Enabled = v;
            input_incidentes.Enabled = v;
            tabla_ejecuciones.Enabled = v;
        }

        protected void btn_modificar_Click(object sender, EventArgs e)
        {
            ///@todo
        }

        /** @brief Método que se activa al seleccionar el botón eliminar de los botones de IME
        * @param parámetros por defecto de ASP
        */
        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            ///@todo
            m_opcion = 'e';
            btn_crear.CssClass = "btn btn-default active";
            btn_modificar.CssClass = "btn btn-default";
            btn_eliminar.CssClass = "btn btn-default";
            activa_desactiva_inputs(false);
        }

        protected void btn_crear_Click(object sender, EventArgs e)
        {
            ///@todo
        }

        /** @brief Método que se activa al seleccionar el botón Aceptar, debe distinguir sobre cual funcionalidad de IME se trata
        * @param parámetros por defecto de ASP
        */
        protected void btn_Aceptar_Click(object sender, EventArgs e)
        {
            alerta_error.Visible = false;
            switch (m_opcion)
            {
                case 'i':
                    ///@todo
                    break;

                case 'e':
                    eliminar_ejecucion();
                    break;

                case 'm':
                    ///@todo
                    break;
                default:
                    cuerpo_alerta_error.Text = " Se presentó un problema al procesar su solicitud, intente nuevamente.";
                    alerta_error.Visible = true;
                    break;
            }
        }
        protected void btn_Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Codigo_Fuente/Fronteras/InterfazEjecucionPruebas.aspx");
        }

        /** @brief Método que se encarga de hacer los pasos necesarios para eliminar una ejecucion
        *   @return true si fue exitoso, false si no.
        */
        private bool eliminar_ejecucion()
        {
            bool a_retornar = false;
            if (m_llave_ejecucion[0] != -1 && m_llave_ejecucion[1] != -1)
            {
                cuerpo_modal.Text = " ¿Esta seguro que desea eliminar la ejecución del sistema?";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modal_alerta", "$('#modal_alerta').modal();", true);
                upModal.Update();
                a_retornar = true;
            }
            else
            {
                cuerpo_alerta_error.Text = "No se ha seleccionado ningúna ejecución.";
            }
            return a_retornar;
        }

        /** @brief Método que se activa al seleccionar el botón aceptar del modal de eliminar ejecucion
        * @param parámetros por defecto de ASP
        */
        protected void btn_modal_aceptar_Click(object sender, EventArgs e)
        {
            int resultado = m_controladora_ep.eliminar_ejecucion(m_llave_ejecucion[1], m_llave_ejecucion[0]);
            Response.Redirect("~/Codigo_Fuente/Fronteras/InterfazEjecucionPruebas.aspx");
        }

        /** @brief Método que se activa al seleccionar el botón cancelar del modal de eliminar ejecucion
        * @param parámetros por defecto de ASP
        */
        protected void btn_modal_cancelar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modal_alerta", "$('#modal_alerta').modal('hide');", true);
            upModal.Visible = false;
            upModal.Update();
            Response.Redirect("~/Codigo_Fuente/Fronteras/InterfazEjecucionPruebas.aspx");
        }

        protected void btn_agregar_resultado_Click(object sender, EventArgs e)
        {
            ///@todo
        }

        protected void btn_eliminar_resultado_Click(object sender, EventArgs e)
        {
            ///@todo sacar el num de resultado
            int num_resultado = 0;
            m_controladora_ep.eliminar_resultado(m_llave_ejecucion[1], m_llave_ejecucion[0], num_resultado);
        }

        /** @brief Método que actualiza el combobox con los diseños disponibles en el sistema
         */
        private void actualiza_disenos()
        {
            vacia_disenos();
            llena_disenos();
        }

        /** @brief Método que vacia el combobox de los diseños disponibles.
         */
        private void vacia_disenos()
        {
            drop_disenos_disponibles.Items.Clear();
        }

        /** @brief Método que llena el combobox con los diseños disponibles en el sistema.
         */
        private void llena_disenos()
        {
            DataTable disenos_disponibles = null;
            if (m_es_administrador)
            {
                // Como soy administrador, puedo ver todos los diseños que hay en el sistema.
                disenos_disponibles = m_controladora_ep.solicitar_disenos_disponibles();
            }
            else
            {
                ///@todo Si soy un usuario normal, solo puedo ver los diseños que tiene asociados el proyecto al que pertenezco.
            }

            ListItem item_tmp = new ListItem();
            item_tmp.Text = "-Seleccione un diseño-";
            item_tmp.Value = "";
            drop_disenos_disponibles.Items.Add(item_tmp);

            for (int i = 0; i < disenos_disponibles.Rows.Count; ++i)
            {
                item_tmp = new ListItem();
                item_tmp.Text = disenos_disponibles.Rows[i]["nombre_diseno"].ToString();
                item_tmp.Value = disenos_disponibles.Rows[i]["id_diseno"].ToString();
                drop_disenos_disponibles.Items.Add(item_tmp);
            }
        }

        /** @brief Evento que se activa cuando se selecciona un nuevo elemento del combobox de los diseños disponibles.
         * @param Los parametros por defecto de un evento de ASP.
         */
        protected void drop_disenos_disponibles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drop_disenos_disponibles.SelectedItem.Value != "")
            {
                int id_diseno_seleccionado = Convert.ToInt32(drop_disenos_disponibles.SelectedItem.Value);
                llena_info_diseno(id_diseno_seleccionado);
            }

        }

        /** @brief Método que se encarga de llenar la informacion del diseño que se seleccionó.
         */
        private void llena_info_diseno(int id_diseno)
        {
            DataTable info_diseno = m_controladora_ep.consultar_diseno(id_diseno);
            if (info_diseno.Rows.Count > 0)
            {
                input_ambiente_diseno.Text = info_diseno.Rows[0]["ambiente"].ToString();
                input_criterios_aceptacion_diseno.Text = info_diseno.Rows[0]["criterio_aceptacion"].ToString();
                ///@todo Llenar el procedimiento del diseño
            }
        }
    }
}