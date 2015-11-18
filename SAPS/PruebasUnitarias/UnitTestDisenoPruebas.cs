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
            Object[] datos = { 0, 1, "Prueba diseño", fecha, "bla", "bla", "bla", "fabo49", "ambiente", "criterio" };
            int resultado = m_controladora_dp.insertar_diseno_pruebas(datos);
            int esperado = 0;
            Assert.AreEqual(esperado, resultado, "Se ingreso el diseño correctamente");
        }

        [TestMethod]
        public void test_insertar_diseno_2()
        {
            Object[] datos = { 0, 3, "Prueba erronea", "2003-09-12", "bla", "bla", "root" };
            int resultado = m_controladora_dp.insertar_diseno_pruebas(datos);
            int no_esperado = 0;
            Assert.AreNotEqual(no_esperado, resultado, "No se agrega ya faltan elementos en el array");
        }

        [TestMethod]
        public void test_insertar_diseno_3()
        {
            Object[] datos = { 0, 3, "Prueba erronea", "2003-09-12", "bla", "bla","bla", "bla", "root", "ambiente", "criterio" };
            int resultado = m_controladora_dp.insertar_diseno_pruebas(datos);
            int no_esperado = 0;
            Assert.AreNotEqual(no_esperado, resultado, "No se agrega ya que son demasiados elementos en el array");
        }

        /// @todo Todas las demas pruebas de unidad.
    }
}
