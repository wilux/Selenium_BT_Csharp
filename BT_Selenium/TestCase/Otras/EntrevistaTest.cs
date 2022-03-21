using NUnit.Framework;
using BT_Selenium.Task;
using BT_Selenium.Tools;

namespace BT_Selenium.TestCase
{

    [TestFixture]
    public class EntrevistaTest : BaseTest
    {

        //Ante de empezar todas las pruebas
        [OneTimeSetUp]
        public void Before()
        {
            Login.In(driver);
            
        }

        //Prueba de Pantalla Entrevista
        //Tiempo que demora en completar datos

        [TestCase("20134627914")]
        public void Completar(string documento)
        {

            Entrevista.Iniciar(driver);
            Entrevista.Completar(driver, documento);

        }

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
