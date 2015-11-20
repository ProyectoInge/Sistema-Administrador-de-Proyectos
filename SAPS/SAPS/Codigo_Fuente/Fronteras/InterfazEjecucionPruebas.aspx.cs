using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAPS.Controladoras;

namespace SAPS.Fronteras
{
    public partial class InterfazEjecucionPruebas : System.Web.UI.Page
    {
        ///Variables de instancia
        private static ControladoraEjecuciones m_controladora_ep;
        private static char m_opcion = 'i';
        private static int[] m_llave_ejecucion; //posiciones: 0 - num_ejecucion, 1 - id_diseno


        /** @brief Metodo que se llama al cargar la página.
        */
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                m_controladora_ep = new ControladoraEjecuciones();
                m_opcion = 'i';
                m_llave_ejecucion = new int[2] {-1, -1};
                alerta_advertencia.Visible = false;
                alerta_error.Visible = false;
                alerta_exito.Visible = false;
            }
            else
            {
                Response.Redirect("~/Codigo_Fuente/Fronteras/InterfazLogin.aspx");
            }

        }


        /** @brief Método que activa o desactiva todos los botones de ingresar, modificar y eliminar.
        * @param bool que indica si se desea activar o desactivar todos los campos.
        */
        protected void activa_desactiva_botones_ime(bool v)
        {
            btn_crear.Enabled = v;
            btn_modificar.Enabled = v;
            btn_eliminar.Enabled = v;
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

        /**@brief Metodo encargado de activar la funcionalidad para modificar una ejecucion de pruebas
        **/
        protected void btn_modificar_Click(object sender, EventArgs e)
        {           
            m_opcion = 'm';
            btn_crear.CssClass = "btn btn-default active";
            btn_modificar.CssClass = "btn btn-default";
            btn_eliminar.CssClass = "btn btn-default";
            activa_desactiva_inputs(true);
            activa_desactiva_botones_ime(false);
            btn_modificar.Enabled = true;

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
                    modificar_ejecucion();                    
                    break;          
                default:
                    cuerpo_alerta_error.Text = " Se presentó un problema al procesar su solicitud, intente nuevamente.";
                    alerta_error.Visible = true;
                    break;
            }
        }

        private bool modificar_ejecucion()
        {
            bool respuesta = false;                                      // Bandera especifica que indica el exito o fallo de la modificacion






            return respuesta;
        }

        protected void btn_Cancelar_Click(object sender, EventArgs e)
        {
            ///@todo
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
            int num_resultado=0;
            m_controladora_ep.eliminar_resultado(m_llave_ejecucion[1], m_llave_ejecucion[0], num_resultado);
        }
    }
}