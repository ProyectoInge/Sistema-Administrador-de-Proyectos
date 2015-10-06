/*
 * Universidad de Costa Rica
 * Escuela de Ciencias de la Computación e Informática
 * Ingeniería de Software I
 * Sistema Administrador de Proyectos de Software (SAPS)
 * II Semestre 2015
 * --------------------------------------------------------------------------------------------
 * Esta clase frontera se encarga de obtener los datos y los eventos que el usuario selecciona,
 * se lo pasa a la controladora de la clase recurso_humano.
 * --------------------------------------------------------------------------------------------
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAPS.Fronteras
{
    public partial class Recursos_Humanos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            llena_recursos_humanos();

        }

        private void btn_lista_click(object sender, EventArgs e)
        {
            activa_botones_ime();
        }

        protected void btn_Cancelar_Click(object sender, EventArgs e)
        {
            limpia_campos();
        }

        protected void btn_consultar_Click(object sender, EventArgs e)
        {
            activa_botones_ime();
        }

        //Metodos auxiliares de la calse
        private void activa_botones_ime()
        {
            btn_eliminar.Enabled = true;
            btn_modificar.Enabled = true;
        }

        private void limpia_campos()
        {
            radio_btn_miembro.Checked = false;
            radio_btn_administrador.Checked = false;
            input_name.Text = "";
            input_correo.Text = "";
            input_telefono.Text = "";
            input_usuario.Text = "";
            input_contrasena.Text = "";
        }

        private void llena_recursos_humanos()
        {
            // Para llenar la tabla "tabla_consultas" dinámicamente
            for (int i = 0; i < 4; ++i)
            {
                Button btn = new Button();
                btn.ID = "btn_lista_" + i;
                btn.Text = "RH " + i;
                btn.Click += new EventHandler(btn_lista_click);
                btn.CssClass = "list-group-item col-md-8";
                lista_rh.Controls.AddAt(i, btn);
            }
        }
    }
}