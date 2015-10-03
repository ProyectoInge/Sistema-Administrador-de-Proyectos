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

        private void llena_recursos_humanos()
        {
            // Para llenar la tabla "tabla_consultas" dinámicamente
            for (int i = 0; i < 4; ++i)
            {
                Button btn = new Button();
                btn.ID = "btn_lista_" + i;
                btn.Text = "Opcion" + i;
                btn.Click += new EventHandler(btn_lista_click);
                btn.CssClass = "list-group-item col-md-8";
                lista_rh.Controls.AddAt(i, btn);
            }
        }

        private void btn_lista_click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}