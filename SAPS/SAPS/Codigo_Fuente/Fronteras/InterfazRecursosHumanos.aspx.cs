﻿/*
 * Universidad de Costa Rica
 * Escuela de Ciencias de la Computación e Informática
 * Ingeniería de Software I
 * Sistema Administrador de Proyectos de Software (SAPS)
 * II Semestre 2015
*/

using System;
using System.Web.UI.WebControls;
using SAPS.Controladoras;
using System.Text.RegularExpressions;
using System.Data;
using System.Web.UI;
using System.Windows;
using System.Threading;

namespace SAPS.Fronteras
{
    /** @brief Esta clase frontera se encarga de obtener los datos y los eventos que el usuario selecciona, se lo pasa a la controladora de la clase recurso_humano.
     */
    public partial class Recursos_Humanos : System.Web.UI.Page
    {
        // Variables de instancia
        private ControladoraRecursosHumanos m_controladora_rh;
        private static char m_opcion = 'i'; // i = insertar, m = modificar, e = eliminar
        private static bool m_result_eliminar = false;
        private static bool m_modal_cancelar = false;

        private string[,] m_tabla_resultados; //posicio: 0-> username, 1-> nombre
        private static int m_tamano_tabla;

        //Metodo que se llama al cargar la página
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
            m_controladora_rh = new ControladoraRecursosHumanos();
            alerta_error.Visible = false;
            alerta_exito.Visible = false;
            drop_proyecto_asociado.Enabled = false;
            drop_rol.Enabled = false;
            activa_desactiva_botones_ime(false);
            if (m_opcion == 'i')
            {
                btn_reestablece_contrasena.Visible = false;
            }
            else
            {
                btn_reestablece_contrasena.Visible = true;
            }
            llena_recursos_humanos();
        }
            else
            {
                Response.Redirect("InterfazLogin.aspx");
            }
        }

        /** @brief Evento que se activa cuando el usuario selecciona un elemento del grid de consulta.
         * @param Los parametros por default de un evento de C#.
         */
        private void btn_lista_rh_click(object sender, EventArgs e)
        {
            string nombre_usuario = ((Button)sender).Text;
            string username = buscar_usuario(nombre_usuario);
            llena_informacion_consulta(username);
            activa_desactiva_botones_ime(true);
            activa_desactiva_inputs(false);
        }

        /** @brief Evento que se activa cuando el usuario selecciona el boton de "cancelar".
         * @param Los parametros por default de un evento de C#.
         */
        protected void btn_Cancelar_Click(object sender, EventArgs e)
        {
            limpia_campos();
            drop_proyecto_asociado.Enabled = false;
            drop_rol.Enabled = false;
            btn_reestablece_contrasena.Visible = false;
            activa_desactiva_botones_ime(false);
        }

        /** @brief Habilita los combo box de "proyecto_asociado" y "rol" en la interfaz.
         * @param Los parametros por default de un evento de C#.
         */
        protected void radio_btn_miembro_CheckedChanged(object sender, EventArgs e)
        {
            drop_proyecto_asociado.Enabled = true;
            drop_rol.Enabled = true;
        }

        /** @brief Deshabilita los combo box  de "proyecto_asociado" y "rol" en la interfaz.
         * @param Los parametros por default de un evento de C#.
         */
        protected void radio_btn_administrador_CheckedChanged(object sender, EventArgs e)
        {
            drop_proyecto_asociado.Enabled = false;
            drop_rol.Enabled = false;
        }

        /** @brief Valida los campos y ejecuta la acción seleccionada (Insertar/Modificar/Eliminar)
         * @param Los parametros por default de un evento de C#.
         */
        protected void btn_Aceptar_Click(object sender, EventArgs e)
        {
            if (valida_campos() == true)
            {
                alerta_exito.Visible = true;
            }
            else
            {
                alerta_error.Visible = true;
            }
        }

        /** @brief Evento que se activa cuando el usuario selecciona la opción de "modificar".
         * @param Los parametros por default de un evento de C#.
        */
        protected void btn_modificar_Click(object sender, EventArgs e)
        {
            m_opcion = 'm';
            btn_reestablece_contrasena.Visible = true;
            activa_desactiva_inputs(true);
            if (radio_btn_administrador.Checked == true)
            {
                drop_rol.Enabled = false;
                drop_proyecto_asociado.Enabled = false;
            }
            activa_desactiva_botones_ime(true);
            input_contrasena.Enabled = false;
            btn_eliminar.CssClass = "btn btn-default";
            btn_crear.CssClass = "btn btn-default";
            btn_modificar.CssClass = "btn btn-default active";
        }

        /** @brief Evento que se activa cuando el usuario selecciona la opción de "eliminar".
         * @param Los parametros por default de un evento de C#.
        */
        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            m_opcion = 'e';
            btn_reestablece_contrasena.Visible = false;
            activa_desactiva_inputs(false);
            activa_desactiva_botones_ime(true);
            btn_eliminar.CssClass = "btn btn-default active";
            btn_crear.CssClass = "btn btn-default";
            btn_modificar.CssClass = "btn btn-default";
        }

        /** @brief Evento que se activa cuando el usuario selecciona la opción de "insertar".
         * @param Los parametros por default de un evento de C#.
        */
        protected void btn_crear_Click(object sender, EventArgs e)
        {
            m_opcion = 'i';
            activa_desactiva_inputs(true);
            btn_reestablece_contrasena.Visible = false;
            limpia_campos();
            activa_desactiva_botones_ime(false);
            drop_rol.Enabled = false;
            drop_proyecto_asociado.Enabled = false;
            btn_eliminar.CssClass = "btn btn-default";
            btn_crear.CssClass = "btn btn-default active";
            btn_modificar.CssClass = "btn btn-default ";
        }

        // ------------------------------------------
        // |    Metodos auxiliares de la clase      |
        // ------------------------------------------

        /** @brief Metodo que se encarga de llenar el comboBox con los proyectos que hay en la base de datos.
        */
        private void llena_proyectos()
        {
            // TO DO --> llenar combo box de proyectos
        }

        /** @brief Activa o desactiva los campos de ingresar texto.
         * @param Bool "estado" que indica si activa o desactiva los campos.
         */
        private void activa_desactiva_inputs(bool estado)
        {
            input_cedula.Enabled = estado;
            input_contrasena.Enabled = estado;
            input_correo.Enabled = estado;
            input_name.Enabled = estado;
            input_telefono.Enabled = estado;
            input_usuario.Enabled = estado;
            drop_proyecto_asociado.Enabled = estado;
            drop_rol.Enabled = estado;
            radio_btn_administrador.Enabled = estado;
            radio_btn_miembro.Enabled = estado;
        }

        /** @brief Pone activos los botones de "Eliminar" y "Modificar"
         * @param Bool con el estado de activacion de los botones ime (true/false)
         */
        private void activa_desactiva_botones_ime(bool estado)
        {
            btn_eliminar.Enabled = estado;
            btn_modificar.Enabled = estado;
        }

        /** @brief Se encarga de limpiar los strings que hay en los textbox y de deshabilitar los campos 
         */
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
            drop_proyecto_asociado.Enabled = false;
            drop_rol.Enabled = false;
            alerta_error.Visible = false;
            alerta_exito.Visible = false;
            m_opcion = 'i';
            activa_desactiva_inputs(true);
            btn_eliminar.CssClass = "btn btn-default";
            btn_crear.CssClass = "btn btn-default active";
            btn_modificar.CssClass = "btn btn-default";
            btn_reestablece_contrasena.Visible = false;
        }

        /** @brief Llena el área de consulta con los recursos humanos que hay en la base de datos.
         */
        private void llena_recursos_humanos()
        {
            DataTable tabla_de_datos = m_controladora_rh.solicitar_recursos_disponibles();
            m_tamano_tabla = tabla_de_datos.Rows.Count;
            m_tabla_resultados = new string[m_tamano_tabla, 2];
            for (int i = 0; i < m_tamano_tabla; ++i)
            {
                TableRow fila = new TableRow();
                TableCell celda_boton = new TableCell();
                TableCell celda_proyecto = new TableCell();
                TableCell celda_rol = new TableCell();
                Button btn = new Button();
                m_tabla_resultados[i, 0] = tabla_de_datos.Rows[i]["username"].ToString();
                m_tabla_resultados[i, 1] = tabla_de_datos.Rows[i]["nombre"].ToString();
                btn.ID = "btn_lista_" + i.ToString();
                btn.Text = m_tabla_resultados[i, 1];
                btn.CssClass = "btn btn-link btn-block btn-sm";
                btn.Click += new EventHandler(btn_lista_rh_click);
                if (tabla_de_datos.Rows[i]["id_proyecto"].ToString() == "")
                {
                    celda_proyecto.Text = "N/A";
                }
                else
                {
                    // TO DO --> hacer la consulta con el id y que me de el nombre del proyecto
                    celda_proyecto.Text = tabla_de_datos.Rows[i]["proyecto"].ToString();
                }

                if (tabla_de_datos.Rows[i]["rol"].ToString() == "")
                {
                    celda_rol.Text = "N/A";
                }
                else
                {
                    celda_proyecto.Text = tabla_de_datos.Rows[i]["rol"].ToString();
                }
                celda_boton.Controls.AddAt(0, btn);
                fila.Cells.AddAt(0, celda_boton);
                fila.Cells.AddAt(1, celda_proyecto);
                fila.Cells.AddAt(2, celda_rol);
                tabla_recursos_humanos.Rows.Add(fila);
            }
        }

        /** @brief Verifica todos los campos que llena el usuario para comprobar que los datos ingresados son válidos, si no hay problema entonces envía los datos a la controladora y realiza la operación respectiva.
         */
        private bool valida_campos()
        {
            bool a_retornar = false;
            switch (m_opcion)
            {
                case 'e':
                    a_retornar = eliminar_recurso_humano();
                    break;
                case 'i':
                    a_retornar = insertar_recurso_humano();
                    break;
                case 'm':
                    a_retornar = modificar_recurso_humano();
                    break;
            }
            return a_retornar;
        }

        /** @brief Metodo que sen encarga de obtener la informacion que corresponde a un usuario y desplegarla en los campos.
         * @param String "username" que indica el nombre de usuario del recurso humano que se va a obtener la información.
         */
        private void llena_informacion_consulta(string username)
        {
            DataTable tabla_informacion = m_controladora_rh.consultar_recurso_humano(username);
            if (tabla_informacion.Rows.Count > 0)
            {
                input_name.Text = tabla_informacion.Rows[0]["nombre"].ToString();
                input_usuario.Text = username;
                input_cedula.Text = tabla_informacion.Rows[0]["cedula"].ToString();
                input_correo.Text = tabla_informacion.Rows[0]["correo"].ToString();
                input_telefono.Text = tabla_informacion.Rows[0]["telefono"].ToString();
                if (tabla_informacion.Rows[0]["es_administrador"].Equals(0))
                {
                    radio_btn_miembro.Checked = true;
                }
                else
                {
                    radio_btn_administrador.Checked = true;
                }
            }
            else
            {
                // TO TO
            }

        }

        /** @brief Metodo que busca en la tabla de [username, nombre] el username correspondiente a un nombre.
         * @param String "nombre" que contiene el nombre del cual quiere recuperar el "username"
         * @return String con el nombre de usuario correspondiente al usuario que se consulto.
         */
        private string buscar_usuario(string nombre)
        {
            string usuario = "";
            int i = 0;
            bool encontrado = false;
            while (i < m_tamano_tabla && encontrado == false)
            {
                if (m_tabla_resultados[i, 1] == nombre)
                {
                    usuario = m_tabla_resultados[i, 0];
                    encontrado = true;

                }
                ++i;
            }
            return usuario;
        }

        /** @brief Metodo que vacia por completo la tabla que muestra los recursos humanos disponibles en la base de datos.
         */
        private void vacia_recursos_humano()
        {
            tabla_recursos_humanos.Rows.Clear();
        }

        /** @brief Metodo que actualiza la tabla que muestra los recursos humanos disponibles en la base de datos con la información más actualizada.
         */
        private void actualiza_tabla_recursos_humanos()
        {
            vacia_recursos_humano();
            llena_recursos_humanos();
        }

        /** @brief Metodo que valida los campos que se ocupan para eliminar un recurso humano, si no hay problema entonces lo elimina de la base.
         */
        private bool eliminar_recurso_humano()
        {
            bool a_retornar = false;
                    if (input_usuario.Text != "")
                    {

                        //TO DO --> Confirmacion de borrar el RH!!
                        titulo_modal.Text = "¡Atención!";
                        cuerpo_modal.Text = " ¿Esta seguro que desea eliminar a " + input_usuario.Text + " del sistema?";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modal_alerta", "$('#modal_alerta').modal();", true);
                        upModal.Update();
                        // ** Hay que averiguar como hacer para que se espere al click del modal y que no ejecute las cosas de una vez.
                        if (m_result_eliminar)
                        {
                            cuerpo_alerta_exito.Text = " Se eliminó el recurso humano correctamente.";
                            limpia_campos();
                            actualiza_tabla_recursos_humanos();
                        }
                        else
                        {
                            cuerpo_alerta_error.Text = " Se canceló la eliminación del recurso humano.";
                        }
                        a_retornar = m_result_eliminar;
                    }
                    else
                    {
                        cuerpo_alerta_error.Text = "Es necesario ingresar un nombre de usuario.";
                        alerta_error.Visible = true;
                        SetFocus(input_usuario);
                    }
            return a_retornar;
        }
        /** @brief Metodo que valida los campos que se ocupan para insertar un recurso humano, si no hay problema entonces lo inserta a la base.
        */
        private bool insertar_recurso_humano()
        {
            bool a_retornar = false;
                    if (input_name.Text != "")
                    {
                        if (input_usuario.Text != "")
                        {
                            if (input_correo.Text != "")
                            {
                                if (input_telefono.Text != "")
                                {
                                    Regex revisa_numero = new Regex(@"(\(?\+?\d{3}\))?(2|4|5|6|7|8)\d{3}-?\d{4}", RegexOptions.Compiled | RegexOptions.IgnoreCase);  //REGEX que valida numeros de telefono
                                    Match acierta = revisa_numero.Match(input_telefono.Text);
                                    if (acierta.Success)    //coincide con la REGEX de numeros de telefono
                                    {
                                        if (input_cedula.Text != "")
                                        {
                                            Regex revisa_cedula = new Regex(@"([1-7]|9)-\d{4}-\d{4}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                                            acierta = revisa_cedula.Match(input_cedula.Text);
                                            if (acierta.Success)    //coincide con la REGEX de cedulas
                                            {
                                                if (input_contrasena.Text != "")
                                                {
                                                    if (radio_btn_administrador.Checked == true || radio_btn_miembro.Checked == true)
                                                    {
                                                        if (radio_btn_miembro.Checked == true)
                                                        {
                                                            // TO DO --> agarrar los campos de rol y proyecto
                                                        }
                                                        else
                                                        {
                                                            Object[] datos = new Object[9];
                                                            datos[0] = input_usuario.Text;
                                                            datos[1] = input_name.Text;
                                                            datos[2] = input_correo.Text;
                                                            datos[3] = input_telefono.Text;
                                                            datos[4] = "";  //es admi entonces no tiene proyecto asociado
                                                            datos[5] = input_contrasena.Text;
                                                            datos[6] = true;
                                                            datos[7] = input_cedula.Text;
                                                            datos[8] = "";  //es admi entonces no tiene un rol asociado

                                                            int resultado = m_controladora_rh.insertar_recurso_humano(datos);
                                                            if (resultado == 0)
                                                            {
                                                                cuerpo_alerta_exito.Text = " Se ingresó el recurso humano correctamente.";
                                                                actualiza_tabla_recursos_humanos();
                                                                btn_modificar.Enabled = true;
                                                                a_retornar = true;
                                                            }
                                                            else
                                                            {
                                                                cuerpo_alerta_error.Text = " Hubo un error al ingresar el recurso humano, intentelo nuevamente.";
                                                                a_retornar = false;
                                                            }
                                                        }
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
                                                cuerpo_alerta_error.Text = "Es necesario ingresar un número de cédula válido.";
                                                SetFocus(input_cedula);
                                                a_retornar = false;
                                            }
                                        }
                                        else
                                        {
                                            cuerpo_alerta_error.Text = "Es necesario ingresar un número de cédula.";
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
        /** @brief Metodo que valida los campos necesarios para modificar un recurso humano y si todo esta bien, lo modifica.
         */
        private bool modificar_recurso_humano()
        {
            bool a_retornar = false;
                    if (input_name.Text != "")
                    {
                        if (input_usuario.Text != "")
                        {
                            if (input_correo.Text != "")
                            {
                                if (input_telefono.Text != "")
                                {
                                    Regex revisa_numero = new Regex(@"(\(?\+?\d{3}\))?(2|4|5|6|7|8)\d{3}-?\d{4}", RegexOptions.Compiled | RegexOptions.IgnoreCase);  //REGEX que valida numeros de telefono
                                    Match acierta = revisa_numero.Match(input_telefono.Text);
                                    if (acierta.Success)    //coincide con la REGEX de numeros de telefono
                                    {
                                        if (input_cedula.Text != "")
                                        {
                                            Regex revisa_cedula = new Regex(@"([1-7]|9)-\d{4}-\d{4}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                                            acierta = revisa_cedula.Match(input_cedula.Text);
                                            if (acierta.Success)    //coincide con la REGEX de cedulas
                                            {
                                                if (radio_btn_administrador.Checked == true || radio_btn_miembro.Checked == true)
                                                {
                                                    if (radio_btn_miembro.Checked == true)
                                                    {
                                                        // TO DO --> agarrar los campos de rol y proyecto
                                                    }
                                                    else
                                                    {
                                                        Object[] datos = new Object[9];
                                                        datos[0] = input_usuario.Text;
                                                        datos[1] = input_name.Text;
                                                        datos[2] = input_correo.Text;
                                                        datos[3] = input_telefono.Text;
                                                        datos[4] = "";  //es admi entonces no tiene proyecto asociado
                                                        datos[5] = "";  //como esta modificando, envia la contraseña vacia
                                                        datos[6] = true;
                                                        datos[7] = input_cedula.Text;
                                                        datos[8] = "";  //es admi entonces no tiene un rol asociado

                                                        int resultado = m_controladora_rh.modificar_recurso_humano(datos);
                                                        if (resultado == 0)
                                                        {
                                                            cuerpo_alerta_exito.Text = " Se modificó el recurso humano correctamente.";
                                                            actualiza_tabla_recursos_humanos();
                                                            btn_modificar.Enabled = true;
                                                            a_retornar = true;
                                                        }
                                                        else
                                                        {
                                                            cuerpo_alerta_error.Text = " Hubo un error al modificar el recurso humano, intentelo nuevamente.";
                                                            a_retornar = false;
                                                        }
                                                    }
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
                                                cuerpo_alerta_error.Text = "Es necesario ingresar un número de cédula válido.";
                                                SetFocus(input_cedula);
                                                a_retornar = false;
                                            }
                                        }
                                        else
                                        {
                                            cuerpo_alerta_error.Text = "Es necesario ingresar un número de cédula.";
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

        // TO DO --> revisar esta parte para el modal.
        protected void btn_modal_aceptar_Click(object sender, EventArgs e)
        {

            int resultado = m_controladora_rh.eliminar_recurso_humano(input_usuario.Text);
            // TO DO --> manejar el codigo que devuelve
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modal_alerta", "$('#modal_alerta').modal('hide');", true);
            upModal.Update();
            m_result_eliminar = true;
        }

        protected void btn_modal_cancelar_Click(object sender, EventArgs e)
        {
            m_result_eliminar = false;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modal_alerta", "$('#modal_alerta').modal('hide');", true);
            upModal.Update();
        }

        protected void btn_reestablece_contrasena_Click(object sender, EventArgs e)
        {
            string url = "~/Codigo_Fuente/Fronteras/InterfazReestablecerContrasena.aspx?u=" + input_usuario.Text;
            Response.Redirect(url);
        }
    }
}