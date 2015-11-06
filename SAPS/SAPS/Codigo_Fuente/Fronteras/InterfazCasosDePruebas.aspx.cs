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
    public partial class InterfazCasosDePruebas : System.Web.UI.Page
    {
        private static ControladoraProyectoPruebas m_controladora_pdp;
        private static ControladoraDisenosPruebas m_controladora_dp;
        private static ControladoraRecursosHumanos m_controladora_rh;

        private static TableHeaderRow m_fila_header; // Es global ya que se tiene que modificar en ciertas ocaciones

        private static bool m_es_administrador;
        protected void Page_Load(object sender, EventArgs e)
        {
            alerta_error.Visible = false;
            alerta_exito.Visible = false;
            alerta_advertencia.Visible = false;
            m_controladora_dp = new ControladoraDisenosPruebas();
            m_controladora_pdp = new ControladoraProyectoPruebas();
            m_controladora_rh = new ControladoraRecursosHumanos();
            m_fila_header = new TableHeaderRow();

            if (!IsPostBack)
            {
                actualiza_proyectos();
                m_es_administrador = m_controladora_rh.es_administrador(Context.User.Identity.Name);
            }
            
        }

        /** @brief Evento que se activa cuando el usuario selecciona el boton de "cancelar".
         * @param Los parametros por default de un evento de C#.
        */
        protected void btn_cancelar_Click(object sender, EventArgs e)
        {

        }

        /** @brief Evento que se activa cuando el usuario selecciona el boton de "aceptar".
        * @param Los parametros por default de un evento de C#.
        */
        protected void btn_aceptar_Click(object sender, EventArgs e)
        {

        }

        /** @brief Evento que se activa cuando el usuario selecciona el boton de "crear".
        * @param Los parametros por default de un evento de C#.
        */
        protected void btn_crear_Click(object sender, EventArgs e)
        {

        }

        /** @brief Evento que se activa cuando el usuario selecciona el boton de "modificar".
        * @param Los parametros por default de un evento de C#.
        */
        protected void btn_modificar_Click(object sender, EventArgs e)
        {

        }

        /** @brief Evento que se activa cuando el usuario selecciona el boton de "eliminar".
       * @param Los parametros por default de un evento de C#.
       */
        protected void btn_eliminar_Click(object sender, EventArgs e)
        {

        }

        /** @brief Evento que se activa cuando el usuario selecciona el boton de "consultar".
         * @param Los parametros por default de un evento de C#.
        */
        protected void btn_consultar_Click(object sender, EventArgs e)
        {

        }

        /** @brief Metodo que se activa cuando el usuario selecciona un proyecto del dropdown, llena la informacion correspondiente a ese proyecto.
         * @param Los parametros por default de un evento de C#.
        */
        protected void drop_proyecto_asociado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drop_proyecto_asociado.SelectedItem.Value != "")
            {
                int id_proyecto_seleccionado = Convert.ToInt32(drop_proyecto_asociado.SelectedItem.Value);
                actualiza_disenos_asociados(id_proyecto_seleccionado);
            }
        }

        /** @brief Metodo que se activa cuando el usuario selecciona un diseño del dropdown, llena la informacion correspondiente a ese diseño.
         * @param Los parametros por default de un evento de C#.
        */
        protected void drop_diseno_asociado_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id_diseno_seleccionado = Convert.ToInt32(drop_diseno_asociado.SelectedItem.Value);
            actualiza_requerimientos(id_diseno_seleccionado);
        }


        /** @brief Método que se activa cuando el usuario hace click en el botón de "agregar entrada"
         * @param Los parametros por default de un evento de C#.
        */
        protected void btn_agregar_entrada_Click(object sender, EventArgs e)
        {
        }

        // ---------------------------------------------------- Métodos auxiliares ----------------------------------------------------


        /** @brief Metodo que actualiza la tabla de requerimientos disponibles con la información más reciente.
        */
        private void actualiza_requerimientos(int id_diseno)
        {
            vacia_requerimientos();
            llena_requerimientos_disponibles(id_diseno);
        }

        /** @brief Metodo que vacia por completo la tabla de los requerimientos disponibles.
        */
        private void vacia_requerimientos()
        {
            drop_requerimientos.Items.Clear();
        }

        /** @brief Metodo que se encarga de llenar el comboBox con los proyectos que hay en la base de datos.
        */
        private void llena_requerimientos_disponibles(int id_diseno)
        {
            DataTable tabla_requerimientos = m_controladora_dp.solicitar_requerimientos_asociados(id_diseno);
            ListItem primer_item = new ListItem();
            primer_item.Text = "";
            primer_item.Value = "";
            drop_requerimientos.Items.Add(primer_item);
            for (int i = 0; i < tabla_requerimientos.Rows.Count; ++i)
            {
                ListItem item_proyecto = new ListItem();
                item_proyecto.Text = tabla_requerimientos.Rows[i]["nombre"].ToString();
                item_proyecto.Value = Convert.ToString(tabla_requerimientos.Rows[i]["id_requerimiento"]);
                drop_requerimientos.Items.Add(item_proyecto);
            }

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
            DataTable tabla_proyectos = m_controladora_pdp.solicitar_proyectos_disponibles();
            ListItem primer_item = new ListItem();
            primer_item.Text = "";
            primer_item.Value = "";
            drop_proyecto_asociado.Items.Add(primer_item);
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
            ListItem primer_item = new ListItem();
            primer_item.Text = "";
            primer_item.Value = "";
            drop_diseno_asociado.Items.Add(primer_item);
            for (int i = 0; i < tabla_disenos_asociados.Rows.Count; ++i)
            {
                ListItem item_diseno = new ListItem();
                item_diseno.Text = tabla_disenos_asociados.Rows[i]["nombre_diseno"].ToString();
                item_diseno.Value = Convert.ToString(tabla_disenos_asociados.Rows[i]["id_diseno"]);
                drop_diseno_asociado.Items.Add(item_diseno);
            }

        }
    }
}