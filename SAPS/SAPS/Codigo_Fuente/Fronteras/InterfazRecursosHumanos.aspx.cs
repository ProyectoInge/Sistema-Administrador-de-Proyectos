﻿/*
 * Universidad de Costa Rica
 * Escuela de Ciencias de la Computación e Informática
 * Ingeniería de Software I
 * Sistema Administrador de Proyectos de Software (SAPS)
 * II Semestre 2015
 * --------------------------------------------------------------------------------------------
 * Esta clase frontera se encarga de obtener los datos y los eventos que el usuario selecciona,
 * se lo pasa a la controladora de la clase recurso_humano.
 * --------------------------------------------------------------------------------------------
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAPS.Codigo_Fuente.Controladoras;

namespace SAPS.Fronteras
{
    public partial class Recursos_Humanos : System.Web.UI.Page
    {
        ControladoraRecursosHumanos m_controladora_rh;
        protected void Page_Load(object sender, EventArgs e)
        {
            drop_proyecto_asociado.Enabled = false;
            drop_rol.Enabled = false;
            llena_recursos_humanos();

        }

        private void btn_lista_click(object sender, EventArgs e)
        {
            activa_botones_ime();
        }

        protected void btn_Cancelar_Click(object sender, EventArgs e)
        {
            limpia_campos();
        }

        protected void btn_consultar_Click(object sender, EventArgs e)
        {
            activa_botones_ime();
        }


        protected void radio_btn_miembro_CheckedChanged(object sender, EventArgs e)
        {
            drop_proyecto_asociado.Enabled = true;
            drop_rol.Enabled = true;
        }

        protected void radio_btn_administrador_CheckedChanged(object sender, EventArgs e)
        {
            drop_proyecto_asociado.Enabled = false;
            drop_rol.Enabled = false;
        }
        //Metodos auxiliares de la clase
        private void activa_botones_ime()
        {
            btn_eliminar.Enabled = true;
            btn_modificar.Enabled = true;
        }

        private void limpia_campos()
        {
            radio_btn_miembro.Checked = false;
            radio_btn_administrador.Checked = false;
            input_name.Text = "";
            input_correo.Text = "";
            input_telefono.Text = "";
            input_usuario.Text = "";
            input_contrasena.Text = "";
            btn_eliminar.Enabled = false;
            btn_modificar.Enabled = false;
            drop_proyecto_asociado.Enabled = false;
            drop_rol.Enabled = false;
        }

        private void llena_recursos_humanos()
        {
            for (int i = 0; i < 30; ++i)
            {
                TableRow fila = new TableRow();
                TableCell celda = new TableCell();
                Button btn = new Button();
                btn.ID = "btn_lista_" + i.ToString();
                btn.Text = "rh " + i.ToString();
                btn.CssClass = "btn btn-link btn-block";
                btn.Click += new EventHandler(btn_lista_click);
                celda.Controls.AddAt(0, btn);
                fila.Cells.Add(celda);
                tabla_recursos_humanos.Rows.Add(fila);
            }
        }
    }
}