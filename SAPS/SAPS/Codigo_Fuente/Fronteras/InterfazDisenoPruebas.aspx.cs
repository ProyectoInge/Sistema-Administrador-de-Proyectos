using System;
using System.Collections.Generic;
using SAPS.Controladoras;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SAPS.Fronteras
{
    public partial class InterfazDisenoPruebas : System.Web.UI.Page
    {

        private static ControladoraDisenosPruebas m_controladora_dp;
        private static ControladoraRecursosHumanos m_controladora_rh;
        private static ControladoraProyectoPruebas m_controladora_pyp;
        private static ControladoraRequerimientos m_controladora_req;

        private static char m_opcion = 'i'; // i = insertar, m = modificar, e = eliminar
        private static bool m_es_administrador;   // true si el usuario de la sesion es administrador, false si no.

        private static Object[,] m_tabla_proyectos_disponibles;
        private static int m_tamano_tabla_pyp;

        private static Object[,] m_tabla_rh;
        private static int m_tamano_tabla_rh;

        private static List<Tuple<string, int>> m_tabla_requerimientos_disponibles;
        private static int m_tamano_tabla_req;

        private static List<Tuple<string, int>> m_tabla_requerimientos_seleccionados;
        private static int m_tamano_tabla_seleccionados;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                m_controladora_dp = new ControladoraDisenosPruebas();
                m_controladora_rh = new ControladoraRecursosHumanos();
                m_controladora_pyp = new ControladoraProyectoPruebas();
                m_controladora_req = new ControladoraRequerimientos();
        alerta_error.Visible = false;
                alerta_exito.Visible = false;
                alerta_advertencia.Visible = false;

                if (!IsPostBack)
                {
                    m_es_administrador = m_controladora_rh.es_administrador(Context.User.Identity.Name);
                    actualiza_proyectos();

                    carga_requerimientos_nuevo();

                    //actualiza_rh();
                }
                //actualiza_tabla_disenos();
                refrescar_requerimientos();
            }
            else
            {
                Response.Redirect("~/Codigo_Fuente/Fronteras/InterfazLogin.aspx");
            }
        }

        /** @brief Método que carga los proyectos existentes en el combo box.
        */
        protected void actualiza_proyectos()
        {
            vacia_proyectos();
            llena_proyectos_disponibles();
        }

        /** @brief Método que vacía el combobox de proyectos.
        */
        protected void vacia_proyectos()
        {
            drop_proyecto.Items.Clear();
        }

        /** @brief Método que llena los proyectos en el combo box.
        */
        protected void llena_proyectos_disponibles()
        {
            DataTable tabla_proyectos;
            if (m_es_administrador)
            {
                tabla_proyectos = m_controladora_pyp.solicitar_proyectos_disponibles(); // cargo todos los recursos humanos
            }
            else
            {
                tabla_proyectos = m_controladora_pyp.consultar_mi_proyecto(Context.User.Identity.Name);   // cargo solo mi informacion
            }
            m_tamano_tabla_pyp = tabla_proyectos.Rows.Count;
            m_tabla_proyectos_disponibles = new Object[m_tamano_tabla_pyp, 2];

            
            ListItem item_proyecto = new ListItem();
            item_proyecto.Text = "";
            item_proyecto.Value = "";
            drop_proyecto.Items.Add(item_proyecto);

            for (int i = 0; i < m_tamano_tabla_pyp; ++i)
            {
                item_proyecto = new ListItem();
                m_tabla_proyectos_disponibles[i, 0] = Convert.ToInt32(tabla_proyectos.Rows[i]["id_proyecto"]);
                m_tabla_proyectos_disponibles[i, 1] = tabla_proyectos.Rows[i]["nombre_proyecto"].ToString();                
                item_proyecto.Text = Convert.ToString(m_tabla_proyectos_disponibles[i, 1]);
                item_proyecto.Value = Convert.ToString(m_tabla_proyectos_disponibles[i, 0]);
                drop_proyecto.Items.Add(item_proyecto);
            }
        }

        protected void carga_requerimientos_nuevo()
        {
            //crea_encabezado_tabla_rh();
            DataTable tabla_de_datos;

            tabla_de_datos = m_controladora_req.solicitar_requerimientos_disponibles(); // cargo todos los requerimientos


            //se inicializa la tabla interna de disponibles
            m_tamano_tabla_req = tabla_de_datos.Rows.Count;
            m_tabla_requerimientos_disponibles = new List<Tuple<string, int>>();

            //se inicializa la tabla interna de agregados (es nueva por lo tanto: 0)
            m_tamano_tabla_seleccionados = 0;
            m_tabla_requerimientos_seleccionados = new List<Tuple<string, int>>();



            for (int i = (m_tamano_tabla_req - 1); i >= 0; --i)
            {
               m_tabla_requerimientos_disponibles.Add(Tuple.Create(tabla_de_datos.Rows[i]["nombre"].ToString(), Convert.ToInt32(tabla_de_datos.Rows[i]["id_requerimiento"])));
            }
            refrescar_requerimientos();
        }

        private void carga_requerimientos_transicion(string nombre_requerimiento, int id_req, bool agregar) //agregar 1: se agrega, agregar 0: se desasocia
        {
            if (agregar)
            {
                m_tabla_requerimientos_disponibles.RemoveAll(item => item.Item1 == nombre_requerimiento);
                m_tamano_tabla_req--;
                m_tamano_tabla_seleccionados++;
                m_tabla_requerimientos_seleccionados.Add(Tuple.Create(nombre_requerimiento, id_req));
            }
            else
            {
                m_tabla_requerimientos_seleccionados.RemoveAll(item => item.Item1 == nombre_requerimiento);
                m_tamano_tabla_req++;
                m_tamano_tabla_seleccionados--;
                m_tabla_requerimientos_disponibles.Add(Tuple.Create(nombre_requerimiento, id_req));
            }

            refrescar_requerimientos();
        }

        private void consultar_disenos()
        {

        }

        private bool ingresar_diseno()
        {
            bool a_retornar = true;
            if (input_nombre.Text != "")
            {
                if(drop_proyecto.Text != "")
                {
                    if(drop_nivel.Text != "")
                    {
                        if(drop_tecnica.Text != "")
                        {
                            if(drop_tipo.Text != "")
                            {
                                if(input_ambiente.Text != "")
                                {
                                    if(input_criterio.Text != "")
                                    {
                                        if(input_procedimiento.Text != "")
                                        {
                                            if(drop_responsable.Text != "")
                                            {
                                                if (input_fecha.Text != "")
                                                {
                                                    Object[] datosDiseno = new Object[8];
                                                    datosDiseno[0] = 0;
                                                    datosDiseno[1] = Convert.ToInt32(drop_proyecto.SelectedValue);
                                                    datosDiseno[2] = input_nombre.Text;
                                                    datosDiseno[3] = DateTime.Parse(input_fecha.Text);
                                                    datosDiseno[4] = drop_tecnica.SelectedValue;
                                                    datosDiseno[5] = drop_tipo.SelectedValue;
                                                    datosDiseno[6] = drop_nivel.SelectedValue;
                                                    datosDiseno[7] = drop_responsable.SelectedValue;
                                                    
                                                    int resultado = m_controladora_dp.insertar_diseno_pruebas(datosDiseno);
                                                    DataTable diseños = m_controladora_dp.solicitar_disenos_disponibles();
                                                    int id_agregado = Convert.ToInt32(diseños.Rows[diseños.Rows.Count - 1]["id_diseno"]);

                                                    for (int i = 0; i < m_tabla_requerimientos_seleccionados.Count; i++)
                                                    {
                                                        Object[] datosAsoc = new Object[5];
                                                    }


                                                    if (resultado == 0)
                                                    {
                                                        cuerpo_alerta_exito.Text = " Se ha insertado un nuevo diseño correctamente.";
                                                        //actualiza_grid();
                                                    }
                                                    else
                                                    {
                                                        cuerpo_alerta_error.Text = " No se logró insertar el diseño, intente nuevamente.";
                                                        a_retornar = false;
                                                    }
                                                }
                                                else
                                                {
                                                    cuerpo_alerta_error.Text = "Es necesario seleccionar una fecha.";
                                                    SetFocus(input_fecha);
                                                    a_retornar = false;
                                                }
                                            }
                                            else
                                            {
                                                cuerpo_alerta_error.Text = "Es necesario seleccionar un responsable.";
                                                SetFocus(drop_responsable);
                                                a_retornar = false;
                                            }
                                        }
                                        else
                                        {
                                            cuerpo_alerta_error.Text = "Es necesario ingresar el procedimiento de prueba.";
                                            SetFocus(input_procedimiento);
                                            a_retornar = false;
                                        }
                                    }
                                    else
                                    {
                                        cuerpo_alerta_error.Text = "Es necesario ingresar un criterio de prueba.";
                                        SetFocus(input_criterio);
                                        a_retornar = false;
                                    }
                                }
                                else
                                {
                                    cuerpo_alerta_error.Text = "Es necesario ingresar un ambiente de prueba..";
                                    SetFocus(input_ambiente);
                                    a_retornar = false;
                                }
                            }
                            else
                            {
                                cuerpo_alerta_error.Text = "Es necesario seleccionar un tipo de prueba.";
                                SetFocus(drop_tipo);
                                a_retornar = false;
                            }
                        }
                        else
                        {
                            cuerpo_alerta_error.Text = "Es necesario seleccionar una técnica de prueba.";
                            SetFocus(drop_tecnica);
                            a_retornar = false;
                        }
                    }
                    else
                    {
                        cuerpo_alerta_error.Text = "Es necesario seleccionar un nivel de prueba.";
                        SetFocus(drop_nivel);
                        a_retornar = false;
                    }
                }
                else
                {
                    cuerpo_alerta_error.Text = "Es necesario seleccionar un proyecto.";
                    SetFocus(drop_proyecto);
                    a_retornar = false;
                }
            }
            else
            {
                cuerpo_alerta_error.Text = "Es necesario ingresar un nombre de diseño.";
                SetFocus(input_nombre);
                a_retornar = false;
            }
            if (a_retornar == false)
            {
                alerta_error.Visible = true;
            }

            return a_retornar;
        }

        private void refrescar_requerimientos()
        {
            tabla_disponibles.Rows.Clear();
            tabla_agregados.Rows.Clear();
            
            for (int i = 0; i < m_tamano_tabla_req; i++)
            {
                TableRow fila = new TableRow();
                TableCell celda_boton = new TableCell();
                Button btn = new Button();
                btn.ID = "btn_lista_disponibles_" + i.ToString();
                btn.Text = m_tabla_requerimientos_disponibles[i].Item1;
                btn.CssClass = "btn btn-link";
                btn.Click += new EventHandler(btn_lista_req_click_asociar);
                celda_boton.Text = Convert.ToString(m_tabla_requerimientos_disponibles[i]);
                celda_boton.Controls.AddAt(0, btn);
                fila.Cells.AddAt(0, celda_boton);
                tabla_disponibles.Rows.Add(fila);
            }
            for (int i = 0; i < m_tamano_tabla_seleccionados; i++)
            {
                TableRow fila = new TableRow();
                TableCell celda_boton = new TableCell();
                Button btn = new Button();
                btn.ID = "btn_lista_asociados_" + i.ToString();
                btn.Text = m_tabla_requerimientos_seleccionados[i].Item1;
                btn.CssClass = "btn btn-link";
                btn.Click += new EventHandler(btn_lista_req_click_asociar);
                celda_boton.Text = Convert.ToString(m_tabla_requerimientos_seleccionados[i]);
                celda_boton.Controls.AddAt(0, btn);
                fila.Cells.AddAt(0, celda_boton);
                tabla_agregados.Rows.Add(fila);
            }
        }

        /*
        private void carga_requerimientos_existente()
        {
            
        }
        */


        private void btn_lista_req_click_asociar(object sender, EventArgs e)
        {
            Button enviador = sender as Button;
            bool se_agrega = enviador.ID.StartsWith("btn_lista_disponibles");
            int id=0;
            if(se_agrega)
            {
                foreach(var coso in m_tabla_requerimientos_disponibles)
                {
                    if (coso.Item1.Equals(enviador.Text))
                        id = coso.Item2;
                }
            }else
            {
                foreach (var coso in m_tabla_requerimientos_seleccionados)
                {
                    if (coso.Item1.Equals(enviador.Text))
                        id = coso.Item2;
                }
            }
            carga_requerimientos_transicion(enviador.Text, id, se_agrega);

            
        }
        
        

        private void actualiza_rh(string id_proyecto)
        {
            DataTable tabla_rh= new DataTable();
            
                tabla_rh = m_controladora_rh.consultar_rh_asociados_proyecto(Convert.ToInt32(id_proyecto)); // cargo todos los recursos humanos, TODO cambiar a solo los de idproy

            m_tamano_tabla_rh = tabla_rh.Rows.Count;
            m_tabla_rh = new Object[m_tamano_tabla_rh, 2];


            ListItem item_rh = new ListItem();
            item_rh.Text = "";
            item_rh.Value = "";
            drop_responsable.Items.Add(item_rh);

            for (int i = 0; i < m_tamano_tabla_rh; ++i)
            {
                item_rh = new ListItem();
                m_tabla_rh[i, 0] = tabla_rh.Rows[i]["username"].ToString();
                m_tabla_rh[i, 1] = tabla_rh.Rows[i]["nombre"].ToString();
                item_rh.Text = Convert.ToString(m_tabla_rh[i, 1]);
                item_rh.Value = Convert.ToString(m_tabla_rh[i, 0]);
                drop_responsable.Items.Add(item_rh);
            }
        }
        //actualiza_tabla_disenos();


        protected void btn_Aceptar_Click(object sender, EventArgs e)
        {
            if(m_opcion == 'i')
            {
                ingresar_diseno();
            }
        }

        /** @brief Evento que se activa cuando el usuario selecciona la opción de "modificar".
        * @param Los parametros por default de un evento de C#.
        */
        protected void btn_modificar_Click(object sender, EventArgs e)
        {
            m_opcion = 'm';
            /*
            //btn_reestablece_contrasena.Visible = true;
            //activa_desactiva_inputs(true);
            //if (radio_btn_administrador.Checked == true)
            //{
                drop_rol.Enabled = false;
                drop_proyecto_asociado.Enabled = false;
            }
            activa_desactiva_botones_ime(true);
            input_contrasena.Enabled = false;
            input_usuario.Enabled = false;
            btn_eliminar.CssClass = "btn btn-default";
            btn_crear.CssClass = "btn btn-default";
            btn_modificar.CssClass = "btn btn-default active";
            if (!m_es_administrador)
            {
                radio_btn_administrador.Enabled = false;
            }
            */
        }

        /** @brief Evento que se activa cuando el usuario selecciona la opción de "eliminar".
         * @param Los parametros por default de un evento de C#.
        */
        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            /*
            if (m_es_administrador)
            {
                m_opcion = 'e';
                btn_reestablece_contrasena.Visible = false;
                activa_desactiva_inputs(false);
                activa_desactiva_botones_ime(true);
                btn_eliminar.CssClass = "btn btn-default active";
                btn_crear.CssClass = "btn btn-default";
                btn_modificar.CssClass = "btn btn-default";
            }
            else
            {
                cuerpo_alerta_advertencia.Text = " No está autorizado para eliminar recursos humanos.";
                alerta_advertencia.Visible = true;
            }
            */
        }

        /** @brief Evento que se activa cuando el usuario selecciona la opción de "insertar".
         * @param Los parametros por default de un evento de C#.
        */
        protected void btn_crear_Click(object sender, EventArgs e)
        {
            /*
            if (m_es_administrador)
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
            else
            {
                cuerpo_alerta_advertencia.Text = " No está autorizado para agregar recursos humanos.";
                alerta_advertencia.Visible = true;
            }
            */
        }

        protected void drop_proyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualiza_rh(drop_proyecto.SelectedItem.Value);
            drop_responsable.Enabled = true;
        }

        /** @brief Método que se activa al hacer click en el botón para administrar los requerimientos disponibles, lo redirecciona a la pantalla para administrar
                   los requerimientos.
         * @param Los parámetros típicos de un evento en C#.
        */
        protected void btn_admi_requerimientos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Codigo_Fuente/Fronteras/InterfazRequerimientos.aspx");
        }
    }
}