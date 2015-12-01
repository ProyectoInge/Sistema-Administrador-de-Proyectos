/*
 * Universidad de Costa Rica
 * Escuela de Ciencias de la Computación e Informática
 * Ingeniería de Software I
 * Sistema Administrador de Proyectos de Software (SAPS)
 * II Semestre 2015
*/
using SAPS.Base_de_Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.IO;



namespace SAPS.Controladoras
{
    public class ControladoraReportes
    {

        // Controladoras de las clases con las que interactua la clase EjecucionesPruebas
        private ControladoraRecursosHumanos m_controladora_rh;
        private ControladoraDisenosPruebas m_controladora_dp;
        private ControladoraCasoPruebas m_controladora_cp;
        private ControladoraProyectoPruebas m_controladora_pdp;

        


        ///@brief Constructor
        public ControladoraReportes()
        {
            m_controladora_rh = new ControladoraRecursosHumanos();
            m_controladora_pdp = new ControladoraProyectoPruebas();
            m_controladora_dp = new ControladoraDisenosPruebas();
            m_controladora_cp = new ControladoraCasoPruebas(); 
            /*
            var document = new Document(PageSize.A4, 50, 50, 25, 25);
            // Create a new PdfWrite object, writing the output to a MemoryStream

            var output = new FileStream(("C:\\Users\\Carlos_2\\Downloads\\Reporte1.pdf"), FileMode.Create);
            var writer = PdfWriter.GetInstance(document, output);

            // Open the Document for writing
            document.Open();


            Object []prueba = {-1, default(DateTime), default(DateTime),"","" };
            agregar_proyectos_PDF(ref document, prueba);

            document.Close();
            */

            //Constantes para el documento
            /*var fuente_titulo = FontFactory.GetFont("Arial", 18, Font.BOLD);
            var boldTableFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
            var info_general = new PdfPTable(2);
            info_general.HorizontalAlignment = 0;
            info_general.SpacingBefore = 10;
            info_general.SpacingAfter = 10;
            info_general.DefaultCell.Border = 0;
            info_general.SetWidths(new int[] { 1, 2 });

            info_general.AddCell(new Phrase("Nombre Proyecto: ", boldTableFont));
            info_general.AddCell("Aquí hay que meter la info");
            info_general.AddCell(new Phrase("Nombre Sistema: ", boldTableFont));
            info_general.AddCell("Aquí hay que meter la info");
            info_general.AddCell(new Phrase("Estado: ", boldTableFont));
            info_general.AddCell("Aquí hay que meter la info");

            // Create a Document object
            var document = new Document(PageSize.A4, 50, 50, 25, 25);

            // Create a new PdfWriter object, specifying the output stream
            var output = new FileStream(("C:\\Users\\Carlos_2\\Downloads\\Reporte1.pdf"), FileMode.Create);
            var writer = PdfWriter.GetInstance(document, output);

            // Open the Document for writing
            document.Open();

            // Create a new Paragraph object with the text, "Hello, World!"
            document.Add(new Paragraph("Proyectos Consultados", fuente_titulo));
            document.Add(info_general);
            var welcomeParagraph = new Paragraph("Aquí van los proyectos");
            var endParagraph = new Paragraph("Aquí van los diseños");

            
            // Add the Paragraph object to the document
            document.Add(welcomeParagraph);
            document.NewPage();

            document.Add(endParagraph);

            // Close the Document - this saves the document contents to the output stream
            document.Close();*/

        }


        /**@brief Método que agrega proyectos de pruebas a un PDF
        * @param document con la referencia al documento donde se van a agregar la información de los proyectos de pruebas
        * datos array con arrays que contienen información sobre los filtros y los espacios a mostrar.  
                |            Object [] datos            |
                |:--------0--------:||:--------1-------:|
                |   filtros []      || info a mostrar []|
        */

        private void agregar_proyectos_PDF(ref Document documento, Object[] datos)
        {
            DataTable info_proyectos = m_controladora_pdp.solicitar_proyectos_filtrados(datos);         
            for (int i = 0; i < info_proyectos.Rows.Count; ++i)
            {
                string contents = File.ReadAllText("E:\\Documentos\\GitHub\\Sistema-Administrador-de-Proyectos\\SAPS\\Plantillas HTML\\PYP.htm");

                contents = contents.Replace("[NOMBRE]", info_proyectos.Rows[i]["nombre_proyecto"].ToString());
                contents = contents.Replace("[NOMBRE_SISTEMA]", info_proyectos.Rows[i]["nombre_sistema"].ToString());
                contents = contents.Replace("[ESTADO]", info_proyectos.Rows[i]["estado"].ToString());
                var parsedHtmlElements = HTMLWorker.ParseToList(new StringReader(contents), null);
                foreach (var htmlElement in parsedHtmlElements)
                {
                    documento.Add(htmlElement as IElement);
                }
            }
        }

