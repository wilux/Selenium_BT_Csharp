using NUnit.Framework;
using BT_Selenium.Task;
using OpenQA.Selenium;
using System;
using BT_Selenium.Actions;
using BT_Selenium.UI;
using System.Threading;
using BT_Selenium.Tools;

namespace BT_Selenium.TestCase
{

    [TestFixture]
    public class TestCalificacion : BaseTest_Reporte
    {
        //Ante de empezar todas las pruebas
        [OneTimeSetUp]
        public void Before()
        {
            Login.In(driver);

            //Iniciar hasta CUIL/CUIT
            Menu.Inicio(driver);
            Menu.WorkFlow(driver);
            Menu.BandejaTareas(driver);
        }


      [TestCase("27120204217", "2000000")]
      [TestCase("20257872301", "2000000")]
        public void CalificarTest(string cuil, string ingresos)
        {
            //Iniciar Instancia
            BandejaTareas.Iniciar(driver);
            NuevaInstancia.Entrevista(driver);

            //Ingresar CUIL
            Entrevista.IngresarDocumento(driver, cuil);

            ////Pantalla Entrevista
            ///Completar Datos que falten
            Entrevista.DatosPersonales(driver);
            Entrevista.Ocupacion(driver);
            Entrevista.DatosContacto(driver);
            ////Seleccionar Cuenta
            Entrevista.BuscarCuenta(driver);
            ////Ingresos
            Entrevista.Ingresos(driver, "PUB", "500000", ingresos);
            ////Confirmar Entrevista
            Entrevista.Confirmar(driver);
            //string nroEntrevista = Entrevista.NroEntrevista(driver);
            //Cerrar
            Entrevista.Cerrar(driver);

            //Retomar de Bandeja
            BandejaTareas.Siguiente(driver);
            BandejaTareas.Ejecutar(driver);

            //Simulacion
            Select.ByValue(driver, SimulacionProductosUI.SelectPaquete, "0");
            CheckBox.UnCheck(driver, SimulacionProductosUI.CheckPrestamo);
            CheckBox.Check(driver, SimulacionProductosUI.CheckCalificacion);
            Select.ByValue(driver, SimulacionProductosUI.SelectCircuito, "BE");
            CheckBox.UnCheck(driver, SimulacionProductosUI.CheckCtaCte);
            CheckBox.UnCheck(driver, SimulacionProductosUI.CheckTarjeta);

            SimulacionProductos.Confirmar(driver);

            BandejaTareas.Seleccionar(driver);
            string comentario = Get.SpanText(driver, BandejaTareasUI.spanComentarioFila);
            Assert.That(comentario == "Validación Cliente");

        }

        [TearDown]
        public void After()
        {
            try
            {
                SimulacionProductos.Cerrar(driver);
            }
            catch { }

            driver.SwitchTo().DefaultContent();
        }

    }
}
