using SAPS.Controladoras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SAPS.Fronteras
{
    public partial class InterfazCerrarSesionRemota : System.Web.UI.Page
    {
        //Variable de instancia
        ControladoraRecursosHumanos m_controladora_rh;
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlGenericControl nav_bar = (HtmlGenericControl)Page.Master.FindControl("navigation_bar"); //para ocultar el navbar
            HtmlGenericControl cuerpo = (HtmlGenericControl)Page.Master.FindControl("cuerpo");
            cuerpo.Attributes.Add("class", "container-fluid body-content");
            nav_bar.Style.Add("display", "none");
            m_controladora_rh = new ControladoraRecursosHumanos();
            alerta_error.Visible = false;
            alerta_exito.Visible = false;
            SetFocus(input_usuario);
            if (Request.IsAuthenticated)
                Response.Redirect("Default.aspx");
        }

        protected void btn_cerrar_sesion_Click(object sender, EventArgs e)
        {
            valida_campos();
        }

        private void valida_campos()
        {
            if (input_usuario.Text != "")
            {
                if (input_contrasena.Text != "")
                {
                    int resultado = m_controladora_rh.autenticar(input_usuario.Text, input_contrasena.Text);
                    if (resultado == 0)
                    {
                        m_controladora_rh.cerrar_sesion(input_usuario.Text);
                        m_controladora_rh.iniciar_sesion(input_usuario.Text);
                        FormsAuthentication.Authenticate(input_usuario.Text, input_contrasena.Text);
                        FormsAuthentication.RedirectFromLoginPage(input_usuario.Text, true);
                    }
                    else
                    {
                        alerta_error.Visible = true;
                        cuerpo_alerta_error.Text = "Los datos ingresados no son válidos.";
                    }

                }
                else
                {
                    alerta_error.Visible = true;
                    cuerpo_alerta_error.Text = "Es necesario que ingrese una contraseña.";
                    SetFocus(input_contrasena);

                }
            }
            else
            {
                alerta_error.Visible = true;
                cuerpo_alerta_error.Text = "Es necesario que ingrese un nombre de usuario.";
                SetFocus(input_usuario);
            }
        }

        protected void btn_regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}