        public void generar_reporte_PDF(Object[] info_proyectos, Object[] info_disenos, Object[] info_casos, Object[] info_ejecuciones)
        {

            var document = new Document(PageSize.A4, 50, 50, 25, 25);
            // Create a new PdfWriter object, specifying the output stream
            //var output = new FileStream(("C:\\Users\\Carlos_2\\Downloads\\MyFirstPDF.pdf"), FileMode.Create);

            // Open the Document for writing
            document.Open();
            // Create a new Paragraph object with the text, "Hello, World!"
            var welcomeParagraph = new Paragraph("MPLP");

            // Add the Paragraph object to the document
            document.Add(welcomeParagraph);

            if (null != info_proyectos) agregar_proyectos_PDF(ref document, info_proyectos);//llamar método que devuelva n páginas con proyectos
            if (null != info_disenos); //llamar método que devuelva n páginas con disenos
            if (null != info_casos) ;  //llamar método que devuelva n páginas con casos
            if (null != info_ejecuciones) ; //llamar método que devuelva n páginas con ejecuciones

            // Close the Document - this saves the document contents to the output stream
            document.Close();

        }














        #region Métodos relacionados con otras controladoras

        /** @brief Metodo que consulta los proyectos disponibles en el sistema.
         *  @return DataTable con la informacion de los proyectos disponibles en la base de datos.
         */
        public DataTable solicitar_proyectos_disponibles()
        {
            m_controladora_pdp = new ControladoraProyectoPruebas();
            return m_controladora_pdp.solicitar_proyectos_disponibles();
        }

        /** @brief Método que asigna las operaciones necesarias para poder consultar mi proyecto de pruebas.
         * @param username de quien hace la consulta.
         * @return DataTable con los resultados de la consultas.
         */
        public DataTable consultar_mi_proyecto(string nombre_usuario)
        {
            m_controladora_pdp = new ControladoraProyectoPruebas();
            return m_controladora_pdp.consultar_mi_proyecto(nombre_usuario);
        }

        /** @brief Método que consulta el perfil de un usuario del sistema, permite que se mantenga la arquitectura N capas.
         * @param nombre_usuario usuario cuyo perfil se desea consultar.
         * @return false si es administrador, true si es miembro
        */
        public bool es_administrador(string nombre_usuario)
        {
            m_controladora_rh = new ControladoraRecursosHumanos();
            return m_controladora_rh.es_administrador(nombre_usuario);
        }

        /** @brief Método que asigna las operaciones necesarias para poder consultar las oficibas disponibles.
         * @return DataTable con los resultados de la consultas.
         */
        public DataTable solicitar_oficinas_disponibles()
        {
            m_controladora_pdp = new ControladoraProyectoPruebas();
            return m_controladora_pdp.solicitar_oficinas_disponibles();
        }


        /** @brief Método que asigna las operaciones necesarias para poder consultar los recursos humanos disponibles.
         * @return DataTable con los resultados de la consultas.
         */
        public DataTable solicitar_recursos_disponibles()
        {
            m_controladora_rh = new ControladoraRecursosHumanos();
            return m_controladora_rh.solicitar_recursos_disponibles();
        }

        /** @brief Metodo que se encarga de hacer una busqueda en los proyectos que cumplan con los filtros que selecciono el usuario.
         *  @param Vector de strings con los filtros de la siguiente manera:
                |   Indice  |   Filtro      |   Tipo    |
                |:---------:|:-------------:|:---------:|
                |   0       |   oficina     |   int     |
                |   1       | fecha_inicio  | DateTime  |
                |   2       | fecha_final   | DateTime  |
                |   3       |   estado      |   string  |
                |   4       |   miembro     |   string  |
                Si no desea filtrar, entonces en la posicion del filtro se envia "".
         *  @return Un DataTable en el que viene toda la información de los proyectos que cumplieron los filtros que se enviaron.
        */
        public DataTable solicitar_proyectos_filtrados(Object[] filtros)
        {
            return m_controladora_pdp.solicitar_proyectos_filtrados(filtros);
        }

        /** @brief Devuelve los casos de pruebas asociados a una lista de llaves primarias de disenos.
        *   @param llaves_disenos lista con las llaves primarias de los diseños
        */
        public DataTable obtener_casos_de_prueba(List<int> llaves_disenos)
        {
            return null;
        }



        //TEFO DOCUMENTE! ESTO NO ESTÁ BN 

        /** @brief Metodo que se encarga de hacer una busqueda en los proyectos que cumplan con los filtros que selecciono el usuario.
 *  @param Vector de strings con los filtros de la siguiente manera:
        |   Indice  |   Filtro      |   Tipo    |
        |:---------:|:-------------:|:---------:|
        |   0       |   oficina     |   int     |
        |   1       | fecha_inicio  | DateTime  |
        |   2       | fecha_final   | DateTime  |
        |   3       |   estado      |   string  |
        |   4       |   miembro     |   string  |
        Si no desea filtrar, entonces en la posicion del filtro se envia "".
 *  @return Un DataTable en el que viene toda la información de los proyectos que cumplieron los filtros que se enviaron.
*/

        public DataTable solicitar_disenos_filtrados(Object[] filtros)
        {
            return m_controladora_dp.solicitar_disenos_filtrados(filtros);
        }

        #endregion

    }
}