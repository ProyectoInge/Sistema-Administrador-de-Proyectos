using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAPS.Controladoras;
using System.Data;
using System.Drawing;

namespace SAPS.Fronteras
{
    public partial class InterfazEjecucionPruebas : System.Web.UI.Page
    {
        ///Variables de instancia
        private static ControladoraEjecuciones m_controladora_ep;
        private static char m_opcion = 'i';
        private static int[] m_llave_ejecucion; //posiciones: 0 - num_ejecucion, 1 - id_diseno

        private static bool m_es_administrador;


        /** @brief Metodo que se llama al cargar la página.
        */
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.Attributes.Add("enctype", "multipart/form-data");
            if (Request.IsAuthenticated)
            {
                m_controladora_ep = new ControladoraEjecuciones();
                m_opcion = 'i';
                m_llave_ejecucion = new int[2] { -1, -1 };
                alerta_advertencia.Visible = false;
                alerta_error.Visible = false;
                alerta_exito.Visible = false;
                alerta_error_archivo.Visible = false;

                if (!IsPostBack)
                {

                    m_es_administrador = m_controladora_ep.es_administrador(Context.User.Identity.Name);
                    actualiza_disenos();
            }
                actualiza_resultados();
            }
            else
            {
                Response.Redirect("~/Codigo_Fuente/Fronteras/InterfazLogin.aspx");
            }

        }


        /** @brief Método que activa o desactiva todos los botones de ingresar, modificar y eliminar.
        * @param bool que indica si se desea activar o desactivar todos los campos.
        */
        protected void activa_desactiva_botones_ime(bool v)
        {
            btn_crear.Enabled = v;
            btn_modificar.Enabled = v;
            btn_eliminar.Enabled = v;
        }

        /** @brief Método que activa o desactiva todos los espacios de ingreso de datos.
        * @param bool que indica si se desea activar o desactivar todos los campos.
        */
        protected void activa_desactiva_inputs(bool v)
        {
            drop_disenos_disponibles.Enabled = v;
            tabla_resultados.Enabled = v;
            drop_rh_disponibles.Enabled = v;
            input_fecha.Enabled = v;
            input_incidentes.Enabled = v;
            tabla_ejecuciones.Enabled = v;
        }

        /**@brief Metodo encargado de activar la funcionalidad para modificar una ejecucion de pruebas
        **/
        protected void btn_modificar_Click(object sender, EventArgs e)
        {
            m_opcion = 'm';
            btn_crear.CssClass = "btn btn-default active";
            btn_modificar.CssClass = "btn btn-default";
            btn_eliminar.CssClass = "btn btn-default";
            activa_desactiva_inputs(true);
            activa_desactiva_botones_ime(false);
            btn_modificar.Enabled = true;

        }

