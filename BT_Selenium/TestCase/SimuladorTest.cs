using NUnit.Framework;
using BT_Selenium.Tasks;
using BT_Selenium.Task;
using BT_Selenium.Tools;
using BT_Selenium.Actions;
using System.Threading;
using BT_Selenium.UI;

namespace BT_Selenium.TestCase
{

    [TestFixture]
    public class SimuladorTest : BaseTest
    {

        //Ante de empezar todas las pruebas
        [OneTimeSetUp]
        public void Before()
        {
            Login.In(driver);
            //IrHasta.SimularProducto(driver, "27305849354", "500000");
            IrHasta.BandejaDeTareas(driver);
            BandejaTareas.Filtrar(driver, "1010261");
            BandejaTareas.Ejecutar(driver);

        }

        //[TestCase(0)]
        //[TestCase(1)]
        //[TestCase(2)]
        //[TestCase(3)]
        //[TestCase(4)]
        //[TestCase(5)]
        //[TestCase(6)]
        //[TestCase(7)]
        public void Simulador(int cantidad)
        {
        

           if( Select.Cantidad(driver, SimulacionProductosUI.SelectPaquete)<cantidad)
            {
                Thread.CurrentThread.Abort();
            }
            //Pantalla Simulacion

                SimulacionProductos.Paquete(driver, cantidad);
                Thread.Sleep(6000);
                bool check = driver.FindElement(SimulacionProductosUI.checkActualizarAcc).GetAttribute("CHECKED") == "checked";
           // Capturar.Pantalla(driver, "Test" + cantidad.ToString(), documento);
            Assert.False(check);
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
