using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SAPS.Controladoras;
using SAPS.Entidades.Ayudantes;

namespace SAPS.Fronteras
{
    public partial class InterfazCasosDePruebas : System.Web.UI.Page
    {
        //Variables de instacia
        private static ControladoraRecursosHumanos m_controladora_rh;
        private static ControladoraProyectoPruebas m_controladora_pdp;
        private static ControladoraDisenosPruebas m_controladora_dp;
        private static ControladoraCasoPruebas m_controladora_cdp;

        

        private static TableHeaderRow m_fila_header; // Es global ya que se tiene que modificar en ciertas ocaciones

        private static char m_opcion = 'i'; //i = insertar, m = modificar, e = eliminar

        private static bool m_es_administrador;

        private static string m_caso_actual = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                alerta_error.Visible = false;
                alerta_exito.Visible = false;
                alerta_advertencia.Visible = false;
                activa_desactiva_botones_ime(false);
                m_controladora_rh = new ControladoraRecursosHumanos();
                m_controladora_pdp = new ControladoraProyectoPruebas();
                m_controladora_dp = new ControladoraDisenosPruebas();
                m_controladora_cdp = new ControladoraCasoPruebas();
                m_controladora_pdp = new ControladoraProyectoPruebas();
                m_controladora_rh = new ControladoraRecursosHumanos();
                m_fila_header = new TableHeaderRow();
                

