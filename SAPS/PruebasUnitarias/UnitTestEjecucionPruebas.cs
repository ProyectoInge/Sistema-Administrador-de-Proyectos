using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAPS.Controladoras;

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
    }
}
