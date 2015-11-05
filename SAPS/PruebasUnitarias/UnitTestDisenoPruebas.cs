using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAPS.Controladoras;

namespace PruebasUnitarias
{
    [TestClass]
    public class UnitTestDisenoPruebas
    {
        private ControladoraDisenosPruebas m_controladora_dp = new ControladoraDisenosPruebas();
        [TestMethod]
        public void test_insertar_diseno_1()
        {
            DateTime fecha = new DateTime(2015, 08, 22);
            Object[] datos = { 0, 1, "Prueba diseño", fecha, "bla", "bla", "bla", "fabo49" };
            int resultado = m_controladora_dp.insertar_diseno_pruebas(datos);
            int esperado = 0;
            Assert.AreEqual(esperado, resultado, "Se ingreso el diseño correctamente");
        }

        /// @todo Todas las demas pruebas de unidad.
    }
}