        /** @brief Método que se activa al seleccionar el botón eliminar de los botones de IME
        * @param parámetros por defecto de ASP
        */
        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            ///@todo
            m_opcion = 'e';
            btn_crear.CssClass = "btn btn-default active";
            btn_modificar.CssClass = "btn btn-default";
            btn_eliminar.CssClass = "btn btn-default";
            activa_desactiva_inputs(false);
        }

        protected void btn_crear_Click(object sender, EventArgs e)
        {
            ///@todo
        }

        /** @brief Método que se activa al seleccionar el botón Aceptar, debe distinguir sobre cual funcionalidad de IME se trata
        * @param parámetros por defecto de ASP
        */
        protected void btn_Aceptar_Click(object sender, EventArgs e)
        {
            alerta_error.Visible = false;
            switch (m_opcion)
            {
                case 'i':
                    ///@todo
                    break;

                case 'e':
                    eliminar_ejecucion();
                    break;

                case 'm':
                    modificar_ejecucion();                    
                    break;          
                default:
                    cuerpo_alerta_error.Text = " Se presentó un problema al procesar su solicitud, intente nuevamente.";
                    alerta_error.Visible = true;
                    break;
            }
        }

        private bool modificar_ejecucion()
        {
            bool respuesta = false;                                      // Bandera especifica que indica el exito o fallo de la modificacion

            if (drop_disenos_disponibles.Text != "")
            {
                if (input_ambiente_diseno.Text != "")
                {

                    if (input_procedimiento_diseno.Text != "")
                    {
                        if (input_criterios_aceptacion_diseno.Text != "")
                        {

                            if (drop_rh_disponibles.Text != "")
                            {

                                if (input_fecha.Text != "")
                                {

                                    if (label_incidentes.Text != "")
                                    {
                                        Object[] datos = new Object[5];
                                        //datos[0] = Numero de ejecucion int ;
                                        datos[1] = drop_rh_disponibles.Text;
                                        datos[2] = Convert.ToInt32(drop_disenos_disponibles.Text);
                                        datos[3] = Convert.ToDateTime(input_fecha.Text);
                                        datos[4] = label_incidentes.Text;

                                        respuesta = true;                                               // La insercion de la ejecucion es valida, pero aun no se ingresa
                                    }                                                                   // Es necesario verificar los resultados de pruebas                                    
                                    else
                                    {
                                        cuerpo_alerta_error.Text = "Debe ingresar una fecha de ejecución.";
                                        SetFocus(input_fecha);
                                        respuesta = false;
                                    }

                                }
                                else {
                                    cuerpo_alerta_error.Text = "Debe ingresar una fecha de ejecución.";
                                    SetFocus(input_fecha);
                                    respuesta = false;
                                }

                            }
                            else {
                                cuerpo_alerta_error.Text = "Debe insertar un responsable asociado.";
                                SetFocus(drop_rh_disponibles);
                                respuesta = false;
                            }

                        }
                        else {
                            cuerpo_alerta_error.Text = "Debe insertar Criterios de Aceptación.";
                            SetFocus(input_criterios_aceptacion_diseno);
                            respuesta = false;
                        }
                    }
                    else {
                        cuerpo_alerta_error.Text = "Debe insertar los datos de Procedimiento";
                        SetFocus(input_procedimiento_diseno);
                        respuesta = false;
                    }

                }
                else {
                    cuerpo_alerta_error.Text = "Debe insertar los datos de Ambiente.";
                    SetFocus(input_ambiente_diseno);
                    respuesta = false;
                }

            }
            else {
                cuerpo_alerta_error.Text = "Debe seleccionar un diseño asociado.";
                SetFocus(drop_disenos_disponibles);
                respuesta = false;
            }


            // Seccion que verifica si la lista de resultados no posee errores

            if (respuesta) {                            // Verificados los datos de ejecucion, se verifican los de resultados

            }




            return respuesta;
        }

        protected void btn_Cancelar_Click(object sender, EventArgs e)
        {
            m_opcion = 'i';
            activa_desactiva_botones_ime(false);
            //limpiar los campos
            Response.Redirect("~/Codigo_Fuente/Fronteras/InterfazEjecucionPruebas.aspx");

        }


        protected void btn_agregar_img_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modal_imagen", "$('#modal_imagen').modal();", true);
            upModalImagen.Update();
        }

        /** @brief Método que se encarga de hacer los pasos necesarios para eliminar una ejecucion
        *   @return true si fue exitoso, false si no.
        */
        private bool eliminar_ejecucion()
        {
            bool a_retornar = false;
            if (m_llave_ejecucion[0] != -1 && m_llave_ejecucion[1] != -1)
            {
                cuerpo_modal.Text = " ¿Esta seguro que desea eliminar la ejecución del sistema?";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modal_alerta", "$('#modal_alerta').modal();", true);
                upModal.Update();
                a_retornar = true;
            }
            else
            {
                cuerpo_alerta_error.Text = "No se ha seleccionado ningúna ejecución.";
            }
            return a_retornar;
        }

        /** @brief Método que se activa al seleccionar el botón aceptar del modal de eliminar ejecucion
        * @param parámetros por defecto de ASP
        */
        protected void btn_modal_aceptar_Click(object sender, EventArgs e)
        {
            int resultado = m_controladora_ep.eliminar_ejecucion(m_llave_ejecucion[1], m_llave_ejecucion[0]);
            Response.Redirect("~/Codigo_Fuente/Fronteras/InterfazEjecucionPruebas.aspx");
        }

        /** @brief Método que se activa al seleccionar el botón cancelar del modal de eliminar ejecucion
        * @param parámetros por defecto de ASP
        */
        protected void btn_modal_cancelar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modal_alerta", "$('#modal_alerta').modal('hide');", true);
            upModal.Visible = false;
            upModal.Update();
            Response.Redirect("~/Codigo_Fuente/Fronteras/InterfazEjecucionPruebas.aspx");
        }

        protected void btn_agregar_resultado_Click(object sender, EventArgs e)
        {
            ///@todo
        }

        protected void btn_eliminar_resultado_Click(object sender, EventArgs e)
        {
            ///@todo sacar el num de resultado
            int num_resultado = 0;
            m_controladora_ep.eliminar_resultado(m_llave_ejecucion[1], m_llave_ejecucion[0], num_resultado);
        }

        /** @brief Método que actualiza el combobox con los diseños disponibles en el sistema
         */
        private void actualiza_disenos()
        {
            vacia_disenos();
            llena_disenos();
        }

        /** @brief Método que vacia el combobox de los diseños disponibles.
         */
        private void vacia_disenos()
        {
            drop_disenos_disponibles.Items.Clear();
        }

        /** @brief Método que llena el combobox con los diseños disponibles en el sistema.
         */
        private void llena_disenos()
        {
            DataTable disenos_disponibles = null;
            if (m_es_administrador)
            {
                // Como soy administrador, puedo ver todos los diseños que hay en el sistema.
                disenos_disponibles = m_controladora_ep.solicitar_disenos_disponibles();
            }
            else
            {
                ///@todo Si soy un usuario normal, solo puedo ver los diseños que tiene asociados el proyecto al que pertenezco.
            }

            ListItem item_tmp = new ListItem();
            item_tmp.Text = "-Seleccione un diseño-";
            item_tmp.Value = "";
            drop_disenos_disponibles.Items.Add(item_tmp);

            for (int i = 0; i < disenos_disponibles.Rows.Count; ++i)
            {
                item_tmp = new ListItem();
                item_tmp.Text = disenos_disponibles.Rows[i]["nombre_diseno"].ToString();
                item_tmp.Value = disenos_disponibles.Rows[i]["id_diseno"].ToString();
                drop_disenos_disponibles.Items.Add(item_tmp);
            }
        }

        /** @brief Evento que se activa cuando se selecciona un nuevo elemento del combobox de los diseños disponibles.
         * @param Los parametros por defecto de un evento de ASP.
         */
        protected void drop_disenos_disponibles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drop_disenos_disponibles.SelectedItem.Value != "")
            {
                int id_diseno_seleccionado = Convert.ToInt32(drop_disenos_disponibles.SelectedItem.Value);
                m_llave_ejecucion[1] = id_diseno_seleccionado;
                llena_info_diseno(id_diseno_seleccionado);
            }

        }

        /** @brief Método que se encarga de llenar la informacion del diseño que se seleccionó.
         */
        private void llena_info_diseno(int id_diseno)
        {
            DataTable info_diseno = m_controladora_ep.consultar_diseno(id_diseno);
            if (info_diseno.Rows.Count > 0)
            {
                input_ambiente_diseno.Text = info_diseno.Rows[0]["ambiente"].ToString();
                input_criterios_aceptacion_diseno.Text = info_diseno.Rows[0]["criterio_aceptacion"].ToString();
                ///@todo Llenar el procedimiento del diseño
    }
}

        /** @brief Método que actualiza la tabla donde estan los resultados de la ejecucion.
         */
        private void actualiza_resultados()
        {
            vacia_resultados();
            llena_resultados();
        }

        /** @brief Método que vacia la tabla donde estan los resultados de la ejecución.
         */
        private void vacia_resultados()
        {
            tabla_ejecuciones.Rows.Clear();
        }

        /** @brief Método que llena la tabla donde estan los resultados de la ejecución.
         */
        private void llena_resultados()
        {
            llena_encabezado_tabla_resultados();
            int num_secuencia = tabla_ejecuciones.Rows.Count;
            llena_fila_inputs(num_secuencia);
        }

        /** @brief Método que crea la fila de la tabla de resultados donde se ingresan datos.
         * @param El número de secuencia por el cual va la lista de los resultados.
        */
        private void llena_fila_inputs(int num_secuencia)
        {
            TableRow fila = new TableRow();
            TableCell celda_tmp = new TableCell();
            DropDownList drop_tmp = new DropDownList();
            ListItem item_tmp = new ListItem();
            TextBox entrada_tmp = new TextBox();
            ///@todo Como agregar imágenes

            celda_tmp.Text = (num_secuencia + 1).ToString();
            fila.Cells.AddAt(0, celda_tmp);

            //Llena y agrega el primer DropDown (Estado)
            #region Creación DropDown "estado"
            celda_tmp = new TableCell();
            drop_tmp = new DropDownList();
            drop_tmp.CssClass = "form-control";

            item_tmp = new ListItem();
            item_tmp.Text = "Satisfactoria";
            item_tmp.Value = "Satisfactoria";
            drop_tmp.Items.Add(item_tmp);

            item_tmp = new ListItem();
            item_tmp.Text = "Fallida";
            item_tmp.Value = "Fallida";
            drop_tmp.Items.Add(item_tmp);

            item_tmp = new ListItem();
            item_tmp.Text = "Pendiente";
            item_tmp.Value = "Pendiente";
            drop_tmp.Items.Add(item_tmp);

            item_tmp = new ListItem();
            item_tmp.Text = "Cancelada";
            item_tmp.Value = "Cancelada";
            drop_tmp.Items.Add(item_tmp);

            celda_tmp.Controls.Add(drop_tmp);
            fila.Cells.AddAt(1, celda_tmp);
            #endregion

            //Llena y crea el segundo DropDown (tipo de no conformidad)
            #region Creación Dropdown "tipo no conformidad"
            celda_tmp = new TableCell();
            drop_tmp = new DropDownList();
            drop_tmp.CssClass = "form-control";

            item_tmp = new ListItem();
            item_tmp.Text = "No aplica";
            item_tmp.Value = "No aplica";
            drop_tmp.Items.Add(item_tmp);

            item_tmp = new ListItem();
            item_tmp.Text = "Funcionalidad";
            item_tmp.Value = "Funcionalidad";
            drop_tmp.Items.Add(item_tmp);

            item_tmp = new ListItem();
            item_tmp.Text = "Validación";
            item_tmp.Value = "Validación";
            drop_tmp.Items.Add(item_tmp);

            item_tmp = new ListItem();
            item_tmp.Text = "Opciones que no funcionan";
            item_tmp.Value = "Opciones que no funcionan";
            drop_tmp.Items.Add(item_tmp);

            item_tmp = new ListItem();
            item_tmp.Text = "Errores de usabilidad";
            item_tmp.Value = "Errores de usabilidad";
            drop_tmp.Items.Add(item_tmp);

            item_tmp = new ListItem();
            item_tmp.Text = "Excepciones";
            item_tmp.Value = "Excepciones";
            drop_tmp.Items.Add(item_tmp);

            celda_tmp.Controls.Add(drop_tmp);
            fila.Cells.AddAt(2, celda_tmp);
            #endregion

            //Llenado y creación del DropDown (ID caso de prueba)
            #region Creación DropDown "ID caso de prueba"
            DataTable casos_disponibles = m_controladora_ep.solicitar_casos_asociados_diseno(m_llave_ejecucion[1]);
            celda_tmp = new TableCell();
            drop_tmp = new DropDownList();
            drop_tmp.CssClass = "form-control";

            for (int i = 0; i < casos_disponibles.Rows.Count; ++i)
            {
                item_tmp = new ListItem();
                item_tmp.Text = casos_disponibles.Rows[i]["id_caso"].ToString();
                item_tmp.Value = casos_disponibles.Rows[i]["id_caso"].ToString();
                drop_tmp.Items.Add(item_tmp);
            }
            celda_tmp.Controls.Add(drop_tmp);
            fila.Cells.AddAt(3, celda_tmp);
            #endregion

            //Crea los campos donde el usuario va a ingresar text (Desc. no conformidad y justificacion)
            #region Creación de las entradas de datos en la fila
            //Descripcion de la no conformidad
            celda_tmp = new TableCell();
            entrada_tmp = new TextBox();
            entrada_tmp.CssClass = "form-control";
            entrada_tmp.Rows = 2;
            entrada_tmp.TextMode = TextBoxMode.MultiLine;
            entrada_tmp.Style.Add("resize", "none");
            entrada_tmp.Attributes.Add("placeholder", "Describa la no conformidad");
            celda_tmp.Controls.Add(entrada_tmp);
            fila.Cells.AddAt(4, celda_tmp);

            //Justificacion
            celda_tmp = new TableCell();
            entrada_tmp = new TextBox();
            entrada_tmp.CssClass = "form-control";
            entrada_tmp.Rows = 2;
            entrada_tmp.TextMode = TextBoxMode.MultiLine;
            entrada_tmp.Style.Add("resize", "none");
            entrada_tmp.Attributes.Add("placeholder", "Escriba la justificación de lo ocurrido");
            celda_tmp.Controls.Add(entrada_tmp);
            fila.Cells.AddAt(5, celda_tmp);

            #endregion

            //Crea el boton
            celda_tmp = new TableCell();
            Button btn_agrega_img = new Button();
            btn_agrega_img.CssClass = "btn btn-link btn-block";
            btn_agrega_img.Text = "Subir una imagen";
            btn_agrega_img.Click += new EventHandler(btn_agregar_img_Click);
            celda_tmp.Controls.Add(btn_agrega_img);
            fila.Cells.AddAt(6, celda_tmp);

            tabla_resultados.Rows.Add(fila);

        }

        /** @brief Método que llena la tabla del encabezado de la tabla de los resultados
        */
        private void llena_encabezado_tabla_resultados()
        {
            TableHeaderRow fila_encabezado = new TableHeaderRow();
            TableHeaderCell celda_encabezado = new TableHeaderCell();

            celda_encabezado.Text = "#";
            fila_encabezado.Cells.Add(celda_encabezado);

            celda_encabezado = new TableHeaderCell();
            celda_encabezado.Text = "Estado";
            fila_encabezado.Cells.Add(celda_encabezado);

            celda_encabezado = new TableHeaderCell();
            celda_encabezado.Text = "Tipo de no conformidad";
            fila_encabezado.Cells.Add(celda_encabezado);

            celda_encabezado = new TableHeaderCell();
            celda_encabezado.Text = "ID caso de prueba";
            fila_encabezado.Cells.Add(celda_encabezado);

            celda_encabezado = new TableHeaderCell();
            celda_encabezado.Text = "Descripción";
            fila_encabezado.Cells.Add(celda_encabezado);

            celda_encabezado = new TableHeaderCell();
            celda_encabezado.Text = "Justificación";
            fila_encabezado.Cells.Add(celda_encabezado);

            celda_encabezado = new TableHeaderCell();
            celda_encabezado.Text = "Resultados";
            fila_encabezado.Cells.Add(celda_encabezado);

            tabla_resultados.Rows.Add(fila_encabezado);
        }

        protected void btn_agregar_imagen_Click(object sender, EventArgs e)
        {
            if (subidor_archivo.HasFile) //Verifica que escogió un archivo
            {
                string nombre_archivo = Server.HtmlEncode(subidor_archivo.FileName); //obtengo el nombre del archivo
                string extension = System.IO.Path.GetExtension(nombre_archivo); //obtengo la extension del archivo
                int tamano_archivo = subidor_archivo.PostedFile.ContentLength;  //obtengo el tamaño del archivo
                if(tamano_archivo < 2100000)    //revisa que el archivo sea menor a 2MB
                {
                    if(extension == ".jpg" || extension == ".png" || extension == ".jpeg") //revisa que sea una imagen
                    {
                        subidor_archivo.PostedFile.SaveAs(Server.MapPath("~")+"/imagenes/" + nombre_archivo); //Guarda el archivo en el servidor.
                    }
                    else
                    {
                        label_mensaje_error_archivo.Text = " Solo puede subir imágenes.";
                        alerta_error_archivo.Visible = true;
                        upModalImagen.Update();
                    }

                }
                else
                {
                    label_mensaje_error_archivo.Text = " El archivo seleccionado pesa mas de 2MB.";
                    alerta_error_archivo.Visible = true;
                    upModalImagen.Update();
                }

            }
            else
            {
                label_mensaje_error_archivo.Text = " No seleccionó ningún archivo.";
                alerta_error_archivo.Visible = true;
                upModalImagen.Update();
            }
        }
    }

}