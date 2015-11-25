using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAPS.Controladoras;
using System.Data;

namespace PruebasUnitarias
{
    [TestClass]
    public class UnitTestEjecucionPruebas
    {
        private ControladoraEjecuciones m_controladora_ep = new ControladoraEjecuciones();

        // ------------------------------- Pruebas de insertar ejecuciones y resultados -------------------------------
        [TestMethod]
        public void agrega_ejecuciones_1()
        {
            Object[] datos_ejecucion = {0,"usuario", 3, "2015-11-27 00:00:00.000", "una incidencia muy uncidentada"};
            int resultado = m_controladora_ep.insertar_ejecucion(datos_ejecucion);
            int resultado_esperado = 0;
            Assert.AreEqual(resultado_esperado, resultado, "La inserción se realizó con éxito.");
        }

        // --------------------------------- Pruebas de consulta de datos -----------------------------------------------
        [TestMethod]
        public void consulta_ejecuciones()
        {
            int id_diseno = 4;
            int cantidad_ejecuciones_relacinadas_con_diseno = 1;
            DataTable ejecuciones = m_controladora_ep.consultar_ejecuciones(id_diseno);
            Assert.AreEqual(cantidad_ejecuciones_relacinadas_con_diseno, ejecuciones.Rows.Count);
        }

        [TestMethod]
        public void consulta_ejecucion()
        {
            int id_diseno = 4;
            int id_ejecucion_consultar = 5;
            string responsable = "test";
            string fecha = "2015-11-25";
            string incidencias = "Incidente test";

            DataTable ejecucion = m_controladora_ep.consultar_ejecucion(id_ejecucion_consultar);
            Assert.AreEqual(Convert.ToInt32(ejecucion.Rows[0]["num_ejecucion"]), id_ejecucion_consultar);
            Assert.AreEqual(Convert.ToInt32(ejecucion.Rows[0]["id_diseno"]), id_diseno);
            Assert.AreEqual(ejecucion.Rows[0]["responsable"], responsable);
            Assert.AreEqual(Convert.ToDateTime(ejecucion.Rows[0]["fecha_ultima_ejec"]).ToString("yyyy-MM-dd"), fecha);
            Assert.AreEqual(ejecucion.Rows[0]["incidencias"], incidencias);
        }

        [TestMethod]
        public void consulta_resultados_ejecucion()
        {
            int id_ejecucion_consultar = 5;
            DataTable resultados_ejecucion = m_controladora_ep.consultar_resultados(id_ejecucion_consultar);

            string estado = "Satisfactoria";
            string tipo_de_no_conformidad = "Funcionalidad";
            string desc_no_conformidad = "Test";
            string justificacion = "Test";

            Assert.AreEqual(resultados_ejecucion.Rows[0]["estado"], estado);
            Assert.AreEqual(resultados_ejecucion.Rows[0]["tipo_no_conformidad"], tipo_de_no_conformidad);
            Assert.AreEqual(resultados_ejecucion.Rows[0]["desc_no_conformidad"], desc_no_conformidad);
            Assert.AreEqual(resultados_ejecucion.Rows[0]["justificacion"], justificacion);
        }
    }
}