                if (!IsPostBack)
                {
                    m_es_administrador = m_controladora_rh.es_administrador(Context.User.Identity.Name);                    
                    drop_diseno_asociado.Enabled = false;
                    drop_id_requerimientos.Enabled = false;
                    actualiza_proyectos();
                }
                actualiza_caso_de_pruebas_disponibles();

            }
            else
            {
                Response.Redirect("~/Codigo_Fuente/Fronteras/InterfazLogin.aspx");
            }
        }


        #region Métodos Botones

        /** @brief Evento que se activa cuando el usuario selecciona el boton de "aceptar".
        * @param Los parametros por default de un evento de C#.
        */
        protected void btn_aceptar_Click(object sender, EventArgs e)
        {
            if (valida_campos() == true)
            {
                if (m_opcion != 'e')
                {
                    alerta_exito.Visible = true;
                    if (m_opcion == 'i')
                    {
                        activa_desactiva_botones_ime(true);
                    }
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

        /** @brief Evento que se activa cuando el usuario selecciona el boton de "cancelar".
        * @param Los parametros por default de un evento de C#.
        */
        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            m_opcion = 'i';
            limpia_campos();
            activa_desactiva_botones_ime(false);
            Response.Redirect("~/Codigo_Fuente/Fronteras/InterfazCasosDePruebas.aspx");
        }
        //Ya está


        /** @brief Evento que se activa cuando el usuario selecciona el boton de "crear".
        * @param Los parametros por default de un evento de C#.
        */
        protected void btn_crear_Click(object sender, EventArgs e)
        {
            m_opcion = 'i';
            activa_desactiva_inputs(true);
            btn_eliminar.CssClass = "btn btn-default";
            btn_crear.CssClass = "btn btn-default active";
            btn_modificar.CssClass = "btn btn-default ";
        }
        //Ya está

        /** @brief Evento que se activa cuando el usuario selecciona el boton de "modificar".
        * @param Los parametros por default de un evento de C#.
         */
        protected void btn_modificar_Click(object sender, EventArgs e)
        {
            m_opcion = 'm';
            activa_desactiva_inputs(true);
            activa_desactiva_botones_ime(true);
            btn_eliminar.CssClass = "btn btn-default";
            btn_crear.CssClass = "btn btn-default";
            btn_modificar.CssClass = "btn btn-default active";
        }
        //Ya está

        /** @brief Evento que se activa cuando el usuario selecciona el boton de "eliminar".
        * @param Los parametros por default de un evento de C#.
        */
        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            m_opcion = 'e';
            activa_desactiva_inputs(false);
            activa_desactiva_botones_ime(true);
            btn_eliminar.CssClass = "btn btn-default active";
            btn_crear.CssClass = "btn btn-default";
            btn_modificar.CssClass = "btn btn-default";
        }
        //Ya está

        /** @brief Evento cuando un botón del ID de caso de pruebas se presiona */
        protected void btn_lista_Clicked(Object sender, EventArgs e)
        {
            string id_caso_de_prueba = ((Button)sender).ID;
            DataTable caso_de_prueba = m_controladora_cdp.consultar_caso_pruebas(id_caso_de_prueba);

            // Completa la información del caso de prueba en la interfaz
            text_proposito.Text = caso_de_prueba.Rows[0]["proposito"].ToString();
            text_flujo_central.Text = caso_de_prueba.Rows[0]["flujo_central"].ToString();
            actualiza_caso_de_pruebas_disponibles();
            m_caso_actual = id_caso_de_prueba;
            activa_desactiva_botones_ime(true);
            // @todo llenar los datos relacionados.
        }

        #endregion


        /** @brief Pone activos los botones de "Eliminar" y "Modificar"
        * @param Bool con el estado de activacion de los botones ime (true/false)
        */
        private void activa_desactiva_botones_ime(bool estado)
        {
                btn_eliminar.Enabled = estado;
                btn_modificar.Enabled = estado;
                btn_crear.Enabled = true;
        }
        //Ya está

        /** @brief Se encarga de limpiar los strings que hay en los textbox y de deshabilitar los campos 
        */
        private void limpia_campos()
        {
            drop_proyecto_asociado.Text = "";
            drop_diseno_asociado.Text = "";
            drop_id_requerimientos.Text = "";
            text_proposito.Text = "";
            text_flujo_central.Text = "";
            m_opcion = 'i';
        }

        /** @brief Activa o desactiva los campos de ingresar texto.
       * @param Bool "estado" que indica si activa o desactiva los campos.
       */
        private void activa_desactiva_inputs(bool estado)
        {
            drop_proyecto_asociado.Enabled = estado;
            drop_diseno_asociado.Enabled = estado;
            drop_id_requerimientos.Enabled = estado;
            text_proposito.Enabled = estado;
            text_flujo_central.Enabled = estado;
        }


        #region Métodos IMEC
        /** @brief Metodo que valida los campos que se ocupan para insertar o modificar un caso de pruebas, si no hay problema entonces lo inserta o lo modifica en la base.
        */
        private bool insertar_modificar_caso_pruebas()
        {
            bool a_retornar = false;
            if (drop_proyecto_asociado.Text != "")
            {
                if (drop_diseno_asociado.Text != "")
                {
                    if (drop_id_requerimientos.Text != "")
                    {
                        if (text_proposito.Text != "")
                        {
                            if (text_flujo_central.Text != "")
                            {
                                //Parte de la entidad
                                Object[] datos = new Object[4];
                                datos[0] = m_caso_actual;
                                datos[1] = drop_diseno_asociado.SelectedItem.Value;
                                datos[2] = text_proposito.Text;
                                datos[3] = text_flujo_central.Text;

                                //No son parte de entidad

                                m_caso_actual = "" ; //Vuelve a invalidar el caso seleccionado
                                if('i' == m_opcion)
                                {
                                    int resultado = m_controladora_cdp.insertar_caso_pruebas(datos, null);
                                    if (resultado == 0)
                                    {
                                        cuerpo_alerta_exito.Text = " Se ingresó el caso de pruebas correctamente.";

                                    }
                                    else
                                    {
                                        cuerpo_alerta_error.Text = " Hubo un error al insertar el caso de pruebas, intentelo nuevamente.";

                                    }
                                }
                                else
                                {
                                    int resultado = m_controladora_cdp.modificar_caso_pruebas(datos, null); //TO DO 
                                    if (resultado == 0)
                                    {
                                        cuerpo_alerta_exito.Text = " Se modificó el caso de pruebas correctamente.";
                                    }
                                    else
                                    {
                                        cuerpo_alerta_error.Text = " Hubo un error al modificar el caso de pruebas, intentelo nuevamente.";

                                    }
                                }
                                actualiza_caso_de_pruebas_disponibles();
                                a_retornar = true;
                            }
                            else
                            {
                                cuerpo_alerta_error.Text = "Es necesario especificar el flujo central del caso de pruebas.";
                                SetFocus(text_flujo_central);
                            }
                        }
                        else
                        {
                            cuerpo_alerta_error.Text = "Es necesario especificar el propósito del caso de pruebas.";
                            SetFocus(text_proposito);
                        }
                    }
                    else
                    {
                        cuerpo_alerta_error.Text = "Es necesario escoger al menos un requerimiento.";
                        SetFocus(drop_id_requerimientos);
                    }
                }
                else
                {
                    cuerpo_alerta_error.Text = "Es necesario escoger un diseño.";
                    SetFocus(drop_diseno_asociado);
                }
            }
            else
            {
                cuerpo_alerta_error.Text = "Es necesario escoger un proyecto.";
                SetFocus(drop_proyecto_asociado);
            }
            return a_retornar;
        }

        /** @brief Metodo que valida los campos que se ocupan para eliminar un caso de pruebas, si no hay problema entonces lo elimina de la base.
       */
        private bool eliminar_caso_pruebas()
        {
            bool a_retornar = false;
            if (m_caso_actual != "")
            {
                int resultado = m_controladora_cdp.eliminar_caso_pruebas(m_caso_actual);
                if (resultado == 0)
                {
                    a_retornar = true;
                    cuerpo_alerta_exito.Text = " Se eliminó el caso de pruebas correctamente.";
                    alerta_exito.Visible = true;
                }
                else
                {
                    cuerpo_alerta_error.Text = " Falló al eliminar el caso de pruebas.";
                    alerta_error.Visible = true;
                }
                actualiza_caso_de_pruebas_disponibles();
            }     
            
            return a_retornar;
        }

        #endregion



        /** @brief Verifica todos los campos que llena el usuario para comprobar que los datos ingresados son válidos, si no hay problema entonces envía los datos a la controladora y realiza la operación respectiva.
         */
        private bool valida_campos()
        {
            bool a_retornar = false;
            if (m_opcion == 'e')
            {
                a_retornar = eliminar_caso_pruebas();
            }
            else
            {
                a_retornar = insertar_modificar_caso_pruebas();
            }
            return a_retornar;
        }


        /** @brief Metodo que se activa cuando el usuario selecciona un proyecto del dropdown, llena la informacion correspondiente a ese proyecto.
         * @param Los parametros por default de un evento de C#.
        */
        protected void drop_proyecto_asociado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ("" != drop_proyecto_asociado.SelectedItem.Value)
            {
                int id_proyecto_seleccionado = Convert.ToInt32(drop_proyecto_asociado.SelectedItem.Value);
                drop_diseno_asociado.Enabled = true;
                drop_id_requerimientos.Enabled = false;
                actualiza_disenos_asociados(id_proyecto_seleccionado);
                vacia_requerimientos();
            }
                label_id_diseno.Text = "ID diseño";
                label_id_diseno.Font.Italic = true;
        }


        /** @brief Metodo que se activa cuando el usuario selecciona un diseño del dropdown, llena la informacion correspondiente a ese diseño.
         * @param Los parametros por default de un evento de C#.
        */
        protected void drop_diseno_asociado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ("" != drop_diseno_asociado.SelectedItem.Value)
            {
                int id_diseno_seleccionado = Convert.ToInt32(drop_diseno_asociado.SelectedItem.Value);
                drop_id_requerimientos.Enabled = true;
                drop_diseno_asociado.Enabled = true;
                actualiza_requerimientos(id_diseno_seleccionado);
                actualiza_caso_de_pruebas_disponibles();
                label_id_diseno.Text = drop_diseno_asociado.SelectedItem.Value;
            }
            else {
                label_id_diseno.Text = "ID diseño";
                drop_id_requerimientos.Items.Clear();
                label_id_diseno.Font.Italic = true;
                drop_id_requerimientos.Enabled = false;
            }
            
        }

        /** @brief Metodo que actualiza la tabla de requerimientos disponibles con la información más reciente.
        */
        private void actualiza_requerimientos(int id_diseno)
        {
            vacia_requerimientos();
            if (!llena_requerimientos_disponibles(id_diseno))
            {
                cuerpo_alerta_error.Text = "Este diseño no tiene requerimientos asociados, no es posible asignarle un caso de pruebas.";
                drop_id_requerimientos.Enabled = false;
                alerta_error.Visible = true;
            }
        }
        //Ya está

        /** @brief Metodo que se encarga de llenar el comboBox con los proyectos que hay en la base de datos.
        */
        private bool llena_requerimientos_disponibles(int id_diseno)
        {
            bool resultado = true;
            DataTable tabla_requerimientos = m_controladora_dp.solicitar_requerimientos_asociados(id_diseno);
            ListItem primer_elemento = new ListItem();
            primer_elemento.Text = "-Asociar requerimiento -";
            primer_elemento.Value = "";
            drop_id_requerimientos.Items.Add(primer_elemento);

            if (tabla_requerimientos.Rows.Count == 0) {
                resultado = false;
                primer_elemento.Text = "-No hay requerimientos-";
            } 
            for (int i = 0; i < tabla_requerimientos.Rows.Count; ++i)
            {
                ListItem item_proyecto = new ListItem();
                item_proyecto.Text = tabla_requerimientos.Rows[i]["id_requerimiento"].ToString();
                item_proyecto.Value = Convert.ToString(tabla_requerimientos.Rows[i]["id_requerimiento"]);
                drop_id_requerimientos.Items.Add(item_proyecto);
            }
            return resultado;
        }

        /** @brief Metodo que vacia por completo la tabla de los requerimientos disponibles.
        */
        private void vacia_requerimientos()
        {
            drop_id_requerimientos.Items.Clear();
        }



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
            DataTable tabla_proyectos;
            ListItem primer_elemento = new ListItem();
            primer_elemento.Text = "-Seleccione un proyecto-";
            primer_elemento.Value = "";
            drop_proyecto_asociado.Items.Add(primer_elemento);
            if (m_es_administrador)
            {
                tabla_proyectos = m_controladora_pdp.solicitar_proyectos_no_eliminados();
            }
            else
            {
                tabla_proyectos = m_controladora_pdp.consultar_mi_proyecto(Context.User.Identity.Name);
            }
            for (int i = 0; i < tabla_proyectos.Rows.Count; ++i)
            {
                ListItem item_proyecto = new ListItem();
                item_proyecto.Text = tabla_proyectos.Rows[i]["nombre_proyecto"].ToString();
                item_proyecto.Value = Convert.ToString(tabla_proyectos.Rows[i]["id_proyecto"]);
                drop_proyecto_asociado.Items.Add(item_proyecto);
            }
        }

        /** @brief Metodo que actualiza la tabla de disenos asociados a un proyecto de pruebas con la información más reciente.
         * @param El identificador del proyecto
        */
        private void actualiza_disenos_asociados(int id_proyecto)
        {
            vaciar_disenos();
            llenar_disenos_asociados(id_proyecto);
        }

        /** @brief Metodo que vacia por completo la tabla de los disenos disponibles.
        */
        private void vaciar_disenos()
        {
            drop_diseno_asociado.Items.Clear();
        }

        /** @brief Metodo que se encarga de llenar el DropBox con los disenos asociados de un proyecto que hay en la base de datos.
         * @param El identificador del proyecto.
        */
        private void llenar_disenos_asociados(int id_proyecto)
        {
            DataTable tabla_disenos_asociados = m_controladora_dp.solicitar_disenos_asociados_proyecto(id_proyecto);
            ListItem primer_elemento = new ListItem();
            primer_elemento.Text = "-Seleccione un diseño-";
            primer_elemento.Value = "";
            drop_diseno_asociado.Items.Add(primer_elemento);
            for (int i = 0; i < tabla_disenos_asociados.Rows.Count; ++i)
            {
                ListItem item_diseno = new ListItem();
                item_diseno.Text = tabla_disenos_asociados.Rows[i]["nombre_diseno"].ToString();
                item_diseno.Value = Convert.ToString(tabla_disenos_asociados.Rows[i]["id_diseno"]);
                drop_diseno_asociado.Items.Add(item_diseno);
            }

        }

        private void actualiza_caso_de_pruebas_disponibles()
        {
            vacia_caso_de_pruebas_disponibles();
            llenar_caso_de_pruebas_disponibles();
        }

        private void vacia_caso_de_pruebas_disponibles()
        {
            tabla_casos_pruebas.Rows.Clear();
        }


        /** @brief Llena el área de consulta con los recursos humanos que hay en la base de datos.
                   Para esto crea la tabla dinámicamente.
         */
        private void llenar_caso_de_pruebas_disponibles()
        {
            crea_encabezado_tabla_cdp();
            if (0!=drop_diseno_asociado.Items.Count && "" != drop_diseno_asociado.SelectedItem.Value)
            {
                int diseno_asociado = Convert.ToInt32(drop_diseno_asociado.SelectedItem.Value);
                DataTable caso_de_pruebas_disponibles = m_controladora_cdp.solicitar_casos_pruebas_disponibles(diseno_asociado);

                for (int i = caso_de_pruebas_disponibles.Rows.Count-1; i>0; i--)
                {
                    TableRow fila = new TableRow();
                    TableCell celda_id = new TableCell();
                    TableCell celda_proposito = new TableCell();
                    Button btn = new Button();
                    btn.ID = caso_de_pruebas_disponibles.Rows[i]["id_caso"].ToString();
                    btn.CssClass = "btn btn-link";
                    btn.Click += new EventHandler(btn_lista_Clicked);

                    // Se inserta la información a la tabla
                    btn.Text = caso_de_pruebas_disponibles.Rows[i]["id_caso"].ToString();
                    celda_proposito.Text = caso_de_pruebas_disponibles.Rows[i]["proposito"].ToString();

                    celda_id.Controls.AddAt(0, btn);
                    fila.Cells.AddAt(0, celda_id);
                    fila.Cells.AddAt(1, celda_proposito);

                    tabla_casos_pruebas.Rows.Add(fila);
                }
            }            
        }

        /** @brief Metodo que crea el encabezado para la tabla de los recursos humanos.
         */
        private void crea_encabezado_tabla_cdp()
        {
            TableHeaderRow header = new TableHeaderRow();
            TableHeaderCell celda_header_id_caso_prueba = new TableHeaderCell();
            TableHeaderCell celda_header_proposito = new TableHeaderCell();
            celda_header_id_caso_prueba.Text = "ID del caso de prueba";
            header.Cells.AddAt(0, celda_header_id_caso_prueba);
            celda_header_proposito.Text = "Propósito de el caso de prueba";
            header.Cells.AddAt(1, celda_header_proposito);
            tabla_casos_pruebas.Rows.Add(header);
        }

        #region Métodos relacionados a entradas de datos


        #endregion


    }
}