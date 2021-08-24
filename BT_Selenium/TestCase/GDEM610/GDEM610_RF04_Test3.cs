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
    // Simula Alta Nueva 20/1 tiene 20/5 sobregirada "
    // Msg: No puede realizar el alta de Cta.Cte (20-1) ya que el Acuerdo Vigente(20-5) está Sobregirado. No permite avanzar.


       [TestFixture, Description("Simula Prestamo. Tiene 20/1 y 20/5 ")]
    public class GDEM610_RF04_Test3
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
            string mensajeEsperado = "";
            string mensajeObtenido = "";
            //Simular
            BandejaTareas.Ejecutar(driver);
            SimulacionProductos.PaqueteNombre(driver, producto); //20/1
            WaitHandler.Wait(5000);
            Capturar.Pantalla(driver, "Test3", documento);
            mensajeObtenido = SimulacionProductos.GetMensaje(driver);
            SimulacionProductos.UnCheckPrestamo(driver);
            bool boton = WaitHandler.IsEnable(driver, SimulacionProductosUI.BTNOPCONFIRMAR);
            //Exito si Hay mensaje (ver mensaje) y si el boton esta deshabilitado
            nroEntrevista = Entrevista.NroEntrevista(driver);
            Assert.IsTrue(mensajeEsperado != mensajeObtenido && boton == false);
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
