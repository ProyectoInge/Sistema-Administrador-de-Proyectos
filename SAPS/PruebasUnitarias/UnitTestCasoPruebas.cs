using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAPS.Controladoras;
using SAPS.Entidades.Ayudantes;
using System.Data;

namespace PruebasUnitarias
{
    [TestClass]
    class UnitTestCasoPruebas
    {
        private ControladoraCasoPruebas m_controladora_cp = new ControladoraCasoPruebas();


        // -----------------------------------  Métodos de prueba para insertar casos de prueba -------------------------------------------------------------

        [TestMethod]
        /**@brief Metodo que evalua si se inserta un caso de prueba con los datos correctos, se inserta correctamente
        **/
        public void test_insertar_correcto()
        {
            Object[] datos = { "id_caso", "diseno", "id_requerimiento", "proposito", "resultados", "flujo" };
            Dato[] entrada_datos = new Dato[2];

            entrada_datos[0] = new Dato("Valor", "Valido"); 
            entrada_datos[1] = new Dato("Valor2", "InValido");

            int resultado = m_controladora_cp.insertar_caso_pruebas(datos, entrada_datos);
            int esperado = 0;

            Assert.AreEqual(resultado, esperado, "Se ingresa correctamente");
        }

        [TestMethod]
        /**@brief Metodo que evalua si se inserta un caso de prueba con los datos incorrectos, falla
        **/
        public void test_insertar_incorrecto()
        {
            object[] datos = { "id_caso2", "diseno", "id_requerimiento", 1234, "resultados", "flujo" };
            Dato[] entrada_datos = new Dato[2];

            entrada_datos[0] = new Dato("Valor", "Valido");
            entrada_datos[1] = new Dato("Valor2", "InValido");

            int resultado = m_controladora_cp.insertar_caso_pruebas(datos, entrada_datos);
            int esperado = 0;

            Assert.AreNotEqual(resultado, esperado, "Los valores ingresados son incorrectos");
        }


        // -----------------------------------  Métodos de prueba para modificar casos de prueba -------------------------------------------------------------


        [TestMethod]
        /**@brief Metodo que evalua si se modifica un caso de prueba correctamente
        **/
        public void test_modificar_correcto()
        {
            Object[] datos = { "id_caso", "diseno", "id_requerimiento", "proposito nuevo", "resultados nuevos", "flujo nuevos" };
            Dato[] entrada_datos = new Dato[2];

            entrada_datos[0] = new Dato("Valor", "Valido");
            entrada_datos[1] = new Dato("Valor2", "InValido");

            int resultado = m_controladora_cp.modificar_caso_pruebas(datos, entrada_datos);
            int esperado = 0;

            Assert.AreEqual(resultado, esperado, "Se ingresa correctamente");

            test_eliminar_correcto();

        }

        [TestMethod]
        /**@brief Metodo que evalua si no se modifica un caso de prueba 
        **/
        public void test_modificar_incorrecto()
        {
            Object[] datos = { "id_caso", "diseno", "id_requerimiento", 22222, "resultados nuevos", "flujo nuevos" };
            Dato[] entrada_datos = new Dato[2];

            entrada_datos[0] = new Dato("Valor", "Valido");
            entrada_datos[1] = new Dato("Valor2", "InValido");

            int resultado = m_controladora_cp.modificar_caso_pruebas(datos, entrada_datos);
            int esperado = 0;

            Assert.AreNotEqual(resultado, esperado, "Los valores ingresados son incorrectos");
        }


        // -----------------------------------  Métodos de prueba para eliminar casos de prueba -------------------------------------------------------------


        [TestMethod]
        /**@brief Metodo que evalua si se elimina correctamente un caso de prueba
        **/
        public void test_eliminar_correcto()
        {
            test_insertar_correcto();
            int resultado = m_controladora_cp.eliminar_caso_pruebas("id_caso");
            Assert.AreEqual(0, resultado, "Se elimina correctamente el caso de pruebas");

        }

        [TestMethod]
        /**@brief Metodo que evalua si se evita que se elimine un caso de prueba por fallo de datos
        **/
        public void test_eliminar_incorrecto()
        {
            test_insertar_correcto();
            int resultado = m_controladora_cp.eliminar_caso_pruebas("id_caso");
            Assert.AreEqual(0, resultado, "No se puede eliminar el caso de pruebas por fallo de datos");

            test_eliminar_correcto();
        }

        // -----------------------------------  Métodos de prueba para consultar casos de prueba -------------------------------------------------------------

        [TestMethod]
        /**@brief Metodo que evalua si se evita que se elimine un caso de prueba por fallo de datos
        **/
        public void test_consultar_correcto()
        {
            test_insertar_correcto();
            DataTable resultado = m_controladora_cp.consultar_caso_pruebas("id_caso");
            string valorA = resultado.Rows[0]["proposito"].ToString();

            Assert.AreEqual("proposito", valorA, "Se consulta correctamente el caso de prueba");
            test_eliminar_correcto();
        }

        [TestMethod]
        /**@brief Metodo que evalua si se evita que se elimine un caso de prueba por fallo de datos
        **/
        public void test_consultar_incorrecto()
        {
            test_insertar_correcto();
            DataTable resultado = m_controladora_cp.consultar_caso_pruebas("id_caso");
            string valorA = resultado.Rows[0]["proposito"].ToString();

            Assert.AreEqual("proposito", valorA, "Se consulta correctamente el caso de prueba");
            test_eliminar_correcto();
        }

    }
}
