using OpenQA.Selenium;
using BT_Selenium.Actions;
using BT_Selenium.UI;
using BT_Selenium.Tools;
using BT_Selenium.Task;

namespace BT_Selenium.Tasks
{
    public class AsistenciaCrediticia
    {
        public static void SeleccionarModulo(IWebDriver driver, string valor)
        {
            Select.ByValue(driver, AsistenciaCrediticiaUI.SelectModulo, valor);
             
        }

        public static void SeleccionarTipoOP(IWebDriver driver, string valor)
        {
            Select.ByValue(driver, AsistenciaCrediticiaUI.SelectLinea, valor);

        }

        public static void Confirmar(IWebDriver driver)
        {
            Click.On(driver, AsistenciaCrediticiaUI.BTNOPCONFIRMAR);
            WaitHandler.Wait(3);
            Click.On(driver, AsistenciaCrediticiaUI.BTN_SI);

        }

    }
}
