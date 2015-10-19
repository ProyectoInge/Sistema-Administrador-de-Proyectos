/*
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
        private ControladoraProyectoPruebas m_controladora_pdp;
        private static char m_opcion = 'i'; // i = insertar, m = modificar, e = eliminar

        private static string[,] m_tabla_recursos_disponibles; //posicion: 0 --> username, 1 --> nombre
        private static Object[,] m_tabla_proyectos_disponibles; //posicion: 0 --> id_proyecto, 1 --> nombre proyecto
        private static int m_tamano_tabla_rh;
        private static int m_tamano_tabla_pdp;

        /** @brief Metodo que se llama al cargar la página.
        */
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                m_controladora_rh = new ControladoraRecursosHumanos();
                m_controladora_pdp = new ControladoraProyectoPruebas();
                alerta_error.Visible = false;
                alerta_exito.Visible = false;
                alerta_advertencia.Visible = false;
                drop_proyecto_asociado.Enabled = false;
                drop_rol.Enabled = false;
                activa_desactiva_botones_ime(false);
                mensaje_error_modal.Visible = false;
                mensaje_exito_modal.Visible = false;
                if (m_opcion != 'e')
                {
                    btn_reestablece_contrasena.Visible = false;
                }
                else
                {
                    btn_reestablece_contrasena.Visible = true;
                }

                if (!IsPostBack)
                {
                    actualiza_proyectos();
                    m_opcion = 'i';
                }
                actualiza_tabla_recursos_humanos();
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
            if (validar_campos() == true)
            {
                if (m_opcion != 'e')
                {
                    alerta_exito.Visible = true;
                }
            }
            else
            {
                if (m_opcion != 'e')
                {
                    alerta_error.Visible = true;
                }
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

        // ------------------------------------------------------------------------------------------------------------------------------
        // |                                                Metodos auxiliares de la clase                                              |
        // ------------------------------------------------------------------------------------------------------------------------------

        /** @brief Metodo que actualiza la tabla de proyectos disponibles con la información más reciente.
        */
        private void actualiza_proyectos()
        {
            vacia_proyectos();
            llena_proyectos_disponibles();

        }

        /** @brief Metodo que vacia por completo la tabla de los proyectos disponibles.
        */
        private void vacia_proyectos()
        {
            drop_proyecto_asociado.Items.Clear();
        }

        /** @brief Metodo que se encarga de llenar el comboBox con los proyectos que hay en la base de datos.
        */
        private void llena_proyectos_disponibles()
        {
            DataTable tabla_proyectos = m_controladora_pdp.solicitar_proyectos_disponibles();
            m_tamano_tabla_pdp = tabla_proyectos.Rows.Count;
            m_tabla_proyectos_disponibles = new Object[m_tamano_tabla_pdp, 2];
            for (int i = 0; i < m_tamano_tabla_pdp; ++i)
            {
                m_tabla_proyectos_disponibles[i, 0] = Convert.ToInt32(tabla_proyectos.Rows[i]["id_proyecto"]);
                m_tabla_proyectos_disponibles[i, 1] = tabla_proyectos.Rows[i]["nombre_proyecto"].ToString();
                ListItem item_proyecto = new ListItem();
                item_proyecto.Text = Convert.ToString(m_tabla_proyectos_disponibles[i, 1]);
                item_proyecto.Value = Convert.ToString(m_tabla_proyectos_disponibles[i, 0]);
                drop_proyecto_asociado.Items.Add(item_proyecto);
            }

        }

        /** @brief Metodo que busca en la tabla de [id_proyecto, nombre] por el id de un proyecto.
         * @param string con el nombre del proyecto que va a buscar el id.
         * @return El id del proyecto, -1 si no lo encuentra.
         */
        private int buscar_id_proyecto(string nombre_proyecto)
        {
            int a_retornar = -1;
            bool encontrado = false;
            int index = 0;
            while (index < m_tamano_tabla_pdp && encontrado == false)
            {
                if (m_tabla_proyectos_disponibles[index, 1].ToString().Equals(nombre_proyecto))
                {
                    encontrado = true;
                    a_retornar = (int)m_tabla_proyectos_disponibles[index, 0];
                }
                ++index;
            }
            return a_retornar;
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
            alerta_advertencia.Visible = false;
            m_opcion = 'i';
            activa_desactiva_inputs(true);
            btn_eliminar.CssClass = "btn btn-default";
            btn_crear.CssClass = "btn btn-default active";
            btn_modificar.CssClass = "btn btn-default";
            btn_reestablece_contrasena.Visible = false;
        }

        /** @brief Llena el área de consulta con los recursos humanos que hay en la base de datos.
                   Para esto crea la tabla dinámicamente.
         */
        private void llena_recursos_humanos()
        {
            DataTable tabla_de_datos = m_controladora_rh.solicitar_recursos_disponibles();
            m_tamano_tabla_rh = tabla_de_datos.Rows.Count;
            m_tabla_recursos_disponibles = new string[m_tamano_tabla_rh, 2];
            crea_encabezado_tabla_rh();
            for (int i = 0; i < m_tamano_tabla_rh; ++i)
            {
                TableRow fila = new TableRow();
                TableCell celda_boton = new TableCell();
                TableCell celda_proyecto = new TableCell();
                TableCell celda_rol = new TableCell();
                Button btn = new Button();
                m_tabla_recursos_disponibles[i, 0] = tabla_de_datos.Rows[i]["username"].ToString();
                m_tabla_recursos_disponibles[i, 1] = tabla_de_datos.Rows[i]["nombre"].ToString();
                btn.ID = "btn_lista_" + i.ToString();
                btn.Text = m_tabla_recursos_disponibles[i, 1];
                btn.CssClass = "btn btn-link";
                btn.Click += new EventHandler(btn_lista_rh_click);
                if (tabla_de_datos.Rows[i]["id_proyecto"].ToString() == "")
                {
                    celda_proyecto.Text = "N/A";
                }
                else
                {
                    int id_proyecto_asociado = Convert.ToInt32(tabla_de_datos.Rows[i]["id_proyecto"]);
                    celda_proyecto.Text = drop_proyecto_asociado.Items.FindByValue(Convert.ToString(id_proyecto_asociado)).Text;
                }

                if (tabla_de_datos.Rows[i]["rol"].ToString() == "")
                {
                    celda_rol.Text = "N/A";
                }
                else
                {
                    celda_rol.Text = Convert.ToString(tabla_de_datos.Rows[i]["rol"]);
                }
                celda_boton.Controls.AddAt(0, btn);
                fila.Cells.AddAt(0, celda_boton);
                fila.Cells.AddAt(1, celda_proyecto);
                fila.Cells.AddAt(2, celda_rol);
                tabla_recursos_humanos.Rows.Add(fila);
            }
        }

        /** @brief Metodo que crea el encabezado para la tabla de los recursos humanos.
        */
        private void crea_encabezado_tabla_rh()
        {
            TableHeaderRow header = new TableHeaderRow();
            TableHeaderCell celda_header_nombre = new TableHeaderCell();
            TableHeaderCell celda_header_proyecto = new TableHeaderCell();
            TableHeaderCell celda_header_rol = new TableHeaderCell();
            celda_header_nombre.Text = "Nombre del usuario";
            header.Cells.AddAt(0, celda_header_nombre);
            celda_header_proyecto.Text = "Proyecto asociado";
            header.Cells.AddAt(1, celda_header_proyecto);
            celda_header_rol.Text = "Rol";
            header.Cells.AddAt(2, celda_header_rol);
            tabla_recursos_humanos.Rows.Add(header);
        }

        /** @brief Verifica todos los campos que llena el usuario para comprobar que los datos ingresados son válidos, si no hay problema entonces envía los datos a la controladora y realiza la operación respectiva.
         */
        private bool validar_campos()
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
            input_name.Text = tabla_informacion.Rows[0]["nombre"].ToString();
            input_usuario.Text = username;
            input_cedula.Text = tabla_informacion.Rows[0]["cedula"].ToString();
            input_correo.Text = tabla_informacion.Rows[0]["correo"].ToString();
            input_telefono.Text = tabla_informacion.Rows[0]["telefono"].ToString();
            if (Convert.ToBoolean(tabla_informacion.Rows[0]["es_administrador"]))
            {
                radio_btn_miembro.Checked = false;
                radio_btn_administrador.Checked = true;
                drop_proyecto_asociado.ClearSelection();
                drop_rol.ClearSelection();
            }
            else
            {
                radio_btn_miembro.Checked = true;
                radio_btn_administrador.Checked = false;
                drop_rol.ClearSelection();
                drop_rol.Items.FindByText(Convert.ToString(tabla_informacion.Rows[0]["rol"])).Selected = true;
                drop_proyecto_asociado.ClearSelection();
                drop_proyecto_asociado.Items.FindByValue(Convert.ToString(tabla_informacion.Rows[0]["id_proyecto"])).Selected = true;
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
            while (i < m_tamano_tabla_rh && encontrado == false)
            {
                if (m_tabla_recursos_disponibles[i, 1] == nombre)
                {
                    usuario = m_tabla_recursos_disponibles[i, 0];
                    encontrado = true;

                }
                ++i;
            }
            return usuario;
        }

        /** @brief Metodo que vacia por completo la tabla que muestra los recursos humanos disponibles en la base de datos.
         */
        private void vaciar_recursos_humano()
        {
            tabla_recursos_humanos.Rows.Clear();
        }

        /** @brief Metodo que actualiza la tabla que muestra los recursos humanos disponibles en la base de datos con la información más actualizada.
         */
        private void actualiza_tabla_recursos_humanos()
        {
            vaciar_recursos_humano();
            llena_recursos_humanos();
        }

        /** @brief Metodo que valida los campos que se ocupan para eliminar un recurso humano, si no hay problema entonces lo elimina de la base.
         */
        private bool eliminar_recurso_humano()
        {
            bool a_retornar = false;
            if (input_usuario.Text != "")
            {
                titulo_modal.Text = "¡Atención!";
                cuerpo_modal.Text = " ¿Esta seguro que desea eliminar a " + input_usuario.Text + " del sistema?";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modal_alerta", "$('#modal_alerta').modal();", true);
                upModal.Update();
                a_retornar = true;
            }
            else
            {
                cuerpo_alerta_error.Text = "Es necesario ingresar un nombre de usuario.";
                alerta_error.Visible = false;
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
                                                Object[] datos = new Object[9];
                                                datos[0] = input_usuario.Text;
                                                datos[1] = input_name.Text;
                                                datos[2] = input_correo.Text;
                                                datos[3] = input_telefono.Text;
                                                datos[5] = input_contrasena.Text;
                                                datos[7] = input_cedula.Text;
                                                if (radio_btn_miembro.Checked == true)
                                                {
                                                    datos[6] = false; //no es admi
                                                    datos[4] = buscar_id_proyecto(drop_proyecto_asociado.SelectedItem.Text);
                                                    datos[8] = drop_rol.SelectedItem.Text;
                                                }
                                                else
                                                {
                                                    datos[6] = true; //es admi
                                                    datos[4] = "";  //es admi entonces no tiene proyecto asociado
                                                    datos[8] = "";  //es admi entonces no tiene un rol asociado
                                                }

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
                                            Object[] datos = new Object[9];
                                            datos[0] = input_usuario.Text;
                                            datos[1] = input_name.Text;
                                            datos[2] = input_correo.Text;
                                            datos[3] = input_telefono.Text;
                                            datos[7] = input_cedula.Text;
                                            if (radio_btn_miembro.Checked == true)
                                            {
                                                datos[6] = false;   //no es admi
                                                datos[4] = buscar_id_proyecto(drop_proyecto_asociado.SelectedItem.Text);
                                                datos[8] = drop_rol.SelectedItem.Text;
                                            }
                                            else
                                            {
                                                datos[6] = true; //es admi
                                                datos[4] = "";  //es admi entonces no tiene proyecto asociado
                                                datos[8] = "";  //es admi entonces no tiene un rol asociado
                                            }

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

        /** @brief Evento que ocurre cuando el usuario confirma que quiere eliminar el recurso humano, va y realiza el cambio en la base de datos.
         * @param Los parametros por default de un evento de C#.
         */
        protected void btn_modal_aceptar_Click(object sender, EventArgs e)
        {

            int resultado = m_controladora_rh.eliminar_recurso_humano(input_usuario.Text);
            if (resultado == 0)
            {
                actualiza_tabla_recursos_humanos();
                mensaje_exito_modal.Visible = true;
                upModal.Update();
            }
            else
            {
                mensaje_error_modal.Visible = true;
                upModal.Update();
            }
        }

        /** @brief Evento que ocurre cuando el usuario se quiere devolver del modal de confirmar eliminacion del recurso humano, cierra el modal.
         * @param Los parametros por default de un evento de C#.
         */
        protected void btn_modal_cancelar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modal_alerta", "$('#modal_alerta').modal('hide');", true);
            upModal.Visible = false;
            upModal.Update();
        }

        /** @brief Se activa cuando el usuario escoge la opcion de reestablecer la contrasena, lo envia a la pagina para cambiar de contraseña.
         */
        protected void btn_reestablece_contrasena_Click(object sender, EventArgs e)
        {
            string url = "~/Codigo_Fuente/Fronteras/InterfazReestablecerContrasena.aspx?u=" + input_usuario.Text; //se envia el "username" a la otra vista.
            Response.Redirect(url);
        }
    }
}