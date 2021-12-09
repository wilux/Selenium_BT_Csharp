using NUnit.Framework;
using BT_Selenium.Task;

namespace BT_Selenium.TestCase
{

    [TestFixture]
    public class TemplateTest : BaseTest_Reporte
    {

        //Ante de empezar todas las pruebas
        [OneTimeSetUp]
        public void Before()
        {
            Login.In(driver);
        }

        //Descomentar el que se usará

        //[TestCase("20303879618")]    --> Mas de uno
        //[Test] --> Un solo caso
        public void TestXX()
        {


        }

        //Al finalizar una prueba individual (cuando hay mas de una)
        //[TearDown]
        //public void AfterTest()
        //{

        //}

        ////Al finalizar todas las pruebas (cuando es mas de una)
        //[OneTimeTearDown]
        //public void After()
        //{
        //    try
        //    {

        //    }
        //    catch { }
        //}

    }
}
