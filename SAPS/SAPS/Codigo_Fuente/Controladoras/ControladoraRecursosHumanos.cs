using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SAPS.Entidades;
using SAPS.Codigo_Fuente.Base_de_Datos;

namespace SAPS.Codigo_Fuente.Controladoras
{
    public class ControladoraRecursosHumanos
    {
        // Variables de instancia
        BDRecursosHumanos m_base_datos;


        // Constructor
        public ControladoraRecursosHumanos()
        {
            m_base_datos = new BDRecursosHumanos();
        }


        // Métodos

        public int insertar_recurso_humano(Object[] datos) 
        {
            RecursoHumano recurso_humano = new RecursoHumano(datos);
            return m_base_datos.insertar_recurso_humano(recurso_humano);
        }

        public int modificar_recurso_humano(Object[] datos) 
        {
            RecursoHumano recurso_humano = new RecursoHumano(datos);
            return m_base_datos.modificar_recurso_humano(recurso_humano);
        }

        public int eliminar_recurso_humano(string nombre_usuario) 
        {
            return m_base_datos.eliminar_recurso_humano(nombre_usuario);
        }
        
        public DataTable consultar_recurso_humano(string nombre_usuario)
        {
            return m_base_datos.consultar_recurso_humano(nombre_usuario);
        }

        public DataTable solicitar_recursos_disponibles()
        {
            return m_base_datos.solicitar_recursos_disponibles();
        }

        // Módulo Seguridad
        public int restablecer_contrasena(string nombre_usuario, string nueva_contrasena) 
        {
            return 0;
        }

        public int autenticar(string nombre_usuario, string contrasena) 
        {
            return 0;
        }

        public int cerrar_sesion() 
        {
            return 0;
        }
    }
}