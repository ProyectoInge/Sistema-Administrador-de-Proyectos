﻿/*
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
using System.Text.RegularExpressions;
using System.Data;
using System.Globalization;

namespace SAPS.Fronteras
{
    /** @brief La clase frontera de proyectos de pruebas se encarga de obtener los datos y eventos ingresados por el usuario y enviarlos a la clase controladora proyectos_de_pruebas. 
    */
    public partial class InterfazProyectosDePruebas : System.Web.UI.Page
    {

        private static ControladoraProyectoPruebas m_controladora_pdp;     // Instacia de la clase controladora
        private static bool m_es_administrador;
        private static char m_opcion_tomada = 'i';                          // i= insertar, m= modificar, e= eliminar
        private static int m_tamano_tabla_oficinas;
        private static Object[,] m_tabla_oficinas_disponibles; //posicion: 0 --> id_oficina (int), 1 --> nombre_oficinas (string), 2 --> representante (string)

        private static Object[,] m_tabla_proyectos_disponibles; //posicion: 0 --> id_proyecto (int), 1 --> nombre_proyecto (string)
        private static int m_tamano_tabla_pdp;
        private static int m_id_proyecto_mostrado = 0;

        /** @brief Constructor inicial de la pagina, se encarga de cargar los elementos basicos iniciales de cada seccion.
        */
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                ControladoraRecursosHumanos controladora_rh = new ControladoraRecursosHumanos();
                alerta_error.Visible = false;
                alerta_exito.Visible = false;
                alerta_advertencia.Visible = false;
                alerta_exito_oficina.Visible = false;
                alerta_error_oficina_cuerpo.Visible = false;

                m_controladora_pdp = new ControladoraProyectoPruebas();
                activa_desactiva_botones_ime(false);
                input_manager_office.Enabled = false;
                input_phone1.Enabled = false;
                input_phone2.Enabled = false;
                mensaje_error_modal.Visible = false;
                mensaje_exito_modal.Visible = false;
                // Se llenan las tablas y comboBox
                //llena_disenos_prueba();   // TO DO --> Sprint 2, cuando ya existan diseños de pruebas.
                if (!IsPostBack)
                {
                    actualiza_drop_oficinas();  // ** OJO, actualiza_drop_oficinas se tiene que llamar ANTES que llena_proyectos_de_pruebas SIEMPRE!!
                    m_es_administrador = controladora_rh.es_administrador(Context.User.Identity.Name);
                }
                llena_proyectos_de_pruebas();


            }
            else
            {
                Response.Redirect("~/Codigo_Fuente/Fronteras/InterfazLogin.aspx");
            }

        }

        /** @brief Boton encargado de cancelar todos los cambios realizados por el usuario al proyecto de pruebas.
        * @param Los parametros por default de un evento de C#.
        */
        protected void btn_cancelar_click(object sender, EventArgs e)
        {
            m_opcion_tomada = 'i';
            activa_desactiva_botones_ime(false);
            limpia_campos();
            Response.Redirect("~/Codigo_Fuente/Fronteras/InterfazProyectosDePruebas.aspx");
        }

        /** @brief Boton encargado de cargar los datos de un proyecto de pruebas seleccionado del Grid, en la pantalla principal.
         * @param Los parametros por default de un evento de C#.
        */
        protected void btn_consultar_click(object sender, EventArgs e)
        {
            activa_desactiva_botones_ime(true);
            activa_desactiva_inputs(false);
        }

        /** @brief Boton encargado de validar todas las entradas realizadas por el usuario al proyecto de pruebas.
        * @param Los parametros por default de un evento de C#.
        */
        protected void btn_aceptar_click(object sender, EventArgs e)
        {
            if (valida_campos())
            {
                if (m_opcion_tomada != 'e')
                {
                    alerta_exito.Visible = true;
                    if (m_opcion_tomada == 'i')
                    {
                        activa_desactiva_botones_ime(true);
                    }
                }
            }
            else
            {
                if (m_opcion_tomada != 'e')
                {
                    alerta_error.Visible = true;
                }
            }
        }

        /** @brief Se habilitan las areas especificas del proyecto de pruebas para que el usuario pueda modificar los valores de forma adecuada.
         * @param Los parametros por default de un evento de C#.
        */
        protected void btn_modificar_click(object sender, EventArgs e)
        {
            m_opcion_tomada = 'm';
            activa_desactiva_botones_ime(true);
            activa_desactiva_inputs(true);
            input_asignment_date.Enabled = false;  // No se permite la modificacion de fecha de asignacion
            btn_eliminar.CssClass = "btn btn-default";
            btn_crear.CssClass = "btn btn-default";
            btn_modificar.CssClass = "btn btn-default active";
        }

        /**@brief Evento que se activa cuando el usuario selecciona el boton eliminar
        * @param Los parametros por default de un evento de C#.
        */
        protected void btn_eliminar_click(object sender, EventArgs e)
        {
            m_opcion_tomada = 'e';
            activa_desactiva_botones_ime(true);
            activa_desactiva_inputs(false);
            btn_eliminar.CssClass = "btn btn-default active";
            btn_crear.CssClass = "btn btn-default";
            btn_modificar.CssClass = "btn btn-default";
        }

        /**@brief Se validan los campos para que el usuario ingrese los datos solicitados en el nuevo proyecto.
         * @param Los parametros por default de un evento de C#.
        */
        protected void btn_crear_click(object sender, EventArgs e)
        {
            m_opcion_tomada = 'i';
            activa_desactiva_inputs(true);
            limpia_campos();
            activa_desactiva_botones_ime(false);
            btn_eliminar.CssClass = "btn btn-default";
            btn_crear.CssClass = "btn btn-default active";
            btn_modificar.CssClass = "btn btn-default";
        }


        /** @brief Evento que ocurre cuando el usuario se quiere devolver del modal de confirmar eliminacion del proyecto de pruebas, cierra el modal.
         * @param Los parametros por default de un evento de C#.
         */
        protected void btn_modal_confirmar_cancelar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modal_alerta", "$('#modal_alerta').modal('hide');", true);
            upModal.Visible = false;
            upModal.Update();
        }

        /** @brief Evento que ocurre cuando el usuario confirma que quiere eliminar el proyecto de pruebas, va y realiza el cambio en la base de datos.
         * @param Los parametros por default de un evento de C#.
         */
        protected void btn_modal_confirmar_aceptar_Click(object sender, EventArgs e)
        {

            int id = m_id_proyecto_mostrado;
            int resultado = m_controladora_pdp.eliminar_proyecto(id);
            if (resultado == 0)
            {
                actualiza_proyectos_de_pruebas();
                mensaje_exito_modal.Visible = true;
            }
            else
            {
                mensaje_error_modal.Visible = true;
            }
            upModal.Update();
        }

        /** @brief Despliega un modal donde se le brinda un formulario para crear una nueva oficina.
         * @param Los parametros por default de un evento de C#.
         */
        protected void btn_agregar_oficina_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modal_agregar_oficina", "$('#modal_agregar_oficina').modal();", true);
            upModalOficina.Update();
            actualiza_drop_oficinas();
        }

        /** @brief Esconde el modal de agregar oficina.
         * @param Los parametros por default de un evento de C#.
         */
        protected void btn_modal_cancelar_oficina_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modal_agregar_oficina", "$('#modal_agregar_oficina').modal('hide');", true);
            upModalOficina.Update();
            actualiza_drop_oficinas();
        }

        /** @brief Método que se activa cuando el usuario decide agregar una oficina nueva, realiza la inserción de la oficina a la base de datos.
         * @param Los parametros por default de un evento de C#.
         */
        protected void btn_modal_agregar_oficina_Click(object sender, EventArgs e)
        {
            if (valida_campos_oficina())
            {
                Object[] datos = new Object[5];
                datos[0] = 0;   //El ID se asigna solo por medio de la BD entonces no hay que enviarlo.
                datos[1] = modal_input_nombre_oficina.Text;
                datos[2] = modal_input_representante_oficina.Text;
                datos[3] = modal_input_telefono1.Text;
                datos[4] = modal_input_telefono2.Text;
                int resultado = m_controladora_pdp.insertar_oficina(datos);
                if (resultado == 0)
                {
                    alerta_exito_oficina.Visible = true;
                }
                else
                {
                    alerta_error_oficina.Text = " No fue posible agregar la oficina, intentelo nuevamente.";
                    alerta_error_oficina_cuerpo.Visible = true;
                }
            }
            else
            {
                alerta_error_oficina_cuerpo.Visible = true;
            }
            upModalOficina.Update();
        }

        /** @brief Una vez que el usuario selecciona un proyecto del Grid, se activa el evento btn_lista_click
                    permitiendo que se bloqueen elementos de entrada y se habiliten botones de edicion
         * @param Los parametros por default de un evento de C#.
        */
        protected void btn_lista_pdp_click(object sender, EventArgs e)
        {
            string nombre_proyecto = ((Button)sender).Text;
            int id_proyecto = buscar_id_proyecto(nombre_proyecto);
            m_id_proyecto_mostrado = id_proyecto;
            llena_campos_proyecto(id_proyecto);
            activa_desactiva_botones_ime(true);
            activa_desactiva_inputs(false);
        }

        /** @brief Metodo que se activa cuando el usuario selecciona una oficina del dropdown, llena la informacion correspondiente a esa oficina.
         * @param Los parametros por default de un evento de C#.
        */
        protected void drop_oficina_asociada_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id_oficina_elegida = Convert.ToInt32(((DropDownList)sender).SelectedValue); // Agarra el item seleccionado del dropdown
            llena_campos_oficina(id_oficina_elegida);
        }
        // ------------------------------------------------------------------------------------------------------------------------------
        // |                                                Metodos auxiliares de la clase                                              |
        // ------------------------------------------------------------------------------------------------------------------------------

        /** @brief Metodo realiza una consulta y llena los campos en la interfaz con la informacion del proyecto consultado.
         * @param El id del proyecto a consultar.
         */
        private void llena_campos_proyecto(int id_proyecto)
        {
            DataTable datos_proyecto = m_controladora_pdp.consultar_proyecto(id_proyecto);
            int id_oficina = Convert.ToInt32(datos_proyecto.Rows[0]["id_oficina"]);
            llena_campos_oficina(id_oficina);
            input_system.Text = Convert.ToString(datos_proyecto.Rows[0]["nombre_sistema"]);
            // TO DO --> No esta desplegando correctamente la fecha en el TextBox
            input_start_date.Text = Convert.ToDateTime(datos_proyecto.Rows[0]["fecha_asignacion"]).ToString("yyyy-MM-dd");
            input_asignment_date.Text = Convert.ToDateTime(datos_proyecto.Rows[0]["fecha_asignacion"]).ToString("yyyy-MM-dd");
            try
            {
                input_finish_date.Text = Convert.ToDateTime(datos_proyecto.Rows[0]["fecha_final"]).ToString("yyyy-MM-dd");
            }
            catch (Exception e)
            {
                input_finish_date.Text = "yyyy-MM-dd";
            }
            input_objective.Text = Convert.ToString(datos_proyecto.Rows[0]["obj_general"]);
            input_process.Text = Convert.ToString(datos_proyecto.Rows[0]["nombre_proyecto"]);

            input_asignment_date.DataBind();
            input_finish_date.DataBind();
            input_start_date.DataBind();
        }

        /** @brief Metodo que realiza una consulta y llena los campos en la interfaz con la informacion de la oficina consultada.
         * @param El id de la oficina a consultar.
         */
        private void llena_campos_oficina(int id_oficina)
        {
            DataTable datos_oficina = m_controladora_pdp.consultar_oficina(id_oficina);
            input_manager_office.Text = Convert.ToString(datos_oficina.Rows[0]["nom_representante"]);
            input_phone1.Text = Convert.ToString(datos_oficina.Rows[0]["telefono"]);
            input_phone2.Text = Convert.ToString(datos_oficina.Rows[0]["telefono2"]);
            // Seleccionar el nombre de la oficina en el dropbox
            string nombre_oficina = Convert.ToString(datos_oficina.Rows[0]["nombre_oficina"]);
            drop_oficina_asociada.ClearSelection();
            drop_oficina_asociada.Items.FindByText(nombre_oficina).Selected = true; // Selecciona la oficina correspondiente
        }

        /** @brief Metodo que vacia las oficinas disponibles.
         */
        private void vaciar_oficinas()
        {
            drop_oficina_asociada.Items.Clear();
        }

        /** @brief Actualiza el drop de las oficinas disponibles (la vacia y la vuelve a llenar).
         */
        private void actualiza_drop_oficinas()
        {
            vaciar_oficinas();
            llena_oficinas_disponibles();
        }

        /** @brief Pone activos los botones de "Eliminar" y "Modificar"
        * @param Bool con el estado de activacion de los botones ime (true/false)
        */
        private void activa_desactiva_botones_ime(bool estado)
        {
            btn_modificar.Enabled = estado;
            btn_eliminar.Enabled = estado;
        }

        /** @brief Habilita o deshabilita todas las areas de texto o input dadas al usuario
                   en la interfaz.
        */
        private void activa_desactiva_inputs(bool estado)
        {
            input_system.Enabled = estado;
            input_process.Enabled = estado;
            drop_oficina_asociada.Enabled = estado;
            drop_estado_proyecto.Enabled = estado;
            input_objective.Enabled = estado;
            input_start_date.Enabled = estado;
            input_asignment_date.Enabled = estado;
            input_finish_date.Enabled = estado;
        }

        /**@brief Se encarga de llenar la tabla de disenos de pruebas con todos los disenos asociados a dicho proyecto de pruebas.
        */
        private void llena_disenos_prueba()
        {
            // TO DO --> Sprint 2, cuando ya existan diseños de pruebas.
        }

        /** @brief Metodo que se encarga de llenar el dropbox con las oficinas disponibles.
         */
        private void llena_oficinas_disponibles()
        {
            DataTable tabla_oficinas = m_controladora_pdp.solicitar_oficinas_disponibles();
            m_tamano_tabla_oficinas = tabla_oficinas.Rows.Count;
            m_tabla_oficinas_disponibles = new Object[m_tamano_tabla_oficinas, 3];
            for (int i = 0; i < m_tamano_tabla_oficinas; ++i)
            {
                m_tabla_oficinas_disponibles[i, 0] = Convert.ToInt32(tabla_oficinas.Rows[i]["id_oficina"]);
                m_tabla_oficinas_disponibles[i, 1] = Convert.ToString(tabla_oficinas.Rows[i]["nombre_oficina"]);
                m_tabla_oficinas_disponibles[i, 2] = Convert.ToString(tabla_oficinas.Rows[i]["nom_representante"]);
                ListItem item_oficina = new ListItem();
                item_oficina.Text = Convert.ToString(m_tabla_oficinas_disponibles[i, 1]);
                item_oficina.Value = Convert.ToString(m_tabla_oficinas_disponibles[i, 0]);
                drop_oficina_asociada.Items.Add(item_oficina);
            }
        }

        /** @brief Metodo que se encarga de encontrar la información relacionada al id de oficina.
         * @param El id de la oficina.
         * @return Un vector de string: [0] = nombre oficina, [1] = nombre representante
         */
        private string[,] busca_info_oficina(int id_oficina)
        {
            string[,] a_retornar = new string[1, 2];
            bool encontrado = false;
            int index = 0;
            while (index < m_tamano_tabla_oficinas && encontrado == false)
            {
                if (Convert.ToInt32(m_tabla_oficinas_disponibles[index, 0]).Equals(id_oficina))
                {
                    encontrado = true;
                }
                else
                {
                    ++index;
                }
            }
            if (encontrado)
            {
                a_retornar[0, 0] = Convert.ToString(m_tabla_oficinas_disponibles[index, 1]);
                a_retornar[0, 1] = Convert.ToString(m_tabla_oficinas_disponibles[index, 2]);
            }
            return a_retornar;
        }

        /** @brief Se encarga de llenar la tabla de proyectos de pruebas que contiene a todos los proyectos, dentro de la base de datos.
        **/
        private void llena_proyectos_de_pruebas()
        {
            DataTable tabla_de_datos;
            if (m_es_administrador)
                tabla_de_datos = m_controladora_pdp.solicitar_proyectos_disponibles();
            else
                tabla_de_datos = m_controladora_pdp.consultar_mi_proyecto(Context.User.Identity.Name);

            m_tamano_tabla_pdp = tabla_de_datos.Rows.Count;
            m_tabla_proyectos_disponibles = new Object[m_tamano_tabla_pdp, 2];
            crea_encabezado_tabla_proyectos();
            for (int i = (m_tamano_tabla_pdp - 1); i >= 0; --i)
            {
                TableRow fila = new TableRow();
                TableCell celda_boton = new TableCell();
                TableCell celda_estado = new TableCell();
                TableCell celda_oficina = new TableCell();
                TableCell celda_encargado = new TableCell();
                Button btn = new Button();
                string[,] info_oficina = new string[1, 2];  //la oficina y el representante de la oficina asociada al proyecto
                m_tabla_proyectos_disponibles[i, 0] = Convert.ToInt32(tabla_de_datos.Rows[i]["id_proyecto"]);
                m_tabla_proyectos_disponibles[i, 1] = Convert.ToString(tabla_de_datos.Rows[i]["nombre_proyecto"]);
                //Crea el boton
                btn.ID = Convert.ToString(m_tabla_proyectos_disponibles[i, 0]);
                btn.Text = Convert.ToString(m_tabla_proyectos_disponibles[i, 1]);
                btn.CssClass = "btn btn-link";
                btn.Click += new EventHandler(btn_lista_pdp_click);
                celda_boton.Controls.AddAt(0, btn);
                fila.Cells.AddAt(0, celda_boton);
                celda_estado.Text = Convert.ToString(tabla_de_datos.Rows[i]["estado"]);
                fila.Cells.AddAt(1, celda_estado);
                info_oficina = busca_info_oficina(Convert.ToInt32(tabla_de_datos.Rows[i]["id_oficina"]));
                celda_oficina.Text = info_oficina[0, 0];
                fila.Cells.AddAt(2, celda_oficina);
                celda_encargado.Text = info_oficina[0, 1];
                fila.Cells.AddAt(3, celda_encargado);
                tabla_proyectos_de_pruebas.Rows.Add(fila);
            }
        }

        /** @brief Metodo que crea el encabezado para la tabla de los proyectos.
         */
        private void crea_encabezado_tabla_proyectos()
        {
            TableHeaderRow header = new TableHeaderRow();
            TableHeaderCell celda_header_nombre = new TableHeaderCell();
            TableHeaderCell celda_header_estado = new TableHeaderCell();
            TableHeaderCell celda_header_oficina = new TableHeaderCell();
            TableHeaderCell celda_header_encargado = new TableHeaderCell();
            celda_header_nombre.Text = "Nombre del proyecto";
            header.Cells.AddAt(0, celda_header_nombre);
            celda_header_estado.Text = "Estado del proyecto";
            header.Cells.AddAt(1, celda_header_estado);
            celda_header_oficina.Text = "Oficina asociada";
            header.Cells.AddAt(2, celda_header_oficina);
            celda_header_encargado.Text = "Encargado de la oficina";
            header.Cells.AddAt(3, celda_header_encargado);
            tabla_proyectos_de_pruebas.Rows.Add(header);
        }

        /** @brief Metodo que verifica que los campos ingresados para la oficina sean válidos.
         * @return true si son válidos, false si no.
         */
        private bool valida_campos_oficina()
        {
            bool a_retornar = false;
            if (modal_input_nombre_oficina.Text != "")
            {
                if (modal_input_representante_oficina.Text != "")
                {
                    if (modal_input_telefono1.Text != "" || modal_input_telefono2.Text != "")
                    {
                        Regex revisa_numero = new Regex(@"(\(?\+?\d{3}\))?(2|4|5|6|7|8)\d{3}-?\d{4}", RegexOptions.Compiled | RegexOptions.IgnoreCase);  //REGEX que valida numeros de telefono
                        if (modal_input_telefono1.Text == "")
                        {
                            Match acierta = revisa_numero.Match(modal_input_telefono2.Text);
                            if (acierta.Success)
                            {
                                a_retornar = true;
                            }
                            else
                            {
                                alerta_error_oficina.Text = " El número de teléfono no es válido.";
                                SetFocus(modal_input_telefono2);
                            }
                        }
                        if (modal_input_telefono2.Text == "")
                        {
                            Match acierta = revisa_numero.Match(modal_input_telefono1.Text);
                            if (acierta.Success)
                            {
                                a_retornar = true;
                            }
                            else
                            {
                                alerta_error_oficina.Text = " El número de teléfono no es válido.";
                                SetFocus(modal_input_telefono1);
                            }
                        }
                        else //los dos campos estan llenos
                        {
                            Match acierta1 = revisa_numero.Match(modal_input_telefono1.Text);
                            Match acierta2 = revisa_numero.Match(modal_input_telefono2.Text);
                            if (acierta1.Success && acierta2.Success)
                            {
                                a_retornar = true;
                            }
                            if (acierta1.Success)
                            {
                                alerta_error_oficina.Text = " El número de teléfono no es válido.";
                                SetFocus(modal_input_telefono2);
                            }
                            else
                            {
                                alerta_error_oficina.Text = " El número de teléfono no es válido.";
                                SetFocus(modal_input_telefono1);
                            }
                        }
                    }
                    else
                    {
                        alerta_error_oficina.Text = " Es necesario que ingrese al menos un número de teléfono.";
                        SetFocus(modal_input_telefono1);
                    }
                }
                else
                {
                    alerta_error_oficina.Text = " Es necesario que ingrese un nombre para el representante.";
                    SetFocus(modal_input_representante_oficina);
                }
            }
            else
            {
                alerta_error_oficina.Text = " Es necesario que ingrese un nombre de oficina.";
                SetFocus(modal_input_nombre_oficina);
            }
            return a_retornar;
        }

        /** @brief Metodo encargado de retornar todos los espacios e ingresos del sistema a su estado
                    original. Incluyendo ademas botones y eventos.
        */
        private void limpia_campos()
        {
            input_system.Text = "";
            input_process.Text = "";
            input_phone1.Text = "";
            input_phone2.Text = "";
            input_manager_office.Text = "";
            input_objective.Text = "";
            input_asignment_date.Text = "";
            input_finish_date.Text = "";
            input_start_date.Text = "";
            m_opcion_tomada = 'i';
            activa_desactiva_inputs(true);
            btn_eliminar.CssClass = "btn btn-default";
            btn_crear.CssClass = "btn btn-default active";
            btn_modificar.CssClass = "btn btn-default";
            alerta_advertencia.Visible = false;
            alerta_error.Visible = false;
            alerta_exito.Visible = false;
            alerta_exito_oficina.Visible = false;
            alerta_error_oficina_cuerpo.Visible = false;
        }

        /** @brief Metodo que busca el id relacionado al nombre de una oficina.
         * @param El nombre de la oficina a consultar.
         * @return El id de la oficina.
         */
        private int busca_id_oficina(string nombre_oficina)
        {
            int id = -1;
            int index = 0;
            bool encontrado = false;
            while (index < m_tamano_tabla_oficinas && encontrado == false)
            {
                if (Convert.ToString(m_tabla_oficinas_disponibles[index, 1]).Equals(nombre_oficina))
                {
                    id = Convert.ToInt32(m_tabla_oficinas_disponibles[index, 0]);
                    encontrado = true;
                }
                ++index;
            }
            return id;
        }

        /** @brief Se validan todos los campos en los cuales el usuario puede ingresar datos, si existen errores, se notifica al usuario.
        */
        private bool valida_campos()
        {
            bool respuesta = false;

            switch (m_opcion_tomada)
            {
                case 'i':
                    respuesta = insertar_proyecto();
                    break;
                case 'm':
                    respuesta = modificar_proyecto();
                    break;
                case 'e':
                    respuesta = eliminar_proyecto();
                    break;
            }
            return respuesta;
        }

        /** @brief Se validan los datos ingresados por el usuario para el nuevo proyecto de pruebas, se envian los mismos a la controladora de base de datos.
        */
        private bool insertar_proyecto()
        {
            bool respuesta = true;                                      // Bandera especifica que indica el exito o fallo de la insercion
            if (input_process.Text != "")
            {

                if (input_system.Text != "")
                {

                    if (input_start_date.Text != "")
                    {

                        if (input_asignment_date.Text != "")
                        {
                            if (drop_estado_proyecto.Text != "")
                            {

                                if (drop_oficina_asociada.Text != "")
                                {

                                    if (input_objective.Text != "")
                                    {
                                        Object[] datos = new Object[9];                                 // En la insercion de proyecto, aun no se posee el id del mismo,
                                        datos[0] = -1;                                                  // este se genera en la base de datos por lo que se envia un -1.
                                        datos[1] = Convert.ToInt32(drop_oficina_asociada.SelectedValue);
                                        datos[2] = input_system.Text;
                                        datos[3] = drop_estado_proyecto.SelectedItem.Text;
                                        datos[4] = input_objective.Text;
                                        datos[5] = input_process.Text;
                                        datos[6] = DateTime.Parse(input_start_date.Text);
                                        datos[7] = DateTime.Parse(input_asignment_date.Text);
                                        if (input_finish_date.Text == "")
                                        {
                                            datos[8] = DBNull.Value;
                                        }
                                        else
                                        {
                                            datos[8] = DateTime.Parse(input_finish_date.Text);
                                        }

                                        int resultado = m_controladora_pdp.insertar_proyecto(datos);
                                        if (resultado == 0)
                                        {
                                            cuerpo_alerta_exito.Text = " Se ha insertado un nuevo proyecto correctamente.";
                                            actualiza_proyectos_de_pruebas();
                                        }
                                        else
                                        {
                                            cuerpo_alerta_error.Text = " No se logró insertar el proyecto, intente nuevamente.";
                                            respuesta = false;
                                        }

                                    }// Objetivo
                                    else
                                    {
                                        cuerpo_alerta_error.Text = " Es necesario ingresar un objetivo.";
                                        SetFocus(input_objective);
                                        respuesta = false;
                                    }
                                }//Oficina asociada
                                else
                                {
                                    cuerpo_alerta_error.Text = " Es necesario ingresar una oficina asociada.";
                                    SetFocus(drop_oficina_asociada);
                                    respuesta = false;
                                }
                            }// Estado de proyecto
                            else
                            {
                                cuerpo_alerta_error.Text = " Es necesario ingresar un estado para el proyecto.";
                                SetFocus(drop_estado_proyecto);
                                respuesta = false;
                            }
                        }// Fecha de asignacion
                        else
                        {
                            cuerpo_alerta_error.Text = " Es necesario ingresar una fecha de asignación del proyecto.";
                            SetFocus(input_asignment_date);
                            respuesta = false;
                        }
                    }// Fecha de inicio
                    else
                    {
                        cuerpo_alerta_error.Text = " Es necesario ingresar una fecha de inicio del proyecto.";
                        SetFocus(input_start_date);
                        respuesta = false;
                    }
                }// Nombre de sistema
                else
                {
                    cuerpo_alerta_error.Text = " Es necesario ingresar un nombre del sistema.";
                    SetFocus(input_system);
                    respuesta = false;
                }
            }// Nombre de proyecto
            else
            {
                cuerpo_alerta_error.Text = " Es necesario ingresar un nombre para el proyecto.";
                SetFocus(input_process);
                respuesta = false;
            }
            return respuesta;
        }

        /**@brief Se confirma que el proyecto a eliminar exista y se procede con la indicacion a la controladora de base de datos para que lo elimine.
        */
        private bool eliminar_proyecto()
        {
            bool respuesta = true;                                      // Bandera especifica que indica el exito o fallo de la eliminacion
            if (input_process.Text != "")
            {
                titulo_modal.Text = "¡Atención!";
                cuerpo_modal.Text = " ¿Esta seguro que desea eliminar a " + input_process.Text + " del sistema?";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modal_alerta", "$('#modal_alerta').modal();", true);
                upModal.Update();
            }
            else
            {
                cuerpo_alerta_error.Text = " Ingrese un nombre de proyecto de pruebas válido.";
                SetFocus(input_process.Text);
                respuesta = false;
            }
            return respuesta;
        }

        /**@brief Se valida que los nuevos datos ingresados por el usuario para el proyecto de pruebas sean validos.
        */
        private bool modificar_proyecto()
        {
            bool respuesta = true;                                      // Bandera especifica que indica el exito o fallo de la modificacion
            if (input_process.Text != "")
            {

                if (input_system.Text != "")
                {

                    if (input_start_date.Text != "")
                    {

                        if (input_asignment_date.Text != "")
                        {

                            if (input_finish_date.Text != "")
                            {

                                if (drop_estado_proyecto.Text != "")
                                {

                                    if (drop_oficina_asociada.Text != "")
                                    {

                                        if (input_objective.Text != "")
                                        {
                                            Object[] datos = new Object[9];
                                            datos[0] = m_id_proyecto_mostrado;
                                            datos[1] = busca_id_oficina(drop_oficina_asociada.SelectedItem.Text);
                                            datos[2] = input_system.Text;
                                            datos[3] = drop_estado_proyecto.SelectedItem.Text;
                                            datos[4] = input_objective.Text;
                                            datos[5] = input_process.Text;
                                            datos[6] = input_start_date.Text;
                                            datos[7] = input_asignment_date.Text;
                                            datos[8] = input_finish_date.Text;

                                            int resultado = m_controladora_pdp.modificar_proyecto(datos);
                                            if (resultado == 0)
                                            {
                                                cuerpo_alerta_exito.Text = " Se ha modificado el proyecto correctamente.";
                                                actualiza_proyectos_de_pruebas();
                                            }
                                            else
                                            {
                                                cuerpo_alerta_exito.Text = " No se ha modificado el proyecto correctamente.";
                                            }

                                        }// Objetivo
                                        else
                                        {
                                            cuerpo_alerta_error.Text = " Es necesario ingresar un objetivo.";
                                            SetFocus(input_objective);
                                            respuesta = false;
                                        }
                                    }//Oficina asociada
                                    else
                                    {
                                        cuerpo_alerta_error.Text = " Es necesario ingresar una oficina asociada.";
                                        SetFocus(drop_oficina_asociada);
                                        respuesta = false;
                                    }
                                }// Estado de proyecto
                                else
                                {
                                    cuerpo_alerta_error.Text = " Es necesario ingresar un estado para el proyecto.";
                                    SetFocus(drop_estado_proyecto);
                                    respuesta = false;
                                }
                            }// Fecha de finalizacion
                            else
                            {
                                cuerpo_alerta_error.Text = " Es necesario ingresar una fecha de finalización del proyecto.";
                                SetFocus(input_finish_date);
                                respuesta = false;
                            }
                        }// Fecha de asignacion
                        else
                        {
                            cuerpo_alerta_error.Text = " Es necesario ingresar una fecha de asignación del proyecto.";
                            SetFocus(input_asignment_date);
                            respuesta = false;
                        }
                    }// Fecha de inicio
                    else
                    {
                        cuerpo_alerta_error.Text = " Es necesario ingresar una fecha de inicio del proyecto.";
                        SetFocus(input_start_date);
                        respuesta = false;
                    }
                }// Nombre de sistema
                else
                {
                    cuerpo_alerta_error.Text = " Es necesario ingresar un nombre de sistema.";
                    SetFocus(input_system);
                    respuesta = false;
                }
            }// Nombre de proyecto
            else
            {
                cuerpo_alerta_error.Text = " Es necesario ingresar un nombre para el proyecto.";
                SetFocus(input_process);
                respuesta = false;
            }
            return respuesta;
        }

        /**@brief Metodo que recorre la tabla de resultados buscando el id asociado a un nombre de proyecto de pruebas.
        */
        private int buscar_id_proyecto(string nombre_proyecto)
        {
            int id = -1;
            bool encontrado = false;
            for (int i = 0; i < m_tamano_tabla_pdp && encontrado == false; ++i)
            {
                if (Convert.ToString(m_tabla_proyectos_disponibles[i, 1]).Equals(nombre_proyecto))
                {
                    id = Convert.ToInt32(m_tabla_proyectos_disponibles[i, 0]);
                    encontrado = true;
                }
            }
            return id;
        }

        /**@brief Metodo encargado de actualizar el Grid de proyectos de pruebas con la nueva informacion.
        */
        private void actualiza_proyectos_de_pruebas()
        {
            vaciar_proyectos();
            llena_proyectos_de_pruebas();
        }

        /** @brief Metodo que vacia por completo la tabla que muestra los proyectos disponibles en la base de datos.
        */
        private void vaciar_proyectos()
        {
            tabla_proyectos_de_pruebas.Rows.Clear();
        }
    }
}