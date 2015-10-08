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
using SAPS.Codigo_Fuente.Controladoras;
using System.Text.RegularExpressions;

namespace SAPS.Fronteras
{
    public partial class Recursos_Humanos : System.Web.UI.Page
    {
        private ControladoraRecursosHumanos m_controladora_rh;
        protected void Page_Load(object sender, EventArgs e)
        {
            alerta_error.Visible = false;
            alerta_exito.Visible = false;
            drop_proyecto_asociado.Enabled = false;
            drop_rol.Enabled = false;
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


        protected void radio_btn_miembro_CheckedChanged(object sender, EventArgs e)
        {
            drop_proyecto_asociado.Enabled = true;
            drop_rol.Enabled = true;
        }

        protected void radio_btn_administrador_CheckedChanged(object sender, EventArgs e)
        {
            drop_proyecto_asociado.Enabled = false;
            drop_rol.Enabled = false;
        }

        protected void btn_Aceptar_Click(object sender, EventArgs e)
        {
            if (valida_campos() == true)
            {
                alerta_exito.Visible = true;
            }
            else
            {
                alerta_error.Visible = true;
                /*
                titulo_modal.Text = "Error";
                cuerpo_modal.Text = "Faltan datos que llenar";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modal_alerta", "$('#modal_alerta').modal();", true);
                upModal.Update();*/
            }
        }

        // ------------------------------------------
        // |    Metodos auxiliares de la clase      |
        // ------------------------------------------

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
            input_cedula.Text = "";
            btn_eliminar.Enabled = false;
            btn_modificar.Enabled = false;
            drop_proyecto_asociado.Enabled = false;
            drop_rol.Enabled = false;
            alerta_error.Visible = false;
            alerta_exito.Visible = false;
            pinta_inputs();
        }

        private void pinta_inputs()
        {
            input_name.BackColor = System.Drawing.Color.White;
            input_correo.BackColor = System.Drawing.Color.White;
            input_telefono.BackColor = System.Drawing.Color.White;
            input_usuario.BackColor = System.Drawing.Color.White;
            input_contrasena.BackColor = System.Drawing.Color.White;
            input_cedula.BackColor = System.Drawing.Color.White;
        }
        private void llena_recursos_humanos()
        {
            for (int i = 0; i < 30; ++i)
            {
                TableRow fila = new TableRow();
                TableCell celda = new TableCell();
                Button btn = new Button();
                btn.ID = "btn_lista_" + i.ToString();
                btn.Text = "rh " + i.ToString();
                btn.CssClass = "btn btn-link btn-block";
                btn.Click += new EventHandler(btn_lista_click);
                celda.Controls.AddAt(0, btn);
                fila.Cells.Add(celda);
                tabla_recursos_humanos.Rows.Add(fila);
            }
        }

        private bool valida_campos()
        {
            bool a_retornar = true;
            pinta_inputs();
            if (input_name.Text != "")
            {
                if (input_usuario.Text != "")
                {
                    if (input_correo.Text != "")
                    {
                        if (input_telefono.Text != "")
                        {
                            Regex revisa_numero = new Regex(@"(\(?\+?\d{3}\))?\d{4}-?\d{4}", RegexOptions.Compiled | RegexOptions.IgnoreCase);  //REGEX que valida numeros de telefono
                            Match acierta = revisa_numero.Match(input_telefono.Text);
                            if (acierta.Success)    //coincide con la REGEX de numeros de telefono
                            {
                                if (input_cedula.Text != "")
                                {
                                    Regex revisa_cedula = new Regex(@"([0-7]|9)-\d{4}-\d{4}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                                    acierta = revisa_cedula.Match(input_cedula.Text);
                                    if (acierta.Success)    //coincide con la REGEX de cedulas
                                    {
                                        if (input_contrasena.Text != "")
                                        {
                                            if (radio_btn_administrador.Checked == true || radio_btn_miembro.Checked == true)
                                            {
                                                if (radio_btn_miembro.Checked == true)
                                                {
                                                    // TO DO
                                                    // Agarro los campos de rol y proyecto
                                                }
                                                else
                                                {
                                                    /*
                                                    Object[] datos = new Object[8];
                                                    datos[0] = input_usuario.Text;
                                                    datos[1] = input_name.Text;
                                                    datos[2] = input_correo.Text;
                                                    datos[3] = input_telefono.Text;
                                                    datos[4] = "";  //es admi entonces no tiene proyecto asociado
                                                    datos[5] = input_contrasena.Text;
                                                    datos[6] = true;
                                                    datos[7] = input_cedula.Text;
                                                    datos[8] = "";  //es admi entonces no tiene un rol asociado
                                                    */

                                                    //int resultado = m_controladora_rh.insertar_recurso_humano(datos);
                                                    // TO DO -- manejar el codigo que devuelve
                                                }
                                                cuerpo_alerta_exito.Text = " Su operación no presentó ningún problema.";
                                                a_retornar = true;
                                            }
                                            else
                                            {
                                                cuerpo_alerta_error.Text = "Es necesario seleccionar un perfil de usuario.";
                                                SetFocus(radio_btn_miembro);
                                                a_retornar = false;
                                            }

                                        }
                                        else
                                        {
                                            cuerpo_alerta_error.Text = "Es necesario ingresar una contraseña.";
                                            SetFocus(input_contrasena);
                                            a_retornar = false;
                                        }
                                    }
                                    else
                                    {
                                        cuerpo_alerta_error.Text = "Es necesario ingresar una cédula válida.";
                                        SetFocus(input_cedula);
                                        a_retornar = false;
                                    }
                                }
                                else
                                {
                                    cuerpo_alerta_error.Text = "Es necesario ingresar una cédula.";
                                    SetFocus(input_cedula);
                                    a_retornar = false;
                                }
                            }
                            else
                            {

                                cuerpo_alerta_error.Text = "Es necesario ingresar un número de teléfono válido.";
                                SetFocus(input_telefono);
                                a_retornar = false;
                            }
                        }
                        else
                        {
                            cuerpo_alerta_error.Text = "Es necesario ingresar un número de teléfono.";
                            SetFocus(input_telefono);
                            a_retornar = false;
                        }
                    }
                    else
                    {

                        cuerpo_alerta_error.Text = "Es necesario ingresar un correo electrónico.";
                        SetFocus(input_correo);
                        a_retornar = false;
                    }
                }
                else
                {

                    cuerpo_alerta_error.Text = "Es necesario ingresar un nombre de usuario.";
                    SetFocus(input_usuario);
                    a_retornar = false;
                }
            }
            else
            {
                cuerpo_alerta_error.Text = "Es necesario ingresar un nombre.";
                SetFocus(input_name);
                a_retornar = false;
            }
            return a_retornar;
        }

    }
}