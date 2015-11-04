using System;
using System.Collections.Generic;
using SAPS.Controladoras;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SAPS.Fronteras
{
    public partial class InterfazDisenoPruebas : System.Web.UI.Page
    {

        private static ControladoraDisenosPruebas m_controladora_dp;
        private static ControladoraRecursosHumanos m_controladora_rh;
        private static ControladoraProyectoPruebas m_controladora_pyp;

        private static char m_opcion = 'i'; // i = insertar, m = modificar, e = eliminar
        private static bool m_es_administrador;   // true si el usuario de la sesion es administrador, false si no.

        private static Object[,] m_tabla_proyectos_disponibles;
        private static int m_tamano_tabla_pyp;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                m_controladora_dp = new ControladoraDisenosPruebas();
                m_controladora_rh = new ControladoraRecursosHumanos();
                m_controladora_pyp = new ControladoraProyectoPruebas();
        alerta_error.Visible = false;
                alerta_exito.Visible = false;
                alerta_advertencia.Visible = false;

                if (!IsPostBack)
                {
                    //actualiza_proyectos();
                    //actualiza_requerimientos();
                    //actualiza_rh();
                    m_es_administrador = m_controladora_rh.es_administrador(Context.User.Identity.Name);
                }
                //actualiza_tabla_disenos();
                if (!m_es_administrador)
                {
                    btn_crear.Enabled = false;
                }

            }
            else
            {
                Response.Redirect("~/Codigo_Fuente/Fronteras/InterfazLogin.aspx");
            }
        }

        /** @brief Método que carga los proyectos existentes en el combo box.
        */
        protected void actualiza_proyectos()
        {
            vacia_proyectos();
            llena_proyectos_disponibles();
        }

        /** @brief Método que vacía el combobox de proyectos.
        */
        protected void vacia_proyectos()
        {
            drop_proyecto.Items.Clear();
        }

        /** @brief Método que llena los proyectos en el combo box.
        */
        protected void llena_proyectos_disponibles()
        {
            DataTable tabla_proyectos = m_controladora_pyp.solicitar_proyectos_disponibles();
            m_tamano_tabla_pyp = tabla_proyectos.Rows.Count;
            m_tabla_proyectos_disponibles = new Object[m_tamano_tabla_pyp, 2];
            for (int i = 0; i < m_tamano_tabla_pyp; ++i)
            {
                m_tabla_proyectos_disponibles[i, 0] = Convert.ToInt32(tabla_proyectos.Rows[i]["id_proyecto"]);
                m_tabla_proyectos_disponibles[i, 1] = tabla_proyectos.Rows[i]["nombre_proyecto"].ToString();
                ListItem item_proyecto = new ListItem();
                item_proyecto.Text = Convert.ToString(m_tabla_proyectos_disponibles[i, 1]);
                item_proyecto.Value = Convert.ToString(m_tabla_proyectos_disponibles[i, 0]);
                drop_proyecto.Items.Add(item_proyecto);
            }
        }

        //actualiza_requerimientos();
        //actualiza_rh();
        //actualiza_tabla_disenos();

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