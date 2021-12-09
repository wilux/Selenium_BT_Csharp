using NUnit.Framework;
using BT_Selenium.Tasks;
using BT_Selenium.Task;
using BT_Selenium.Tools;
using BT_Selenium.Actions;

namespace BT_Selenium.TestCase
{

    [TestFixture]
    public class InstanciaTest : BaseTest_Reporte
    {

        //Ante de empezar todas las pruebas
        [OneTimeSetUp]
        public void Before()
        {
            Login.In(driver);
        }

      //  [Test]
        public void Buscar()
        {
           // IrHasta.SimularProducto(driver, documento);

            IrHasta.BandejaDeTareas(driver);
            BandejaTareas.BuscarInstancia(driver, "2464825");
        }

    }
}
