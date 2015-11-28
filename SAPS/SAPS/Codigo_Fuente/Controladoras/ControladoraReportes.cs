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
using System.IO;

namespace SAPS.Controladoras
{
    public class ControladoraReportes
    {

        // Controladoras de las clases con las que interactua la clase EjecucionesPruebas
        private ControladoraRecursosHumanos m_controladora_rh;
        private ControladoraProyectoPruebas m_controladora_pyp;
        private ControladoraDisenosPruebas m_controladora_dp;
        private ControladoraCasoPruebas m_controladora_cp;

        


        ///@brief Constructor
        public ControladoraReportes()
        {
            m_controladora_rh = new ControladoraRecursosHumanos();
            m_controladora_dp = new ControladoraDisenosPruebas();
            m_controladora_cp = new ControladoraCasoPruebas();

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





        public void generar_reporte_PDF(Object[] info_proyectos, Object[] info_disenos, Object[] info_casos, Object[] info_ejecuciones) {

            var document = new Document(PageSize.A4, 50, 50, 25, 25);
            // Create a new PdfWriter object, specifying the output stream
            var output = new FileStream(("C:\\Users\\Carlos_2\\Downloads\\MyFirstPDF.pdf"), FileMode.Create);
            var writer = PdfWriter.GetInstance(document, output);
            // Open the Document for writing
            document.Open();
            // Create a new Paragraph object with the text, "Hello, World!"
            var welcomeParagraph = new Paragraph("MPLP");

            // Add the Paragraph object to the document
            document.Add(welcomeParagraph);

            if (null != info_proyectos) agregar_proyectos_PDF(ref document, info_proyectos);//llamar método que devuelva n páginas con proyectos
            if(null != info_disenos)//llamar método que devuelva n páginas con disenos
            if(null != info_casos) //llamar método que devuelva n páginas con casos
            if(null != info_ejecuciones) //llamar método que devuelva n páginas con ejecuciones


            // Close the Document - this saves the document contents to the output stream
            document.Close();

        }
       



        private void agregar_proyectos_PDF(ref Document documento, Object[]datos)
        {
            DataTable info_proyectos = null; 
            string []datos_incluidos = (string[])datos[0];

            //Se traen los datos relacionados con los proyectos.
            if ( typeof(string[])== datos[1].GetType())
            {
                info_proyectos = m_controladora_pyp.solicitar_proyectos_filtrados(((string[])datos[1]));
            }
            else
            {
                //info_proyectos = m_controladora_pyp.solicitar_proyectos_filtrados((List<string>)datos[1]);
            }

            for(int i=0; i<info_proyectos.Rows.Count; i++)
            {
                //agregar cosas al documento
                //Agregar datos con formato **aquí se escogerían campos a mostrar 
                //Por cada tres proyectos fila del DataTable crear una página?
                /*if(null != datos_incluidos[0])//incluir objetivos
                if(null != datos_incluidos[1]) // incluir diseños
                if(null != datos_incluidos[2]) // incluir fechas
                if(null != datos_incluidos[3]) // incluir oficina
                if(null != datos_incluidos[4])*/ // incluir miembros
                //agregar final de página
            }
        }
    }
}