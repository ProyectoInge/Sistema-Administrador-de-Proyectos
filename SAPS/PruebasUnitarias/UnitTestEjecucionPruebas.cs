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
        #region Pruebas insertar ejecuciones
        [TestMethod]
        public void agrega_ejecuciones_1()
        {
            Object[] datos_ejecucion = {0,"usuario", 3, "2015-11-27 00:00:00.000", "una incidencia muy uncidentada"};
            int resultado = m_controladora_ep.insertar_ejecucion(datos_ejecucion);
            int resultado_esperado = 0;
            Assert.AreEqual(resultado_esperado, resultado, "La inserción se realizó con éxito.");
        }

        [TestMethod]
        public void agrega_ejecucion_2()
        {
            Object[] datos_ejecucion = { 92, "usuario", "bla bla bla" };
            int resultado = m_controladora_ep.insertar_ejecucion(datos_ejecucion);
            int no_esperado = 0;
            Assert.AreNotEqual(no_esperado, resultado, "No lo logra ingresar ya que faltan datos");
        }

        [TestMethod]
        public void agregar_ejecucion_3()
        {
            Object[] datos = { 0, "usuario", 3, "2015-11-27 00:00:00.000", "una incidencia muy uncidentada", 87, "hola" };
            int resultado = m_controladora_ep.insertar_ejecucion(datos);
            int no_esperado = 0;
            Assert.AreNotEqual(no_esperado, resultado, "No lo logra ingresar ya que son demasiados datos");
        }
        #endregion
        #region Pruebas insertar resultados
        /*
                | Índice | Descripción             | Tipo de datos |
                |:------:|:-----------------------:|:-------------:|
                |    0   |  Numero de resultado    |      int      |
                |    1   |  Id del diseno          |      int      |
                |    2   |  Numero de ejecucion    |      int      |
                |    3   |  Estado                 |     string    |
                |    4   |  Tipo No Conformidad    |     string    |
                |    5   |  Id del Caso            |     string    |
                |    6   |  Descripcion No Conf.   |     string    |
                |    7   |  Justificacion          |     string    |
                |    8   |  Ruta de la imagen      |     string    |
            */
        [TestMethod]
        public void agregar_resultado_1()
        {
            Object[] datos = { 8, 3, 4, "Satisfactoria", "No aplica", "DP_E31", "No conforme", "Justificado", "" };
            int resultado = m_controladora_ep.insertar_resultado(datos);
            int esperado = 0;
            Assert.AreEqual(esperado, resultado, "Se agrego el resultado correctamente");
        }

        [TestMethod]
        public void agregar_resultado_2()
        {
            Object[] datos = { 8, 3, 4, "Satisfactoria", "No aplica", "DP_E31", "No conforme" };
            int resultado = m_controladora_ep.insertar_resultado(datos);
            int no_esperado = 0;
            Assert.AreNotEqual(no_esperado, resultado, "No tiene suficientes datos para agregar un resultado");
        }

        [TestMethod]
        public void agregar_resultado_3()
        {
            Object[] datos = { 8, 3, 4, "Satisfactoria", "No aplica", "DP_E31", "No conforme", 7878, "bla bla bla", 8773, "bla bla bla" };
            int resultado = m_controladora_ep.insertar_resultado(datos);
            int no_esperado = 0;
            Assert.AreNotEqual(no_esperado, resultado, "Son demasiados datos para agregar el resultado");
        }
        #endregion
    }
}
