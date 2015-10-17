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
using System.Text.RegularExpressions;
using System.Data;

namespace SAPS.Fronteras
{
    /** @brief La clase frontera de proyectos de pruebas se encarga de obtener los datos y eventos ingresados por el usuario y enviarlos a la clase controladora proyectos_de_pruebas. 
    */
    public partial class InterfazProyectosDePruebas : System.Web.UI.Page
    {

        private ControladoraProyectoPruebas m_controladora_pdp;     // Instacia de la clase controladora
        private static char opcion_tomada;                          // i= insertar, m= modificar, e= eliminar

        private Object[,] m_tabla_resultados; //posicion: 0-> nombre proyecto, 1-> id_proyecto
        private int m_tamano_tabla;

        /** @brief Constructor inicial de la pagina, se encarga de cargar los elementos basicos iniciales de cada seccion.
        */
        protected void Page_Load(object sender, EventArgs e)
        {
            alerta_error.Visible = false;
            alerta_exito.Visible = false;
            alerta_advertencia.Visible = false;
            alerta_exito_oficina.Visible = false;
            alerta_error_oficina.Visible = false;

            m_controladora_pdp = new ControladoraProyectoPruebas();
            opcion_tomada = 'i';
            activa_desactiva_botones_ime(false);
            input_manager_office.Enabled = false;
            input_phone1.Enabled = false;
            input_phone2.Enabled = false;
            // Se llenan las tablas de Grid
            //llena_disenos_prueba();   // TO DO --> Sprint 2, cuando ya existan diseños de pruebas.                                        
            llena_proyectos_de_pruebas();

        }

        /** @brief Una vez que el usuario selecciona un proyecto del Grid, se activa el evento btn_lista_click
                    permitiendo que se bloqueen elementos de entrada y se habiliten botones de edicion
         * @param Los parametros por default de un evento de C#.
        */
        private void btn_lista_click(object sender, EventArgs e)
        {
            activa_desactiva_botones_ime(true);
            activa_desactiva_inputs(false);
        }

        /** @brief Boton encargado de cancelar todos los cambios realizados por el usuario al proyecto de pruebas.
        * @param Los parametros por default de un evento de C#.
        */
        protected void btn_cancelar_click(object sender, EventArgs e)
        {
            activa_desactiva_botones_ime(false);
            limpia_campos();
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
            // Hace falta realizar modificar y eliminar, solo esta validando insertar
            if (valida_campos())
            {
                alerta_exito.Visible = true;
            }
            else
            {
                alerta_error.Visible = true;
            }
        }

        /** @brief Se habilitan las areas especificas del proyecto de pruebas para que el usuario pueda modificar los valores de forma adecuada.
         * @param Los parametros por default de un evento de C#.
        */
        protected void btn_modificar_click(object sender, EventArgs e)
        {
            opcion_tomada = 'm';
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
            opcion_tomada = 'e';
            activa_desactiva_botones_ime(true);
            activa_desactiva_inputs(false);
            btn_eliminar.CssClass = "btn btn-default activa";
            btn_crear.CssClass = "btn btn-default";
            btn_modificar.CssClass = "btn btn-default";
        }

        protected void btn_crear_click(object sender, EventArgs e)
        {
            opcion_tomada = 'i';
            activa_desactiva_inputs(true);
            limpia_campos();
            activa_desactiva_botones_ime(false);
            btn_eliminar.CssClass = "btn btn-default";
            btn_crear.CssClass = "btn btn-default active";
            btn_modificar.CssClass = "btn btn-default";
        }

        protected void btn_modal_cancelar_Click(object sender, EventArgs e)
        { //TO DO
        }

        protected void btn_modal_aceptar_Click(object sender, EventArgs e)
        {
            // TO DO
        }


        protected void btn_agregar_oficina_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modal_agregar_oficina", "$('#modal_agregar_oficina').modal();", true);
            upModalOficina.Update();
        }

        protected void btn_modal_cancelar_oficina_Click(object sender, EventArgs e)
        {

        }

