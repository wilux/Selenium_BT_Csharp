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
    // Simula Prestamo sin Limite
    // No se debe romper marco pantalla


    [TestFixture, Description("Simula Prestamo. Sin limites ")]
    public class GDEM610_RF04_Test4
    {
        //Selenium Driver
        protected IWebDriver driver = new InternetExplorerDriver("C:\\webdriver\\");
        protected string QaURL = "http://btwebqa.ar.bpn/BTWeb/hlogin.aspx";
        private bool stop;
        protected string usuario = "dechands";
        protected string documento = "20076874337";
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
            //Simular
            BandejaTareas.Ejecutar(driver);
            SimulacionProductos.Paquete(driver);
            WaitHandler.Wait(5000);
            SimulacionProductos.CheckPrestamo(driver);
            WaitHandler.Wait(5000);
            Capturar.Pantalla(driver, "Test4", documento);
            nroEntrevista = Entrevista.NroEntrevista(driver);
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
