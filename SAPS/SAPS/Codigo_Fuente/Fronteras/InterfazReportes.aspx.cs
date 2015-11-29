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
using SAPS.Controladoras;
using System.Data;

namespace SAPS.Fronteras
{
    public partial class InterfazReportes : System.Web.UI.Page
    {
        #region Variables de instancia
        ///Variables de instancia
        private static bool m_es_administrador;
        private static ControladoraReportes m_controladora_rep;
        private static List<Pair> m_proyectos; //Va a tener los proyectos que se estan mostrando en la interfaz
        /*
            |   Indice  | Significado    | Tipo  |
            |:---------:|:--------------:|:-----:|
            |     0     |   ID Proyecto  |  int  |
            |     1     |   Estado       |  bool |
            */
        private static List<Pair> m_disenos; //Va a tener los diseños que se estan mostrando en la interfaz
        /*
             |   Indice  | Significado    | Tipo  |
             |:---------:|:--------------:|:-----:|
             |     0     |   ID Diseño    |  int  |
             |     1     |   Estado       |  bool |
             */
        private static List<Pair> m_casos; //Va a tener los casos que se estan mostrando en la interfaz
        /*
             |   Indice  | Significado    |   Tipo   |
             |:---------:|:--------------:|:--------:|
             |     0     |   ID Caso      |  string  |
             |     1     |   Estado       |  bool    |
             */
        private static List<Pair> m_ejecuciones; //Va a tener las ejecuciones que se estan mostrando en la interfaz
        /*
             |   Indice  | Significado    |                 Tipo                     |
             |:---------:|:--------------:|:----------------------------------------:|
             |     0     |  ID Ejecucion  |  Pair<int id_diseno, int num_ejecucion>  |
             |     1     |   Estado       |                 bool                     |
             */
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
                }
                else
                {

                }
                actualiza_proyectos_disponibles();
            }
            else
            {
                Response.Redirect("~/Codigo_Fuente/Fronteras/InterfazLogin.aspx");
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
            int indice_proyecto = 0;
            bool encontrado = false;
            while (!encontrado && indice_proyecto < m_proyectos.Count)
            {
                if (m_proyectos[indice_proyecto].First.Equals(id_proyecto_seleccionado))
                {
                    m_proyectos[indice_proyecto].Second = !(Convert.ToBoolean(m_proyectos[indice_proyecto].Second));    //Si esta seleccionado (true) lo deselecciono (lo paso a false) y si esta en false, lo paso a true
                    encontrado = true;
                }
                ++indice_proyecto;
            }

        }

        /** @brief Metodo que revisa los filtros que selecciono el usuario para elegir los proyectos que cumplan estos filtros.
         *  @return Un DataTable con todos los proyectos que cumplan los filtros.
        */
        private DataTable obtener_proyectos_filtrados()
        {
            Object[] filtros = new Object[5];
            int oficina_seleccionada = -1;
            if(proyecto_drop_oficina.SelectedItem.Value != "")
                oficina_seleccionada = Int32.Parse(proyecto_drop_oficina.SelectedItem.Value);
            filtros[0] = oficina_seleccionada;
            filtros[1] = default(DateTime);
            if (proyecto_input_fecha_inicio.Text != "")
                filtros[1] = DateTime.Parse(proyecto_input_fecha_inicio.Text);
            filtros[2] = default(DateTime);
            if(proyecto_input_fecha_final.Text != "")
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
                //Lo agrego a la estructura que lleva control de los proyectos
                Pair pareja_tmp = new Pair();
                pareja_tmp.First = Convert.ToInt32(proyectos_disponibles.Rows[i]["id_proyecto"]);
                pareja_tmp.Second = false;
                m_proyectos.Add(pareja_tmp);

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

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            ///@todo
        }

        /** @brief Metodo que se encarga de marcar todos los proyectos como "seleccionados" tanto en interfaz como en la estructura de control interno.
         *  @param Los parametros por defecto de un evento en ASP.
        */
        protected void proyecto_check_todos_CheckedChanged(object sender, EventArgs e)
        {
            bool estado = ((CheckBox)sender).Checked;
            if (estado)
            {
                for (int i = 0; i < m_proyectos.Count; ++i)
                {
                    m_proyectos[i].Second = estado;
                }
            }
            else
            {
                for (int i = 0; i < m_proyectos.Count; ++i)
                {
                    m_proyectos[i].Second = estado;
                }
            }

        }


        /** @brief Metodo que limpia los campos de los filtros en el panel de los proyectos
         *  @param Los parametros por defecto de un evento de ASP
        */
        protected void proyecto_btn_limpiar_filtros_Click(object sender, EventArgs e)
        {
            proyecto_drop_estado.ClearSelection();
            proyecto_drop_miembro.ClearSelection();
            proyecto_drop_oficina.ClearSelection();
            actualizar_oficinas();
            actualizar_recursos_humanos();
            actualiza_proyectos_disponibles();
            proyecto_input_fecha_final.Text = "";
            proyecto_input_fecha_inicio.Text = "";
        }

        protected void diseno_btn_limpiar_filtros_Click(object sender, EventArgs e)
        {

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
    }
}