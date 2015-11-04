using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAPS.Fronteras
{
    public partial class InterfazDisenoPruebas : System.Web.UI.Page
    {

        private static char m_opcion = 'i'; // i = insertar, m = modificar, e = eliminar


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /** @brief Evento que se activa cuando el usuario selecciona la opción de "modificar".
 * @param Los parametros por default de un evento de C#.
*/
        protected void btn_modificar_Click(object sender, EventArgs e)
        {
            m_opcion = 'm';
            /*
            //btn_reestablece_contrasena.Visible = true;
            //activa_desactiva_inputs(true);
            //if (radio_btn_administrador.Checked == true)
            //{
                drop_rol.Enabled = false;
                drop_proyecto_asociado.Enabled = false;
            }
            activa_desactiva_botones_ime(true);
            input_contrasena.Enabled = false;
            input_usuario.Enabled = false;
            btn_eliminar.CssClass = "btn btn-default";
            btn_crear.CssClass = "btn btn-default";
            btn_modificar.CssClass = "btn btn-default active";
            if (!m_es_administrador)
            {
                radio_btn_administrador.Enabled = false;
            }
            */
        }

        /** @brief Evento que se activa cuando el usuario selecciona la opción de "eliminar".
         * @param Los parametros por default de un evento de C#.
        */
        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            /*
            if (m_es_administrador)
            {
                m_opcion = 'e';
                btn_reestablece_contrasena.Visible = false;
                activa_desactiva_inputs(false);
                activa_desactiva_botones_ime(true);
                btn_eliminar.CssClass = "btn btn-default active";
                btn_crear.CssClass = "btn btn-default";
                btn_modificar.CssClass = "btn btn-default";
            }
            else
            {
                cuerpo_alerta_advertencia.Text = " No está autorizado para eliminar recursos humanos.";
                alerta_advertencia.Visible = true;
            }
            */
        }

        /** @brief Evento que se activa cuando el usuario selecciona la opción de "insertar".
         * @param Los parametros por default de un evento de C#.
        */
        protected void btn_crear_Click(object sender, EventArgs e)
        {
            /*
            if (m_es_administrador)
            {
                m_opcion = 'i';
                activa_desactiva_inputs(true);
                btn_reestablece_contrasena.Visible = false;
                limpia_campos();
                activa_desactiva_botones_ime(false);
                drop_rol.Enabled = false;
                drop_proyecto_asociado.Enabled = false;
                btn_eliminar.CssClass = "btn btn-default";
                btn_crear.CssClass = "btn btn-default active";
                btn_modificar.CssClass = "btn btn-default ";
            }
            else
            {
                cuerpo_alerta_advertencia.Text = " No está autorizado para agregar recursos humanos.";
                alerta_advertencia.Visible = true;
            }
            */
        }
    }
}