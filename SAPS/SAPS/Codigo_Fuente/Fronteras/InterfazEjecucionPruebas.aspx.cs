using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAPS.Fronteras
{
    public partial class InterfazEjecucionPruebas : System.Web.UI.Page
    {
        /** @brief Metodo que se llama al cargar la página.
        */
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                alerta_advertencia.Visible = false;
                alerta_error.Visible = false;
                alerta_exito.Visible = false;
            }
            else
            {
                Response.Redirect("~/Codigo_Fuente/Fronteras/InterfazLogin.aspx");
            }

        }

        protected void btn_modificar_Click(object sender, EventArgs e)
        {
            ///@todo
        }

        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            ///@todo
        }

        protected void btn_crear_Click(object sender, EventArgs e)
        {
            ///@todo
        }

        protected void btn_Aceptar_Click(object sender, EventArgs e)
        {
            ///@todo
        }

        protected void btn_Cancelar_Click(object sender, EventArgs e)
        {
            ///@todo
        }

        protected void btn_agregar_resultado_Click(object sender, EventArgs e)
        {
            ///@todo
        }

        protected void btn_eliminar_resultado_Click(object sender, EventArgs e)
        {
            ///@todo
        }
    }
}