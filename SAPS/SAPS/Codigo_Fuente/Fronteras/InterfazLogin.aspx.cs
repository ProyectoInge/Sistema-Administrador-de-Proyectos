/*
 * Universidad de Costa Rica
 * Escuela de Ciencias de la Computación e Informática
 * Ingeniería de Software I
 * Sistema Administrador de Proyectos de Software (SAPS)
 * II Semestre 2015
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAPS.Controladoras;
using System.Web.UI.HtmlControls;

namespace SAPS.Fronteras
{
    /** @brief Clase que se encarga de obtener los datos que ingresa el usuario al hacer "log-in" y se los pasa a la controladora para autenticar los datos.
     */
    public partial class InterfazLogin : System.Web.UI.Page
    {
        //Variable de instancia
        ControladoraRecursosHumanos m_controladora_rh;

        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlGenericControl nav_bar = (HtmlGenericControl)Page.Master.FindControl("navigation_bar"); //para ocultar el navbar
            nav_bar.Visible = false;
            m_controladora_rh = new ControladoraRecursosHumanos();
            alerta_error.Visible = false;
        }

        /** @brief Evento que se activa cuando el usuario hace click en el boton "login", verifica los datos y autentica al usuario.
         * @param Los parametros por default de un evento de C#.
         */
        protected void btn_login_Click(object sender, EventArgs e)
        {
            if(input_usuario.Text != "")
            {
                if(input_contrasena.Text != "")
                {
                    int resultado = m_controladora_rh.autenticar(input_usuario.Text, input_contrasena.Text);
                    if(resultado == 0)
                    {
                        // TO DO --> Registrar la sesion del usuario.
                        Response.Redirect("~/"); // Si el usuario se autentica correctamente, lo dirige a la pantalla de inicio.
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
    }
}