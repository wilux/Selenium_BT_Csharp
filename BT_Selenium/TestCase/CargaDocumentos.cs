using BT_Selenium.Actions;
using BT_Selenium.Task;
using BT_Selenium.Tasks;
using BT_Selenium.Tools;
using BT_Selenium.UI;
using NUnit.Framework;

namespace BT_Selenium.TestCase
{

    [TestFixture]
    public class CargaDocumentos : BaseTest
    {
      //  [TestCase("27307925597")]

        public void RF02(string documento)
        {
            Login.As(driver, "dechands");
            Menu.Inicio(driver);
            Menu.WorkFlow(driver);
            Menu.BandejaTareas(driver);

            BandejaTareas.Ejecutar(driver);

            Documentacion.Fecha(driver);
            Documentacion.AnioCierre(driver);
            //Documentacion.SeleccionarFila(driver);
            //Documentacion.Agregar(driver);
            AgregarDocumento.Auto(driver);
        }

    }
}
