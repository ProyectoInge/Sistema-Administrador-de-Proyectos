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
        private ControladoraRecursosHumanos m_controladora_rh;
        private static string m_nombre_usuario = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            m_controladora_rh = new ControladoraRecursosHumanos();
            m_nombre_usuario = Request.QueryString["u"];
            input_usuario.Text = m_nombre_usuario;
            input_usuario.Enabled = false;
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
                if(input_nueva_contrasena1.Text != "")
                {
                    if(input_nueva_contrasena2.Text != "")
                    {
                        bool resultado_comparacion = input_nueva_contrasena1.Text.Equals(input_nueva_contrasena2.Text);
                        if(resultado_comparacion)
                        {
                            int resultado_reestablecer = m_controladora_rh.restablecer_contrasena(input_usuario.Text, input_nueva_contrasena1.Text); //hace el cambio de contraseña
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
                            cuerpo_alerta_error.Text = " No coinciden las contraseñas ingresadas, vuelva a ingresarlas.";
                            SetFocus(input_nueva_contrasena1);
                        }
                    }
                    else
                    {
                        cuerpo_alerta_error.Text = " Es necesario que ingrese la contraseña dos veces.";
                        SetFocus(input_nueva_contrasena1);
                    }
                }
                else
                {
                    cuerpo_alerta_error.Text = "Es necesario que ingrese la contraseña actual.";
                    SetFocus(input_nueva_contrasena1);
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