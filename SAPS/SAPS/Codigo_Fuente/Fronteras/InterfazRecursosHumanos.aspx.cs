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
        ControladoraRecursosHumanos m_controladora_rh;
        protected void Page_Load(object sender, EventArgs e)
        {
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
            btn_eliminar.Enabled = false;
            btn_modificar.Enabled = false;
            drop_proyecto_asociado.Enabled = false;
            drop_rol.Enabled = false;
            pinta_inputs();
        }

        private void pinta_inputs()
        {
            input_name.BackColor = System.Drawing.Color.White;
            input_correo.BackColor = System.Drawing.Color.White;
            input_telefono.BackColor = System.Drawing.Color.White;
            input_usuario.BackColor = System.Drawing.Color.White;
            input_contrasena.BackColor = System.Drawing.Color.White;
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
            string color_error = "#f2dede";
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
                            if (acierta.Success)    //coincide con la REGEX
                            {

                                if (input_contrasena.Text != "")
                                {
                                    if(radio_btn_administrador.Checked == true || radio_btn_miembro.Checked == true)
                                    {
                                        if (radio_btn_miembro.Checked == true)
                                        {
                                            // Agarro los campos de rol y proyecto
                                        }
                                        else
                                        {
                                            // Solo me interesa que es administrador
                                        }
                                    }
                                    else
                                    {
                                        a_retornar = false;
                                    }

                                }
                                else
                                {
                                    input_contrasena.BackColor = System.Drawing.ColorTranslator.FromHtml(color_error.Trim());
                                    SetFocus(input_contrasena);
                                    a_retornar = false;
                                }
                            }
                            else
                            {
                                input_telefono.BackColor = System.Drawing.ColorTranslator.FromHtml(color_error.Trim());
                                SetFocus(input_telefono);
                                a_retornar = false;
                            }
                        }
                        else
                        {
                            input_telefono.BackColor = System.Drawing.ColorTranslator.FromHtml(color_error.Trim());
                            SetFocus(input_telefono);
                            a_retornar = false;
                        }
                    }
                    else
                    {
                        input_correo.BackColor = System.Drawing.ColorTranslator.FromHtml(color_error.Trim());
                        SetFocus(input_correo);
                        a_retornar = false;
                    }
                }
                else
                {
                    input_usuario.BackColor = System.Drawing.ColorTranslator.FromHtml(color_error.Trim());
                    SetFocus(input_usuario);
                    a_retornar = false;
                }
            }
            else
            {
                input_name.BackColor = System.Drawing.ColorTranslator.FromHtml(color_error.Trim());
                SetFocus(input_name);
                a_retornar = false;
            }
            return a_retornar;
        }

    }
}