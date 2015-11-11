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
using System.Web.Security;

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
            if (!IsPostBack)
            {
                if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                {
                    input_usuario.Text = Request.Cookies["UserName"].Value;
                    input_contrasena.Attributes["value"] = Request.Cookies["Password"].Value;
                }
            }
            HtmlGenericControl nav_bar = (HtmlGenericControl)Page.Master.FindControl("navigation_bar"); //para ocultar el navbar
            HtmlGenericControl cuerpo = (HtmlGenericControl)Page.Master.FindControl("cuerpo");
            cuerpo.Attributes.Add("class", "container-fluid body-content");
            nav_bar.Style.Add("display", "none");
            m_controladora_rh = new ControladoraRecursosHumanos();
            alerta_error.Visible = false;
            link_cerrar_sesion.Visible = false;
            SetFocus(input_usuario);
            if (Request.IsAuthenticated)
                Response.Redirect("Default.aspx");
        }

        /** @brief Evento que se activa cuando el usuario hace click en el boton "login", verifica los datos y autentica al usuario.
         * @param Los parametros por default de un evento de C#.
         */
        protected void btn_login_Click(object sender, EventArgs e)
        {
            if (input_usuario.Text != "")
            {
                if (m_controladora_rh.existe_usuario(input_usuario.Text))
                {
                    if (input_contrasena.Text != "")
                    {
                        if (!m_controladora_rh.consultar_sesion(input_usuario.Text))
                        {
                            int resultado = m_controladora_rh.autenticar(input_usuario.Text, input_contrasena.Text);
                            if (resultado == 0)
                            {
                                if (checkbox_recordarme.Checked)
                                {
                                    Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                                    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
                                }
                                else
                                {
                                    Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                                    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
                                }
                                Response.Cookies["UserName"].Value = input_usuario.Text.Trim();
                                Response.Cookies["Password"].Value = input_contrasena.Text.Trim();
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
                            cuerpo_alerta_error.Text = "Ya existe una sesión iniciada con éste nombre de usuario.";
                            link_cerrar_sesion.Visible = true;
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
                    cuerpo_alerta_error.Text = " El usuario ingresado no existe en el sistema.";
                    alerta_error.Visible = true;
                    SetFocus(input_usuario);
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