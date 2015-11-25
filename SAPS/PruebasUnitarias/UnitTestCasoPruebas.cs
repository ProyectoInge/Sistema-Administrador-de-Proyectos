using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAPS.Controladoras;
using SAPS.Entidades.Ayudantes;

namespace PruebasUnitarias
{
    [TestClass]
    class UnitTestCasoPruebas
    {
        private ControladoraCasoPruebas m_controladora_cp = new ControladoraCasoPruebas();


        // -----------------------------------  Métodos de prueba para insertar casos de prueba -------------------------------------------------------------

        [TestMethod]
        /**@brief Metodo que evalua si un caso de prueba con los datos correctos se inserta correctamente
        **/
        public void test_insertar_correcto()
        {
            Object[] datos = { "id_caso", "diseno", "id_requerimiento", "proposito", "resultados", "flujo" };
            Dato[] entrada_datos = new Dato[2];

            entrada_datos[0] = new Dato("Valor", "Valido"); 
            entrada_datos[1] = new Dato("Valor2", "InValido");

            int resultado = m_controladora_cp.insertar_caso_pruebas(datos, entrada_datos);
            int esperado = 0;

            Assert.AreEqual(resultado, esperado);
        }

        [TestMethod]
        /**@brief Metodo que evalua si un caso de prueba con los datos incorrectos falla
        **/
        public void test_insertar_incorrecto()
        {

        }



    }
}
