using BT_Selenium.Actions;
using BT_Selenium.UI;
using NUnit.Framework;
using BT_Selenium.Tools;
using BT_Selenium.Tasks;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using NUnit.Framework.Interfaces;

namespace BT_Selenium.TestCase.GDEM610
{
    // Alta de 20/1 para cliente con paquete y 20/5 C/ ACC

    // En SimulacionProducto debe salir mensaje: "El Acuerdo de la Cta.Cte. 20-1 reemplazará al Vigente"
    // Al confirmar producto por gerente y creditos se debe bajar ACC 20/5


    [TestFixture, Description("Alta de 20/1 con 20/5")]
    public class GDEM610_RF04_Test1
    {
        //Selenium Driver
        protected IWebDriver driver = new InternetExplorerDriver("C:\\webdriver\\");
        protected string QaURL = "http://btwebqa.ar.bpn/BTWeb/hlogin.aspx";
        private bool stop;
        protected string usuario = "dechands";
        protected string documento = "27363826550";
        protected string producto = "CTA.CORRIENTE $";
        protected string test = "Test1";
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
            string mensajeEsperado = "El Acuerdo de la Cta.Cte. 20-1 reemplazará al Vigente";
            string mensajeObtenido = "";
            //Simular
            SimulacionProductos.PaqueteNombre(driver, producto);
            WaitHandler.Wait(5000);
            Capturar.Pantalla(driver, test, documento);
            mensajeObtenido = SimulacionProductos.GetMensaje(driver);
            SimulacionProductos.UnCheckPrestamo(driver);
            SimulacionProductos.Confirmar(driver);
            nroEntrevista = Entrevista.NroEntrevista(driver);
            Assert.IsTrue(mensajeEsperado == mensajeObtenido);
        }

        [Test, Order(4)]
        public void Carga_Avanzada()
        {
            //Bandeja Tareas
            BandejaTareas.Tomar(driver);

            //Pantalla Carga Avanzada
            //Setea consulta Bridger Insight
            BridgerInsight.Consultar(documento, usuario);
            CargaAvanzada.OrigenFondos(driver);
            CargaAvanzada.Aceptar(driver);
        }

        [Test, Order(5)]
        public void ReutilizacionProducto()
        {
            //Bandeja Tareas
            BandejaTareas.Tomar(driver);

            //Pantalla Reutilizacion Productos
            ReutilizacionABMProductos.SeleccionarSeguroVida(driver);
            ReutilizacionABMProductos.SeleccionarTarjeta(driver);
            ReutilizacionABMProductos.Aceptar(driver);
            ReutilizacionABMProductos.PerfilRiesgo(driver);
        }

        [Test, Order(6)]
        public void Matriz_Riesgo()
        {
            //Pantall Matriz Riesgo
            MatrizRiesgo.Confirmar(driver);
            MatrizRiesgo.Cerrar(driver);
        }



        [Test, Order(7)]
        public void ConfirmacionGerente()
        {
            ConfirmarInstanciaSuperior.Gerente(driver, documento, "liriac");
        }

        [Test, Order(8)]
        public void ConfirmacionCreditos()
        {
            ConfirmarInstanciaSuperior.Creditos(driver, documento, "totij");
        }

        [Test, Order(9)]
        public void ComprobarAcuerdo()
        {
            //Consultar la DB si el acuerdo modulo 49 esta dado de baja

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
