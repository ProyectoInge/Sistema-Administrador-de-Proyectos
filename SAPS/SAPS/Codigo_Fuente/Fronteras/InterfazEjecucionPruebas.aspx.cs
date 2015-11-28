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

        private static List<string[]> m_resultados_tmp;     // Va a llevar registro de cuantos resultados temporales se han creado.
        /* Cada String[] de la lista m_resultados_tmp tiene la siguiente estructura:

            |   Indice  |   Significado         |
            |:---------:|:---------------------:|
            |   0       |   # resultado         |
            |   1       |   estado              |
            |   2       |   tipo no conformidad |
            |   3       |   ID Caso             |
            |   4       |   Descripcion         |
            |   5       |   Justificacion       |
            |   6       |   Ruta imagen         |

            */

        /** @brief Metodo que se llama al cargar la página.
        */
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.Attributes.Add("enctype", "multipart/form-data");
            if (Request.IsAuthenticated)
            {
                m_controladora_ep = new ControladoraEjecuciones();
                alerta_advertencia.Visible = false;
                alerta_error.Visible = false;
                alerta_exito.Visible = false;
                alerta_error_archivo.Visible = false;

                if (!IsPostBack)
                {
                    m_llave_ejecucion = new int[2] { -1, -1 };
                    m_es_administrador = m_controladora_ep.es_administrador(Context.User.Identity.Name);
                    actualiza_disenos();
                    btn_agregar_resultado.Enabled = false;
                    btn_eliminar_resultado.Enabled = false;
                    drop_rh_disponibles.Enabled = false;
                    label_img_agregada.Visible = false;
                    m_resultados_tmp = new List<string[]>();
                    m_nombre_archivo = "";
                }

                if (drop_disenos_disponibles.SelectedItem.Value != "")
                {
                    llenar_ejecuciones_disponibles(Convert.ToInt32(drop_disenos_disponibles.SelectedItem.Value));
                }

                // Si hay ejecuciones
                if (m_resultados_tmp.Count > 0)
                {
                    actualiza_resultados();
                }
                else
                {
                    celda_drop_num_resultado.Text = (m_resultados_tmp.Count + 1).ToString();
                }
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
            btn_crear.CssClass = "btn btn-default";
            btn_modificar.CssClass = "btn btn-default active";
            btn_eliminar.CssClass = "btn btn-default";
            activa_desactiva_inputs(true);
            activa_desactiva_botones_ime(true);
            actualiza_resultados();
        }

        /** @brief Método que se activa al seleccionar el botón eliminar de los botones de IME
        * @param parámetros por defecto de ASP
        */
        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            m_opcion = 'e';
            btn_crear.CssClass = "btn btn-default";
            btn_modificar.CssClass = "btn btn-default";
            btn_eliminar.CssClass = "btn btn-default active";
            activa_desactiva_inputs(false);
            actualiza_resultados();
        }

        protected void btn_crear_Click(object sender, EventArgs e)
        {
            m_opcion = 'i';
            btn_crear.CssClass = "btn btn-default active";
            btn_modificar.CssClass = "btn btn-default";
            btn_eliminar.CssClass = "btn btn-default";
            activa_desactiva_inputs(true);
            actualiza_resultados();
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
                    agregar_ejecucion_resultados();
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

        /** @brief Metodo que se encarga de agregar la ejecucion y los resultados asociado al sistema.
        */
        private bool agregar_ejecucion_resultados()
        {
            bool a_retornar = false;
            if (drop_disenos_disponibles.SelectedItem.Value != "")
            {
                if (drop_rh_disponibles.SelectedItem.Value != "")
                {
                    if (input_fecha.Text != "")
                    {
                        if (input_incidentes.Text != "")
                        {
                            #region Guardo la ejecución en la base
                            /*
                                | Índice | Descripción             | Tipo de datos |
                                |:------:|:-----------------------:|:-------------:|
                                |    0   |  Numero de ejecucion    |      int      |
                                |    1   |  Responsable            |     string    |
                                |    2   |  Id del diseno          |      int      |
                                |    3   |  Fecha de ejecucion     |    Datetime   |
                                |    4   |  Incidencias            |     string    |
                            */
                            Object[] datos_ejecucion = new Object[5];
                            datos_ejecucion[0] = 0; //El ID lo asigna la base
                            datos_ejecucion[1] = drop_rh_disponibles.SelectedItem.Value;
                            datos_ejecucion[2] = drop_disenos_disponibles.SelectedItem.Value;
                            datos_ejecucion[3] = DateTime.Parse(input_fecha.Text);
                            datos_ejecucion[4] = input_incidentes.Text;
                            #endregion
                            int resultado = m_controladora_ep.insertar_ejecucion(datos_ejecucion);
                            if (resultado == 0)
                            {
                                DataTable ejecuciones_disponibles = m_controladora_ep.consultar_ejecuciones(Int32.Parse(drop_disenos_disponibles.SelectedItem.Value));
                                int id_ejecucion_recien_agrgada = Convert.ToInt32(ejecuciones_disponibles.Rows[ejecuciones_disponibles.Rows.Count - 1]["num_ejecucion"]);
                                bool resultado_resultados = ingresar_resultados_sistema(id_ejecucion_recien_agrgada);
                                if (resultado_resultados)
                                {
                                    cuerpo_alerta_exito.Text = " Se agregó la ejecución con sus resultados correctamente.";
                                    alerta_exito.Visible = true;
                                    a_retornar = true;
                                }
                                else
                                {
                                    cuerpo_alerta_error.Text = "Se presento un error al agregar uno de los resultados";
                                    alerta_error.Visible = true;
                                }

                            }
                            else
                            {
                                cuerpo_alerta_error.Text = " Ocurrio un error al insertar la ejecución";
                                alerta_error.Visible = true;
                            }

                        }
                        else
                        {
                            cuerpo_alerta_error.Text = " Tiene que ingresar un valor en ejecución";
                            alerta_error.Visible = true;
                            SetFocus(input_justificacion);
                        }
                    }
                    else
                    {
                        cuerpo_alerta_error.Text = " No ha seleccionado la fecha de la ejecución";
                        alerta_error.Visible = true;
                        SetFocus(input_fecha);
                    }
                }
                else
                {
                    cuerpo_alerta_error.Text = " No ha seleccionado ningún responsable para la ejecución.";
                    alerta_error.Visible = true;
                    SetFocus(drop_rh_disponibles);
                }
            }
            else
            {
                cuerpo_alerta_error.Text = " No ha seleccionado ningún diseño.";
                alerta_error.Visible = true;
                SetFocus(drop_disenos_disponibles);
            }

            return a_retornar;
        }
        /** @brief Metodo que se encarga de agregar todos los resultados que estan en la estructura de los resultados y los pasa a la base.
         *  @param El identificador de la ejecucion a la que se le van a asociar los resultados
         *  @return True si logro agregar todos los resultados, false si alguno presento error
        */
        private bool ingresar_resultados_sistema(int id_ejecucion)
        {

            #region Guardar los resutlados en la base de datos
            /*
                | Índice | Descripción             | Tipo de datos |
                |:------:|:-----------------------:|:-------------:|
                |    0   |  Numero de resultado    |      int      |
                |    1   |  Id del diseno          |      int      |
                |    2   |  Numero de ejecucion    |      int      |
                |    3   |  Estado                 |     string    |
                |    4   |  Tipo No Conformidad    |     string    |
                |    5   |  Id del Caso            |     string    |
                |    6   |  Descripcion No Conf.   |     string    |
                |    7   |  Justificacion          |     string    |
                |    8   |  Ruta de la imagen      |     string    |

                |   Indice  |   Significado         |
                |:---------:|:---------------------:|
                |   0       |   # resultado         |
                |   1       |   estado              |
                |   2       |   tipo no conformidad |   Todos son string
                |   3       |   ID Caso             |
                |   4       |   Descripcion         |
                |   5       |   Justificacion       |
                |   6       |   Ruta imagen         |
            */
            for (int i = 0; i < m_resultados_tmp.Count; ++i)
            {
                string[] vec_tmp = m_resultados_tmp[i];
                Object[] datos_resultado = new Object[9];
                datos_resultado[0] = Int32.Parse(vec_tmp[0]);
                datos_resultado[1] = Int32.Parse(drop_disenos_disponibles.SelectedItem.Value);
                datos_resultado[2] = id_ejecucion;
                datos_resultado[3] = vec_tmp[1];
                datos_resultado[4] = vec_tmp[2];
                datos_resultado[5] = vec_tmp[3];
                datos_resultado[6] = vec_tmp[4];
                datos_resultado[7] = vec_tmp[5];
                datos_resultado[8] = vec_tmp[6];
                int resultado_agrega_resultado = m_controladora_ep.insertar_resultado(datos_resultado);
                if (resultado_agrega_resultado != 0)
                {
                    cuerpo_alerta_error.Text = " Se presentó un error al insertar el resultado " + vec_tmp[0];
                    alerta_error.Visible = true;
                    return false;
                }
            }
            return true;
            #endregion
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
                                        datos[0] = m_llave_ejecucion[0];                                // Al consultar una ejecucion, el vector de llaves se llena
                                        datos[1] = drop_rh_disponibles.Text;
                                        datos[2] = Convert.ToInt32(drop_disenos_disponibles.Text);
                                        datos[3] = Convert.ToDateTime(input_fecha.Text);
                                        datos[4] = label_incidentes.Text;

                                        int resultado = m_controladora_ep.modificar_ejecucion(datos);
                                        if (resultado == 0)
                                        {
                                            respuesta = true;                                               // La insercion de la ejecucion es valida
                                                                                                            // Es necesario verificar los resultados de pruebas                                    
                                        }
                                        else
                                        {
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
                DataTable ejecuciones_disponibles = m_controladora_ep.consultar_ejecuciones(Int32.Parse(drop_disenos_disponibles.SelectedItem.Value));
                int id_ejecucion_recien_agrgada = Convert.ToInt32(ejecuciones_disponibles.Rows[ejecuciones_disponibles.Rows.Count - 1]["num_ejecucion"]);

                /*
                    | Índice | Descripción             | Tipo de datos |
                    |:------:|:-----------------------:|:-------------:|
                    |    0   |  Numero de resultado    |      int      |
                    |    1   |  Id del diseno          |      int      |
                    |    2   |  Numero de ejecucion    |      int      |
                    |    3   |  Estado                 |     string    |
                    |    4   |  Tipo No Conformidad    |     string    |
                    |    5   |  Id del Caso            |     string    |
                    |    6   |  Descripcion No Conf.   |     string    |
                    |    7   |  Justificacion          |     string    |
                    |    8   |  Ruta de la imagen      |     string    |

                    |   Indice  |   Significado         |
                    |:---------:|:---------------------:|
                    |   0       |   # resultado         |
                    |   1       |   estado              |
                    |   2       |   tipo no conformidad |   Todos son string
                    |   3       |   ID Caso             |
                    |   4       |   Descripcion         |
                    |   5       |   Justificacion       |
                    |   6       |   Ruta imagen         |
                */
                for (int i = 0; i < m_resultados_tmp.Count; ++i)
                {
                    string[] vec_tmp = m_resultados_tmp[i];
                    Object[] datos_resultado = new Object[9];
                    datos_resultado[0] = Int32.Parse(vec_tmp[0]);
                    datos_resultado[1] = Int32.Parse(drop_disenos_disponibles.SelectedItem.Value);
                    datos_resultado[2] = id_ejecucion_recien_agrgada;
                    datos_resultado[3] = vec_tmp[1];
                    datos_resultado[4] = vec_tmp[2];
                    datos_resultado[5] = vec_tmp[3];
                    datos_resultado[6] = vec_tmp[4];
                    datos_resultado[7] = vec_tmp[5];
                    datos_resultado[8] = vec_tmp[6];
                    int resultado_agrega_resultado = m_controladora_ep.modificar_resultado(datos_resultado);
                    if (resultado_agrega_resultado != 0)
                    {
                        cuerpo_alerta_error.Text = " Se presentó un error al insertar el resultado " + vec_tmp[0];
                        alerta_error.Visible = true;
                        return false;
                    }
                }

                cuerpo_alerta_exito.Text = " Se agregó la ejecución con sus resultados correctamente.";
                alerta_exito.Visible = true;
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
            mensaje_exito_modal.Visible = false;
            mensaje_error_modal.Visible = false;
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
            string[] fila_tmp = new string[7];

            string ruta = "";
            if (m_nombre_archivo != "")
            {
                ruta = Server.MapPath("~") + "/imagenes/" + m_nombre_archivo;
            }
            else
            {
                ruta = "NoTiene," + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            }

            #region Agrega los datos de la fila nueva a m_resultados_tmp
            //Agrega el nuevo elemento a la lista
            fila_tmp[0] = celda_drop_num_resultado.Text;
            fila_tmp[1] = drop_estado.SelectedItem.Value;
            fila_tmp[2] = drop_tipo_no_conformidad.SelectedItem.Value;
            fila_tmp[3] = drop_casos.SelectedItem.Value;
            fila_tmp[4] = input_descripcion.Text;
            fila_tmp[5] = input_justificacion.Text;
            fila_tmp[6] = ruta;
            m_resultados_tmp.Add(fila_tmp);     //Agrega la fila a la lista que contiene la informacion en memoria
            #endregion

            limpia_campos_ingresar_resultado();
            actualiza_resultados();
        }

        private void limpia_campos_ingresar_resultado()
        {
            input_descripcion.Text = "";
            input_justificacion.Text = "";
            m_nombre_archivo = "";
            label_img_agregada.Visible = false;

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
            TableHeaderCell celda_header_accion = new TableHeaderCell();
            celda_header_proposito.Text = "Nombre del diseño";
            header.Cells.AddAt(0, celda_header_proposito);
            celda_header_responsable.Text = "Responsable";
            header.Cells.AddAt(1, celda_header_responsable);
            celda_header_fecha_ultima_ejecucion.Text = "Fecha de la última ejecución";
            celda_header_accion.Text = "Acción";
            header.Cells.AddAt(2, celda_header_fecha_ultima_ejecucion);
            tabla_ejecuciones.Rows.Add(header);
            header.Cells.AddAt(3, celda_header_accion);
        }

        protected void ejecucion_seleccionado(object sender, EventArgs e)
        {
            int id_ejecucion = Convert.ToInt32(((Button)sender).ID);
            DataTable datos_ejecucion = m_controladora_ep.consultar_ejecucion(id_ejecucion);
            //ERROR
            m_llave_ejecucion[0] = Convert.ToInt32(datos_ejecucion.Rows[0]["num_ejecucion"].ToString());
            m_llave_ejecucion[1] = Convert.ToInt32(datos_ejecucion.Rows[0]["id_diseno"].ToString());

            // Responsable
            ListItem nombre_responsable = new ListItem();
            string nombre_usuario = datos_ejecucion.Rows[0]["responsable"].ToString();
            nombre_responsable.Text = m_controladora_ep.obtener_recurso_humano(nombre_usuario).Rows[0]["nombre"].ToString();
            nombre_responsable.Value = nombre_usuario;
            drop_rh_disponibles.Items.Add(nombre_responsable);
            drop_rh_disponibles.SelectedValue = nombre_usuario;
            drop_rh_disponibles.Enabled = false;

            // Fecha
            try
            {
                input_fecha.Text = Convert.ToDateTime(datos_ejecucion.Rows[0]["fecha_ultima_ejec"]).ToString("yyyy-MM-dd");
            }
            catch (Exception error)
            {
                input_fecha.Text = "yyyy-MM-dd";
            }
            input_fecha.Enabled = false;

            // incidentes
            input_incidentes.Text = datos_ejecucion.Rows[0]["incidencias"].ToString();
            input_incidentes.Enabled = false;

            // Resultados
            vacia_resultados();
            DataTable resultados_ejecucion = m_controladora_ep.consultar_resultados(id_ejecucion);

            for (int i = 0; i < resultados_ejecucion.Rows.Count; ++i)
            {
                string[] datos_resultado = new string[7];
                datos_resultado[0] = resultados_ejecucion.Rows[i]["num_resultado"].ToString();
                datos_resultado[1] = resultados_ejecucion.Rows[i]["estado"].ToString();
                datos_resultado[2] = resultados_ejecucion.Rows[i]["tipo_no_conformidad"].ToString();
                datos_resultado[3] = resultados_ejecucion.Rows[i]["id_caso"].ToString();
                datos_resultado[4] = resultados_ejecucion.Rows[i]["desc_no_conformidad"].ToString();
                datos_resultado[5] = resultados_ejecucion.Rows[i]["justificacion"].ToString();
                datos_resultado[6] = resultados_ejecucion.Rows[i]["ruta_imagen"].ToString();
                m_resultados_tmp.Add(datos_resultado);
            }

            llena_resultados();
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

                try
                {
                    fecha_ultima_ejecucion.Text = ejecucion["fecha_ultima_ejec"].ToString();
                }
                catch (Exception error)
                {
                    input_fecha.Text = "yyyy-MM-dd";
                }

                // Botón para consultar
                TableCell celda_consultar = new TableCell();
                Button btn_id_ejecucion = new Button();
                btn_id_ejecucion.Text = "Consultar";
                btn_id_ejecucion.ID = ejecucion["num_ejecucion"].ToString();
                btn_id_ejecucion.CssClass = "btn btn-link btn-block";
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
            string[] ruta_url = ((Button)sender).ID.Split(',');
            if (ruta_url[0] != "NoTiene")
            {
                visor_imagen.ImageUrl = ruta_url[0];
            }
            else
            {
                visor_imagen.ImageUrl = "http://telegram-stickers.github.io/public/stickers/animals/15.png";
            }
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modal_mostrar_imagen", "$('#modal_mostrar_imagen').modal();", true);
            update_mostrar_imagen.Update();
        }

        protected void btn_eliminar_resultado_Click(object sender, EventArgs e)
        {
            
            foreach (TableRow row in tabla_resultados.Rows)
            {
                foreach (TableCell cell in row.Cells)
                {
                    foreach (Control ctrl in cell.Controls)
                    {
                        if (ctrl is CheckBox)
                        {
                            CheckBox chck = (CheckBox)ctrl;
                            if (chck.Checked)
                            {
                                for (int i = m_resultados_tmp.Count - 1; i >= 0; i--)
                                {
                                    if (m_resultados_tmp[0][0] == chck.ID)
                                        m_resultados_tmp.RemoveAt(i); //lo saca de la lista                                        
                                }

                            }

                        }
                    }
                }

            }
            actualiza_resultados();
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
                DataTable info_proyecto_asociado = m_controladora_ep.consultar_mi_proyecto(Context.User.Identity.Name);
                int id_mi_proyecto = Convert.ToInt32(info_proyecto_asociado.Rows[0]["id_proyecto"]);
                disenos_disponibles = m_controladora_ep.solicitar_disenos_asociados_proyecto(id_mi_proyecto);
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

        /** @brief Actualiza los casos dependiendo del diseño que se seleccionó
        */
        private void actualizar_casos()
        {
            vaciar_casos();
            llena_casos();
        }

        /** @brief Elimina todos los items que hay en el drop de los casos.
        */
        private void vaciar_casos()
        {
            drop_casos.Items.Clear();
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
                actualizar_casos();
            }
            else
            {
                borrar_filas_tabla_ejecuciones_disponibles();
                actualizar_casos();
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
                int id_proyecto = Convert.ToInt32(info_diseno.Rows[0]["id_proyecto"]);
                actualizar_rh_disponibles(id_proyecto);
                btn_eliminar_resultado.Enabled = true;
                btn_agregar_resultado.Enabled = true;
                drop_rh_disponibles.Enabled = true;
            }
        }

        /** @brief Metodo que actualiza el drop de los diseños disponibles dependiendo del proyecto que se haya seleccionado.
         *  @param El identificador del proyecto que se eligio.
        */
        private void actualizar_rh_disponibles(int id_proyecto)
        {
            vaciar_rh_disponibles();
            llena_rh_disponibles(id_proyecto);
        }

        /** @brief Metod que vacia por completo el drop de los recursos humanos
        */
        private void vaciar_rh_disponibles()
        {
            drop_rh_disponibles.Items.Clear();
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
            for (int i = tabla_resultados.Rows.Count - 1; i >= 2; --i)
            {
                tabla_resultados.Rows.RemoveAt(i);
            }
        }

        /** @brief Método que llena la tabla donde estan los resultados de la ejecución.
         */
        private void llena_resultados()
        {
            celda_drop_num_resultado.Text = (m_resultados_tmp.Count + 1).ToString();
            for (int i = 0; i < m_resultados_tmp.Count; ++i)
            {
                string[] vec_tmp = m_resultados_tmp[i]; //Agarra el i-esimo vector de la lista
                TableRow nueva_fila = new TableRow();
                TableCell celda_tmp = new TableCell();
                DropDownList casos = new DropDownList();
                casos.CssClass = "form-control";



                #region Crea los controles de la fila

                //Agrega el checkbox de selección
                celda_tmp = new TableCell();
                CheckBox check = new CheckBox();
                check.AutoPostBack = true;
                check.ID = Convert.ToString(vec_tmp[0]);
                celda_tmp.Controls.Add(check);
                nueva_fila.Cells.Add(celda_tmp);

                //Agrega el identificador del caso de prueba del resultado
                celda_tmp = new TableCell();
                celda_tmp.Text = vec_tmp[3];

                ListItem caso_escogido = new ListItem();                                            // Se agrega inicialmente el caso escogido
                caso_escogido.Text = celda_tmp.Text;
                caso_escogido.Value = celda_tmp.Text;
                casos.Items.Add(caso_escogido);
                // Posterior, se consulta el resto de casos y se agrega
                DataTable casos_disponibles = m_controladora_ep.solicitar_casos_asociados_diseno(m_llave_ejecucion[1]);
                ListItem item_tmp = new ListItem();
                for (int j = 0; j < casos_disponibles.Rows.Count; ++j)
                {
                    item_tmp = new ListItem();
                    item_tmp.Text = casos_disponibles.Rows[j]["id_caso"].ToString();
                    item_tmp.Value = casos_disponibles.Rows[j]["id_caso"].ToString();
                    if (item_tmp.Text != celda_tmp.Text)
                    {
                        casos.Items.Add(item_tmp);
                    }
                }

                if (m_opcion == 'm')
                {
                    casos.Enabled = true;
                }
                else
                {
                    casos.Enabled = false;
                }

                celda_tmp.Controls.Add(casos);                                                      // Se agrega la lista de casos al resultado
                nueva_fila.Cells.Add(celda_tmp);

                //Agrega el numero de resultado
                celda_tmp = new TableCell();
                celda_tmp.Text = vec_tmp[0];
                nueva_fila.Cells.Add(celda_tmp);

                //Agrega el estado del resultado
                celda_tmp = new TableCell();
                celda_tmp.Text = vec_tmp[1];
                DropDownList lista = new DropDownList();
                lista.CssClass = "form-control";

                switch (celda_tmp.Text)
                {                                   // Creacion del dropdown de estados
                    case "Satisfactoria":
                        lista.Items.Add("Satisfactoria");
                        lista.Items.Add("Fallida");
                        lista.Items.Add("Pendiente");
                        lista.Items.Add("Cancelada");
                        break;
                    case "Fallida":
                        lista.Items.Add("Fallida");
                        lista.Items.Add("Satisfactoria");
                        lista.Items.Add("Pendiente");
                        lista.Items.Add("Cancelada");
                        break;
                    case "Pendiente":
                        lista.Items.Add("Pendiente");
                        lista.Items.Add("Fallida");
                        lista.Items.Add("Satisfactoria");
                        lista.Items.Add("Cancelada");
                        break;
                    case "Cancelada":
                        lista.Items.Add("Cancelada");
                        lista.Items.Add("Pendiente");
                        lista.Items.Add("Fallida");
                        lista.Items.Add("Satisfactoria");
                        break;
                }

                if (m_opcion == 'm')
                {
                    lista.Enabled = true;
                }
                else
                {
                    lista.Enabled = false;
                }

                celda_tmp.Controls.Add(lista);                                              // Se agrega el dropdown de estados a la celda
                nueva_fila.Cells.Add(celda_tmp);

                //Agrega el tipo de no conformidad del resultado
                celda_tmp = new TableCell();
                celda_tmp.Text = vec_tmp[2];
                DropDownList lista_conformidad = new DropDownList();
                lista_conformidad.CssClass = "form-control";

                switch (celda_tmp.Text)
                {                                                  // Creacion del dropdown de tipos de no conformidad
                    case "No aplica":
                        lista_conformidad.Items.Add("No aplica");
                        lista_conformidad.Items.Add("Funcionalidad");
                        lista_conformidad.Items.Add("Validación");
                        lista_conformidad.Items.Add("Opciones que no funcionan");
                        lista_conformidad.Items.Add("Errores de usabilidad");
                        lista_conformidad.Items.Add("Excepciones");
                        break;
                    case "Funcionalidad":
                        lista_conformidad.Items.Add("Funcionalidad");
                        lista_conformidad.Items.Add("No aplica");
                        lista_conformidad.Items.Add("Validación");
                        lista_conformidad.Items.Add("Opciones que no funcionan");
                        lista_conformidad.Items.Add("Errores de usabilidad");
                        lista_conformidad.Items.Add("Excepciones");
                        break;
                    case "Validación":
                        lista_conformidad.Items.Add("Validación");
                        lista_conformidad.Items.Add("Funcionalidad");
                        lista_conformidad.Items.Add("No aplica");
                        lista_conformidad.Items.Add("Opciones que no funcionan");
                        lista_conformidad.Items.Add("Errores de usabilidad");
                        lista_conformidad.Items.Add("Excepciones");
                        break;
                    case "Opciones que no funcionan":
                        lista_conformidad.Items.Add("Opciones que no funcionan");
                        lista_conformidad.Items.Add("Validación");
                        lista_conformidad.Items.Add("Funcionalidad");
                        lista_conformidad.Items.Add("No aplica");
                        lista_conformidad.Items.Add("Errores de usabilidad");
                        lista_conformidad.Items.Add("Excepciones");
                        break;
                    case "Errores de usabilidad":
                        lista_conformidad.Items.Add("Errores de usabilidad");
                        lista_conformidad.Items.Add("Opciones que no funcionan");
                        lista_conformidad.Items.Add("Validación");
                        lista_conformidad.Items.Add("Funcionalidad");
                        lista_conformidad.Items.Add("No aplica");
                        lista_conformidad.Items.Add("Excepciones");
                        break;
                    case "Excepciones":
                        lista_conformidad.Items.Add("Excepciones");
                        lista_conformidad.Items.Add("Errores de usabilidad");
                        lista_conformidad.Items.Add("Opciones que no funcionan");
                        lista_conformidad.Items.Add("Validación");
                        lista_conformidad.Items.Add("Funcionalidad");
                        lista_conformidad.Items.Add("No aplica");
                        break;
                }

                if (m_opcion == 'm')
                {
                    lista_conformidad.Enabled = true;
                }
                else
                {
                    lista_conformidad.Enabled = false;
                }

                celda_tmp.Controls.Add(lista_conformidad);                                      // Se agrega el dropdown de tipos de no conformidad a la celda
                nueva_fila.Cells.Add(celda_tmp);

                //Agrega la descripcion de la no conformidad
                celda_tmp = new TableCell();
                TextBox input_tmp = new TextBox();
                input_tmp.CssClass = "form-control";
                if (m_opcion == 'm')
                {
                    input_tmp.Enabled = true;
                }
                else
                {
                    input_tmp.Enabled = false;
                }
                input_tmp.TextMode = TextBoxMode.MultiLine;
                input_tmp.Rows = 2;
                input_tmp.Attributes.Add("resize", "none");
                input_tmp.Text = vec_tmp[4];
                celda_tmp.Controls.Add(input_tmp);
                nueva_fila.Cells.Add(celda_tmp);

                //Agrega la justificacion
                celda_tmp = new TableCell();
                input_tmp = new TextBox();
                input_tmp.CssClass = "form-control";
                if (m_opcion == 'm')
                {
                    input_tmp.Enabled = true;
                }
                else
                {
                    input_tmp.Enabled = false;
                }
                input_tmp.TextMode = TextBoxMode.MultiLine;
                input_tmp.Rows = 2;
                input_tmp.Attributes.Add("resize", "none");
                input_tmp.Text = vec_tmp[5];
                celda_tmp.Controls.Add(input_tmp);
                nueva_fila.Cells.Add(celda_tmp);

                //Hace el boton para consultar la imagen

                if (m_opcion == 'm')
                {                                                                      // Se permite al usuario subir otra imagen
                    celda_tmp = new TableCell();
                    Button btn_modificar_imagen = new Button();
                    btn_modificar_imagen.CssClass = "btn btn-link";
                    btn_modificar_imagen.Text = "Cambiar imagen";
                    btn_modificar_imagen.ID = vec_tmp[6];
                    btn_modificar_imagen.Click += new EventHandler(activar_modal_imagen);
                    celda_tmp.Controls.Add(btn_modificar_imagen);
                    nueva_fila.Cells.Add(celda_tmp);
                }
                else                                                                                        // Consulta normal de resultados de ejecucion
                {
                    celda_tmp = new TableCell();
                    Button btn_consultar_imagen = new Button();
                    btn_consultar_imagen.CssClass = "btn btn-link";
                    btn_consultar_imagen.Text = "Ver imagen";
                    btn_consultar_imagen.ID = vec_tmp[6];
                    btn_consultar_imagen.Click += new EventHandler(btn_consultar_imagen_Click);
                    celda_tmp.Controls.Add(btn_consultar_imagen);
                    nueva_fila.Cells.Add(celda_tmp);
                }
                #endregion
                tabla_resultados.Rows.Add(nueva_fila);
            }
        }


        /** @brief Metodo que se encarga de llenar el drop con los casos disponibles.
        */
        private void llena_casos()
        {
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


        /**@brief Evento encargado de mostrar el modal apropiado para cargar una imagen relacionada al resultado.
        */
        protected void activar_modal_imagen(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modal_imagen", "$('#modal_imagen').modal();", true);
            upModalImagen.Update();
        }



        /** @brief Evento que guarda una imagen que subió el usuario al servidor.
         * @param Los parametros por defecto de ASP para un evento.
        */
        protected void btn_agregar_imagen_Click(object sender, EventArgs e)
        {
            if (subidor_archivo.HasFile) //Verifica que escogió un archivo
            {
                string nombre_archivo = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Server.HtmlEncode(subidor_archivo.FileName); //obtengo el nombre del archivo
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
                    label_mensaje_error_archivo.Text = " El archivo seleccionado pesa mas de 1,5MB.";
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

        /** @brief Metodo que se encarga de llenar los recursos humanos disponibles.
         * @param El identificador del proyecto del cual se van a mostrar los recursos humanos disponibles.
        */
        private void llena_rh_disponibles(int id_proyecto)
        {
            DataTable rh_disponibles = m_controladora_ep.consultar_rh_asociados_proyecto(id_proyecto);
            ListItem item_tmp = new ListItem();
            item_tmp.Text = "-Seleccione un recurso humano-";
            item_tmp.Value = "";
            drop_rh_disponibles.Items.Add(item_tmp);
            for (int i = 0; i < rh_disponibles.Rows.Count; ++i)
            {
                item_tmp = new ListItem();
                item_tmp.Text = rh_disponibles.Rows[i]["nombre"].ToString();
                item_tmp.Value = rh_disponibles.Rows[i]["username"].ToString();
                drop_rh_disponibles.Items.Add(item_tmp);
            }
        }
    }

}