using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAPS.Controladoras;

namespace PruebasUnitarias
{
    [TestClass]
    public class UnitTestRequerimientos
    {
        private ControladoraRequerimientos m_controladora_requerimientos = new ControladoraRequerimientos();

        // ---------------------------------- Pruebas de insertar requerimientos ----------------------------------
        [TestMethod]
        public void test_insertar_requerimiento()
        {
            Object[] datos = { 0, "Requerimiento de prueba" };
            int resultado = m_controladora_requerimientos.insertar_requerimiento(datos);
            int resultado_esperado = 0;
            Assert.AreEqual(resultado_esperado, resultado, "La inserción se realizó con éxito.");
        }

        [TestMethod]
        public void test_insertar_requerimiento_2()
        {
            Object[] datos = { 0, "Requerimento 2", 87 };
            int resultado = m_controladora_requerimientos.insertar_requerimiento(datos);
            int resultado_esperado = 0;
            Assert.AreEqual(resultado_esperado, resultado, "Aunque hayan mas datos, solo se cuentan los primeros 2");
        }

        [TestMethod]
        public void test_insertar_requerimiento_3()
        {
            Object[] datos = { 0, null };
            int resultado = m_controladora_requerimientos.insertar_requerimiento(datos);
            int esperado = 0;
            Assert.AreNotEqual(esperado, resultado, "No deberia de dar 0 ya que faltan datos en el vector.");
        }

        [TestMethod]
        public void test_insertar_requerimiento_4()
        {
            Object[] datos = new Object[2];
            int resultado = m_controladora_requerimientos.insertar_requerimiento(datos);
            int esperado = 0;
            Assert.AreNotEqual(esperado, resultado, "No se inicializo el vector, por lo que debe dar error");
        }


        // ---------------------------------- Pruebas de eliminar requerimientos ----------------------------------

    }
}
