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

namespace SAPS.Codigo_Fuente.Fronteras

    /*@brief La clase frontera de proyectos de pruebas se encarga de obtener los datos y eventos ingresados por el usuario
            y enviarlos a la clase controladora proyectos_de_pruebas. 
        
    **/
{
    public partial class InterfazProyectosDePruebas : System.Web.UI.Page
    {

        private ControladoraProyectoPruebas m_controladora_pdp;         // Instacia de la clase controladora

        char opcion_tomada;                                             // Opciones de valor: i= insertar, m= modificar, b= borrar


        /** @brief Constructor inicial de la pagina, se encarga de cargar los elementos basicos
                    iniciales de cada seccion.
        */
        protected void Page_Load(object sender, EventArgs e)
        {
            alerta_error.Visible = false;
            alerta_exito.Visible = false;

            m_controladora_pdp = new ControladoraProyectoPruebas();
            opcion_tomada = 'i';
            activa_desactiva_botones_ime(false);
            llena_disenos_prueba();                                                 // Se llenan las tablas de Grid
            llena_proyectos_de_pruebas();

        }

        /** @brief Una vez que el usuario selecciona un proyecto del Grid, se activa el evento btn_lista_click
                    permitiendo que se bloqueen elementos de entrada y se habiliten botones de edicion
            * @param Los parametros por default de un evento de C#.
        */
        private void btn_lista_click(object sender, EventArgs e) {
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

        /** @brief Boton encargado de cargar los datos de un proyecto de pruebas seleccionado del Grid, en la pantalla
                    principal.
            * @param Los parametros por default de un evento de C#.
        */
        protected void btn_consultar_click(object sender, EventArgs e) {
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
            else {
                alerta_error.Visible = true;
            }
        }

        /**@brief Se habilitan las areas especificas del proyecto de pruebas para que el usuario pueda modificar
                    los valores de forma adecuada.
            * @param Los parametros por default de un evento de C#.
        */
        protected void btn_modificar_click(object sender, EventArgs e)
        {
            opcion_tomada = 'm';
            activa_desactiva_botones_ime(true);
            activa_desactiva_inputs(true);
            btn_eliminar.BackColor = System.Drawing.Color.White;
            btn_crear.BackColor = System.Drawing.Color.White;
            btn_modificar.BackColor = System.Drawing.Color.LightGray;
        }

        /**@brief Evento que se activa cuando el usuario selecciona el boton eliminar
        * @param Los parametros por default de un evento de C#.
        */
        protected void btn_eliminar_click(object sender, EventArgs e)
        {
            opcion_tomada = 'e';
            activa_desactiva_botones_ime(true);
            activa_desactiva_inputs(false);
            btn_eliminar.BackColor = System.Drawing.Color.LightGray;
            btn_crear.BackColor = System.Drawing.Color.White;
            btn_modificar.BackColor = System.Drawing.Color.White;
        }

        protected void btn_crear_click(object sender, EventArgs e)
        {
            opcion_tomada = 'i';
            activa_desactiva_inputs(true);
            limpia_campos();
            activa_desactiva_botones_ime(false);
            btn_eliminar.BackColor = System.Drawing.Color.White;
            btn_crear.BackColor = System.Drawing.Color.LightGray;
            btn_modificar.BackColor = System.Drawing.Color.White;
        }


        // ------------------------------------------
        // |    Metodos auxiliares de la clase      |
        // ------------------------------------------

        /** @brief Pone activos los botones de "Eliminar" y "Modificar"
        * @param Bool con el estado de activacion de los botones ime (true/false)
        */
        private void activa_desactiva_botones_ime(bool estado) {
            btn_modificar.Enabled = estado;
            btn_eliminar.Enabled = estado;
        }

        /** @brief Habilita o deshabilita todas las areas de texto o input dadas al usuario
                   en la interfaz.

        */
        private void activa_desactiva_inputs(bool estado) {
            input_system.Enabled = estado;
            input_process.Enabled = estado;
            input_leader.Enabled = estado;
            input_phone1.Enabled = estado;
            input_phone2.Enabled = estado;
            drop_oficina_asociada.Enabled = estado;
            drop_estado_proyecto.Enabled = estado;
            input_manager_office.Enabled = estado;
            input_objective.Enabled = estado;
        }


        /**@brief Se encarga de llenar la tabla de disenos de pruebas con todos los
                  disenos asociados a dicho proyecto de pruebas.

        */
        private void llena_disenos_prueba() {

            // Es necesario llenar con los resultados de la base de datos

            for (int i = 0; i < 30; ++i)
            {
                TableRow fila = new TableRow();
                TableCell celda = new TableCell();
                Button btn = new Button();
                btn.ID = "btn_lista_" + i.ToString();
                btn.Text = "dp " + i.ToString();
                btn.CssClass = "btn btn-link btn-block";
                btn.Click += new EventHandler(btn_lista_click);
                celda.Controls.AddAt(0, btn);
                fila.Cells.Add(celda);
                tabla_disenos_de_prueba.Rows.Add(fila);
            }

        }

        /** @brief Se encarga de llenar la tabla de proyectos de pruebas que contiene a todos
                   los proyectos, dentro de la base de datos.
        **/
        private void llena_proyectos_de_pruebas()
        {

            // Es necesario llenar con los resultados de la base de datos

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

        /** @brief Metodo encargado de retornar todos los espacios e ingresos del sistema a su estado
                    original. Incluyendo ademas botones y eventos.
        */
        private void limpia_campos() {
            input_system.Text = "";
            input_process.Text = "";
            input_leader.Text = "";
            input_phone1.Text = "";
            input_phone2.Text = "";
            input_manager_office.Text = "";
            input_objective.Text = "";
            opcion_tomada = 'i';
            activa_desactiva_inputs(true);
            btn_crear.BackColor = System.Drawing.Color.White;
            btn_eliminar.BackColor = System.Drawing.Color.White;
            btn_modificar.BackColor = System.Drawing.Color.White;
        }

        /** @brief Se validan todos los campos en los cuales el usuario puede ingresar datos, si existen errores, se notifica al usuario.
        *
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
            else {
                if (input_system.Text != "")
                {
                    if (input_process.Text != "")
                    {
                        if (input_leader.Text != "")
                        {
                            if (input_objective.Text != "")
                            {
                                if (drop_oficina_asociada.Text != "")
                                {
                                    if (input_phone1.Text != "")
                                    {
                                        if (input_phone2.Text != "")
                                        {
                                            if (input_manager_office.Text != "")
                                            {
                                                if (drop_estado_proyecto.Text != "")
                                                {
                                                    Object[] datos = new Object[9];
                                                    datos[0] = input_system.Text;
                                                    datos[1] = input_process.Text;
                                                    datos[2] = input_leader.Text;
                                                    datos[3] = input_objective.Text;
                                                    datos[4] = drop_oficina_asociada.Text;
                                                    datos[5] = input_phone1.Text;
                                                    datos[6] = input_phone2.Text;
                                                    datos[7] = input_manager_office.Text;
                                                    datos[8] = drop_estado_proyecto.Text;


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
                                            }
                                            else
                                            {
                                                cuerpo_alerta_error.Text = "Es necesario ingresar un representante de oficina.";
                                                SetFocus(input_manager_office);
                                                respuesta = false;
                                            }
                                        }
                                        else
                                        {
                                            cuerpo_alerta_error.Text = "Es necesario ingresar un segundo número telefónico.";
                                            SetFocus(input_phone2);
                                            respuesta = false;
                                        }
                                    }
                                    else
                                    {
                                        cuerpo_alerta_error.Text = "Es necesario ingresar un número telefónico.";
                                        SetFocus(input_phone1);
                                        respuesta = false;
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
                            cuerpo_alerta_error.Text = "Es necesario ingresar un líder de proyecto.";
                            SetFocus(input_leader);
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
                else {
                    cuerpo_alerta_error.Text = "Es necesario ingresar un nombre de sistema.";
                    SetFocus(input_system);
                    respuesta = false;
                }
            }
            return respuesta;
        }
    }
}