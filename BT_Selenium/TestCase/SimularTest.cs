using NUnit.Framework;
using BT_Selenium.Task;


namespace BT_Selenium.TestCase
{

    [TestFixture]
    public class SimularTest : BaseTest
    {

        //Ante de empezar todas las pruebas
        [OneTimeSetUp]
        public void Before()
        {
            Login.In(driver);
            Menu.Inicio(driver);
            Menu.WorkFlow(driver);
            Menu.BandejaTareas(driver);
        }

        //Casos listos para simular
        [TestCase("20310994481", "PUB", "300000", "300000")]
        [TestCase("27274067948", "PUB", "300000", "300000")]
        public void SimularProductos(string documento, string sector, string ingresoDependiente, string ingresoIndependiente)
        {

            BandejaTareas.Iniciar(driver);
            NuevaInstancia.Entrevista(driver);
            Entrevista.Completar(driver, documento, sector, ingresoDependiente, ingresoIndependiente );
            BandejaTareas.Siguiente(driver);

        }

        //[TearDown]
        //public void AfterTest()
        //{

        //}


        [OneTimeTearDown]
        public void After()
        {
            try
            {

            }
            catch { }
        }

    }
}
