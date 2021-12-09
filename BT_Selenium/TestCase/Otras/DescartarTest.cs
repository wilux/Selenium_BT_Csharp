using BT_Selenium.Task;
using NUnit.Framework;

namespace BT_Selenium.TestCase
{
   [TestFixture]
    public class DescartarTest : BaseTest_Reporte
    {


       // [Test]
        public void Descartar()
        {
            try
            {
                DescartarTarea.DescartarTareas(driver);
            }
            catch { }
        }

    }
}
