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

        private static int TAMA_ARCHIVO = 1600000; //Constante que es el tamaño máximo (en bytes) del archivo que se puede subir.

        private static bool m_es_administrador;

        private static string m_nombre_archivo;

        // Resultados
        private static List<string[]> m_resultados_tmp;


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
                label_img_agregada.Visible = false;
                btn_agregar_resultado.Enabled = false;
                btn_eliminar_resultado.Enabled = false;
                drop_rh_disponibles.Enabled = false;

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
                                else
                                {
                                    cuerpo_alerta_error.Text = "Debe ingresar una fecha de ejecución.";
                                    SetFocus(input_fecha);
                                    respuesta = false;
                                }

                            }
                            else
                            {
                                cuerpo_alerta_error.Text = "Debe insertar un responsable asociado.";
                                SetFocus(drop_rh_disponibles);
                                respuesta = false;
                            }

                        }
                        else
                        {
                            cuerpo_alerta_error.Text = "Debe insertar Criterios de Aceptación.";
                            SetFocus(input_criterios_aceptacion_diseno);
                            respuesta = false;
                        }
                    }
                    else
                    {
                        cuerpo_alerta_error.Text = "Debe insertar los datos de Procedimiento";
                        SetFocus(input_procedimiento_diseno);
                        respuesta = false;
                    }

                }
                else
                {
                    cuerpo_alerta_error.Text = "Debe insertar los datos de Ambiente.";
                    SetFocus(input_ambiente_diseno);
                    respuesta = false;
                }

            }
            else
            {
                cuerpo_alerta_error.Text = "Debe seleccionar un diseño asociado.";
                SetFocus(drop_disenos_disponibles);
                respuesta = false;
            }


            // Seccion que verifica si la lista de resultados no posee errores

            if (respuesta)
            {                            // Verificados los datos de ejecucion, se verifican los de resultados

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

        /** @brief Evento que se activa cuando el usuario da click en "agregar" para un resultado
         * @param Los parámetros por defecto de ASP
        */
        protected void btn_agregar_resultado_Click(object sender, EventArgs e)
        {
            string ruta = Server.MapPath("~") + "/imagenes/" + m_nombre_archivo;
            TableRow nueva_fila = new TableRow();
            TableCell celda_tmp = new TableCell();

            //Agrega el numero de resultado
            celda_tmp.Text = celda_drop_num_resultado.Text;
            nueva_fila.Cells.Add(celda_tmp);

            //Agrega el estado del resultado
            celda_tmp = new TableCell();
            celda_tmp.Text = drop_estado.SelectedItem.Value;
            nueva_fila.Cells.Add(celda_tmp);

            //Agrega el tipo de no conformidad del resultado
            celda_tmp = new TableCell();
            celda_tmp.Text = drop_tipo_no_conformidad.SelectedItem.Value;
            nueva_fila.Cells.Add(celda_tmp);

            //Agrega el identificador del caso de prueba del resultado
            celda_tmp = new TableCell();
            celda_tmp.Text = drop_casos.SelectedItem.Value;
            nueva_fila.Cells.Add(celda_tmp);

            //Agrega la descripcion de la no conformidad
            celda_tmp = new TableCell();
            TextBox input_tmp = new TextBox();
            input_tmp.CssClass = "form-control";
            input_tmp.Enabled = false;
            input_tmp.TextMode = TextBoxMode.MultiLine;
            input_tmp.Attributes.Add("resize", "none");
            input_tmp.Text = input_descripcion.Text;
            celda_tmp.Controls.Add(input_tmp);
            nueva_fila.Cells.Add(celda_tmp);

            //Agrega la justificacion
            celda_tmp = new TableCell();
            input_tmp = new TextBox();
            input_tmp.CssClass = "form-control";
            input_tmp.Enabled = false;
            input_tmp.TextMode = TextBoxMode.MultiLine;
            input_tmp.Attributes.Add("resize", "none");
            input_tmp.Text = input_justificacion.Text;
            celda_tmp.Controls.Add(input_tmp);
            nueva_fila.Cells.Add(celda_tmp);

            //Hace el boton para consultar la imagen
            celda_tmp = new TableCell();
            Button btn_consultar_imagen = new Button();
            btn_consultar_imagen.CssClass = "btn btn-link";
            btn_consultar_imagen.Text = "Ver imagen";
            btn_consultar_imagen.ID = ruta;
            btn_consultar_imagen.Click += new EventHandler(btn_consultar_imagen_Click);
            celda_tmp.Controls.Add(btn_consultar_imagen);
            nueva_fila.Cells.Add(celda_tmp);

            //agrega la fila a la tabla
            tabla_resultados.Rows.Add(nueva_fila);


        }


        // Métodos relacionados a consultar

        protected void borrar_filas_tabla_ejecuciones_disponibles()
        {
            tabla_ejecuciones.Rows.Clear();
        }

        protected void crea_encabezado_ejecuciones_disponibles()
        {
            TableHeaderRow header = new TableHeaderRow();
            TableHeaderCell celda_header_proposito = new TableHeaderCell();
            TableHeaderCell celda_header_responsable = new TableHeaderCell();
            TableHeaderCell celda_header_fecha_ultima_ejecucion = new TableHeaderCell();
            celda_header_proposito.Text = "Próposito del diseño";
            header.Cells.AddAt(0, celda_header_proposito);
            celda_header_responsable.Text = "Responsable";
            header.Cells.AddAt(1, celda_header_responsable);
            celda_header_fecha_ultima_ejecucion.Text = "Fecha de la última ejecución";
            header.Cells.AddAt(2, celda_header_fecha_ultima_ejecucion);
            tabla_ejecuciones.Rows.Add(header);
        }

        protected void ejecucion_seleccionado(object sender, EventArgs e)
        {
            int id_ejecucion = Convert.ToInt32(((Button)sender).ID);
            DataTable datos_ejecucion = m_controladora_ep.consultar_ejecucion(id_ejecucion);

            // Responsable
            ListItem nombre_responsable = new ListItem();
            string nombre_usuario = datos_ejecucion.Rows[0]["responsable"].ToString();
            nombre_responsable.Text = m_controladora_ep.obtener_recurso_humano(nombre_usuario).Rows[0]["nombre"].ToString();
            nombre_responsable.Value = nombre_usuario;
            drop_disenos_disponibles.Items.Add(nombre_responsable);

            // Fecha
            try
            {
                input_fecha.Text = Convert.ToDateTime(datos_ejecucion.Rows[0]["fecha_ultima_ejec"]).ToString("yyyy-MM-dd");
            }
            catch (Exception error)
            {
                input_fecha.Text = "yyyy-MM-dd";
            }

            // incidentes
            input_incidentes.Text = datos_ejecucion.Rows[0]["incidencias"].ToString();


            // Resultados
            vacia_resultados();
            DataTable resultados_ejecucion = m_controladora_ep.consultar_resultados(id_ejecucion);
            foreach (DataRow resultado in resultados_ejecucion.Rows)
            {
                string[] datos_resultado = new string[7];
                int i = 0;
                foreach (var item in resultado.ItemArray)
                {
                    datos_resultado[i] = item.ToString();
                    i++;
                }
                m_resultados_tmp.Add(datos_resultado);
            }
            
            // @todo llamar a método que llena la lista de resultados.
        }

        protected void llenar_ejecuciones_disponibles(int id_diseno)
        {
            crea_encabezado_ejecuciones_disponibles();

            DataTable ejecuciones = m_controladora_ep.consultar_ejecuciones(id_diseno);
            foreach (DataRow ejecucion in ejecuciones.Rows)
            {
                TableRow fila_ejecucion = new TableRow();

                TableCell proposito_diseno = new TableCell();
                proposito_diseno.Text = m_controladora_ep.obtener_proposito_diseno(Convert.ToInt32(ejecucion["id_diseno"].ToString()));

                TableCell responsable_ejecucion = new TableCell();
                responsable_ejecucion.Text = ejecucion["responsable"].ToString();

                TableCell fecha_ultima_ejecucion = new TableCell();
                fecha_ultima_ejecucion.Text = ejecucion["fecha_ultima_ejecuc"].ToString();

                // Botón para consultar
                TableCell celda_consultar = new TableCell();
                Button btn_id_ejecucion = new Button();
                btn_id_ejecucion.Text = "Consultar";
                btn_id_ejecucion.ID = ejecucion["num_ejecucion"].ToString();
                btn_id_ejecucion.CssClass = "btn btn-link";
                btn_id_ejecucion.Click += new EventHandler(ejecucion_seleccionado);
                celda_consultar.Controls.Add(btn_id_ejecucion);

                // Insertar en la fila
                fila_ejecucion.Cells.Add(proposito_diseno);
                fila_ejecucion.Cells.Add(responsable_ejecucion);
                fila_ejecucion.Cells.Add(fecha_ultima_ejecucion);
                fila_ejecucion.Cells.Add(celda_consultar);

                tabla_ejecuciones.Rows.Add(fila_ejecucion);
            }
        }

        protected void btn_consultar_imagen_Click(object sender, EventArgs e)
        {
            // En el ID del boton viene la ruta a la imagen.
            ///@todo Desplegar el modal donde muestre la imagen
        }

        /** @brief Agrega un resultado a la tabla de los resultados.
         * @param Un vector con todos los datos del resultado a ingresar.
         *  | Indice    |   Descripcion         | Tipo de dato      |
            |:---------:|:---------------------:|:-----------------:|
            |   0       |   # de resultado      |   int             |
            |   1       |   Estado              |   string          |
            |   2       |   Tipo no conformidad |   string          |
            |   3       |   ID Caso de prueba   |   string          |
            |   4       |   Desc. no conformidad|   string          |
            |   5       |   Justificacion       |   string          |
            |   6       |   Ruta imagen         |   string          |
        */
        private void agrega_resultado(Object[] datos_resultado)
        {
            int resultado = m_controladora_ep.insertar_resultado(datos_resultado);
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

                // Llena la tabla de ejecuciones asociadas a un diseño
                llenar_ejecuciones_disponibles(id_diseno_seleccionado);
            }
            else
            {
                borrar_filas_tabla_ejecuciones_disponibles();
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
                input_procedimiento_diseno.Text = info_diseno.Rows[0]["procedimiento"].ToString();
                btn_eliminar_resultado.Enabled = true;
                btn_agregar_resultado.Enabled = true;
                drop_rh_disponibles.Enabled = true;
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
            celda_drop_num_resultado.Text = (tabla_resultados.Rows.Count - 1).ToString();
            llena_casos();
        }

        /** @brief Metodo que se encarga de llenar el drop con los casos disponibles.
        */
        private void llena_casos()
        {
            //Llenado y creación del DropDown (ID caso de prueba)
            DataTable casos_disponibles = m_controladora_ep.solicitar_casos_asociados_diseno(m_llave_ejecucion[1]);
            ListItem item_tmp = new ListItem();
            for (int i = 0; i < casos_disponibles.Rows.Count; ++i)
            {
                item_tmp = new ListItem();
                item_tmp.Text = casos_disponibles.Rows[i]["id_caso"].ToString();
                item_tmp.Value = casos_disponibles.Rows[i]["id_caso"].ToString();
                drop_casos.Items.Add(item_tmp);
            }
        }


        protected void btn_agregar_imagen_Click(object sender, EventArgs e)
        {
            if (subidor_archivo.HasFile) //Verifica que escogió un archivo
            {
                string nombre_archivo = Server.HtmlEncode(subidor_archivo.FileName); //obtengo el nombre del archivo
                string extension = System.IO.Path.GetExtension(nombre_archivo); //obtengo la extension del archivo
                int tamano_archivo = subidor_archivo.PostedFile.ContentLength;  //obtengo el tamaño del archivo
                if (tamano_archivo < TAMA_ARCHIVO)    //revisa que el archivo sea menor a 1.5MB
                {
                    if (extension == ".jpg" || extension == ".png" || extension == ".jpeg") //revisa que sea una imagen
                    {
                        subidor_archivo.PostedFile.SaveAs(Server.MapPath("~") + "/imagenes/" + nombre_archivo); //Guarda el archivo en el servidor.
                        m_nombre_archivo = nombre_archivo;
                        cuerpo_alerta_exito.Text = " Se subió correctamente la imagen";
                        alerta_exito.Visible = true;
                        label_img_agregada.Visible = true;
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