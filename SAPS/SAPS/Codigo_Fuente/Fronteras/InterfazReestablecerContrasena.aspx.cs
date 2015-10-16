using SAPS.Controladoras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAPS.Fronteras
{
    public partial class InterfazReestablecerContrasena : System.Web.UI.Page
    {
        ControladoraRecursosHumanos m_controladora_rh;

        protected void Page_Load(object sender, EventArgs e)
        {
            m_controladora_rh = new ControladoraRecursosHumanos();
            alerta_error.Visible = false;
            alerta_exito.Visible = false;
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Codigo_Fuente/Fronteras/InterfazRecursosHumanos.aspx");
        }

        protected void btn_reestablecer_Click(object sender, EventArgs e)
        {
            if (valida_campos())
            {
                alerta_exito.Visible = true;
            }
            else
            {
                alerta_error.Visible = true;
            }
        }

        private bool valida_campos()
        {
            bool a_retornar = false;
            if (input_usuario.Text != "")
            {
                if(input_vieja_contrasena.Text != "")
                {
                    if(input_nueva_contrasena.Text != "")
                    {
                        int resultado_autenticar = m_controladora_rh.autenticar(input_usuario.Text, input_vieja_contrasena.Text);   //valida que la info sea correcta
                        if(resultado_autenticar != -1)
                        {
                            int resultado_reestablecer = m_controladora_rh.restablecer_contrasena(input_usuario.Text, input_nueva_contrasena.Text); //hace el cambio de contraseña
                            if(resultado_reestablecer != -1)
                            {
                                cuerpo_alerta_exito.Text = " Tuvo éxito al reestablecer la contraseña.";
                                a_retornar = true;
                            }
                            else
                            {
                                cuerpo_alerta_error.Text = " Hubo un error al reestablecer la contraseña, intentelo nuevamente.";
                            }
                        }
                        else
                        {
                            cuerpo_alerta_error.Text = " Los datos de usuario y la contraseña actual no son correctos.";
                        }
                    }
                    else
                    {
                        cuerpo_alerta_error.Text = " Es necesario que ingrese la contraseña nueva.";
                        SetFocus(input_nueva_contrasena);
                    }
                }
                else
                {
                    cuerpo_alerta_error.Text = "Es necesario que ingrese la contraseña actual.";
                    SetFocus(input_vieja_contrasena);
                }
            }
            else
            {
                cuerpo_alerta_error.Text = " Es necesario que ingrese un nombre de usuario.";
                SetFocus(input_usuario);
            }
            return a_retornar;
        }
    }
}