using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPS.Entidades
{
    public class Resultados_EP
    {
        private int numero_resultado;
        private int id_diseno;
        private int numero_ejecucion;
        private string estado;
        private string tipo_no_conformidad;
        private string id_caso;
        private string desc_no_conformidad;
        private string justificacion;
        // variable que maneja la imagen, falta averiguar como ponerlo

        /* @brief Constructor de la entidad de resultados de ejecucion de pruebas.
        @param datos contiene los datos para poder crear un conjunto asociado a una ejecucion de pruebas, el orden va de la siguiente manera:
                             * | Índice | Descripción             | Tipo de datos |
                             * |:------:|:-----------------------:|:-------------:|
                             * |    0   |  Numero de resultado    |      int      |
                             * |    1   |  Id del diseno          |      int      |
                             * |    2   |  Numero de ejecucion    |      int      |
                             * |    3   |  Estado                 |     String    |
                             * |    4   |  Tipo No Conformidad    |     String    |
                             * |    5   |  Id del Caso            |     String    |
                             * |    6   |  Descripcion No Conf.   |     String    |
                             * |    7   |  Justificacion          |     String    |
                             * |    8   |  Imagen                 |    Averiguar  |
        * **/
        public Resultados_EP(Object[ ] datos)
        {
            numero_resultado = Convert.ToInt32(datos[0]);
            id_diseno = Convert.ToInt32(datos[1]);
            numero_ejecucion = Convert.ToInt32(datos[2]);
            estado = datos[3].ToString();
            tipo_no_conformidad = datos[4].ToString();
            id_caso = datos[5].ToString();
            desc_no_conformidad = datos[6].ToString();
            justificacion = datos[7].ToString();
            //imagen = datos[8]. analizar
        }

        public int num_resultado
        {
            get { return numero_resultado; }
            set { numero_resultado = value; }
        }

        public int identificador_diseno
        {
            get { return id_diseno; }
            set { id_diseno = value; }
        }

        public int num_ejecucion
        {
            get { return num_ejecucion; }
            set { num_ejecucion = value; }
        }

        public string estado_rep
        {
            get { return estado; }
            set { estado = value; }
        }

        public string tipo_no_conf
        {
            get { return tipo_no_conformidad; }
            set { tipo_no_conformidad = value; }
        }

        public string identificador_caso
        {
            get { return identificador_caso; }
            set { identificador_caso = value; }
        }

        public string descripcion_no_conformidad
        {
            get { return desc_no_conformidad; }
            set { desc_no_conformidad = value; }
        }

        public string justificacion_rep
        {
            get { return justificacion; }
            set { justificacion = value; }
        }
    }    
}