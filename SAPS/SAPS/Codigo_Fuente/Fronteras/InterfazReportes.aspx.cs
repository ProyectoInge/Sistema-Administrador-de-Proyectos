/*
 * Universidad de Costa Rica
 * Escuela de Ciencias de la Computación e Informática
 * Ingeniería de Software I
 * Sistema Administrador de Proyectos de Software (SAPS)
 * II Semestre 2015
*/

using SAPS.Controladoras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SAPS.Fronteras
{
    public partial class InterfazReportes : System.Web.UI.Page
    {
        #region Variables de instancia
        ///Variables de instancia
        private static bool m_es_administrador;
        private static ControladoraReportes m_controladora_rep;


        /* |   Indice  | Significado    | Tipo  |
        *  |:---------:|:--------------:|:-----:|
        *  |     0     |   ID Proyecto  |  int  |
        *  |     1     |   Estado       |  bool |
            */
        private static List<Pair> m_proyectos; //Va a tener los proyectos que se estan mostrando en la interfaz


        /*  |   Indice  | Significado    | Tipo  |
         *  |:---------:|:--------------:|:-----:|
         *  |     0     |   ID Diseño    |  int  |
         *  |     1     |   Estado       |  bool |
             */
        private static List<Pair> m_disenos; //Va a tener los diseños que se estan mostrando en la interfaz


        /*
         * |   Indice  | Significado    |   Tipo   |
         * |:---------:|:--------------:|:--------:|
         * |     0     |   ID Caso      |  string  |
         * |     1     |   Estado       |  bool    |
             */
        private static List<Pair> m_casos; //Va a tener los casos que se estan mostrando en la interfaz


        /* |   Indice  | Significado    |                 Tipo                     |
        *  |:---------:|:--------------:|:----------------------------------------:|
        *  |     0     |  ID Ejecucion  |  Pair<int id_diseno, int num_ejecucion>  |
        *  |     1     |   Estado       |                 bool                     |
             */
        private static List<Pair> m_ejecuciones; //Va a tener las ejecuciones que se estan mostrando en la interfaz

        /* Estos booleanos funcionan para saber si hay que habilitar o deshabilitar los campos en los paneles.
        */
        private static bool m_habilitado_proyecto;
        private static bool m_habilitado_disenos;
        private static bool m_habilitado_casos;
        private static bool m_habilitado_ejecuciones;

        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                alerta_advertencia.Visible = false;
                alerta_error.Visible = false;
                alerta_exito.Visible = false;
                m_controladora_rep = new ControladoraReportes();
                if (!IsPostBack)    //Primera vez que carga la pagina
                {
                    m_proyectos = new List<Pair>();
                    m_casos = new List<Pair>();
                    m_disenos = new List<Pair>();
                    m_ejecuciones = new List<Pair>();
                    m_es_administrador = m_controladora_rep.es_administrador(Context.User.Identity.Name);
                    actualizar_oficinas();
                    actualizar_recursos_humanos();
                    llenar_lista_proyectos();   // ******** Esto es nuevo ********
                    llenar_lista_disenos();     // ******** Esto también lol *****
                    m_habilitado_proyecto = true;
                    m_habilitado_disenos = false;
                    m_habilitado_casos = false;
                    m_habilitado_ejecuciones = false;
                    btn_generar_reporte.Enabled = false;
                }
                else
                {

                }
                actualiza_proyectos_disponibles();

                // ***** Esto siempre tienen que dejarlo al final del Page_Load
                habilitar_deshabilitar_paneles();
            }
            else
            {
                Response.Redirect("~/Codigo_Fuente/Fronteras/InterfazLogin.aspx");
            }

        }

        /** @brief Metodo que se encarga de habilitar o deshabilitar los paneles.
        */
        private void habilitar_deshabilitar_paneles()
        {
            habilita_deshabilita_panel_proyectos();
            habilita_deshabilita_panel_disenos();
            habilita_deshabilita_panel_casos();
            habilita_deshabilita_panel_ejecuciones();
        }

        /** @brief Metodo que habilita o deshabilita el panel de los proyectos
        */
        private void habilita_deshabilita_panel_proyectos()
        {
            //Filtros
            proyecto_btn_continuar.Disabled = !m_habilitado_proyecto;
            proyecto_btn_limpiar_filtros.Enabled = m_habilitado_proyecto;
            proyecto_drop_estado.Enabled = m_habilitado_proyecto;
            proyecto_drop_miembro.Enabled = m_habilitado_proyecto;
            proyecto_drop_oficina.Enabled = m_habilitado_proyecto;
            proyecto_input_fecha_final.Enabled = m_habilitado_proyecto;
            proyecto_input_fecha_inicio.Enabled = m_habilitado_proyecto;

            //Checks
            proyecto_check_todos.Enabled = m_habilitado_proyecto;

            //Tabla de los proyectos disponibles
            if (tabla_proyectos.Rows.Count > 0)
                foreach (TableRow fila in tabla_proyectos.Rows)
                    ((CheckBox)fila.Cells[1].Controls[0]).Enabled = m_habilitado_proyecto;

        }

        /** @brief Metodo que habilita o deshabilita el panel de los diseños
        */
        private void habilita_deshabilita_panel_disenos()
        {
            //Filtros
            diseno_btn_continuar.Disabled = !m_habilitado_disenos;
            diseno_btn_volver.Disabled = !m_habilitado_disenos;
            diseno_btn_limpiar_filtros.Enabled = m_habilitado_disenos;
            diseno_drop_nivel_prueba.Enabled = m_habilitado_disenos;
            diseno_drop_responsables.Enabled = m_habilitado_disenos;
            diseno_drop_tecnicas_prueba.Enabled = m_habilitado_disenos;
            diseno_drop_tipo_prueba.Enabled = m_habilitado_disenos;
            diseno_fecha_antes.Enabled = m_habilitado_disenos;
            diseno_fecha_despues.Enabled = m_habilitado_disenos;

            //Checks
            diseno_check_todos.Enabled = m_habilitado_disenos;

            //Tabla de los disenos disponibles
            if (tabla_disenos.Rows.Count > 0)
                foreach (TableRow fila in tabla_disenos.Rows)
                    ((CheckBox)fila.Cells[1].Controls[0]).Enabled = m_habilitado_disenos;

        }

        /** @brief Metodo que habilita o deshabilita el panel de los casos
        */
        private void habilita_deshabilita_panel_casos()
        {
            //Botones
            casos_btn_continuar.Disabled = !m_habilitado_casos;
            casos_btn_volver.Disabled = !m_habilitado_casos;

            //Checks
            Checkbox_casos_de_prueba_todos.Enabled = m_habilitado_casos;

            //Tabla de los casos disponibles
            if (tabla_casos_de_prueba_disponibles.Rows.Count > 0)
                foreach (TableRow fila in tabla_casos_de_prueba_disponibles.Rows)
                    ((CheckBox)fila.Cells[1].Controls[0]).Enabled = m_habilitado_casos;
        }

        /** @brief Metodo que habilita o deshabilita el panel de las ejecuciones
        */
        private void habilita_deshabilita_panel_ejecuciones()
        {
            //Filtros
            ejecucion_btn_volver.Disabled = !m_habilitado_ejecuciones;
            btn_listo.Disabled = !m_habilitado_ejecuciones;
            ejecucion_btn_limpiar_filtros.Enabled = m_habilitado_ejecuciones;
            ejecucion_drop_responsables.Enabled = m_habilitado_ejecuciones;
            ejecucion_input_fecha.Enabled = m_habilitado_ejecuciones;

            //Checks
            check_ejecuciones_todos.Enabled = m_habilitado_ejecuciones;

            //Tabla
            if (tabla_ejecuciones_disponibles.Rows.Count > 0)
                foreach (TableRow fila in tabla_ejecuciones_disponibles.Rows)
                    ((CheckBox)fila.Cells[1].Controls[0]).Enabled = m_habilitado_ejecuciones;
        }

        /** @brief Metodo que carga todos los proyectos que hay en el sistema en la lista de pairs con los IDs de los proyectos y el estado.
        */
        private void llenar_lista_proyectos()
        {
            DataTable todos_proyectos = m_controladora_rep.solicitar_proyectos_disponibles();
            foreach (DataRow fila_tmp in todos_proyectos.Rows)
            {
                Pair pair_tmp = new Pair();
                pair_tmp.First = fila_tmp["id_proyecto"].ToString();
                pair_tmp.Second = false;
                m_proyectos.Add(pair_tmp);
            }
        }

        /** @brief Metodo que actualiza los proyectos que hay en el sistema en la interfaz
        */
        private void actualiza_proyectos_disponibles()
        {
            vacia_proyectos_disponibles();
            llena_proyectos_disponibles();
        }

        /** @brief Metodo que borra todas las filas de la tabla de los proyectos
        */
        private void vacia_proyectos_disponibles()
        {
            tabla_proyectos.Rows.Clear();
        }

        /** @brief Metodo que se activa cuando el usuario selecciona una casilla de los proyectos, lo marca como seleccionado en la estructura de control interno.
        */
        protected void check_estado_proyecto_Cambia(object sender, EventArgs e)
        {
            int id_proyecto_seleccionado = Convert.ToInt32(((CheckBox)sender).ID);
            int indice_proyecto = buscar_proyecto_en_lista(id_proyecto_seleccionado);
            m_proyectos[indice_proyecto].Second = Convert.ToBoolean(((CheckBox)sender).Checked);

        }

        /** @brief Metodo que revisa los filtros que selecciono el usuario para elegir los proyectos que cumplan estos filtros.
         *  @return Un DataTable con todos los proyectos que cumplan los filtros.
        */
        private DataTable obtener_proyectos_filtrados()
        {
            Object[] filtros = new Object[5];
            int oficina_seleccionada = -1;
            if (proyecto_drop_oficina.SelectedItem.Value != "")
                oficina_seleccionada = Int32.Parse(proyecto_drop_oficina.SelectedItem.Value);
            filtros[0] = oficina_seleccionada;
            filtros[1] = default(DateTime);
            if (proyecto_input_fecha_inicio.Text != "")
                filtros[1] = DateTime.Parse(proyecto_input_fecha_inicio.Text);
            filtros[2] = default(DateTime);
            if (proyecto_input_fecha_final.Text != "")
                filtros[2] = DateTime.Parse(proyecto_input_fecha_final.Text);

            filtros[3] = proyecto_drop_miembro.SelectedItem.Value;
            filtros[4] = proyecto_drop_estado.SelectedItem.Value;

            return m_controladora_rep.solicitar_proyectos_filtrados(filtros);
        }

        /** @brief Metodo que llena la tabla con los proyectos que hay disponibles en el sistema.
         */
        private void llena_proyectos_disponibles()
        {
            DataTable proyectos_disponibles = obtener_proyectos_filtrados();

            for (int i = 0; i < proyectos_disponibles.Rows.Count; ++i)
            {

                //Agrego el elemento a la tabla que se muestra en la vista
                TableRow fila_tmp = new TableRow();
                TableCell celda_tmp = new TableCell();

                celda_tmp.Text = proyectos_disponibles.Rows[i]["nombre_proyecto"].ToString();
                fila_tmp.Cells.Add(celda_tmp);

                celda_tmp = new TableCell();
                CheckBox check_tmp = new CheckBox();
                check_tmp.ID = proyectos_disponibles.Rows[i]["id_proyecto"].ToString();
                check_tmp.CheckedChanged += new EventHandler(check_estado_proyecto_Cambia);
                check_tmp.AutoPostBack = true;
                check_tmp.Checked = Convert.ToBoolean(m_proyectos[buscar_proyecto_en_lista(Convert.ToInt32(check_tmp.ID))].Second);
                check_tmp.CssClass = "checkbox-inline";
                celda_tmp.Controls.Add(check_tmp);

                //Esto es para poner la fila en rojo indicando que el proyecto fue eliminado
                if (Convert.ToBoolean(proyectos_disponibles.Rows[i]["eliminado"]))
                    fila_tmp.CssClass = "danger";

                fila_tmp.Cells.Add(celda_tmp);
                tabla_proyectos.Rows.Add(fila_tmp);

            }
        }

        /** @brief Metodo que actualiza el drop de las oficinas en la interfaz.
        */
        private void actualizar_oficinas()
        {
            vaciar_oficinas();
            llenar_oficinas();
        }

        /** @brief Metodo que vacia el drop de las oficinas disponibles
        */
        private void vaciar_oficinas()
        {
            proyecto_drop_oficina.Items.Clear();
        }

        /** @brief Metodo que llena el drop con las oficinas que hay en el sistema.
        */
        private void llenar_oficinas()
        {
            DataTable oficinas_disponibles = m_controladora_rep.solicitar_oficinas_disponibles();
            ListItem item_tmp = new ListItem();
            item_tmp.Text = "-Seleccione-";
            item_tmp.Value = "";
            proyecto_drop_oficina.Items.Add(item_tmp);
            foreach (DataRow fila in oficinas_disponibles.Rows)
            {
                item_tmp = new ListItem();
                item_tmp.Text = fila["nombre_oficina"].ToString();
                item_tmp.Value = fila["id_oficina"].ToString();
                proyecto_drop_oficina.Items.Add(item_tmp);
            }
        }

        /** @brief Metodo que actualiza el drop de los recursos humanos para agregar al filtrado.
        */
        private void actualizar_recursos_humanos()
        {
            vaciar_recursos_humanos();
            llena_recursos_humanos();
        }

        /** @brief Metodo que vacia el drop de los recursos humanos en la vista.
        */
        private void vaciar_recursos_humanos()
        {
            proyecto_drop_miembro.Items.Clear();
        }

        /** @brief Metodo que llena con los recursos humanos que hay en el sistema el drop en la interfaz.
        */
        private void llena_recursos_humanos()
        {
            DataTable recursos_disponibles = m_controladora_rep.solicitar_recursos_disponibles();
            ListItem item_tmp = new ListItem();
            item_tmp.Text = "-Seleccione-";
            item_tmp.Value = "";
            proyecto_drop_miembro.Items.Add(item_tmp);
            foreach (DataRow fila in recursos_disponibles.Rows)
            {
                if (!m_controladora_rep.es_administrador(fila["username"].ToString()))   //Solo agrega los que no son administradores
                {
                    item_tmp = new ListItem();
                    item_tmp.Text = fila["nombre"].ToString();
                    item_tmp.Value = fila["username"].ToString();
                    proyecto_drop_miembro.Items.Add(item_tmp);
                }
            }
        }

        protected void btn_generar_reporte_Click(object sender, EventArgs e)
        {
            ///@todo
        }
        

        /** @brief Metodo que se encarga de marcar todos los proyectos como "seleccionados" tanto en interfaz como en la estructura de control interno.
         *  @param Los parametros por defecto de un evento en ASP.
        */
        protected void proyecto_check_todos_CheckedChanged(object sender, EventArgs e)
        {
            bool estado = ((CheckBox)sender).Checked;
            foreach (TableRow fila in tabla_proyectos.Rows)
            {
                ((CheckBox)fila.Cells[1].Controls[0]).Checked = estado;
                ((CheckBox)fila.Cells[1].Controls[0]).Enabled = !estado;
                int id_proyecto = Convert.ToInt32(((CheckBox)fila.Cells[1].Controls[0]).ID);
                int indice_proyecto = buscar_proyecto_en_lista(id_proyecto);
                if (indice_proyecto != -1)
                    m_proyectos[indice_proyecto].Second = estado;
            }
        }

        /** @brief Metodo que buscar por un proyecto en especifico en la lista de los proyectos
         *  @param El identificador del proyecto que se desea buscar
         *  @return El indice en base 0 en la lista de los proyectos, -1 si no lo encontro.
        */
        private int buscar_proyecto_en_lista(int id_proyecto_buscar)
        {
            int a_retornar = -1;
            bool encontrado = false;
            int indice = 0;
            while (!encontrado && indice < m_proyectos.Count)
            {
                if (Convert.ToInt32(m_proyectos[indice].First) == id_proyecto_buscar)
                {
                    a_retornar = indice;
                    encontrado = true;
                }
                ++indice;
            }
            return a_retornar;
        }

        /** @brief Metodo que limpia los campos de los filtros en el panel de los proyectos
         *  @param Los parametros por defecto de un evento de ASP
        */
        protected void proyecto_btn_limpiar_filtros_Click(object sender, EventArgs e)
        {
            proyecto_drop_estado.ClearSelection();
            proyecto_drop_miembro.ClearSelection();
            proyecto_drop_oficina.ClearSelection();
            proyecto_drop_estado.Items[0].Selected = true;
            proyecto_drop_miembro.Items[0].Selected = true;
            proyecto_drop_oficina.Items[0].Selected = true;
            proyecto_input_fecha_final.Text = "";
            proyecto_input_fecha_inicio.Text = "";
            actualiza_proyectos_disponibles();
        }


        #region Métodos relacionados con panel casos de pruebas

        /** @brief Método que cargará los casos de prueba para mostrar en  el panel.
        *          Este método revisa los diseños para obtener los casos de prueba relacionados. 
        */
        protected void obtener_casos_de_prueba()
        {
            List<int> llaves_disenos = new List<int>();
            foreach (Pair item in m_disenos)
            {
                if (Convert.ToBoolean(item.Second)) llaves_disenos.Add(Convert.ToInt32(item.First));
            }

            DataTable casos_de_prueba_disponibles = m_controladora_rep.obtener_casos_de_prueba(llaves_disenos);
            for (int i = 0; i < casos_de_prueba_disponibles.Rows.Count; ++i)
            {
                // Lo agrego a la estructura que lleva control de los proyectos
                string id_caso = casos_de_prueba_disponibles.Rows[i]["id_caso"].ToString();
                m_casos.Add(new Pair(id_caso, false));

                // Agrego el elemento a la tabla que se muestra en la vista
                TableRow fila_tmp = new TableRow();
                TableCell celda_tmp = new TableCell();

                celda_tmp.Text = id_caso;
                fila_tmp.Cells.Add(celda_tmp);

                celda_tmp = new TableCell();
                CheckBox check_tmp = new CheckBox();
                check_tmp.ID = id_caso;
                check_tmp.CheckedChanged += new EventHandler(check_estado_casos_Cambia);
                check_tmp.AutoPostBack = true;
                check_tmp.CssClass = "checkbox-inline";
                celda_tmp.Controls.Add(check_tmp);

                fila_tmp.Cells.Add(celda_tmp);
                tabla_casos_de_prueba_disponibles.Rows.Add(fila_tmp);
            }
        }

        protected void check_estado_casos_Cambia(object sender, EventArgs e)
        {
            string id_casos_seleccionado = ((CheckBox)sender).ID;
            int indice_casos = 0;
            bool encontrado = false;
            while (!encontrado && indice_casos < m_casos.Count)
            {
                if (m_casos[indice_casos].ToString() == id_casos_seleccionado)
                {
                    m_casos[indice_casos].Second = !(Convert.ToBoolean(m_casos[indice_casos].Second));
                    encontrado = true;
                }
                ++indice_casos;
            }
        }

        protected void Checkbox_casos_de_prueba_todos_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var item in m_casos)
            {
                item.Second = true;
            }
        }

        #endregion

        /** @brief Evento que limpia deja el valor por defecto en los dropdown de filtros para diseños
         *  @param Los parametros por defecto de un evento de ASP
        */
        protected void diseno_btn_limpiar_filtros_Click(object sender, EventArgs e)
        {
            diseno_drop_tecnicas_prueba.ClearSelection();
            diseno_drop_tipo_prueba.ClearSelection();
            diseno_drop_nivel_prueba.ClearSelection();
            diseno_drop_responsables.ClearSelection();
            diseno_fecha_antes.Text = "";
            diseno_fecha_despues.Text = "";
            diseno_drop_tecnicas_prueba.Items[0].Selected = true;
            diseno_drop_tipo_prueba.Items[0].Selected = true;
            diseno_drop_nivel_prueba.Items[0].Selected = true;
            if (diseno_drop_responsables.Items.Count > 0)
                diseno_drop_responsables.Items[0].Selected = true;
            ///@todo Llamar a actualizar_disenos()
        }


        ///@brief metodo que trae todos los ids de disenos de la BD e inicializa m_disenos
        protected void llenar_lista_disenos()
        {
            DataTable all_disenos = m_controladora_rep.solicitar_disenos_disponibles();
            foreach (DataRow fila_it in all_disenos.Rows)
            {
                Pair pair_tmp = new Pair();
                pair_tmp.First = fila_it["id_diseno"].ToString();
                pair_tmp.Second = false;
                m_disenos.Add(pair_tmp);
            }
        }

        ///@brief metodo que construye lista de todos los ids de proyectos seleccionados

        protected List<string> get_selected_projects()
        {
            List<string> lista_seleccionados = new List<string>();
            for (int i = 0; i < m_proyectos.Count; i++)
            {
                if (Convert.ToBoolean(m_proyectos[i].Second) == true)
                {
                    lista_seleccionados.Add(Convert.ToString(m_proyectos[i].First));
                }
            }
            return lista_seleccionados;
        }

        ///@brief metodo que busca en m_disenos el id de diseno y devuelve true o false segun esté o no seleccionado.
        protected bool get_check_selected_diseno(string id_diseno)
        {
            foreach (Pair pair_tmp in m_disenos)
            {
                if (Convert.ToString(pair_tmp.First) == id_diseno)
                    return Convert.ToBoolean(pair_tmp.Second);
            }

            //deberia ser unreachable 
            return false;
        }     

        ///@brief metodo que obtiene todos los disenos segun los filtros y devuelve la lista de strings[] (id, nombre, checked) de los filtrados
        protected List<string[]> get_lista_disenos_filtrados()
        {
            Object[] sql_param = new Object[5];
            List<string[]> lista_pares_disenos_seleccionados = new List<string[]>();

            //obtiene los proyectos que se seleccionaron
            List<string> lista_seleccionados = get_selected_projects();

            //se construye el Object[] de parametros
            Object[] parametros = new Object[7];
            parametros[0] = diseno_drop_tecnicas_prueba.SelectedItem.Value;
            parametros[1] = diseno_drop_tipo_prueba.SelectedItem.Value;
            parametros[2] = diseno_drop_nivel_prueba.SelectedItem.Value;
            parametros[3] = diseno_drop_responsables.SelectedItem.Value;
            parametros[4] = default(DateTime);
            if (diseno_fecha_despues.Text != "")
                parametros[4] = DateTime.Parse(diseno_fecha_despues.Text);
            parametros[5] = default(DateTime);
            if (diseno_fecha_antes.Text != "")
                parametros[5] = DateTime.Parse(diseno_fecha_antes.Text);
            parametros[6] = lista_seleccionados;


            DataTable disenos_filtrados = m_controladora_rep.solicitar_disenos_filtrados(parametros);
            
            foreach (DataRow fila_tmp in disenos_filtrados.Rows)
            {
                string[] pair_tmp = new string[3];
                pair_tmp[0] = fila_tmp["id_diseno"].ToString();
                pair_tmp[1] = fila_tmp["nombre_diseno"].ToString();
                pair_tmp[2] = Convert.ToString(get_check_selected_diseno(Convert.ToString(pair_tmp[0])));
                lista_pares_disenos_seleccionados.Add(pair_tmp);             
            }

            return lista_pares_disenos_seleccionados;
        }

        protected void llena_tabla_disenos()
        {
            List<string[]> lista_pares_disenos_filtrados = get_lista_disenos_filtrados();

            foreach (string[] array_tmp in lista_pares_disenos_filtrados)
            {
                TableRow fila_tmp = new TableRow();

                TableCell celda_nombre_tmp = new TableCell();
                celda_nombre_tmp.Text = Convert.ToString(array_tmp[1]);
                fila_tmp.Cells.Add(celda_nombre_tmp);

                TableCell celda_chck_tmp = new TableCell();
                CheckBox check_tmp = new CheckBox();
                check_tmp.ID = array_tmp[0];
                check_tmp.CheckedChanged += new EventHandler(check_estado_disenos_Cambia);
                check_tmp.AutoPostBack = true;
                check_tmp.Checked = Convert.ToBoolean(array_tmp[2]);
                check_tmp.CssClass = "checkbox-inline";
                fila_tmp.Cells.Add(celda_chck_tmp);                
            }
        }

        ///@brief cambia el valor en m_disenos de seleccion del diseno, se activa cuando se checkea el compa
        private void check_estado_disenos_Cambia(object sender, EventArgs e)
        {
            int id_diseno_seleccionado = Convert.ToInt32(((CheckBox)sender).ID);
            int it_disenos = 0;
            bool encontrado = false;
            while (!encontrado && it_disenos < m_disenos.Count)
            {
                if (m_disenos[it_disenos].First.Equals(id_diseno_seleccionado))
                {
                    m_disenos[it_disenos].Second = !(Convert.ToBoolean(m_disenos[it_disenos].Second)); //Si esta seleccionado (true) lo deselecciono (lo paso a false) y si esta en false, lo paso a true
                    encontrado = true;
                }
                ++it_disenos;
            }
        }

        protected void diseno_drop_tecnicas_prueba_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void diseno_drop_tipo_prueba_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void diseno_drop_nivel_prueba_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void diseno_check_todos_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void ejecucion_btn_limpiar_filtros_Click(object sender, EventArgs e)
        {
            ejecucion_drop_responsables.ClearSelection();
            if (ejecucion_drop_responsables.Items.Count > 0)
                ejecucion_drop_responsables.Items[0].Selected = true;
            ejecucion_input_fecha.Text = "";
            ///@todo Llamar a actualizar ejecuciones
        }

        protected void check_ejecuciones_todos_CheckedChanged(object sender, EventArgs e)
        {

        }

        // ---------------------------------------------- Botones de continuar y volver ----------------------------------------------
        protected void proyecto_btn_continuar_ServerClick(object sender, EventArgs e)
        {
            bool alguno_seleccionado = false;
            int indice = 0;
            //Busco si existe al menos un elemento marcado como seleccionado.
            do
            {
                if (Convert.ToBoolean(m_proyectos[indice].Second))
                    alguno_seleccionado = true;
                ++indice;
            } while (!alguno_seleccionado && indice < m_proyectos.Count);
            if (alguno_seleccionado)//Existe alguno seleccionado
            {
                m_habilitado_proyecto = false;
                m_habilitado_disenos = true;
                m_habilitado_casos = false;
                m_habilitado_ejecuciones = false;
                habilitar_deshabilitar_paneles();
        }
            else
        {
                cuerpo_alerta_advertencia.Text = " Es necesario que seleccione al menos un proyecto para poder continuar.";
                alerta_advertencia.Visible = true;
        }
        }

        protected void diseno_btn_volver_ServerClick(object sender, EventArgs e)
        {
            m_habilitado_proyecto = true;
            m_habilitado_disenos = false;
            m_habilitado_casos = false;
            m_habilitado_ejecuciones = false;
            habilitar_deshabilitar_paneles();
        }

        protected void diseno_btn_continuar_ServerClick(object sender, EventArgs e)
        {
            m_habilitado_proyecto = false;
            m_habilitado_disenos = false;
            m_habilitado_casos = true;
            m_habilitado_ejecuciones = false;
            habilitar_deshabilitar_paneles();
        }


        protected void casos_btn_volver_ServerClick(object sender, EventArgs e)
        {
            m_habilitado_proyecto = false;
            m_habilitado_disenos = true;
            m_habilitado_casos = false;
            m_habilitado_ejecuciones = false;
            habilitar_deshabilitar_paneles();
        }

        protected void casos_btn_continuar_ServerClick(object sender, EventArgs e)
        {
            m_habilitado_proyecto = false;
            m_habilitado_disenos = false;
            m_habilitado_casos = false;
            m_habilitado_ejecuciones = true;
            habilitar_deshabilitar_paneles();
        }

        protected void ejecuciones_btn_volver_ServerClick(object sender, EventArgs e)
        {
            m_habilitado_proyecto = false;
            m_habilitado_disenos = false;
            m_habilitado_casos = true;
            m_habilitado_ejecuciones = false;
            habilitar_deshabilitar_paneles();
        }

        protected void ejecucion_btn_volver_ServerClick(object sender, EventArgs e)
        {
            m_habilitado_proyecto = true;
            m_habilitado_disenos = false;
            m_habilitado_casos = false;
            m_habilitado_ejecuciones = false;
            habilitar_deshabilitar_paneles();
        }

        protected void btn_listo_ServerClick(object sender, EventArgs e)
        {
            btn_generar_reporte.Enabled = true;
        }
    }
}
 
