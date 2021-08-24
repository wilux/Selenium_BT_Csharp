using BT_Selenium.Actions;
using BT_Selenium.UI;
using NUnit.Framework;
using BT_Selenium.Tools;
using BT_Selenium.Tasks;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using NUnit.Framework.Interfaces;
using BT_Selenium.Task;

namespace BT_Selenium.TestCase.GDEM610
{
    // "Simula Prestamo y tiene Paquete 20/1 y 20/5 C/ACC. "
    // "No debe muestrar mensaje de 20/5 sin acuerdo"

    [TestFixture, Description("Simula Prestamo. Tiene 20/1 y 20/5 ")]
    public class GDEM610_RF04_Test2
    {
        //Selenium Driver
        protected IWebDriver driver = new InternetExplorerDriver("C:\\webdriver\\");
        protected string QaURL = "http://btwebqa.ar.bpn/BTWeb/hlogin.aspx";
        private bool stop;
        protected string usuario = "dechands";
        protected string documento = "20209502209";
        protected string producto = "CTA.CORRIENTE $";
        protected string test = "Test2";
        protected string nroEntrevista = "";


        [Test, Order(1)]
        public void Home()
        {
            _ = new InternetExplorerOptions
            {
                EnsureCleanSession = true,
                RequireWindowFocus = true
            };

            //driver = new InternetExplorerDriver("C:\\webdriver\\");
            driver.Navigate().GoToUrl(QaURL);
            driver.Manage().Window.Maximize();

            Login.As(driver, usuario);
        }

        [Test, Order(2)]
        public void IniciarEntrevista()
        {
            Entrevista.Iniciar(driver);
            Entrevista.IngresarDocumento(driver, documento);

            ////Pantalla Entrevista
            ////Completamos Datos Contacto
            Entrevista.Completar_DatosContacto(driver);
            Entrevista.SeleccionarCuentaCredito(driver);
            Entrevista.IngresosPF(driver);
            Entrevista.Confirmar(driver);
            Entrevista.Cerrar(driver);
        }



        [Test, Order(3)]
        public void SimularProducto()
        {
            //string mensajeEsperado = "";
            string mensajeObtenido = "";
            //Simular
            BandejaTareas.Ejecutar(driver);
            SimulacionProductos.Paquete(driver);//Busca el primero
            WaitHandler.Wait(5000);
            Capturar.Pantalla(driver, "Test2", documento);
            mensajeObtenido = SimulacionProductos.GetMensaje(driver);
            SimulacionProductos.CheckPrestamo(driver);
            nroEntrevista = Entrevista.NroEntrevista(driver);
            Assert.IsTrue(mensajeObtenido == "");
        }


        [SetUp]
        public void BeforeBaseTest()
        {
            if (stop)
            {
                try
                {
                    Assert.Inconclusive("Un test anterior falló.");
                }
                catch { }
            }


        }
        [TearDown]
        public void AfterBaseTest()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                stop = true;
                Reporte.Logger(test + "Nro Entrevista: " + nroEntrevista);
                //if (driver != null)
                //{
                //    driver.Quit();

                //}
            }

        }
    }

}