        protected void btn_modal_agregar_oficina_Click(object sender, EventArgs e)
        {
            // TO DO --> todavia no muestra mensaje de confirmacion o de error.
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
                    alerta_exito_oficina.Text = " No hubo problema al ingresar la oficina.";
                    alerta_exito_oficina.Visible = true;
                    upModalOficina.Update();
                }
                else
                {
                    alerta_error_oficina.Text = " No fue posible agregar la oficina, intentelo nuevamente.";
                    alerta_error_oficina.Visible = true;
                    upModalOficina.Update();
                }
            }
            else
            {
                alerta_error_oficina.Visible = true;
                upModalOficina.Update();
            }
        }

        // ------------------------------------------
        // |    Metodos auxiliares de la clase      |
        // ------------------------------------------

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
            //input_phone1.Enabled = estado;
            //input_phone2.Enabled = estado;
            //input_manager_office.Enabled = estado;
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

        /** @brief Se encarga de llenar la tabla de proyectos de pruebas que contiene a todos los proyectos, dentro de la base de datos.
        **/
        private void llena_proyectos_de_pruebas()
        {
            // TO DO --> Es necesario llenar con los resultados de la base de datos
            for (int i = 0; i < 30; ++i)
            {
                TableRow fila = new TableRow();
                TableCell celda = new TableCell();
                Button btn = new Button();
                btn.ID = "btn_lista2_" + i.ToString();
                btn.Text = "pdp " + i.ToString();
                btn.CssClass = "btn btn-link btn-block";
                btn.Click += new EventHandler(btn_lista_click);
                celda.Controls.AddAt(0, btn);
                fila.Cells.Add(celda);
                tabla_proyectos_de_pruebas.Rows.Add(fila);
            }
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
            opcion_tomada = 'i';
            activa_desactiva_inputs(true);
            btn_eliminar.CssClass = "btn btn-default";
            btn_crear.CssClass = "btn btn-default";
            btn_modificar.CssClass = "btn btn-default";
            alerta_advertencia.Visible = false;
            alerta_error.Visible = false;
            alerta_exito.Visible = false;
            alerta_exito_oficina.Visible = false;
            alerta_error_oficina.Visible = false;
        }

        /** @brief Se validan todos los campos en los cuales el usuario puede ingresar datos, si existen errores, se notifica al usuario.
        */
        private bool valida_campos()
        {
            bool respuesta = true;
            if (opcion_tomada == 'e')
            {
                if (input_system.Text != "")
                {
                    // TO DO
                    //int resultado = m_controladora_pdp.eliminar_proyecto(input_system.Text);

                    // manejar el resultado de la base de datos
                }
                else
                {
                    cuerpo_alerta_error.Text = "Es necesario ingresar el nombre del sistema.";
                    SetFocus(input_system);
                    respuesta = false;
                }
            }
            else
            {
                if (input_system.Text != "")
                {
                    if (input_process.Text != "")
                    {
                        if (input_objective.Text != "")
                        {
                            if (drop_oficina_asociada.Text != "")
                            {
                                if (drop_estado_proyecto.Text != "")
                                {
                                    if (input_start_date.Text != "")
                                    {
                                        if (input_asignment_date.Text != "")
                                        {
                                            if (input_finish_date.Text != "")
                                            {

                                                Object[] datos = new Object[9];

                                                datos[2] = input_system.Text;                       // Nombre del sistema
                                                datos[5] = input_process.Text;                      // Nombre de proyecto                                                    
                                                datos[6] = input_start_date.Text;                   // Fecha de inicio del proyecto
                                                datos[8] = input_finish_date;                       // Fecha de finalizacion del proyecto
                                                datos[4] = input_objective.Text;                    // Objetivo general
                                                datos[1] = drop_oficina_asociada.Text;              // Oficina asociada
                                                datos[3] = drop_estado_proyecto.Text;               // Estado del proyecto
                                                datos[7] = input_asignment_date.Text;               // Fecha de asignacion

                                                int resultado;
                                                if (opcion_tomada == 'i')
                                                {
                                                    resultado = m_controladora_pdp.insertar_proyecto(datos);
                                                }
                                                else
                                                {
                                                    resultado = m_controladora_pdp.modificar_proyecto(datos);
                                                }

                                                cuerpo_alerta_exito.Text = "Su operación ha sido exitosa.";
                                                respuesta = true;

                                            }
                                            else
                                            {
                                                cuerpo_alerta_error.Text = "Es necesario ingresar una fecha de finalización del proyecto.";
                                                SetFocus(input_finish_date);
                                                respuesta = false;
                                            }
                                        }
                                        else
                                        {
                                            cuerpo_alerta_error.Text = "Es necesario ingresar una fecha de asignación del proyecto.";
                                            SetFocus(input_asignment_date);
                                            respuesta = false;
                                        }
                                    }
                                    else
                                    {
                                        cuerpo_alerta_error.Text = "Es necesario ingresar una fecha de inicio del proyecto.";
                                        SetFocus(input_manager_office);
                                        respuesta = false;
                                    }
                                }
                            }
                        }
                        else
                        {
                            cuerpo_alerta_error.Text = "Es necesario ingresar un objetivo.";
                            SetFocus(input_objective);
                            respuesta = false;
                        }
                    }
                    else
                    {
                        cuerpo_alerta_error.Text = "Es necesario ingresar un nombre de proceso.";
                        SetFocus(input_process);
                        respuesta = false;
                    }
                }
                else
                {
                    cuerpo_alerta_error.Text = "Es necesario ingresar un nombre de sistema.";
                    SetFocus(input_system);
                    respuesta = false;
                }
            }
            return respuesta;
        }
    }
}