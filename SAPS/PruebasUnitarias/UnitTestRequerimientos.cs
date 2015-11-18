using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAPS.Controladoras;
using System.Data;

namespace PruebasUnitarias
{
    [TestClass]
    public class UnitTestRequerimientos
    {
        private ControladoraRequerimientos m_controladora_requerimientos = new ControladoraRequerimientos();

        // ---------------------------------- Pruebas de insertar requerimientos ----------------------------------
        [TestMethod]
        public void test_insertar_requerimiento_1()
        {
            Object[] datos = { "CP_I", "Insertar un caso de prueba.", "Criterio 1, criterio 2, criterio 3."};
            int resultado = m_controladora_requerimientos.insertar_requerimiento(datos);
            int resultado_esperado = 0;
            Assert.AreEqual(resultado_esperado, resultado, "La inserción se realizó con éxito.");
        }

        [TestMethod]
        public void test_insertar_requerimiento_2()
        {
            Object[] datos = { "CP_M", "Modificar un caso de prueba.", "Criterio 1, criterio 2", 89 };
            int resultado = m_controladora_requerimientos.insertar_requerimiento(datos);
            int resultado_esperado = 0;
            Assert.AreEqual(resultado_esperado, resultado, "Aunque hayan mas datos, solo se cuentan los primeros 2");
        }

        [TestMethod]
        public void test_insertar_requerimiento_3()
        {
            Object[] datos = { "PYP_E", null, null };
            int resultado = m_controladora_requerimientos.insertar_requerimiento(datos);
            int no_esperado = 0;
            Assert.AreNotEqual(no_esperado, resultado, "No deberia de dar 0 ya que faltan datos en el vector.");
        }

        [TestMethod]
        public void test_insertar_requerimiento_4()
        {
            Object[] datos = new Object[2];
            int resultado = m_controladora_requerimientos.insertar_requerimiento(datos);
            int no_esperado = 0;
            Assert.AreNotEqual(no_esperado, resultado, "No se inicializo el vector, por lo que debe dar error");
        }

        // ---------------------------------- Pruebas de eliminar requerimientos ----------------------------------
        [TestMethod]
        public void test_eliminar_requerimiento_1()
        {
            int resultado = m_controladora_requerimientos.eliminar_requerimiento("CP_M");
            int esperado = 0;
            Assert.AreEqual(esperado, resultado, "Se eliminó correctamente el requerimiento");
        }

        [TestMethod]
        public void test_eliminar_requerimiento_2()
        {
            int resultado = m_controladora_requerimientos.eliminar_requerimiento("DP_BLA");
            int no_esperado = 0;
            Assert.AreNotEqual(no_esperado, resultado, "El ID 200 no existe entonces da error");
        }

        // ---------------------------------- Pruebas de consultar requerimientos ----------------------------------

        [TestMethod]
        public void test_consultar_requerimiento_1()
        {
            DataTable resultado = m_controladora_requerimientos.consultar_requerimiento("RH_M");
            string nombre_requerimiento = Convert.ToString(resultado.Rows[0]["nombre"]);
            string esperado = "Requerimiento 2";
            Assert.AreEqual(esperado, nombre_requerimiento, "Se consulto el requerimiento correctamente");
        }

        [TestMethod]
        public void test_consultar_requerimiento_2()
        {
            DataTable resultado = m_controladora_requerimientos.consultar_requerimiento("DP_I");
            string nombre_requerimiento = Convert.ToString(resultado.Rows[0]["nombre"]);
            string no_esperado = "Perro";
            Assert.AreNotEqual(no_esperado, nombre_requerimiento, "Efectivamente, los valores no coinciden");
        }

        // ---------------------------------- Pruebas de consultar requerimientos ----------------------------------

        [TestMethod]
        public void test_modificar_requerimiento_1()
        {
            Object[] datos = { "DP_E", "Cambio requerimiento", "Criterio modificado 1" };
            int resultado = m_controladora_requerimientos.modificar_requerimiento(datos);
            int esperado = 0;
            Assert.AreEqual(esperado, resultado, "Se logro modificar con exito el requerimiento");
        }

        [TestMethod]
        public void test_modificar_requerimiento_2()
        {
            Object[] datos = { "ID_NOEXISTE", "Perro", "Bla"};
            int resultado = m_controladora_requerimientos.modificar_requerimiento(datos);
            int no_esperado = 0;
            Assert.AreNotEqual(no_esperado, resultado, "El ID no corresponde entonces no hizo el cambio");
        }
    }
}
