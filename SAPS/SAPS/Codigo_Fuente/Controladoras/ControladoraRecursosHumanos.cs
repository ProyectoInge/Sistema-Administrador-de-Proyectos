using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SAPS.Codigo_Fuente.Base_de_Datos;
using SAPS.Codigo_Fuente.Ayudantes;

namespace SAPS.Codigo_Fuente.Controladoras
{
    public class ControladoraRecursosHumanos
    {
        // Variables de instancia
        Seguridad m_seguridad;


        // Constructor
        public ControladoraRecursosHumanos()
        {

        }


        // Métodos

        public int insertar_recurso_humano(Object[] datos) 
        {
            return 0;
        }

        public int modificar_recurso_humano(Object[] datos) 
        {
            return 0;
        }

        public int eliminar_recurso_humano(string nombre_usuario) 
        {
            return 0;
        }
        
        public DataTable consultar_recurso_humano(string nombre_usuario)
        {
            return null;
        }

        public DataTable solicitar_recursos_disponibles()
        {
            return null;
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